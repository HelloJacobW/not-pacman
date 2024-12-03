using System.Windows.Media;

namespace WpfApp1.src.entities.impl.ghosts
{
    class Clyde : Ghost
    {
        public Clyde() {
            color = Brushes.Orange;
        }

        public override void update(double deltaTime)
        {
            // movement logic
        }
    }
}
