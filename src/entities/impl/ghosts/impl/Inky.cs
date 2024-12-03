using System.Windows.Media;

namespace WpfApp1.src.entities.impl.ghosts
{
    class Inky : Ghost
    {
        public Inky() {
            color = Brushes.Blue;
        }

        public override void update(double deltaTime)
        {
            // movement logic
        }
    }
}
