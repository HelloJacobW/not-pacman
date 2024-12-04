using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Numerics;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using WpfApp1;
using WpfApp1.src;
using WpfApp1.src.board;
using WpfApp1.src.entities.impl;
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
            Vector2 futurePos = MainWindow.ToMapPos(position);
            //Vector2 playerMapPos = MainWindow.ToMapPos(position);

            if (moveDirection == MoveDirection.RIGHT)
            {
                futurePos.X += 1;
            }
            if (moveDirection == MoveDirection.LEFT && futurePos.X != 0)
            {
                futurePos.X -= 1;
            }

            if (moveDirection == MoveDirection.UP && futurePos.Y != 0)
            {
                futurePos.Y -= 1;
            }
            if (moveDirection == MoveDirection.DOWN)
            {
                futurePos.Y += 1;
            }

            if (!DoesIntersect(futurePos))
            {
                position = MainWindow.ToScreenPos(futurePos);
            }
            
            elapsedTime = DateTime.Now;

            if (MainWindow.board[(int) futurePos.X,(int) futurePos.Y] == TileType.DOT)
            {
                foreach (var dot in MainWindow.GetEntitiesByType<DotEntity>())
                {
                    Vector2 dotMapPos = MainWindow.ToMapPos(dot.position);

                    var playerMapPos = MainWindow.ToMapPos(position);
                    if (dotMapPos.X == playerMapPos.X && dotMapPos.Y == playerMapPos.Y)
                    {
                        Debug.Write($"destroyed {dot}");
                        dot.destroy();
                    }
                }
            }
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
        if(e.Key == Key.A && position.X != 0)
        {
            moveDirection = MoveDirection.LEFT;
        }
    }

    public void OnKeyUp(KeyEventArgs e)
    {
    }

    private bool DoesIntersect(Vector2 pos)
    {
        Debug.WriteLine(pos.X+$" ({pos.X}), "+ pos.Y + $" ({pos.Y})");
        var playerRect = new WpfApp1.src.helpers.Rectangle(pos.X+0.5f, pos.Y+0.5f, .1f, .1f);
        
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