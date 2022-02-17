namespace Flowchart_Editor.Models
{
    public class ActionBlockForMovements
    {
        public object? transferInformationActionBlock = null;
        public ActionBlockForMovements(object sender)
        {
            transferInformationActionBlock = sender;
        }
    }
}