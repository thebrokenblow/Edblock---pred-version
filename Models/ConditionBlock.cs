using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Flowchart_Editor.Models
{
    public class ConditionBlock
    {
        private Canvas? canvasConditionBlock = null;
        private Polygon? polygonConditionBlock = null;
        private TextBox? textOfConditionBlockBox = null;
        private Ellipse? firstPointToConnect = null;
        private Ellipse? secondPointToConnect = null;
        private Ellipse? thirdPointToConnect = null;
        private Ellipse? fourthPointToConnect = null;

        public UIElement GetUIElementWithoutCreate() => canvasConditionBlock;

        private void conditionBlock_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var instanceOfConditionBlock = new ConditionBlockForMovements(sender);
                var dataObjectInformationOConditionBlock = new DataObject(typeof(ConditionBlockForMovements), instanceOfConditionBlock);
                DragDrop.DoDragDrop(sender as DependencyObject, dataObjectInformationOConditionBlock, DragDropEffects.Copy);
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
                textOfConditionBlockBox = new TextBox();

                var backgroundColor = new BrushConverter();
                polygonConditionBlock.Fill = (Brush)backgroundColor.ConvertFrom("#FF60B2D3");
                Point Point1 = new Point(10, 30);
                Point Point2 = new Point(70, 60);
                Point Point3 = new Point(140, 30);
                Point Point4 = new Point(70, 0);
                Point Point5 = new Point(10, 30);

                PointCollection myPointCollection = new PointCollection();
                myPointCollection.Add(Point1);
                myPointCollection.Add(Point2);
                myPointCollection.Add(Point3);
                myPointCollection.Add(Point4);
                myPointCollection.Add(Point5);
              
                polygonConditionBlock.Points = myPointCollection;
                canvasConditionBlock.Children.Add(polygonConditionBlock);

                firstPointToConnect.Fill = Brushes.Red;
                firstPointToConnect.Height = 6;
                firstPointToConnect.Width = 6;
                firstPointToConnect.Margin = new Thickness(68, 1, 0, 0); //Переделать под setLeft setTop
                firstPointToConnect.MouseDown += getСoordinatesOfConnectionPoint;

                secondPointToConnect.Fill = Brushes.Black;
                secondPointToConnect.Height = 6;
                secondPointToConnect.Width = 6;
                secondPointToConnect.Margin = new Thickness(3, 32, 0, 0);
                secondPointToConnect.MouseDown += getСoordinatesOfConnectionPoint;


                thirdPointToConnect.Fill = Brushes.Black;
                thirdPointToConnect.Height = 6;
                thirdPointToConnect.Width = 6;
                thirdPointToConnect.Margin = new Thickness(67, 62, 0, 0);
                thirdPointToConnect.MouseDown += getСoordinatesOfConnectionPoint;


                fourthPointToConnect.Fill = Brushes.Black;
                fourthPointToConnect.Height = 6;
                fourthPointToConnect.Width = 6;
                fourthPointToConnect.Margin = new Thickness(135, 32, 0, 0);
                fourthPointToConnect.MouseDown += getСoordinatesOfConnectionPoint;

                textOfConditionBlockBox.Text = "Условие";
                textOfConditionBlockBox.FontSize = 12;
                textOfConditionBlockBox.Foreground = Brushes.White;

                Canvas.SetLeft(textOfConditionBlockBox, 47);
                Canvas.SetTop(textOfConditionBlockBox, 21);

                canvasConditionBlock.Children.Add(textOfConditionBlockBox);
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
                if (CoordinatesBlock.coordinatesBlockX != null && CoordinatesBlock.coordinatesBlockY != null)
                {
                    if (canvasConditionBlock != null)
                    {
                        
                        Line connectionLine = new Line();
                        connectionLine.X2 = (double)CoordinatesBlock.coordinatesBlockX; 
                        connectionLine.Y2 = (double)CoordinatesBlock.coordinatesBlockY;
                        connectionLine.X1 = e.GetPosition((Ellipse)sender).X;
                        connectionLine.Y1 = e.GetPosition((Ellipse)sender).Y;
                        connectionLine.Stroke = Brushes.Black;
                        
                        canvasConditionBlock.Children.Add(connectionLine);
                        CoordinatesBlock.coordinatesBlockX = null;
                        CoordinatesBlock.coordinatesBlockY = null;
                    }
                }
                else
                {
                    CoordinatesBlock.coordinatesBlockX = e.GetPosition((Ellipse)sender).X;
                    CoordinatesBlock.coordinatesBlockY = e.GetPosition((Ellipse)sender).Y;
                }
            }
        }
        public void Reset()
        {
            canvasConditionBlock = null;
        }
    }
}