using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect_4
{
    class Controls
    {
        int currentColumn = 3;

        public void DropChoice()
        {
            String input = Console.ReadLine();
            int choice = Int32.Parse(input);
            if (choice == 1) { currentColumn = 0; }
            else if (choice == 2) { currentColumn = 1; }
            else if (choice == 3) { currentColumn = 2; }
            else if (choice == 4) { currentColumn = 3; }
            else if (choice == 5) { currentColumn = 4; }
            else if (choice == 6) { currentColumn = 5; }
            else if (choice == 7) { currentColumn = 6; }
        }
    }
}
