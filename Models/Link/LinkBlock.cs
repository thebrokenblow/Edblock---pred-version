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

        public LinkBlock(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
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


                //firstPointToConnect.Fill = Brushes.Black;
                //firstPointToConnect.Height = 6;
                //firstPointToConnect.Width = 6;
                //firstPointToConnect.Margin = new Thickness(35, -3, 0, 0);

                //secondPointToConnect.Fill = Brushes.Black;
                //secondPointToConnect.Height = 6;
                //secondPointToConnect.Width = 6;
                //secondPointToConnect.Margin = new Thickness(-3, 35, 0, 0);


                //thirdPointToConnect.Fill = Brushes.Black;
                //thirdPointToConnect.Height = 6;
                //thirdPointToConnect.Width = 6;
                //thirdPointToConnect.Margin = new Thickness(35, 72, 0, 0);

                //fourthPointToConnect.Fill = Brushes.Black;
                //fourthPointToConnect.Height = 6;
                //fourthPointToConnect.Width = 6;
                //fourthPointToConnect.Margin = new Thickness(72, 35, 0, 0);

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