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

        protected static void SetPointPolygon(Polygon polygonBlock, List<Point> listPoints)
        {
            PointCollection pointCollection = new();
            foreach (Point itemPoint in listPoints)
                pointCollection.Add(itemPoint);

            polygonBlock.Points = pointCollection;
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