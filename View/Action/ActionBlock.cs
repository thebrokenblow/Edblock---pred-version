using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Controls;
using Flowchart_Editor.Models.Comment;

namespace Flowchart_Editor.Models
{
    [BlockName("ActionBlock")]
    public class ActionBlock : Block
    {
        private readonly int defaultWidth = DefaultPropertyForBlock.width;
        private readonly int defaulHeight = DefaultPropertyForBlock.height;

        public ActionBlock(MainWindow mainWindow, int keyBlock)
        {
            MainWindow = mainWindow;
            keyOfBlock = keyBlock;
            blockWidthCoefficient = 1;
            blockHeightCoefficient = 1;
            initialText = "Действие";
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

                BrushConverter brushConverter = new();
                Brush backgroundColor = (Brush)brushConverter.ConvertFrom("#FF52C0AA");

                SetPropertyForCanvas(defaultWidth, defaulHeight, backgroundColor);

                SetPropertyForTextBox(defaultWidth, defaulHeight, initialText);

                SetPropertyForTextBlock(defaultWidth, defaulHeight);

                SetPropertyForFirstPointToConnect(defaultWidth / 2 - 2, -2);
                firstPointToConnect.MouseDown += ClickOnFirstConnectionPoint;

                SetPropertyForSecondPointToConnect(-2, defaulHeight / 2 - 2);
                secondPointToConnect.MouseDown += ClickOnSecondConnectionPoint;

                SetPropertyForThirdPointToConnect(defaultWidth / 2 - 2, defaulHeight - 3);
                thirdPointToConnect.MouseDown += ClickOnThirdConnectionPoint;

                SetPropertyForFourthPointToConnect(defaultWidth - 4, defaulHeight / 2 - 2);
                fourthPointToConnect.MouseDown += ClickOnFourthConnectionPoint;

                canvas.MouseRightButtonDown += ClickRightButton;
                AddChildrenForCanvas();
            }
            return canvas;
        }

        public override void SetWidth(int valueBlockWidth)
        {
            if (canvas != null && TextBox != null && TextBlock != null)
            {
                canvas.Width = valueBlockWidth;
                TextBox.Width = valueBlockWidth;
                TextBlock.Width = valueBlockWidth;
                Canvas.SetLeft(firstPointToConnect, valueBlockWidth / 2 - 2);
                Canvas.SetLeft(thirdPointToConnect, valueBlockWidth / 2 - 2);
                Canvas.SetLeft(fourthPointToConnect, valueBlockWidth - 4);
            }
        }

        public override void SetHeight(int valueBlockHeight)
        {
            if (canvas != null && TextBox != null && TextBlock != null)
            {
                canvas.Height = valueBlockHeight;
                TextBox.Height = valueBlockHeight;
                TextBlock.Height = valueBlockHeight;
                Canvas.SetTop(secondPointToConnect, valueBlockHeight / 2 - 2);
                Canvas.SetTop(thirdPointToConnect, valueBlockHeight - 3);
                Canvas.SetTop(fourthPointToConnect, valueBlockHeight / 2 - 2);
            }
        }

        protected override void SetСoordinatesComment(UIElement comment)
        {
            Canvas.SetTop(comment, DefaultPropertyForBlock.height / 2 + 1);
            Canvas.SetLeft(comment, DefaultPropertyForBlock.width);
        }

        public override double GetWidthCoefficient() => blockWidthCoefficient;

        public override double GetHeightCoefficient() => blockHeightCoefficient;
    }
}