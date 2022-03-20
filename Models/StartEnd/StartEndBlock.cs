using System.Windows.Shapes;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Flowchart_Editor.Models
{
    public class StartEndBlock
    {
        public Canvas? canvasStartEndBlock = null;
        public Rectangle? rectangleStartEndBlock = null;
        public TextBox? textBoxOfStartEnd = null;
        public TextBlock? textBlockOfStartEnd = null;
        public Ellipse? firstPointToConnect = null;
        public Ellipse? secondPointToConnect = null;
        public Ellipse? thirdPointToConnect = null;
        public Ellipse? fourthPointToConnect = null;
        private int defaultWidth = DefaultPropertyForBlock.width;
        private int defaulHeight = DefaultPropertyForBlock.height / 2;
        private string defaulColorPoint = DefaultPropertyForBlock.colorPoint;
        private int defaulFontSize = DefaultPropertyForBlock.fontSize;
        private FontFamily defaultFontFamily = DefaultPropertyForBlock.fontFamily;
        private bool textChangeStatus = false;
        private int valueOfClicksOnTextBlock = 0;
        private MainWindow mainWindow;
        private const int radiusOfRectangleStartEndBlock = 20;
        private const int radiusPoint = 6;
        private int keyStartEndBlock = 0;

        public StartEndBlock(MainWindow mainWindow, int keyBlock)
        {
            this.mainWindow = mainWindow;
            keyStartEndBlock = keyBlock;
        }

        public UIElement GetUIElementWithoutCreate() => canvasStartEndBlock;

        private void startEndBlock_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (textChangeStatus)
                {
                    var instanceOfStartEndBlock = new StartEndBlockForMovements(sender);
                    var dataObjectInformationOfStartEndBlock = new DataObject(typeof(StartEndBlockForMovements), instanceOfStartEndBlock);
                    DragDrop.DoDragDrop(sender as DependencyObject, dataObjectInformationOfStartEndBlock, DragDropEffects.Copy);
                }
            }
            e.Handled = true;
        }
        public UIElement GetUIElement()
        {
            if (canvasStartEndBlock == null)
            {
                canvasStartEndBlock = new Canvas();
                rectangleStartEndBlock = new Rectangle();
                textBoxOfStartEnd = new TextBox();
                textBlockOfStartEnd = new TextBlock();
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

                textBoxOfStartEnd.Text = "Начало";
                textBoxOfStartEnd.Foreground = Brushes.White;
                textBoxOfStartEnd.Width = defaultWidth;
                textBoxOfStartEnd.Height = defaulHeight;
                textBoxOfStartEnd.FontSize = defaulFontSize;
                textBoxOfStartEnd.FontFamily = defaultFontFamily;
                textBoxOfStartEnd.VerticalAlignment = VerticalAlignment.Center;
                textBoxOfStartEnd.HorizontalAlignment = HorizontalAlignment.Center;
                textBoxOfStartEnd.TextAlignment = TextAlignment.Center;
                textBoxOfStartEnd.Foreground = Brushes.White;
                textBoxOfStartEnd.MouseDoubleClick += ChangeTextBoxToTextBlock;
                Canvas.SetTop(textBlockOfStartEnd, 3.5);

                textBlockOfStartEnd.Foreground = Brushes.White;
                textBlockOfStartEnd.Width = defaultWidth;
                textBlockOfStartEnd.Height = defaulHeight;
                textBlockOfStartEnd.FontSize = defaulFontSize;
                textBlockOfStartEnd.FontFamily = defaultFontFamily;
                textBlockOfStartEnd.VerticalAlignment = VerticalAlignment.Center;
                textBlockOfStartEnd.HorizontalAlignment = HorizontalAlignment.Center;
                textBlockOfStartEnd.TextAlignment = TextAlignment.Center;
                textBlockOfStartEnd.Foreground = Brushes.White;
                textBlockOfStartEnd.MouseDown += ChangeTextBoxToTextBlock;
                Canvas.SetTop(textBlockOfStartEnd, 3.5);

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

                canvasStartEndBlock.Children.Add(rectangleStartEndBlock);
                canvasStartEndBlock.Children.Add(textBoxOfStartEnd);
                canvasStartEndBlock.Children.Add(firstPointToConnect);
                canvasStartEndBlock.Children.Add(secondPointToConnect);
                canvasStartEndBlock.Children.Add(thirdPointToConnect);
                canvasStartEndBlock.Children.Add(fourthPointToConnect);
                canvasStartEndBlock.MouseMove += startEndBlock_MouseMove;
            }
            return canvasStartEndBlock;
        }
        private void GetСoordinatesOfConnectionPoint(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (CoordinatesBlock.coordinatesBlockPointX == 0 && CoordinatesBlock.coordinatesBlockPointY == 0)
                {
                    CoordinatesBlock.coordinatesBlockPointX = Canvas.GetLeft((Ellipse)sender) + Canvas.GetLeft(canvasStartEndBlock) + 3;
                    CoordinatesBlock.coordinatesBlockPointY = Canvas.GetTop((Ellipse)sender) + Canvas.GetTop(canvasStartEndBlock) + 3;

                    CoordinatesBlock.keyFirstBlock = keyStartEndBlock;
                }
                else
                {
                    double x1 = CoordinatesBlock.coordinatesBlockPointX;
                    double y1 = CoordinatesBlock.coordinatesBlockPointY;

                    double x2 = Canvas.GetLeft((Ellipse)sender) + Canvas.GetLeft(canvasStartEndBlock) + 3;
                    double y2 = Canvas.GetTop((Ellipse)sender) + Canvas.GetTop(canvasStartEndBlock) + 3;

                    CoordinatesBlock.keySecondBlock = keyStartEndBlock;

                    mainWindow.DrawConnectionLine(x1, y1, x2, y2);
                    CoordinatesBlock.coordinatesBlockPointX = 0;
                    CoordinatesBlock.coordinatesBlockPointY = 0;
                }
            }
        }
        private void ChangeTextBoxToTextBlock(object sender, MouseEventArgs e)
        {
            if (textChangeStatus)
            {
                valueOfClicksOnTextBlock++;
                if (valueOfClicksOnTextBlock == 2)
                {
                    canvasStartEndBlock.Children.Remove(textBoxOfStartEnd);
                    canvasStartEndBlock.Children.Remove(textBlockOfStartEnd);
                    textBoxOfStartEnd.Text = textBlockOfStartEnd.Text;
                    canvasStartEndBlock.Children.Add(textBoxOfStartEnd);
                    textChangeStatus = false;
                    valueOfClicksOnTextBlock = 0;
                }
            }
            else
            {
                canvasStartEndBlock.Children.Remove(textBoxOfStartEnd);
                canvasStartEndBlock.Children.Remove(textBoxOfStartEnd);
                textBlockOfStartEnd.Text = textBoxOfStartEnd.Text;
                canvasStartEndBlock.Children.Add(textBlockOfStartEnd);
                textChangeStatus = true;
            }
        }
        public void Reset()
        {
            canvasStartEndBlock = null;
        }
    }
}