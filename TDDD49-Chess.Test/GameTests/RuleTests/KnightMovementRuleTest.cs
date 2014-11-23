using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDD49_Chess.Game.GameObject;
using TDDD49_Chess.Game.Rules;

namespace TDDD49_Chess.Test.GameTests.RuleTests
{
    [TestClass]
    public class KnightMovementRuleTest
    {
        [TestMethod]
        public void MovementTest_Knight_TestGetUnhinderedMovement()
        {
            Board _board = new Board();
            //Sets a pawn in the middle of the starting position.
            _board.Squares[3, 3].Piece = Pieces.KNIGHT;
            _board.Squares[3, 3].Color = Color.WHITE;
            IMovementRule _knightMovement = new KnightMovementRule();

            var _validMoves = _knightMovement.ValidMoves(_board, new Point(3, 3));

            /*
             * 0 0 0 0 0 0 0 0
             * 0 0 1 0 1 0 0 0
             * 0 1 0 0 0 1 0 0
             * 0 0 0 K 0 0 0 0 
             * 0 1 0 0 0 1 0 0
             * 0 0 1 0 1 0 0 0
             * 0 0 0 0 0 0 0 0
             * 0 0 0 0 0 0 0 0
             * */

            Assert.AreEqual(8, _validMoves.Count);
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(1, 2)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(2, 1)));


            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(4, 1)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(5, 2)));

            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(5, 4)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(4, 5)));

            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(1, 4)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(2, 5)));
        }

        [TestMethod]
        public void MovementTest_Knight_TestGetHinderedMovement()
        {
            Board _board = new Board();
            //Sets a pawn in the middle of the starting position.
            _board.Squares[3, 3].Piece = Pieces.KNIGHT;
            _board.Squares[3, 3].Color = Color.WHITE;
            _board.Squares[2, 1].Piece = Pieces.KNIGHT;
            _board.Squares[2, 1].Color = Color.WHITE;
            _board.Squares[5, 4].Piece = Pieces.KNIGHT;
            _board.Squares[5, 4].Color = Color.WHITE;
            _board.Squares[4, 5].Piece = Pieces.KNIGHT;
            _board.Squares[4, 5].Color = Color.WHITE;
            IMovementRule _knightMovement = new KnightMovementRule();

            var _validMoves = _knightMovement.ValidMoves(_board, new Point(3, 3));

            /*
            * 0 0 0 0 0 0 0 0
            * 0 0 W 0 1 0 0 0
            * 0 1 0 0 0 1 0 0
            * 0 0 0 K 0 0 0 0 
            * 0 1 0 0 0 W 0 0
            * 0 0 1 0 W 0 0 0
            * 0 0 0 0 0 0 0 0
            * 0 0 0 0 0 0 0 0
            * */

            Assert.AreEqual(5, _validMoves.Count);
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(1, 2)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(4, 1)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(5, 2)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(1, 4)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(2, 5)));
        }

        [TestMethod]
        public void MovementTest_Knight_TestCaptureMovement()
        {
            Board _board = new Board();
            //Sets a pawn in the middle of the starting position.
            _board.Squares[3, 3].Piece = Pieces.KNIGHT;
            _board.Squares[3, 3].Color = Color.WHITE;
            _board.Squares[2, 1].Piece = Pieces.KNIGHT;
            _board.Squares[2, 1].Color = Color.BLACK;
            _board.Squares[5, 4].Piece = Pieces.KNIGHT;
            _board.Squares[5, 4].Color = Color.BLACK;
            _board.Squares[4, 5].Piece = Pieces.KNIGHT;
            _board.Squares[4, 5].Color = Color.BLACK;
            IMovementRule _knightMovement = new KnightMovementRule();

            var _validMoves = _knightMovement.ValidMoves(_board, new Point(3, 3));

            /*
            * 0 0 0 0 0 0 0 0
            * 0 0 B 0 1 0 0 0
            * 0 1 0 0 0 1 0 0
            * 0 0 0 K 0 0 0 0 
            * 0 1 0 0 0 B 0 0
            * 0 0 1 0 B 0 0 0
            * 0 0 0 0 0 0 0 0
            * 0 0 0 0 0 0 0 0
            * */


            Assert.AreEqual(8, _validMoves.Count);
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(1, 2)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(2, 1)));


            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(4, 1)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(5, 2)));

            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(5, 4)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(4, 5)));

            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(1, 4)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(2, 5)));
        }
    }
}
