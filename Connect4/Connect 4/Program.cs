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
            Coin coinColor = Coin.Green;
            const Coin AICoin = Coin.Red;


            AI ai = new AI(board);
            AI ai2 = new AI(board);


            Console.WriteLine("Input 1 if you wish to play against AI, input 2 if you wish to watch AI vs AI or input 3 if you wish to play VS human.");
            int mode = Int32.Parse(Console.ReadLine());

            if (mode == 1)
            {
                while (!board.HasWon(Coin.Red) &&
                !board.HasWon(Coin.Green) &&
                !board.IsFull())
                {
                    Console.Clear();
                    board.DrawBoard();
                    int choice;


                        if (coinColor != AICoin)
                        {
                            String input = Console.ReadLine();
                            choice = Int32.Parse(input);
                            currentColumn = choice - 1;
                        }
                        else
                        {
                            currentColumn = choice = ai.GetBestMove(coinColor);
                            if (!board.CanDrop(currentColumn))
                            {
                                int secondaryChoice = currentColumn + 1;
                                board.Drop(secondaryChoice, coinColor);
                                if (coinColor == Coin.Red) { coinColor = Coin.Green; }
                                else { coinColor = Coin.Red; }
                            }
                        }
                        if (board.CanDrop(currentColumn))
                        {
                            board.Drop(currentColumn, coinColor);
                            if (coinColor == Coin.Red) { coinColor = Coin.Green; }
                            else { coinColor = Coin.Red; }
                        }
                        if (coinColor != AICoin)
                        {
                            currentColumn = choice = ai2.GetBestMove(coinColor);
                            if (!board.CanDrop(currentColumn))
                            {
                                int secondaryChoice = currentColumn + 1;
                                board.Drop(secondaryChoice, coinColor);
                                if (coinColor == Coin.Red) { coinColor = Coin.Green; }
                                else { coinColor = Coin.Red; }
                            }
                        }
                        else
                        {
                            currentColumn = choice = ai.GetBestMove(coinColor);
                            if (!board.CanDrop(currentColumn))
                            {
                                int secondaryChoice = currentColumn + 1;
                                board.Drop(secondaryChoice, coinColor);
                                if (coinColor == Coin.Red) { coinColor = Coin.Green; }
                                else { coinColor = Coin.Red; }
                            }
                        }
                        if (board.CanDrop(currentColumn))
                        {
                            board.Drop(currentColumn, coinColor);
                            if (coinColor == Coin.Red) { coinColor = Coin.Green; }
                            else { coinColor = Coin.Red; }
                        }

                    Console.Clear();
                    if (board.HasWon(Coin.Red))
                    {
                        Console.Out.WriteLine("RED WON");
                    }
                    else if (board.HasWon(Coin.Green))
                    {
                        Console.Out.WriteLine("GREEN WON");
                    }
                    else
                    {
                        Console.Out.WriteLine("A GODDAMN TIE");
                    }

                    board.DrawBoard();
                }
            }
            if (mode == 2)
            {
                {
                    while (!board.HasWon(Coin.Red) &&
                    !board.HasWon(Coin.Green) &&
                    !board.IsFull())
                    {
                        Console.Clear();
                        board.DrawBoard();
                        int choice;

                            if (coinColor != AICoin)
                            {
                                currentColumn = choice = ai2.GetBestMove(coinColor);
                                if (!board.CanDrop(currentColumn))
                                {
                                    int secondaryChoice = currentColumn + 1;
                                    board.Drop(secondaryChoice, coinColor);
                                    if (coinColor == Coin.Red) { coinColor = Coin.Green; }
                                    else { coinColor = Coin.Red; }
                                }
                            }
                            else
                            {
                                currentColumn = choice = ai.GetBestMove(coinColor);
                                if (!board.CanDrop(currentColumn))
                                {
                                    int secondaryChoice = currentColumn + 1;
                                    board.Drop(secondaryChoice, coinColor);
                                    if (coinColor == Coin.Red) { coinColor = Coin.Green; }
                                    else { coinColor = Coin.Red; }
                                }
                            }
                            if (board.CanDrop(currentColumn))
                            {
                                board.Drop(currentColumn, coinColor);
                                if (coinColor == Coin.Red) { coinColor = Coin.Green; }
                                else { coinColor = Coin.Red; }
                            }
                            if (coinColor != AICoin)
                            {
                                currentColumn = choice = ai2.GetBestMove(coinColor);
                                if (!board.CanDrop(currentColumn))
                                {
                                    int secondaryChoice = currentColumn + 1;
                                    board.Drop(secondaryChoice, coinColor);
                                    if (coinColor == Coin.Red) { coinColor = Coin.Green; }
                                    else { coinColor = Coin.Red; }
                                }
                            }
                            else
                            {
                                currentColumn = choice = ai.GetBestMove(coinColor);
                                if (!board.CanDrop(currentColumn))
                                {
                                    int secondaryChoice = currentColumn + 1;
                                    board.Drop(secondaryChoice, coinColor);
                                    if (coinColor == Coin.Red) { coinColor = Coin.Green; }
                                    else { coinColor = Coin.Red; }
                                }
                            }
                            if (board.CanDrop(currentColumn))
                            {
                                board.Drop(currentColumn, coinColor);
                                if (coinColor == Coin.Red) { coinColor = Coin.Green; }
                                else { coinColor = Coin.Red; }
                            }

                        Console.Clear();
                        if (board.HasWon(Coin.Red))
                        {
                            Console.Out.WriteLine("RED WON");
                        }
                        else if (board.HasWon(Coin.Green))
                        {
                            Console.Out.WriteLine("GREEN WON");
                        }
                        else
                        {
                            Console.Out.WriteLine("A GODDAMN TIE");
                        }

                        board.DrawBoard();
                    }
                }
            }
            if (mode == 3)
            {
                while (!board.HasWon(Coin.Red) &&
                !board.HasWon(Coin.Green) &&
                !board.IsFull())
                {
                    Console.Clear();
                    board.DrawBoard();
                    int choice;

                        String input = Console.ReadLine();
                        choice = Int32.Parse(input);
                        currentColumn = choice - 1;

                        if (board.CanDrop(currentColumn))
                        {
                            board.Drop(currentColumn, coinColor);
                            if (coinColor == Coin.Red) { coinColor = Coin.Green; }
                            else { coinColor = Coin.Red; }
                        }
                    
                    Console.Clear();
                    if (board.HasWon(Coin.Red))
                    {
                        Console.Out.WriteLine("RED WON");
                    }
                    else if (board.HasWon(Coin.Green))
                    {
                        Console.Out.WriteLine("GREEN WON");
                    }
                    else
                    {
                        Console.Out.WriteLine("A GODDAMN TIE");
                    }

                    board.DrawBoard();
                }
            }
        }
        
    }
    
}
