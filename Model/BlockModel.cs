namespace Flowchart_Editor.Model
{
    public class BlockModel
    {
        public string nameOfBlock { get; set; }
        public int height { get; set; }
        public int width { get; set; }
        public string textOfBlock { get; set; }
        public double topCoordinates { get; set; }
        public double leftCoordinates { get; set; }
        public BlockModel(string nameOfBlock, int height, int width, string textOfBlock, double topCoordinates, double leftCoordinates) 
        {
            this.nameOfBlock = nameOfBlock;
            this.height = height;
            this.width = width;
            this.textOfBlock = textOfBlock;
            this.topCoordinates = topCoordinates;
            this.leftCoordinates = leftCoordinates;
        }
    }
}
