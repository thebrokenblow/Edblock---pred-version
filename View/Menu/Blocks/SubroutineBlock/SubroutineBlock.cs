using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Controls;

namespace Flowchart_Editor.Models
{
    [BlockName("SubroutineBlock")]
    public class SubroutineBlock : Block
    {
        public Border? borderSubroutineBlock = null;
        public Border? internalBorderSubroutineBlock = null;
        private readonly int defaultWidth = DefaultPropertyForBlock.width;
        private readonly int defaulHeight = DefaultPropertyForBlock.height;

        public SubroutineBlock(Canvas destination)
        {
            EditField = destination;
            blockWidthCoefficient = 1;
            blockHeightCoefficient = 1;
            initialText = "Подпрограмма";
        }

        override public UIElement GetUIElement()
        {
            if (FrameBlock == null)
            {
                FrameBlock = new Canvas();
                TextBoxOfBlock = new TextBox();
                TextBlockOfBlock = new TextBlock();
                
                borderSubroutineBlock = new Border();
                internalBorderSubroutineBlock = new Border();

                FrameBlock.Height = defaulHeight;
                FrameBlock.Width = defaultWidth;

                BrushConverter brushConverter = new();
                Brush backgroundColor = (Brush)brushConverter.ConvertFrom("#FFBA64C8");

                SetPropertyFrameBlock(defaultWidth, defaulHeight, backgroundColor);

                borderSubroutineBlock.BorderBrush = Brushes.Black;
                borderSubroutineBlock.Height = defaulHeight;
                borderSubroutineBlock.Width = defaultWidth;
                borderSubroutineBlock.BorderThickness = new Thickness(1);
                borderSubroutineBlock.CornerRadius = new CornerRadius(1);

                internalBorderSubroutineBlock.BorderBrush = Brushes.Black;
                internalBorderSubroutineBlock.Height = defaulHeight;
                internalBorderSubroutineBlock.Width = defaultWidth - 40;
                internalBorderSubroutineBlock.BorderThickness = new Thickness(1);
                internalBorderSubroutineBlock.CornerRadius = new CornerRadius(1);
                Canvas.SetTop(internalBorderSubroutineBlock, 0);
                Canvas.SetLeft(internalBorderSubroutineBlock, 20);

                //SetPropertyForTextBox(defaultWidth - 40, defaulHeight, initialText, 20);

                //SetPropertyForTextBlock(defaultWidth - 40, defaulHeight, 20);

                //SetPropertyPointConnect(firstPointToConnect, defaultWidth / 2 - 2, -2);
                //firstPointToConnect.MouseDown += ClickOnFirstConnectionPoint;

                //SetPropertyPointConnect(secondPointToConnect, -2, defaulHeight / 2 - 2);
                //secondPointToConnect.MouseDown += ClickOnSecondConnectionPoint;

                //SetPropertyPointConnect(thirdPointToConnect, defaultWidth / 2 - 2, defaulHeight - 3);
                //thirdPointToConnect.MouseDown += ClickOnThirdConnectionPoint;

                //SetPropertyPointConnect(fourthPointToConnect, defaultWidth - 4, defaulHeight / 2 - 2);
                //fourthPointToConnect.MouseDown += ClickOnFourthConnectionPoint;

                FrameBlock.Children.Add(borderSubroutineBlock);
                FrameBlock.Children.Add(internalBorderSubroutineBlock);
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
            if (FrameBlock != null && borderSubroutineBlock != null && internalBorderSubroutineBlock != null)
            {
                FrameBlock.Width = valueBlockWidth;
                //SetPropertyForTextBox(valueBlockWidth - 40, DefaultPropertyForBlock.height);
                //SetPropertyForTextBlock(valueBlockWidth - 40, DefaultPropertyForBlock.height, 20);
                borderSubroutineBlock.Width = valueBlockWidth;
                borderSubroutineBlock.Width = valueBlockWidth;
                internalBorderSubroutineBlock.Width = valueBlockWidth - 40;

                //Canvas.SetLeft(firstPointConnect, valueBlockWidth / 2 - 2);
                //Canvas.SetLeft(thirdPointConnect, valueBlockWidth / 2 - 2);
                //Canvas.SetLeft(fourthPointConnect, valueBlockWidth - 4);
            }
        }

        public override void SetHeight(int valueBlockHeight)
        {
            if (FrameBlock != null && borderSubroutineBlock != null && internalBorderSubroutineBlock != null)
            {
                FrameBlock.Height = valueBlockHeight;
                //SetPropertyForTextBox(DefaultPropertyForBlock.width - 40, DefaultPropertyForBlock.height);
                //SetPropertyForTextBlock(DefaultPropertyForBlock.width - 40, DefaultPropertyForBlock.height, 20);
                borderSubroutineBlock.Height = valueBlockHeight;
                internalBorderSubroutineBlock.Height = valueBlockHeight;

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