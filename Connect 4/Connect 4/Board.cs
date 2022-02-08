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
        int currentColumn = 3;
        Coin coinColor = Coin.Red;

        public Board() {
            cell = new Coin[Rows, Columns];
            PopulateEmptyCells();
        }

        public void Start ()
        {
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

        public void Drop(int column, Coin coin)
        {
            if (!CanDrop(column)) { return; }
            int currentRow = 0;
            while (currentRow < Rows - 1 &&
                cell[currentRow + 1, column] == Coin.Clear)
            {
                currentRow++;
            }
            cell[currentRow, column] = coin;
        }

        public bool IsFull()
        {
            for (int column = 0; column < Columns; column++)
            {
                if (CanDrop(column)) { return false; }
            }

            return true;
        }

        public bool HasWon(Coin coinColor)
        {
            for (int row = 0; row < Rows; row++)
            {
                for (int column = 0; column < Columns; column++)
                {
                    if (CheckYAxis(row, column, coinColor)) { return true; }
                    if (CheckXAxis(row, column, coinColor)) { return true; }
                    if (CheckDiagonallyDown(row, column, coinColor)) { return true; }
                    if (CheckDiagonallyUp(row, column, coinColor)) { return true; }
                }
            }

            return false;
        }

        private bool CheckXAxis(int row, int column, Coin coinColor)
        {
            if (column + 3 >= Columns) { return false; }

            for (int distance = 0; distance < 4; distance++)
            {
                if (cell[row, column + distance] != coinColor) { return false; }
            }

            return true;
        }

        private bool CheckYAxis(int row, int column, Coin coinColor)
        {
            if (row + 3 >= Rows) { return false; }

            for (int distance = 0; distance < 4; distance++)
            {
                if (cell[row + distance, column] != coinColor) { return false; }
            }

            return true;
        }

        private bool CheckDiagonallyDown(int row, int column, Coin coinColor)
        {
            if (row + 3 >= Rows) { return false; }
            if (column + 3 >= Columns) { return false; }

            for (int distance = 0; distance < 4; distance++)
            {
                if (cell[row + distance, column + distance] != coinColor) { return false; }
            }

            return true;
        }

        private bool CheckDiagonallyUp(int row, int column, Coin coinColor)
        {
            if (row - 3 < 0) { return false; }
            if (column + 3 >= Columns) { return false; }

            for (int distance = 0; distance < 4; distance++)
            {
                if (cell[row - distance, column + distance] != coinColor) { return false; }
            }

            return true;
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