using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Controls;

namespace Flowchart_Editor.Models
{
    [BlockName("CycleWhileBeginBlock")]
    public class CycleWhileBeginBlock : Block
    {
        public Polygon? polygon;   
        private readonly int defaultWidth = DefaultPropertyForBlock.width;
        private readonly int defaulHeight = DefaultPropertyForBlock.height;

        public CycleWhileBeginBlock(Edblock mainWindow, int keyBlock)
        {
            MainWindow = mainWindow;
            keyOfBlock = keyBlock;
            blockWidthCoefficient = 1;
            blockHeightCoefficient = 1;
            initialText = "Цикл while начало";
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
                Brush backgroundColor = (Brush)brushConverter.ConvertFrom("#FFCCCCFF");

                polygon.Fill = backgroundColor;
                Point Point1 = new(0, defaulHeight);
                Point Point2 = new(0, 10);
                Point Point3 = new(10, 0);
                Point Point4 = new(defaultWidth - 10, 0);
                Point Point5 = new(defaultWidth, 10);
                Point Point6 = new(defaultWidth, defaulHeight);
                PointCollection myPointCollection1 = new();
                myPointCollection1.Add(Point1);
                myPointCollection1.Add(Point2);
                myPointCollection1.Add(Point3);
                myPointCollection1.Add(Point4);
                myPointCollection1.Add(Point5);
                myPointCollection1.Add(Point6);
                polygon.Points = myPointCollection1;

                SetPropertyForTextBox(defaultWidth - 20, defaulHeight, initialText, 10);

                SetPropertyForTextBlock(defaultWidth - 20, defaulHeight, 10);

                SetPropertyForFirstPointToConnect(defaultWidth / 2 - 2, -2);
                firstPointToConnect.MouseDown += ClickOnFirstConnectionPoint;

                SetPropertyForSecondPointToConnect(-2, defaulHeight / 2 - 2);
                secondPointToConnect.MouseDown += ClickOnSecondConnectionPoint;

                SetPropertyForThirdPointToConnect(defaultWidth / 2 - 2, defaulHeight - 3);
                thirdPointToConnect.MouseDown += ClickOnThirdConnectionPoint;

                SetPropertyForFourthPointToConnect(defaultWidth - 4, defaulHeight / 2 - 2);
                fourthPointToConnect.MouseDown += ClickOnFourthConnectionPoint;

                canvas.Children.Add(polygon);
                canvas.Children.Add(TextBox);
                canvas.Children.Add(firstPointToConnect);
                canvas.Children.Add(secondPointToConnect);
                canvas.Children.Add(thirdPointToConnect);
                canvas.Children.Add(fourthPointToConnect);
                
                canvas.MouseMove += MouseMoveBlockForMovements;
                canvas.MouseRightButtonDown += ClickRightButton;
            }
            return canvas;
        }

        protected override void SetСoordinatesComment(UIElement comment)
        {
            Canvas.SetTop(comment, DefaultPropertyForBlock.height / 2 + 1);
            Canvas.SetLeft(comment, DefaultPropertyForBlock.width);
        }

        public override void SetWidth(int valueBlockWidth)
        {
            if (polygon != null && canvas != null)
            {
                Point Point1 = new(0, DefaultPropertyForBlock.height);
                Point Point2 = new(0, 10);
                Point Point3 = new(10, 0);
                Point Point4 = new(valueBlockWidth - 10, 0);
                Point Point5 = new(valueBlockWidth, 10);
                Point Point6 = new(valueBlockWidth, DefaultPropertyForBlock.height);
                PointCollection myPointCollection = new();
                myPointCollection.Add(Point1);
                myPointCollection.Add(Point2);
                myPointCollection.Add(Point3);
                myPointCollection.Add(Point4);
                myPointCollection.Add(Point5);
                myPointCollection.Add(Point6);

                polygon.Points = myPointCollection;
                canvas.Width = valueBlockWidth;

                SetPropertyForTextBox(valueBlockWidth - 20, DefaultPropertyForBlock.height, valueForSetLeft: 10);
                SetPropertyForTextBlock(valueBlockWidth - 20, DefaultPropertyForBlock.height, valueForSetLeft: 10);

                Canvas.SetLeft(firstPointToConnect, valueBlockWidth / 2 - 2);
                Canvas.SetLeft(thirdPointToConnect, valueBlockWidth / 2 - 2);
                Canvas.SetLeft(fourthPointToConnect, valueBlockWidth - 4);
            }
        }

        public override void SetHeight(int valueBlockHeight)
        {
            if (polygon != null && canvas != null)
            {
                Point Point1 = new(0, valueBlockHeight);
                Point Point2 = new(0, 10);
                Point Point3 = new(10, 0);
                Point Point4 = new(DefaultPropertyForBlock.width - 10, 0);
                Point Point5 = new(DefaultPropertyForBlock.width, 10);
                Point Point6 = new(DefaultPropertyForBlock.width, valueBlockHeight);
                PointCollection myPointCollection = new();
                myPointCollection.Add(Point1);
                myPointCollection.Add(Point2);
                myPointCollection.Add(Point3);
                myPointCollection.Add(Point4);
                myPointCollection.Add(Point5);
                myPointCollection.Add(Point6);

                polygon.Points = myPointCollection;
                canvas.Width = DefaultPropertyForBlock.width;

                SetPropertyForTextBox(DefaultPropertyForBlock.width - 20, valueBlockHeight, valueForSetLeft: 10);
                SetPropertyForTextBlock(DefaultPropertyForBlock.width - 20, valueBlockHeight, valueForSetLeft: 10);

                Canvas.SetTop(secondPointToConnect, valueBlockHeight / 2 - 2);
                Canvas.SetTop(thirdPointToConnect, valueBlockHeight - 3);
                Canvas.SetTop(fourthPointToConnect, valueBlockHeight / 2 - 2);
            }
        }

        public override double GetWidthCoefficient() => blockWidthCoefficient;

        public override double GetHeightCoefficient() => blockHeightCoefficient;

        public override void SetLeftBlockForConditionCaseSecondOption(UIElement uIElementBlock, double coordinateLeft) =>
            Canvas.SetLeft(uIElementBlock, coordinateLeft - 1);

        public override void SetTopBlockForConditionCaseSecondOption(UIElement uIElementBlock, double coordinateTop) =>
            Canvas.SetTop(uIElementBlock, coordinateTop);

        public override void SetLeftBlockForConditionCaseFirstOption(UIElement uIElementBlock, double coordinateLeft) =>
             Canvas.SetLeft(uIElementBlock, coordinateLeft - 1);

        public override void SetTopBlockForConditionCaseFirstOption(UIElement uIElementBlock, double coordinateTop) =>
            Canvas.SetTop(uIElementBlock, coordinateTop - DefaultPropertyForBlock.height / 2 + 0.5);
    }
}
