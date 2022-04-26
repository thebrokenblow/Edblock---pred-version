using Flowchart_Editor.Models.Action;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Flowchart_Editor.Models
{
    public class ConditionBlock : Block
    {
        public Polygon? polygonConditionBlock;
        private readonly int defaultWidth = DefaultPropertyForBlock.width;
        private readonly int defaulHeight = DefaultPropertyForBlock.height;
        private readonly MainWindow mainWindow;
        const string initialText = "Условие";

        public ConditionBlock(MainWindow mainWindow, int keyBlock)
        {
            this.mainWindow = mainWindow;
            keyOfBlock = keyBlock;
        }

        public UIElement GetUIElement()
        {
            if (canvas == null)
            {
                canvas = new Canvas();
                polygonConditionBlock = new Polygon();
                textBox = new TextBox();
                textBlock = new TextBlock();
                firstPointToConnect = new Ellipse();
                secondPointToConnect = new Ellipse();
                thirdPointToConnect = new Ellipse();
                fourthPointToConnect = new Ellipse();
               
                BrushConverter brushConverter = new();
                Brush backgroundColor = (Brush)brushConverter.ConvertFrom("#FF60B2D3");
                Brush brushDefaulColorPoint = (Brush)brushConverter.ConvertFrom(defaulColorPoint);

                polygonConditionBlock.Fill = backgroundColor;
                Point Point1 = new(0, defaulHeight / 2);
                Point Point2 = new(defaultWidth / 2, defaulHeight);
                Point Point3 = new(defaultWidth, defaulHeight / 2);
                Point Point4 = new(defaultWidth / 2, 0);
                Point Point5 = new(0, defaulHeight / 2);

                PointCollection myPointCollection = new();
                myPointCollection.Add(Point1);
                myPointCollection.Add(Point2);
                myPointCollection.Add(Point3);
                myPointCollection.Add(Point4);
                myPointCollection.Add(Point5);
                polygonConditionBlock.Points = myPointCollection;

                int valueForSetLeftTextBoxAndTextBlock = defaultWidth / 2 - defaultWidth / 4;
                int valueForSetTopTextBoxAndTextBlock = defaulHeight / 4;

                SetPropertyForTextBox(defaultWidth / 2, defaulHeight / 2, initialText, valueForSetLeftTextBoxAndTextBlock, valueForSetTopTextBoxAndTextBlock);
                SetPropertyForTextBlock(defaultWidth / 2, defaulHeight / 2, valueForSetLeftTextBoxAndTextBlock, valueForSetTopTextBoxAndTextBlock);

                SetPropertyForFirstPointToConnect(defaultWidth / 2 - 3, -2, brushDefaulColorPoint);
                firstPointToConnect.MouseDown += ClickOnFirstConnectionPoint;

                SetPropertyForSecondPointToConnect(0, defaulHeight / 2 - 3, brushDefaulColorPoint);
                secondPointToConnect.MouseDown += ClickOnSecondConnectionPoint;

                SetPropertyForThirdPointToConnect(defaultWidth / 2 - 3, defaulHeight - 3, brushDefaulColorPoint);
                thirdPointToConnect.MouseDown += ClickOnThirdConnectionPoint;

                SetPropertyForFourthPointToConnect(defaultWidth - 6, defaulHeight / 2 - 3, brushDefaulColorPoint);
                fourthPointToConnect.MouseDown += ClickOnFourthConnectionPoint;

                canvas.Children.Add(polygonConditionBlock);
                canvas.Children.Add(firstPointToConnect);
                canvas.Children.Add(secondPointToConnect);
                canvas.Children.Add(thirdPointToConnect);
                canvas.Children.Add(fourthPointToConnect);
                canvas.Children.Add(textBox);
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

        public void SetWidthAndHeightOfBlock(int valueBlockWidth, int valueBlokHeight)
        {
            if (polygonConditionBlock != null && textBox != null && textBlock != null)
            {
                Point Point1 = new(0, valueBlokHeight / 2);
                Point Point2 = new(valueBlockWidth / 2, valueBlokHeight);
                Point Point3 = new(valueBlockWidth, valueBlokHeight / 2);
                Point Point4 = new(valueBlockWidth / 2, 0);
                Point Point5 = new(0, valueBlokHeight / 2);
                PointCollection myPointCollection = new();
                myPointCollection.Add(Point1);
                myPointCollection.Add(Point2);
                myPointCollection.Add(Point3);
                myPointCollection.Add(Point4);
                myPointCollection.Add(Point5);
                polygonConditionBlock.Points = myPointCollection;

                int valueForSetLeftTextBoxAndTextBlock = valueBlockWidth / 2 - valueBlockWidth / 4;
                int valueForSetTopTextBoxAndTextBlock = valueBlokHeight / 4;

                SetPropertyForTextBox(valueBlockWidth / 2, valueBlokHeight / 2, textBox.Text, valueForSetLeftTextBoxAndTextBlock, valueForSetTopTextBoxAndTextBlock);
                SetPropertyForTextBlock(valueBlockWidth / 2, valueBlokHeight / 2, valueForSetLeftTextBoxAndTextBlock, valueForSetTopTextBoxAndTextBlock);

                SetPropertyForFirstPointToConnect(valueBlockWidth / 2 - 3, -2);
                SetPropertyForSecondPointToConnect(0, valueBlokHeight / 2 - 3);
                SetPropertyForThirdPointToConnect(valueBlockWidth / 2 - 3, valueBlokHeight - 3);
                SetPropertyForFourthPointToConnect(valueBlockWidth - 6, valueBlokHeight / 2 - 3);
            }
        }
    }
}