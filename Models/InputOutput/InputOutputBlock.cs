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

                textBoxInputOutputBlock.Text = "Ввод/Вывод";
                textBoxInputOutputBlock.FontSize = defaulFontSize;
                textBoxInputOutputBlock.Foreground = Brushes.White;
                textBoxInputOutputBlock.Width = defaultWidth;
                textBoxInputOutputBlock.Height = defaulHeight;
                textBoxInputOutputBlock.TextAlignment = TextAlignment.Center;
                textBoxInputOutputBlock.HorizontalAlignment = HorizontalAlignment.Center;
                textBoxInputOutputBlock.TextWrapping = TextWrapping.Wrap;
                textBoxInputOutputBlock.FontFamily = defaulFontFamily;
                textBoxInputOutputBlock.MouseDoubleClick += changeTextBoxToTextBlock;
                
                textBlockInputOutputBlock.FontSize = defaulFontSize;
                textBlockInputOutputBlock.Foreground = Brushes.White;
                textBlockInputOutputBlock.Width = defaultWidth;
                textBlockInputOutputBlock.Height = defaulHeight;
                textBlockInputOutputBlock.TextAlignment = TextAlignment.Center;
                textBlockInputOutputBlock.HorizontalAlignment = HorizontalAlignment.Center;
                textBlockInputOutputBlock.TextWrapping = TextWrapping.Wrap;
                textBlockInputOutputBlock.FontFamily = defaulFontFamily;
                textBlockInputOutputBlock.MouseDown += changeTextBoxToTextBlock;

                firstPointToConnect.Fill = Brushes.Black;
                firstPointToConnect.Height = 6;
                firstPointToConnect.Width = 6;
                Canvas.SetTop(firstPointToConnect, -2);
                Canvas.SetLeft(firstPointToConnect, defaultWidth / 2);

                secondPointToConnect.Fill = Brushes.Black;
                secondPointToConnect.Height = 6;
                secondPointToConnect.Width = 6;
                Canvas.SetTop(secondPointToConnect, defaulHeight / 2 - 5);
                Canvas.SetLeft(secondPointToConnect, 8);

                thirdPointToConnect.Fill = Brushes.Black;
                thirdPointToConnect.Height = 6;
                thirdPointToConnect.Width = 6;
                Canvas.SetTop(thirdPointToConnect, defaulHeight - 3);
                Canvas.SetLeft(thirdPointToConnect, defaultWidth / 2);
                
                fourthPointToConnect.Fill = Brushes.Black;
                fourthPointToConnect.Height = 6;
                fourthPointToConnect.Width = 6;
                Canvas.SetLeft(fourthPointToConnect, defaultWidth - 13);
                Canvas.SetTop(fourthPointToConnect, defaulHeight / 2 - 5);

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
        private void changeTextBoxToTextBlock(object sender, MouseEventArgs e)
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