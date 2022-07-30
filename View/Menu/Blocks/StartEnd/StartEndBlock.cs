using System.Windows.Shapes;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Flowchart_Editor.Models
{
    [BlockName("StartEndBlock")]
    public class StartEndBlock : Block
    {
        private Rectangle? rectangle;
        private readonly int defaultWidth = DefaultPropertyForBlock.width;
        private readonly int defaulHeight = DefaultPropertyForBlock.height / 2;
        private const int radiusOfRectangleStartEndBlock = 20;

        public StartEndBlock(Canvas destination)
        {
            EditField = destination;
            blockWidthCoefficient = 1;
            blockHeightCoefficient = 0.5;
            initialText = "Начало / Конец";
        }
        override public UIElement GetUIElement()
        {
            if (FrameBlock == null)
            {
                FrameBlock = new Canvas();
                rectangle = new Rectangle();
                TextBoxOfBlock = new TextBox();
                TextBlockOfBlock = new TextBlock();
                //ExtensionConnectionPoint FirstPointToConnect = new(new Ellipse(), "firstPointToConnect");
                //ExtensionConnectionPoint SecondPointToConnect = new(new Ellipse(), "secondPointToConnect");
                //ExtensionConnectionPoint ThirdPointToConnect = new(new Ellipse(), "thirdPointToConnect");
                //ExtensionConnectionPoint FourthPointToConnect = new(new Ellipse(), "fourthPointToConnect");

                FrameBlock.Width = defaultWidth;
                FrameBlock.Height = DefaultPropertyForBlock.height;

                BrushConverter brushConverter = new();
                Brush backgroundColor = (Brush)brushConverter.ConvertFrom("#FFF25252");

                rectangle.Fill = backgroundColor;
                rectangle.RadiusX = radiusOfRectangleStartEndBlock;
                rectangle.RadiusY = radiusOfRectangleStartEndBlock;
                rectangle.Width = defaultWidth;
                rectangle.Height = defaulHeight;

                //SetPropertyForTextBox(defaultWidth - 20, defaulHeight - 3, initialText, 10, 3);
                
                //SetPropertyForTextBlock(defaultWidth - 20, defaulHeight - 3, 10, 3);

                //SetPropertyPointConnect(firstPointToConnect, defaultWidth / 2 - 2.5, -2);
                //firstPointToConnect.MouseDown += ClickOnFirstConnectionPoint;

                //SetPropertyPointConnect(secondPointToConnect, -2, defaulHeight / 2 - 2.5);
                //secondPointToConnect.MouseDown += ClickOnSecondConnectionPoint;

                //SetPropertyPointConnect(thirdPointToConnect, defaultWidth / 2 - 2.5, defaulHeight - 2.5);
                //thirdPointToConnect.MouseDown += ClickOnThirdConnectionPoint;

                //SetPropertyPointConnect(fourthPointToConnect, defaultWidth - 2.5, defaulHeight / 2 - 2.5);
                //fourthPointToConnect.MouseDown += ClickOnFourthConnectionPoint;

                FrameBlock.Children.Add(rectangle);
                FrameBlock.Children.Add(TextBoxOfBlock);
                
                FrameBlock.MouseMove += MouseMoveBlockForMovements;
            }
            return FrameBlock;
        }

        protected override void SetСoordinatesComment(UIElement comment)
        {
            Canvas.SetTop(comment, DefaultPropertyForBlock.height / 4 + 0.5);
            Canvas.SetLeft(comment, DefaultPropertyForBlock.width);
        }

        public override void SetWidth(int valueBlockWidth)
        {
            if (FrameBlock != null && rectangle != null)
            {
                FrameBlock.Width = valueBlockWidth;
                rectangle.Width = valueBlockWidth;
                //SetPropertyForTextBox(valueBlockWidth - 20, DefaultPropertyForBlock.height / 2 - 3, valueForSetLeft: 10, valueForSetTop: 3);
                //SetPropertyForTextBlock(valueBlockWidth - 20, DefaultPropertyForBlock.height / 2 - 3, 10, 3);

                //Canvas.SetLeft(firstPointConnect, valueBlockWidth / 2 - 2.5);
                //Canvas.SetLeft(thirdPointConnect, valueBlockWidth / 2 - 2.5);
                //Canvas.SetLeft(fourthPointConnect, valueBlockWidth - 2.5);
            }
        }

        public override void SetHeight(int valueBlockHeight)
        {
            if (FrameBlock != null && rectangle != null)
            {
                FrameBlock.Height = valueBlockHeight / 2;
                rectangle.Height = valueBlockHeight / 2;
                SetPropertyForTextBox(DefaultPropertyForBlock.width - 20, valueBlockHeight / 2 - 3);
                SetPropertyForTextBlock(DefaultPropertyForBlock.width - 20, valueBlockHeight / 2 - 3);
                //Canvas.SetTop(secondPointConnect, valueBlockHeight / 4 - 2.5);
                //Canvas.SetTop(thirdPointConnect, valueBlockHeight / 2 - 2.5);
                //Canvas.SetTop(fourthPointConnect, valueBlockHeight / 4 - 2.5);
            }
        }
        public override double GetWidthCoefficient() => blockWidthCoefficient;

        public override double GetHeightCoefficient() => blockHeightCoefficient;

        public override void SetLeftBlockForConditionCaseSecondOption(UIElement uIElementBlock, double coordinateLeft) =>
            Canvas.SetLeft(uIElementBlock, coordinateLeft - 0.5);

        public override void SetTopBlockForConditionCaseSecondOption(UIElement uIElementBlock, double coordinateTop) =>
            Canvas.SetTop(uIElementBlock, coordinateTop);

        public override void SetLeftBlockForConditionCaseFirstOption(UIElement uIElementBlock, double coordinateLeft) =>
              Canvas.SetLeft(uIElementBlock, coordinateLeft - 1);

        public override void SetTopBlockForConditionCaseFirstOption(UIElement uIElementBlock, double coordinateTop) =>
            Canvas.SetTop(uIElementBlock, coordinateTop - DefaultPropertyForBlock.height / 4);
    }
}