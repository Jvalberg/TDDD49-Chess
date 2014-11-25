using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDD49_Chess.Game.GameObject;
using TDDD49_Chess.Game.Rules;

namespace TDDD49_Chess.Test.GameTests.RuleTests
{
    [TestClass]
    public class StalemateGameStateRuleTest
    {
        [TestMethod]
        public void GameStateTest_Stalemate()
        {
            Board _board = new Board();
            _board.Squares[0, 0] = new Square(Pieces.KING, Color.BLACK);

            _board.Squares[4, 3] = new Square(Pieces.BISHOP, Color.WHITE);
            _board.Squares[7, 1] = new Square(Pieces.QUEEN, Color.WHITE);
            
            /*
            * K 0 0 0 0 0 0 0
            * 0 0 0 0 0 0 0 Q
            * 0 0 0 0 0 0 0 0
            * 0 0 0 0 B 0 0 0 
            * 0 0 0 0 0 0 0 0
            * 0 0 0 0 0 0 0 0
            * 0 0 0 0 0 0 0 0
            * 0 0 0 0 0 0 0 0
            * */
            IGameRules gameRules = new GameRules();

            Assert.IsTrue(gameRules.IsGameState(_board, GameStateRule.STALEMATE, Color.BLACK));

            _board.Squares[7, 1] = new Square(Pieces.QUEEN, Color.BLACK);

            Assert.IsFalse(gameRules.IsGameState(_board, GameStateRule.STALEMATE, Color.BLACK));

        }
    }
}
