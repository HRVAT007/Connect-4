using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect_4
{
    public class AI
    {
        private Board _board;
        public AI(Board board)
        {
            _board = board;
        }

        public int GetBestMove(Coin coin)
        {
            float bestScore = float.NegativeInfinity;
            int bestMove = 0;
            for (int i = 0; i < 7; i++)
            {
                _tempBoard.Cell = _board.Cell;
                if (!_tempBoard.CanDrop(i))
                {
                    continue;
                }
                _tempBoard.Drop(i, coin);
                var score = GetScore(_tempBoard.Cell, 6, coin, coin.Opposite(), false, float.NegativeInfinity, float.PositiveInfinity);
                if (score > bestScore)
                {
                    bestMove = i;
                    bestScore = score;
                }
            }
            return bestMove;
        }

        Board _tempBoard = new Board();
        public float GetScore(Coin[,] node, int depth, Coin player, Coin coin, bool max, float alpha, float beta)
        {
            _tempBoard.Cell = node;
            if (depth == 0 || _tempBoard.IsFull() || _tempBoard.GetScore(player) == float.PositiveInfinity || _tempBoard.GetScore(player.Opposite()) == float.PositiveInfinity)
            {
                float scoreAhead = _tempBoard.GetScoreAhead(player);
                return scoreAhead;
            }
            float value;
            if (max)
            {
                value = float.NegativeInfinity;
            }
            else
            {
                value = float.PositiveInfinity;
            }
            for (int i = 0; i < 7; i++)
            {
                _tempBoard.Cell = node;
                if (!_tempBoard.CanDrop(i))
                {
                    continue;
                }
                _tempBoard.Drop(i, coin);
                float score = GetScore(_tempBoard.Cell, depth - 1, player, coin.Opposite(), !max, alpha, beta);
                if (max)
                {
                    value = Math.Max(value, score);
                    alpha = Math.Max(alpha, value);
                    if (value >= beta)
                        break;
                }
                else
                {
                    value = Math.Min(value, score);
                    beta = Math.Min(beta, value);
                    if (value <= alpha)
                        break;
                }
            }
            return value;
        }
    }
}
