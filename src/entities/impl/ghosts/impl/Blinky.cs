using System.Windows.Media;

namespace WpfApp1.src.entities.impl.ghosts
{
    class Blinky : Ghost
    {
        public Blinky() {
            color = Brushes.Red;
        }

        public override void update(double deltaTime)
        {
            // movement logic
        }
    }
}
