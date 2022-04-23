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
        public Canvas? canvasCycleWhileBeginBlock;
        public Polygon? polygonCycleWhileBeginBlock = null;
        public TextBox? textBoxOfCycleWhileBeginBlock = null;
        public TextBlock? textBlockOfCycleWhileBeginBlock = null;
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
        private readonly int keyCycleWhileBeginBlock = 0;
        private const string textOfCycleForBlock = "Цикл while начало";

        public CycleWhileBeginBlock(MainWindow mainWindow, int keyBlock)
        {
            this.mainWindow = mainWindow;
            keyCycleWhileBeginBlock = keyBlock;
        }

        public UIElement GetUIElement()
        {
            if (canvasCycleWhileBeginBlock == null)
            {
                canvasCycleWhileBeginBlock = new Canvas();
                polygonCycleWhileBeginBlock = new Polygon();
                textBoxOfCycleWhileBeginBlock = new TextBox();
                textBlockOfCycleWhileBeginBlock = new TextBlock();
                firstPointToConnect = new Ellipse();
                secondPointToConnect = new Ellipse();
                thirdPointToConnect = new Ellipse();
                fourthPointToConnect = new Ellipse();

                var backgroundColor = new BrushConverter();
                polygonCycleWhileBeginBlock.Fill = (Brush)backgroundColor.ConvertFrom("#FFCCCCFF");
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
                canvasCycleWhileBeginBlock.Children.Add(polygonCycleWhileBeginBlock);

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

                textBoxOfCycleWhileBeginBlock.Text = textOfCycleForBlock;
                textBoxOfCycleWhileBeginBlock.Width = defaultWidth;
                textBoxOfCycleWhileBeginBlock.Height = defaulHeight;
                textBoxOfCycleWhileBeginBlock.FontSize = defaulFontSize;
                textBoxOfCycleWhileBeginBlock.FontFamily = defaultFontFamily;
                textBoxOfCycleWhileBeginBlock.VerticalAlignment = VerticalAlignment.Center;
                textBoxOfCycleWhileBeginBlock.HorizontalAlignment = HorizontalAlignment.Center;
                textBoxOfCycleWhileBeginBlock.TextAlignment = TextAlignment.Center;
                textBoxOfCycleWhileBeginBlock.Foreground = Brushes.White;
                textBoxOfCycleWhileBeginBlock.TextWrapping = TextWrapping.Wrap;
                textBoxOfCycleWhileBeginBlock.MouseDoubleClick += ChangeTextBoxToTextBlock;

                textBlockOfCycleWhileBeginBlock.Text = textOfCycleForBlock;
                textBlockOfCycleWhileBeginBlock.Width = defaultWidth;
                textBlockOfCycleWhileBeginBlock.Height = defaulHeight;
                textBlockOfCycleWhileBeginBlock.FontSize = defaulFontSize;
                textBlockOfCycleWhileBeginBlock.FontFamily = defaultFontFamily;
                textBlockOfCycleWhileBeginBlock.VerticalAlignment = VerticalAlignment.Center;
                textBlockOfCycleWhileBeginBlock.HorizontalAlignment = HorizontalAlignment.Center;
                textBlockOfCycleWhileBeginBlock.TextAlignment = TextAlignment.Center;
                textBlockOfCycleWhileBeginBlock.Foreground = Brushes.White;
                textBlockOfCycleWhileBeginBlock.TextWrapping = TextWrapping.Wrap;
                textBlockOfCycleWhileBeginBlock.MouseDown += ChangeTextBoxToTextBlock;

                canvasCycleWhileBeginBlock.Children.Add(textBoxOfCycleWhileBeginBlock);
                canvasCycleWhileBeginBlock.Children.Add(firstPointToConnect);
                canvasCycleWhileBeginBlock.Children.Add(secondPointToConnect);
                canvasCycleWhileBeginBlock.Children.Add(thirdPointToConnect);
                canvasCycleWhileBeginBlock.Children.Add(fourthPointToConnect);
                canvasCycleWhileBeginBlock.MouseMove += MouseMoveBlockForMovements;
            }
            return canvasCycleWhileBeginBlock;
        }
        private void GetСoordinatesOfConnectionPoint(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (CoordinatesBlock.coordinatesBlockPointX == 0 && CoordinatesBlock.coordinatesBlockPointY == 0)
                {
                    CoordinatesBlock.coordinatesBlockPointX = Canvas.GetLeft((Ellipse)sender) + Canvas.GetLeft(canvasCycleWhileBeginBlock) + 3;
                    CoordinatesBlock.coordinatesBlockPointY = Canvas.GetTop((Ellipse)sender) + Canvas.GetTop(canvasCycleWhileBeginBlock) + 3;

                    CoordinatesBlock.keyFirstBlock = keyCycleWhileBeginBlock;

                    mainWindow.WriteFirstNameOfBlockToConect(textOfCycleForBlock);
                }
                else
                {
                    double x1 = CoordinatesBlock.coordinatesBlockPointX;
                    double y1 = CoordinatesBlock.coordinatesBlockPointY;

                    double x2 = Canvas.GetLeft((Ellipse)sender) + Canvas.GetLeft(canvasCycleWhileBeginBlock) + 3;
                    double y2 = Canvas.GetTop((Ellipse)sender) + Canvas.GetTop(canvasCycleWhileBeginBlock) + 3;

                    CoordinatesBlock.keySecondBlock = keyCycleWhileBeginBlock;

                    mainWindow.WriteSecondNameOfBlockToConect(textOfCycleForBlock);

                    mainWindow.DrawConnectionLine(x1, y1, x2, y2);
                    CoordinatesBlock.coordinatesBlockPointX = 0;
                    CoordinatesBlock.coordinatesBlockPointY = 0;
                }
            }
        }
        private void ChangeTextBoxToTextBlock(object sender, MouseEventArgs e)
        {
            if (canvasCycleWhileBeginBlock != null && textBoxOfCycleWhileBeginBlock != null && textBlockOfCycleWhileBeginBlock != null)
            {
                if (textChangeStatus)
                {
                    valueOfClicksOnTextBlock++;
                    if (valueOfClicksOnTextBlock == 2)
                    {
                        canvasCycleWhileBeginBlock.Children.Remove(textBoxOfCycleWhileBeginBlock);
                        canvasCycleWhileBeginBlock.Children.Remove(textBlockOfCycleWhileBeginBlock);
                        textBoxOfCycleWhileBeginBlock.Text = textBlockOfCycleWhileBeginBlock.Text;
                        canvasCycleWhileBeginBlock.Children.Add(textBoxOfCycleWhileBeginBlock);
                        textChangeStatus = false;
                        valueOfClicksOnTextBlock = 0;
                    }
                }
                else
                {
                    canvasCycleWhileBeginBlock.Children.Remove(textBoxOfCycleWhileBeginBlock);
                    canvasCycleWhileBeginBlock.Children.Remove(textBlockOfCycleWhileBeginBlock);
                    textBlockOfCycleWhileBeginBlock.Text = textBoxOfCycleWhileBeginBlock.Text;
                    Canvas.SetTop(textBlockOfCycleWhileBeginBlock, 3.5);
                    canvasCycleWhileBeginBlock.Children.Add(textBlockOfCycleWhileBeginBlock);
                    textChangeStatus = true;
                }
            }
        }
        public void SetWidthAndHeightOfBlock(int valueBlokWidth, int valueBlokHeight)
        {
            if (polygonCycleWhileBeginBlock != null && canvasCycleWhileBeginBlock != null && textBoxOfCycleWhileBeginBlock != null && textBlockOfCycleWhileBeginBlock != null)
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
                canvasCycleWhileBeginBlock.Width = valueBlokWidth;
                textBoxOfCycleWhileBeginBlock.Width = valueBlokWidth;
                textBlockOfCycleWhileBeginBlock.Width = valueBlokWidth;
                Canvas.SetLeft(firstPointToConnect, valueBlokWidth / 2 - 2);
                Canvas.SetLeft(thirdPointToConnect, valueBlokWidth / 2 - 2);
                Canvas.SetLeft(fourthPointToConnect, valueBlokWidth - 4);
            }
        }
    }
}
