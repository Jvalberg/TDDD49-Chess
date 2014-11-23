using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDD49_Chess.Game.GameObject;
using TDDD49_Chess.Game.Rules;
using System.Collections.Generic;

namespace TDDD49_Chess.Test.GameTests.RuleTests
{
    [TestClass]
    public class PawnMovementRuleTest
    {
        [TestMethod]
        public void MovementTest_Pawn_TestGetUnhinderedMovement()
        {
            Board _board = new Board();
            //Sets a pawn in the middle of the starting position.
            int startingX = 3;
            _board.Squares[startingX, Board.WHITE_START_PAWN_ROW].Piece = Pieces.PAWN;
            _board.Squares[startingX, Board.WHITE_START_PAWN_ROW].Color = Color.WHITE;
            IMovementRule _pawnMovement = new PawnMovementRule();

            IList<Point> validMoves = _pawnMovement.ValidMoves(_board, new Point() { X = startingX, Y = Board.WHITE_START_PAWN_ROW });

            //From the initial position two moves should be possible. One step forward, and two steps forward.
            Assert.AreEqual(2, validMoves.Count);
            Assert.IsTrue(TestHelper.FoundPosition(validMoves, 
                new Point() { X = startingX, 
                    Y = Board.WHITE_START_PAWN_ROW + Board.WHITE_DIRECTION }));
            Assert.IsTrue(TestHelper.FoundPosition(validMoves, 
                new Point() { X = startingX, 
                    Y = Board.WHITE_START_PAWN_ROW + 2 * Board.WHITE_DIRECTION }));


            //Move the pawn one position forward, and get the new valid moves.
            _board.Squares[startingX, Board.WHITE_START_PAWN_ROW].Piece = Pieces.NONE;
            _board.Squares[startingX, Board.WHITE_START_PAWN_ROW].Color = Color.NONE;

            _board.Squares[startingX, Board.WHITE_START_PAWN_ROW+Board.WHITE_DIRECTION].Piece = Pieces.PAWN;
            _board.Squares[startingX, Board.WHITE_START_PAWN_ROW+Board.WHITE_DIRECTION].Color = Color.WHITE;

            validMoves = _pawnMovement.ValidMoves(_board, new Point() { X = startingX, Y = Board.WHITE_START_PAWN_ROW + Board.WHITE_DIRECTION });

            //Should only be able to move one step forward.
            Assert.AreEqual(1, validMoves.Count);
            Assert.IsTrue(TestHelper.FoundPosition(validMoves, new Point() { X = startingX, Y = Board.WHITE_START_PAWN_ROW + 2 * Board.WHITE_DIRECTION }));
        }

        [TestMethod]
        public void MovementTest_Pawn_TestGetHinderedMovement()
        {
            Board _board = new Board();
            //Sets a pawn in the middle of the board
            int startingX = 3;
            _board.Squares[startingX, 3].Piece = Pieces.PAWN;
            _board.Squares[startingX, 3].Color = Color.WHITE;
            
            //adds an opposing ally
            _board.Squares[startingX, 2].Piece = Pieces.PAWN;
            _board.Squares[startingX, 2].Color = Color.WHITE;
            IMovementRule _pawnMovement = new PawnMovementRule();

            IList<Point> validMoves = _pawnMovement.ValidMoves(_board, new Point() { X = startingX, Y = 3 });

            Assert.AreEqual(0, validMoves.Count);

            //changes opposing piece to opposition (should not be able to capture)
            _board.Squares[startingX, 2].Piece = Pieces.PAWN;
            _board.Squares[startingX, 2].Color = Color.BLACK;

            validMoves = _pawnMovement.ValidMoves(_board, new Point() { X = startingX, Y = 3 });

            Assert.AreEqual(0, validMoves.Count);
        }

        [TestMethod]
        public void MovementTest_Pawn_TestCaptureMovement()
        {
            Board _board = new Board();
            //Sets a pawn in the middle of the board
            int startingX = 3;
            _board.Squares[startingX, 3].Piece = Pieces.PAWN;
            _board.Squares[startingX, 3].Color = Color.WHITE;

            //adds an opposing ally
            _board.Squares[2, 2].Piece = Pieces.PAWN;
            _board.Squares[2, 2].Color = Color.BLACK;
            IMovementRule _pawnMovement = new PawnMovementRule();

            IList<Point> validMoves = _pawnMovement.ValidMoves(_board, new Point() { X = startingX, Y = 3 });

            Assert.AreEqual(2, validMoves.Count);
            Assert.IsTrue(TestHelper.FoundPosition(validMoves, new Point() { X = 2, Y = 2 }));
        }
    }
}
