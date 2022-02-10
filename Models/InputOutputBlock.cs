using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Flowchart_Editor.Models
{
    public class InputOutputBlock
    {
        private Canvas? canvasInputOutputBlock = null;
        private Polygon? polygonInputOutputBlock = null;
        private TextBox? textInputOutputkBox = null;
        private Ellipse? firstPointToConnect = null;
        private Ellipse? secondPointToConnect = null;
        private Ellipse? thirdPointToConnect = null;
        private Ellipse? fourthPointToConnect = null;

        public UIElement GetUIElementWithoutCreate() => canvasInputOutputBlock;


        private void inputOutputBlock_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var instanceOfInputOutputBlock = new InputOutputBlockForMovements(sender);
                var dataObjectInformationOfStartEndBlock = new DataObject(typeof(InputOutputBlockForMovements), instanceOfInputOutputBlock);
                DragDrop.DoDragDrop(sender as DependencyObject, dataObjectInformationOfStartEndBlock, DragDropEffects.Copy);
            }
            e.Handled = true;
        }

        public UIElement GetUIElement()
        {
            if (canvasInputOutputBlock == null)
            {
                canvasInputOutputBlock = new Canvas();
                polygonInputOutputBlock = new Polygon();
                textInputOutputkBox = new TextBox();
                firstPointToConnect = new Ellipse();
                secondPointToConnect = new Ellipse();
                thirdPointToConnect = new Ellipse();
                fourthPointToConnect = new Ellipse();

                var backgroundColor = new BrushConverter();
                polygonInputOutputBlock.Fill = (Brush)backgroundColor.ConvertFrom("#FF05273C");

                Point Point1 = new Point(30, 10);
                Point Point2 = new Point(10, 60);
                Point Point3 = new Point(120, 60);
                Point Point4 = new Point(140, 10);

                PointCollection myPointCollection = new PointCollection();
                myPointCollection.Add(Point1);
                myPointCollection.Add(Point2);
                myPointCollection.Add(Point3);
                myPointCollection.Add(Point4);

                polygonInputOutputBlock.Points = myPointCollection;
                

                textInputOutputkBox.Text = "Ввод/Вывод";
                textInputOutputkBox.FontSize = 12;
                textInputOutputkBox.Foreground = Brushes.White;
                Canvas.SetTop(textInputOutputkBox, 25);
                Canvas.SetLeft(textInputOutputkBox, 37);

                firstPointToConnect.Fill = Brushes.Black;
                firstPointToConnect.Height = 6;
                firstPointToConnect.Width = 6;
                firstPointToConnect.Margin = new Thickness(60, 5, 0, 0);

                secondPointToConnect.Fill = Brushes.Black;
                secondPointToConnect.Height = 6;
                secondPointToConnect.Width = 6;
                secondPointToConnect.Margin = new Thickness(18, 35, 0, 0);


                thirdPointToConnect.Fill = Brushes.Black;
                thirdPointToConnect.Height = 6;
                thirdPointToConnect.Width = 6;
                thirdPointToConnect.Margin = new Thickness(80, 66, 0, 0);

                fourthPointToConnect.Fill = Brushes.Black;
                fourthPointToConnect.Height = 6;
                fourthPointToConnect.Width = 6;
                fourthPointToConnect.Margin = new Thickness(120, 35, 0, 0);

                canvasInputOutputBlock.Children.Add(polygonInputOutputBlock);
                canvasInputOutputBlock.Children.Add(textInputOutputkBox);
                canvasInputOutputBlock.Children.Add(firstPointToConnect);
                canvasInputOutputBlock.Children.Add(secondPointToConnect);
                canvasInputOutputBlock.Children.Add(thirdPointToConnect);
                canvasInputOutputBlock.Children.Add(fourthPointToConnect);
                canvasInputOutputBlock.MouseMove += inputOutputBlock_MouseMove;
            }
            return canvasInputOutputBlock;
        }

        public void Reset()
        {
            canvasInputOutputBlock = null;
        }
    }
}