using Flowchart_Editor.Models.Action;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Flowchart_Editor.Models
{
    public class CycleWhileBeginBlock : Block
    {
        public Polygon? polygonCycleWhileBeginBlock = null;   
        private readonly int defaultWidth = DefaultPropertyForBlock.width;
        private readonly int defaulHeight = DefaultPropertyForBlock.height;
        private readonly MainWindow mainWindow;
        private const string initialText = "Цикл while начало";

        public CycleWhileBeginBlock(MainWindow mainWindow, int keyBlock)
        {
            this.mainWindow = mainWindow;
            keyOfBlock = keyBlock;
        }

        public UIElement GetUIElement()
        {
            if (canvas == null)
            {
                canvas = new Canvas();
                polygonCycleWhileBeginBlock = new Polygon();
                textBox = new TextBox();
                textBlock = new TextBlock();
                firstPointToConnect = new Ellipse();
                secondPointToConnect = new Ellipse();
                thirdPointToConnect = new Ellipse();
                fourthPointToConnect = new Ellipse();

                BrushConverter brushConverter = new();
                Brush backgroundColor = (Brush)brushConverter.ConvertFrom("#FFCCCCFF");
                Brush brushDefaulColorPoint = (Brush)brushConverter.ConvertFrom(defaulColorPoint);

                polygonCycleWhileBeginBlock.Fill = backgroundColor;
                Point Point1 = new(0, defaulHeight);
                Point Point2 = new(0, 10);
                Point Point3 = new(10, 0);
                Point Point4 = new(defaultWidth - 10, 0);
                Point Point5 = new(defaultWidth, 10);
                Point Point6 = new(defaultWidth, defaulHeight);
                PointCollection myPointCollection1 = new();
                myPointCollection1.Add(Point1);
                myPointCollection1.Add(Point2);
                myPointCollection1.Add(Point3);
                myPointCollection1.Add(Point4);
                myPointCollection1.Add(Point5);
                myPointCollection1.Add(Point6);
                polygonCycleWhileBeginBlock.Points = myPointCollection1;

                SetPropertyForTextBox(defaultWidth - 20, defaulHeight, initialText, 10);
                SetPropertyForTextBlock(defaultWidth - 20, defaulHeight, 10);

                SetPropertyForFirstPointToConnect(defaultWidth / 2 - 2, -2, brushDefaulColorPoint);
                firstPointToConnect.MouseDown += ClickOnFirstConnectionPoint;

                SetPropertyForSecondPointToConnect(-2, defaulHeight / 2 - 2, brushDefaulColorPoint);
                secondPointToConnect.MouseDown += ClickOnSecondConnectionPoint;

                SetPropertyForThirdPointToConnect(defaultWidth / 2 - 2, defaulHeight - 3, brushDefaulColorPoint);
                thirdPointToConnect.MouseDown += ClickOnThirdConnectionPoint;

                SetPropertyForFourthPointToConnect(defaultWidth - 4, defaulHeight / 2 - 2, brushDefaulColorPoint);
                fourthPointToConnect.MouseDown += ClickOnFourthConnectionPoint;

                canvas.Children.Add(polygonCycleWhileBeginBlock);
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
        public void SetWidthAndHeightOfBlock(int valueBlokWidth, int valueBlokHeight)
        {
            if (polygonCycleWhileBeginBlock != null && canvas != null && textBox != null && textBlock != null)
            {
                Point Point1 = new(0, valueBlokHeight);
                Point Point2 = new(0, 10);
                Point Point3 = new(10, 0);
                Point Point4 = new(valueBlokWidth - 10, 0);
                Point Point5 = new(valueBlokWidth, 10);
                Point Point6 = new(valueBlokWidth, valueBlokHeight);
                PointCollection myPointCollection = new();
                myPointCollection.Add(Point1);
                myPointCollection.Add(Point2);
                myPointCollection.Add(Point3);
                myPointCollection.Add(Point4);
                myPointCollection.Add(Point5);
                myPointCollection.Add(Point6);

                polygonCycleWhileBeginBlock.Points = myPointCollection;
                canvas.Width = valueBlokWidth;

                SetPropertyForTextBox(valueBlokWidth - 20, valueBlokHeight, initialText, 10);
                SetPropertyForTextBlock(valueBlokWidth - 20, valueBlokHeight, 10);

                Canvas.SetLeft(firstPointToConnect, valueBlokWidth / 2 - 2);
                Canvas.SetLeft(thirdPointToConnect, valueBlokWidth / 2 - 2);
                Canvas.SetLeft(fourthPointToConnect, valueBlokWidth - 4);
                Canvas.SetTop(secondPointToConnect, valueBlokHeight / 2 - 2);
                Canvas.SetTop(thirdPointToConnect, valueBlokHeight - 3);
                Canvas.SetTop(fourthPointToConnect, valueBlokHeight / 2 - 2);
            }
        }
    }
}
