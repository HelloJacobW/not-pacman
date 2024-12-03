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
        public static TileType[,] board = new TileType[36,28];

        public static List<Rectangle> walls = new List<Rectangle> {

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
                    board[i, j] = TileType.DOT;
                    entities.Add(new DotEntity(new System.Numerics.Vector2((i*20) + 10, (j*20) + 10)));
                }
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

        public static List<T> GetEntitiesByType<T>() where T : Entity
        {
            return entities.OfType<T>().ToList();
        }

        public static T GetEntityByType<T>() where T : Entity
        {
            return GetEntitiesByType<T>().First();
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

        private void Grid_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {

        }
    }
}
