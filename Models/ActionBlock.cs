using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Flowchart_Editor.Models
{
    public class ActionBlock
    {
        private Canvas? canvasOfActionBlock = null;
        private TextBox? textOfActionBlock = null;
        private Ellipse? firstPointToConnect = null;
        private Ellipse? secondPointToConnect = null;
        private Ellipse? thirdPointToConnect = null;
        private Ellipse? fourthPointToConnect = null;

        public UIElement GetUIElementWithoutCreate() => canvasOfActionBlock;

        private void actionBlockForMovements_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var instanceOfActionBlock = new ActionBlockForMovements(sender);
                var dataObjectInformationOfActionBlock = new DataObject(typeof(ActionBlockForMovements), instanceOfActionBlock);
                DragDrop.DoDragDrop(sender as DependencyObject, dataObjectInformationOfActionBlock, DragDropEffects.Copy);
            }
            e.Handled = true;
        }

        public UIElement GetUIElement()
        {
            if (canvasOfActionBlock == null)
            {
                canvasOfActionBlock = new Canvas();
                textOfActionBlock = new TextBox();
                firstPointToConnect = new Ellipse();
                secondPointToConnect = new Ellipse();
                thirdPointToConnect = new Ellipse();
                fourthPointToConnect = new Ellipse();


                textOfActionBlock.Text = "Действие";
                textOfActionBlock.Foreground = Brushes.White;

                var backgroundColor = new BrushConverter();
                canvasOfActionBlock.Background = (Brush)backgroundColor.ConvertFrom("#FF52C0AA");
                canvasOfActionBlock.Width = 140;
                canvasOfActionBlock.Height = 60;

                Canvas.SetLeft(textOfActionBlock, 40);
                Canvas.SetTop(textOfActionBlock, 15);
                
                firstPointToConnect.Fill = Brushes.Red;
                firstPointToConnect.Height = 6;
                firstPointToConnect.Width = 6;
                firstPointToConnect.Margin = new Thickness(65, -3, 0, 0);
                firstPointToConnect.MouseDown += getСoordinatesOfConnectionPoint;

                secondPointToConnect.Fill = Brushes.Black;
                secondPointToConnect.Height = 6;
                secondPointToConnect.Width = 6;
                secondPointToConnect.Margin = new Thickness(-3, 25, 0, 0);
                secondPointToConnect.MouseDown += getСoordinatesOfConnectionPoint;

                thirdPointToConnect.Fill = Brushes.Black;
                thirdPointToConnect.Height = 6;
                thirdPointToConnect.Width = 6;
                thirdPointToConnect.Margin = new Thickness(65, 57, 0, 0);
                thirdPointToConnect.MouseDown += getСoordinatesOfConnectionPoint;

                fourthPointToConnect.Fill = Brushes.Black;
                fourthPointToConnect.Height = 6;
                fourthPointToConnect.Width = 6;
                fourthPointToConnect.Margin = new Thickness(136, 25, 0, 0);
                fourthPointToConnect.MouseDown += getСoordinatesOfConnectionPoint;

                canvasOfActionBlock.Children.Add(textOfActionBlock);
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
                if (CoordinatesBlock.coordinatesBlockX != null && CoordinatesBlock.coordinatesBlockY != null)
                {
                    if (canvasOfActionBlock != null)
                    {
                        double? coordinatesBlockStartPointX = CoordinatesBlock.coordinatesBlockX;
                        double? coordinatesBlockStartPointY = CoordinatesBlock.coordinatesBlockY;

                        double coordinatesBlockEndPointX = e.GetPosition((Canvas)sender).X;
                        double coordinatesBlockEndPointY = e.GetPosition((Canvas)sender).Y;

                        Line connectionLine = new Line();
                        connectionLine.X1 = (double)coordinatesBlockStartPointX;
                        connectionLine.Y1 = (double)coordinatesBlockStartPointY;
                        connectionLine.X2 = coordinatesBlockEndPointX;
                        connectionLine.Y2 = coordinatesBlockEndPointY;
                        connectionLine.Stroke = Brushes.Black;
                        canvasOfActionBlock.Children.Add(connectionLine);

                        CoordinatesBlock.coordinatesBlockX = null;
                        CoordinatesBlock.coordinatesBlockY = null;
                    }
                }
                else
                {
                    CoordinatesBlock.coordinatesBlockX = e.GetPosition((Ellipse)sender).X;
                    CoordinatesBlock.coordinatesBlockY = e.GetPosition((Ellipse)sender).Y;
                }
            }
        }

        public void Reset()
        {
            canvasOfActionBlock = null;
        }
    }
}