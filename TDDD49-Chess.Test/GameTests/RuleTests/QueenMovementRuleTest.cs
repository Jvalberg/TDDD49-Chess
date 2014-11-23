using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDD49_Chess.Game.GameObject;
using TDDD49_Chess.Game.Rules;

namespace TDDD49_Chess.Test.GameTests.RuleTests
{
    [TestClass]
    public class QueenMovementRuleTest
    {
        [TestMethod]
        public void MovementTest_Queen_TestGetUnhinderedMovement()
        {
            Board _board = new Board();
            //Sets a pawn in the middle of the starting position.
            _board.Squares[3, 3].Piece = Pieces.QUEEN;
            _board.Squares[3, 3].Color = Color.WHITE;
            IMovementRule _queenMovementRule = new QueenMovementRule();

            var _validMoves = _queenMovementRule.ValidMoves(_board, new Point(3, 3));
            /*
           * 1 0 0 1 0 0 1 0
           * 0 1 0 1 0 1 0 0
           * 0 0 1 1 1 0 0 0
           * 1 1 1 Q 1 1 1 1
           * 0 0 1 1 1 0 0 0
           * 0 1 0 1 0 1 0 0
           * 1 0 0 1 0 0 1 0
           * 0 0 0 1 0 0 0 1
           * */

            Assert.AreEqual(27, _validMoves.Count);

            //Rook moves
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(3, 0)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(3, 1)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(3, 2)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(3, 4)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(3, 5)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(3, 6)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(3, 7)));

            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(0, 3)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(1, 3)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(2, 3)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(4, 3)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(5, 3)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(6, 3)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(7, 3)));

            //Bishop moves
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(0, 0)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(1, 1)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(2, 2)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(4, 4)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(5, 5)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(6, 6)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(7, 7)));

            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(6, 0)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(5, 1)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(4, 2)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(2, 4)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(1, 5)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(0, 6)));
        }


        [TestMethod]
        public void MovementTest_Queen_TestGetHinderedMovement()
        {
            Board _board = new Board();
            //Sets a pawn in the middle of the starting position.
            _board.Squares[3, 3].Piece = Pieces.QUEEN;
            _board.Squares[3, 3].Color = Color.WHITE;
            _board.Squares[3, 2].Piece = Pieces.QUEEN;
            _board.Squares[3, 2].Color = Color.WHITE;
            _board.Squares[5, 5].Piece = Pieces.QUEEN;
            _board.Squares[5, 5].Color = Color.WHITE;
            IMovementRule _queenMovementRule = new QueenMovementRule();

            var _validMoves = _queenMovementRule.ValidMoves(_board, new Point(3, 3));
            /*
           * 1 0 0 0 0 0 1 0
           * 0 1 0 0 0 1 0 0
           * 0 0 1 W 1 0 0 0
           * 1 1 1 Q 1 1 1 1
           * 0 0 1 1 1 0 0 0
           * 0 1 0 1 0 W 0 0
           * 1 0 0 1 0 0 0 0
           * 0 0 0 1 0 0 0 0
           * */

            Assert.AreEqual(21, _validMoves.Count);

            //Rook moves
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(3, 4)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(3, 5)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(3, 6)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(3, 7)));

            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(0, 3)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(1, 3)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(2, 3)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(4, 3)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(5, 3)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(6, 3)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(7, 3)));

            //Bishop moves
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(0, 0)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(1, 1)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(2, 2)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(4, 4)));

            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(6, 0)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(5, 1)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(4, 2)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(2, 4)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(1, 5)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(0, 6)));
        }

        [TestMethod]
        public void MovementTest_Queen_TestCaptureMovement()
        {
            Board _board = new Board();
            //Sets a pawn in the middle of the starting position.
            _board.Squares[3, 3].Piece = Pieces.QUEEN;
            _board.Squares[3, 3].Color = Color.WHITE;
            _board.Squares[3, 2].Piece = Pieces.QUEEN;
            _board.Squares[3, 2].Color = Color.BLACK;
            _board.Squares[5, 5].Piece = Pieces.QUEEN;
            _board.Squares[5, 5].Color = Color.WHITE;

            _board.Squares[6, 0].Piece = Pieces.QUEEN;
            _board.Squares[6, 0].Color = Color.BLACK;
            _board.Squares[5, 1].Piece = Pieces.QUEEN;
            _board.Squares[5, 1].Color = Color.BLACK;
            IMovementRule _queenMovementRule = new QueenMovementRule();

            var _validMoves = _queenMovementRule.ValidMoves(_board, new Point(3, 3));
            /*
           * 1 0 0 0 0 0 B 0
           * 0 1 0 0 0 B 0 0
           * 0 0 1 B 1 0 0 0
           * 1 1 1 Q 1 1 1 1
           * 0 0 1 1 1 0 0 0
           * 0 1 0 1 0 W 0 0
           * 1 0 0 1 0 0 0 0
           * 0 0 0 1 0 0 0 0
           * */

            Assert.AreEqual(21, _validMoves.Count);

            //Rook moves
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(3, 2)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(3, 4)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(3, 5)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(3, 6)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(3, 7)));

            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(0, 3)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(1, 3)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(2, 3)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(4, 3)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(5, 3)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(6, 3)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(7, 3)));

            //Bishop moves
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(0, 0)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(1, 1)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(2, 2)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(4, 4)));

            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(5, 1)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(4, 2)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(2, 4)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(1, 5)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(0, 6)));
        }
    }
}
