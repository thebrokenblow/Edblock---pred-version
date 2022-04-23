using System.Windows.Shapes;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System;

namespace Flowchart_Editor.Models
{
    public class StartEndBlock : Block
    {
        public Rectangle? rectangleStartEndBlock = null;
        private readonly int defaultWidth = DefaultPropertyForBlock.width;
        private readonly int defaulHeight = DefaultPropertyForBlock.height / 2;
        private readonly MainWindow mainWindow;
        private const int radiusOfRectangleStartEndBlock = 20;
        private const string textOfStartEndBlock = "Начало / Конец";

        public StartEndBlock(MainWindow mainWindow, int keyBlock)
        {
            this.mainWindow = mainWindow;
            keyOfBlock = keyBlock;
        }
        public UIElement GetUIElement()
        {
            if (canvas == null)
            {
                canvas = new Canvas();
                rectangleStartEndBlock = new Rectangle();
                textBox = new TextBox();
                textBlock = new TextBlock();
                firstPointToConnect = new Ellipse();
                secondPointToConnect = new Ellipse();
                thirdPointToConnect = new Ellipse();
                fourthPointToConnect = new Ellipse();

                var backgroundColor = new BrushConverter();
                rectangleStartEndBlock.Fill = (Brush)backgroundColor.ConvertFrom("#FFF25252");
                rectangleStartEndBlock.RadiusX = radiusOfRectangleStartEndBlock;
                rectangleStartEndBlock.RadiusY = radiusOfRectangleStartEndBlock;
                rectangleStartEndBlock.Width = defaultWidth;
                rectangleStartEndBlock.Height = defaulHeight;

                textBox.Text = textOfStartEndBlock;
                textBox.Foreground = Brushes.White;
                textBox.Width = defaultWidth;
                textBox.Height = defaulHeight;
                textBox.FontSize = defaulFontSize;
                textBox.FontFamily = defaultFontFamily;
                textBox.VerticalAlignment = VerticalAlignment.Center;
                textBox.HorizontalAlignment = HorizontalAlignment.Center;
                textBox.TextAlignment = TextAlignment.Center;
                textBox.Foreground = Brushes.White;
                textBox.MouseDoubleClick += ChangeTextBoxToTextBlock;
                Canvas.SetTop(textBlock, 3.5);

                textBlock.Foreground = Brushes.White;
                textBlock.Width = defaultWidth;
                textBlock.Height = defaulHeight;
                textBlock.FontSize = defaulFontSize;
                textBlock.FontFamily = defaultFontFamily;
                textBlock.VerticalAlignment = VerticalAlignment.Center;
                textBlock.HorizontalAlignment = HorizontalAlignment.Center;
                textBlock.TextAlignment = TextAlignment.Center;
                textBlock.Foreground = Brushes.White;
                textBlock.MouseDown += ChangeTextBoxToTextBlock;
                Canvas.SetTop(textBlock, 3.5);

                firstPointToConnect.Fill = (Brush)backgroundColor.ConvertFrom(defaulColorPoint);
                firstPointToConnect.Height = radiusPoint;
                firstPointToConnect.Width = radiusPoint;
                Canvas.SetLeft(firstPointToConnect, defaultWidth / 2 - 2.5);
                Canvas.SetTop(firstPointToConnect, -2);
                firstPointToConnect.MouseDown += GetСoordinatesOfConnectionPoint;
              
                secondPointToConnect.Fill = (Brush)backgroundColor.ConvertFrom(defaulColorPoint);
                secondPointToConnect.Height = radiusPoint;
                secondPointToConnect.Width = radiusPoint;
                Canvas.SetLeft(secondPointToConnect, -2);
                Canvas.SetTop(secondPointToConnect, defaulHeight / 2 - 2.5);
                secondPointToConnect.MouseDown += GetСoordinatesOfConnectionPoint;

                thirdPointToConnect.Fill = (Brush)backgroundColor.ConvertFrom(defaulColorPoint);
                thirdPointToConnect.Height = radiusPoint;
                thirdPointToConnect.Width = radiusPoint;
                Canvas.SetLeft(thirdPointToConnect, defaultWidth / 2 - 2.5);
                Canvas.SetTop(thirdPointToConnect, defaulHeight - 2.5);
                thirdPointToConnect.MouseDown += GetСoordinatesOfConnectionPoint;

                fourthPointToConnect.Fill = (Brush)backgroundColor.ConvertFrom(defaulColorPoint);
                fourthPointToConnect.Height = radiusPoint;
                fourthPointToConnect.Width = radiusPoint;
                Canvas.SetLeft(fourthPointToConnect, defaultWidth - 2.5);
                Canvas.SetTop(fourthPointToConnect, defaulHeight / 2 - 2.5);
                fourthPointToConnect.MouseDown += GetСoordinatesOfConnectionPoint;

                canvas.Children.Add(rectangleStartEndBlock);
                canvas.Children.Add(textBox);
                canvas.Children.Add(firstPointToConnect);
                canvas.Children.Add(secondPointToConnect);
                canvas.Children.Add(thirdPointToConnect);
                canvas.Children.Add(fourthPointToConnect);
                canvas.MouseMove += MouseMoveBlockForMovements;
            }
            return canvas;
        }
        private void GetСoordinatesOfConnectionPoint(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (CoordinatesBlock.coordinatesBlockPointX == 0 && CoordinatesBlock.coordinatesBlockPointY == 0)
                {
                    CoordinatesBlock.coordinatesBlockPointX = Canvas.GetLeft((Ellipse)sender) + Canvas.GetLeft(canvas) + 3;
                    CoordinatesBlock.coordinatesBlockPointY = Canvas.GetTop((Ellipse)sender) + Canvas.GetTop(canvas) + 3;

                    CoordinatesBlock.keyFirstBlock = keyOfBlock;

                    mainWindow.WriteFirstNameOfBlockToConect(textOfStartEndBlock);
                }
                else
                {
                    double x1 = CoordinatesBlock.coordinatesBlockPointX;
                    double y1 = CoordinatesBlock.coordinatesBlockPointY;

                    double x2 = Canvas.GetLeft((Ellipse)sender) + Canvas.GetLeft(canvas) + 3;
                    double y2 = Canvas.GetTop((Ellipse)sender) + Canvas.GetTop(canvas) + 3;

                    CoordinatesBlock.keySecondBlock = keyOfBlock;

                    mainWindow.WriteSecondNameOfBlockToConect(textOfStartEndBlock);

                    mainWindow.DrawConnectionLine(x1, y1, x2, y2);
                    CoordinatesBlock.coordinatesBlockPointX = 0;
                    CoordinatesBlock.coordinatesBlockPointY = 0;
                }
            }
        }
    }
}