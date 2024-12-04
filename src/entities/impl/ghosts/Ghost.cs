using System.Numerics;
using System.Windows.Media;

namespace WpfApp1.src.entities.impl.ghosts
{
    abstract class Ghost : Entity
    {
        public Ghost() {
            SpriteShape.Width = 20;
            SpriteShape.Height = 20;
        }
    }
}
