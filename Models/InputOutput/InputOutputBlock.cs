using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Flowchart_Editor.Models
{
    public class InputOutputBlock
    {
        public Canvas? canvasInputOutputBlock = null;
        public Polygon? polygonInputOutputBlock = null;
        public TextBox? textBoxInputOutputBlock = null;
        public TextBlock? textBlockInputOutputBlock = null;
        public Ellipse? firstPointToConnect = null;
        public Ellipse? secondPointToConnect = null;
        public Ellipse? thirdPointToConnect = null;
        public Ellipse? fourthPointToConnect = null;
        private bool textChangeStatus = false;
        private int defaultWidth = DefaultPropertyForBlock.width;
        private int defaulHeight = DefaultPropertyForBlock.height;
        private string defaulColorPoint = DefaultPropertyForBlock.colorPoint;
        private FontFamily defaulFontFamily = DefaultPropertyForBlock.fontFamily;
        private int defaulFontSize = DefaultPropertyForBlock.fontSize;
        private int valueOfClicksOnTextBlock = 0;
        private MainWindow mainWindow;
        private const int radiusPoint = 6;
        private int keyInputOutputBlock = 0;
        private const string textOfInputOutputBlock = "Ввод/Вывод";

        public InputOutputBlock(MainWindow mainWindow, int keyBlock)
        {
            this.mainWindow = mainWindow;
            keyInputOutputBlock = keyBlock;
        }

        public UIElement GetUIElementWithoutCreate() => canvasInputOutputBlock;
        private void inputOutputBlock_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (textChangeStatus)
                {
                    var instanceOfInputOutputBlock = new InputOutputBlockForMovements(sender);
                    var dataObjectInformationOfStartEndBlock = new DataObject(typeof(InputOutputBlockForMovements), instanceOfInputOutputBlock);
                    DragDrop.DoDragDrop(sender as DependencyObject, dataObjectInformationOfStartEndBlock, DragDropEffects.Copy);
                }
            }
            e.Handled = true;
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

                Point Point1 = new Point(20, 0);
                Point Point2 = new Point(0, defaulHeight);
                Point Point3 = new Point(defaultWidth - 20, defaulHeight);
                Point Point4 = new Point(defaultWidth, 0);

                PointCollection myPointCollection = new PointCollection();
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
                canvasInputOutputBlock.MouseMove += inputOutputBlock_MouseMove;
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
        public void Reset()
        {
            canvasInputOutputBlock = null;
        }
    }
}