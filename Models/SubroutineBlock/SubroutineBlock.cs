using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Flowchart_Editor.Models
{
    public class SubroutineBlock
    {
        public Canvas? canvasSubroutineBlock = null;
        public Border? borderSubroutineBlock = null;
        public Border? internalBorderSubroutineBlock = null;
        public TextBox? textBoxOfSubroutineBlockBox = null;
        public TextBlock? textBlockOfSubroutineBlockBox = null;
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
        private const int radiusPoint = 6;

        public UIElement GetUIElementWithoutCreate() => canvasSubroutineBlock;
        
        private void subroutineBlock_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (textChangeStatus)
                {
                    var instanceOfInputOutputBlock = new SubroutineBlockForMovements(sender);
                    var dataObjectInformationOfStartEndBlock = new DataObject(typeof(SubroutineBlockForMovements), instanceOfInputOutputBlock);
                    DragDrop.DoDragDrop(sender as DependencyObject, dataObjectInformationOfStartEndBlock, DragDropEffects.Copy);
                }
            }
            e.Handled = true;
        }

        public UIElement GetUIElement()
        {
            if (canvasSubroutineBlock == null)
            {
                canvasSubroutineBlock = new Canvas();
                borderSubroutineBlock = new Border();
                internalBorderSubroutineBlock = new Border();
                textBoxOfSubroutineBlockBox = new TextBox();
                textBlockOfSubroutineBlockBox = new TextBlock();
                firstPointToConnect = new Ellipse();
                secondPointToConnect = new Ellipse();
                thirdPointToConnect = new Ellipse();
                fourthPointToConnect = new Ellipse();

                canvasSubroutineBlock.Width = defaultWidth;
                canvasSubroutineBlock.Height = defaulHeight;
                var backgroundColor = new BrushConverter();
                canvasSubroutineBlock.Background = (Brush)backgroundColor.ConvertFrom("#FFBA64C8");

                borderSubroutineBlock.BorderBrush = Brushes.Black;
                borderSubroutineBlock.Height = defaulHeight;
                borderSubroutineBlock.Width = defaultWidth;
                borderSubroutineBlock.BorderThickness = new Thickness(1);
                borderSubroutineBlock.CornerRadius = new CornerRadius(1);

                internalBorderSubroutineBlock.BorderBrush = Brushes.Black;
                internalBorderSubroutineBlock.Height = defaulHeight;
                internalBorderSubroutineBlock.Width = defaultWidth - 40;
                internalBorderSubroutineBlock.BorderThickness = new Thickness(1);
                internalBorderSubroutineBlock.CornerRadius = new CornerRadius(1);
                Canvas.SetTop(internalBorderSubroutineBlock, 0);
                Canvas.SetLeft(internalBorderSubroutineBlock, 20);

                textBoxOfSubroutineBlockBox.Text = "Подпрограмма";
                textBoxOfSubroutineBlockBox.Width = defaultWidth;
                textBoxOfSubroutineBlockBox.Height = defaulHeight;
                textBoxOfSubroutineBlockBox.FontSize = defaulFontSize;
                textBoxOfSubroutineBlockBox.FontFamily = defaultFontFamily;
                textBoxOfSubroutineBlockBox.VerticalAlignment = VerticalAlignment.Center;
                textBoxOfSubroutineBlockBox.HorizontalAlignment = HorizontalAlignment.Center;
                textBoxOfSubroutineBlockBox.TextAlignment = TextAlignment.Center;
                textBoxOfSubroutineBlockBox.Foreground = Brushes.White;
                textBoxOfSubroutineBlockBox.TextWrapping = TextWrapping.Wrap;
                textBoxOfSubroutineBlockBox.MouseDoubleClick += changeTextBoxToLabel;

                textBlockOfSubroutineBlockBox.Text = "Подпрограмма";
                textBlockOfSubroutineBlockBox.Width = defaultWidth;
                textBlockOfSubroutineBlockBox.Height = defaulHeight;
                textBlockOfSubroutineBlockBox.FontSize = defaulFontSize;
                textBlockOfSubroutineBlockBox.FontFamily = defaultFontFamily;
                textBlockOfSubroutineBlockBox.VerticalAlignment = VerticalAlignment.Center;
                textBlockOfSubroutineBlockBox.HorizontalAlignment = HorizontalAlignment.Center;
                textBlockOfSubroutineBlockBox.TextAlignment = TextAlignment.Center;
                textBlockOfSubroutineBlockBox.Foreground = Brushes.White;
                textBlockOfSubroutineBlockBox.TextWrapping = TextWrapping.Wrap;
                textBlockOfSubroutineBlockBox.MouseDown += changeTextBoxToLabel;

                firstPointToConnect.Fill = (Brush)backgroundColor.ConvertFrom(defaulColorPoint);
                firstPointToConnect.Height = radiusPoint;
                firstPointToConnect.Width = radiusPoint;
                Canvas.SetLeft(firstPointToConnect, defaultWidth / 2 - 2);
                Canvas.SetTop(firstPointToConnect, -2);
                firstPointToConnect.MouseDown += getСoordinatesOfConnectionPoint;

                secondPointToConnect.Fill = (Brush)backgroundColor.ConvertFrom(defaulColorPoint);
                secondPointToConnect.Height = radiusPoint;
                secondPointToConnect.Width = radiusPoint;
                Canvas.SetLeft(secondPointToConnect, -2);
                Canvas.SetTop(secondPointToConnect, defaulHeight / 2 - 2);
                secondPointToConnect.MouseDown += getСoordinatesOfConnectionPoint;

                thirdPointToConnect.Fill = (Brush)backgroundColor.ConvertFrom(defaulColorPoint);
                thirdPointToConnect.Height = radiusPoint;
                thirdPointToConnect.Width = radiusPoint;
                Canvas.SetLeft(thirdPointToConnect, defaultWidth / 2 - 2);
                Canvas.SetTop(thirdPointToConnect, defaulHeight - 3);
                thirdPointToConnect.MouseDown += getСoordinatesOfConnectionPoint;

                fourthPointToConnect.Fill = (Brush)backgroundColor.ConvertFrom(defaulColorPoint);
                fourthPointToConnect.Height = radiusPoint;
                fourthPointToConnect.Width = radiusPoint;
                Canvas.SetLeft(fourthPointToConnect, defaultWidth - 4);
                Canvas.SetTop(fourthPointToConnect, defaulHeight / 2 - 2);
                fourthPointToConnect.MouseDown += getСoordinatesOfConnectionPoint;

                canvasSubroutineBlock.Children.Add(borderSubroutineBlock);
                canvasSubroutineBlock.Children.Add(internalBorderSubroutineBlock);
                canvasSubroutineBlock.Children.Add(textBoxOfSubroutineBlockBox);
                canvasSubroutineBlock.Children.Add(firstPointToConnect);
                canvasSubroutineBlock.Children.Add(secondPointToConnect);
                canvasSubroutineBlock.Children.Add(thirdPointToConnect);
                canvasSubroutineBlock.Children.Add(fourthPointToConnect);
                canvasSubroutineBlock.MouseMove += subroutineBlock_MouseMove;
            }
            return canvasSubroutineBlock;
        }
        private void getСoordinatesOfConnectionPoint(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (CoordinatesBlock.coordinatesBlockPointX != 0 && CoordinatesBlock.coordinatesBlockPointX != 0)
                {
                    if (canvasSubroutineBlock != null)
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
                        canvasSubroutineBlock.Children.Add(connectionLine);

                        CoordinatesBlock.coordinatesBlockX = 0;
                        CoordinatesBlock.coordinatesBlockY = 0;
                    }
                }
                else
                {
                    CoordinatesBlock.coordinatesBlockPointX = e.GetPosition(thirdPointToConnect).X + e.GetPosition(canvasSubroutineBlock).X;
                    CoordinatesBlock.coordinatesBlockPointY = e.GetPosition(thirdPointToConnect).Y + e.GetPosition(canvasSubroutineBlock).Y;
                    Line connectionLine = new Line();
                    connectionLine.Stroke = Brushes.Red;
                    //canvasOfActionBlock.Children.Add(connectionLine);
                }
            }
        }
        private void changeTextBoxToLabel(object sender, MouseEventArgs e)
        {
            if (textChangeStatus)
            {
                valueOfClicksOnTextBlock++;
                if (valueOfClicksOnTextBlock == 2)
                {
                    canvasSubroutineBlock.Children.Remove(textBoxOfSubroutineBlockBox);
                    canvasSubroutineBlock.Children.Remove(textBlockOfSubroutineBlockBox);
                    textBoxOfSubroutineBlockBox.Text = textBlockOfSubroutineBlockBox.Text;
                    canvasSubroutineBlock.Children.Add(textBoxOfSubroutineBlockBox);
                    textChangeStatus = false;
                    valueOfClicksOnTextBlock = 0;
                }
            }
            else
            {
                canvasSubroutineBlock.Children.Remove(textBoxOfSubroutineBlockBox);
                canvasSubroutineBlock.Children.Remove(textBlockOfSubroutineBlockBox);
                textBlockOfSubroutineBlockBox.Text = textBoxOfSubroutineBlockBox.Text;
                Canvas.SetTop(textBlockOfSubroutineBlockBox, 3.5);
                canvasSubroutineBlock.Children.Add(textBlockOfSubroutineBlockBox);
                textChangeStatus = true;
            }
        }
        public void Reset()
        {
            canvasSubroutineBlock = null;
        }
    }
}