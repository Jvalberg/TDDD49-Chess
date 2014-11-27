using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDD49_Chess.Game.GameObject;
using TDDD49_Chess.Game.Players;
using TDDD49_Chess.Game.Rules;

namespace TDDD49_Chess.Game
{
    /// <summary>
    /// The full chess engine, used by special entities to
    /// access very restricted functions.
    /// </summary>
    public interface IChessEngine : IPlayerChessEngine
    {
        //Tries to register a player as the specific color.
        Boolean RegisterPlayer(int color, IChessPlayer player);
        Boolean RegisterObserver(IChessObserver observer);
        Boolean Unregister(IChessObserver entity);
    }

    /// <summary>
    /// The chess engine API which players can use.
    /// </summary>
    public interface IPlayerChessEngine : IReadOnlyChessEngine
    {
        Boolean IsActivePlayer(IChessPlayer player);
        Boolean GenerateBoardSetup(IList<Move> moves);
        Boolean TryMove(IChessPlayer player, Point from, Point to);
        Boolean NewGame();
    }

    /// <summary>
    /// Create a readonly chess interface intended
    /// to be used by the observers of a game.
    /// </summary>
    public interface IReadOnlyChessEngine
    {
        Boolean IsActiveGame();
        Boolean IsGameOver();
        Boolean IsCurrentTurn(int color);
        Board GetBoardCopy();

        IGameRules GetRules();
        IList<Move> GetMoveHistory();
    }
}
