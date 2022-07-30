namespace Flowchart_Editor.Models.Interface
{
    public interface IChangingLines
    {
        public void ChangeCoordinatesForFirstLine();
        public void ChangeCoordinatesForSecondLine();
        public void ChangeCoordinatesForThirdLine();
        public void ChangeCoordinatesForFourthLine();
        public void ChooseWayToChangeCoordinatesForLine();
    }
}
