using System.Windows.Media;
using System.Windows.Shapes;

public class Pacman : Entity
{
    public Pacman()
    {
        SpriteShape = new Ellipse();
        SpriteShape.Fill = Brushes.Yellow;
        SpriteShape.Width = 25;
        SpriteShape.Height = 25;
    }

    public override void update(double deltaTime)
    {
        position.X += (float) (100f * deltaTime);
    }
}