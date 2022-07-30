using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Controls;

namespace Flowchart_Editor.Models
{
    [BlockName("CycleForBlock")]
    public class CycleForBlock : Block
    {
        private Polygon? polygon;
        private readonly int defaultWidth = DefaultPropertyForBlock.width;
        private readonly int defaulHeight = DefaultPropertyForBlock.height;

        public CycleForBlock(Canvas destination)
        {
            EditField = destination;
            blockWidthCoefficient = 1;
            blockHeightCoefficient = 1;
            initialText = "Цикл for";
        }

        override public UIElement GetUIElement()
        {
            if (FrameBlock == null)
            {
                FrameBlock = new Canvas();
                polygon = new Polygon();
                TextBoxOfBlock = new TextBox();
                TextBlockOfBlock = new TextBlock(); 
                

                FrameBlock.Height = defaulHeight;
                FrameBlock.Width = defaultWidth;

                BrushConverter brushConverter = new();
                Brush backgroundColor = (Brush)brushConverter.ConvertFrom("#FFFFC618");

                polygon.Fill = backgroundColor;
                Point Point1 = new(10, 0);
                Point Point2 = new(0, 10);
                Point Point3 = new(0, defaulHeight - 10);
                Point Point4 = new(10, defaulHeight);
                Point Point5 = new(defaultWidth - 10, defaulHeight);
                Point Point6 = new(defaultWidth, defaulHeight - 10);
                Point Point7 = new(defaultWidth, 10);
                Point Point8 = new(defaultWidth - 10, 0);
                PointCollection myPointCollection = new();
                myPointCollection.Add(Point1);
                myPointCollection.Add(Point2);
                myPointCollection.Add(Point3);
                myPointCollection.Add(Point4);
                myPointCollection.Add(Point5);
                myPointCollection.Add(Point6);
                myPointCollection.Add(Point7);
                myPointCollection.Add(Point8);
                polygon.Points = myPointCollection;

                //SetPropertyForTextBox(defaultWidth - 20, defaulHeight, initialText, 10);

                //SetPropertyForTextBlock(defaultWidth - 20, defaulHeight, 10);

                //SetPropertyPointConnect(firstPointToConnect, defaultWidth / 2 - 2, -2);
                //firstPointToConnect.MouseDown += ClickOnFirstConnectionPoint;

                //SetPropertyPointConnect(secondPointToConnect, -2, defaulHeight / 2 - 2);
                //secondPointToConnect.MouseDown += ClickOnSecondConnectionPoint;

                //SetPropertyPointConnect(thirdPointToConnect, defaultWidth / 2 - 2, defaulHeight - 3);
                //thirdPointToConnect.MouseDown += ClickOnThirdConnectionPoint;

                //SetPropertyPointConnect(fourthPointToConnect, defaultWidth - 4, defaulHeight / 2 - 2);
                //fourthPointToConnect.MouseDown += ClickOnFourthConnectionPoint;

                FrameBlock.Children.Add(polygon);
                FrameBlock.Children.Add(TextBoxOfBlock);
                
                FrameBlock.MouseMove += MouseMoveBlockForMovements;
                
            }
            return FrameBlock;
        }

        protected override void SetСoordinatesComment(UIElement comment)
        {
            Canvas.SetTop(comment, DefaultPropertyForBlock.height / 2 + 1);
            Canvas.SetLeft(comment, DefaultPropertyForBlock.width);
        }

        public override void SetWidth(int valueBlockWidth)
        {
            if (polygon != null && FrameBlock != null)
            {
                Point Point1 = new(10, 0);
                Point Point2 = new(0, 10);
                Point Point3 = new(0, DefaultPropertyForBlock.height - 10);
                Point Point4 = new(10, DefaultPropertyForBlock.height);
                Point Point5 = new(valueBlockWidth - 10, DefaultPropertyForBlock.height);
                Point Point6 = new(valueBlockWidth, DefaultPropertyForBlock.height - 10);
                Point Point7 = new(valueBlockWidth, 10);
                Point Point8 = new(valueBlockWidth - 10, 0);
                PointCollection myPointCollection = new();
                myPointCollection.Add(Point1);
                myPointCollection.Add(Point2);
                myPointCollection.Add(Point3);
                myPointCollection.Add(Point4);
                myPointCollection.Add(Point5);
                myPointCollection.Add(Point6);
                myPointCollection.Add(Point7);
                myPointCollection.Add(Point8);

                polygon.Points = myPointCollection;
                FrameBlock.Width = valueBlockWidth;

                SetPropertyForTextBox(valueBlockWidth - 20, DefaultPropertyForBlock.height, valueSetLeft: 10);
                SetPropertyForTextBlock(valueBlockWidth - 20, DefaultPropertyForBlock.height, valueSetLeft: 10);

                //Canvas.SetLeft(firstPointConnect, valueBlockWidth / 2 - 2);
                //Canvas.SetLeft(thirdPointConnect, valueBlockWidth / 2 - 2);
                //Canvas.SetLeft(fourthPointConnect, valueBlockWidth - 4);
            }
        }

        public override void SetHeight(int valueBlockHeight)
        {
            if (polygon != null && FrameBlock != null)
            {
                Point Point1 = new(10, 0);
                Point Point2 = new(0, 10);
                Point Point3 = new(0, valueBlockHeight - 10);
                Point Point4 = new(10, valueBlockHeight);
                Point Point5 = new(DefaultPropertyForBlock.width - 10, valueBlockHeight);
                Point Point6 = new(DefaultPropertyForBlock.width, valueBlockHeight - 10);
                Point Point7 = new(DefaultPropertyForBlock.width, 10);
                Point Point8 = new(DefaultPropertyForBlock.width - 10, 0);
                PointCollection myPointCollection = new();
                myPointCollection.Add(Point1);
                myPointCollection.Add(Point2);
                myPointCollection.Add(Point3);
                myPointCollection.Add(Point4);
                myPointCollection.Add(Point5);
                myPointCollection.Add(Point6);
                myPointCollection.Add(Point7);
                myPointCollection.Add(Point8);

                polygon.Points = myPointCollection;
                FrameBlock.Width = DefaultPropertyForBlock.width;

                SetPropertyForTextBox(DefaultPropertyForBlock.width - 20, valueBlockHeight, valueSetLeft: 10);
                SetPropertyForTextBlock(DefaultPropertyForBlock.width - 20, DefaultPropertyForBlock.height, valueSetLeft: 10);

                //Canvas.SetTop(secondPointConnect, valueBlockHeight / 2 - 2);
                //Canvas.SetTop(thirdPointConnect, valueBlockHeight - 3);
                //Canvas.SetTop(fourthPointConnect, valueBlockHeight / 2 - 2);
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