using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDD49_Chess.Game;
using TDDD49_Chess.Game.Players;
using TDDD49_Chess.Game.GameObject;
using TDDD49_Chess.Test.MockObjects;

namespace TDDD49_Chess.Test.GameEngineTests
{
    [TestClass]
    public class ChessEngineTests
    {
        [TestMethod]
        public void TestRegisterUnregister_Observers()
        {
            IChessEngine _chessEngine = new ChessEngine();
            TestListener _observer1 = new TestListener() { Triggered = false };
            TestListener _observer2 = new TestListener() { Triggered = false };

            _chessEngine.RegisterObserver(_observer1);
            _chessEngine.RegisterObserver(_observer2);
            _chessEngine.TryMove(new Point(), new Point()); //Triggers game updated.

            Assert.IsTrue(_observer1.Triggered);
            Assert.IsTrue(_observer2.Triggered);

            _observer2.Triggered = false;
            _chessEngine.Unregister(_observer2);
            _chessEngine.TryMove(new Point(), new Point());

            Assert.IsFalse(_observer2.Triggered);
        }

        [TestMethod]
        public void TestRegisterUnregister_Players()
        {
            IChessEngine _chessEngine = new ChessEngine();
            TestListener _player1 = new TestListener() { Triggered = false };
            TestListener _player2 = new TestListener() { Triggered = false };

            var result = _chessEngine.RegisterPlayer(Color.BLACK, _player1);
            var result2 = _chessEngine.RegisterPlayer(Color.BLACK, _player2);
            _chessEngine.TryMove(new Point(), new Point());

            Assert.IsTrue(result);
            Assert.IsFalse(result2);
            Assert.IsTrue(_player1.Triggered);
            Assert.IsFalse(_player2.Triggered);

            result2 = _chessEngine.RegisterPlayer(Color.WHITE, _player2);
            _chessEngine.TryMove(new Point(), new Point());

            Assert.IsTrue(result2);
            Assert.IsTrue(_player2.Triggered);

            _player1.Triggered = false;
            _chessEngine.Unregister(_player1);
            _chessEngine.TryMove(new Point(), new Point());

            Assert.IsFalse(_player1.Triggered);
        }
    }
}
