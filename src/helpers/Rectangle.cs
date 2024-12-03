namespace WpfApp1.src.helpers
{
    class Rectangle
    {
        float x, y, width, height;

        public Rectangle(float x, float y, float width, float height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        public bool Intersects(Rectangle other)
        {
            return !(x + width <= other.x ||
                     other.x + other.width <= x ||
                     y + height <= other.y ||
                     other.y + other.height <= y);
        }

        public bool Intersects(float x, float y, float width float height)
        {
            return Intersects(new Rectangle(x, y, width, height));
        }
    }
}
