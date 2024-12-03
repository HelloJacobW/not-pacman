using System.Numerics;
using System.Windows.Media;

namespace WpfApp1.src.entities.impl.ghosts
{
    abstract class Ghost : Entity
    {
        protected Vector2 position = new Vector2(0, 0);
        protected Brush color = null;
    }
}
