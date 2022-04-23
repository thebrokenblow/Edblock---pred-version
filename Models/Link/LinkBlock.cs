using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Flowchart_Editor.Models
{
    public class LinkBlock : Block
    {
        public Canvas? canvasLinkBlock;
        public Ellipse eliposLinkBlock;
        public TextBox textBoxOfLinkBlock;
        public TextBlock textBlockOfLinkBlock;
        public Ellipse firstPointToConnect;
        public Ellipse secondPointToConnect;
        public Ellipse thirdPointToConnect;
        public Ellipse fourthPointToConnect;
        private bool textChangeStatus = false;
        private readonly int defaultWidth = DefaultPropertyForBlock.height / 2;
        private readonly int defaulHeight = DefaultPropertyForBlock.height / 2;
        private readonly string defaulColorPoint = DefaultPropertyForBlock.colorPoint;
        private readonly FontFamily defaulFontFamily = DefaultPropertyForBlock.fontFamily;
        private readonly int defaulFontSize = DefaultPropertyForBlock.fontSize;
        private int valueOfClicksOnTextBlock = 0;
        private readonly MainWindow mainWindow;
        private const int radiusPoint = 6;
        private readonly int keyLinkBlock = 0;
        private const string textOfLinkBlock = "Ссылка";

        public LinkBlock(MainWindow mainWindow, int keyBlock)
        {
            this.mainWindow = mainWindow;
            keyLinkBlock = keyBlock;
        }

        public UIElement GetUIElement()
        {
            if (canvasLinkBlock == null)
            {
                canvasLinkBlock = new Canvas();
                eliposLinkBlock = new Ellipse();
                textBoxOfLinkBlock = new TextBox();
                textBlockOfLinkBlock = new TextBlock();
                firstPointToConnect = new Ellipse();
                secondPointToConnect = new Ellipse();
                thirdPointToConnect = new Ellipse();
                fourthPointToConnect = new Ellipse();

                canvasLinkBlock.Width = defaultWidth;
                canvasLinkBlock.Width = defaulHeight;
                eliposLinkBlock.Width = defaultWidth;
                eliposLinkBlock.Height = defaulHeight;
                var backgroundColor = new BrushConverter();
                eliposLinkBlock.Fill = (Brush)backgroundColor.ConvertFrom("#5761A8");

                textBoxOfLinkBlock.Width = defaultWidth;
                textBoxOfLinkBlock.Height = defaulHeight - 5;
                textBoxOfLinkBlock.FontSize = defaulFontSize;
                textBoxOfLinkBlock.FontFamily = defaulFontFamily;
                textBoxOfLinkBlock.Foreground = Brushes.White;
                textBoxOfLinkBlock.TextWrapping = TextWrapping.Wrap;
                textBoxOfLinkBlock.VerticalAlignment = VerticalAlignment.Center;
                textBoxOfLinkBlock.HorizontalAlignment = HorizontalAlignment.Center;
                textBoxOfLinkBlock.TextAlignment = TextAlignment.Center;
                textBoxOfLinkBlock.MouseDoubleClick += ChangeTextBoxToTextBlock;
                Canvas.SetTop(textBoxOfLinkBlock, 5);

                textBlockOfLinkBlock.Width = defaultWidth;
                textBlockOfLinkBlock.Height = defaulHeight - 5;
                textBlockOfLinkBlock.FontSize = defaulFontSize;
                textBlockOfLinkBlock.FontFamily = defaulFontFamily;
                textBlockOfLinkBlock.Foreground = Brushes.White;
                textBlockOfLinkBlock.TextWrapping = TextWrapping.Wrap;
                textBlockOfLinkBlock.VerticalAlignment = VerticalAlignment.Center;
                textBlockOfLinkBlock.HorizontalAlignment = HorizontalAlignment.Center;
                textBlockOfLinkBlock.TextAlignment = TextAlignment.Center;
                textBlockOfLinkBlock.MouseDown += ChangeTextBoxToTextBlock;
                Canvas.SetTop(textBlockOfLinkBlock, 5);

                firstPointToConnect.Fill = (Brush)backgroundColor.ConvertFrom(defaulColorPoint);
                firstPointToConnect.Height = radiusPoint;
                firstPointToConnect.Width = radiusPoint;
                Canvas.SetLeft(firstPointToConnect, defaultWidth / 2 - 3);
                Canvas.SetTop(firstPointToConnect, -2);
                firstPointToConnect.MouseDown += GetСoordinatesOfConnectionPoint;

                secondPointToConnect.Fill = (Brush)backgroundColor.ConvertFrom(defaulColorPoint);
                secondPointToConnect.Height = radiusPoint;
                secondPointToConnect.Width = radiusPoint;
                Canvas.SetLeft(secondPointToConnect, -2);
                Canvas.SetTop(secondPointToConnect, defaulHeight / 2 - 3);
                secondPointToConnect.MouseDown += GetСoordinatesOfConnectionPoint;

                thirdPointToConnect.Fill = (Brush)backgroundColor.ConvertFrom(defaulColorPoint);
                thirdPointToConnect.Height = radiusPoint;
                thirdPointToConnect.Width = radiusPoint;
                Canvas.SetLeft(thirdPointToConnect, defaultWidth / 2 - 3);
                Canvas.SetTop(thirdPointToConnect, defaulHeight - 3);
                thirdPointToConnect.MouseDown += GetСoordinatesOfConnectionPoint;

                fourthPointToConnect.Fill = (Brush)backgroundColor.ConvertFrom(defaulColorPoint);
                fourthPointToConnect.Height = radiusPoint;
                fourthPointToConnect.Width = radiusPoint;
                Canvas.SetLeft(fourthPointToConnect, defaultWidth - 3);
                Canvas.SetTop(fourthPointToConnect, defaulHeight / 2 - 3);
                fourthPointToConnect.MouseDown += GetСoordinatesOfConnectionPoint;

                canvasLinkBlock.Children.Add(eliposLinkBlock);
                canvasLinkBlock.Children.Add(textBoxOfLinkBlock);
                canvasLinkBlock.Children.Add(firstPointToConnect);
                canvasLinkBlock.Children.Add(secondPointToConnect);
                canvasLinkBlock.Children.Add(thirdPointToConnect);
                canvasLinkBlock.Children.Add(fourthPointToConnect);
                canvasLinkBlock.MouseMove += MouseMoveBlockForMovements;
            }
            return canvasLinkBlock;
        }
        private void GetСoordinatesOfConnectionPoint(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (CoordinatesBlock.coordinatesBlockPointX == 0 && CoordinatesBlock.coordinatesBlockPointY == 0)
                {
                    CoordinatesBlock.coordinatesBlockPointX = Canvas.GetLeft((Ellipse)sender) + Canvas.GetLeft(canvasLinkBlock) + 3;
                    CoordinatesBlock.coordinatesBlockPointY = Canvas.GetTop((Ellipse)sender) + Canvas.GetTop(canvasLinkBlock) + 3;

                    CoordinatesBlock.keyFirstBlock = keyLinkBlock;

                    mainWindow.WriteFirstNameOfBlockToConect(textOfLinkBlock);
                }
                else
                {
                    double x1 = CoordinatesBlock.coordinatesBlockPointX;
                    double y1 = CoordinatesBlock.coordinatesBlockPointY;

                    double x2 = Canvas.GetLeft((Ellipse)sender) + Canvas.GetLeft(canvasLinkBlock) + 3;
                    double y2 = Canvas.GetTop((Ellipse)sender) + Canvas.GetTop(canvasLinkBlock) + 3;

                    CoordinatesBlock.keySecondBlock = keyLinkBlock;

                    mainWindow.WriteSecondNameOfBlockToConect(textOfLinkBlock);

                    mainWindow.DrawConnectionLine(x1, y1, x2, y2);
                    CoordinatesBlock.coordinatesBlockPointX = 0;
                    CoordinatesBlock.coordinatesBlockPointY = 0;
                }
            }
        }
        private void ChangeTextBoxToTextBlock(object sender, MouseEventArgs e)
        {
            if (canvasLinkBlock != null)
            {
                if (textChangeStatus)
                {
                    valueOfClicksOnTextBlock++;
                    if (valueOfClicksOnTextBlock == 2)
                    {
                        canvasLinkBlock.Children.Remove(textBoxOfLinkBlock);
                        canvasLinkBlock.Children.Remove(textBlockOfLinkBlock);
                        textBoxOfLinkBlock.Text = textBlockOfLinkBlock.Text;
                        //Canvas.SetTop(textBoxOfLinkBlockBox, 2.5);
                        canvasLinkBlock.Children.Add(textBoxOfLinkBlock);
                        textChangeStatus = false;
                        valueOfClicksOnTextBlock = 0;
                    }
                }
                else
                {
                    canvasLinkBlock.Children.Remove(textBoxOfLinkBlock);
                    canvasLinkBlock.Children.Remove(textBlockOfLinkBlock);
                    textBlockOfLinkBlock.Text = textBoxOfLinkBlock.Text;
                    Canvas.SetTop(textBlockOfLinkBlock, 5.5);
                    canvasLinkBlock.Children.Add(textBlockOfLinkBlock);
                    textChangeStatus = true;
                }
            }
        }

        public void SetHeightOfBlock(int valueBlokHeight)
        {
            if (canvasLinkBlock != null)
            {
                canvasLinkBlock.Width = valueBlokHeight / 2;
                canvasLinkBlock.Height = valueBlokHeight / 2;

                eliposLinkBlock.Height = valueBlokHeight / 2;
                eliposLinkBlock.Width = valueBlokHeight / 2;

                textBoxOfLinkBlock.Width = valueBlokHeight / 2;
                textBoxOfLinkBlock.Height = valueBlokHeight / 2 - 2.5;

                textBlockOfLinkBlock.Width = valueBlokHeight / 2;
                textBlockOfLinkBlock.Height = valueBlokHeight / 2 - 2.5;

                Canvas.SetLeft(firstPointToConnect, valueBlokHeight / 4 - 3);
                Canvas.SetTop(firstPointToConnect, -2);

                Canvas.SetLeft(secondPointToConnect, -2);
                Canvas.SetTop(secondPointToConnect, valueBlokHeight / 4 - 3);

                Canvas.SetLeft(thirdPointToConnect, valueBlokHeight / 4 - 3);
                Canvas.SetTop(thirdPointToConnect, valueBlokHeight / 2 - 3);

                Canvas.SetLeft(fourthPointToConnect, valueBlokHeight / 2 - 3);
                Canvas.SetTop(fourthPointToConnect, valueBlokHeight / 4 - 3);
            }
        }
    }
}