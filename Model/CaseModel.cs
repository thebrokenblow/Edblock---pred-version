using System.Collections.Generic;

namespace Flowchart_Editor.Model
{
    public class CaseModel : BlockModel
    {
        public int countOfLine { get; private set; }
        public List<LineOfCase>? listLineOfCase { get; private set; }
        public List<string> listTextOfLine { get; private set; }
        public CaseModel(string nameOfBlock, int height, int width, string textOfBlock, double topCoordinates, double leftCoordinates, 
            bool flagPresenceСomment, string textOfComment, int countOfLine, List<LineOfCase>? listLineOfCase, List<string> listTextOfLine) 
            : base (nameOfBlock, height, width, textOfBlock, topCoordinates, leftCoordinates, flagPresenceСomment, textOfComment)
        {
            this.countOfLine = countOfLine;
            this.listLineOfCase = listLineOfCase;
            this.listTextOfLine = listTextOfLine;
        }
    }
}
