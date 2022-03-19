using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Flowchart_Editor.Models
{
    public class CycleForBlock
    {
        public Canvas? canvasCycleForBlock = null;
        public Polygon? polygonCycleForBlock = null;
        public TextBox? textBoxOfCycleForBlock = null;
        public TextBlock? textBlockOfCycleForBlock = null;
        public Ellipse? firstPointToConnect = null;
        public Ellipse? secondPointToConnect = null;
        public Ellipse? thirdPointToConnect = null;
        public Ellipse? fourthPointToConnect = null;
        private int defaultWidth = DefaultPropertyForBlock.width;
        private int defaulHeight = DefaultPropertyForBlock.height;
        private string defaulColorPoint = DefaultPropertyForBlock.colorPoint;
        private int defaulFontSize = DefaultPropertyForBlock.fontSize;
        private FontFamily defaultFontFamily = DefaultPropertyForBlock.fontFamily;
        private bool textChangeStatus = false;
        private int valueOfClicksOnTextBlock = 0;
        private MainWindow mainWindow;
        private const int radiusPoint = 6;

        public CycleForBlock(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
        }

        public UIElement GetUIElementWithoutCreate() => canvasCycleForBlock;

        private void cycleForBlock_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (textChangeStatus)
                {
                    var instanceOfCycleForBlock = new CycleForBlockForMovements(sender);
                    var dataObjectInformationOfCycleForBlock = new DataObject(typeof(CycleForBlockForMovements), instanceOfCycleForBlock);
                    DragDrop.DoDragDrop(sender as DependencyObject, dataObjectInformationOfCycleForBlock, DragDropEffects.Copy);
                }
            }
            e.Handled = true;
        }

        public UIElement GetUIElement()
        {
            if (canvasCycleForBlock == null)
            {
                canvasCycleForBlock = new Canvas();
                polygonCycleForBlock = new Polygon();
                textBoxOfCycleForBlock = new TextBox();
                textBlockOfCycleForBlock = new TextBlock(); 
                firstPointToConnect = new Ellipse();
                secondPointToConnect = new Ellipse();
                thirdPointToConnect = new Ellipse();
                fourthPointToConnect = new Ellipse();

                var backgroundColor = new BrushConverter();
                polygonCycleForBlock.Fill = (Brush)backgroundColor.ConvertFrom("#FFFFC618");
                Point Point1 = new Point(10, 0);
                Point Point2 = new Point(0, 10);
                Point Point3 = new Point(0, defaulHeight - 10);
                Point Point4 = new Point(10, defaulHeight);
                Point Point5 = new Point(defaultWidth - 10, defaulHeight);
                Point Point6 = new Point(defaultWidth, defaulHeight - 10);
                Point Point7 = new Point(defaultWidth, 10);
                Point Point8 = new Point(defaultWidth - 10, 0);
                PointCollection myPointCollection = new PointCollection();
                myPointCollection.Add(Point1);
                myPointCollection.Add(Point2);
                myPointCollection.Add(Point3);
                myPointCollection.Add(Point4);
                myPointCollection.Add(Point5);
                myPointCollection.Add(Point6);
                myPointCollection.Add(Point7);
                myPointCollection.Add(Point8);
                polygonCycleForBlock.Points = myPointCollection;
                canvasCycleForBlock.Children.Add(polygonCycleForBlock);

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

                textBoxOfCycleForBlock.Text = "Цикл for";
                textBoxOfCycleForBlock.Width = defaultWidth;
                textBoxOfCycleForBlock.Height = defaulHeight;
                textBoxOfCycleForBlock.FontSize = defaulFontSize;
                textBoxOfCycleForBlock.FontFamily = defaultFontFamily;
                textBoxOfCycleForBlock.VerticalAlignment = VerticalAlignment.Center;
                textBoxOfCycleForBlock.HorizontalAlignment = HorizontalAlignment.Center;
                textBoxOfCycleForBlock.TextAlignment = TextAlignment.Center;
                textBoxOfCycleForBlock.Foreground = Brushes.White;
                textBoxOfCycleForBlock.TextWrapping = TextWrapping.Wrap;
                textBoxOfCycleForBlock.MouseDoubleClick += ChangeTextBoxToTextBlock;

                textBlockOfCycleForBlock.Text = "Цикл for";
                textBlockOfCycleForBlock.Width = defaultWidth;
                textBlockOfCycleForBlock.Height = defaulHeight;
                textBlockOfCycleForBlock.FontSize = defaulFontSize;
                textBlockOfCycleForBlock.FontFamily = defaultFontFamily;
                textBlockOfCycleForBlock.VerticalAlignment = VerticalAlignment.Center;
                textBlockOfCycleForBlock.HorizontalAlignment = HorizontalAlignment.Center;
                textBlockOfCycleForBlock.TextAlignment = TextAlignment.Center;
                textBlockOfCycleForBlock.Foreground = Brushes.White;
                textBlockOfCycleForBlock.TextWrapping = TextWrapping.Wrap;
                textBlockOfCycleForBlock.MouseDown += ChangeTextBoxToTextBlock;

                canvasCycleForBlock.Children.Add(textBoxOfCycleForBlock);
                canvasCycleForBlock.Children.Add(firstPointToConnect);
                canvasCycleForBlock.Children.Add(secondPointToConnect);
                canvasCycleForBlock.Children.Add(thirdPointToConnect);
                canvasCycleForBlock.Children.Add(fourthPointToConnect);
                canvasCycleForBlock.MouseMove += cycleForBlock_MouseMove;
            }
            return canvasCycleForBlock;
        }
        private void GetСoordinatesOfConnectionPoint(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (CoordinatesBlock.coordinatesBlockPointX == 0 && CoordinatesBlock.coordinatesBlockPointY == 0)
                {
                    CoordinatesBlock.coordinatesBlockPointX = Canvas.GetLeft((Ellipse)sender) + Canvas.GetLeft(canvasCycleForBlock) + 3;
                    CoordinatesBlock.coordinatesBlockPointY = Canvas.GetTop((Ellipse)sender) + Canvas.GetTop(canvasCycleForBlock) + 3;
                }
                else
                {
                    double x1 = CoordinatesBlock.coordinatesBlockPointX;
                    double y1 = CoordinatesBlock.coordinatesBlockPointY;

                    double x2 = Canvas.GetLeft((Ellipse)sender) + Canvas.GetLeft(canvasCycleForBlock) + 3;
                    double y2 = Canvas.GetTop((Ellipse)sender) + Canvas.GetTop(canvasCycleForBlock) + 3;

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
                    canvasCycleForBlock.Children.Remove(textBoxOfCycleForBlock);
                    canvasCycleForBlock.Children.Remove(textBlockOfCycleForBlock);
                    textBoxOfCycleForBlock.Text = textBlockOfCycleForBlock.Text;
                    canvasCycleForBlock.Children.Add(textBoxOfCycleForBlock);
                    textChangeStatus = false;
                    valueOfClicksOnTextBlock = 0;
                }
            }
            else
            {
                canvasCycleForBlock.Children.Remove(textBoxOfCycleForBlock);
                canvasCycleForBlock.Children.Remove(textBlockOfCycleForBlock);
                textBlockOfCycleForBlock.Text = textBoxOfCycleForBlock.Text;
                Canvas.SetTop(textBlockOfCycleForBlock, 3.5);
                canvasCycleForBlock.Children.Add(textBlockOfCycleForBlock);
                textChangeStatus = true;
            }
        }

        public void Reset()
        {
            canvasCycleForBlock = null;
        }
    }
}