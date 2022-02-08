using System;

namespace Connect_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            board.Start();
            int currentColumn = 3;
            Coin coinColor = Coin.Red;

            while (!board.HasWon(Coin.Red) &&
                !board.HasWon(Coin.Green) &&
                !board.IsFull())
            {
                Console.Clear();
                board.DrawBoard();
                    String input = Console.ReadLine();
                    int choice = Int32.Parse(input);
                currentColumn = choice - 1;
                if (board.CanDrop(currentColumn))
                    {
                        board.Drop(currentColumn, coinColor);
                        if (coinColor == Coin.Red) { coinColor = Coin.Green; }
                        else { coinColor = Coin.Red; }
                    }
                }
            }
        }
    }
