using System.Numerics;
using System.Windows.Media;
using WpfApp1.src.helpers;

namespace WpfApp1.src.entities.impl
{
    class DotEntity : Entity
    {
        public Rectangle collider = new Rectangle(0, 0, 0, 0);

        public DotEntity(Vector2 pos) {
            SpriteShape = new System.Windows.Shapes.Ellipse();
            SpriteShape.Width = 10;
            SpriteShape.Height = 10;
            SpriteShape.Fill = Brushes.White;
            this.position = pos;
            collider = new Rectangle(pos.X, pos.Y, (float) SpriteShape.Width, (float) SpriteShape.Height);
        }

        public override void update(double deltaTime)
        {
        }
    }
}
