using System.Numerics;
using System.Windows.Controls;
using System.Windows.Shapes;
using WpfApp1;

public abstract class Entity
{
    public Shape SpriteShape = new Rectangle();
    public Vector2 position = Vector2.Zero ;

    public abstract void update(double deltaTime);

    public virtual void draw() {
        Canvas.SetLeft(SpriteShape, position.X);
        Canvas.SetTop(SpriteShape, position.Y);
    }

    // Remove self from the list of entities and remove it from the canvas
    public virtual void destroy()
    {
        MainWindow.entities.Remove(this);
        MainWindow.canvas.Children.Remove(SpriteShape);
    }
}