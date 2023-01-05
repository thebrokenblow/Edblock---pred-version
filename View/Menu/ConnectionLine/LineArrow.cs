using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Flowchart_Editor.View.Menu.ConnectionLine
{
    public class LineArrow
    {
        public Polygon Arrow { get; private set; }
        public const int widthArrow = 8;
        public const int heightArrow = 7;
        private readonly PointCollection pointCollectionArrow;

        public LineArrow()
        {
            Arrow = new()
            {
                Fill = Brushes.Black
            };

            pointCollectionArrow = new();
        }

        public void DrawBottomArrow()
        {
            Point leftPointX = new(-widthArrow / 2, 0);
            Point pointY = new(0, heightArrow);
            Point rightPointX = new(widthArrow / 2, 0);

            AddPointArrow(leftPointX, pointY, rightPointX);
        }

        public void DrawUpperArrow()
        {
            Point leftPointX = new(-widthArrow / 2, heightArrow);
            Point pointY = new(0, 0);
            Point rightPointX = new(widthArrow / 2, heightArrow);

            AddPointArrow(leftPointX, pointY, rightPointX);
        }

        public void DrawLeftArrow()
        {
            Point topPointY = new(0, widthArrow / 2);
            Point pointX = new(heightArrow, 0);
            Point bottomPointX = new(0, -widthArrow / 2);

            AddPointArrow(topPointY, pointX, bottomPointX);
        }

        public void DrawRigthArrow()
        {
            Point topPointY = new(0, widthArrow / 2);
            Point pointX = new(-heightArrow, 0);
            Point bottomPointX = new(0, -widthArrow / 2);

            AddPointArrow(topPointY, pointX, bottomPointX);
        }

        private void AddPointArrow(params Point[] points)
        {
            pointCollectionArrow.Clear();

            foreach (Point itemPoint in points)
            {
                pointCollectionArrow.Add(itemPoint);
            }

            Arrow.Points = pointCollectionArrow;
        }
    }
}
