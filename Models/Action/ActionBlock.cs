using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Flowchart_Editor.Models
{
    public class ActionBlock : Window
    {
        public Canvas? canvasOfActionBlock = null;
        public TextBox? textBoxOfActionBlock = null;
        public TextBlock? textBlockOfActionBlock = null;
        public Ellipse? firstPointToConnect = null;
        public Ellipse? secondPointToConnect = null;
        public Ellipse? thirdPointToConnect = null;
        public Ellipse? fourthPointToConnect = null;
        private bool textChangeStatus = false;
        private int defaultWidth = DefaultPropertyForBlock.width;
        private int defaulHeight = DefaultPropertyForBlock.height;
        private string defaulColorPoint = DefaultPropertyForBlock.colorPoint;
        private int defaulFontSize = DefaultPropertyForBlock.fontSize;
        private FontFamily defaultFontFamily = DefaultPropertyForBlock.fontFamily;
        private int valueOfClicksOnTextBlock = 0;

        public UIElement GetUIElementWithoutCreate() => canvasOfActionBlock;

        private void actionBlockForMovements_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (textChangeStatus)
                {
                    var instanceOfActionBlock = new ActionBlockForMovements(sender);
                    var dataObjectInformationOfActionBlock = new DataObject(typeof(ActionBlockForMovements), instanceOfActionBlock);
                    DragDrop.DoDragDrop(sender as DependencyObject, dataObjectInformationOfActionBlock, DragDropEffects.Copy);
                }
            }
            e.Handled = true;
        }

        public UIElement GetUIElement()
        {
            if (canvasOfActionBlock == null)
            {
                canvasOfActionBlock = new Canvas();
                textBoxOfActionBlock = new TextBox();
                textBlockOfActionBlock = new TextBlock();
                firstPointToConnect = new Ellipse();
                secondPointToConnect = new Ellipse();
                thirdPointToConnect = new Ellipse();
                fourthPointToConnect = new Ellipse();

                textBoxOfActionBlock.Text = "Действие";
                textBoxOfActionBlock.Width = defaultWidth;
                textBoxOfActionBlock.Height = defaulHeight;
                textBoxOfActionBlock.FontSize = defaulFontSize;
                textBoxOfActionBlock.FontFamily = defaultFontFamily;
                textBoxOfActionBlock.VerticalAlignment = VerticalAlignment.Center;
                textBoxOfActionBlock.HorizontalAlignment = HorizontalAlignment.Center;
                textBoxOfActionBlock.TextAlignment = TextAlignment.Center;
                textBoxOfActionBlock.Foreground = Brushes.White;
                textBoxOfActionBlock.TextWrapping = TextWrapping.Wrap;
                textBoxOfActionBlock.MouseDoubleClick += changeTextBoxToLabel;

                textBlockOfActionBlock.Width = defaultWidth;
                textBlockOfActionBlock.Height = defaulHeight;
                textBlockOfActionBlock.FontSize = defaulFontSize;
                textBlockOfActionBlock.FontFamily = defaultFontFamily;
                textBlockOfActionBlock.VerticalAlignment = VerticalAlignment.Center;
                textBlockOfActionBlock.HorizontalAlignment = HorizontalAlignment.Center;
                textBlockOfActionBlock.TextAlignment = TextAlignment.Center;
                textBlockOfActionBlock.Foreground = Brushes.White;
                textBlockOfActionBlock.TextWrapping = TextWrapping.Wrap;
                textBlockOfActionBlock.MouseDown += changeTextBoxToLabel;

                var backgroundColor = new BrushConverter();
                canvasOfActionBlock.Background = (Brush)backgroundColor.ConvertFrom("#FF52C0AA");
                canvasOfActionBlock.Width = defaultWidth;
                canvasOfActionBlock.Height = defaulHeight;

                firstPointToConnect.Fill = (Brush)backgroundColor.ConvertFrom(defaulColorPoint); 
                firstPointToConnect.Height = 6;
                firstPointToConnect.Width = 6;
                Canvas.SetLeft(firstPointToConnect, defaultWidth / 2 - 2);
                Canvas.SetTop(firstPointToConnect,  -2);
                firstPointToConnect.MouseDown += getСoordinatesOfConnectionPoint;

                secondPointToConnect.Fill = (Brush)backgroundColor.ConvertFrom(defaulColorPoint);
                secondPointToConnect.Height = 6;
                secondPointToConnect.Width = 6;
                Canvas.SetLeft(secondPointToConnect, -2);
                Canvas.SetTop(secondPointToConnect, defaulHeight / 2 - 2);
                secondPointToConnect.MouseDown += getСoordinatesOfConnectionPoint;

                thirdPointToConnect.Fill = (Brush)backgroundColor.ConvertFrom(defaulColorPoint);
                thirdPointToConnect.Height = 6;
                thirdPointToConnect.Width = 6;
                Canvas.SetLeft(thirdPointToConnect, defaultWidth / 2 - 2);
                Canvas.SetTop(thirdPointToConnect, defaulHeight - 3);
                thirdPointToConnect.MouseDown += getСoordinatesOfConnectionPoint;

                fourthPointToConnect.Fill = (Brush)backgroundColor.ConvertFrom(defaulColorPoint);
                fourthPointToConnect.Height = 6;
                fourthPointToConnect.Width = 6;
                Canvas.SetLeft(fourthPointToConnect, defaultWidth - 4);
                Canvas.SetTop(fourthPointToConnect, defaulHeight / 2 -2);
                fourthPointToConnect.MouseDown += getСoordinatesOfConnectionPoint;

                canvasOfActionBlock.Children.Add(textBoxOfActionBlock);
                canvasOfActionBlock.Children.Add(firstPointToConnect);
                canvasOfActionBlock.Children.Add(secondPointToConnect);
                canvasOfActionBlock.Children.Add(thirdPointToConnect);
                canvasOfActionBlock.Children.Add(fourthPointToConnect);
                canvasOfActionBlock.MouseMove += actionBlockForMovements_MouseMove;
            }
            return canvasOfActionBlock;
        }
        private void getСoordinatesOfConnectionPoint(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (CoordinatesBlock.coordinatesBlockPointX != 0 && CoordinatesBlock.coordinatesBlockPointX != 0)
                {
                    if (canvasOfActionBlock != null)
                    {
                        double coordinatesBlockStartPointX = CoordinatesBlock.coordinatesBlockX;
                        double coordinatesBlockStartPointY = CoordinatesBlock.coordinatesBlockY;

                        double coordinatesBlockEndPointX = e.GetPosition((Canvas)sender).X + e.GetPosition((Ellipse)sender).X;
                        double coordinatesBlockEndPointY = e.GetPosition((Canvas)sender).Y + e.GetPosition((Ellipse)sender).Y;

                        Line connectionLine = new Line();
                        connectionLine.X1 = (double)coordinatesBlockStartPointX;
                        connectionLine.Y1 = (double)coordinatesBlockStartPointY;
                        connectionLine.X2 = coordinatesBlockEndPointX;
                        connectionLine.Y2 = coordinatesBlockEndPointY;
                        connectionLine.Stroke = Brushes.Black;
                        canvasOfActionBlock.Children.Add(connectionLine);

                        CoordinatesBlock.coordinatesBlockX = 0;
                        CoordinatesBlock.coordinatesBlockY = 0;
                    }
                }
                else
                {
                    CoordinatesBlock.coordinatesBlockPointX = e.GetPosition(thirdPointToConnect).X + e.GetPosition(canvasOfActionBlock).X;
                    CoordinatesBlock.coordinatesBlockPointY = e.GetPosition(thirdPointToConnect).Y + e.GetPosition(canvasOfActionBlock).Y;
                    Line connectionLine = new Line();
                    
                   
                    connectionLine.Stroke = Brushes.Red;
                    //canvasOfActionBlock.Children.Add(connectionLine);
                }
            }
        }
        private void changeTextBoxToLabel(object sender, MouseEventArgs e)
        {
            if (!textChangeStatus)
            {
                canvasOfActionBlock.Children.Remove(textBoxOfActionBlock);
                canvasOfActionBlock.Children.Remove(textBlockOfActionBlock);
                textBlockOfActionBlock.Text = textBoxOfActionBlock.Text;
                Canvas.SetTop(textBlockOfActionBlock, 3.5);
                canvasOfActionBlock.Children.Add(textBlockOfActionBlock);
                textChangeStatus = true;
            }
            else
            {
                valueOfClicksOnTextBlock++;
                if (valueOfClicksOnTextBlock == 2)
                {
                    canvasOfActionBlock.Children.Remove(textBoxOfActionBlock);
                    canvasOfActionBlock.Children.Remove(textBlockOfActionBlock);
                    textBoxOfActionBlock.Text = textBlockOfActionBlock.Text;
                    canvasOfActionBlock.Children.Add(textBoxOfActionBlock);
                    textChangeStatus = false;
                    valueOfClicksOnTextBlock = 0;
                }
            }
        }

        public void Reset()
        {
            canvasOfActionBlock = null;
        }
    }
}