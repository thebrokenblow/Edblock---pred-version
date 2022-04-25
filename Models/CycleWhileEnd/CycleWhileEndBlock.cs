using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Flowchart_Editor.Models
{
    public class CycleWhileEndBlock : Block
    {
        public Polygon polygonCycleWhileEndBlock;
        public TextBox textBoxOfCycleWhileEndBlock;
        public TextBlock textBlockOfCycleWhileEndBlock;
        public Ellipse? firstPointToConnect = null;
        public Ellipse? secondPointToConnect = null;
        public Ellipse? thirdPointToConnect = null;
        public Ellipse? fourthPointToConnect = null;
        private readonly int defaultWidth = DefaultPropertyForBlock.width;
        private readonly int defaulHeight = DefaultPropertyForBlock.height;
        private readonly string defaulColorPoint = DefaultPropertyForBlock.colorPoint;
        private readonly int defaulFontSize = DefaultPropertyForBlock.fontSize;
        private readonly FontFamily defaultFontFamily = DefaultPropertyForBlock.fontFamily;
        private bool textChangeStatus = false;
        private int valueOfClicksOnTextBlock = 0;
        private readonly MainWindow mainWindow;
        private const int radiusPoint = 6;
        private readonly int keyCycleWhileEndBlock = 0;
        private const string textOfCycleWhileEndBlock = "Цикл while конец";

        public CycleWhileEndBlock(MainWindow mainWindow, int keyBlock)
        {
            this.mainWindow = mainWindow;
            keyCycleWhileEndBlock = keyBlock;
        }

        public UIElement GetUIElement()
        {
            if (canvas == null)
            {
                canvas = new Canvas();
                polygonCycleWhileEndBlock = new Polygon();
                textBoxOfCycleWhileEndBlock = new TextBox();
                textBlockOfCycleWhileEndBlock = new TextBlock();
                firstPointToConnect = new Ellipse();
                secondPointToConnect = new Ellipse();
                thirdPointToConnect = new Ellipse();
                fourthPointToConnect = new Ellipse();

                var backgroundColor = new BrushConverter();
                polygonCycleWhileEndBlock.Fill = (Brush)backgroundColor.ConvertFrom("#FFCCCCFF");
                Point Point1 = new(0, 0); 
                Point Point2 = new(0, defaulHeight - 10);
                Point Point3 = new(10, defaulHeight);
                Point Point4 = new(defaultWidth - 10, defaulHeight);
                Point Point5 = new(defaultWidth, defaulHeight - 10);
                Point Point6 = new(defaultWidth, 0);
                PointCollection myPointCollection1 = new();
                myPointCollection1.Add(Point1);
                myPointCollection1.Add(Point2);
                myPointCollection1.Add(Point3);
                myPointCollection1.Add(Point4);
                myPointCollection1.Add(Point5);
                myPointCollection1.Add(Point6);
                polygonCycleWhileEndBlock.Points = myPointCollection1;
                canvas.Children.Add(polygonCycleWhileEndBlock);

                firstPointToConnect.Fill = (Brush)backgroundColor.ConvertFrom(defaulColorPoint);
                firstPointToConnect.Height = radiusPoint;
                firstPointToConnect.Width = radiusPoint;
                Canvas.SetLeft(firstPointToConnect, defaultWidth / 2 - 2);
                Canvas.SetTop(firstPointToConnect, -2);
                firstPointToConnect.MouseDown += GetСoordinatesOfConnectionPoint;

                secondPointToConnect.Fill = (Brush)backgroundColor.ConvertFrom(defaulColorPoint);
                secondPointToConnect.Height = radiusPoint;
                secondPointToConnect.Width = radiusPoint;

                Canvas.SetLeft(secondPointToConnect, -2);
                Canvas.SetTop(secondPointToConnect, defaulHeight / 2 - 2);
                secondPointToConnect.MouseDown += GetСoordinatesOfConnectionPoint;

                thirdPointToConnect.Fill = (Brush)backgroundColor.ConvertFrom(defaulColorPoint);
                thirdPointToConnect.Height = radiusPoint;
                thirdPointToConnect.Width = radiusPoint;
                Canvas.SetLeft(thirdPointToConnect, defaultWidth / 2 - 2);
                Canvas.SetTop(thirdPointToConnect, defaulHeight - 3);
                thirdPointToConnect.MouseDown += GetСoordinatesOfConnectionPoint;

                fourthPointToConnect.Fill = (Brush)backgroundColor.ConvertFrom(defaulColorPoint);
                fourthPointToConnect.Height = radiusPoint;
                fourthPointToConnect.Width = radiusPoint;
                Canvas.SetLeft(fourthPointToConnect, defaultWidth - 4);
                Canvas.SetTop(fourthPointToConnect, defaulHeight / 2 - 2);
                fourthPointToConnect.MouseDown += GetСoordinatesOfConnectionPoint;

                textBoxOfCycleWhileEndBlock.Text = textOfCycleWhileEndBlock;
                textBoxOfCycleWhileEndBlock.Width = defaultWidth;
                textBoxOfCycleWhileEndBlock.Height = defaulHeight;
                textBoxOfCycleWhileEndBlock.FontSize = defaulFontSize;
                textBoxOfCycleWhileEndBlock.FontFamily = defaultFontFamily;
                textBoxOfCycleWhileEndBlock.VerticalAlignment = VerticalAlignment.Center;
                textBoxOfCycleWhileEndBlock.HorizontalAlignment = HorizontalAlignment.Center;
                textBoxOfCycleWhileEndBlock.TextAlignment = TextAlignment.Center;
                textBoxOfCycleWhileEndBlock.Foreground = Brushes.White;
                textBoxOfCycleWhileEndBlock.TextWrapping = TextWrapping.Wrap;
                textBoxOfCycleWhileEndBlock.MouseDoubleClick += ChangeTextBoxToTextBlock;

                textBlockOfCycleWhileEndBlock.Text = textOfCycleWhileEndBlock;
                textBlockOfCycleWhileEndBlock.Width = defaultWidth;
                textBlockOfCycleWhileEndBlock.Height = defaulHeight;
                textBlockOfCycleWhileEndBlock.FontSize = defaulFontSize;
                textBlockOfCycleWhileEndBlock.FontFamily = defaultFontFamily;
                textBlockOfCycleWhileEndBlock.VerticalAlignment = VerticalAlignment.Center;
                textBlockOfCycleWhileEndBlock.HorizontalAlignment = HorizontalAlignment.Center;
                textBlockOfCycleWhileEndBlock.TextAlignment = TextAlignment.Center;
                textBlockOfCycleWhileEndBlock.Foreground = Brushes.White;
                textBlockOfCycleWhileEndBlock.TextWrapping = TextWrapping.Wrap;
                textBlockOfCycleWhileEndBlock.MouseDown += ChangeTextBoxToTextBlock;

                canvas.Children.Add(textBoxOfCycleWhileEndBlock);
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

                    CoordinatesBlock.keyFirstBlock = keyCycleWhileEndBlock;

                    mainWindow.WriteFirstNameOfBlockToConect(textOfCycleWhileEndBlock);
                }
                else
                {
                    double x1 = CoordinatesBlock.coordinatesBlockPointX;
                    double y1 = CoordinatesBlock.coordinatesBlockPointY;

                    double x2 = Canvas.GetLeft((Ellipse)sender) + Canvas.GetLeft(canvas) + 3;
                    double y2 = Canvas.GetTop((Ellipse)sender) + Canvas.GetTop(canvas) + 3;

                    CoordinatesBlock.keySecondBlock = keyCycleWhileEndBlock;

                    mainWindow.WriteSecondNameOfBlockToConect(textOfCycleWhileEndBlock);

                    mainWindow.DrawConnectionLine(x1, y1, x2, y2);
                    CoordinatesBlock.coordinatesBlockPointX = 0;
                    CoordinatesBlock.coordinatesBlockPointY = 0;
                }
            }
        }
        private void ChangeTextBoxToTextBlock(object sender, MouseEventArgs e)
        {
            if (canvas != null)
            {
                if (textChangeStatus)
                {
                    valueOfClicksOnTextBlock++;
                    if (valueOfClicksOnTextBlock == 2)
                    {
                        canvas.Children.Remove(textBoxOfCycleWhileEndBlock);
                        canvas.Children.Remove(textBlockOfCycleWhileEndBlock);
                        textBoxOfCycleWhileEndBlock.Text = textBlockOfCycleWhileEndBlock.Text;
                        canvas.Children.Add(textBoxOfCycleWhileEndBlock);
                        textChangeStatus = false;
                        valueOfClicksOnTextBlock = 0;
                    }
                }
                else
                {
                    canvas.Children.Remove(textBoxOfCycleWhileEndBlock);
                    canvas.Children.Remove(textBlockOfCycleWhileEndBlock);
                    textBlockOfCycleWhileEndBlock.Text = textBoxOfCycleWhileEndBlock.Text;
                    Canvas.SetTop(textBlockOfCycleWhileEndBlock, 3.5);
                    canvas.Children.Add(textBlockOfCycleWhileEndBlock);
                    textChangeStatus = true;
                }
            }
        }

        public void SetWidthAndHeightOfBlock(int valueBlokWidth, int valueBlokHeight)
        {
            if (canvas != null)
            {
                Point Point1 = new(0, 0);
                Point Point2 = new(0, valueBlokHeight - 10);
                Point Point3 = new(10, valueBlokHeight);
                Point Point4 = new(valueBlokWidth - 10, valueBlokHeight);
                Point Point5 = new(valueBlokWidth, valueBlokHeight - 10);
                Point Point6 = new(valueBlokWidth, 0);
                PointCollection myPointCollection = new();
                myPointCollection.Add(Point1);
                myPointCollection.Add(Point2);
                myPointCollection.Add(Point3);
                myPointCollection.Add(Point4);
                myPointCollection.Add(Point5);
                myPointCollection.Add(Point6);

                polygonCycleWhileEndBlock.Points = myPointCollection;
                canvas.Width = valueBlokWidth;
                textBoxOfCycleWhileEndBlock.Width = valueBlokWidth;
                textBlockOfCycleWhileEndBlock.Width = valueBlokWidth;
                Canvas.SetLeft(firstPointToConnect, valueBlokWidth / 2 - 2);
                Canvas.SetLeft(thirdPointToConnect, valueBlokWidth / 2 - 2);
                Canvas.SetLeft(fourthPointToConnect, valueBlokWidth - 4);
            }
        }
    }
}