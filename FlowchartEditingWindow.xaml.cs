using Flowchart_Editor.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Flowchart_Editor
{

    public delegate void Action(object sender, RoutedEventArgs e);


    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MinWidth = 1280;
            MinHeight = 720;
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
        private void conditionBlock_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var instanceOfConditionBlock = new ConditionBlock();
                var dataObjectInformationOConditionBlock = new DataObject(typeof(ConditionBlock), instanceOfConditionBlock);
                DragDrop.DoDragDrop(conditionBlock, dataObjectInformationOConditionBlock, DragDropEffects.Copy);
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
        private void inputOutputBlock_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var instanceOfInputOutputBlock = new InputOutputBlock();
                var dataObjectInformationOfInputOutputBlock = new DataObject(typeof(InputOutputBlock), instanceOfInputOutputBlock);
                DragDrop.DoDragDrop(inputOutputBlock, dataObjectInformationOfInputOutputBlock, DragDropEffects.Copy);
            }
            e.Handled = true;
        }
        private void subroutineBlock_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var instanceSubroutineBlock = new SubroutineBlock();
                var dataObjectInformationOfSubroutineBlock = new DataObject(typeof(SubroutineBlock), instanceSubroutineBlock);
                DragDrop.DoDragDrop(subroutineBlock, dataObjectInformationOfSubroutineBlock, DragDropEffects.Copy);
            }
            e.Handled = true;
        }
        private void linkBlock_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var instanceOfLinkBlockBlock = new LinkBlock();
                var dataObjectInformationOfLinkBlock = new DataObject(typeof(LinkBlock), instanceOfLinkBlockBlock);
                DragDrop.DoDragDrop(sender as DependencyObject, dataObjectInformationOfLinkBlock, DragDropEffects.Copy);
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
            else if (e.Data.GetDataPresent(typeof(ConditionBlock)))
            {
                var position = e.GetPosition(destination);
                var featuresOfConditionBlock = ((ConditionBlock)e.Data.GetData(typeof(ConditionBlock))).GetUIElement();
                Canvas.SetLeft(featuresOfConditionBlock, position.X);
                Canvas.SetTop(featuresOfConditionBlock, position.Y);
            }
            else if (e.Data.GetDataPresent(typeof(StartEndBlock)))
            {
                var position = e.GetPosition(destination);
                var featuresOfStartEndBlock = ((StartEndBlock)e.Data.GetData(typeof(StartEndBlock))).GetUIElement();
                Canvas.SetLeft(featuresOfStartEndBlock, position.X);
                Canvas.SetTop(featuresOfStartEndBlock, position.Y);
            }
            else if (e.Data.GetDataPresent(typeof(InputOutputBlock)))
            {
                var position = e.GetPosition(destination);
                var featuresOfInputOutputBlock = ((InputOutputBlock)e.Data.GetData(typeof(InputOutputBlock))).GetUIElement();
                Canvas.SetLeft(featuresOfInputOutputBlock, position.X);
                Canvas.SetTop(featuresOfInputOutputBlock, position.Y);
            }
            else if (e.Data.GetDataPresent(typeof(SubroutineBlock)))
            {
                var position = e.GetPosition(destination);
                var featuresOfSubroutineBlock = ((SubroutineBlock)e.Data.GetData(typeof(SubroutineBlock))).GetUIElement();
                Canvas.SetLeft(featuresOfSubroutineBlock, position.X);
                Canvas.SetTop(featuresOfSubroutineBlock, position.Y);
            }
            else if (e.Data.GetDataPresent(typeof(LinkBlock)))
            {
                var position = e.GetPosition(destination);
                var featuresOfLinkBlock = ((LinkBlock)e.Data.GetData(typeof(LinkBlock))).GetUIElement();
                Canvas.SetLeft(featuresOfLinkBlock, position.X);
                Canvas.SetTop(featuresOfLinkBlock, position.Y);
            }
            e.Handled = true;
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
                var resultTransferInformation = (ActionBlockForMovements)e.Data.GetData(typeof(ActionBlockForMovements));
                Canvas.SetLeft((UIElement)resultTransferInformation.transferInformationActionBlock, position.X + 1);
                Canvas.SetTop((UIElement)resultTransferInformation.transferInformationActionBlock, position.Y + 1);

            }
            else if (e.Data.GetDataPresent(typeof(ConditionBlock)))
            {
                e.Effects = DragDropEffects.Copy;
                var position = e.GetPosition(destination);
                var dataInformationConditionBlock = (ConditionBlock)e.Data.GetData(typeof(ConditionBlock)); 
                UIElement conditionBlockOfUIElement;
                if (dataInformationConditionBlock.GetUIElementWithoutCreate() == null)
                {
                    conditionBlockOfUIElement = ((ConditionBlock)e.Data.GetData(typeof(ConditionBlock))).GetUIElement();
                    destination.Children.Add(conditionBlockOfUIElement);
                }
                else
                {
                    conditionBlockOfUIElement = ((ConditionBlock)e.Data.GetData(typeof(ConditionBlock))).GetUIElement();
                }
                Canvas.SetLeft(conditionBlockOfUIElement, position.X + 1);
                Canvas.SetTop(conditionBlockOfUIElement, position.Y + 1);

            }
            else if (e.Data.GetDataPresent(typeof(ConditionBlockForMovements)))
            {
                e.Effects = DragDropEffects.Copy;
                var position = e.GetPosition(destination);
                var resultTransferInformation = (ConditionBlockForMovements)e.Data.GetData(typeof(ConditionBlockForMovements));
                Canvas.SetLeft((UIElement)resultTransferInformation.transferInformation, position.X + 1);
                Canvas.SetTop((UIElement)resultTransferInformation.transferInformation, position.Y + 1);

            }
            else if (e.Data.GetDataPresent(typeof(StartEndBlock)))
            {
                e.Effects = DragDropEffects.Copy;
                var position = e.GetPosition(destination);
                var dataInformationOfStartEndBlock = (StartEndBlock)e.Data.GetData(typeof(StartEndBlock)); 
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

            } 
            else if (e.Data.GetDataPresent(typeof(StartEndBlockForMovements)))
            {
                e.Effects = DragDropEffects.Copy;
                var position = e.GetPosition(destination);
                var resultTransferInformation = (StartEndBlockForMovements)e.Data.GetData(typeof(StartEndBlockForMovements));
                Canvas.SetLeft((UIElement)resultTransferInformation.transferInformation, position.X + 1);
                Canvas.SetTop((UIElement)resultTransferInformation.transferInformation, position.Y + 1);
            } 
            else if (e.Data.GetDataPresent(typeof(InputOutputBlock)))
            {
                e.Effects = DragDropEffects.Copy;
                var position = e.GetPosition(destination);
                var dataInformationOfInputOutputBlock = (InputOutputBlock)e.Data.GetData(typeof(InputOutputBlock)); 
                UIElement inputOutputBlockOfUIElement;
                if (dataInformationOfInputOutputBlock.GetUIElementWithoutCreate() == null)
                {
                    inputOutputBlockOfUIElement = ((InputOutputBlock)e.Data.GetData(typeof(InputOutputBlock))).GetUIElement();
                    destination.Children.Add(inputOutputBlockOfUIElement);
                }
                else
                {
                    inputOutputBlockOfUIElement = ((InputOutputBlock)e.Data.GetData(typeof(InputOutputBlock))).GetUIElement();
                }
                Canvas.SetLeft(inputOutputBlockOfUIElement, position.X + 1);
                Canvas.SetTop(inputOutputBlockOfUIElement, position.Y + 1);

            }
            else if (e.Data.GetDataPresent(typeof(InputOutputBlockForMovements)))
            {
                e.Effects = DragDropEffects.Copy;
                var position = e.GetPosition(destination);
                var resultTransferInformation = (InputOutputBlockForMovements)e.Data.GetData(typeof(InputOutputBlockForMovements));
                Canvas.SetLeft((UIElement)resultTransferInformation.transferInformation, position.X + 1);
                Canvas.SetTop((UIElement)resultTransferInformation.transferInformation, position.Y + 1);
            }
            else if (e.Data.GetDataPresent(typeof(SubroutineBlock)))
            {
                e.Effects = DragDropEffects.Copy;
                var position = e.GetPosition(destination);
                var dataInformationOfSubroutineBlock = (SubroutineBlock)e.Data.GetData(typeof(SubroutineBlock));
                UIElement subroutineBlockOfUIElement;
                if (dataInformationOfSubroutineBlock.GetUIElementWithoutCreate() == null)
                {
                    subroutineBlockOfUIElement = ((SubroutineBlock)e.Data.GetData(typeof(SubroutineBlock))).GetUIElement();
                    destination.Children.Add(subroutineBlockOfUIElement);
                }
                else
                {
                    subroutineBlockOfUIElement = ((SubroutineBlock)e.Data.GetData(typeof(SubroutineBlock))).GetUIElement();
                }
                Canvas.SetLeft(subroutineBlockOfUIElement, position.X + 1);
                Canvas.SetTop(subroutineBlockOfUIElement, position.Y + 1);

            }
            else if (e.Data.GetDataPresent(typeof(SubroutineBlockForMovements)))
            {
                e.Effects = DragDropEffects.Copy;
                var position = e.GetPosition(destination);
                var resultTransferInformation = (SubroutineBlockForMovements)e.Data.GetData(typeof(SubroutineBlockForMovements));
                Canvas.SetLeft((UIElement)resultTransferInformation.transferInformation, position.X + 1);
                Canvas.SetTop((UIElement)resultTransferInformation.transferInformation, position.Y + 1);
            }
            else if (e.Data.GetDataPresent(typeof(LinkBlock)))
            {
                e.Effects = DragDropEffects.Copy;
                var position = e.GetPosition(destination);
                var dataInformationOfLinkBlock = (LinkBlock)e.Data.GetData(typeof(LinkBlock));
                UIElement linkBlockOfUIElement;
                if (dataInformationOfLinkBlock.GetUIElementWithoutCreate() == null)
                {
                    linkBlockOfUIElement = ((LinkBlock)e.Data.GetData(typeof(LinkBlock))).GetUIElement();
                    destination.Children.Add(linkBlockOfUIElement);
                }
                else
                {
                    linkBlockOfUIElement = ((LinkBlock)e.Data.GetData(typeof(LinkBlock))).GetUIElement();
                }
                Canvas.SetLeft(linkBlockOfUIElement, position.X + 1);
                Canvas.SetTop(linkBlockOfUIElement, position.Y + 1);

            }
            else if (e.Data.GetDataPresent(typeof(LinkBlockForMovements)))
            {
                e.Effects = DragDropEffects.Copy;
                var position = e.GetPosition(destination);
                var resultTransferInformation = (LinkBlockForMovements)e.Data.GetData(typeof(LinkBlockForMovements));
                Canvas.SetLeft((UIElement)resultTransferInformation.transferInformation, position.X + 1);
                Canvas.SetTop((UIElement)resultTransferInformation.transferInformation, position.Y + 1);
            }
            else e.Effects = DragDropEffects.None;
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
            else if (e.Data.GetDataPresent(typeof(ConditionBlock)))
            {
                var conditionBlockOfUIElement = ((ConditionBlock)e.Data.GetData(typeof(ConditionBlock))).GetUIElement();
                destination.Children.Remove(conditionBlockOfUIElement);
                var dataInformationOfconditionBlock = (ConditionBlock)e.Data.GetData(typeof(ConditionBlock));
                dataInformationOfconditionBlock.Reset();
            }
            else if (e.Data.GetDataPresent(typeof(StartEndBlock)))
            {
                var startEndBlockOfUIElement = ((StartEndBlock)e.Data.GetData(typeof(StartEndBlock))).GetUIElement();
                destination.Children.Remove(startEndBlockOfUIElement);
                var dataInformationOfStartEndBlock = (StartEndBlock)e.Data.GetData(typeof(StartEndBlock));
                dataInformationOfStartEndBlock.Reset();
            } 
            else if (e.Data.GetDataPresent(typeof(SubroutineBlock)))
            {
                var startEndBlockOfUIElement = ((SubroutineBlock)e.Data.GetData(typeof(SubroutineBlock))).GetUIElement();
                destination.Children.Remove(startEndBlockOfUIElement);
                var dataInformationOfStartEndBlock = (SubroutineBlock)e.Data.GetData(typeof(SubroutineBlock));
                dataInformationOfStartEndBlock.Reset();
            }
            else if (e.Data.GetDataPresent(typeof(LinkBlock)))
            {
                var startEndBlockOfUIElement = ((LinkBlock)e.Data.GetData(typeof(LinkBlock))).GetUIElement();
                destination.Children.Remove(startEndBlockOfUIElement);
                var dataInformationOfStartEndBlock = (LinkBlock)e.Data.GetData(typeof(LinkBlock));
                dataInformationOfStartEndBlock.Reset();
            }
            e.Handled = true;
        }
    }
}