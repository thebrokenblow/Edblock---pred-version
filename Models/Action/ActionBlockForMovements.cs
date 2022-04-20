using System.Windows.Shapes;
using System.Windows.Controls;
using System;

namespace Flowchart_Editor.Models
{
    public class ActionBlockForMovements
    {
        private ActionBlock mainActionBlock;
        private ActionBlock firstActionBlock;
        private ActionBlock secondActionBlock;
        private ActionBlock thirdActionBlock;
        private ActionBlock fourthActionBlock;

        private Line firstLineConnectionBlock;
        private Line secondLineConnectionBlock;
        private Line thirdLineConnectionBlock;
        private Line fourthLineConnectionBlock;

        private object firstSenderMainActionBlock;
        private object secondSenderMainActionBlock;
        private object thirdSenderMainActionBlock;
        private object fourthSenderMainActionBlock;

        private object senderFirstActionBlock;
        private object senderSecondActionBlock;
        private object senderThirdActionBlock;
        private object senderFourthActionBlock;

        private object transferInformationActionBlock;

        private int numberOfOccurrencesInBlock;

        public ActionBlockForMovements(object sender, ActionBlock mainActionBlock, ActionBlock firstActionBlock, ActionBlock secondActionBlock, 
            ActionBlock thirdActionBlock, ActionBlock fourthActionBlock, object firstSenderMainActionBlock, object secondSenderMainActionBlock, 
            object thirdSenderMainActionBlock, object fourthSenderMainActionBlock, object senderFirstActionBlock, object senderSecondActionBlock, 
            object senderThirdActionBlock, object senderFourthActionBlock, Line firstLineConnectionBlock, Line secondLineConnectionBlock, 
            Line thirdLineConnectionBlock, Line fourthLineConnectionBlock, int numberOfOccurrencesInBlock)
        {
            transferInformationActionBlock = sender;
            this.mainActionBlock = mainActionBlock;

            this.firstActionBlock = firstActionBlock;
            this.secondActionBlock = secondActionBlock;
            this.thirdActionBlock = thirdActionBlock;
            this.fourthActionBlock = fourthActionBlock;

            this.firstSenderMainActionBlock = firstSenderMainActionBlock;
            this.secondSenderMainActionBlock = secondSenderMainActionBlock;
            this.thirdSenderMainActionBlock = thirdSenderMainActionBlock;
            this.fourthSenderMainActionBlock = fourthSenderMainActionBlock;

            this.senderFirstActionBlock = senderFirstActionBlock;
            this.senderSecondActionBlock = senderSecondActionBlock;
            this.senderThirdActionBlock = senderThirdActionBlock;
            this.senderFourthActionBlock = senderFourthActionBlock;

            this.firstLineConnectionBlock = firstLineConnectionBlock;
            this.secondLineConnectionBlock = secondLineConnectionBlock;
            this.thirdLineConnectionBlock = thirdLineConnectionBlock;
            this.fourthLineConnectionBlock = fourthLineConnectionBlock;

            this.numberOfOccurrencesInBlock = numberOfOccurrencesInBlock;
        }

        public object GetTransferInformationActionBlock() => transferInformationActionBlock;
        public int GetNumberOfOccurrencesInBlock() => numberOfOccurrencesInBlock;
        public double GetСoordinatesFirstAtionBlockAndFirstSenderActionBlockX() => Canvas.GetLeft((Ellipse)firstSenderMainActionBlock) + Canvas.GetLeft(mainActionBlock.GetCanvas()) + 3;
        public double GetСoordinatesFirstAtionBlockAndFirstSenderActionBlockY() => Canvas.GetTop((Ellipse)firstSenderMainActionBlock) + Canvas.GetTop(mainActionBlock.GetCanvas()) + 3;
        public double GetСoordinatesSecondAtionBlockAndFirstSenderActionBlockX() => Canvas.GetLeft((Ellipse)senderFirstActionBlock) + Canvas.GetLeft(firstActionBlock.GetCanvas()) + 3;
        public double GetСoordinatesSecondAtionBlockAndFirstSenderActionBlockY() => Canvas.GetTop((Ellipse)senderFirstActionBlock) + Canvas.GetTop(firstActionBlock.GetCanvas()) + 3;
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

        public void SetCoordinateForFirstLine(double сoordinateForFirstLineX1, double сoordinateForFirstLineY1, double сoordinateForFirstLineX2, double сoordinateForFirstLineY2)
        {
            firstLineConnectionBlock.X1 = сoordinateForFirstLineX1;
            firstLineConnectionBlock.Y1 = сoordinateForFirstLineY1;
            firstLineConnectionBlock.X2 = сoordinateForFirstLineX2;
            firstLineConnectionBlock.Y2 = сoordinateForFirstLineY2;
        }
        public void SetCoordinateForSecondLine(double coordinateForSecondLineX1, double coordinateForSecondLineY1, double coordinateForSecondLineX2, double coordinateForSecondLineY2)
        {
            secondLineConnectionBlock.X1 = coordinateForSecondLineX1;
            secondLineConnectionBlock.Y1 = coordinateForSecondLineY1;
            secondLineConnectionBlock.X2 = coordinateForSecondLineX2;
            secondLineConnectionBlock.Y2 = coordinateForSecondLineY2;
        }

        public void SetCoordinateForThirdLine(double сoordinateForThirdLineX1, double сoordinateForThirdLineY1, double сoordinateForThirdLineX2, double сoordinateForThirdLineY2)
        {
            thirdLineConnectionBlock.X1 = сoordinateForThirdLineX1;
            thirdLineConnectionBlock.Y1 = сoordinateForThirdLineY1;
            thirdLineConnectionBlock.X2 = сoordinateForThirdLineX2;
            thirdLineConnectionBlock.Y2 = сoordinateForThirdLineY2;
        }

        public void SetCoordinateForFourthLine(double сoordinateForFourthLineX1, double сoordinateForFourthLineY1, double сoordinateForFourthLineX2, double сoordinateForFourthLineY2)
        {
            fourthLineConnectionBlock.X1 = сoordinateForFourthLineX1;
            fourthLineConnectionBlock.Y1 = сoordinateForFourthLineY1;
            fourthLineConnectionBlock.X2 = сoordinateForFourthLineX2;
            fourthLineConnectionBlock.Y2 = сoordinateForFourthLineY2;
        }
    }
}