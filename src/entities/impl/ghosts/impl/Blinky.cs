using System;
using System.Collections.Generic;
using System.Windows.Documents;
using System.Windows.Media;
using WpfApp1.src.entities.impl.ghosts.impl.helpers;

namespace WpfApp1.src.entities.impl.ghosts
{
    class Blinky : Ghost
    {
        private List<PathfindingSystem.ResultPoint> path = null;
        private DateTime lastMoveTime = DateTime.MinValue;

        public Blinky() {
            color = Brushes.Red;
        }

        public override void update(double deltaTime)
        {
            if (path ==  null)
            {
            }
        }
    }
}
