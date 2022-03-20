using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Flowchart_Editor.Models
{
    public class LinkBlock
    {
        public Canvas? canvasLinkBlock = null;
        public Ellipse? eliposLinkBlock = null;
        public TextBox? textBoxOfLinkBlockBox = null;
        public TextBlock? textBlockOfLinkBlockBox = null;
        public Ellipse? firstPointToConnect = null;
        public Ellipse? secondPointToConnect = null;
        public Ellipse? thirdPointToConnect = null;
        public Ellipse? fourthPointToConnect = null;
        private bool textChangeStatus = false;
        private int defaultWidth = DefaultPropertyForBlock.height / 2;
        private int defaulHeight = DefaultPropertyForBlock.height / 2;
        private string defaulColorPoint = DefaultPropertyForBlock.colorPoint;
        private FontFamily defaulFontFamily = DefaultPropertyForBlock.fontFamily;
        private int defaulFontSize = DefaultPropertyForBlock.fontSize;
        private int valueOfClicksOnTextBlock = 0;
        private MainWindow mainWindow;
        private const int radiusPoint = 6;
        private int keyLinkBlock = 0;
        private const string textOfLinkBlock = "Ссылка";

        public LinkBlock(MainWindow mainWindow, int keyBlock)
        {
            this.mainWindow = mainWindow;
            keyLinkBlock = keyBlock;
        }

        public UIElement GetUIElementWithoutCreate() => canvasLinkBlock;

        private void linkBlock_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (textChangeStatus)
                {
                    var instanceOfLinkBlockBlock = new LinkBlockForMovements(sender);
                    var dataObjectInformationOfLinkBlock = new DataObject(typeof(LinkBlockForMovements), instanceOfLinkBlockBlock);
                    DragDrop.DoDragDrop(sender as DependencyObject, dataObjectInformationOfLinkBlock, DragDropEffects.Copy);
                }
            }
            e.Handled = true;
        }

        public UIElement GetUIElement()
        {
            if (canvasLinkBlock == null)
            {
                canvasLinkBlock = new Canvas();
                eliposLinkBlock = new Ellipse();
                textBoxOfLinkBlockBox = new TextBox();
                textBlockOfLinkBlockBox = new TextBlock();
                firstPointToConnect = new Ellipse();
                secondPointToConnect = new Ellipse();
                thirdPointToConnect = new Ellipse();
                fourthPointToConnect = new Ellipse();

                canvasLinkBlock.Width = defaultWidth;
                canvasLinkBlock.Width = defaulHeight;
                eliposLinkBlock.Width = defaultWidth;
                eliposLinkBlock.Height = defaulHeight;
                var backgroundColor = new BrushConverter();
                eliposLinkBlock.Fill = (Brush)backgroundColor.ConvertFrom("#5761A8");

                textBoxOfLinkBlockBox.Width = defaultWidth;
                textBoxOfLinkBlockBox.Height = defaulHeight - 5;
                textBoxOfLinkBlockBox.FontSize = defaulFontSize;
                textBoxOfLinkBlockBox.FontFamily = defaulFontFamily;
                textBoxOfLinkBlockBox.Foreground = Brushes.White;
                textBoxOfLinkBlockBox.TextWrapping = TextWrapping.Wrap;
                textBoxOfLinkBlockBox.VerticalAlignment = VerticalAlignment.Center;
                textBoxOfLinkBlockBox.HorizontalAlignment = HorizontalAlignment.Center;
                textBoxOfLinkBlockBox.TextAlignment = TextAlignment.Center;
                textBoxOfLinkBlockBox.MouseDoubleClick += changeTextBoxToTextBlock;
                Canvas.SetTop(textBoxOfLinkBlockBox, 5);

                textBlockOfLinkBlockBox.Width = defaultWidth;
                textBlockOfLinkBlockBox.Height = defaulHeight - 5;
                textBlockOfLinkBlockBox.FontSize = defaulFontSize;
                textBlockOfLinkBlockBox.FontFamily = defaulFontFamily;
                textBlockOfLinkBlockBox.Foreground = Brushes.White;
                textBlockOfLinkBlockBox.TextWrapping = TextWrapping.Wrap;
                textBlockOfLinkBlockBox.VerticalAlignment = VerticalAlignment.Center;
                textBlockOfLinkBlockBox.HorizontalAlignment = HorizontalAlignment.Center;
                textBlockOfLinkBlockBox.TextAlignment = TextAlignment.Center;
                textBlockOfLinkBlockBox.MouseDown += changeTextBoxToTextBlock;
                Canvas.SetTop(textBlockOfLinkBlockBox, 5);

                firstPointToConnect.Fill = (Brush)backgroundColor.ConvertFrom(defaulColorPoint);
                firstPointToConnect.Height = radiusPoint;
                firstPointToConnect.Width = radiusPoint;
                Canvas.SetLeft(firstPointToConnect, defaultWidth / 2 - 3);
                Canvas.SetTop(firstPointToConnect, -2);
                firstPointToConnect.MouseDown += GetСoordinatesOfConnectionPoint;

                secondPointToConnect.Fill = (Brush)backgroundColor.ConvertFrom(defaulColorPoint);
                secondPointToConnect.Height = radiusPoint;
                secondPointToConnect.Width = radiusPoint;
                Canvas.SetLeft(secondPointToConnect, -2);
                Canvas.SetTop(secondPointToConnect, defaulHeight / 2 - 3);
                secondPointToConnect.MouseDown += GetСoordinatesOfConnectionPoint;

                thirdPointToConnect.Fill = (Brush)backgroundColor.ConvertFrom(defaulColorPoint);
                thirdPointToConnect.Height = radiusPoint;
                thirdPointToConnect.Width = radiusPoint;
                Canvas.SetLeft(thirdPointToConnect, defaultWidth / 2 - 3);
                Canvas.SetTop(thirdPointToConnect, defaulHeight - 3);
                thirdPointToConnect.MouseDown += GetСoordinatesOfConnectionPoint;

                fourthPointToConnect.Fill = (Brush)backgroundColor.ConvertFrom(defaulColorPoint);
                fourthPointToConnect.Height = radiusPoint;
                fourthPointToConnect.Width = radiusPoint;
                Canvas.SetLeft(fourthPointToConnect, defaultWidth - 3);
                Canvas.SetTop(fourthPointToConnect, defaulHeight / 2 - 3);
                fourthPointToConnect.MouseDown += GetСoordinatesOfConnectionPoint;

                canvasLinkBlock.Children.Add(eliposLinkBlock);
                canvasLinkBlock.Children.Add(textBoxOfLinkBlockBox);
                canvasLinkBlock.Children.Add(firstPointToConnect);
                canvasLinkBlock.Children.Add(secondPointToConnect);
                canvasLinkBlock.Children.Add(thirdPointToConnect);
                canvasLinkBlock.Children.Add(fourthPointToConnect);
                canvasLinkBlock.MouseMove += linkBlock_MouseMove;
            }
            return canvasLinkBlock;
        }
        private void GetСoordinatesOfConnectionPoint(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (CoordinatesBlock.coordinatesBlockPointX == 0 && CoordinatesBlock.coordinatesBlockPointY == 0)
                {
                    CoordinatesBlock.coordinatesBlockPointX = Canvas.GetLeft((Ellipse)sender) + Canvas.GetLeft(canvasLinkBlock) + 3;
                    CoordinatesBlock.coordinatesBlockPointY = Canvas.GetTop((Ellipse)sender) + Canvas.GetTop(canvasLinkBlock) + 3;

                    CoordinatesBlock.keyFirstBlock = keyLinkBlock;

                    mainWindow.WriteFirstNameOfBlockToConect(textOfLinkBlock);
                }
                else
                {
                    double x1 = CoordinatesBlock.coordinatesBlockPointX;
                    double y1 = CoordinatesBlock.coordinatesBlockPointY;

                    double x2 = Canvas.GetLeft((Ellipse)sender) + Canvas.GetLeft(canvasLinkBlock) + 3;
                    double y2 = Canvas.GetTop((Ellipse)sender) + Canvas.GetTop(canvasLinkBlock) + 3;

                    CoordinatesBlock.keySecondBlock = keyLinkBlock;

                    mainWindow.WriteSecondNameOfBlockToConect(textOfLinkBlock);

                    mainWindow.DrawConnectionLine(x1, y1, x2, y2);
                    CoordinatesBlock.coordinatesBlockPointX = 0;
                    CoordinatesBlock.coordinatesBlockPointY = 0;
                }
            }
        }
        private void changeTextBoxToTextBlock(object sender, MouseEventArgs e)
        {
            if (textChangeStatus)
            {
                valueOfClicksOnTextBlock++;
                if (valueOfClicksOnTextBlock == 2)
                {
                    canvasLinkBlock.Children.Remove(textBoxOfLinkBlockBox);
                    canvasLinkBlock.Children.Remove(textBlockOfLinkBlockBox);
                    textBoxOfLinkBlockBox.Text = textBlockOfLinkBlockBox.Text;
                    //Canvas.SetTop(textBoxOfLinkBlockBox, 2.5);
                    canvasLinkBlock.Children.Add(textBoxOfLinkBlockBox);
                    textChangeStatus = false;
                    valueOfClicksOnTextBlock = 0;
                }
            }
            else
            {
                canvasLinkBlock.Children.Remove(textBoxOfLinkBlockBox);
                canvasLinkBlock.Children.Remove(textBlockOfLinkBlockBox);
                textBlockOfLinkBlockBox.Text = textBoxOfLinkBlockBox.Text;
                Canvas.SetTop(textBlockOfLinkBlockBox, 5.5);
                canvasLinkBlock.Children.Add(textBlockOfLinkBlockBox);
                textChangeStatus = true;
            }
        }

        public void Reset()
        {
            canvasLinkBlock = null;
        }
    }
}