using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Flowchart_Editor.Models
{
    public class ConditionBlock
    {
        public Canvas? canvasConditionBlock = null;
        public Polygon? polygonConditionBlock = null;
        public TextBox? textBoxOfConditionBlock = null;
        public TextBlock? textBlocOfConditionBlock = null;
        public Ellipse? firstPointToConnect = null;
        public Ellipse? secondPointToConnect = null;
        public Ellipse? thirdPointToConnect = null;
        public Ellipse? fourthPointToConnect = null;
        private int defaultWidth = ActionBlockDefaultProperty.Width;
        private int defaulHeight = ActionBlockDefaultProperty.Height;
        private string defaulColorPoint = ActionBlockDefaultProperty.colorPoint;
        private bool textChangeStatus = true;
        private int valueOfClicksOnTextBlock = 0;
        private bool firstChangeOfTextBoxToTextBlock = false;

        public UIElement GetUIElementWithoutCreate() => canvasConditionBlock;

        private void conditionBlock_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (!textChangeStatus)
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

                //firstPointToConnect.Fill = Brushes.Red;
                //firstPointToConnect.Height = 6;
                //firstPointToConnect.Width = 6;
                //firstPointToConnect.Margin = new Thickness(68, 1, 0, 0); //Переделать под setLeft setTop
                //firstPointToConnect.MouseDown += getСoordinatesOfConnectionPoint;

                //secondPointToConnect.Fill = Brushes.Black;
                //secondPointToConnect.Height = 6;
                //secondPointToConnect.Width = 6;
                //secondPointToConnect.Margin = new Thickness(3, 32, 0, 0);
                //secondPointToConnect.MouseDown += getСoordinatesOfConnectionPoint;


                //thirdPointToConnect.Fill = Brushes.Black;
                //thirdPointToConnect.Height = 6;
                //thirdPointToConnect.Width = 6;
                //thirdPointToConnect.Margin = new Thickness(67, 62, 0, 0);
                //thirdPointToConnect.MouseDown += getСoordinatesOfConnectionPoint;


                //fourthPointToConnect.Fill = Brushes.Black;
                //fourthPointToConnect.Height = 6;
                //fourthPointToConnect.Width = 6;
                //fourthPointToConnect.Margin = new Thickness(135, 32, 0, 0);
                //fourthPointToConnect.MouseDown += getСoordinatesOfConnectionPoint;

                textBoxOfConditionBlock.Text = "Условие";
                textBoxOfConditionBlock.FontSize = 12;
                textBoxOfConditionBlock.Width = defaultWidth / 2;
                textBoxOfConditionBlock.Foreground = Brushes.White;
                textBoxOfConditionBlock.HorizontalAlignment = HorizontalAlignment.Center;
                textBoxOfConditionBlock.VerticalAlignment = VerticalAlignment.Center;
                textBoxOfConditionBlock.TextAlignment = TextAlignment.Center;
                textBoxOfConditionBlock.TextWrapping = TextWrapping.Wrap;
                textBoxOfConditionBlock.MouseDoubleClick += changeTextBoxToTextBlock;
                Canvas.SetLeft(textBoxOfConditionBlock, defaultWidth / 2 - (defaultWidth / 4));
                Canvas.SetTop(textBoxOfConditionBlock, defaulHeight / 4);

                textBlocOfConditionBlock.FontSize = 12;
                textBlocOfConditionBlock.Foreground = Brushes.White;
                textBlocOfConditionBlock.Width = defaultWidth / 2;
                textBlocOfConditionBlock.HorizontalAlignment = HorizontalAlignment.Center;
                textBlocOfConditionBlock.VerticalAlignment = VerticalAlignment.Center;
                textBlocOfConditionBlock.TextAlignment = TextAlignment.Center;
                textBlocOfConditionBlock.TextWrapping = TextWrapping.Wrap;
                textBlocOfConditionBlock.MouseDown += changeTextBoxToTextBlock;
                Canvas.SetLeft(textBlocOfConditionBlock, defaultWidth / 2 - (defaultWidth / 4));
                Canvas.SetTop(textBlocOfConditionBlock, defaulHeight / 4);

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
        private void changeTextBoxToTextBlock(object sender, MouseEventArgs e)
        {
            if (textChangeStatus)
            {
                canvasConditionBlock.Children.Remove(textBoxOfConditionBlock);
                canvasConditionBlock.Children.Remove(textBlocOfConditionBlock);
                textBlocOfConditionBlock.Text = textBoxOfConditionBlock.Text;
                canvasConditionBlock.Children.Add(textBlocOfConditionBlock);
                textChangeStatus = false;
            }
            else
            {
                valueOfClicksOnTextBlock++;
                if (valueOfClicksOnTextBlock == 2)
                {
                    canvasConditionBlock.Children.Remove(textBoxOfConditionBlock);
                    canvasConditionBlock.Children.Remove(textBlocOfConditionBlock);
                    textBoxOfConditionBlock.Text = textBlocOfConditionBlock.Text;
                    canvasConditionBlock.Children.Add(textBoxOfConditionBlock);
                    textChangeStatus = true;
                    valueOfClicksOnTextBlock = 0;
                }
            }
        }
        public void Reset()
        {
            canvasConditionBlock = null;
        }
    }
}