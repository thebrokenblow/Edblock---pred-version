using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Controls;
using Flowchart_Editor.Models.Action;
using System;

namespace Flowchart_Editor.Models
{
    public class LinkBlock : Block
    {
        private readonly int defaultWidth = DefaultPropertyForBlock.height / 2;
        private readonly int defaulHeight = DefaultPropertyForBlock.height / 2;
        private readonly MainWindow mainWindow;

        public LinkBlock(MainWindow mainWindow, int keyBlock)
        {
            this.mainWindow = mainWindow;
            keyOfBlock = keyBlock;
        }

        public UIElement GetUIElement()
        {
            if (canvas == null)
            {
                canvas = new Canvas();
                ellipse = new Ellipse();
                textBox = new TextBox();
                textBlock = new TextBlock();
                firstPointToConnect = new Ellipse();
                secondPointToConnect = new Ellipse();
                thirdPointToConnect = new Ellipse();
                fourthPointToConnect = new Ellipse();

                BrushConverter brushConverter = new();
                Brush backgroundColor = (Brush)brushConverter.ConvertFrom("#FF5761A8");
                Brush brushDefaulColorPoint = (Brush)brushConverter.ConvertFrom(defaulColorPoint);

                SetPropertyForCanvas(defaultWidth, defaulHeight);
                SetPropertyForEllipse(defaultWidth, defaulHeight, backgroundColor);

                int valueForSetTop = 5;
                SetPropertyForTextBox(Math.Abs(defaultWidth - 60), defaulHeight - 5, "", 30, valueForSetTop);
                SetPropertyForTextBlock(Math.Abs(defaultWidth - 60), defaulHeight - 5, 30, valueForSetTop);

                SetPropertyForFirstPointToConnect(defaultWidth / 2 - 3, -2, brushDefaulColorPoint);
                firstPointToConnect.MouseDown += ClickOnFirstConnectionPoint;

                SetPropertyForSecondPointToConnect(-2, defaulHeight / 2 - 3, brushDefaulColorPoint);
                secondPointToConnect.MouseDown += ClickOnSecondConnectionPoint;

                SetPropertyForThirdPointToConnect(defaulHeight / 2 - 3, defaulHeight - 3, brushDefaulColorPoint);
                thirdPointToConnect.MouseDown += ClickOnThirdConnectionPoint;

                SetPropertyForFourthPointToConnect(defaultWidth - 3, defaulHeight / 2 - 3, brushDefaulColorPoint);
                fourthPointToConnect.MouseDown += ClickOnFourthConnectionPoint;

                canvas.Children.Add(ellipse);
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
                StaticBlock.firstPointToConnect = "firstPointToConnect";
                flagForEnteringFirstConnectionPoint = true;
                GetDataForCoordinates(sender, "", mainWindow);
            }
        }
        private void ClickOnSecondConnectionPoint(object sender, MouseEventArgs e)
        {
            if (!flagForEnteringSecondConnectionPoint)
            {
                flagForEnteringSecondConnectionPoint = true;
                GetDataForCoordinates(sender, "", mainWindow);
            }
        }
        private void ClickOnThirdConnectionPoint(object sender, MouseEventArgs e)
        {
            if (!flagForEnteringThirdConnectionPoint)
            {
                StaticBlock.secondPointToConnect = "thirdPointToConnect";
                flagForEnteringThirdConnectionPoint = true;
                GetDataForCoordinates(sender, "", mainWindow);
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
                    GetDataForCoordinates(sender, "", mainWindow);
                }
            }
        }
    }
}