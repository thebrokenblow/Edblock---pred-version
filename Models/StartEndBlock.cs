using System.Windows.Shapes;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Flowchart_Editor.Models
{
    public class StartEndBlock
    {
        private Canvas? canvasStartEndBlock = null;
        private Rectangle? rectangleStartEndBlock = null;
        private TextBox? textOfStartEndBox = null;
        private Ellipse? firstPointToConnect = null;
        private Ellipse? secondPointToConnect = null;
        private Ellipse? thirdPointToConnect = null;
        private Ellipse? fourthPointToConnect = null;


        public UIElement GetUIElementWithoutCreate() => canvasStartEndBlock;


        private void startEndBlock_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var instanceOfStartEndBlock = new StartEndBlockForMovements(sender);
                var dataObjectInformationOfStartEndBlock = new DataObject(typeof(StartEndBlockForMovements), instanceOfStartEndBlock);
                DragDrop.DoDragDrop(sender as DependencyObject, dataObjectInformationOfStartEndBlock, DragDropEffects.Copy);
            }
            e.Handled = true;
        }

        public UIElement GetUIElement()
        {
            if (canvasStartEndBlock == null)
            {
                canvasStartEndBlock = new Canvas();
                rectangleStartEndBlock = new Rectangle();
                textOfStartEndBox = new TextBox();
                firstPointToConnect = new Ellipse();
                secondPointToConnect = new Ellipse();
                thirdPointToConnect = new Ellipse();
                fourthPointToConnect = new Ellipse();

                var backgroundColor = new BrushConverter();
                rectangleStartEndBlock.Fill = (Brush)backgroundColor.ConvertFrom("#FFF25252");
                rectangleStartEndBlock.RadiusX = 25;
                rectangleStartEndBlock.RadiusY = 25;
                rectangleStartEndBlock.Width = 140;
                rectangleStartEndBlock.Height = 60;

                textOfStartEndBox.Text = "Начало";
                textOfStartEndBox.Foreground = Brushes.White;

                firstPointToConnect.Fill = Brushes.Black;
                firstPointToConnect.Height = 6;
                firstPointToConnect.Width = 6;
                firstPointToConnect.Margin = new Thickness(65, -4, 0, 0);

                secondPointToConnect.Fill = Brushes.Black;
                secondPointToConnect.Height = 6;
                secondPointToConnect.Width = 6;
                secondPointToConnect.Margin = new Thickness(-3, 25, 0, 0);


                thirdPointToConnect.Fill = Brushes.Black;
                thirdPointToConnect.Height = 6;
                thirdPointToConnect.Width = 6;
                thirdPointToConnect.Margin = new Thickness(65, 56, 0, 0);

                fourthPointToConnect.Fill = Brushes.Black;
                fourthPointToConnect.Height = 6;
                fourthPointToConnect.Width = 6;
                fourthPointToConnect.Margin = new Thickness(137, 25, 0, 0);

                Canvas.SetLeft(textOfStartEndBox, 47);
                Canvas.SetTop(textOfStartEndBox, 17);
                canvasStartEndBlock.Children.Add(rectangleStartEndBlock);
                canvasStartEndBlock.Children.Add(textOfStartEndBox);
                canvasStartEndBlock.Children.Add(firstPointToConnect);
                canvasStartEndBlock.Children.Add(secondPointToConnect);
                canvasStartEndBlock.Children.Add(thirdPointToConnect);
                canvasStartEndBlock.Children.Add(fourthPointToConnect);
                canvasStartEndBlock.MouseMove += startEndBlock_MouseMove;
            }
            return canvasStartEndBlock;
        }

        public void Reset()
        {
            canvasStartEndBlock = null;
        }
    }
}
