using Flowchart_Editor.Models;
using Flowchart_Editor.Models.Interface;
using System.Windows.Shapes;

namespace Flowchart_Editor
{
    public class ChangingLines
    {
        private readonly IBlockForMovements transferInformation;
        private readonly int numberOfOccurrencesInBlock;

        public ChangingLines(IBlockForMovements transferInformation, int numberOfOccurrencesInBlock)
        {
            this.transferInformation = transferInformation;
            this.numberOfOccurrencesInBlock = numberOfOccurrencesInBlock;
        }

        public void ChangeCoordinatesForFirstLine(Line[] lines, Block firstBlock, Block secondBlock, int numberOfOccurrencesInBlock = 0)
        {
            double СoordinateForFirstLineX1 = transferInformation.GetСoordinatesMainBlockAndFirstSenderMainBlockX();
            double СoordinateForFirstLineY1 = transferInformation.GetСoordinatesMainBlockAndFirstSenderMainBlockY();
            double СoordinateForFirstLineX2 = transferInformation.GetСoordinatesFirstAtionBlockAndFirstSenderBlockX();
            double СoordinateForFirstLineY2 = transferInformation.GetСoordinatesFirstAtionBlockAndFirstSenderBlockY();

            transferInformation.SetCoordinateForFirstLine(СoordinateForFirstLineX1, СoordinateForFirstLineY1, СoordinateForFirstLineX2, СoordinateForFirstLineY2, lines, firstBlock, secondBlock);
        }
        void ChangeCoordinatesForSecondLine(Line[] lines, Block firstBlock, Block secondBlock)
        {
            double СoordinateForSecondLineX1 = transferInformation.GetСoordinatesMainBlockAndSecondSenderMainBlockX();
            double СoordinateForSecondLineY1 = transferInformation.GetСoordinatesMainBlockAndSecondSenderMainBlockY();
            double СoordinateForSecondLineX2 = transferInformation.GetСoordinatesSecondBlockAndSecondSenderBlockX();
            double СoordinateForSecondLineY2 = transferInformation.GetСoordinatesSecondBlockAndSecondSenderBlockY();

            transferInformation.SetCoordinateForSecondLine(СoordinateForSecondLineX1, СoordinateForSecondLineY1, СoordinateForSecondLineX2, СoordinateForSecondLineY2, lines, firstBlock, secondBlock);
        }
        void ChangeCoordinatesForThirdLine(Line[] lines, Block firstBlock, Block secondBlock)
        {
            double СoordinateForThirdLineX1 = transferInformation.GetСoordinatesMainBlockAndThirdSenderMainBlockX();
            double СoordinateForThirdLineY1 = transferInformation.GetСoordinatesMainBlockAndThirdSenderMainBlockY();
            double СoordinateForThirdLineX2 = transferInformation.GetСoordinatesThirdBlockAndThirdSenderBlockX();
            double СoordinateForThirdLineY2 = transferInformation.GetСoordinatesThirdBlockAndThirdSenderBlockY();

            transferInformation.SetCoordinateForThirdLine(СoordinateForThirdLineX1, СoordinateForThirdLineY1, СoordinateForThirdLineX2, СoordinateForThirdLineY2, lines, firstBlock, secondBlock);
        }
        public void ChangeCoordinatesForFourthLine(Line[] lines, Block firstBlock, Block secondBlock)
        {
            double СoordinateForFourthLineX1 = transferInformation.GetСoordinatesMainBlockAndFourthSenderMainBlockX();
            double СoordinateForFourthLineY1 = transferInformation.GetСoordinatesMainBlockAndFourthSenderMainBlockY();
            double СoordinateForFourthLineX2 = transferInformation.GetСoordinatesFourthBlockAndFourthSenderBlockX();
            double СoordinateForFourthLineY2 = transferInformation.GetСoordinatesFourthBlockAndFourthSenderBlockY();

            transferInformation.SetCoordinateForFourthLine(СoordinateForFourthLineX1, СoordinateForFourthLineY1, СoordinateForFourthLineX2, СoordinateForFourthLineY2, lines, firstBlock, secondBlock);
        }
        public void ChooseWayToChangeCoordinatesForLine(Block firstBlock, Block secondBlock, Block thirdBlock, Block fourthBlock, Block fifthBlock, BlockForMovements blockForMovements)
        {
            switch (numberOfOccurrencesInBlock)
            {
                case 1:
                    ChangeCoordinatesForFirstLine(blockForMovements.firstLineConnectionBlock, firstBlock, secondBlock);
                    break;
                case 2:
                    ChangeCoordinatesForFirstLine(blockForMovements.firstLineConnectionBlock, firstBlock, secondBlock, numberOfOccurrencesInBlock);
                    ChangeCoordinatesForSecondLine(blockForMovements.secondLineConnectionBlock, firstBlock, thirdBlock);
                    break;
                case 3:
                    ChangeCoordinatesForFirstLine(blockForMovements.firstLineConnectionBlock, firstBlock, secondBlock);
                    ChangeCoordinatesForSecondLine(blockForMovements.secondLineConnectionBlock, secondBlock, thirdBlock);
                    ChangeCoordinatesForThirdLine(blockForMovements.thirdLineConnectionBlock, thirdBlock, fourthBlock);
                    break;
                case 4:
                    ChangeCoordinatesForFirstLine(blockForMovements.firstLineConnectionBlock, firstBlock, secondBlock);
                    ChangeCoordinatesForSecondLine(blockForMovements.secondLineConnectionBlock, secondBlock, thirdBlock);
                    ChangeCoordinatesForThirdLine(blockForMovements.thirdLineConnectionBlock, thirdBlock, fourthBlock);
                    ChangeCoordinatesForFourthLine(blockForMovements.fourthLineConnectionBlock, fourthBlock, fifthBlock);
                    break;
            }
        }
    }
}
