using Flowchart_Editor.Models;

namespace Flowchart_Editor
{
    public class ChangingLines
    {
        private ActionBlockForMovements transferInformation;
        private int numberOfOccurrencesInBlock;

        public ChangingLines(ActionBlockForMovements transferInformation, int numberOfOccurrencesInBlock)
        {
            this.transferInformation = transferInformation;
            this.numberOfOccurrencesInBlock = numberOfOccurrencesInBlock;
        }

        private void ChangeCoordinatesForFirstLine()
        {
            double СoordinateForFirstLineX1 = transferInformation.GetСoordinatesFirstAtionBlockAndFirstSenderActionBlockX();
            double СoordinateForFirstLineY1 = transferInformation.GetСoordinatesFirstAtionBlockAndFirstSenderActionBlockY();
            double СoordinateForFirstLineX2 = transferInformation.GetСoordinatesSecondAtionBlockAndFirstSenderActionBlockX();
            double СoordinateForFirstLineY2 = transferInformation.GetСoordinatesSecondAtionBlockAndFirstSenderActionBlockY();

            transferInformation.SetCoordinateForFirstLine(СoordinateForFirstLineX1, СoordinateForFirstLineY1, СoordinateForFirstLineX2, СoordinateForFirstLineY2);
        }
        private void ChangeCoordinatesForSecondLine()
        {
            double СoordinateForSecondLineX1 = transferInformation.GetСoordinatesSecondAtionBlockAndSecondSenderActionBlockX();
            double СoordinateForSecondLineY1 = transferInformation.GetСoordinatesSecondAtionBlockAndSecondSenderActionBlockY();
            double СoordinateForSecondLineX2 = transferInformation.GetСoordinatesThirdAtionBlockAndFirstSenderActionBlockX();
            double СoordinateForSecondLineY2 = transferInformation.GetСoordinatesThirdAtionBlockAndFirstSenderActionBlockY();

            transferInformation.SetCoordinateForSecondLine(СoordinateForSecondLineX1, СoordinateForSecondLineY1, СoordinateForSecondLineX2, СoordinateForSecondLineY2);
        }
        private void ChangeCoordinatesForThirdLine()
        {
            double СoordinateForThirdLineX1 = transferInformation.GetСoordinatesFourthAtionBlockAndThirdSenderActionBlockX();
            double СoordinateForThirdLineY1 = transferInformation.GetСoordinatesFourthAtionBlockAndThirdSenderActionBlockY();
            double СoordinateForThirdLineX2 = transferInformation.GetСoordinatesFifthAtionBlockAndFourthSenderActionBlockX();
            double СoordinateForThirdLineY2 = transferInformation.GetСoordinatesFifthAtionBlockAndFourthSenderActionBlockY();

            transferInformation.SetCoordinateForThirdLine(СoordinateForThirdLineX1, СoordinateForThirdLineY1, СoordinateForThirdLineX2, СoordinateForThirdLineY2);
        }
        private void ChangeCoordinatesForFourthLine()
        {
            double СoordinateForFourthLineX1 = transferInformation.GetСoordinatesSixthAtionBlockAndFifthSenderActionBlockX();
            double СoordinateForFourthLineY1 = transferInformation.GetСoordinatesSixthAtionBlockAndFifthSenderActionBlockY();
            double СoordinateForFourthLineX2 = transferInformation.GetСoordinatesSeventhAtionBlockAndSixthSenderActionBlockX();
            double СoordinateForFourthLineY2 = transferInformation.GetСoordinatesSeventhAtionBlockAndSixthSenderActionBlockY();

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
