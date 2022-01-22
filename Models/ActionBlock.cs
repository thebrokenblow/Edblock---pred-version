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
        private Button? firstPointToConnect = null;
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
                firstPointToConnect = new Button();
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

                //делегат, который обрабатывает click 
                firstPointToConnect.Background = Brushes.Red;
                firstPointToConnect.Height = 6;
                firstPointToConnect.Width = 6;
                firstPointToConnect.Margin = new Thickness(65, -3, 0, 0);

                //ButtonAutomationPeer peer = new ButtonAutomationPeer(firstPointToConnect);
                //Action? invokeProv = peer.GetPattern(PatternInterface.Invoke) as Action;
                //invokeProv += drawLine();
                //invokeProv.Invoke();

                secondPointToConnect.Fill = Brushes.Black;
                secondPointToConnect.Height = 6;
                secondPointToConnect.Width = 6;
                secondPointToConnect.Margin = new Thickness(-3, 25, 0, 0);


                thirdPointToConnect.Fill = Brushes.Black;
                thirdPointToConnect.Height = 6;
                thirdPointToConnect.Width = 6;
                thirdPointToConnect.Margin = new Thickness(65, 57, 0, 0);

                fourthPointToConnect.Fill = Brushes.Black;

                fourthPointToConnect.Height = 6;
                fourthPointToConnect.Width = 6;
                fourthPointToConnect.Margin = new Thickness(136, 25, 0, 0);

                canvasOfActionBlock.Children.Add(textOfActionBlock);
                canvasOfActionBlock.Children.Add(firstPointToConnect);
                canvasOfActionBlock.Children.Add(secondPointToConnect);
                canvasOfActionBlock.Children.Add(thirdPointToConnect);
                canvasOfActionBlock.Children.Add(fourthPointToConnect);
                canvasOfActionBlock.MouseMove += actionBlockForMovements_MouseMove;
            }
            return canvasOfActionBlock;
        }

        public void Reset()
        {
            canvasOfActionBlock = null;
        }
    }
}