namespace Flowchart_Editor.View.ConnectionPoint
{
    public class ConnectionPoint
    {
        public string? NameConnectionPoint { get; private set; }
        public bool FlagEntry { get; set; } = false; 
        public ConnectionPoint(string nameConnectionPoint)
        { 
            NameConnectionPoint = nameConnectionPoint;
        }
    }
}