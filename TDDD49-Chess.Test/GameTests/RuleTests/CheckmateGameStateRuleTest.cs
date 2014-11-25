using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDD49_Chess.Game.GameObject;
using TDDD49_Chess.Game.Rules;

namespace TDDD49_Chess.Test.GameTests.RuleTests
{
    [TestClass]
    public class CheckmateGameStateRuleTest
    {
        [TestMethod]
        public void GameStateTest_Checkmate()
        {
            Board board = new Board();
            board.Squares[0, 0] = new Square(Pieces.KING, Color.BLACK);
            board.Squares[1, 7] = new Square(Pieces.QUEEN, Color.WHITE);
            board.Squares[0, 6] = new Square(Pieces.QUEEN, Color.WHITE);
            /*
            * K 0 0 0 0 0 0 0
            * 0 0 0 0 0 0 0 0
            * 0 0 0 0 0 0 0 0
            * 0 0 0 0 0 0 0 0 
            * 0 0 0 0 0 0 0 0
            * 0 0 0 0 0 0 0 0
            * Q 0 0 0 0 0 0 0
            * 0 Q 0 0 0 0 0 0
            * */
            IGameRules _gameRules = new GameRules();

            Assert.IsTrue(_gameRules.IsGameState(board, GameStateRule.CHECKMATE, Color.BLACK));

            board.Squares[0, 6] = new Square(Pieces.QUEEN, Color.BLACK);

            Assert.IsFalse(_gameRules.IsGameState(board, GameStateRule.CHECKMATE, Color.BLACK));
        }

        [TestMethod]
        public void GameStateTest_Checkmate_KingMove()
        {
           Board board = new Board();
            board.Squares[0, 0] = new Square(Pieces.KING, Color.BLACK);
            board.Squares[7, 1] = new Square(Pieces.ROOK, Color.BLACK);
            board.Squares[1, 7] = new Square(Pieces.QUEEN, Color.WHITE);
            board.Squares[0, 6] = new Square(Pieces.QUEEN, Color.WHITE);
            /*
             * Black can protect itself with the rook, no checkmate.
            * K 0 0 0 0 0 0 0
            * 0 0 0 0 0 0 0 R
            * 0 0 0 0 0 0 0 0
            * 0 0 0 0 0 0 0 0 
            * 0 0 0 0 0 0 0 0
            * 0 0 0 0 0 0 0 0
            * Q 0 0 0 0 0 0 0
            * 0 Q 0 0 0 0 0 0
            * */
            IGameRules _gameRules = new GameRules();

            Assert.IsFalse(_gameRules.IsGameState(board, GameStateRule.CHECKMATE, Color.BLACK));
        }

        [TestMethod]
        public void GameStateTest_Checkmate_KingCapture()
        {
            Board board = new Board();
            board.Squares[0, 0] = new Square(Pieces.KING, Color.BLACK);
            board.Squares[0, 7] = new Square(Pieces.QUEEN, Color.WHITE);
            board.Squares[1, 1] = new Square(Pieces.PAWN, Color.WHITE);
            board.Squares[0, 6] = new Square(Pieces.QUEEN, Color.WHITE);
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
            IGameRules _gameRules = new GameRules();

            Assert.IsFalse(_gameRules.IsGameState(board, GameStateRule.CHECKMATE, Color.BLACK));
        }
    }
}
