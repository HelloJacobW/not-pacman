using System.Diagnostics;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

public class Pacman : Entity
{
    public bool moveRight = true;
    public bool moveLeft;
    public bool moveUp;
    public bool moveDown;

    public Pacman()
    {
        SpriteShape = new Ellipse();
        SpriteShape.Fill = Brushes.Yellow;
        SpriteShape.Width = 20;
        SpriteShape.Height = 20;
    }

    public override void update(double deltaTime)
    {
     if (moveRight && position.X < 700)
        {
            position.X += (float)(100f * deltaTime);
        }
     if (moveLeft && position.X > 0)
        {
            position.X -= (float)(100f * deltaTime);
        }

     if (moveUp && position.Y <= 0)
        {
            position.Y -= (float)(100f * deltaTime);
        }
     if (moveDown && position.Y < 540)
        {
            position.Y += (float)(100f * deltaTime);
        }
    }


    public void OnKeyDown(KeyEventArgs e)
    {
    }

    public void OnKeyUp(KeyEventArgs e)
    {
    }
}