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
            new(0, 0, 1, 36),
            new(27, 0, 1, 36),
            new(0, 35, 28, 1),

            new(2, 2, 4, 2),
            new(7, 2, 5, 2),
            new(13, 0, 2, 3),
            new(16, 2, 5, 2),
            new(22, 2, 4, 2),

        };
    }
}
