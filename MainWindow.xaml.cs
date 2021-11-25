using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

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
        public object transferInformation = null;
        public ActionBlockForMovements(object sender) 
        {
            transferInformation = sender;
        }

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

    public class StartEndBlock
    {
        private Canvas? canvasStartEndBlock = null;
        private Rectangle? rectangleStartEndBlock = null;
        private TextBox? textOfStartEndBox = null;

        public UIElement GetUIElementWithoutCreate()
        {
            #pragma warning disable CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
            return canvasStartEndBlock;
            #pragma warning restore CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
        }

        private void startEndBlock_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var instanceOfStartEndBlock = new StartEndBlockForMovements(sender);
                var dataObjectInformationOfStartEndBlock = new DataObject(typeof(StartEndBlockForMovements), instanceOfStartEndBlock);
                DragDrop.DoDragDrop(sender as DependencyObject, dataObjectInformationOfStartEndBlock, DragDropEffects.Copy);
            }
            e.Handled = true;
        }

        public UIElement GetUIElement()
        {
            if (canvasStartEndBlock == null)
            {
                canvasStartEndBlock = new Canvas();
                rectangleStartEndBlock = new Rectangle();
                textOfStartEndBox = new TextBox();

                var backgroundColor = new BrushConverter();
                rectangleStartEndBlock.Fill = (Brush)backgroundColor.ConvertFrom("#FFF25252");
                rectangleStartEndBlock.RadiusX = 25;
                rectangleStartEndBlock.RadiusY = 25;
                rectangleStartEndBlock.Width = 140;
                rectangleStartEndBlock.Height = 60;

                textOfStartEndBox.Text = "Начало";
                textOfStartEndBox.Foreground = Brushes.Black;

                Canvas.SetLeft(textOfStartEndBox, 47);
                Canvas.SetTop(textOfStartEndBox, 17);
                canvasStartEndBlock.Children.Add(rectangleStartEndBlock);
                canvasStartEndBlock.Children.Add(textOfStartEndBox);
                canvasStartEndBlock.MouseMove += startEndBlock_MouseMove;
            }
            return canvasStartEndBlock;
        }

        internal void Reset()
        {
            canvasStartEndBlock = null;
        }
    }

    public class StartEndBlockForMovements
    {
        private Canvas? canvasStartEndBlock = null;
        private Rectangle? rectangleStartEndBlock = null;
        private TextBox? textOfStartEndBox = null;
        public object transferInformation = null;

        public StartEndBlockForMovements(object sender)
        {
            transferInformation = sender;
        }

        public UIElement GetUIElementWithoutCreate()
        {
            #pragma warning disable CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
            return canvasStartEndBlock;
            #pragma warning restore CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
        }

        public UIElement GetUIElement()
        {
            if (canvasStartEndBlock == null)
            {
                canvasStartEndBlock = new Canvas();
                rectangleStartEndBlock = new Rectangle();
                textOfStartEndBox = new TextBox();

                var backgroundColor = new BrushConverter();
                rectangleStartEndBlock.Fill = (Brush)backgroundColor.ConvertFrom("#FFF25252");
                rectangleStartEndBlock.RadiusX = 25;
                rectangleStartEndBlock.RadiusY = 25;
                rectangleStartEndBlock.Width = 140;
                rectangleStartEndBlock.Height = 60;

                textOfStartEndBox.Text = "Начало";
                textOfStartEndBox.Foreground = Brushes.Black;

                Canvas.SetLeft(textOfStartEndBox, 47);
                Canvas.SetTop(textOfStartEndBox, 17);
                canvasStartEndBlock.Children.Add(rectangleStartEndBlock);
                canvasStartEndBlock.Children.Add(textOfStartEndBox);
            }
            return canvasStartEndBlock;
        }

        internal void Reset()
        {
            canvasStartEndBlock = null;
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
                var dataObjectInformationOfActionBlock = new DataObject(typeof(ActionBlock), instanceOfActionBlock); //Занесениие информации в DataObject зачем?
                DragDrop.DoDragDrop(sender as DependencyObject, dataObjectInformationOfActionBlock, DragDropEffects.Copy);
            }
            e.Handled = true;
        }
        private void startEndBlock_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var instanceOfStartEndBlock = new StartEndBlock();
                var dataObjectInformationOfStartEndBlock = new DataObject(typeof(StartEndBlock), instanceOfStartEndBlock);
                DragDrop.DoDragDrop(sender as DependencyObject, dataObjectInformationOfStartEndBlock, DragDropEffects.Copy);
            }
            e.Handled = true;
        }

        private void destination_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ActionBlock)))
            {
                var position = e.GetPosition(destination); //Зачем получаем координаты у поля а не у блока переносимого 
                var featuresOfActionBlock = ((ActionBlock)e.Data.GetData(typeof(ActionBlock))).GetUIElement(); 
                Canvas.SetLeft(featuresOfActionBlock, position.X);
                Canvas.SetTop(featuresOfActionBlock, position.Y);
            } else if (e.Data.GetDataPresent(typeof(StartEndBlock)))
            {
                var position = e.GetPosition(destination);
                var featuresOfStartEndBlock = ((StartEndBlock)e.Data.GetData(typeof(StartEndBlock))).GetUIElement();
                Canvas.SetLeft(featuresOfStartEndBlock, position.X);
                Canvas.SetTop(featuresOfStartEndBlock, position.Y);
            }
            e.Handled = true;
        }

        private void destination_DragOver(object sender, DragEventArgs e) //Метод обрабатывает что можем переносить только блоки и ничего лишнего
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
                var resultTransferInformation = (ActionBlockForMovements)e.Data.GetData(typeof(ActionBlockForMovements));
                Canvas.SetLeft((UIElement)resultTransferInformation.transferInformation, position.X + 1);
                Canvas.SetTop((UIElement)resultTransferInformation.transferInformation, position.Y + 1);

            }
            else if (e.Data.GetDataPresent(typeof(StartEndBlock)))
            {
                e.Effects = DragDropEffects.Copy;
                var position = e.GetPosition(destination);
                var dataInformationOfStartEndBlock = (StartEndBlock)e.Data.GetData(typeof(StartEndBlock)); //
                UIElement startEndBlockOfUIElement;
                if (dataInformationOfStartEndBlock.GetUIElementWithoutCreate() == null)
                {
                    startEndBlockOfUIElement = ((StartEndBlock)e.Data.GetData(typeof(StartEndBlock))).GetUIElement();
                    destination.Children.Add(startEndBlockOfUIElement);
                }
                else
                {
                    startEndBlockOfUIElement = ((StartEndBlock)e.Data.GetData(typeof(StartEndBlock))).GetUIElement();
                }
                Canvas.SetLeft(startEndBlockOfUIElement, position.X + 1);
                Canvas.SetTop(startEndBlockOfUIElement, position.Y + 1);

            } else if (e.Data.GetDataPresent(typeof(StartEndBlockForMovements)))
            {
                e.Effects = DragDropEffects.Copy;
                var position = e.GetPosition(destination);
                var resultTransferInformation = (StartEndBlockForMovements)e.Data.GetData(typeof(StartEndBlockForMovements));
                Canvas.SetLeft((UIElement)resultTransferInformation.transferInformation, position.X + 1);
                Canvas.SetTop((UIElement)resultTransferInformation.transferInformation, position.Y + 1);
            } else e.Effects = DragDropEffects.None;
            e.Handled = true;
        }

        private void destination_DragLeave(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ActionBlock)))
            {
                var actionBlockOfUIElement = ((ActionBlock)e.Data.GetData(typeof(ActionBlock))).GetUIElement();
                destination.Children.Remove(actionBlockOfUIElement); //Удаление, если блок уехал за canvas
                var dataInformationOfActionBlock = (ActionBlock)e.Data.GetData(typeof(ActionBlock));
                dataInformationOfActionBlock.Reset(); //Востановление блока 
            } else if (e.Data.GetDataPresent(typeof(ActionBlockForMovements)))
            {
                var actionBlockOfUIElement = ((ActionBlockForMovements)e.Data.GetData(typeof(ActionBlockForMovements))).GetUIElement();
                destination.Children.Remove(actionBlockOfUIElement); //Удаление, если блок уехал за canvas
                var dataInformationOfActionBlock = (ActionBlockForMovements)e.Data.GetData(typeof(ActionBlockForMovements));
                dataInformationOfActionBlock.Reset(); //Востановление блока 
            }
            else if (e.Data.GetDataPresent(typeof(StartEndBlock)))
            {
                var startEndBlockOfUIElement = ((StartEndBlock)e.Data.GetData(typeof(StartEndBlock))).GetUIElement();
                destination.Children.Remove(startEndBlockOfUIElement);
                var dataInformationOfStartEndBlock = (StartEndBlock)e.Data.GetData(typeof(StartEndBlock));
                dataInformationOfStartEndBlock.Reset();
            } else if(e.Data.GetDataPresent(typeof(StartEndBlockForMovements)))
            {
                var startEndBlockOfUIElement = ((StartEndBlockForMovements)e.Data.GetData(typeof(StartEndBlockForMovements))).GetUIElement();
                destination.Children.Remove(startEndBlockOfUIElement);
                var dataInformationOfStartEndBlock = (StartEndBlockForMovements)e.Data.GetData(typeof(StartEndBlockForMovements));
                dataInformationOfStartEndBlock.Reset();
            }
            e.Handled = true;
        }
    }
}