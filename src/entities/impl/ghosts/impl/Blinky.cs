using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Documents;
using System.Windows.Media;
using WpfApp1.src.entities.impl.ghosts.impl.helpers;

namespace WpfApp1.src.entities.impl.ghosts
{
    class Blinky : Ghost
    {
        private List<PathfindingSystem.ResultPoint> path = null;
        private DateTime lastMoveTime = DateTime.MinValue;

        public Blinky() : base() {
            SpriteShape.Fill = Brushes.Red;
            position = MainWindow.ToScreenPos(new System.Numerics.Vector2(13, 13));
        }

        public override void update(double deltaTime)
        {
            if (path ==  null)
            {
                Pacman pacman = MainWindow.GetEntityByType<Pacman>();

                if (pacman == null)
                {
                    Debug.WriteLine("Pacman is nulll...");
                    return;
                }

                var bs = GetBoardState();

                path = PathfindingSystem.TryGetPath(
                        bs,
                        MainWindow.ToMapPos(position),
                        MainWindow.ToMapPos(pacman.position)
                    );

                Debug.WriteLine($"Generated path: {path} ({path != null})");
            }
        }

        private List<List<PathfindingSystem.TileState>> GetBoardState()
        {
            int boardWidth = 28; // Assuming the width of the board
            int boardHeight = 31; // Assuming the height of the board

            // Initialize the board with false values
            List<List<PathfindingSystem.TileState>> board = new List<List<PathfindingSystem.TileState>>();
            for (int y = 0; y < boardHeight; y++)
            {
                List<PathfindingSystem.TileState> row = new List<PathfindingSystem.TileState>();
                for (int x = 0; x < boardWidth; x++)
                {
                    row.Add(PathfindingSystem.TileState.OPEN);
                }
                board.Add(row);
            }

            // Mark the spots occupied by walls as true
            foreach (var wall in Constants.walls)
            {
                int startX = (int)wall.x;
                int startY = (int)wall.y;
                int endX = (int)(wall.x + wall.width);
                int endY = (int)(wall.y + wall.height);

                for (int y = startY; y < endY; y++)
                {
                    for (int x = startX; x < endX; x++)
                    {
                        board[y][x] = PathfindingSystem.TileState.BLOCKED;
                    }
                }
            }

            return board;
        }

    }
}
