using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDD49_Chess.Game.GameObject;
using TDDD49_Chess.Game.Rules;

namespace TDDD49_Chess.Test.GameTests.RuleTests
{
    [TestClass]
    public class CheckGameStateRuleTest
    {
        [TestMethod]
        public void GameStateTest_Check_Pawn()
        {
            Board _board = new Board();
            _board.Squares[3, 3] = new Square(Pieces.KING, Color.BLACK);
            _board.Squares[4, 4] = new Square(Pieces.PAWN, Color.WHITE);
            IGameStateRule _checkGameStateRule = new CheckGameStateRule();
            /*
            * 0 0 0 0 0 0 0 0
            * 0 0 0 0 0 0 0 0
            * 0 0 0 0 0 0 0 0
            * 0 0 0 K 0 0 0 0 
            * 0 0 0 0 P 0 0 0
            * 0 0 0 0 0 0 0 0
            * 0 0 0 0 0 0 0 0
            * 0 0 0 0 0 0 0 0
            * */

            Assert.IsTrue(_checkGameStateRule.IsTrue(_board, Color.BLACK));

            _board.Squares[4, 4].Color = Color.BLACK;

            Assert.IsFalse(_checkGameStateRule.IsTrue(_board, Color.BLACK));
        }

        [TestMethod]
        public void GameStateTest_Check_Rook()
        {
            Board _board = new Board();
            _board.Squares[3, 3] = new Square(Pieces.KING, Color.WHITE);
            _board.Squares[3, 7] = new Square(Pieces.ROOK, Color.BLACK);
            IGameStateRule _checkGameStateRule = new CheckGameStateRule();
            /*
            * 0 0 0 0 0 0 0 0
            * 0 0 0 0 0 0 0 0
            * 0 0 0 0 0 0 0 0
            * 0 0 0 K 0 0 0 0 
            * 0 0 0 0 0 0 0 0
            * 0 0 0 0 0 0 0 0
            * 0 0 0 0 0 0 0 0
            * 0 0 0 R 0 0 0 0
            * */

            Assert.IsTrue(_checkGameStateRule.IsTrue(_board, Color.WHITE));

            _board.Squares[3, 7] = new Square(Pieces.NONE, Color.NONE);
            _board.Squares[4, 7] = new Square(Pieces.ROOK, Color.BLACK);

            Assert.IsFalse(_checkGameStateRule.IsTrue(_board, Color.WHITE));
        }

        [TestMethod]
        public void GameStateTest_Check_Knight()
        {
            Board _board = new Board();
            _board.Squares[3, 3] = new Square(Pieces.KING, Color.WHITE);
            _board.Squares[4, 5] = new Square(Pieces.KNIGHT, Color.BLACK);
            IGameStateRule _checkGameStateRule = new CheckGameStateRule();

            /*
            * 0 0 0 0 0 0 0 0
            * 0 0 0 0 0 0 0 0
            * 0 0 0 0 0 0 0 0
            * 0 0 0 K 0 0 0 0 
            * 0 0 0 0 0 0 0 0
            * 0 0 0 0 Kn0 0 0
            * 0 0 0 0 0 0 0 0
            * 0 0 0 0 0 0 0 0
            * */

            Assert.IsTrue(_checkGameStateRule.IsTrue(_board, Color.WHITE));

            _board.Squares[4, 5] = new Square(Pieces.NONE, Color.NONE);
            _board.Squares[4, 3] = new Square(Pieces.KNIGHT, Color.BLACK);

            Assert.IsFalse(_checkGameStateRule.IsTrue(_board, Color.WHITE));
        }

        [TestMethod]
        public void GameStateTest_Check_Bishop()
        {
            Board _board = new Board();
            _board.Squares[3, 3] = new Square(Pieces.KING, Color.WHITE);
            _board.Squares[5, 1] = new Square(Pieces.BISHOP, Color.BLACK);
            IGameStateRule _checkGameStateRule = new CheckGameStateRule();

            /*
            * 0 0 0 0 0 0 0 0
            * 0 0 0 0 0 B 0 0
            * 0 0 0 0 0 0 0 0
            * 0 0 0 K 0 0 0 0 
            * 0 0 0 0 0 0 0 0
            * 0 0 0 0 0 0 0 0
            * 0 0 0 0 0 0 0 0
            * 0 0 0 0 0 0 0 0
            * */

            Assert.IsTrue(_checkGameStateRule.IsTrue(_board, Color.WHITE));

            _board.Squares[5, 1] = new Square(Pieces.NONE, Color.NONE);
            _board.Squares[6, 1] = new Square(Pieces.BISHOP, Color.BLACK);

            Assert.IsFalse(_checkGameStateRule.IsTrue(_board, Color.WHITE));
        }

        [TestMethod]
        public void GameStateTest_Check_Queen()
        {
            Board _board = new Board();
            _board.Squares[3, 3] = new Square(Pieces.KING, Color.WHITE);
            _board.Squares[3, 4] = new Square(Pieces.QUEEN, Color.BLACK);
            IGameStateRule _checkGameStateRule = new CheckGameStateRule();

            /*
            * 0 0 0 0 0 0 0 0
            * 0 0 0 0 0 0 0 0
            * 0 0 0 0 0 0 0 0
            * 0 0 0 K 0 0 0 0 
            * 0 0 0 Q 0 0 0 0
            * 0 0 0 0 0 0 0 0
            * 0 0 0 0 0 0 0 0
            * 0 0 0 0 0 0 0 0
            * */

            Assert.IsTrue(_checkGameStateRule.IsTrue(_board, Color.WHITE));

            _board.Squares[3, 4] = new Square(Pieces.NONE, Color.NONE);
            _board.Squares[4, 5] = new Square(Pieces.QUEEN, Color.BLACK);

            Assert.IsFalse(_checkGameStateRule.IsTrue(_board, Color.WHITE));
        }
    }
}
