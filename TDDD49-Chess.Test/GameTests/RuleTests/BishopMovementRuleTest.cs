using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDD49_Chess.Game.GameObject;
using TDDD49_Chess.Game.Rules;

namespace TDDD49_Chess.Test.GameTests.RuleTests
{
    [TestClass]
    public class BishopMovementRuleTest
    {
        [TestMethod]
        public void MovementTest_Bishop_TestGetUnhinderedMovement()
        {
            Board _board = new Board();
            //Sets a pawn in the middle of the starting position.
            int startingX = 3;
            int startingY = 3;
            _board.Squares[startingX, startingY].Piece = Pieces.BISHOP;
            _board.Squares[startingX, startingY].Color = Color.WHITE;
            IMovementRule _bishopMovement = new BishopMovementRule();

            var _validMoves = _bishopMovement.ValidMoves(_board, new Point(startingX, startingY));

            /*
            * 1 0 0 0 0 0 1 0
            * 0 1 0 0 0 1 0 0
            * 0 0 1 0 1 0 0 0
            * 0 0 0 B 0 0 0 0
            * 0 0 1 0 1 0 0 0
            * 0 1 0 0 0 1 0 0
            * 1 0 0 0 0 0 1 0
            * 0 0 0 0 0 0 0 1
            * */

            Assert.AreEqual(13, _validMoves.Count);
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
        public void MovementTest_Bishop_TestGetHinderedMovement()
        {
            Board _board = new Board();
            //Sets a pawn in the middle of the starting position.
            int startingX = 3;
            int startingY = 3;
            _board.Squares[3, 3].Piece = Pieces.BISHOP;
            _board.Squares[3, 3].Color = Color.WHITE;
            _board.Squares[1, 1].Piece = Pieces.BISHOP;
            _board.Squares[1, 1].Color = Color.WHITE;
            _board.Squares[0, 6].Piece = Pieces.BISHOP;
            _board.Squares[0, 6].Color = Color.WHITE;

            _board.Squares[5, 5].Piece = Pieces.BISHOP;
            _board.Squares[5, 5].Color = Color.WHITE;
            IMovementRule _bishopMovement = new BishopMovementRule();

            var _validMoves = _bishopMovement.ValidMoves(_board, new Point(startingX, startingY));

            /*
            * 0 0 0 0 0 0 1 0
            * 0 W 0 0 0 1 0 0
            * 0 0 1 0 1 0 0 0
            * 0 0 0 B 0 0 0 0
            * 0 0 1 0 1 0 0 0
            * 0 1 0 0 0 W 0 0
            * W 0 0 0 0 0 0 0
            * 0 0 0 0 0 0 0 0
            * */

            Assert.AreEqual(7, _validMoves.Count);
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(2, 2)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(4, 4)));

            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(6, 0)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(5, 1)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(4, 2)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(2, 4)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(1, 5)));

        }

        [TestMethod]
        public void MovementTest_Bishop_TestCaptureMovement()
        {
            Board _board = new Board();
            //Sets a pawn in the middle of the starting position.
            int startingX = 3;
            int startingY = 3;
            _board.Squares[3, 3].Piece = Pieces.BISHOP;
            _board.Squares[3, 3].Color = Color.WHITE;
            _board.Squares[1, 1].Piece = Pieces.BISHOP;
            _board.Squares[1, 1].Color = Color.BLACK;
            _board.Squares[0, 6].Piece = Pieces.BISHOP;
            _board.Squares[0, 6].Color = Color.WHITE;
            _board.Squares[5, 1].Piece = Pieces.BISHOP;
            _board.Squares[5, 1].Color = Color.BLACK;
            _board.Squares[6, 0].Piece = Pieces.BISHOP;
            _board.Squares[6, 0].Color = Color.BLACK;

            _board.Squares[5, 5].Piece = Pieces.BISHOP;
            _board.Squares[5, 5].Color = Color.WHITE;
            _board.Squares[6, 6].Piece = Pieces.BISHOP;
            _board.Squares[6, 6].Color = Color.BLACK;
            IMovementRule _bishopMovement = new BishopMovementRule();

            var _validMoves = _bishopMovement.ValidMoves(_board, new Point(startingX, startingY));

            /*
            * 0 0 0 0 0 0 B 0
            * 0 B 0 0 0 B 0 0
            * 0 0 1 0 1 0 0 0
            * 0 0 0 B 0 0 0 0
            * 0 0 1 0 1 0 0 0
            * 0 1 0 0 0 W 0 0
            * W 0 0 0 0 0 B 0
            * 0 0 0 0 0 0 0 0
            * */

            Assert.AreEqual(7, _validMoves.Count);
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(1, 1)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(2, 2)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(4, 4)));

            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(5, 1)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(4, 2)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(2, 4)));
            Assert.IsTrue(TestHelper.FoundPosition(_validMoves, new Point(1, 5)));

        }
    }
}
