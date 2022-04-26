using Flowchart_Editor.Models.Action;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Flowchart_Editor.Models
{
    public class SubroutineBlock : Block
    {
        public Border? borderSubroutineBlock = null;
        public Border? internalBorderSubroutineBlock = null;
        private readonly MainWindow mainWindow;
        private readonly int defaultWidth = DefaultPropertyForBlock.width;
        private readonly int defaulHeight = DefaultPropertyForBlock.height;
        private const string initialText = "Подпрограмма";

        public SubroutineBlock(MainWindow mainWindow, int keyBlock)
        {
            this.mainWindow = mainWindow;
            keyOfBlock = keyBlock;
        }

        public UIElement GetUIElement()
        {
            if (canvas == null)
            {
                canvas = new Canvas();
                borderSubroutineBlock = new Border();
                internalBorderSubroutineBlock = new Border();
                textBox = new TextBox();
                textBlock = new TextBlock();
                firstPointToConnect = new Ellipse();
                secondPointToConnect = new Ellipse();
                thirdPointToConnect = new Ellipse();
                fourthPointToConnect = new Ellipse();

                BrushConverter brushConverter = new();
                Brush backgroundColor = (Brush)brushConverter.ConvertFrom("#FFBA64C8");
                Brush brushDefaulColorPoint = (Brush)brushConverter.ConvertFrom(defaulColorPoint);

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

                SetPropertyForFirstPointToConnect(defaultWidth / 2 - 2, -2, brushDefaulColorPoint);
                firstPointToConnect.MouseDown += ClickOnFirstConnectionPoint;

                SetPropertyForSecondPointToConnect(-2, defaulHeight / 2 - 2, brushDefaulColorPoint);
                secondPointToConnect.MouseDown += ClickOnSecondConnectionPoint;

                SetPropertyForThirdPointToConnect(defaultWidth / 2 - 2, defaulHeight - 3, brushDefaulColorPoint);
                thirdPointToConnect.MouseDown += ClickOnThirdConnectionPoint;

                SetPropertyForFourthPointToConnect(defaultWidth - 4, defaulHeight / 2 - 2, brushDefaulColorPoint);
                fourthPointToConnect.MouseDown += ClickOnFourthConnectionPoint;

                canvas.Children.Add(borderSubroutineBlock);
                canvas.Children.Add(internalBorderSubroutineBlock);
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
                StaticBlock.secondPointToConnect = "thirdPointToConnect";
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