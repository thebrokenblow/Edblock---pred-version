namespace Flowchart_Editor.Models.Interface
{
    public interface IBlockForMovements
    {
        public double GetСoordinatesMainBlockAndFirstSenderMainBlockX();
        public double GetСoordinatesMainBlockAndFirstSenderMainBlockY();
        public double GetСoordinatesFirstAtionBlockAndFirstSenderBlockX();
        public double GetСoordinatesFirstAtionBlockAndFirstSenderBlockY();
        public double GetСoordinatesSecondBlockAndSecondSenderBlockX();
        public double GetСoordinatesSecondBlockAndSecondSenderBlockY();
        public double GetСoordinatesMainBlockAndSecondSenderMainBlockX();
        public double GetСoordinatesMainBlockAndSecondSenderMainBlockY();
        public double GetСoordinatesMainBlockAndThirdSenderMainBlockX();
        public double GetСoordinatesMainBlockAndThirdSenderMainBlockY();
        public double GetСoordinatesThirdBlockAndThirdSenderBlockX();
        public double GetСoordinatesThirdBlockAndThirdSenderBlockY();
        public double GetСoordinatesMainBlockAndFourthSenderMainBlockX();
        public double GetСoordinatesMainBlockAndFourthSenderMainBlockY();
        public double GetСoordinatesFourthBlockAndFourthSenderBlockX();
        public double GetСoordinatesFourthBlockAndFourthSenderBlockY();
        public void SetCoordinateForFirstLine(double сoordinateForFirstLineX1, double сoordinateForFirstLineY1, double сoordinateForFirstLineX2, double сoordinateForFirstLineY2);
        public void SetCoordinateForSecondLine(double coordinateForSecondLineX1, double coordinateForSecondLineY1, double coordinateForSecondLineX2, double coordinateForSecondLineY2);
        public void SetCoordinateForThirdLine(double сoordinateForThirdLineX1, double сoordinateForThirdLineY1, double сoordinateForThirdLineX2, double сoordinateForThirdLineY2);
        public void SetCoordinateForFourthLine(double сoordinateForFourthLineX1, double сoordinateForFourthLineY1, double сoordinateForFourthLineX2, double сoordinateForFourthLineY2);
    }
}
