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
        private int defaultWidth = DefaultPropertyForBlock.Width;
        private int defaulHeight = DefaultPropertyForBlock.Height / 2;
        private string defaulColorPoint = DefaultPropertyForBlock.colorPoint;
        private bool textChangeStatus = true;
        private int valueOfClicksOnTextBlock = 0;
        private const int radiusOfRectangleStartEndBlock = 20;

        public UIElement GetUIElementWithoutCreate() => canvasStartEndBlock;

        private void startEndBlock_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (!textChangeStatus)
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

                textBlockOfStartEnd.Text = "Начало";
                textBlockOfStartEnd.Foreground = Brushes.White;
                textBlockOfStartEnd.Width = defaultWidth;
                textBlockOfStartEnd.Height = defaulHeight;
                textBlockOfStartEnd.VerticalAlignment = VerticalAlignment.Center;
                textBlockOfStartEnd.HorizontalAlignment = HorizontalAlignment.Center;
                textBlockOfStartEnd.TextAlignment = TextAlignment.Center;
                textBlockOfStartEnd.Foreground = Brushes.White;
                Canvas.SetTop(textBlockOfStartEnd, 3.5);

                //Canvas.SetLeft(textBoxOfStartEnd, 50); //47


                //textBlockOfStartEnd.Text = "Начало";
                //textBlockOfStartEnd.Foreground = Brushes.White;
                //Canvas.SetLeft(textBlockOfStartEnd, defaultWidth / 2 + defaultWidth / 4 + 5);
                //Canvas.SetTop(textBlockOfStartEnd, 17);

                //firstPointToConnect.Fill = Brushes.Black;
                //firstPointToConnect.Height = 6;
                //firstPointToConnect.Width = 6;
                //firstPointToConnect.Margin = new Thickness(65, -4, 0, 0);

                //secondPointToConnect.Fill = Brushes.Black;
                //secondPointToConnect.Height = 6;
                //secondPointToConnect.Width = 6;
                //secondPointToConnect.Margin = new Thickness(-3, 25, 0, 0);


                //thirdPointToConnect.Fill = Brushes.Black;
                //thirdPointToConnect.Height = 6;
                //thirdPointToConnect.Width = 6;
                //thirdPointToConnect.Margin = new Thickness(65, 56, 0, 0);

                //fourthPointToConnect.Fill = Brushes.Black;
                //fourthPointToConnect.Height = 6;
                //fourthPointToConnect.Width = 6;
                //fourthPointToConnect.Margin = new Thickness(137, 25, 0, 0);

                canvasStartEndBlock.Children.Add(rectangleStartEndBlock);
                canvasStartEndBlock.Children.Add(textBlockOfStartEnd);
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