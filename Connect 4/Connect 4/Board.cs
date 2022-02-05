using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect_4
{
    public class Board
    {
        public int Rows = 6;
        public int Columns = 7;
        private Coin[,] cell;

        public Board() {
            cell = new Coin[Rows, Columns];
            PopulateEmptyCells();
        }

        private void PopulateEmptyCells()
        {
            for (int row = 0; row < Rows; row++)
            {
                for (int column = 0; column < Columns; column++)
                {
                    cell[row, column] = Coin.Clear;
                }
            }
        }

        public bool CanDrop(int column)
        {
            if (cell[0, column] == Coin.Clear) { return true; }
            else { return false; }
        }

        public void DrawBoard()
        {
            for (int row = 0; row < Rows; row++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("■■ ");
                for (int column = 0; column < Columns; column++)
                {
                    Coin type = cell[row, column];
                    switch(type)
                    {
                        case Coin.Clear:
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write(". ");
                            break;
                        case Coin.Red:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("O ");
                            break;
                        case Coin.Green:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("O ");
                            break;
                    }
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("■■");
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("■■■■■■■■■■■■■■■■■■■");
        }
    }
}