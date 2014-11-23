using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDD49_Chess.Game.GameObject;
using TDDD49_Chess.Game.Rules;

namespace TDDD49_Chess.Test.GameTests.RuleTests
{
    [TestClass]
    public class RookMovementRuleTest
    {
        [TestMethod]
        public void MovementTest_Rook_TestGetUnhinderedMovement()
        {
            Board _board = new Board();
            //Sets a pawn in the middle of the starting position.
            _board.Squares[3, 3].Piece = Pieces.ROOK;
            _board.Squares[3, 3].Color = Color.WHITE;
            IMovementRule _rookMovement = new RookMovementRule();

            var _validMoves = _rookMovement.ValidMoves(_board, new Point(3, 3));

            /*
             * 0 0 0 1 0 0 0 0
             * 0 0 0 1 0 0 0 0
             * 0 0 0 1 0 0 0 0
             * 1 1 1 0 1 1 1 1 
             * 0 0 0 1 0 0 0 0
             * 0 0 0 1 0 0 0 0
             * 0 0 0 1 0 0 0 0
             * 0 0 0 1 0 0 0 0
             *  15 moves
             * */

            Assert.AreEqual(14, _validMoves.Count);
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
        }

        [TestMethod]
        public void MovementTest_Rook_TestGetHinderedMovement()
        {
            Board _board = new Board();
            //Sets a pawn in the middle of the starting position.
            _board.Squares[3, 3].Piece = Pieces.ROOK;
            _board.Squares[3, 3].Color = Color.WHITE;
            _board.Squares[3, 4].Piece = Pieces.ROOK;
            _board.Squares[3, 4].Color = Color.WHITE;

            _board.Squares[5, 3].Piece = Pieces.ROOK;
            _board.Squares[5, 3].Color = Color.WHITE;
            IMovementRule _rookMovement = new RookMovementRule();
            
            /*
             * 0 0 0 1 0 0 0 0
             * 0 0 0 1 0 0 0 0
             * 0 0 0 1 0 0 0 0
             * 1 1 1 0 1 W 0 0 
             * 0 0 0 W 0 0 0 0
             * 0 0 0 0 0 0 0 0
             * 0 0 0 0 0 0 0 0
             * 0 0 0 0 0 0 0 0
             *  15 moves
             * */
            var _validMoves = _rookMovement.ValidMoves(_board, new Point(3, 3));

            Assert.AreEqual(7, _validMoves.Count);
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(3, 0)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(3, 1)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(3, 2)));

            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(0, 3)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(1, 3)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(2, 3)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(4, 3)));
        }

        [TestMethod]
        public void MovementTest_Rook_TestCaptureMovement()
        {
            Board _board = new Board();
            //Sets a pawn in the middle of the starting position.
            _board.Squares[3, 3].Piece = Pieces.ROOK;
            _board.Squares[3, 3].Color = Color.WHITE;


            _board.Squares[3, 0].Piece = Pieces.ROOK;
            _board.Squares[3, 0].Color = Color.BLACK;
            _board.Squares[3, 1].Piece = Pieces.ROOK;
            _board.Squares[3, 1].Color = Color.BLACK;
            _board.Squares[3, 7].Piece = Pieces.ROOK;
            _board.Squares[3, 7].Color = Color.BLACK;

            _board.Squares[1, 3].Piece = Pieces.ROOK;
            _board.Squares[1, 3].Color = Color.BLACK;
            _board.Squares[5, 3].Piece = Pieces.ROOK;
            _board.Squares[5, 3].Color = Color.WHITE;
            _board.Squares[6, 3].Piece = Pieces.ROOK;
            _board.Squares[6, 3].Color = Color.BLACK;

            IMovementRule _rookMovement = new RookMovementRule();

            /*
             * 0 0 0 B 0 0 0 0
             * 0 0 0 B 0 0 0 0
             * 0 0 0 1 0 0 0 0
             * 0 B 1 0 1 W B 0 
             * 0 0 0 1 0 0 0 0
             * 0 0 0 1 0 0 0 0
             * 0 0 0 1 0 0 0 0
             * 0 0 0 B 0 0 0 0
             *  15 moves
             * */
            var _validMoves = _rookMovement.ValidMoves(_board, new Point(3, 3));
            Assert.AreEqual(9, _validMoves.Count);

            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(3, 1)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(3, 2)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(3, 4)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(3, 5)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(3, 6)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(3, 7)));

            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(1, 3)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(2, 3)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(4, 3)));
        }
    }
}
