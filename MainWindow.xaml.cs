using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using WpfApp1.src.board;
using WpfApp1.src.entities.impl;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public static GameCanvas canvas = new GameCanvas();

        public static DateTime lastFrameTime = DateTime.Now;
        public static List<Entity> entities = new List<Entity>();
        public static TileType[,] board = new TileType[28,36];

        public static List<src.helpers.Rectangle> walls = new List<src.helpers.Rectangle> {
            // four main walls
            new(0, 0, 28, 1),
            new(0, 0, 1, 36),
            new(27, 0, 1, 36),
            new(0, 35, 28, 1),
            
            new(2, 2, 4, 2),
            new(7, 2, 5, 2),
            new(13, 0, 2, 3),
            new(16, 2, 5, 2),
            new(22, 2, 4, 2),

        };

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

            //  - add the dots
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (WouldBeInWall(i, j))
                        continue;

                    board[i, j] = TileType.DOT;
                    entities.Add(new DotEntity(new System.Numerics.Vector2((i*20) + 10, (j*20) + 10)));
                }
            }

            //  - add the walls
            foreach (var wall in walls)
            {
                entities.Add(new WallEntity(new System.Numerics.Vector2((float)((wall.x * 20) + 7.5), (float) ((wall.y * 20) + 7.5)), (float)(wall.width * 20) - 5, (wall.height * 20) - 5));
                board[(int)wall.x, (int)wall.y] = TileType.WALL;
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

            foreach (var entity in entities)
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

            foreach (var entity in walls) {
                if (entity.Intersects(rect))
                    return true;
            }

            return false;
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
    }
}
