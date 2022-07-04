using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Controls;

namespace Flowchart_Editor.Models
{
    [BlockName("LinkBlock")]
    public class LinkBlock : Block
    {
        private readonly int width = DefaultPropertyForBlock.width / 2;
        private readonly int defaultWidth = DefaultPropertyForBlock.height / 2;
        private readonly int defaulHeight = DefaultPropertyForBlock.height / 2;

        public LinkBlock(Edblock mainWindow, int keyBlock)
        {
            MainWindow = mainWindow;
            keyOfBlock = keyBlock;
            blockWidthCoefficient = 0.5;
            blockHeightCoefficient = 0.5;
            initialText = "Ссылка";
        }

        override public UIElement GetUIElement()
        {
            if (canvas == null)
            {
                canvas = new Canvas();
                ellipse = new Ellipse();
                TextBox = new TextBox();
                TextBlock = new TextBlock();
                firstPointToConnect = new Ellipse();
                secondPointToConnect = new Ellipse();
                thirdPointToConnect = new Ellipse();
                fourthPointToConnect = new Ellipse();

                BrushConverter brushConverter = new();
                Brush backgroundColor = (Brush)brushConverter.ConvertFrom("#FF5761A8");

                SetPropertyForCanvas(DefaultPropertyForBlock.height, DefaultPropertyForBlock.height);

                ellipse.Width = defaultWidth;
                ellipse.Height = defaulHeight;
                ellipse.Fill = backgroundColor;

                SetPropertyForTextBox(defaulHeight / 2, defaulHeight / 2, "", 7, 5);

                SetPropertyForTextBlock(defaulHeight / 2, defaulHeight / 2, 7, 5);

                SetPropertyForFirstPointToConnect(defaultWidth / 2 - 3, -2);
                firstPointToConnect.MouseDown += ClickOnFirstConnectionPoint;

                SetPropertyForSecondPointToConnect(-2, defaulHeight / 2 - 3);
                secondPointToConnect.MouseDown += ClickOnSecondConnectionPoint;

                SetPropertyForThirdPointToConnect(defaulHeight / 2 - 3, defaulHeight - 3);
                thirdPointToConnect.MouseDown += ClickOnThirdConnectionPoint;

                SetPropertyForFourthPointToConnect(defaultWidth - 3, defaulHeight / 2 - 3);
                fourthPointToConnect.MouseDown += ClickOnFourthConnectionPoint;

                canvas.Children.Add(ellipse);
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

           Canvas.SetLeft(comment, DefaultPropertyForBlock.height / 2);
           Canvas.SetTop(comment, defaulHeight / 2);            
        }

        public override void SetWidth(int valueBlockWidth){}

        public override void SetHeight(int valueBlockHeight)
        {
            if (canvas != null && ellipse != null)
            {
                canvas.Width = valueBlockHeight / 2;
                canvas.Height = valueBlockHeight / 2;

                ellipse.Height = valueBlockHeight / 2;
                ellipse.Width = valueBlockHeight / 2;

                SetPropertyForTextBox(valueBlockHeight / 2 - 12, valueBlockHeight / 2, valueForSetLeft: 7, valueForSetTop: 5);
                SetPropertyForTextBlock(valueBlockHeight / 2 - 12, valueBlockHeight / 2);

                Canvas.SetLeft(firstPointToConnect, valueBlockHeight / 4 - 3);
                Canvas.SetTop(firstPointToConnect, -2);

                Canvas.SetLeft(secondPointToConnect, -2);
                Canvas.SetTop(secondPointToConnect, valueBlockHeight / 4 - 3);

                Canvas.SetLeft(thirdPointToConnect, valueBlockHeight / 4 - 3);
                Canvas.SetTop(thirdPointToConnect, valueBlockHeight / 2 - 3);

                Canvas.SetLeft(fourthPointToConnect, valueBlockHeight / 2 - 3);
                Canvas.SetTop(fourthPointToConnect, valueBlockHeight / 4 - 3);
            }
        }
        public override double GetWidthCoefficient() => 
            blockWidthCoefficient;

        public override double GetHeightCoefficient() => 
            blockHeightCoefficient;

        public override void SetLeftBlockForConditionCaseSecondOption(UIElement uIElementBlock, double coordinateLeft) =>
            Canvas.SetLeft(uIElementBlock, coordinateLeft + DefaultPropertyForBlock.height);

        public override void SetTopBlockForConditionCaseSecondOption(UIElement uIElementBlock, double coordinateTop) =>
            Canvas.SetTop(uIElementBlock, coordinateTop);

        public override void SetLeftBlockForConditionCaseFirstOption(UIElement uIElementBlock, double coordinateLeft)
        {
            throw new System.NotImplementedException();
        }

        public override void SetTopBlockForConditionCaseFirstOption(UIElement uIElementBlock, double coordinateTop)
        {
            throw new System.NotImplementedException();
        }
    }
}