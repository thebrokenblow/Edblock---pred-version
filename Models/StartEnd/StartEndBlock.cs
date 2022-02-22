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
        private int defaultWidth = DefaultPropertyForBlock.width;
        private int defaulHeight = DefaultPropertyForBlock.height / 2;
        private string defaulColorPoint = DefaultPropertyForBlock.colorPoint;
        private int defaulFontSize = DefaultPropertyForBlock.fontSize;
        private FontFamily defaultFontFamily = DefaultPropertyForBlock.fontFamily;
        private bool textChangeStatus = false;
        private int valueOfClicksOnTextBlock = 0;
        private const int radiusOfRectangleStartEndBlock = 20;

        public UIElement GetUIElementWithoutCreate() => canvasStartEndBlock;

        private void startEndBlock_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (textChangeStatus)
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

                textBoxOfStartEnd.Text = "Начало";
                textBoxOfStartEnd.Foreground = Brushes.White;
                textBoxOfStartEnd.Width = defaultWidth;
                textBoxOfStartEnd.Height = defaulHeight;
                textBoxOfStartEnd.FontSize = defaulFontSize;
                textBoxOfStartEnd.FontFamily = defaultFontFamily;
                textBoxOfStartEnd.VerticalAlignment = VerticalAlignment.Center;
                textBoxOfStartEnd.HorizontalAlignment = HorizontalAlignment.Center;
                textBoxOfStartEnd.TextAlignment = TextAlignment.Center;
                textBoxOfStartEnd.Foreground = Brushes.White;
                textBoxOfStartEnd.MouseDoubleClick += changeTextBoxToTextBlock;
                Canvas.SetTop(textBlockOfStartEnd, 3.5);

                textBlockOfStartEnd.Foreground = Brushes.White;
                textBlockOfStartEnd.Width = defaultWidth;
                textBlockOfStartEnd.Height = defaulHeight;
                textBlockOfStartEnd.FontSize = defaulFontSize;
                textBlockOfStartEnd.FontFamily = defaultFontFamily;
                textBlockOfStartEnd.VerticalAlignment = VerticalAlignment.Center;
                textBlockOfStartEnd.HorizontalAlignment = HorizontalAlignment.Center;
                textBlockOfStartEnd.TextAlignment = TextAlignment.Center;
                textBlockOfStartEnd.Foreground = Brushes.White;
                textBlockOfStartEnd.MouseDown += changeTextBoxToTextBlock;
                Canvas.SetTop(textBlockOfStartEnd, 3.5);

                firstPointToConnect.Fill = (Brush)backgroundColor.ConvertFrom(defaulColorPoint);
                firstPointToConnect.Height = 6;
                firstPointToConnect.Width = 6;
                Canvas.SetLeft(firstPointToConnect, defaultWidth / 2 - 2.5);
                Canvas.SetTop(firstPointToConnect, -2);
              
                secondPointToConnect.Fill = (Brush)backgroundColor.ConvertFrom(defaulColorPoint);
                secondPointToConnect.Height = 6;
                secondPointToConnect.Width = 6;
                Canvas.SetLeft(secondPointToConnect, -2);
                Canvas.SetTop(secondPointToConnect, defaulHeight / 2 - 2.5);

                thirdPointToConnect.Fill = (Brush)backgroundColor.ConvertFrom(defaulColorPoint);
                thirdPointToConnect.Height = 6;
                thirdPointToConnect.Width = 6;
                Canvas.SetLeft(thirdPointToConnect, defaultWidth / 2 - 2.5);
                Canvas.SetTop(thirdPointToConnect, defaulHeight - 2.5);

                fourthPointToConnect.Fill = (Brush)backgroundColor.ConvertFrom(defaulColorPoint);
                fourthPointToConnect.Height = 6;
                fourthPointToConnect.Width = 6;
                Canvas.SetLeft(fourthPointToConnect, defaultWidth - 2.5);
                Canvas.SetTop(fourthPointToConnect, defaulHeight / 2 - 2.5);

                canvasStartEndBlock.Children.Add(rectangleStartEndBlock);
                canvasStartEndBlock.Children.Add(textBoxOfStartEnd);
                canvasStartEndBlock.Children.Add(firstPointToConnect);
                canvasStartEndBlock.Children.Add(secondPointToConnect);
                canvasStartEndBlock.Children.Add(thirdPointToConnect);
                canvasStartEndBlock.Children.Add(fourthPointToConnect);
                canvasStartEndBlock.MouseMove += startEndBlock_MouseMove;
            }
            return canvasStartEndBlock;
        }
        private void changeTextBoxToTextBlock(object sender, MouseEventArgs e)
        {
            if (!textChangeStatus)
            {
                canvasStartEndBlock.Children.Remove(textBoxOfStartEnd);
                canvasStartEndBlock.Children.Remove(textBoxOfStartEnd);
                textBlockOfStartEnd.Text = textBoxOfStartEnd.Text;
                canvasStartEndBlock.Children.Add(textBlockOfStartEnd);
                textChangeStatus = true;
            }
            else
            {
                valueOfClicksOnTextBlock++;
                if (valueOfClicksOnTextBlock == 2)
                {
                    canvasStartEndBlock.Children.Remove(textBoxOfStartEnd);
                    canvasStartEndBlock.Children.Remove(textBlockOfStartEnd);
                    textBoxOfStartEnd.Text = textBlockOfStartEnd.Text;
                    canvasStartEndBlock.Children.Add(textBoxOfStartEnd);
                    textChangeStatus = false;
                    valueOfClicksOnTextBlock = 0;
                }
            }
        }
        public void Reset()
        {
            canvasStartEndBlock = null;
        }
    }
}