using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using TDDD49_Chess.Game.GameObject;

namespace TDDD49_Chess.Game.Persistance
{
    /// <summary>
    /// Creates data to be store from the current chess state.
    /// Can load a chess state from stored data.
    /// 
    /// This implementation uses XML files as data storage.
    /// Throws exceptions and  lets the persistor determine how to handle.
    /// </summary>
    public class DataStore :IDataStore
    {
        private String _xml_path;
        private const String ROOT_NAME = "Moves";
        
        public void AddState(IChessEngine chessEngine)
        {
            var moves = chessEngine.GetMoveHistory();
            var latestMove = moves.Last();
            if(latestMove != null)
            {
                XDocument xml_storage;
                if(!File.Exists(_xml_path))
                {
                    xml_storage = new XDocument();
                    xml_storage.Add(new XElement(ROOT_NAME));
                }
                else
                {
                    xml_storage = XDocument.Load(_xml_path);
                }
                xml_storage.Element(ROOT_NAME).Add(createFrom(latestMove));
                xml_storage.Save(_xml_path);
            }
        }

        private XElement createFrom(Move move)
        {
            return new XElement("Move",
                new XElement("From", move.From.ToString()), 
                new XElement("To", move.To.ToString()),
                new XElement("MovedPiece", move.MovedPiece.ToString()),
                new XElement("CapturedPiece", move.CapturedPiece.ToString()));
        }

        public void Load(IChessEngine chessEngine)
        {
            if(File.Exists(_xml_path))
            {
                XDocument xml = XDocument.Load(_xml_path);
                var moves = from move in xml.Descendants("Move")
                            select new
                            {
                                From = Point.FromString(move.Element("From").Value),
                                To = Point.FromString(move.Element("To").Value),
                                MPiece = Square.FromString(move.Element("MovedPiece").Value),
                                CPiece = Square.FromString(move.Element("CapturedPiece").Value)
                            };
                var convertedMoves = new List<Move>();
                int count = 1;
                foreach(var move in moves)
                {
                    convertedMoves.Add(new Move(count, move.From, move.To, move.MPiece, move.CPiece));
                }
                chessEngine.GenerateBoardSetup(convertedMoves);
            }
        }

        public void Clear()
        {
            XDocument xml;
            if (File.Exists(_xml_path))
            {
                xml = XDocument.Load(_xml_path);
                xml.RemoveNodes();
            }
            else
            {
                xml = new XDocument();
            }
            xml.Add(new XElement(ROOT_NAME));
            xml.Save(_xml_path);
        }

        public void SetupDataStore(string connectionDetails)
        {
            _xml_path = connectionDetails;
            
            if(File.Exists(_xml_path))
            {
                try
                {
                    var storage = XDocument.Load(_xml_path);
                    if (storage.Element(ROOT_NAME) != null)
                    {
                        return; //Properly loaded
                    }
                }
                catch(Exception e)
                {

                }
            }
                
            var xml_storage = new XDocument();
            xml_storage.Add(new XElement(ROOT_NAME));
            xml_storage.Save(_xml_path);
        }

        public void AddMetadata(string identifier, string value)
        {
            if(File.Exists(_xml_path))
            {
                try
                {
                    var xml_storage = XDocument.Load(_xml_path);
                    if (xml_storage.Element(ROOT_NAME) == null)
                        xml_storage.Add(new XElement(ROOT_NAME));
                    if(xml_storage.Element("Metadata") == null)
                        xml_storage.Element(ROOT_NAME).Add(new XElement("Metadata"));
                    xml_storage.Element(ROOT_NAME).Element("Metadata").Add(
                        new XElement(identifier, value));
                    xml_storage.Save(_xml_path);
                }
                catch(Exception e)
                {

                }
            }
        }

        public string GetMetadata(string identifier)
        {
            if(File.Exists(_xml_path))
            {
                try
                {
                    var xml_storage = XDocument.Load(_xml_path);
                    return xml_storage.Element(ROOT_NAME).Element("Metadata").Element(identifier).Value;
                }
                catch (Exception e)
                {

                }
            }
            return null;
        }
    }
}
