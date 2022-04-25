﻿using System.Windows;
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

                BrushConverter brushConverter = new();
                Brush backgroundColor = (Brush)brushConverter.ConvertFrom("#FF52C0AA");
                Brush brushDefaulColorPoint = (Brush)brushConverter.ConvertFrom(defaulColorPoint);

                SetPropertyForTextBox(defaultWidth, defaulHeight, initialText);
                SetPropertyForTextBlock(defaultWidth, defaulHeight);
                SetPropertyForCanvas(backgroundColor, defaultWidth, defaulHeight);

                SetPropertyForFirstPointToConnect(brushDefaulColorPoint, defaultWidth);
                firstPointToConnect.MouseDown += ClickOnFirstConnectionPoint;

                SetPropertyForSecondPointToConnect(brushDefaulColorPoint, defaulHeight);
                secondPointToConnect.MouseDown += ClickOnSecondConnectionPoint;

                SetPropertyForThirdPointToConnect(brushDefaulColorPoint, defaultWidth, defaulHeight);
                thirdPointToConnect.MouseDown += ClickOnThirdConnectionPoint;

                SetPropertyForFourthPointToConnect(brushDefaulColorPoint, defaultWidth, defaulHeight);
                fourthPointToConnect.MouseDown += ClickOnFourthConnectionPoint;

                AddChildrenForCanvas();
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