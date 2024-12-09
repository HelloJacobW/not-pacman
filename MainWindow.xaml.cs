using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using WpfApp1.src;
using WpfApp1.src.board;
using WpfApp1.src.entities.impl;
using WpfApp1.src.entities.impl.ghosts;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public static GameCanvas canvas = new GameCanvas();

        public static DateTime lastFrameTime = DateTime.Now;
        public static List<Entity> entities = new List<Entity>();
        public static TileType[,] board = new TileType[28,36];



        public MainWindow()
        {
            // Setup window
            InitializeComponent();
            Content = canvas;
            Title = "Not Pacman!";


            // Add entities

            //  - add pacman
            entities.Add(new Pacman());

            //  - add the ghosts
            entities.Add(new Blinky());
            entities.Add(new Inky());
            entities.Add(new Pinky());
            entities.Add(new Clyde());

            //  - add the dots
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (WouldBeInWall(i, j))
                        continue;

                    if (!(9 < i && i < 17) || !(12 < j && j < 16))
                        {
                        board[i, j] = TileType.DOT;
                        entities.Add(new DotEntity(ToScreenPos(new Vector2(i, j))));
                        }
                }
            }

            // - add the barrier infront of ghosts
            entities.Add(new Barrier(
                ToScreenPos(new Vector2(13 - .8f, 12)),
                (float)(60),
                (float)(11)
                ));

            //  - add the main walls
            foreach (var wall in Constants.walls)
            {
                var rel = ToScreenPos(new Vector2(wall.x, wall.y));

                entities.Add(new WallEntity(
                        new Vector2(rel.X-2.5f, rel.Y-2.5f),
                        (float)(wall.width * 20) - 5, 
                        (float)(wall.height * 20) - 5
                    ));
                board[(int)wall.x, (int)wall.y] = TileType.WALL;
            }

            // - Make the walls "hollow" | fill them in with black
            foreach (var wall in Constants.walls)
            {
                var rel = ToScreenPos(new Vector2(wall.x, wall.y));

                entities.Add(new HollowWall(
                    new Vector2(rel.X - 2.5f, rel.Y - 2.5f),
                    (float)(wall.width * 20) - 5,
                    (float)(wall.height * 20) - 5
                    ));
            }

            // register the entities sprite shape with the canvas (make the entities appear on the screen)
            foreach (Entity entity in entities)
                canvas.Children.Add(entity.SpriteShape);

            // Game loop event
            CompositionTarget.Rendering += Clock;
        }

        private void Clock(object sender, EventArgs e)
        {
            double deltaTime = (DateTime.Now - lastFrameTime).TotalMilliseconds / 1000;
            lastFrameTime = DateTime.Now;

            List<Entity> cloned = new List<Entity>();
            cloned.AddRange(entities);

            foreach (var entity in cloned)
            {
                entity.update(deltaTime);
                entity.draw();
            }
        }


        // helper methods ==========
        public static List<T> GetEntitiesByType<T>() where T : Entity
        {
            return entities.OfType<T>().ToList();
        }

        public static T GetEntityByType<T>() where T : Entity
        {
            return GetEntitiesByType<T>().First();
        }

        private static bool WouldBeInWall(int x, int y)
        {
            src.helpers.Rectangle rect = new(x, y, 1, 1);

            foreach (var entity in Constants.walls) {
                if (entity.Intersects(rect))
                    return true;
            }

            return false;
        }

        public static Vector2 ToScreenPos(Vector2 pos)
        {
            return new(
                    (pos.X * 20) + 10,
                    (pos.Y * 20 + 10)
                );
        }

        public static Vector2 ToMapPos(Vector2 pos)
        {
            return new(
                   (int)(pos.X - 10) / 20,
                   (int)(pos.Y - 10) / 20
                );
        }


        public class GameCanvas : Canvas
        {
            public GameCanvas() : base()
            {
                Background = Brushes.Black;
            }

            protected override void OnRender(DrawingContext drawingContext)
            {
                base.OnRender(drawingContext);
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            GetEntityByType<Pacman>().OnKeyDown(e);
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            GetEntityByType<Pacman>().OnKeyUp(e);
        }
    }
}
