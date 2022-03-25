using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Flowchart_Editor.Models
{
    public class ActionBlockForMovements
    {
        public Line lineConnectionBlock;
        public object firstSenderConnectionPoints;
        public object secondSenderConnectionPoints;
        public bool flagOfFirstBlockToConnect;
        public ActionBlock? firstActionBlock = null;
        public ActionBlock? secondActionBlock = null;


        public object? transferInformationActionBlock = null;
        public ActionBlockForMovements(object sender)
        {
            transferInformationActionBlock = sender;
        }
        public double GetСoordinatesFirstAtionBlockX() => Canvas.GetLeft((Ellipse)firstSenderConnectionPoints) + Canvas.GetLeft(firstActionBlock.canvasOfActionBlock) + 3;
        public double GetСoordinatesFirstAtionBlockY() => Canvas.GetTop((Ellipse)firstSenderConnectionPoints) + Canvas.GetTop(firstActionBlock.canvasOfActionBlock) + 3;
        public double GetСoordinatesSecondAtionBlockX() => Canvas.GetLeft((Ellipse)secondSenderConnectionPoints) + Canvas.GetLeft(secondActionBlock.canvasOfActionBlock) + 3;
        public double GetСoordinatesSecondAtionBlockY() => Canvas.GetTop((Ellipse)secondSenderConnectionPoints) + Canvas.GetTop(secondActionBlock.canvasOfActionBlock) + 3;
    }
}