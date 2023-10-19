using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Тортики
{
    internal class Arrow
    {

        public static int Show(int min, int max)
        {
            int pos = 1;
            ConsoleKeyInfo key;
            do
            {
                Console.SetCursorPosition(0, pos);
                Console.WriteLine("->");
                key = Console.ReadKey(true);
                Console.SetCursorPosition(0, pos);
                Console.WriteLine("  ");
                if (key.Key == ConsoleKey.UpArrow && pos != min)
                {
                    pos--;
                }
                else if (key.Key == ConsoleKey.DownArrow && pos != max)
                {
                    pos++;
                }
                else if (key.Key == ConsoleKey.Escape)
                {
                    Console.SetCursorPosition(0, max+4);
                    return 0;
                }
            } while (key.Key != ConsoleKey.Enter);
            return pos;
        }
    }
}
