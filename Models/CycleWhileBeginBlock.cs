using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Flowchart_Editor.Models
{
    public class CycleWhileBeginBlock
    {
        private Canvas? canvasCycleForBlock = null;
        private Polygon? polygonCycleForBlock = null;
        private TextBox? textOfCycleForBlock = null;
        private Ellipse? firstPointToConnect = null;
        private Ellipse? secondPointToConnect = null;
        private Ellipse? thirdPointToConnect = null;
        private Ellipse? fourthPointToConnect = null;

        public UIElement GetUIElementWithoutCreate() => canvasCycleForBlock;

        private void cycleForBlock_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var instanceOfConditionBlock = new CycleForBlockForMovements(sender);
                var dataObjectInformationOConditionBlock = new DataObject(typeof(CycleForBlockForMovements), instanceOfConditionBlock);
                DragDrop.DoDragDrop(sender as DependencyObject, dataObjectInformationOConditionBlock, DragDropEffects.Copy);
            }
            e.Handled = true;
        }

        public UIElement GetUIElement()
        {
            if (canvasCycleForBlock == null)
            {
                canvasCycleForBlock = new Canvas();
                polygonCycleForBlock = new Polygon();
                textOfCycleForBlock = new TextBox();

                var backgroundColor = new BrushConverter();
                polygonCycleForBlock.Fill = (Brush)backgroundColor.ConvertFrom("#FFCCCCFF");
                Point Point1 = new Point(10, 70);
                Point Point2 = new Point(10, 20);
                Point Point3 = new Point(20, 10);
                Point Point4 = new Point(140, 10);
                Point Point5 = new Point(150, 20);
                Point Point6 = new Point(150, 70);
                PointCollection myPointCollection1 = new PointCollection();
                myPointCollection1.Add(Point1);
                myPointCollection1.Add(Point2);
                myPointCollection1.Add(Point3);
                myPointCollection1.Add(Point4);
                myPointCollection1.Add(Point5);
                myPointCollection1.Add(Point6);
                polygonCycleForBlock.Points = myPointCollection1;
                canvasCycleForBlock.Children.Add(polygonCycleForBlock);

                textOfCycleForBlock.Text = "Цикл for";
                textOfCycleForBlock.FontSize = 12;
                textOfCycleForBlock.Foreground = Brushes.White;
                Canvas.SetLeft(textOfCycleForBlock, 50);
                Canvas.SetTop(textOfCycleForBlock, 24);
                canvasCycleForBlock.Children.Add(textOfCycleForBlock);

                canvasCycleForBlock.MouseMove += cycleForBlock_MouseMove;
            }
            return canvasCycleForBlock;
        }

        public void Reset()
        {
            canvasCycleForBlock = null;
        }
    }
}
