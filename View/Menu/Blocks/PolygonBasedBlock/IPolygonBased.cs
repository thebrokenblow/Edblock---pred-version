using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using Flowchart_Editor.Model;
using System.Windows.Controls;
using System.Collections.Generic;

namespace Flowchart_Editor.View.Menu.Blocks.PolygonBasedBlock
{
    public interface IPolygonBased
    {
        public void SetCoordinatesPoints(ControlSize polygonSize);

        public void SetPropertyPolyginBlock();

        protected static Polygon SetPointPolygon(List<Point> listPoints)
        {
            Polygon polygonBlock = new();
            PointCollection pointCollection = new();
            foreach (Point itemPoint in listPoints)
                pointCollection.Add(itemPoint);

            polygonBlock.Points = pointCollection;
            return polygonBlock;
        }

        protected static void SetFill(Polygon polygonBlock, Brush backgroundColor)
        {
            polygonBlock.Fill = backgroundColor;
        }

        protected static void AddPolygon(Canvas frameBlock, Polygon polygonBlock)
        {
            frameBlock.Children.Add(polygonBlock);
        }
    }
}