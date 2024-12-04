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
            Vector2 futurePos = position;
            Vector2 playerMapPos = MainWindow.ToMapPos(position);

            if (moveDirection == MoveDirection.RIGHT)
            {
                futurePos.X += (float)(20f);
            }
            if (moveDirection == MoveDirection.LEFT && playerMapPos.X != 0)
            {
                futurePos.X -= (float)(20f);
            }

            if (moveDirection == MoveDirection.UP && playerMapPos.Y != 0)
            {
                futurePos.Y -= (float)(20f);
            }
            if (moveDirection == MoveDirection.DOWN)
            {
                futurePos.Y += (float)(20f);
            }

            if (!DoesIntersect(futurePos))
            {
                position = futurePos;
            }
            
            elapsedTime = DateTime.Now;

            if (MainWindow.board[(int) playerMapPos.X,(int) playerMapPos.Y] == TileType.DOT)
            {
                foreach (var dot in MainWindow.GetEntitiesByType<DotEntity>())
                {
                    Vector2 dotMapPos = MainWindow.ToMapPos(dot.position);

                    if (dotMapPos == position)
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
        Vector2 playerMapPos = MainWindow.ToMapPos(pos);
        Debug.WriteLine(playerMapPos.X+","+playerMapPos.Y);
        var playerRect = new WpfApp1.src.helpers.Rectangle(playerMapPos.X+1, playerMapPos.Y+1, .1f, .1f);
        
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