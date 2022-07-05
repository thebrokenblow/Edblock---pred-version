using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Flowchart_Editor.Models
{
    [BlockName("ConditionBlock")]
    public class ConditionBlock : Block
    {
        protected Polygon? polygon;
        private readonly int defaultWidth = DefaultPropertyForBlock.width;
        private readonly int defaulHeight = DefaultPropertyForBlock.height;

        public ConditionBlock(Edblock mainWindow, int keyBlock)
        {
            MainWindow = mainWindow;
            keyOfBlock = keyBlock;
            blockWidthCoefficient = 1;
            blockHeightCoefficient = 1;
            initialText = "Условие";
        }

        override public UIElement GetUIElement()
        {
            if (canvas == null)
            {
                canvas = new Canvas();
                polygon = new Polygon();
                TextBox = new TextBox();
                TextBlock = new TextBlock();
                firstPointToConnect = new Ellipse();
                secondPointToConnect = new Ellipse();
                thirdPointToConnect = new Ellipse();
                fourthPointToConnect = new Ellipse();
               
                canvas.Width = defaultWidth;
                canvas.Height = defaulHeight;

                BrushConverter brushConverter = new();
                Brush backgroundColor = (Brush)brushConverter.ConvertFrom("#FF60B2D3");

                polygon.Fill = backgroundColor;
                Point Point1 = new(0, defaulHeight / 2);
                Point Point2 = new(defaultWidth / 2, defaulHeight);
                Point Point3 = new(defaultWidth, defaulHeight / 2);
                Point Point4 = new(defaultWidth / 2, 0);
                Point Point5 = new(0, defaulHeight / 2);

                PointCollection myPointCollection = new();
                myPointCollection.Add(Point1);
                myPointCollection.Add(Point2);
                myPointCollection.Add(Point3);
                myPointCollection.Add(Point4);
                myPointCollection.Add(Point5);
                polygon.Points = myPointCollection;

                double valueForSetLeftTextBoxAndTextBlock = defaultWidth / 2 - defaultWidth / 4;
                double valueForSetTopTextBoxAndTextBlock = defaulHeight / 4;

                SetPropertyForTextBox(defaultWidth / 2, defaulHeight / 2, initialText, valueForSetLeftTextBoxAndTextBlock, valueForSetTopTextBoxAndTextBlock);

                SetPropertyForTextBlock(defaultWidth / 2, defaulHeight / 2, valueForSetLeftTextBoxAndTextBlock, valueForSetTopTextBoxAndTextBlock);

                SetPropertyPointConnect(firstPointToConnect, defaultWidth / 2 - 3, -2);
                firstPointToConnect.MouseDown += ClickOnFirstConnectionPoint;

                SetPropertyPointConnect(secondPointToConnect, 0, defaulHeight / 2 - 3);
                secondPointToConnect.MouseDown += ClickOnSecondConnectionPoint;

                SetPropertyPointConnect(thirdPointToConnect, defaultWidth / 2 - 3, defaulHeight - 3);
                thirdPointToConnect.MouseDown += ClickOnThirdConnectionPoint;

                SetPropertyPointConnect(fourthPointToConnect, defaultWidth - 6, defaulHeight / 2 - 3);
                fourthPointToConnect.MouseDown += ClickOnFourthConnectionPoint;

                canvas.Children.Add(polygon);
                canvas.Children.Add(firstPointToConnect);
                canvas.Children.Add(secondPointToConnect);
                canvas.Children.Add(thirdPointToConnect);
                canvas.Children.Add(fourthPointToConnect);
                canvas.Children.Add(TextBox);
                canvas.MouseMove += MouseMoveBlockForMovements;
                canvas.MouseRightButtonDown += ClickRightButton;
            }
            return canvas;
        }

        protected override void SetСoordinatesComment(UIElement comment)
        {
            Canvas.SetTop(comment, DefaultPropertyForBlock.height / 2);
            Canvas.SetLeft(comment, DefaultPropertyForBlock.width);
        }

        public override void SetWidth(int valueBlockWidth)
        {
            if (polygon != null)
            {
                SetSizeForPolygon(DefaultPropertyForBlock.height, valueBlockWidth);
                double valueForSetLeftTextBoxAndTextBlock = valueBlockWidth / 2 - valueBlockWidth / 4;
                double valueForSetTopTextBoxAndTextBlock = DefaultPropertyForBlock.height / 4;

                SetPropertyForTextBox(valueBlockWidth / 2, DefaultPropertyForBlock.height / 2, valueForSetLeft: valueForSetLeftTextBoxAndTextBlock, valueForSetTop: valueForSetTopTextBoxAndTextBlock);
                SetPropertyForTextBlock(valueBlockWidth / 2, DefaultPropertyForBlock.height / 2, valueForSetLeftTextBoxAndTextBlock, valueForSetTopTextBoxAndTextBlock);

                Canvas.SetLeft(firstPointToConnect, valueBlockWidth / 2 - 3);
                Canvas.SetLeft(secondPointToConnect, 0);
                Canvas.SetLeft(thirdPointToConnect, valueBlockWidth / 2 - 3);
                Canvas.SetLeft(fourthPointToConnect, valueBlockWidth - 6);
            }
        }

        protected void SetSizeForPolygon(int valueBlockHeight, int valueBlockWidth)
        {
            Point Point1 = new(0, valueBlockHeight / 2);
            Point Point2 = new(valueBlockWidth / 2, valueBlockHeight);
            Point Point3 = new(valueBlockWidth, valueBlockHeight / 2);
            Point Point4 = new(valueBlockWidth / 2, 0);
            Point Point5 = new(0, valueBlockHeight / 2);
            PointCollection myPointCollection = new();
            myPointCollection.Add(Point1);
            myPointCollection.Add(Point2);
            myPointCollection.Add(Point3);
            myPointCollection.Add(Point4);
            myPointCollection.Add(Point5);
            if (polygon != null)
                polygon.Points = myPointCollection;
        }
        public override void SetHeight(int valueBlockHeight)
        {
            if (polygon != null)
            {
                SetSizeForPolygon(valueBlockHeight, DefaultPropertyForBlock.width);
                double valueForSetLeftTextBoxAndTextBlock = DefaultPropertyForBlock.width / 2 - DefaultPropertyForBlock.width / 4;
                double valueForSetTopTextBoxAndTextBlock = valueBlockHeight / 4;

                SetPropertyForTextBox(DefaultPropertyForBlock.width / 2, valueBlockHeight / 2, valueForSetLeft: valueForSetLeftTextBoxAndTextBlock, valueForSetTop: valueForSetTopTextBoxAndTextBlock);
                SetPropertyForTextBlock(DefaultPropertyForBlock.width / 2, valueBlockHeight / 2, valueForSetLeftTextBoxAndTextBlock, valueForSetTopTextBoxAndTextBlock);

                Canvas.SetTop(firstPointToConnect, -2);
                Canvas.SetTop(secondPointToConnect, valueBlockHeight / 2 - 3);
                Canvas.SetTop(thirdPointToConnect, valueBlockHeight - 3);
                Canvas.SetTop(fourthPointToConnect, valueBlockHeight / 2 - 3);
            }
        }

        public override double GetWidthCoefficient() => blockWidthCoefficient;

        public override double GetHeightCoefficient() => blockHeightCoefficient;

        public override void SetLeftBlockForConditionCaseSecondOption(UIElement uIElementBlock, double coordinateLeft) => 
            Canvas.SetLeft(uIElementBlock, coordinateLeft);

        public override void SetTopBlockForConditionCaseSecondOption(UIElement uIElementBlock, double coordinateTop) =>
            Canvas.SetTop(uIElementBlock, coordinateTop);

        public override void SetLeftBlockForConditionCaseFirstOption(UIElement uIElementBlock, double coordinateLeft) =>
             Canvas.SetLeft(uIElementBlock, coordinateLeft - 1);

        public override void SetTopBlockForConditionCaseFirstOption(UIElement uIElementBlock, double coordinateTop) =>
            Canvas.SetTop(uIElementBlock, coordinateTop - DefaultPropertyForBlock.height / 2);
    }
}