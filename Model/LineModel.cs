namespace Flowchart_Editor.Model
{
    public class LineModel
    {
        public double x1 { get; set; }
        public double y1 { get; set; }
        public double x2 { get; set; }
        public double y2 { get; set; }
        public LineModel(double x1, double y1, double x2, double y2)
        {
            this.x1 = x1; 
            this.y1 = y1;
            this.x2 = x2; 
            this.y2 = y2;
        }
    }
}
