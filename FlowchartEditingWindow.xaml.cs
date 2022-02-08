using Flowchart_Editor.Models;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace Flowchart_Editor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int minHeight = 760;
        const int minWidth = 1024; 
        public MainWindow()
        {
            InitializeComponent();
            MinHeight = minHeight;
            MinWidth = minWidth;     
        }
        List<AllApplicationBlocks> listAllApplicationBlocks = new List<AllApplicationBlocks>();
        private void test()
        {
            foreach (AllApplicationBlocks allApplicationBlocks in listAllApplicationBlocks) {
                allApplicationBlocks.actionBlok.textOfActionBlock.Text = "";

                
                    }

        }
        public void actionBlock_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var instanceOfActionBlock = new ActionBlock();
                var allApplicationBlocks = new AllApplicationBlocks(instanceOfActionBlock);
                listAllApplicationBlocks.Add(allApplicationBlocks);
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
        private void cycleBlockFor_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var instanceOfCycleForBlock = new CycleForBlock();
                var dataObjectInstanceOfCycleForBlock = new DataObject(typeof(CycleForBlock), instanceOfCycleForBlock);
                DragDrop.DoDragDrop(sender as DependencyObject, dataObjectInstanceOfCycleForBlock, DragDropEffects.Copy);
            }
            e.Handled = true;
        }
        private void cycleBlockWhileBegin_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var instanceOfCycleWhileBlock = new CycleWhileBeginBlock();
                var dataObjectInstanceOfCycleWhileBlock = new DataObject(typeof(CycleWhileBeginBlock), instanceOfCycleWhileBlock);
                DragDrop.DoDragDrop(sender as DependencyObject, dataObjectInstanceOfCycleWhileBlock, DragDropEffects.Copy);
            }
            e.Handled = true;
        }
        private void cycleBlockWhileEnd_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var instanceOfCycleWhileBlock = new CycleWhileEndBlock();
                var dataObjectInstanceOfCycleWhileBlock = new DataObject(typeof(CycleWhileEndBlock), instanceOfCycleWhileBlock);
                DragDrop.DoDragDrop(sender as DependencyObject, dataObjectInstanceOfCycleWhileBlock, DragDropEffects.Copy);
            }
            e.Handled = true;
        }
        private void linkBlock_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var instanceOfLinkBlock = new LinkBlock();
                var dataObjectInformationOfLinkBlock = new DataObject(typeof(LinkBlock), instanceOfLinkBlock);
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
            else if (e.Data.GetDataPresent(typeof(CycleForBlock)))
            {
                var position = e.GetPosition(destination);
                var featuresOfCycleForBlock = ((CycleForBlock)e.Data.GetData(typeof(CycleForBlock))).GetUIElement();
                Canvas.SetLeft(featuresOfCycleForBlock, position.X);
                Canvas.SetTop(featuresOfCycleForBlock, position.Y);
            }
            else if (e.Data.GetDataPresent(typeof(CycleWhileBeginBlock)))
            {
                var position = e.GetPosition(destination);
                var featuresOfCycleForBlock = ((CycleWhileBeginBlock)e.Data.GetData(typeof(CycleWhileBeginBlock))).GetUIElement();
                Canvas.SetLeft(featuresOfCycleForBlock, position.X);
                Canvas.SetTop(featuresOfCycleForBlock, position.Y);
            }
            else if (e.Data.GetDataPresent(typeof(CycleWhileEndBlock)))
            {
                var position = e.GetPosition(destination);
                var featuresOfCycleWhileBlock = ((CycleWhileEndBlock)e.Data.GetData(typeof(CycleWhileEndBlock))).GetUIElement();
                Canvas.SetLeft(featuresOfCycleWhileBlock, position.X);
                Canvas.SetTop(featuresOfCycleWhileBlock, position.Y);
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
            else if (e.Data.GetDataPresent(typeof(CycleForBlock)))
            {
                e.Effects = DragDropEffects.Copy;
                var position = e.GetPosition(destination);
                var dataInformationOfSubroutineBlock = (CycleForBlock)e.Data.GetData(typeof(CycleForBlock));
                UIElement subroutineBlockOfUIElement;
                if (dataInformationOfSubroutineBlock.GetUIElementWithoutCreate() == null)
                {
                    subroutineBlockOfUIElement = ((CycleForBlock)e.Data.GetData(typeof(CycleForBlock))).GetUIElement();
                    destination.Children.Add(subroutineBlockOfUIElement);
                }
                else
                {
                    subroutineBlockOfUIElement = ((CycleForBlock)e.Data.GetData(typeof(CycleForBlock))).GetUIElement();
                }
                Canvas.SetLeft(subroutineBlockOfUIElement, position.X + 1);
                Canvas.SetTop(subroutineBlockOfUIElement, position.Y + 1);

            }
            else if (e.Data.GetDataPresent(typeof(CycleForBlockForMovements)))
            {
                e.Effects = DragDropEffects.Copy;
                var position = e.GetPosition(destination);
                var resultTransferInformation = (CycleForBlockForMovements)e.Data.GetData(typeof(CycleForBlockForMovements));
                Canvas.SetLeft((UIElement)resultTransferInformation.transferInformation, position.X + 1);
                Canvas.SetTop((UIElement)resultTransferInformation.transferInformation, position.Y + 1);
            }
            else if (e.Data.GetDataPresent(typeof(CycleWhileBeginBlock)))
            {
                e.Effects = DragDropEffects.Copy;
                var position = e.GetPosition(destination);
                var dataInformationOfSubroutineBlock = (CycleWhileBeginBlock)e.Data.GetData(typeof(CycleWhileBeginBlock));
                UIElement subroutineBlockOfUIElement;
                if (dataInformationOfSubroutineBlock.GetUIElementWithoutCreate() == null)
                {
                    subroutineBlockOfUIElement = ((CycleWhileBeginBlock)e.Data.GetData(typeof(CycleWhileBeginBlock))).GetUIElement();
                    destination.Children.Add(subroutineBlockOfUIElement);
                }
                else
                {
                    subroutineBlockOfUIElement = ((CycleWhileBeginBlock)e.Data.GetData(typeof(CycleWhileBeginBlock))).GetUIElement();
                }
                Canvas.SetLeft(subroutineBlockOfUIElement, position.X + 1);
                Canvas.SetTop(subroutineBlockOfUIElement, position.Y + 1);

            }
            else if (e.Data.GetDataPresent(typeof(CycleWhileBeginBlockForMovements)))
            {
                e.Effects = DragDropEffects.Copy;
                var position = e.GetPosition(destination);
                var resultTransferInformation = (CycleWhileBeginBlockForMovements)e.Data.GetData(typeof(CycleWhileBeginBlockForMovements));
                Canvas.SetLeft((UIElement)resultTransferInformation.transferInformation, position.X + 1);
                Canvas.SetTop((UIElement)resultTransferInformation.transferInformation, position.Y + 1);
            }
            else if (e.Data.GetDataPresent(typeof(CycleWhileEndBlock)))
            {
                e.Effects = DragDropEffects.Copy;
                var position = e.GetPosition(destination);
                var dataInformationOfSubroutineBlock = (CycleWhileEndBlock)e.Data.GetData(typeof(CycleWhileEndBlock));
                UIElement subroutineBlockOfUIElement;
                if (dataInformationOfSubroutineBlock.GetUIElementWithoutCreate() == null)
                {
                    subroutineBlockOfUIElement = ((CycleWhileEndBlock)e.Data.GetData(typeof(CycleWhileEndBlock))).GetUIElement();
                    destination.Children.Add(subroutineBlockOfUIElement);
                }
                else
                {
                    subroutineBlockOfUIElement = ((CycleWhileEndBlock)e.Data.GetData(typeof(CycleWhileEndBlock))).GetUIElement();
                }
                Canvas.SetLeft(subroutineBlockOfUIElement, position.X + 1);
                Canvas.SetTop(subroutineBlockOfUIElement, position.Y + 1);

            }
            else if (e.Data.GetDataPresent(typeof(CycleWhileEndBlockForMovements)))
            {
                e.Effects = DragDropEffects.Copy;
                var position = e.GetPosition(destination);
                var resultTransferInformation = (CycleWhileEndBlockForMovements)e.Data.GetData(typeof(CycleWhileEndBlockForMovements));
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
            else if (e.Data.GetDataPresent(typeof(CycleForBlock)))
            {
                var startEndBlockOfUIElement = ((CycleForBlock)e.Data.GetData(typeof(CycleForBlock))).GetUIElement();
                destination.Children.Remove(startEndBlockOfUIElement);
                var dataInformationOfStartEndBlock = (CycleForBlock)e.Data.GetData(typeof(CycleForBlock));
                dataInformationOfStartEndBlock.Reset();
            }
            else if (e.Data.GetDataPresent(typeof(CycleWhileBeginBlock)))
            {
                var startEndBlockOfUIElement = ((CycleWhileBeginBlock)e.Data.GetData(typeof(CycleWhileBeginBlock))).GetUIElement();
                destination.Children.Remove(startEndBlockOfUIElement);
                var dataInformationOfStartEndBlock = (CycleWhileBeginBlock)e.Data.GetData(typeof(CycleWhileBeginBlock));
                dataInformationOfStartEndBlock.Reset();
            }
            else if (e.Data.GetDataPresent(typeof(CycleWhileEndBlock)))
            {
                var startEndBlockOfUIElement = ((CycleWhileEndBlock)e.Data.GetData(typeof(CycleWhileEndBlock))).GetUIElement();
                destination.Children.Remove(startEndBlockOfUIElement);
                var dataInformationOfStartEndBlock = (CycleWhileEndBlock)e.Data.GetData(typeof(CycleWhileEndBlock));
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

        private void listViewItem_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ButtonCloseMenu.Visibility = Visibility.Visible;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
        }

        private void toggleButtonStyleTheme_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)toggleButtonStyleTheme.IsChecked)
            {
                BrushConverter color = new BrushConverter();

                homeIcon.Foreground = (Brush)color.ConvertFrom("#FFF9F9FB");
                homeText.Foreground = (Brush)color.ConvertFrom("#FFF9F9FB");

                instagramIcon.Foreground = (Brush)color.ConvertFrom("#FFF9F9FB");
                instagramText.Foreground = (Brush)color.ConvertFrom("#FFF9F9FB");

                facebookIcon.Foreground = (Brush)color.ConvertFrom("#FFF9F9FB");
                facebookText.Foreground = (Brush)color.ConvertFrom("#FFF9F9FB");

                twitterIcon.Foreground = (Brush)color.ConvertFrom("#FFF9F9FB");
                twitterText.Foreground = (Brush)color.ConvertFrom("#FFF9F9FB");

                
                toggleButtonStyleTheme.Background = (Brush)color.ConvertFrom("#FFF9F9FB");
                topicName.Foreground = (Brush)color.ConvertFrom("#FFF9F9FB");
                topicName.Text = "Tёмная тема";

                GridPanelMenu.Background = (Brush)color.ConvertFrom("#FF040205");

                ButtonOpenMenu.Foreground = (Brush)color.ConvertFrom("#FFF9F9FB");
                ButtonCloseMenu.Foreground = (Brush)color.ConvertFrom("#FFF9F9FB");

                GridMain.Background = (Brush)color.ConvertFrom("#FF262427");

                lineSeparatingLocationOfBlocksAndField.Background = (Brush)color.ConvertFrom("#FFF9F9FB");

                destination.Background = (Brush)color.ConvertFrom("#FF262427");

                actionBlockText.Foreground = (Brush)color.ConvertFrom("#FFF9F9FB");
                conditionBlockText.Foreground = (Brush)color.ConvertFrom("#FFF9F9FB");
                startEndBlockText.Foreground = (Brush)color.ConvertFrom("#FFF9F9FB");
                inputOutputBlockText.Foreground = (Brush)color.ConvertFrom("#FFF9F9FB");
                subroutineBlockText.Foreground = (Brush)color.ConvertFrom("#FFF9F9FB");
                cycleBlockForText.Foreground = (Brush)color.ConvertFrom("#FFF9F9FB");
                cycleBlockWhileBeginText.Foreground = (Brush)color.ConvertFrom("#FFF9F9FB");
                cycleBlockWhileEndText.Foreground = (Brush)color.ConvertFrom("#FFF9F9FB");
                linkBlockText.Foreground = (Brush)color.ConvertFrom("#FFF9F9FB");
            }
            else
            {
                BrushConverter color = new BrushConverter();

                homeIcon.Foreground = (Brush)color.ConvertFrom("#FF040205");
                homeText.Foreground = (Brush)color.ConvertFrom("#FF040205");

                instagramIcon.Foreground = (Brush)color.ConvertFrom("#FF040205");
                instagramText.Foreground = (Brush)color.ConvertFrom("#FF040205");

                facebookIcon.Foreground = (Brush)color.ConvertFrom("#FF040205");
                facebookText.Foreground = (Brush)color.ConvertFrom("#FF040205");

                twitterIcon.Foreground = (Brush)color.ConvertFrom("#FF040205");
                twitterText.Foreground = (Brush)color.ConvertFrom("#FF040205");
               
                topicName.Foreground = (Brush)color.ConvertFrom("#FF040205");
                topicName.Text = "Светлая тема";

                GridPanelMenu.Background = (Brush)color.ConvertFrom("#FFF9F9FB");

                ButtonOpenMenu.Foreground = (Brush)color.ConvertFrom("#FF040205");
                ButtonCloseMenu.Foreground = (Brush)color.ConvertFrom("#FF040205");

                GridMain.Background = (Brush)color.ConvertFrom("#FFF9F9FB");

                lineSeparatingLocationOfBlocksAndField.Background = (Brush)color.ConvertFrom("#FF040205");

                destination.Background = (Brush)color.ConvertFrom("#FFF9F9FB");

                actionBlockText.Foreground = (Brush)color.ConvertFrom("#FF040205");
                conditionBlockText.Foreground = (Brush)color.ConvertFrom("#FF040205");
                startEndBlockText.Foreground = (Brush)color.ConvertFrom("#FF040205");
                inputOutputBlockText.Foreground = (Brush)color.ConvertFrom("#FF040205");
                subroutineBlockText.Foreground = (Brush)color.ConvertFrom("#FF040205");
                cycleBlockForText.Foreground = (Brush)color.ConvertFrom("#FF040205");
                cycleBlockWhileBeginText.Foreground = (Brush)color.ConvertFrom("#FF040205");
                cycleBlockWhileEndText.Foreground = (Brush)color.ConvertFrom("#FF040205");
                linkBlockText.Foreground = (Brush)color.ConvertFrom("#FF040205");
            }
        }
    }
}