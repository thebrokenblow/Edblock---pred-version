using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Controls;
using Flowchart_Editor.Models.Action;

namespace Flowchart_Editor.Models
{
    public class ActionBlock : Block
    {
        private readonly MainWindow mainWindow;
        private readonly int defaultWidth = DefaultPropertyForBlock.width;
        private readonly int defaulHeight = DefaultPropertyForBlock.height;
        private const string initialText = "Действие";

        public ActionBlock(MainWindow mainWindow, int keyBlock)
        {
            this.mainWindow = mainWindow;
            keyOfBlock = keyBlock;
        }
        protected void SetPropertyForTextBlock(int defaultWidth, int defaulHeight)
        {
            if (textBlock != null)
            {
                textBlock.Width = defaultWidth;
                textBlock.Height = defaulHeight;
                textBlock.FontSize = defaulFontSize;
                textBlock.FontFamily = defaultFontFamily;
                textBlock.VerticalAlignment = VerticalAlignment.Center;
                textBlock.HorizontalAlignment = HorizontalAlignment.Center;
                textBlock.TextAlignment = TextAlignment.Center;
                textBlock.Foreground = Brushes.White;
                textBlock.TextWrapping = TextWrapping.Wrap;
                textBlock.MouseDown += ChangeTextBoxToTextBlock;
            }
        }

        public UIElement GetUIElement()
        {
            if (canvas == null)
            {
                canvas = new Canvas();
                textBox = new TextBox();
                textBlock = new TextBlock();
                firstPointToConnect = new Ellipse();
                secondPointToConnect = new Ellipse();
                thirdPointToConnect = new Ellipse();
                fourthPointToConnect = new Ellipse();

                SetPropertyForTextBox(defaultWidth, defaulHeight, initialText);
                SetPropertyForTextBlock(defaultWidth, defaulHeight);

                BrushConverter brushConverter = new();
                Brush backgroundColor = (Brush)brushConverter.ConvertFrom("#FF52C0AA");

                SetPropertyForCanvas(backgroundColor, defaultWidth, defaulHeight);

                firstPointToConnect.Fill = (Brush)brushConverter.ConvertFrom(defaulColorPoint); 
                firstPointToConnect.Height = radiusPoint;
                firstPointToConnect.Width = radiusPoint;
                Canvas.SetLeft(firstPointToConnect, defaultWidth / 2 - 2);
                Canvas.SetTop(firstPointToConnect,  -2);
                firstPointToConnect.MouseDown += ClickOnFirstConnectionPoint;

                secondPointToConnect.Fill = (Brush)brushConverter.ConvertFrom(defaulColorPoint);
                secondPointToConnect.Height = radiusPoint;
                secondPointToConnect.Width = radiusPoint;
                Canvas.SetLeft(secondPointToConnect, -2);
                Canvas.SetTop(secondPointToConnect, defaulHeight / 2 - 2);
                secondPointToConnect.MouseDown += ClickOnSecondConnectionPoint;

                thirdPointToConnect.Fill = (Brush)brushConverter.ConvertFrom(defaulColorPoint);
                thirdPointToConnect.Height = radiusPoint;
                thirdPointToConnect.Width = radiusPoint;
                Canvas.SetLeft(thirdPointToConnect, defaultWidth / 2 - 2);
                Canvas.SetTop(thirdPointToConnect, defaulHeight - 3);
                thirdPointToConnect.MouseDown += ClickOnThirdConnectionPoint;

                fourthPointToConnect.Fill = (Brush)brushConverter.ConvertFrom(defaulColorPoint);
                fourthPointToConnect.Height = radiusPoint;
                fourthPointToConnect.Width = radiusPoint;
                Canvas.SetLeft(fourthPointToConnect, defaultWidth - 4);
                Canvas.SetTop(fourthPointToConnect, defaulHeight / 2 -2);
                fourthPointToConnect.MouseDown += ClickOnFourthConnectionPoint;

                canvas.Children.Add(textBox);
                canvas.Children.Add(firstPointToConnect);
                canvas.Children.Add(secondPointToConnect);
                canvas.Children.Add(thirdPointToConnect);
                canvas.Children.Add(fourthPointToConnect);
                canvas.MouseMove += MouseMoveBlockForMovements;
            }
            return canvas;
        }

        private void ClickOnFirstConnectionPoint(object sender, MouseEventArgs e)
        {
            if (!flagForEnteringFirstConnectionPoint)
            {
                flagForEnteringFirstConnectionPoint = true;
                GetDataForCoordinates(sender, initialText, mainWindow);
            }
        }
        private void ClickOnSecondConnectionPoint(object sender, MouseEventArgs e)
        {
            if (!flagForEnteringSecondConnectionPoint)
            {
                flagForEnteringSecondConnectionPoint = true;
                GetDataForCoordinates(sender, initialText, mainWindow);
            }
        }
        private void ClickOnThirdConnectionPoint(object sender, MouseEventArgs e)
        {
            if (!flagForEnteringThirdConnectionPoint)
            {
                flagForEnteringThirdConnectionPoint = true;
                GetDataForCoordinates(sender, initialText, mainWindow);
            }
        }
        private void ClickOnFourthConnectionPoint(object sender, MouseEventArgs e)
        {
            if (!flagForEnteringSecondConnectionPoint)
            {
                if (PinningComment.flagPinningComment && PinningComment.comment != null && canvas != null)
                {
                    flagForEnteringSecondConnectionPoint = true;
                    UIElement commentUIElement = PinningComment.comment.GetUIElement();
                    canvas.Children.Add(commentUIElement);
                    Canvas.SetTop(commentUIElement, defaulHeight / 2 + 1);
                    Canvas.SetLeft(commentUIElement, defaultWidth + 1);
                    mainWindow.WriteFirstNameOfBlockToConect("");
                    PinningComment.flagPinningComment = false;
                    PinningComment.comment = null;

                }
                else
                {
                    flagForEnteringSecondConnectionPoint = true;
                    GetDataForCoordinates(sender, initialText, mainWindow);
                }
            }
        }
    }
}