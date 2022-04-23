using Flowchart_Editor.Models.Interface;

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

        public void ChangeCoordinatesForFirstLine()
        {
            double СoordinateForFirstLineX1 = transferInformation.GetСoordinatesMainBlockAndFirstSenderMainBlockX();
            double СoordinateForFirstLineY1 = transferInformation.GetСoordinatesMainBlockAndFirstSenderMainBlockY();
            double СoordinateForFirstLineX2 = transferInformation.GetСoordinatesFirstAtionBlockAndFirstSenderBlockX();
            double СoordinateForFirstLineY2 = transferInformation.GetСoordinatesFirstAtionBlockAndFirstSenderBlockY();

            transferInformation.SetCoordinateForFirstLine(СoordinateForFirstLineX1, СoordinateForFirstLineY1, СoordinateForFirstLineX2, СoordinateForFirstLineY2);
        }
        void ChangeCoordinatesForSecondLine()
        {
            double СoordinateForSecondLineX1 = transferInformation.GetСoordinatesMainBlockAndSecondSenderMainBlockX();
            double СoordinateForSecondLineY1 = transferInformation.GetСoordinatesMainBlockAndSecondSenderMainBlockY();
            double СoordinateForSecondLineX2 = transferInformation.GetСoordinatesSecondBlockAndSecondSenderBlockX();
            double СoordinateForSecondLineY2 = transferInformation.GetСoordinatesSecondBlockAndSecondSenderBlockY();

            transferInformation.SetCoordinateForSecondLine(СoordinateForSecondLineX1, СoordinateForSecondLineY1, СoordinateForSecondLineX2, СoordinateForSecondLineY2);
        }
        void ChangeCoordinatesForThirdLine()
        {
            double СoordinateForThirdLineX1 = transferInformation.GetСoordinatesMainBlockAndThirdSenderMainBlockX();
            double СoordinateForThirdLineY1 = transferInformation.GetСoordinatesMainBlockAndThirdSenderMainBlockY();
            double СoordinateForThirdLineX2 = transferInformation.GetСoordinatesThirdBlockAndThirdSenderBlockX();
            double СoordinateForThirdLineY2 = transferInformation.GetСoordinatesThirdBlockAndThirdSenderBlockY();

            transferInformation.SetCoordinateForThirdLine(СoordinateForThirdLineX1, СoordinateForThirdLineY1, СoordinateForThirdLineX2, СoordinateForThirdLineY2);
        }
        public void ChangeCoordinatesForFourthLine()
        {
            double СoordinateForFourthLineX1 = transferInformation.GetСoordinatesMainBlockAndFourthSenderMainBlockX();
            double СoordinateForFourthLineY1 = transferInformation.GetСoordinatesMainBlockAndFourthSenderMainBlockY();
            double СoordinateForFourthLineX2 = transferInformation.GetСoordinatesFourthBlockAndFourthSenderBlockX();
            double СoordinateForFourthLineY2 = transferInformation.GetСoordinatesFourthBlockAndFourthSenderBlockY();

            transferInformation.SetCoordinateForFourthLine(СoordinateForFourthLineX1, СoordinateForFourthLineY1, СoordinateForFourthLineX2, СoordinateForFourthLineY2);
        }
        public void ChooseWayToChangeCoordinatesForLine()
        {
            switch (numberOfOccurrencesInBlock)
            {
                case 1:
                    ChangeCoordinatesForFirstLine();
                    break;
                case 2:
                    ChangeCoordinatesForFirstLine();
                    ChangeCoordinatesForSecondLine();
                    break;
                case 3:
                    ChangeCoordinatesForFirstLine();
                    ChangeCoordinatesForSecondLine();
                    ChangeCoordinatesForThirdLine();
                    break;
                case 4:
                    ChangeCoordinatesForFirstLine();
                    ChangeCoordinatesForSecondLine();
                    ChangeCoordinatesForThirdLine();
                    ChangeCoordinatesForFourthLine();
                    break;
            }
        }
    }
}
