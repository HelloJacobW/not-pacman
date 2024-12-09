using System.Drawing;
using System.Numerics;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WpfApp1.src.entities.impl
{
    public class WallEntity : Entity
    {
        public helpers.Rectangle collider = new(0, 0, 0, 0);

        public WallEntity(Vector2 position, float width, float heigth)
        {
            this.position = position;
            SpriteShape.Width = width;
            SpriteShape.Height = heigth;
            SpriteShape.Fill = Brushes.Blue;
            collider = new(position.X, position.Y, width, heigth);
        }
        public override void update(double deltaTime)
        {
        
        }
    }

    public class HollowWall : Entity
    {
        public HollowWall(Vector2 position, float width, float heighth)
        {
            this.position = new Vector2(position.X + 5, position.Y + 5);
            SpriteShape.Width = width - 10;
            SpriteShape.Height = heighth - 10;
            SpriteShape.Fill = Brushes.Black;
        }

        public override void update(double deltaTime)
        {

        }
    }

    public class Barrier : Entity
    {
        public helpers.Rectangle collider = new(0, 0, 0, 0);
        public Barrier(Vector2 position, float width, float heigth)
        {
            this.position = position;
            SpriteShape.Width = width;
            SpriteShape.Height = heigth;
            SpriteShape.Fill = Brushes.WhiteSmoke;
            collider = new(position.X, position.Y, width, heigth);
        }

        public override void update(double deltaTime)
        {

        }
    }
}
