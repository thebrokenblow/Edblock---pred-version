using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;

namespace Flowchart_Editor.Models
{
    [BlockName("ActionBlock")]
    public class ActionBlock : Block
    {
        private readonly int defaultWidth = DefaultPropertyForBlock.width;
        private readonly int defaulHeight = DefaultPropertyForBlock.height;
        const int offsetConnectionPoint = 2;

        public ActionBlock(Canvas destination)
        {
            Destination = destination;
            blockWidthCoefficient = 1;
            blockHeightCoefficient = 1;
            initialText = "Действие";
        }

        override public UIElement GetUIElement()
        {
            if (Canvas == null)
            {
                BrushConverter brushConverter = new();
                Brush backgroundColor = (Brush)brushConverter.ConvertFrom("#FF52C0AA");

                SetPropertyForCanvas(defaultWidth, defaulHeight, backgroundColor);

                SetPropertyForTextBox(defaultWidth, defaulHeight, initialText);

                SetPropertyForTextBlock(defaultWidth, defaulHeight);

                InitializingConnectionPoints();

                SetPropertyPointConnect(firstPointToConnect, defaultWidth / 2 - offsetConnectionPoint, -offsetConnectionPoint);
                
                SetPropertyPointConnect(secondPointToConnect, -offsetConnectionPoint, defaulHeight / 2 - offsetConnectionPoint);

                SetPropertyPointConnect(thirdPointToConnect, defaultWidth / 2 - offsetConnectionPoint, defaulHeight - offsetConnectionPoint);

                SetPropertyPointConnect(fourthPointToConnect, defaultWidth - offsetConnectionPoint * 2, defaulHeight / 2 - offsetConnectionPoint);

                AddTextFields();

                AddConnectionPoints();
            }
            return Canvas;
        }

        public override void SetWidth(int valueBlockWidth)
        {
            if (Canvas != null && TextBoxOfBlock != null && TextBlockOfBlock != null)
            {
                Canvas.Width = valueBlockWidth;
                TextBoxOfBlock.Width = valueBlockWidth;
                TextBlockOfBlock.Width = valueBlockWidth;
                Canvas.SetLeft(firstPointToConnect, valueBlockWidth / 2 - offsetConnectionPoint);
                Canvas.SetLeft(thirdPointToConnect, valueBlockWidth / 2 - offsetConnectionPoint);
                Canvas.SetLeft(fourthPointToConnect, valueBlockWidth - offsetConnectionPoint * 2);
            }
        }

        public override void SetHeight(int valueBlockHeight)
        {
            if (Canvas != null && TextBoxOfBlock != null && TextBlockOfBlock != null)
            {
                Canvas.Height = valueBlockHeight;
                TextBoxOfBlock.Height = valueBlockHeight;
                TextBlockOfBlock.Height = valueBlockHeight;
                Canvas.SetTop(secondPointToConnect, valueBlockHeight / 2 - offsetConnectionPoint);
                Canvas.SetTop(thirdPointToConnect, valueBlockHeight - offsetConnectionPoint);
                Canvas.SetTop(fourthPointToConnect, valueBlockHeight / 2 - offsetConnectionPoint);
            }
        }

        protected override void SetСoordinatesComment(UIElement comment)
        {
            Canvas.SetTop(comment, DefaultPropertyForBlock.height / 2 + 1);
            Canvas.SetLeft(comment, DefaultPropertyForBlock.width);
        }

        public override double GetWidthCoefficient() => 
            blockWidthCoefficient;

        public override double GetHeightCoefficient() => 
            blockHeightCoefficient;

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