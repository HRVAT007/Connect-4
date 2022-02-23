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

        public Coin[,] Cell { set => cell = value.Clone() as Coin[,]; get => cell.Clone() as Coin[,]; }

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
            const int winningLength = 4;
            for (int row = 0; row < Rows; row++)
            {
                for (int column = 0; column < Columns; column++)
                {
                    if (CheckYAxis(row, column, coinColor, winningLength)) { return true; }
                    if (CheckXAxis(row, column, coinColor, winningLength)) { return true; }
                    if (CheckDiagonallyDown(row, column, coinColor, winningLength)) { return true; }
                    if (CheckDiagonallyUp(row, column, coinColor, winningLength)) { return true; }
                }
            }

            return false;
        }

        public float GetScoreAhead(Coin coin)
        {
            float myScore = GetScore(coin);
            float opposite = GetScore(coin.Opposite());
            return myScore - opposite;
        }

        public float GetScore(Coin coin)
        {
            float score = 0;

            for (int x = 0; x < Columns; x++)
            {
                for (int y = 0; y < Rows; y++)
                {
                    for (int length = 4; length >= 2; length--)
                    {
                        int checkCount = Check(y, x, coin, length);
                        score += checkCount * length;
                        if(length == 4 && checkCount > 0)
                        {
                            score = float.PositiveInfinity;
                            return score;
                        }

                        if (checkCount > 0)
                        {
                            break;
                        }
                    }
                }
            }

            return score;
        }

        private int Check(int row, int column, Coin coinColor, int length)
        {
            return new bool[] { 
                CheckXAxis(row, column, coinColor, length), 
                CheckYAxis(row, column, coinColor, length), 
                CheckDiagonallyDown(row, column, coinColor, length),
                CheckDiagonallyUp(row, column, coinColor, length), }
            .Where(x => x).Count();
        }

        private bool CheckXAxis(int row, int column, Coin coinColor, int length)
        {
            if (column + (length - 1) >= Columns) { return false; }

            for (int distance = 0; distance < length; distance++)
            {
                if (cell[row, column + distance] != coinColor) { return false; }
            }

            return true;
        }

        private bool CheckYAxis(int row, int column, Coin coinColor, int length)
        {
            if (row + (length - 1) >= Rows) { return false; }

            for (int distance = 0; distance < length; distance++)
            {
                if (cell[row + distance, column] != coinColor) { return false; }
            }

            return true;
        }

        private bool CheckDiagonallyDown(int row, int column, Coin coinColor, int length)
        {
            if (row + (length - 1) >= Rows) { return false; }
            if (column + (length - 1) >= Columns) { return false; }

            for (int distance = 0; distance < length; distance++)
            {
                if (cell[row + distance, column + distance] != coinColor) { return false; }
            }

            return true;
        }

        private bool CheckDiagonallyUp(int row, int column, Coin coinColor, int length)
        {
            if (row - (length - 1) < 0) { return false; }
            if (column + (length - 1) >= Columns) { return false; }

            for (int distance = 0; distance < length; distance++)
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
            Console.WriteLine($" ");
            for (int i = 0; i < 7; i++)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine($"");
            Console.WriteLine($"{Coin.Green.ToString()} score is '{GetScore(Coin.Green)}'\n{Coin.Red.ToString()} score is '{GetScore(Coin.Red)}'");
        }
    }
}