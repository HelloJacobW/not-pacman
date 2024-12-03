using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.src
{
    public class Constants
    {
        public static List<helpers.Rectangle> walls = new List<helpers.Rectangle> {
            // four main walls
            new(0, 0, 28, 1),
            new(0, 0, 1, 31),
            new(27, 0, 1, 31),
            new(0, 30, 28, 1),

            new(2, 2, 4, 3),
            new(7, 2, 5, 3),
            new(13, 0, 2, 4),
            new(16, 2, 5, 3),
            new(22, 2, 4, 3),
            new(2, 6, 4, 2),
            new(7, 6, 2, 8),
            new(0, 9, 6, 5),
            new(0, 15, 6, 5),
            new(0, 24, 3, 2),
            new(2, 21, 4, 2),
            new(4, 22, 2, 4),
            new(2, 27, 10, 2),
            new(7, 24, 2, 4),
            new(7, 21, 5, 2),
            new(7, 15, 2, 5),
            new(10, 6, 8, 2),
            new(7, 9, 5, 2),
            new(13, 7, 2, 4),
            new(10, 12, 1, 5),
            new(10, 12, 3, 1),
            new(15, 12, 3, 1),
            new(17, 12, 1, 5),
            new(10, 16, 8, 1),
            new(10, 18, 8, 2),
            new(13, 19, 2, 4),
            new(10, 24, 8, 2),
            new(13, 25, 2, 4),
            new(16, 21, 5, 2),
            new(16, 27, 10, 2),
            new(19, 24, 2, 4),
            new(22, 21, 4, 2),
            new(22, 22, 2, 4),
            new(25, 24, 3, 2),
            new(22, 15, 6, 5),
            new(22, 9, 6, 5),
            new(19, 15, 2, 5),
            new(22, 6, 4, 2),
            new(19, 6, 2, 8),
            new(16, 9, 4, 2),
        };
    }
}
