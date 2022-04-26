using Flowchart_Editor.Models.Action;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Flowchart_Editor.Models
{
    public class InputOutputBlock : Block
    {
        public Polygon? polygonInputOutputBlock;
        private readonly int defaultWidth = DefaultPropertyForBlock.width;
        private readonly int defaulHeight = DefaultPropertyForBlock.height;
        private readonly MainWindow mainWindow;
        private const string initialText = "Ввод/Вывод";
        private const int sideProjection = 20;
        private const int startingPointOfCoordinates = 0;

        public InputOutputBlock(MainWindow mainWindow, int keyBlock)
        {
            this.mainWindow = mainWindow;
            keyOfBlock = keyBlock;
        }

        public UIElement GetUIElement()
        {
            if (canvas == null)
            {
                canvas = new Canvas();
                polygonInputOutputBlock = new Polygon();
                textBox = new TextBox();
                textBlock = new TextBlock();
                firstPointToConnect = new Ellipse();
                secondPointToConnect = new Ellipse();
                thirdPointToConnect = new Ellipse();
                fourthPointToConnect = new Ellipse();

                BrushConverter brushConverter = new();
                Brush backgroundColor = (Brush)brushConverter.ConvertFrom("#FF008080");
                Brush brushDefaulColorPoint = (Brush)brushConverter.ConvertFrom(defaulColorPoint);

                polygonInputOutputBlock.Fill = backgroundColor;
                Point Point1 = new(sideProjection, startingPointOfCoordinates);
                Point Point2 = new(startingPointOfCoordinates, defaulHeight);
                Point Point3 = new(defaultWidth - sideProjection, defaulHeight);
                Point Point4 = new(defaultWidth, startingPointOfCoordinates);

                PointCollection myPointCollection = new();
                myPointCollection.Add(Point1);
                myPointCollection.Add(Point2);
                myPointCollection.Add(Point3);
                myPointCollection.Add(Point4);

                polygonInputOutputBlock.Points = myPointCollection;

                SetPropertyForTextBox(defaultWidth - sideProjection * 3, defaulHeight - 5, initialText, sideProjection * 1.5, 5);
                SetPropertyForTextBlock(defaultWidth - sideProjection * 3, defaulHeight - 5, sideProjection * 1.5, 5);

                SetPropertyForFirstPointToConnect(defaultWidth / 2, -2, brushDefaulColorPoint);
                firstPointToConnect.MouseDown += ClickOnFirstConnectionPoint;

                SetPropertyForSecondPointToConnect(8, defaulHeight / 2 - 5, brushDefaulColorPoint);
                secondPointToConnect.MouseDown += ClickOnSecondConnectionPoint;

                SetPropertyForThirdPointToConnect(defaultWidth / 2, defaulHeight - 3, brushDefaulColorPoint);
                thirdPointToConnect.MouseDown += ClickOnThirdConnectionPoint;

                SetPropertyForFourthPointToConnect(defaultWidth - 13, defaulHeight / 2 - 5, brushDefaulColorPoint);
                fourthPointToConnect.MouseDown += ClickOnFourthConnectionPoint;

                canvas.Children.Add(polygonInputOutputBlock);
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
            if (canvas != null && polygonInputOutputBlock != null && textBox != null && textBlock != null)
            {
                Point Point1 = new(20, 0);
                Point Point2 = new(0, valueBlokHeight);
                Point Point3 = new(valueBlokWidth - 20, valueBlokHeight);
                Point Point4 = new(valueBlokWidth, 0);

                PointCollection myPointCollection = new();
                myPointCollection.Add(Point1);
                myPointCollection.Add(Point2);
                myPointCollection.Add(Point3);
                myPointCollection.Add(Point4);

                polygonInputOutputBlock.Points = myPointCollection;
                canvas.Width = valueBlokWidth;

                SetPropertyForTextBox(valueBlokWidth - sideProjection * 3, valueBlokHeight - 5, valueForSetLeft: sideProjection * 1.5, valueForSetTop: 5);
                SetPropertyForTextBlock(valueBlokWidth - sideProjection * 3, valueBlokHeight - 5, valueForSetLeft: sideProjection * 1.5, valueForSetTop: 5);

                Canvas.SetLeft(firstPointToConnect, valueBlokWidth / 2);
                Canvas.SetLeft(thirdPointToConnect, valueBlokWidth / 2);
                Canvas.SetLeft(fourthPointToConnect, valueBlokWidth - 13);
                Canvas.SetTop(secondPointToConnect, valueBlokHeight / 2 - 5);
                Canvas.SetTop(thirdPointToConnect, valueBlokHeight - 3);
                Canvas.SetTop(fourthPointToConnect, valueBlokHeight / 2 - 5);
            }
        }
    }
}