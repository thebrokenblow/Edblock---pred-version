using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Flowchart_Editor.Models
{
    public class ActionBlock : Window
    {
        public Canvas? canvasOfActionBlock = null;
        public TextBox? textBoxOfActionBlock = null;
        public TextBlock? textBlockOfActionBlock = null;
        public Ellipse? firstPointToConnect = null;
        public Ellipse? secondPointToConnect = null;
        public Ellipse? thirdPointToConnect = null;
        public Ellipse? fourthPointToConnect = null;
        private bool textChangeStatus = false;
        private int defaultWidth = DefaultPropertyForBlock.width;
        private int defaulHeight = DefaultPropertyForBlock.height;
        private string defaulColorPoint = DefaultPropertyForBlock.colorPoint;
        private int defaulFontSize = DefaultPropertyForBlock.fontSize;
        private FontFamily defaultFontFamily = DefaultPropertyForBlock.fontFamily;
        private int valueOfClicksOnTextBlock = 0;
        private MainWindow mainWindow;
        private const int radiusPoint = 6;
        private int keyOfActionBlock = 0;

        public ActionBlock(MainWindow mainWindow, int keyBlock)
        {
            this.mainWindow = mainWindow;
            keyOfActionBlock = keyBlock;
        }

        public UIElement GetUIElementWithoutCreate() => canvasOfActionBlock;

        private void actionBlockForMovements_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (textChangeStatus)
                {
                    var instanceOfActionBlock = new ActionBlockForMovements(sender);
                    var dataObjectInformationOfActionBlock = new DataObject(typeof(ActionBlockForMovements), instanceOfActionBlock);
                    DragDrop.DoDragDrop(sender as DependencyObject, dataObjectInformationOfActionBlock, DragDropEffects.Copy);
                }
            }
            e.Handled = true;
        }

        public UIElement GetUIElement()
        {
            if (canvasOfActionBlock == null)
            {
                canvasOfActionBlock = new Canvas();
                textBoxOfActionBlock = new TextBox();
                textBlockOfActionBlock = new TextBlock();
                firstPointToConnect = new Ellipse();
                secondPointToConnect = new Ellipse();
                thirdPointToConnect = new Ellipse();
                fourthPointToConnect = new Ellipse();

                textBoxOfActionBlock.Text = "Действие";
                textBoxOfActionBlock.Width = defaultWidth;
                textBoxOfActionBlock.Height = defaulHeight;
                textBoxOfActionBlock.FontSize = defaulFontSize;
                textBoxOfActionBlock.FontFamily = defaultFontFamily;
                textBoxOfActionBlock.VerticalAlignment = VerticalAlignment.Center;
                textBoxOfActionBlock.HorizontalAlignment = HorizontalAlignment.Center;
                textBoxOfActionBlock.TextAlignment = TextAlignment.Center;
                textBoxOfActionBlock.Foreground = Brushes.White;
                textBoxOfActionBlock.TextWrapping = TextWrapping.Wrap;
                textBoxOfActionBlock.MouseDoubleClick += ChangeTextBoxToLabel;

                textBlockOfActionBlock.Width = defaultWidth;
                textBlockOfActionBlock.Height = defaulHeight;
                textBlockOfActionBlock.FontSize = defaulFontSize;
                textBlockOfActionBlock.FontFamily = defaultFontFamily;
                textBlockOfActionBlock.VerticalAlignment = VerticalAlignment.Center;
                textBlockOfActionBlock.HorizontalAlignment = HorizontalAlignment.Center;
                textBlockOfActionBlock.TextAlignment = TextAlignment.Center;
                textBlockOfActionBlock.Foreground = Brushes.White;
                textBlockOfActionBlock.TextWrapping = TextWrapping.Wrap;
                textBlockOfActionBlock.MouseDown += ChangeTextBoxToLabel;

                var backgroundColor = new BrushConverter();
                canvasOfActionBlock.Background = (Brush)backgroundColor.ConvertFrom("#FF52C0AA");
                canvasOfActionBlock.Width = defaultWidth;
                canvasOfActionBlock.Height = defaulHeight;

                firstPointToConnect.Fill = (Brush)backgroundColor.ConvertFrom(defaulColorPoint); 
                firstPointToConnect.Height = radiusPoint;
                firstPointToConnect.Width = radiusPoint;
                Canvas.SetLeft(firstPointToConnect, defaultWidth / 2 - 2);
                Canvas.SetTop(firstPointToConnect,  -2);
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
                Canvas.SetTop(fourthPointToConnect, defaulHeight / 2 -2);
                fourthPointToConnect.MouseDown += GetСoordinatesOfConnectionPoint;

                canvasOfActionBlock.Children.Add(textBoxOfActionBlock);
                canvasOfActionBlock.Children.Add(firstPointToConnect);
                canvasOfActionBlock.Children.Add(secondPointToConnect);
                canvasOfActionBlock.Children.Add(thirdPointToConnect);
                canvasOfActionBlock.Children.Add(fourthPointToConnect);
                canvasOfActionBlock.MouseMove += actionBlockForMovements_MouseMove;
            }
            return canvasOfActionBlock;
        }
        private void GetСoordinatesOfConnectionPoint(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (CoordinatesBlock.coordinatesBlockPointX == 0 && CoordinatesBlock.coordinatesBlockPointY == 0)
                {
                    CoordinatesBlock.coordinatesBlockPointX = Canvas.GetLeft((Ellipse)sender) + Canvas.GetLeft(canvasOfActionBlock) + 3;
                    CoordinatesBlock.coordinatesBlockPointY = Canvas.GetTop((Ellipse)sender) + Canvas.GetTop(canvasOfActionBlock) + 3;

                    CoordinatesBlock.keyFirstBlock = keyOfActionBlock;
                }
                else
                {
                    double x1 = CoordinatesBlock.coordinatesBlockPointX;
                    double y1 = CoordinatesBlock.coordinatesBlockPointY;

                    double x2 = Canvas.GetLeft((Ellipse)sender) + Canvas.GetLeft(canvasOfActionBlock) + 3;
                    double y2 = Canvas.GetTop((Ellipse)sender) + Canvas.GetTop(canvasOfActionBlock) + 3;

                    CoordinatesBlock.keySecondBlock = keyOfActionBlock;

                    mainWindow.DrawConnectionLine(x1, y1, x2, y2);
                    CoordinatesBlock.coordinatesBlockPointX = 0;
                    CoordinatesBlock.coordinatesBlockPointY = 0;
                }
            }
        }
        private void ChangeTextBoxToLabel(object sender, MouseEventArgs e)
        {
            if (textChangeStatus)
            {
                valueOfClicksOnTextBlock++;
                if (valueOfClicksOnTextBlock == 2)
                {
                    canvasOfActionBlock.Children.Remove(textBoxOfActionBlock);
                    canvasOfActionBlock.Children.Remove(textBlockOfActionBlock);
                    textBoxOfActionBlock.Text = textBlockOfActionBlock.Text;
                    canvasOfActionBlock.Children.Add(textBoxOfActionBlock);
                    textChangeStatus = false;
                    valueOfClicksOnTextBlock = 0;
                }
            }
            else
            {
                canvasOfActionBlock.Children.Remove(textBoxOfActionBlock);
                canvasOfActionBlock.Children.Remove(textBlockOfActionBlock);
                textBlockOfActionBlock.Text = textBoxOfActionBlock.Text;
                Canvas.SetTop(textBlockOfActionBlock, 3.5);
                canvasOfActionBlock.Children.Add(textBlockOfActionBlock);
                textChangeStatus = true;
            }
        }

        public void Reset()
        {
            canvasOfActionBlock = null;
        }
    }
}