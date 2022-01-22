using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Flowchart_Editor.Models
{
    public class SubroutineBlock
    {
        private Canvas? canvasSubroutineBlock = null;
        private Border? borderSubroutineBlock = null;
        private Border? internalBorderSubroutineBlock = null;
        private TextBox? textOfSubroutineBlockBox = null;
        private Ellipse? firstPointToConnect = null;
        private Ellipse? secondPointToConnect = null;
        private Ellipse? thirdPointToConnect = null;
        private Ellipse? fourthPointToConnect = null;

        public UIElement GetUIElementWithoutCreate() => canvasSubroutineBlock;
        

        private void subroutineBlock_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var instanceOfInputOutputBlock = new SubroutineBlockForMovements(sender);
                var dataObjectInformationOfStartEndBlock = new DataObject(typeof(SubroutineBlockForMovements), instanceOfInputOutputBlock);
                DragDrop.DoDragDrop(sender as DependencyObject, dataObjectInformationOfStartEndBlock, DragDropEffects.Copy);
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
                textOfSubroutineBlockBox = new TextBox();
                firstPointToConnect = new Ellipse();
                secondPointToConnect = new Ellipse();
                thirdPointToConnect = new Ellipse();
                fourthPointToConnect = new Ellipse();


                canvasSubroutineBlock.Width = 140;
                canvasSubroutineBlock.Height = 60;
                var backgroundColor = new BrushConverter();
                canvasSubroutineBlock.Background = (Brush)backgroundColor.ConvertFrom("#FFBA64C8");

                borderSubroutineBlock.BorderBrush = Brushes.Black;
                borderSubroutineBlock.Height = 60;
                borderSubroutineBlock.Width = 140;
                borderSubroutineBlock.BorderThickness = new Thickness(1);
                borderSubroutineBlock.CornerRadius = new CornerRadius(1);

                internalBorderSubroutineBlock.BorderBrush = Brushes.Black;
                internalBorderSubroutineBlock.Height = 60;
                internalBorderSubroutineBlock.Width = 100;
                internalBorderSubroutineBlock.BorderThickness = new Thickness(1);
                internalBorderSubroutineBlock.CornerRadius = new CornerRadius(1);
                Canvas.SetTop(internalBorderSubroutineBlock, 0);
                Canvas.SetLeft(internalBorderSubroutineBlock, 20);

                textOfSubroutineBlockBox.Text = "Подпрограмма";
                textOfSubroutineBlockBox.FontSize = 12;
                textOfSubroutineBlockBox.Foreground = Brushes.White;
                Canvas.SetTop(textOfSubroutineBlockBox, 15);
                Canvas.SetLeft(textOfSubroutineBlockBox, 25);

                firstPointToConnect.Fill = Brushes.Black;
                firstPointToConnect.Height = 6;
                firstPointToConnect.Width = 6;
                firstPointToConnect.Margin = new Thickness(65, -3, 0, 0);

                secondPointToConnect.Fill = Brushes.Black;
                secondPointToConnect.Height = 6;
                secondPointToConnect.Width = 6;
                secondPointToConnect.Margin = new Thickness(-3, 27, 0, 0);


                thirdPointToConnect.Fill = Brushes.Black;
                thirdPointToConnect.Height = 6;
                thirdPointToConnect.Width = 6;
                thirdPointToConnect.Margin = new Thickness(65, 57, 0, 0);

                fourthPointToConnect.Fill = Brushes.Black;
                fourthPointToConnect.Height = 6;
                fourthPointToConnect.Width = 6;
                fourthPointToConnect.Margin = new Thickness(136, 27, 0, 0);


                canvasSubroutineBlock.Children.Add(borderSubroutineBlock);
                canvasSubroutineBlock.Children.Add(internalBorderSubroutineBlock);
                canvasSubroutineBlock.Children.Add(textOfSubroutineBlockBox);
                canvasSubroutineBlock.Children.Add(firstPointToConnect);
                canvasSubroutineBlock.Children.Add(secondPointToConnect);
                canvasSubroutineBlock.Children.Add(thirdPointToConnect);
                canvasSubroutineBlock.Children.Add(fourthPointToConnect);
                canvasSubroutineBlock.MouseMove += subroutineBlock_MouseMove;
            }
            return canvasSubroutineBlock;
        }

        public void Reset()
        {
            canvasSubroutineBlock = null;
        }
    }
}
