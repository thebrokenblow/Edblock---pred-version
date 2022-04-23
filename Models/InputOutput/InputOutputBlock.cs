using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Flowchart_Editor.Models
{
    public class InputOutputBlock : Block
    {
        public Canvas? canvasInputOutputBlock;
        public Polygon polygonInputOutputBlock;
        public TextBox textBoxInputOutputBlock;
        public TextBlock textBlockInputOutputBlock;
        public Ellipse? firstPointToConnect = null;
        public Ellipse? secondPointToConnect = null;
        public Ellipse? thirdPointToConnect = null;
        public Ellipse? fourthPointToConnect = null;
        private bool textChangeStatus = false;
        private readonly int defaultWidth = DefaultPropertyForBlock.width;
        private readonly int defaulHeight = DefaultPropertyForBlock.height;
        private readonly string defaulColorPoint = DefaultPropertyForBlock.colorPoint;
        private readonly FontFamily defaulFontFamily = DefaultPropertyForBlock.fontFamily;
        private readonly int defaulFontSize = DefaultPropertyForBlock.fontSize;
        private int valueOfClicksOnTextBlock = 0;
        private readonly MainWindow mainWindow;
        private const int radiusPoint = 6;
        private readonly int keyInputOutputBlock = 0;
        private const string textOfInputOutputBlock = "Ввод/Вывод";
        private const int sideProjection = 20;
        private const int startingPointOfCoordinates = 0;

        public InputOutputBlock(MainWindow mainWindow, int keyBlock)
        {
            this.mainWindow = mainWindow;
            keyInputOutputBlock = keyBlock;
        }

        public UIElement GetUIElement()
        {
            if (canvasInputOutputBlock == null)
            {
                canvasInputOutputBlock = new Canvas();
                polygonInputOutputBlock = new Polygon();
                textBoxInputOutputBlock = new TextBox();
                textBlockInputOutputBlock = new TextBlock();
                firstPointToConnect = new Ellipse();
                secondPointToConnect = new Ellipse();
                thirdPointToConnect = new Ellipse();
                fourthPointToConnect = new Ellipse();

                var backgroundColor = new BrushConverter();
                polygonInputOutputBlock.Fill = (Brush)backgroundColor.ConvertFrom("#FF008080");

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

                textBoxInputOutputBlock.Text = textOfInputOutputBlock;
                textBoxInputOutputBlock.FontSize = defaulFontSize;
                textBoxInputOutputBlock.Foreground = Brushes.White;
                textBoxInputOutputBlock.Width = defaultWidth;
                textBoxInputOutputBlock.Height = defaulHeight;
                textBoxInputOutputBlock.TextAlignment = TextAlignment.Center;
                textBoxInputOutputBlock.HorizontalAlignment = HorizontalAlignment.Center;
                textBoxInputOutputBlock.TextWrapping = TextWrapping.Wrap;
                textBoxInputOutputBlock.FontFamily = defaulFontFamily;
                textBoxInputOutputBlock.MouseDoubleClick += ChangeTextBoxToTextBlock;
                
                textBlockInputOutputBlock.FontSize = defaulFontSize;
                textBlockInputOutputBlock.Foreground = Brushes.White;
                textBlockInputOutputBlock.Width = defaultWidth;
                textBlockInputOutputBlock.Height = defaulHeight;
                textBlockInputOutputBlock.TextAlignment = TextAlignment.Center;
                textBlockInputOutputBlock.HorizontalAlignment = HorizontalAlignment.Center;
                textBlockInputOutputBlock.TextWrapping = TextWrapping.Wrap;
                textBlockInputOutputBlock.FontFamily = defaulFontFamily;
                textBlockInputOutputBlock.MouseDown += ChangeTextBoxToTextBlock;

                firstPointToConnect.Fill = (Brush)backgroundColor.ConvertFrom(defaulColorPoint);
                firstPointToConnect.Height = radiusPoint;
                firstPointToConnect.Width = radiusPoint;
                Canvas.SetTop(firstPointToConnect, -2);
                Canvas.SetLeft(firstPointToConnect, defaultWidth / 2);
                firstPointToConnect.MouseDown += GetСoordinatesOfConnectionPoint;

                secondPointToConnect.Fill = (Brush)backgroundColor.ConvertFrom(defaulColorPoint);
                secondPointToConnect.Height = radiusPoint;
                secondPointToConnect.Width = radiusPoint;
                Canvas.SetTop(secondPointToConnect, defaulHeight / 2 - 5);
                Canvas.SetLeft(secondPointToConnect, 8);
                secondPointToConnect.MouseDown += GetСoordinatesOfConnectionPoint;

                thirdPointToConnect.Fill = (Brush)backgroundColor.ConvertFrom(defaulColorPoint);
                thirdPointToConnect.Height = radiusPoint;
                thirdPointToConnect.Width = radiusPoint;
                Canvas.SetTop(thirdPointToConnect, defaulHeight - 3);
                Canvas.SetLeft(thirdPointToConnect, defaultWidth / 2);
                thirdPointToConnect.MouseDown += GetСoordinatesOfConnectionPoint;

                fourthPointToConnect.Fill = (Brush)backgroundColor.ConvertFrom(defaulColorPoint);
                fourthPointToConnect.Height = radiusPoint;
                fourthPointToConnect.Width = radiusPoint;
                Canvas.SetLeft(fourthPointToConnect, defaultWidth - 13);
                Canvas.SetTop(fourthPointToConnect, defaulHeight / 2 - 5);
                fourthPointToConnect.MouseDown += GetСoordinatesOfConnectionPoint;

                canvasInputOutputBlock.Children.Add(polygonInputOutputBlock);
                canvasInputOutputBlock.Children.Add(textBoxInputOutputBlock);
                canvasInputOutputBlock.Children.Add(firstPointToConnect);
                canvasInputOutputBlock.Children.Add(secondPointToConnect);
                canvasInputOutputBlock.Children.Add(thirdPointToConnect);
                canvasInputOutputBlock.Children.Add(fourthPointToConnect);
                canvasInputOutputBlock.MouseMove += MouseMoveBlockForMovements;
            }
            return canvasInputOutputBlock;
        }
        private void GetСoordinatesOfConnectionPoint(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (CoordinatesBlock.coordinatesBlockPointX == 0 && CoordinatesBlock.coordinatesBlockPointY == 0)
                {
                    CoordinatesBlock.coordinatesBlockPointX = Canvas.GetLeft((Ellipse)sender) + Canvas.GetLeft(canvasInputOutputBlock) + 3;
                    CoordinatesBlock.coordinatesBlockPointY = Canvas.GetTop((Ellipse)sender) + Canvas.GetTop(canvasInputOutputBlock) + 3;

                    CoordinatesBlock.keyFirstBlock = keyInputOutputBlock;

                    mainWindow.WriteFirstNameOfBlockToConect(textOfInputOutputBlock);
                }
                else
                {
                    double x1 = CoordinatesBlock.coordinatesBlockPointX;
                    double y1 = CoordinatesBlock.coordinatesBlockPointY;

                    double x2 = Canvas.GetLeft((Ellipse)sender) + Canvas.GetLeft(canvasInputOutputBlock) + 3;
                    double y2 = Canvas.GetTop((Ellipse)sender) + Canvas.GetTop(canvasInputOutputBlock) + 3;

                    CoordinatesBlock.keySecondBlock = keyInputOutputBlock;

                    mainWindow.WriteSecondNameOfBlockToConect(textOfInputOutputBlock);

                    mainWindow.DrawConnectionLine(x1, y1, x2, y2);
                    CoordinatesBlock.coordinatesBlockPointX = 0;
                    CoordinatesBlock.coordinatesBlockPointY = 0;
                }
            }
        }
        private void ChangeTextBoxToTextBlock(object sender, MouseEventArgs e)
        {
            if (canvasInputOutputBlock != null)
            {
                if (textChangeStatus)
                {
                    valueOfClicksOnTextBlock++;
                    if (valueOfClicksOnTextBlock == 2)
                    {
                        canvasInputOutputBlock.Children.Remove(textBoxInputOutputBlock);
                        canvasInputOutputBlock.Children.Remove(textBlockInputOutputBlock);
                        textBoxInputOutputBlock.Text = textBlockInputOutputBlock.Text;
                        canvasInputOutputBlock.Children.Add(textBoxInputOutputBlock);

                        textChangeStatus = false;
                        valueOfClicksOnTextBlock = 0;
                    }
                }
                else
                {
                    canvasInputOutputBlock.Children.Remove(textBoxInputOutputBlock);
                    canvasInputOutputBlock.Children.Remove(textBlockInputOutputBlock);
                    textBlockInputOutputBlock.Text = textBoxInputOutputBlock.Text;
                    Canvas.SetTop(textBlockInputOutputBlock, 3.5);
                    canvasInputOutputBlock.Children.Add(textBlockInputOutputBlock);
                    textChangeStatus = true;
                }
            }
        }
        public void SetWidthAndHeightOfBlock(int valueBlokWidth, int valueBlokHeight)
        {
            if (canvasInputOutputBlock != null)
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
                canvasInputOutputBlock.Width = valueBlokWidth;
                textBoxInputOutputBlock.Width = valueBlokWidth;
                textBlockInputOutputBlock.Width = valueBlokWidth;
                Canvas.SetLeft(firstPointToConnect, valueBlokWidth / 2);
                Canvas.SetLeft(thirdPointToConnect, valueBlokWidth / 2);
                Canvas.SetLeft(fourthPointToConnect, valueBlokWidth - 13);
            }
        }
    }
}