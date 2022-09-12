using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Collections.Generic;

namespace Flowchart_Editor.View.Menu.Blocks.PolygonBasedBlock
{
    public class PolygonBased
    {
        public Polygon FramePolygon { get; set; }
        public List<Point> PointsPolygon { get; set; }

        public PolygonBased()
        {
            FramePolygon = new();
            PointsPolygon = new();
        }

        public void SetPointPolygon()
        {
            PointCollection pointCollection = new();
            foreach (Point itemPoint in PointsPolygon)
                pointCollection.Add(itemPoint);

            FramePolygon.Points = pointCollection;
        }
    }
}