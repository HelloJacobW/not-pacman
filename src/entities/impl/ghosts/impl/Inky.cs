using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System;
using System.Windows.Media;
using WpfApp1.src.entities.impl.ghosts.impl.helpers;

namespace WpfApp1.src.entities.impl.ghosts
{
    class Inky : Blinky
    {
        public Inky() : base()
        {
            SpriteShape.Fill = Brushes.Cyan;
        }
    }
}
