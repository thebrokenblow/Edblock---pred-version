using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Flowchart_Editor.Models
{
    public class ConditionBlock : Window
    {
        public Canvas? canvasConditionBlock = null;
        public Polygon? polygonConditionBlock = null;
        public TextBox? textBoxOfConditionBlock = null;
        public TextBlock? textBlocOfConditionBlock = null;
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
        private const int radiusPoint = 6;

        public UIElement GetUIElementWithoutCreate() => canvasConditionBlock;

        private void conditionBlock_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (textChangeStatus)
                {
                    var instanceOfConditionBlock = new ConditionBlockForMovements(sender);
                    var dataObjectInformationOConditionBlock = new DataObject(typeof(ConditionBlockForMovements), instanceOfConditionBlock);
                    DragDrop.DoDragDrop(sender as DependencyObject, dataObjectInformationOConditionBlock, DragDropEffects.Copy);
                }
            }
            e.Handled = true;
        }

        public UIElement GetUIElement()
        {
            if (canvasConditionBlock == null)
            {
                firstPointToConnect = new Ellipse();
                secondPointToConnect = new Ellipse();
                thirdPointToConnect = new Ellipse();
                fourthPointToConnect = new Ellipse();
                canvasConditionBlock = new Canvas();
                polygonConditionBlock = new Polygon();
                textBoxOfConditionBlock = new TextBox();
                textBlocOfConditionBlock = new TextBlock();

                var backgroundColor = new BrushConverter();
                polygonConditionBlock.Fill = (Brush)backgroundColor.ConvertFrom("#FF60B2D3");
                Point Point1 = new Point(0, defaulHeight / 2);
                Point Point2 = new Point(defaultWidth / 2, defaulHeight);
                Point Point3 = new Point(defaultWidth, defaulHeight / 2);
                Point Point4 = new Point(defaultWidth / 2, 0);
                Point Point5 = new Point(0, defaulHeight / 2);

                PointCollection myPointCollection = new PointCollection();
                myPointCollection.Add(Point1);
                myPointCollection.Add(Point2);
                myPointCollection.Add(Point3);
                myPointCollection.Add(Point4);
                myPointCollection.Add(Point5);

                polygonConditionBlock.Points = myPointCollection;
                canvasConditionBlock.Children.Add(polygonConditionBlock);

                textBoxOfConditionBlock.Text = "Условие";
                textBoxOfConditionBlock.FontSize = defaulFontSize;
                textBoxOfConditionBlock.Width = defaultWidth / 2;
                textBoxOfConditionBlock.Foreground = Brushes.White;
                textBoxOfConditionBlock.FontFamily = defaultFontFamily;
                textBoxOfConditionBlock.HorizontalAlignment = HorizontalAlignment.Center;
                textBoxOfConditionBlock.VerticalAlignment = VerticalAlignment.Center;
                textBoxOfConditionBlock.TextAlignment = TextAlignment.Center;
                textBoxOfConditionBlock.TextWrapping = TextWrapping.Wrap;
                textBoxOfConditionBlock.MouseDoubleClick += changeTextBoxToTextBlock;
                Canvas.SetLeft(textBoxOfConditionBlock, defaultWidth / 2 - (defaultWidth / 4));
                Canvas.SetTop(textBoxOfConditionBlock, defaulHeight / 4);

                textBlocOfConditionBlock.FontSize = defaulFontSize;
                textBlocOfConditionBlock.Width = defaultWidth / 2;
                textBlocOfConditionBlock.Foreground = Brushes.White;
                textBlocOfConditionBlock.FontFamily = defaultFontFamily;
                textBlocOfConditionBlock.HorizontalAlignment = HorizontalAlignment.Center;
                textBlocOfConditionBlock.VerticalAlignment = VerticalAlignment.Center;
                textBlocOfConditionBlock.TextAlignment = TextAlignment.Center;
                textBlocOfConditionBlock.TextWrapping = TextWrapping.Wrap;
                textBlocOfConditionBlock.MouseDown += changeTextBoxToTextBlock;
                Canvas.SetLeft(textBlocOfConditionBlock, defaultWidth / 2 - (defaultWidth / 4));
                Canvas.SetTop(textBlocOfConditionBlock, defaulHeight / 4);

                firstPointToConnect.Fill = (Brush)backgroundColor.ConvertFrom(defaulColorPoint);
                firstPointToConnect.Height = radiusPoint;
                firstPointToConnect.Width = radiusPoint;
                Canvas.SetLeft(firstPointToConnect, defaultWidth / 2 - 3);
                Canvas.SetTop(firstPointToConnect, -2);
                firstPointToConnect.MouseDown += getСoordinatesOfConnectionPoint;

                secondPointToConnect.Fill = (Brush)backgroundColor.ConvertFrom(defaulColorPoint);
                secondPointToConnect.Height = radiusPoint;
                secondPointToConnect.Width = radiusPoint;
                Canvas.SetLeft(secondPointToConnect, -2 + 2);
                Canvas.SetTop(secondPointToConnect, defaulHeight / 2 - 3);
                secondPointToConnect.MouseDown += getСoordinatesOfConnectionPoint;

                thirdPointToConnect.Fill = (Brush)backgroundColor.ConvertFrom(defaulColorPoint);
                thirdPointToConnect.Height = radiusPoint;
                thirdPointToConnect.Width = radiusPoint;
                Canvas.SetLeft(thirdPointToConnect, defaultWidth / 2 - 3);
                Canvas.SetTop(thirdPointToConnect, defaulHeight - 3);
                thirdPointToConnect.MouseDown += getСoordinatesOfConnectionPoint;

                fourthPointToConnect.Fill = (Brush)backgroundColor.ConvertFrom(defaulColorPoint);
                fourthPointToConnect.Height = radiusPoint;
                fourthPointToConnect.Width = radiusPoint;
                Canvas.SetLeft(fourthPointToConnect, defaultWidth - 6);
                Canvas.SetTop(fourthPointToConnect, defaulHeight / 2 - 3);
                fourthPointToConnect.MouseDown += getСoordinatesOfConnectionPoint;

                canvasConditionBlock.Children.Add(textBoxOfConditionBlock);
                canvasConditionBlock.Children.Add(firstPointToConnect);
                canvasConditionBlock.Children.Add(secondPointToConnect);
                canvasConditionBlock.Children.Add(thirdPointToConnect);
                canvasConditionBlock.Children.Add(fourthPointToConnect);
                canvasConditionBlock.MouseMove += conditionBlock_MouseMove;
            }
            return canvasConditionBlock;
        }
        private void getСoordinatesOfConnectionPoint(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (CoordinatesBlock.coordinatesBlockX != 0 && CoordinatesBlock.coordinatesBlockY != 0)
                {
                    if (canvasConditionBlock != null)
                    {      
                        Line connectionLine = new Line();

                        connectionLine.X1 = CoordinatesBlock.coordinatesBlockPointX; 
                        connectionLine.Y1 = CoordinatesBlock.coordinatesBlockPointY;
                        connectionLine.X2 = CoordinatesBlock.coordinatesBlockPointX;
                        connectionLine.Y2 = e.GetPosition(firstPointToConnect).Y + e.GetPosition(canvasConditionBlock).Y;
                        connectionLine.Stroke = Brushes.Black;
                        canvasConditionBlock.Children.Add(connectionLine);
                        
                        CoordinatesBlock.coordinatesBlockX = 0;
                        CoordinatesBlock.coordinatesBlockY = 0;
                    }
                }
                else
                {
                    CoordinatesBlock.coordinatesBlockX = e.GetPosition((Ellipse)sender).X;
                    CoordinatesBlock.coordinatesBlockY = e.GetPosition((Ellipse)sender).Y;
                }
            }
        }
        private void changeTextBoxToTextBlock(object sender, MouseEventArgs e)
        {
            if (textChangeStatus)
            {
                valueOfClicksOnTextBlock++;
                if (valueOfClicksOnTextBlock == 2)
                {
                    canvasConditionBlock.Children.Remove(textBoxOfConditionBlock);
                    canvasConditionBlock.Children.Remove(textBlocOfConditionBlock);
                    textBoxOfConditionBlock.Text = textBlocOfConditionBlock.Text;
                    canvasConditionBlock.Children.Add(textBoxOfConditionBlock);

                    textChangeStatus = false;
                    valueOfClicksOnTextBlock = 0;
                }
            }
            else
            {
                canvasConditionBlock.Children.Remove(textBoxOfConditionBlock);
                canvasConditionBlock.Children.Remove(textBlocOfConditionBlock);
                textBlocOfConditionBlock.Text = textBoxOfConditionBlock.Text;
                canvasConditionBlock.Children.Add(textBlocOfConditionBlock);
                textChangeStatus = true;
            }
        }
        public void Reset()
        {
            canvasConditionBlock = null;
        }
    }
}