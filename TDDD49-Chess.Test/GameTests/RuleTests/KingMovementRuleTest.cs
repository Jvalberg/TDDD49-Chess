using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDD49_Chess.Game.GameObject;
using TDDD49_Chess.Game.Rules;

namespace TDDD49_Chess.Test.GameTests.RuleTests
{
    [TestClass]
    public class KingMovementRuleTest
    {
        [TestMethod]
        public void MovementTest_King_TestGetUnhinderedMovement()
        {
            Board _board = new Board();
            //Sets a pawn in the middle of the starting position.
            int startingX = 3;
            int startingY = 3;
            _board.Squares[startingX, startingY].Piece = Pieces.KING;
            _board.Squares[startingX, startingY].Color = Color.WHITE;
            IMovementRule _kingMovement = new KingMovementRule();

            var _validMoves = _kingMovement.ValidMoves(_board, new Point(startingX, startingY));

            Assert.AreEqual(8, _validMoves.Count);
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(startingX - 1, startingY - 1)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(startingX - 1, startingY)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(startingX, startingY - 1)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(startingX + 1, startingY + 1)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(startingX + 1, startingY)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(startingX, startingY + 1)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(startingX - 1, startingY + 1)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(startingX + 1, startingY - 1)));
        }


        [TestMethod]
        public void MovementTest_King_TestGetHinderedMovement()
        {
            Board _board = new Board();
            //Sets a pawn in the middle of the starting position.
            int startingX = 0;
            int startingY = 0;
            _board.Squares[startingX, startingY].Piece = Pieces.KING;
            _board.Squares[startingX, startingY].Color = Color.WHITE;
            _board.Squares[startingX + 1, startingY + 1].Piece = Pieces.KNIGHT;
            _board.Squares[startingX + 1, startingY + 1].Color = Color.WHITE;
            IMovementRule _kingMovement = new KingMovementRule();

            var _validMoves = _kingMovement.ValidMoves(_board, new Point(startingX, startingY));

            Assert.AreEqual(2, _validMoves.Count);
            Assert.IsFalse(TestHelper.FoundPosition(_validMoves, new Point(startingX + 1, startingY + 1)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(startingX + 1, startingY)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(startingX, startingY + 1)));
        }

        [TestMethod]
        public void MovementTest_King_TestCaptureMovement()
        {
            Board _board = new Board();
            //Sets a pawn in the middle of the starting position.
            int startingX = 7;
            int startingY = 7;
            _board.Squares[startingX, startingY].Piece = Pieces.KING;
            _board.Squares[startingX, startingY].Color = Color.WHITE;
            _board.Squares[6, 6].Piece = Pieces.KNIGHT;
            _board.Squares[6, 6].Color = Color.BLACK;
            IMovementRule _kingMovement = new KingMovementRule();

            var _validMoves = _kingMovement.ValidMoves(_board, new Point(startingX, startingY));

            Assert.AreEqual(3, _validMoves.Count);
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(6, 7)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(7, 6)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(6, 6)));
        }

        [TestMethod]
        public void MovementTest_King_TestCaptureProtectedPiece()
        {
            Board _board = new Board();
            //Sets a pawn in the middle of the starting position.
            int startingX = 7;
            int startingY = 7;
            _board.Squares[startingX, startingY].Piece = Pieces.KING;
            _board.Squares[startingX, startingY].Color = Color.WHITE;
            _board.Squares[6, 6].Piece = Pieces.KNIGHT;
            _board.Squares[6, 6].Color = Color.BLACK;
            IMovementRule _kingMovement = new KingMovementRule();
            /*
             * Black can capture the pawn and escape.
            * K 0 0 0 0 0 0 Q
            * 0 P 0 0 0 0 0 0
            * 0 0 0 0 0 0 0 0
            * 0 0 0 0 0 0 0 0 
            * 0 0 0 0 0 0 0 0
            * 0 0 0 0 0 0 0 0
            * Q 0 0 0 0 0 0 0
            * 0 0 0 0 0 0 0 0
            * */
            var _validMoves = _kingMovement.ValidMoves(_board, new Point(startingX, startingY));

            Assert.AreEqual(3, _validMoves.Count);
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(6, 7)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(7, 6)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(6, 6)));
        }
    }
}
