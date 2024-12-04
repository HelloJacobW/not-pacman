using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System;
using System.Windows.Media;
using WpfApp1.src.entities.impl.ghosts.impl.helpers;

namespace WpfApp1.src.entities.impl.ghosts
{
    class Pinky : Blinky
    {
        public Pinky() : base()
        {
            SpriteShape.Fill = Brushes.Pink;
            position = MainWindow.ToScreenPos(new Vector2(13, 13));
        }
    }
}
