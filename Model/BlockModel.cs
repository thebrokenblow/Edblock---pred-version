using Flowchart_Editor.Models;

namespace Flowchart_Editor.Model
{
    public class BlockModel
    {
        public string nameOfBlock { get; private set; }
        public int height { get; private set; }
        public int width { get; private set; }
        public string textOfBlock { get; private set; }
        public double topCoordinates { get; private set; }
        public double leftCoordinates { get; private set; }
        public bool flagPresenceСomment { get; private set; }
        public BlockModel(string nameOfBlock, int height, int width, string textOfBlock, double topCoordinates, double leftCoordinates, bool flagPresenceСomment) 
        {
            this.nameOfBlock = nameOfBlock;
            this.height = height;
            this.width = width;
            this.textOfBlock = textOfBlock;
            this.topCoordinates = topCoordinates;
            this.leftCoordinates = leftCoordinates;
            this.flagPresenceСomment = flagPresenceСomment;
        }
    }
}
