using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDD49_Chess.Game.GameObject;
using TDDD49_Chess.Game.Players;
using TDDD49_Chess.Game.Rules;

namespace TDDD49_Chess.Game
{
    public class ChessEngine : IChessEngine
    {

        private IList<IChessObserver> _observers;
        private Dictionary<IChessPlayer, int> _players;

        /// <summary>
        /// The color which should move next.
        /// </summary>
        private int _turn_color;
        private Board _board;
        private Boolean _isActiveGame;

        private IGameRules _gameRules;
        private IList<Move> _moveHistory;

        public ChessEngine()
        {
            Initialize();
        }

        public void Initialize()
        {
            _observers = new List<IChessObserver>();
            _players = new Dictionary<IChessPlayer, int>();
            _moveHistory = new List<Move>();
            _gameRules = new GameRules();
            resetBoard();
        }

        public bool TryMove(IChessPlayer player, Point from, Point to)
        {
            if(!_players.ContainsKey(player))
                throw new Exception("Cannot make a move as an unregistered player. Register!");
            
            if (_players[player] != _turn_color)
                return false; //Cannot make a move when it's not your turn.

            var validMoves = _gameRules.MovementRules.ValidMoves(_board, from);

            if (!validMoves.Contains(to))
                return false; //Cannot make an invalid move.

            if (_gameRules.IsGameState(_board.MakeMove(from, to),
                                        GameStateRule.CHECK,
                                        _turn_color))
                return false; //Cannot make a moves which puts the own player in check.
            

            Move move = new Move(from, to, _board.Squares[from.X, from.Y], _board.Squares[to.X, to.Y]);
            makeMove(move);
            _moveHistory.Add(move);
            _turn_color = _turn_color == Color.BLACK ? Color.WHITE : Color.BLACK;
            ChessGameChanged(new GameUpdatedArgs(move, _turn_color));
            return true;
        }

        private void makeMove(Move move)
        {
            _board = _board.MakeMove(move.From, move.To);
        }

        public bool IsActiveGame()
        {
            return _isActiveGame;
        }

        public bool IsGameOver()
        {
            var oppositionColor = _turn_color == Color.BLACK ? Color.WHITE : Color.BLACK;
            return _gameRules.IsGameState(_board, GameStateRule.CHECKMATE, _turn_color) ||
                _gameRules.IsGameState(_board, GameStateRule.CHECKMATE, oppositionColor);
        }

        public bool IsCurrentTurn(int color)
        {
            return _turn_color == color;
        }

        public Board GetBoardCopy()
        {
            return _board.GetCopy();
        }

        public IGameRules GetRules()
        {
            return _gameRules;
        }

        public IList<Move> GetMoveHistory()
        {
            return _moveHistory;
        }

        public bool NewGame()
        {
            if (!_players.ContainsValue(Color.WHITE) ||
                !_players.ContainsValue(Color.BLACK))
                throw new Exception("Cannot start game unless both white and black have players.");

            _turn_color = Color.WHITE;
            _isActiveGame = true;
            _moveHistory = new List<Move>();

            resetBoard();
            
            ChessGameChanged(new GameUpdatedArgs(null, -1));

            return true;
        }

        private void resetBoard()
        {
            _board = new Board();
            for (int i = 0; i < 8; i++)
            {
                _board.Squares[i, Board.WHITE_START_PAWN_ROW] = new Square(Pieces.PAWN, Color.WHITE);
                _board.Squares[i, Board.BLACK_START_PAWN_ROW] = new Square(Pieces.PAWN, Color.BLACK);
            }

            addClothedRow(_board, 0, Color.BLACK);
            addClothedRow(_board, 7, Color.WHITE);
            
            _moveHistory.Clear();
        }

        private void addClothedRow(Board board, int rowId, int color)
        {
            _board.Squares[0, rowId] = new Square(Pieces.ROOK, color);
            _board.Squares[1, rowId] = new Square(Pieces.KNIGHT, color);
            _board.Squares[2, rowId] = new Square(Pieces.BISHOP, color);
            _board.Squares[3, rowId] = new Square(Pieces.QUEEN, color);
            _board.Squares[4, rowId] = new Square(Pieces.KING, color);
            _board.Squares[5, rowId] = new Square(Pieces.BISHOP, color);
            _board.Squares[6, rowId] = new Square(Pieces.KNIGHT, color);
            _board.Squares[7, rowId] = new Square(Pieces.ROOK, color);
        }

        #region IChessEngine members
         
        public bool RegisterPlayer(int color, IChessPlayer player)
        {
            if (!(color == Color.BLACK ||
                color == Color.WHITE))
                throw new Exception("Cannot register with unkown color. Use Color.<BLACK><WHITE>..");

            if (_players.ContainsValue(color))
                return false;

            _players.Add(player, color);
            return true;
        }

        public bool RegisterObserver(IChessObserver observer)
        {
            if (!_observers.Contains(observer))
                _observers.Add(observer);
            return true;
        }

        public bool Unregister(IChessObserver entity)
        {
            if (_observers.Contains(entity))
                _observers.Remove(entity);
            if(entity is IChessPlayer)
            {
                _players.Remove(entity as IChessPlayer);
            }
            return true;
        }


        protected void ChessGameChanged(GameUpdatedArgs args)
        {
            foreach (var observer in _observers)
                observer.GameUpdated(args);

            foreach (var player in _players)
                player.Key.GameUpdated(args);
        }

        #endregion
    }
}
