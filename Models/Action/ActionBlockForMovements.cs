using System.Windows.Shapes;
using System.Windows.Controls;

namespace Flowchart_Editor.Models
{
    public class ActionBlockForMovements
    {
        public int numberOfOccurrencesInBlock;

        public Line firstLineConnectionBlock;
        public Line secondLineConnectionBlock;
        public Line thirdLineConnectionBlock;
        public Line fourthLineConnectionBlock;

        public ActionBlock mainActionBlock;
        public ActionBlock firstActionBlock;
        public ActionBlock secondActionBlock;
        public ActionBlock thirdActionBlock;
        public ActionBlock fourthActionBlock;

        public object firstSenderMainActionBlock;
        public object secondSenderMainActionBlock;
        public object thirdSenderMainActionBlock;
        public object fourthSenderMainActionBlock;

        public object senderFirstdActionBlock;
        public object senderSecondActionBlock;
        public object senderThirdActionBlock;
        public object senderFourthActionBlock;


        public object transferInformationActionBlock;

        public ActionBlockForMovements(object sender)
        {
            transferInformationActionBlock = sender;
        }

        public double GetСoordinatesFirstAtionBlockAndFirstSenderActionBlockX() => Canvas.GetLeft((Ellipse)firstSenderMainActionBlock) + Canvas.GetLeft(mainActionBlock.GetCanvas()) + 3;
        public double GetСoordinatesFirstAtionBlockAndFirstSenderActionBlockY() => Canvas.GetTop((Ellipse)firstSenderMainActionBlock) + Canvas.GetTop(mainActionBlock.GetCanvas()) + 3;
        public double GetСoordinatesSecondAtionBlockAndFirstSenderActionBlockX() => Canvas.GetLeft((Ellipse)senderFirstdActionBlock) + Canvas.GetLeft(firstActionBlock.GetCanvas()) + 3;
        public double GetСoordinatesSecondAtionBlockAndFirstSenderActionBlockY() => Canvas.GetTop((Ellipse)senderFirstdActionBlock) + Canvas.GetTop(firstActionBlock.GetCanvas()) + 3;
        public double GetСoordinatesThirdAtionBlockAndFirstSenderActionBlockX() => Canvas.GetLeft((Ellipse)senderSecondActionBlock) + Canvas.GetLeft(secondActionBlock.GetCanvas()) + 3;
        public double GetСoordinatesThirdAtionBlockAndFirstSenderActionBlockY() => Canvas.GetTop((Ellipse)senderSecondActionBlock) + Canvas.GetTop(secondActionBlock.GetCanvas()) + 3;
        public double GetСoordinatesSecondAtionBlockAndSecondSenderActionBlockX() => Canvas.GetLeft((Ellipse)secondSenderMainActionBlock) + Canvas.GetLeft(mainActionBlock.GetCanvas()) + 3;
        public double GetСoordinatesSecondAtionBlockAndSecondSenderActionBlockY() => Canvas.GetTop((Ellipse)secondSenderMainActionBlock) + Canvas.GetTop(mainActionBlock.GetCanvas()) + 3;
        public double GetСoordinatesFourthAtionBlockAndThirdSenderActionBlockX() => Canvas.GetLeft((Ellipse)thirdSenderMainActionBlock) + Canvas.GetLeft(mainActionBlock.GetCanvas()) + 3;
        public double GetСoordinatesFourthAtionBlockAndThirdSenderActionBlockY() => Canvas.GetTop((Ellipse)thirdSenderMainActionBlock) + Canvas.GetTop(mainActionBlock.GetCanvas()) + 3;
        public double GetСoordinatesFifthAtionBlockAndFourthSenderActionBlockX() => Canvas.GetLeft((Ellipse)senderThirdActionBlock) + Canvas.GetLeft(thirdActionBlock.GetCanvas()) + 3;
        public double GetСoordinatesFifthAtionBlockAndFourthSenderActionBlockY() => Canvas.GetTop((Ellipse)senderThirdActionBlock) + Canvas.GetTop(thirdActionBlock.GetCanvas()) + 3;
        public double GetСoordinatesSixthAtionBlockAndFifthSenderActionBlockX() => Canvas.GetLeft((Ellipse)fourthSenderMainActionBlock) + Canvas.GetLeft(mainActionBlock.GetCanvas()) + 3;
        public double GetСoordinatesSixthAtionBlockAndFifthSenderActionBlockY() => Canvas.GetTop((Ellipse)fourthSenderMainActionBlock) + Canvas.GetTop(mainActionBlock.GetCanvas()) + 3;
        public double GetСoordinatesSeventhAtionBlockAndSixthSenderActionBlockX() => Canvas.GetLeft((Ellipse)senderFourthActionBlock) + Canvas.GetLeft(fourthActionBlock.GetCanvas()) + 3;
        public double GetСoordinatesSeventhAtionBlockAndSixthSenderActionBlockY() => Canvas.GetTop((Ellipse)senderFourthActionBlock) + Canvas.GetTop(fourthActionBlock.GetCanvas()) + 3;

    }
}