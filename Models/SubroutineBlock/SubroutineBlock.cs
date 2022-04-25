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
        private readonly int keySubroutineBlock = 0;
        private const string textOfSubroutineBlock = "Подпрограмма";

        public SubroutineBlock(MainWindow mainWindow, int keyBlock)
        {
            this.mainWindow = mainWindow;
            keySubroutineBlock = keyBlock;
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

                canvas.Width = defaultWidth;
                canvas.Height = defaulHeight;
                var backgroundColor = new BrushConverter();
                canvas.Background = (Brush)backgroundColor.ConvertFrom("#FFBA64C8");

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

                textBox.Text = textOfSubroutineBlock;
                textBox.Width = defaultWidth;
                textBox.Height = defaulHeight;
                textBox.FontSize = defaulFontSize;
                textBox.FontFamily = defaultFontFamily;
                textBox.VerticalAlignment = VerticalAlignment.Center;
                textBox.HorizontalAlignment = HorizontalAlignment.Center;
                textBox.TextAlignment = TextAlignment.Center;
                textBox.Foreground = Brushes.White;
                textBox.TextWrapping = TextWrapping.Wrap;
                textBox.MouseDoubleClick += ChangeTextBoxToTextBlock;

                textBlock.Text = textOfSubroutineBlock;
                textBlock.Width = defaultWidth;
                textBlock.Height = defaulHeight;
                textBlock.FontSize = defaulFontSize;
                textBlock.FontFamily = defaultFontFamily;
                textBlock.VerticalAlignment = VerticalAlignment.Center;
                textBlock.HorizontalAlignment = HorizontalAlignment.Center;
                textBlock.TextAlignment = TextAlignment.Center;
                textBlock.Foreground = Brushes.White;
                textBlock.TextWrapping = TextWrapping.Wrap;
                textBlock.MouseDown += ChangeTextBoxToTextBlock;

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
        private void GetСoordinatesOfConnectionPoint(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (CoordinatesBlock.coordinatesBlockPointX == 0 && CoordinatesBlock.coordinatesBlockPointY == 0)
                {
                    CoordinatesBlock.coordinatesBlockPointX = Canvas.GetLeft((Ellipse)sender) + Canvas.GetLeft(canvas) + 3;
                    CoordinatesBlock.coordinatesBlockPointY = Canvas.GetTop((Ellipse)sender) + Canvas.GetTop(canvas) + 3;

                    CoordinatesBlock.keyFirstBlock = keySubroutineBlock;

                    mainWindow.WriteFirstNameOfBlockToConect(textOfSubroutineBlock);
                }
                else
                {
                    double x1 = CoordinatesBlock.coordinatesBlockPointX;
                    double y1 = CoordinatesBlock.coordinatesBlockPointY;

                    double x2 = Canvas.GetLeft((Ellipse)sender) + Canvas.GetLeft(canvas) + 3;
                    double y2 = Canvas.GetTop((Ellipse)sender) + Canvas.GetTop(canvas) + 3;

                    CoordinatesBlock.keySecondBlock = keySubroutineBlock;

                    mainWindow.DrawConnectionLine(x1, y1, x2, y2);

                    mainWindow.WriteSecondNameOfBlockToConect(textOfSubroutineBlock);

                    CoordinatesBlock.coordinatesBlockPointX = 0;
                    CoordinatesBlock.coordinatesBlockPointY = 0;
                }
            }
        }
    }
}