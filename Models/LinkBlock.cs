using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Flowchart_Editor.Models
{
    public class LinkBlock
    {
        private Canvas? canvasLinkBlock = null;
        private Ellipse? eliposLinkBlock = null;
        private TextBox? textOfLinkBlockBox = null;
        private Ellipse? firstPointToConnect = null;
        private Ellipse? secondPointToConnect = null;
        private Ellipse? thirdPointToConnect = null;
        private Ellipse? fourthPointToConnect = null;

        public UIElement GetUIElementWithoutCreate() => canvasLinkBlock;

        private void linkBlock_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var instanceOfLinkBlockBlock = new LinkBlockForMovements(sender);
                var dataObjectInformationOfLinkBlock = new DataObject(typeof(LinkBlockForMovements), instanceOfLinkBlockBlock);
                DragDrop.DoDragDrop(sender as DependencyObject, dataObjectInformationOfLinkBlock, DragDropEffects.Copy);
            }
            e.Handled = true;
        }

        public UIElement GetUIElement()
        {
            if (canvasLinkBlock == null)
            {
                canvasLinkBlock = new Canvas();
                eliposLinkBlock = new Ellipse();
                textOfLinkBlockBox = new TextBox();
                firstPointToConnect = new Ellipse();
                secondPointToConnect = new Ellipse();
                thirdPointToConnect = new Ellipse();
                fourthPointToConnect = new Ellipse();

                eliposLinkBlock.Width = 75;
                eliposLinkBlock.Height = 75;
                var backgroundColor = new BrushConverter();
                eliposLinkBlock.Fill = (Brush)backgroundColor.ConvertFrom("#5761A8");

                textOfLinkBlockBox.Text = "Ссылка";
                textOfLinkBlockBox.FontSize = 12;
                textOfLinkBlockBox.Foreground = Brushes.White;
                Canvas.SetTop(textOfLinkBlockBox, 22);
                Canvas.SetLeft(textOfLinkBlockBox, 17);

                firstPointToConnect.Fill = Brushes.Black;
                firstPointToConnect.Height = 6;
                firstPointToConnect.Width = 6;
                firstPointToConnect.Margin = new Thickness(35, -3, 0, 0);

                secondPointToConnect.Fill = Brushes.Black;
                secondPointToConnect.Height = 6;
                secondPointToConnect.Width = 6;
                secondPointToConnect.Margin = new Thickness(-3, 35, 0, 0);


                thirdPointToConnect.Fill = Brushes.Black;
                thirdPointToConnect.Height = 6;
                thirdPointToConnect.Width = 6;
                thirdPointToConnect.Margin = new Thickness(35, 72, 0, 0);

                fourthPointToConnect.Fill = Brushes.Black;
                fourthPointToConnect.Height = 6;
                fourthPointToConnect.Width = 6;
                fourthPointToConnect.Margin = new Thickness(72, 35, 0, 0);

                canvasLinkBlock.Children.Add(eliposLinkBlock);
                canvasLinkBlock.Children.Add(textOfLinkBlockBox);
                canvasLinkBlock.Children.Add(firstPointToConnect);
                canvasLinkBlock.Children.Add(secondPointToConnect);
                canvasLinkBlock.Children.Add(thirdPointToConnect);
                canvasLinkBlock.Children.Add(fourthPointToConnect);
                canvasLinkBlock.MouseMove += linkBlock_MouseMove;
            }
            return canvasLinkBlock;
        }

        public void Reset()
        {
            canvasLinkBlock = null;
        }
    }
}