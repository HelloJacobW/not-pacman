using System.Numerics;
using System.Windows.Controls;
using System.Windows.Shapes;
using WpfApp1;

public abstract class Entity
{
    public Shape SpriteShape = new Rectangle();
    protected Vector2 position = Vector2.Zero;

    public abstract void update(double deltaTime);

    public void draw() {
        Canvas.SetLeft(SpriteShape, position.X);
        Canvas.SetTop(SpriteShape, position.Y);
    }

    // Remove self from the list of entities and remove it from the canvas
    public void destroy()
    {
        MainWindow.entities.Remove(this);
        MainWindow.canvas.Children.Remove(SpriteShape);
    }
}