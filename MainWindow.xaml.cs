using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Flowchart_Editor
{
    public class ActionBlock
    {
        private Canvas? canvasOfActionBlock = null;
        private TextBox? textOfActionBlock = null;

        public UIElement GetUIElementWithoutCreate()
        {
            #pragma warning disable CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
            return canvasOfActionBlock;
            #pragma warning restore CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
        }

        public void actionBlock_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var instanceOfActionBlock = new ActionBlockForMovements();

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

                textOfActionBlock.Text = "Действие";
                textOfActionBlock.Foreground = Brushes.Black;

                var backgroundColor = new BrushConverter();
                canvasOfActionBlock.Background = (Brush)backgroundColor.ConvertFrom("#FF52C0AA");
                canvasOfActionBlock.Width = 140;
                canvasOfActionBlock.Height = 60;

                Canvas.SetLeft(textOfActionBlock, 40);
                Canvas.SetTop(textOfActionBlock, 15);
                canvasOfActionBlock.Children.Add(textOfActionBlock);
                canvasOfActionBlock.MouseMove += actionBlock_MouseMove;
            }
            return canvasOfActionBlock;
        }

        internal void Reset()
        {
            canvasOfActionBlock = null;
        }
    }

    public class ActionBlockForMovements
    {
        private Canvas? canvasOfActionBlock = null;
        private TextBox? textOfActionBlock = null;

        public UIElement GetUIElementWithoutCreate()
        {
            #pragma warning disable CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
            return canvasOfActionBlock;
            #pragma warning restore CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
        }

        public UIElement GetUIElement()
        {
            if (canvasOfActionBlock == null)
            {
                canvasOfActionBlock = new Canvas();
                textOfActionBlock = new TextBox();

                textOfActionBlock.Text = "Действие";
                textOfActionBlock.Foreground = Brushes.Black;

                var backgroundColor = new BrushConverter();
                canvasOfActionBlock.Background = (Brush)backgroundColor.ConvertFrom("#FF52C0AA");
                canvasOfActionBlock.Width = 140;
                canvasOfActionBlock.Height = 60;

                Canvas.SetLeft(textOfActionBlock, 40);
                Canvas.SetTop(textOfActionBlock, 15);
                canvasOfActionBlock.Children.Add(textOfActionBlock);
            }
            return canvasOfActionBlock;
        }
        internal void Reset()
        {
            canvasOfActionBlock = null;
        }
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void actionBlock_MouseMove(object sender, MouseEventArgs e)
        {

            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var instanceOfActionBlock = new ActionBlock();
                var dataObjectInformationOfActionBlock = new DataObject(typeof(ActionBlock), instanceOfActionBlock);
                DragDrop.DoDragDrop(sender as DependencyObject, dataObjectInformationOfActionBlock, DragDropEffects.Copy);
            }
            e.Handled = true;
        }

        private void destination_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ActionBlock)))
            {
                var position = e.GetPosition(destination);
                var featuresOfActionBlock = ((ActionBlock)e.Data.GetData(typeof(ActionBlock))).GetUIElement();
                Canvas.SetLeft(featuresOfActionBlock, position.X);
                Canvas.SetTop(featuresOfActionBlock, position.Y);
            }
            if (e.Data.GetDataPresent(typeof(ActionBlockForMovements)))
            {
                var position = e.GetPosition(destination);
                var featuresOfActionBlock = ((ActionBlockForMovements)e.Data.GetData(typeof(ActionBlockForMovements))).GetUIElement();
                Canvas.SetLeft(featuresOfActionBlock, position.X);
                Canvas.SetTop(featuresOfActionBlock, position.Y);
            }
        }

        private void destination_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ActionBlock)))
            {
                e.Effects = DragDropEffects.Copy;
                var position = e.GetPosition(destination);
                var dataInformationOfActionBlock = (ActionBlock)e.Data.GetData(typeof(ActionBlock));
                UIElement actionBlockOfUIElement;
                if (dataInformationOfActionBlock.GetUIElementWithoutCreate() == null)
                {
                    actionBlockOfUIElement = ((ActionBlock)e.Data.GetData(typeof(ActionBlock))).GetUIElement();
                    destination.Children.Add(actionBlockOfUIElement);
                }
                else
                {
                    actionBlockOfUIElement = ((ActionBlock)e.Data.GetData(typeof(ActionBlock))).GetUIElement();
                }
                Canvas.SetLeft(actionBlockOfUIElement, position.X + 1);
                Canvas.SetTop(actionBlockOfUIElement, position.Y + 1);
            }
            else if (e.Data.GetDataPresent(typeof(ActionBlockForMovements)))
            {
                e.Effects = DragDropEffects.Copy;
                var position = e.GetPosition(destination);
                var dataInformationOfActionBlock = (ActionBlockForMovements)e.Data.GetData(typeof(ActionBlockForMovements));
                UIElement actionBlockOfUIElement;
                if (dataInformationOfActionBlock.GetUIElementWithoutCreate() == null)
                {
                    actionBlockOfUIElement = ((ActionBlockForMovements)e.Data.GetData(typeof(ActionBlockForMovements))).GetUIElement();
                    destination.Children.Add(actionBlockOfUIElement);
                }
                else
                {
                    actionBlockOfUIElement = ((ActionBlockForMovements)e.Data.GetData(typeof(ActionBlockForMovements))).GetUIElement();
                }
                Canvas.SetLeft(actionBlockOfUIElement, position.X + 1);
                Canvas.SetTop(actionBlockOfUIElement, position.Y + 1);
            }
            else
                e.Effects = DragDropEffects.None;
            e.Handled = true;
        }

        private void destination_DragLeave(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ActionBlock)))
            {
                var actionBlockOfUIElement = ((ActionBlock)e.Data.GetData(typeof(ActionBlock))).GetUIElement();
                destination.Children.Remove(actionBlockOfUIElement);
                var dataInformationOfActionBlock = (ActionBlock)e.Data.GetData(typeof(ActionBlock));
                dataInformationOfActionBlock.Reset();
            }
            else if (e.Data.GetDataPresent(typeof(ActionBlockForMovements)))
            {
                var actionBlockOfUIElement = ((ActionBlockForMovements)e.Data.GetData(typeof(ActionBlockForMovements))).GetUIElement();
                destination.Children.Remove(actionBlockOfUIElement);
                var dataInformationOfActionBlock = (ActionBlockForMovements)e.Data.GetData(typeof(ActionBlockForMovements));
                dataInformationOfActionBlock.Reset();
            }
            e.Handled = true;
        }
    }
}