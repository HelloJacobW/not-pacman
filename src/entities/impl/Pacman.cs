using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using WpfApp1;
using WpfApp1.src;
using WpfApp1.src.board;
using WpfApp1.src.entities.impl;

public class Pacman : Entity
{
    private MoveDirection moveDirection = MoveDirection.NONE;
    private MoveDirection nextMoveDirection = MoveDirection.NONE;

    public DateTime elapsedTime;
    private Vector2 mapPos = new Vector2(25, 25);

    private Vector2 portalOne = new Vector2(1, 14);
    private Vector2 portalTwo = new Vector2(26, 14);


    public Pacman()
    {
        SpriteShape = new Ellipse();
        SpriteShape.Fill = Brushes.Yellow;
        SpriteShape.Width = 20;
        SpriteShape.Height = 20;

        elapsedTime = DateTime.Now;

        position = MainWindow.ToMapPos(mapPos);
        update(0d);
    }

    public override void update(double deltaTime)
    {

        if (Vector2.Distance(mapPos, portalOne) == 0)
        {
            mapPos = portalTwo;
            elapsedTime = DateTime.MinValue;
        }
        else if (Vector2.Distance(mapPos, portalTwo) == 0)
        {
            mapPos = portalOne;
            elapsedTime = DateTime.MinValue;
        }


        try
        {
            if (MainWindow.board[(int)mapPos.X, (int)mapPos.Y] == TileType.DOT)
            {
                foreach (var dot in MainWindow.GetEntitiesByType<DotEntity>())
                {
                    Vector2 playerMapPos = MainWindow.ToMapPos(position);
                    Vector2 dotMapPos = MainWindow.ToMapPos(dot.position);

                    if (dotMapPos == playerMapPos)
                    {
                        Debug.WriteLine($"destroyed {dot}");
                        dot.destroy();
                    }
                }
            }
        }
        catch (Exception ex) { }


        if ((DateTime.Now - elapsedTime).TotalMilliseconds >= 200)
        {
            Vector2 futurePos = mapPos;
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
                mapPos = futurePos;
            }

            elapsedTime = DateTime.Now;
        }
    }

    public override void draw()
    {
        Canvas.SetLeft(SpriteShape, position.X + (SpriteShape.Width / 2) - 15);
        Canvas.SetTop(SpriteShape, position.Y + (SpriteShape.Height / 2) - 15);
    }


    public void OnKeyDown(KeyEventArgs e)
    {
        if (e.Key == Key.W || e.Key == Key.Up)
        {
            moveDirection = MoveDirection.UP;
        }
        if (e.Key == Key.S || e.Key == Key.Down)
        {
            moveDirection = MoveDirection.DOWN;
        }

        if (e.Key == Key.D || e.Key == Key.Right)
        {
            moveDirection = MoveDirection.RIGHT;
        }
        if((e.Key == Key.A || e.Key == Key.Left) && position.X != 0)
        {
            moveDirection = MoveDirection.LEFT;
        }

        if (e.Key == Key.Space)
            moveDirection = MoveDirection.NONE;
    }

    public void OnKeyUp(KeyEventArgs e)
    {
    }

    private bool DoesIntersect(Vector2 pos)
    {
        var playerRect = new WpfApp1.src.helpers.Rectangle(pos.X, pos.Y, 1f, 1f);
        foreach (var wall in Constants.walls)
            if (wall.Intersects(playerRect))
                return true;


        return false;
    }

    private enum MoveDirection
    {
        LEFT, RIGHT, UP, DOWN, NONE
    }
}