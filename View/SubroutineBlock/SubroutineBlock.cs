using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Controls;
using Flowchart_Editor.Models.Comment;

namespace Flowchart_Editor.Models
{
    [BlockName("SubroutineBlock")]
    public class SubroutineBlock : Block
    {
        public Border? borderSubroutineBlock = null;
        public Border? internalBorderSubroutineBlock = null;
        private readonly int defaultWidth = DefaultPropertyForBlock.width;
        private readonly int defaulHeight = DefaultPropertyForBlock.height;

        public SubroutineBlock(MainWindow mainWindow, int keyBlock)
        {
            MainWindow = mainWindow;
            keyOfBlock = keyBlock;
            blockWidthCoefficient = 1;
            blockHeightCoefficient = 1;
            initialText = "Подпрограмма";
        }

        override public UIElement GetUIElement()
        {
            if (canvas == null)
            {
                canvas = new Canvas();
                TextBox = new TextBox();
                TextBlock = new TextBlock();
                firstPointToConnect = new Ellipse();
                secondPointToConnect = new Ellipse();
                thirdPointToConnect = new Ellipse();
                fourthPointToConnect = new Ellipse();
                borderSubroutineBlock = new Border();
                internalBorderSubroutineBlock = new Border();

                canvas.Height = defaulHeight;
                canvas.Width = defaultWidth;

                BrushConverter brushConverter = new();
                Brush backgroundColor = (Brush)brushConverter.ConvertFrom("#FFBA64C8");

                SetPropertyForCanvas(defaultWidth, defaulHeight, backgroundColor);

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

                SetPropertyForTextBox(defaultWidth - 40, defaulHeight, initialText, 20);

                SetPropertyForTextBlock(defaultWidth - 40, defaulHeight, 20);

                SetPropertyForFirstPointToConnect(defaultWidth / 2 - 2, -2);
                firstPointToConnect.MouseDown += ClickOnFirstConnectionPoint;

                SetPropertyForSecondPointToConnect(-2, defaulHeight / 2 - 2);
                secondPointToConnect.MouseDown += ClickOnSecondConnectionPoint;

                SetPropertyForThirdPointToConnect(defaultWidth / 2 - 2, defaulHeight - 3);
                thirdPointToConnect.MouseDown += ClickOnThirdConnectionPoint;

                SetPropertyForFourthPointToConnect(defaultWidth - 4, defaulHeight / 2 - 2);
                fourthPointToConnect.MouseDown += ClickOnFourthConnectionPoint;

                canvas.Children.Add(borderSubroutineBlock);
                canvas.Children.Add(internalBorderSubroutineBlock);
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
            if (canvas != null && borderSubroutineBlock != null && internalBorderSubroutineBlock != null)
            {
                canvas.Width = valueBlockWidth;
                SetPropertyForTextBox(valueBlockWidth - 40, DefaultPropertyForBlock.height);
                SetPropertyForTextBlock(valueBlockWidth - 40, DefaultPropertyForBlock.height, 20);
                borderSubroutineBlock.Width = valueBlockWidth;
                borderSubroutineBlock.Width = valueBlockWidth;
                internalBorderSubroutineBlock.Width = valueBlockWidth - 40;

                Canvas.SetLeft(firstPointToConnect, valueBlockWidth / 2 - 2);
                Canvas.SetLeft(thirdPointToConnect, valueBlockWidth / 2 - 2);
                Canvas.SetLeft(fourthPointToConnect, valueBlockWidth - 4);
            }
        }

        public override void SetHeight(int valueBlockHeight)
        {
            if (canvas != null && borderSubroutineBlock != null && internalBorderSubroutineBlock != null)
            {
                canvas.Height = valueBlockHeight;
                SetPropertyForTextBox(DefaultPropertyForBlock.width - 40, DefaultPropertyForBlock.height);
                SetPropertyForTextBlock(DefaultPropertyForBlock.width - 40, DefaultPropertyForBlock.height, 20);
                borderSubroutineBlock.Height = valueBlockHeight;
                internalBorderSubroutineBlock.Height = valueBlockHeight;

                Canvas.SetTop(secondPointToConnect, valueBlockHeight / 2 - 2);
                Canvas.SetTop(thirdPointToConnect, valueBlockHeight - 3);
                Canvas.SetTop(fourthPointToConnect, valueBlockHeight / 2 - 2);
            }
        }
        public override double GetWidthCoefficient() => blockWidthCoefficient;

        public override double GetHeightCoefficient() => blockHeightCoefficient;
    }
}