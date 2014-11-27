using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDD49_Chess.Game.GameObject;
using TDDD49_Chess.Game.Players;
using TDDD49_Chess.Game.Rules;

namespace TDDD49_Chess.AI
{
    public class ChessMinimaxMoveAlgorithm : IChessMoveAlgorithm
    {
        private IChessPlayer _player;
        private int MAX_DEPTH = 3;
        private Random random;
        private int MAX_VALUE = 100000;

        public ChessMinimaxMoveAlgorithm(IChessPlayer player)
        {
            _player = player;
            random = new Random();
        }

        Tuple<Point, Point> IChessMoveAlgorithm.GetNextMove(Board board, int color)
        {
            var result = maxi(MAX_DEPTH, board, color);
            return new Tuple<Point, Point>(result.Item2, result.Item3);
        }

        Tuple<int, Point, Point> maxi(int depth, Board board, int color)
        {
            if (depth == 0) return new Tuple<int,Point,Point>(
                evaluate(board, Color.OtherColor(color)), 
                new Point(), new Point());

            int max = int.MinValue;
            Point bestFrom = new Point();
            Point bestTo = new Point();
            var allPieces = board.GetAllPieces(color);
            int iterations = 0;
            foreach(var piece in allPieces)
            {
                var validMoves = _player.GetRules().MovementRules.ValidMoves(board, piece);
                validMoves = _player.GetRules().FilterCheckMoves(board, piece, validMoves);
                foreach(var validMove in validMoves)
                {
                    iterations++;
                    var simulatedBoard = board.MakeMove(piece, validMove);
                    var result = mini(depth - 1, simulatedBoard, Color.OtherColor(color));
                    if(result.Item1 > max || (result.Item1 == max && random.NextDouble() > 0.8))
                    {
                        max = result.Item1;
                        bestFrom = piece;
                        bestTo = validMove;
                        if (max == MAX_VALUE)
                            return new Tuple<int, Point, Point>(max, bestFrom, bestTo);
                    }
                }
            }

            if(iterations == 0)
            {
                return new Tuple<int, Point, Point>(
                   evaluate(board, color),
                   new Point(), new Point());
            }
            return new Tuple<int, Point, Point>(max, bestFrom, bestTo);
        }

        Tuple<int, Point, Point> mini(int depth, Board board, int color)
        {
            if (depth == 0)
            {
                var value = evaluate(board, Color.OtherColor(color));
                return new Tuple<int, Point, Point>(
                value,
                new Point(), new Point());
            }

            int min = int.MaxValue;
            Point bestFrom = new Point();
            Point bestTo = new Point();
            int iterations = 0;
            var allPieces = board.GetAllPieces(color);
            foreach (var piece in allPieces)
            {
                var validMoves = _player.GetRules().MovementRules.ValidMoves(board, piece);
                foreach (var validMove in validMoves)
                {
                    iterations++;
                    var simulatedBoard = board.MakeMove(piece, validMove);
                    var result = maxi(depth - 1, simulatedBoard, Color.OtherColor(color));
                    if (result.Item1 < min || (result.Item1 == min && random.NextDouble() > 0.8))
                    {
                        min = result.Item1;
                        bestFrom = piece;
                        bestTo = validMove;
                    }
                }
            }

            if (iterations == 0)
            {
                return new Tuple<int, Point, Point>(
                   evaluate(board, color),
                   new Point(), new Point());
            }
            return new Tuple<int, Point, Point>(min, bestFrom, bestTo);
        }

        int evaluate(Board board, int color)
        {
            //Return the points in the eyes of the specified color.
            int score = 0;


            if (!hasKing(board, Color.OtherColor(color)) || _player.GetRules().IsGameState(board,
                GameStateRule.CHECKMATE, Color.OtherColor(color)))
            {
                if (!hasKing(board, Color.OtherColor(color)) || _player.GetRules().IsGameState(board,
                    GameStateRule.CHECKMATE, Color.OtherColor(color)))
                return MAX_VALUE;
            }
            if (!hasKing(board, color) || _player.GetRules().IsGameState(board,
                GameStateRule.CHECKMATE, color))
                return -MAX_VALUE;

            foreach (var squares in board.Squares)
            {
                if(!Pieces.IsNotPiece(squares.Piece))
                {
                    int value = Pieces.GetPieceValue(squares.Piece);
                    if (color != squares.Color)
                        value *= -1;
                    score += value;
                }
            }
            return score;
        }

        private bool hasKing(Board board, int color)
        {
            var pieces = board.GetAllPieces(color);
            foreach (var piece in pieces)
                if (board.Squares[piece.X, piece.Y].Piece == Pieces.KING)
                    return true;
            return false;
        }
    }
}
