using System.Windows.Media;

namespace WpfApp1.src.entities.impl.ghosts
{
    class Pinky : Ghost
    {
        public Pinky() {
            color = Brushes.Pink;
        }

        public override void update(double deltaTime)
        {
            // movement logic
        }
    }
}
