using System.Windows.Shapes;

namespace Flowchart_Editor.View.Menu
{
    public enum OrientationConnectionPoint
    {
        Vertical,
        Horizontal
    }

    public class ConnectionPoint
    {
        public Ellipse EllipseConnectionPoint { get; private set; }
        public OrientationConnectionPoint OrientationConnectionPoint { get; private set; }
        public ConnectionPoint(OrientationConnectionPoint orientationConnectionPoint)
        {
            EllipseConnectionPoint = new();
            OrientationConnectionPoint = orientationConnectionPoint;
        }
    }
}
