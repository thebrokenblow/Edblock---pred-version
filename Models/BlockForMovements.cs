using System.Windows.Shapes;
using System.Windows.Controls;
using Flowchart_Editor.Models.Interface;

namespace Flowchart_Editor.Models
{
    public class BlockForMovements : IBlockForMovements
    {
        private readonly Block? mainBlock;
        private readonly Block? firstBlock;
        private readonly Block? secondBlock;
        private readonly Block? thirdBlock;
        private readonly Block? fourthBlock;

        private readonly Line? firstLineConnectionBlock;
        private readonly Line? secondLineConnectionBlock;
        private readonly Line? thirdLineConnectionBlock;
        private readonly Line? fourthLineConnectionBlock;

        private readonly object? firstSenderMainBlock;
        private readonly object? secondSenderMainBlock;
        private readonly object? thirdSenderMainBlock;
        private readonly object? fourthSenderMainBlock;

        private readonly object? firstSenderBlock;
        private readonly object? secondSenderBlock;
        private readonly object? thirdSenderBlock;
        private readonly object? fourthSenderBlock;

        private readonly object transferInformationActionBlock;

        private readonly int numberOfOccurrencesInBlock;

        public BlockForMovements(object sender, Block? mainBlock, Block? firstBlock, Block? secondBlock,
            Block? thirdBlock, Block? fourthBlock, object? firstSenderMainBlock, object? secondSenderMainBlock, 
            object? thirdSenderMainBlock, object? fourthSenderMainBlock, object? firstSenderBlock, object? secondSenderBlock, 
            object? thirdSenderBlock, object? fourthSenderBlock, Line? firstLineConnectionBlock, Line? secondLineConnectionBlock, 
            Line? thirdLineConnectionBlock, Line? fourthLineConnectionBlock, int numberOfOccurrencesInBlock)
        {
            transferInformationActionBlock = sender;
            this.mainBlock = mainBlock;

            this.firstBlock = firstBlock;
            this.secondBlock = secondBlock;
            this.thirdBlock = thirdBlock;
            this.fourthBlock = fourthBlock;

            this.firstSenderMainBlock = firstSenderMainBlock;
            this.secondSenderMainBlock = secondSenderMainBlock;
            this.thirdSenderMainBlock = thirdSenderMainBlock;
            this.fourthSenderMainBlock = fourthSenderMainBlock;

            this.firstSenderBlock = firstSenderBlock;
            this.secondSenderBlock = secondSenderBlock;
            this.thirdSenderBlock = thirdSenderBlock;
            this.fourthSenderBlock = fourthSenderBlock;

            this.firstLineConnectionBlock = firstLineConnectionBlock;
            this.secondLineConnectionBlock = secondLineConnectionBlock;
            this.thirdLineConnectionBlock = thirdLineConnectionBlock;
            this.fourthLineConnectionBlock = fourthLineConnectionBlock;

            this.numberOfOccurrencesInBlock = numberOfOccurrencesInBlock;
        }

        public object GetTransferInformationActionBlock() => transferInformationActionBlock;
        public int GetNumberOfOccurrencesInBlock() => numberOfOccurrencesInBlock;
        public double GetСoordinatesMainBlockAndFirstSenderMainBlockX() => mainBlock != null && firstSenderMainBlock != null ? Canvas.GetLeft((Ellipse)firstSenderMainBlock) + Canvas.GetLeft(mainBlock.GetCanvas()) + 3 : 0;
        public double GetСoordinatesMainBlockAndFirstSenderMainBlockY() => mainBlock != null && firstSenderMainBlock != null ? Canvas.GetTop((Ellipse)firstSenderMainBlock) + Canvas.GetTop(mainBlock.GetCanvas()) + 3 : 0;
        public double GetСoordinatesFirstAtionBlockAndFirstSenderBlockX() => firstBlock != null && firstSenderBlock != null ? Canvas.GetLeft((Ellipse)firstSenderBlock) + Canvas.GetLeft(firstBlock.GetCanvas()) + 3 : 0;
        public double GetСoordinatesFirstAtionBlockAndFirstSenderBlockY() => firstBlock != null && firstSenderBlock != null ? Canvas.GetTop((Ellipse)firstSenderBlock) + Canvas.GetTop(firstBlock.GetCanvas()) + 3 : 0;
        public double GetСoordinatesSecondBlockAndSecondSenderBlockX() => secondBlock != null && secondSenderBlock != null ? Canvas.GetLeft((Ellipse)secondSenderBlock) + Canvas.GetLeft(secondBlock.GetCanvas()) + 3 : 0;
        public double GetСoordinatesSecondBlockAndSecondSenderBlockY() => secondBlock != null && secondSenderBlock != null ? Canvas.GetTop((Ellipse)secondSenderBlock) + Canvas.GetTop(secondBlock.GetCanvas()) + 3 : 0;
        public double GetСoordinatesMainBlockAndSecondSenderMainBlockX() => mainBlock != null && secondSenderMainBlock != null ? Canvas.GetLeft((Ellipse)secondSenderMainBlock) + Canvas.GetLeft(mainBlock.GetCanvas()) + 3 : 0;
        public double GetСoordinatesMainBlockAndSecondSenderMainBlockY() => mainBlock != null && secondSenderMainBlock != null ? Canvas.GetTop((Ellipse)secondSenderMainBlock) + Canvas.GetTop(mainBlock.GetCanvas()) + 3 : 0;
        public double GetСoordinatesMainBlockAndThirdSenderMainBlockX() => mainBlock != null && thirdSenderMainBlock != null ? Canvas.GetLeft((Ellipse)thirdSenderMainBlock) + Canvas.GetLeft(mainBlock.GetCanvas()) + 3 : 0;
        public double GetСoordinatesMainBlockAndThirdSenderMainBlockY() => mainBlock != null && thirdSenderMainBlock != null ? Canvas.GetTop((Ellipse)thirdSenderMainBlock) + Canvas.GetTop(mainBlock.GetCanvas()) + 3 : 0;
        public double GetСoordinatesThirdBlockAndThirdSenderBlockX() => thirdBlock != null && thirdSenderBlock != null ? Canvas.GetLeft((Ellipse)thirdSenderBlock) + Canvas.GetLeft(thirdBlock.GetCanvas()) + 3 : 0;
        public double GetСoordinatesThirdBlockAndThirdSenderBlockY() => thirdBlock != null && thirdSenderBlock  != null ? Canvas.GetTop((Ellipse)thirdSenderBlock) + Canvas.GetTop(thirdBlock.GetCanvas()) + 3 : 0;
        public double GetСoordinatesMainBlockAndFourthSenderMainBlockX() => mainBlock != null && fourthSenderMainBlock != null ? Canvas.GetLeft((Ellipse)fourthSenderMainBlock) + Canvas.GetLeft(mainBlock.GetCanvas()) + 3 : 0;
        public double GetСoordinatesMainBlockAndFourthSenderMainBlockY() => mainBlock != null && fourthSenderMainBlock != null ? Canvas.GetTop((Ellipse)fourthSenderMainBlock) + Canvas.GetTop(mainBlock.GetCanvas()) + 3 : 0;
        public double GetСoordinatesFourthBlockAndFourthSenderBlockX() => fourthBlock != null && fourthSenderBlock != null ? Canvas.GetLeft((Ellipse)fourthSenderBlock) + Canvas.GetLeft(fourthBlock.GetCanvas()) + 3 : 0;
        public double GetСoordinatesFourthBlockAndFourthSenderBlockY() => fourthBlock != null && fourthSenderBlock != null ? Canvas.GetTop((Ellipse)fourthSenderBlock) + Canvas.GetTop(fourthBlock.GetCanvas()) + 3 : 0;

        public void SetCoordinateForFirstLine(double сoordinateForFirstLineX1, double сoordinateForFirstLineY1, double сoordinateForFirstLineX2, double сoordinateForFirstLineY2)
        {
            if (firstLineConnectionBlock != null)
            {
                firstLineConnectionBlock.X1 = сoordinateForFirstLineX1;
                firstLineConnectionBlock.Y1 = сoordinateForFirstLineY1;
                firstLineConnectionBlock.X2 = сoordinateForFirstLineX2;
                firstLineConnectionBlock.Y2 = сoordinateForFirstLineY2;
            }
        }
        public void SetCoordinateForSecondLine(double coordinateForSecondLineX1, double coordinateForSecondLineY1, double coordinateForSecondLineX2, double coordinateForSecondLineY2)
        {
            if (secondLineConnectionBlock != null)
            {
                secondLineConnectionBlock.X1 = coordinateForSecondLineX1;
                secondLineConnectionBlock.Y1 = coordinateForSecondLineY1;
                secondLineConnectionBlock.X2 = coordinateForSecondLineX2;
                secondLineConnectionBlock.Y2 = coordinateForSecondLineY2;
            }
        }

        public void SetCoordinateForThirdLine(double сoordinateForThirdLineX1, double сoordinateForThirdLineY1, double сoordinateForThirdLineX2, double сoordinateForThirdLineY2)
        {
            if (thirdLineConnectionBlock != null)
            {
                thirdLineConnectionBlock.X1 = сoordinateForThirdLineX1;
                thirdLineConnectionBlock.Y1 = сoordinateForThirdLineY1;
                thirdLineConnectionBlock.X2 = сoordinateForThirdLineX2;
                thirdLineConnectionBlock.Y2 = сoordinateForThirdLineY2;
            }
        }

        public void SetCoordinateForFourthLine(double сoordinateForFourthLineX1, double сoordinateForFourthLineY1, double сoordinateForFourthLineX2, double сoordinateForFourthLineY2)
        {
            if (fourthLineConnectionBlock != null)
            {
                fourthLineConnectionBlock.X1 = сoordinateForFourthLineX1;
                fourthLineConnectionBlock.Y1 = сoordinateForFourthLineY1;
                fourthLineConnectionBlock.X2 = сoordinateForFourthLineX2;
                fourthLineConnectionBlock.Y2 = сoordinateForFourthLineY2;
            }
        }
    }
}