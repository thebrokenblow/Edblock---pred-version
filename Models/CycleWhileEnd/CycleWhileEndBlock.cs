using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Flowchart_Editor.Models
{
    public class CycleWhileEndBlock
    {
        private Canvas? canvasCycleWhileEndBlock = null;
        private Polygon? polygonCycleWhileEndBlock = null;
        private TextBox? textOfCycleWhileEndBlock = null;
        private Ellipse? firstPointToConnect = null;
        private Ellipse? secondPointToConnect = null;
        private Ellipse? thirdPointToConnect = null;
        private Ellipse? fourthPointToConnect = null;

        public UIElement GetUIElementWithoutCreate() => canvasCycleWhileEndBlock;

        private void cycleForBlock_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var instanceOfConditionBlock = new CycleWhileEndBlockForMovements(sender);
                var dataObjectInformationOConditionBlock = new DataObject(typeof(CycleWhileEndBlockForMovements), instanceOfConditionBlock);
                DragDrop.DoDragDrop(sender as DependencyObject, dataObjectInformationOConditionBlock, DragDropEffects.Copy);
            }
            e.Handled = true;
        }

        public UIElement GetUIElement()
        {
            if (canvasCycleWhileEndBlock == null)
            {
                canvasCycleWhileEndBlock = new Canvas();
                polygonCycleWhileEndBlock = new Polygon();
                textOfCycleWhileEndBlock = new TextBox();

                var backgroundColor = new BrushConverter();
                polygonCycleWhileEndBlock.Fill = (Brush)backgroundColor.ConvertFrom("#FFCCCCFF");
                Point Point1 = new Point(10, 10); 
                Point Point2 = new Point(10, 60);
                Point Point3 = new Point(20, 70);
                Point Point4 = new Point(140, 70);
                Point Point5 = new Point(150, 60);
                Point Point6 = new Point(150, 10);
                PointCollection myPointCollection1 = new PointCollection();
                myPointCollection1.Add(Point1);
                myPointCollection1.Add(Point2);
                myPointCollection1.Add(Point3);
                myPointCollection1.Add(Point4);
                myPointCollection1.Add(Point5);
                myPointCollection1.Add(Point6);
                polygonCycleWhileEndBlock.Points = myPointCollection1;
                canvasCycleWhileEndBlock.Children.Add(polygonCycleWhileEndBlock);

                textOfCycleWhileEndBlock.Text = "Цикл for";
                textOfCycleWhileEndBlock.FontSize = 12;
                textOfCycleWhileEndBlock.Foreground = Brushes.White;
                Canvas.SetLeft(textOfCycleWhileEndBlock, 50);
                Canvas.SetTop(textOfCycleWhileEndBlock, 24);
                canvasCycleWhileEndBlock.Children.Add(textOfCycleWhileEndBlock);

                canvasCycleWhileEndBlock.MouseMove += cycleForBlock_MouseMove;
            }
            return canvasCycleWhileEndBlock;
        }

        public void Reset()
        {
            canvasCycleWhileEndBlock = null;
        }
    }
}
