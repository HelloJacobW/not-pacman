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
            SpriteShape = new CustomShape();

            this.position = position;
            SpriteShape.Width = width;
            SpriteShape.Height = heigth;
            SpriteShape.Fill = Brushes.Blue;
            collider = new(position.X, position.Y, width, heigth);
        }

        public override void update(double deltaTime)
        {
        }



        public class CustomShape : Shape
        {
            public double Thickness { get; set; } = 5;

            protected override Geometry DefiningGeometry
            {
                get
                {
                    if (Thickness <= 0 || Width <= Thickness || Height <= Thickness)
                    {
                        return Geometry.Empty;
                    }

                    double halfThickness = Thickness / 2;

                    Rect outerRect = new Rect(0, 0, Width, Height);
                    Rect innerRect = new Rect(halfThickness, halfThickness, Width - Thickness, Height - Thickness);

                    Geometry outerGeometry = new RectangleGeometry(outerRect);
                    Geometry innerGeometry = new RectangleGeometry(innerRect);

                    CombinedGeometry hollowedOutGeometry = new CombinedGeometry(GeometryCombineMode.Exclude, outerGeometry, innerGeometry);

                    return hollowedOutGeometry;
                }
            }

            public double Width { get; set; } = 100;
            public double Height { get; set; } = 50;
        }

    }
}
