using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Windows.Documents;
using System.Windows.Media;
using WpfApp1.src.entities.impl.ghosts.impl.helpers;

namespace WpfApp1.src.entities.impl.ghosts
{
    class Blinky : Ghost
    {
        private List<PathfindingSystem.ResultPoint> path = null;
        private DateTime lastMoveTime = DateTime.MinValue;
        private Vector2 generatedPathForTarget = Vector2.Zero;

        public Blinky() : base() {
            SpriteShape.Fill = Brushes.Red;
            position = MainWindow.ToScreenPos(new Vector2(13, 13));
        }

        public override void update(double deltaTime)
        {
            Pacman pacman = MainWindow.GetEntityByType<Pacman>();
            Vector2 pacmanMapPos = MainWindow.ToMapPos(pacman.position);

            if (path ==  null || (pacmanMapPos.X != generatedPathForTarget.X || pacmanMapPos.Y != generatedPathForTarget.Y))
            {

                var bs = PathfindingSystem.GetBoardState();

                // really simple solution to make the inky & blinky ai seem different
                Vector2 inkyMapPos = MainWindow.ToMapPos(MainWindow.GetEntityByType<Inky>().position);

                bs[(int)inkyMapPos.X][(int)inkyMapPos.Y] = PathfindingSystem.TileState.BLOCKED;

                path = PathfindingSystem.TryGetPath(
                        bs,
                        MainWindow.ToMapPos(position),
                        MainWindow.ToMapPos(pacman.position)
                    );

                generatedPathForTarget = pacmanMapPos;
            }

            if ( path != null && (DateTime.Now - lastMoveTime).TotalMilliseconds > 250 ) {
                if (path.Count == 0)
                {
                    path = null;
                    return;
                }

                var move = path[0];
                path.Remove(move);

                Vector2 mapPos = MainWindow.ToMapPos(position);

                switch (move)
                {
                    case PathfindingSystem.ResultPoint.UP: mapPos.Y -= 1; break;
                    case PathfindingSystem.ResultPoint.DOWN: mapPos.Y += 1; break;
                    case PathfindingSystem.ResultPoint.LEFT: mapPos.X -= 1; break;
                    case PathfindingSystem.ResultPoint.RIGHT: mapPos.X += 1; break;
                    default:
                        Debug.Write("How did we get here??");
                        break;
                }

                position = MainWindow.ToScreenPos(mapPos);
                lastMoveTime = DateTime.Now;
            }
        }
    }
}
