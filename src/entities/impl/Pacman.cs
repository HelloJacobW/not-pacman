using System;
using System.Diagnostics;
using System.Numerics;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using WpfApp1;
using WpfApp1.src;
using WpfApp1.src.helpers;

public class Pacman : Entity
{
    private MoveDirection moveDirection = MoveDirection.NONE;

    public DateTime elapsedTime;

    public Pacman()
    {
        SpriteShape = new Ellipse();
        SpriteShape.Fill = Brushes.Yellow;
        SpriteShape.Width = 20;
        SpriteShape.Height = 20;

        position = new System.Numerics.Vector2(25, 25);
        elapsedTime = DateTime.Now;
    }

    public override void update(double deltaTime)
    {
     if((DateTime.Now - elapsedTime).TotalMilliseconds >= 250)
        {
            if (moveDirection == MoveDirection.RIGHT && )
            {
                position.X += (float)(20f);
            }
            if (moveDirection == MoveDirection.LEFT && position.X > 25)
            {
                position.X -= (float)(20f);
            }

            if (moveDirection == MoveDirection.UP && position.Y > 25)
            {
                position.Y -= (float)(20f);
            }
            if (moveDirection == MoveDirection.DOWN && position.Y < 540)
            {
                position.Y += (float)(20f);
            }

            elapsedTime = DateTime.Now;
        }
    }

    public void OnKeyDown(KeyEventArgs e)
    {
        if (e.Key == Key.W)
        {
            moveDirection = MoveDirection.UP;
        }
        if (e.Key == Key.S)
        {
            moveDirection = MoveDirection.DOWN;
        }

        if (e.Key == Key.D)
        {
            moveDirection = MoveDirection.RIGHT;
        }
        if(e.Key == Key.A)
        {
            moveDirection = MoveDirection.LEFT;
        }
    }

    public void OnKeyUp(KeyEventArgs e)
    {
    }

    private bool DoesIntersect(Vector2 pos)
    {
        Vector2 playerMapPos = Vector2.Zero;
        var playerRect = new WpfApp1.src.helpers.Rectangle(playerMapPos.X, playerMapPos.Y, 1, 1);
        
        foreach (var wall in Constants.walls)
        {
            if (wall.Intersects(playerRect))
                return true;
        }

        return false;
    }

    private enum MoveDirection
    {
        LEFT, RIGHT, UP, DOWN, NONE
    }
}