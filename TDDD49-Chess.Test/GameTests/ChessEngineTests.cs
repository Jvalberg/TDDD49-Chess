using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDD49_Chess.Game;
using TDDD49_Chess.Test.MockObjects;
using TDDD49_Chess.Game.GameObject;

namespace TDDD49_Chess.Test.GameTests
{
    [TestClass]
    public class ChessEngineTests
    {
        [TestMethod]
        public void ChessEngine_TestRegisterPlayer()
        {
            IChessEngine _chessEngine = new ChessEngine();
            var player1 = new TestListener();
            var player2 = new TestListener();

            var result1 = _chessEngine.RegisterPlayer(Color.BLACK, player1);
            var result2 = _chessEngine.RegisterPlayer(Color.BLACK, player2);

            Assert.IsTrue(result1);
            Assert.IsFalse(result2);
            
            result1 = _chessEngine.Unregister(player1);
            result2 = _chessEngine.RegisterPlayer(Color.BLACK, player2);
            Assert.IsTrue(result1);
            Assert.IsTrue(result2);
            result2 = _chessEngine.Unregister(player2);
        }

        [TestMethod]
        public void ChessEngine_TestNewGame()
        {
            IChessEngine _chessEngine = new ChessEngine();
            var player1 = new TestListener();
            var player2 = new TestListener();

            _chessEngine.RegisterPlayer(Color.BLACK, player1);
            _chessEngine.RegisterPlayer(Color.WHITE, player2);

            _chessEngine.NewGame();

            _chessEngine.Unregister(player1);
        }
    }
}
