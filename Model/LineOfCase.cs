namespace Flowchart_Editor.Model
{
    public class LineOfCase
    {
        //public double topCoordinates { get; private set; }
        //public double leftCoordinates { get; private set; }
        public LineModel lineModel { get; private set; }
        public CaseModel? caseModel { get; private set; }
        public BlockModel? blockModel { get; private set; }
        public LineOfCase(/*double topCoordinates, double leftCoordinates*/ LineModel lineModel, CaseModel? caseModel, BlockModel? blockModel)
        {
            //this.topCoordinates = topCoordinates;
            //this.leftCoordinates = leftCoordinates;
            this.lineModel = lineModel;
            this.caseModel = caseModel;
            this.blockModel = blockModel;
        }
    }
}
