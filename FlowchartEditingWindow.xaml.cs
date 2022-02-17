using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Flowchart_Editor.Models;

namespace Flowchart_Editor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int minHeight = 760;
        const int minWidth = 1380; 
        public MainWindow()
        {
            InitializeComponent();
            MinHeight = minHeight;
            MinWidth = minWidth;
            for (int i = 8; i <= 36; i += 2)
                fontSizeComboBox.Items.Add(i);

            for (int i = 90; i <= 250; i += 10)
                blockWidthComboBox.Items.Add(i);

            for (int i = 60; i <= 250; i += 10)
                blockHeightComboBox.Items.Add(i);
        }
        List<ActionBlock> listActionBlock = new List<ActionBlock>();
        public void actionBlock_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var instanceOfActionBlock = new ActionBlock();
                listActionBlock.Add(instanceOfActionBlock);
                var dataObjectInformationOfActionBlock = new DataObject(typeof(ActionBlock), instanceOfActionBlock);
                DragDrop.DoDragDrop(sender as DependencyObject, dataObjectInformationOfActionBlock, DragDropEffects.Copy);
            }
            e.Handled = true;
        }
        List<ConditionBlock> listConditionBlock = new List<ConditionBlock>();
        private void conditionBlock_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var instanceOfConditionBlock = new ConditionBlock();
                listConditionBlock.Add(instanceOfConditionBlock);
                var dataObjectInformationOConditionBlock = new DataObject(typeof(ConditionBlock), instanceOfConditionBlock);
                DragDrop.DoDragDrop(conditionBlock, dataObjectInformationOConditionBlock, DragDropEffects.Copy);
            }
            e.Handled = true;
        }
        List<StartEndBlock> listStartEndBlock = new List<StartEndBlock>();
        private void startEndBlock_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var instanceOfStartEndBlock = new StartEndBlock();
                listStartEndBlock.Add(instanceOfStartEndBlock);
                var dataObjectInformationOfStartEndBlock = new DataObject(typeof(StartEndBlock), instanceOfStartEndBlock);
                DragDrop.DoDragDrop(sender as DependencyObject, dataObjectInformationOfStartEndBlock, DragDropEffects.Copy);
            }
            e.Handled = true;
        }
        List<InputOutputBlock> listInputOutputBlock = new List<InputOutputBlock>();
        private void inputOutputBlock_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var instanceOfInputOutputBlock = new InputOutputBlock();
                listInputOutputBlock.Add(instanceOfInputOutputBlock);
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
            buttonOpenMenu.Visibility = Visibility.Collapsed;
            buttonCloseMenu.Visibility = Visibility.Visible;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            buttonOpenMenu.Visibility = Visibility.Visible;
            buttonCloseMenu.Visibility = Visibility.Collapsed;
        }

        const string darkWhite = "#FFF9F9FB";
        const string darkBlack = "#FF040205";
        const string lightBlack = "#FF262427";
        const string darkTheme = "Тёмная тема";
        const string lightThene = "Светлая тема";

        private void toggleButtonStyleTheme_Click(object sender, RoutedEventArgs e)
        {
            if (toggleButtonStyleTheme.IsChecked != null)
            {
                if ((bool)toggleButtonStyleTheme.IsChecked)
                {
                    BrushConverter color = new BrushConverter();

                    homeIcon.Foreground = (Brush)color.ConvertFrom(darkWhite);
                    homeText.Foreground = (Brush)color.ConvertFrom(darkWhite);

                    instagramIcon.Foreground = (Brush)color.ConvertFrom(darkWhite);
                    instagramText.Foreground = (Brush)color.ConvertFrom(darkWhite);

                    facebookIcon.Foreground = (Brush)color.ConvertFrom(darkWhite);
                    facebookText.Foreground = (Brush)color.ConvertFrom(darkWhite);

                    twitterIcon.Foreground = (Brush)color.ConvertFrom(darkWhite);
                    twitterText.Foreground = (Brush)color.ConvertFrom(darkWhite);


                    toggleButtonStyleTheme.Background = (Brush)color.ConvertFrom(darkWhite);
                    topicName.Foreground = (Brush)color.ConvertFrom(darkWhite);
                    topicName.Text = darkTheme;

                    navigationMenu.Background = (Brush)color.ConvertFrom(darkBlack);

                    buttonOpenMenu.Foreground = (Brush)color.ConvertFrom(darkWhite);
                    buttonCloseMenu.Foreground = (Brush)color.ConvertFrom(darkWhite);

                    blockLayoutMenu.Background = (Brush)color.ConvertFrom(lightBlack);

                    lineSeparatingLocationOfBlocksAndField.Background = (Brush)color.ConvertFrom(darkWhite);

                    destination.Background = (Brush)color.ConvertFrom(lightBlack);

                    actionBlockText.Foreground = (Brush)color.ConvertFrom(darkWhite);
                    conditionBlockText.Foreground = (Brush)color.ConvertFrom(darkWhite);
                    startEndBlockText.Foreground = (Brush)color.ConvertFrom(darkWhite);
                    inputOutputBlockText.Foreground = (Brush)color.ConvertFrom(darkWhite);
                    subroutineBlockText.Foreground = (Brush)color.ConvertFrom(darkWhite);
                    cycleBlockForText.Foreground = (Brush)color.ConvertFrom(darkWhite);
                    cycleBlockWhileBeginText.Foreground = (Brush)color.ConvertFrom(darkWhite);
                    cycleBlockWhileEndText.Foreground = (Brush)color.ConvertFrom(darkWhite);
                    linkBlockText.Foreground = (Brush)color.ConvertFrom(darkWhite);

                    textFont.Foreground = (Brush)color.ConvertFrom(darkWhite);
                    textFontSize.Foreground = (Brush)color.ConvertFrom(darkWhite);
                    textWidth.Foreground = (Brush)color.ConvertFrom(darkWhite);
                    textHeight.Foreground = (Brush)color.ConvertFrom(darkWhite);

                    DefaultPropertyForBlock.colorPoint = darkWhite;
                    foreach (ActionBlock listActionBlock in listActionBlock)
                    {
                        listActionBlock.firstPointToConnect.Fill = (Brush)color.ConvertFrom(darkWhite);
                        listActionBlock.secondPointToConnect.Fill = (Brush)color.ConvertFrom(darkWhite);
                        listActionBlock.thirdPointToConnect.Fill = (Brush)color.ConvertFrom(darkWhite);
                        listActionBlock.fourthPointToConnect.Fill = (Brush)color.ConvertFrom(darkWhite);

                    }
                    foreach (ConditionBlock itemListConditionBlock in listConditionBlock)
                    {
                        itemListConditionBlock.firstPointToConnect.Fill = (Brush)color.ConvertFrom(darkWhite);
                        itemListConditionBlock.secondPointToConnect.Fill = (Brush)color.ConvertFrom(darkWhite);
                        itemListConditionBlock.thirdPointToConnect.Fill = (Brush)color.ConvertFrom(darkWhite);
                        itemListConditionBlock.fourthPointToConnect.Fill = (Brush)color.ConvertFrom(darkWhite);
                    }
                }
                else
                {
                    BrushConverter color = new BrushConverter();

                    homeIcon.Foreground = (Brush)color.ConvertFrom(darkBlack);
                    homeText.Foreground = (Brush)color.ConvertFrom(darkBlack);

                    instagramIcon.Foreground = (Brush)color.ConvertFrom(darkBlack);
                    instagramText.Foreground = (Brush)color.ConvertFrom(darkBlack);

                    facebookIcon.Foreground = (Brush)color.ConvertFrom(darkBlack);
                    facebookText.Foreground = (Brush)color.ConvertFrom(darkBlack);

                    twitterIcon.Foreground = (Brush)color.ConvertFrom(darkBlack);
                    twitterText.Foreground = (Brush)color.ConvertFrom(darkBlack);

                    topicName.Foreground = (Brush)color.ConvertFrom(darkBlack);
                    topicName.Text = lightThene;

                    navigationMenu.Background = (Brush)color.ConvertFrom(darkWhite);

                    buttonOpenMenu.Foreground = (Brush)color.ConvertFrom(darkBlack);
                    buttonCloseMenu.Foreground = (Brush)color.ConvertFrom(darkBlack);

                    blockLayoutMenu.Background = (Brush)color.ConvertFrom(darkWhite);

                    lineSeparatingLocationOfBlocksAndField.Background = (Brush)color.ConvertFrom(darkBlack);

                    destination.Background = (Brush)color.ConvertFrom(darkWhite);

                    actionBlockText.Foreground = (Brush)color.ConvertFrom(darkBlack);
                    conditionBlockText.Foreground = (Brush)color.ConvertFrom(darkBlack);
                    startEndBlockText.Foreground = (Brush)color.ConvertFrom(darkBlack);
                    inputOutputBlockText.Foreground = (Brush)color.ConvertFrom(darkBlack);
                    subroutineBlockText.Foreground = (Brush)color.ConvertFrom(darkBlack);
                    cycleBlockForText.Foreground = (Brush)color.ConvertFrom(darkBlack);
                    cycleBlockWhileBeginText.Foreground = (Brush)color.ConvertFrom(darkBlack);
                    cycleBlockWhileEndText.Foreground = (Brush)color.ConvertFrom(darkBlack);
                    linkBlockText.Foreground = (Brush)color.ConvertFrom(darkBlack);

                    textFont.Foreground = (Brush)color.ConvertFrom(darkBlack);
                    textFontSize.Foreground = (Brush)color.ConvertFrom(darkBlack);
                    textWidth.Foreground = (Brush)color.ConvertFrom(darkBlack);
                    textHeight.Foreground = (Brush)color.ConvertFrom(darkBlack);

                    DefaultPropertyForBlock.colorPoint = darkBlack;
                    foreach (ActionBlock itemListActionBlock in listActionBlock)
                    {
                        itemListActionBlock.firstPointToConnect.Fill = (Brush)color.ConvertFrom(darkBlack);
                        itemListActionBlock.secondPointToConnect.Fill = (Brush)color.ConvertFrom(darkBlack);
                        itemListActionBlock.thirdPointToConnect.Fill = (Brush)color.ConvertFrom(darkBlack);
                        itemListActionBlock.fourthPointToConnect.Fill = (Brush)color.ConvertFrom(darkBlack);
                    }
                    foreach (ConditionBlock itemListConditionBlock in listConditionBlock)
                    {
                        itemListConditionBlock.firstPointToConnect.Fill = (Brush)color.ConvertFrom(darkBlack);
                        itemListConditionBlock.secondPointToConnect.Fill = (Brush)color.ConvertFrom(darkBlack);
                        itemListConditionBlock.thirdPointToConnect.Fill = (Brush)color.ConvertFrom(darkBlack);
                        itemListConditionBlock.fourthPointToConnect.Fill = (Brush)color.ConvertFrom(darkBlack);
                    }
                }
            }
        }

        private void listOfFontsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem typeItem = (ComboBoxItem)listOfFontsComboBox.SelectedItem;
            FontFamily fontFamily = new FontFamily(typeItem.Content.ToString());
            foreach (ActionBlock listActionBlock in listActionBlock)
            {
                listActionBlock.textBoxOfActionBlock.FontFamily = fontFamily;
                listActionBlock.textBlockOfActionBlock.FontFamily = fontFamily;
            }
        }

        private void fontSizeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (ActionBlock listActionBlock in listActionBlock)
            {
                listActionBlock.textBoxOfActionBlock.FontSize = Convert.ToInt32(fontSizeComboBox.SelectedItem);
                listActionBlock.textBlockOfActionBlock.FontSize = Convert.ToInt32(fontSizeComboBox.SelectedItem);
            }
        }

        private void blockWidthComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int valueBlokWidth = Convert.ToInt32(blockWidthComboBox.SelectedItem);
            DefaultPropertyForBlock.Width = (int)valueBlokWidth;
            foreach (ActionBlock itemListActionBlock in listActionBlock)
            {
                itemListActionBlock.canvasOfActionBlock.Width = valueBlokWidth;
                itemListActionBlock.textBoxOfActionBlock.Width = valueBlokWidth;
                itemListActionBlock.textBlockOfActionBlock.Width = valueBlokWidth;
                Canvas.SetLeft(itemListActionBlock.firstPointToConnect, valueBlokWidth / 2 - 2);
                Canvas.SetLeft(itemListActionBlock.thirdPointToConnect, valueBlokWidth / 2 - 2);
                Canvas.SetLeft(itemListActionBlock.fourthPointToConnect, valueBlokWidth - 4);
                
            }
            int valueBlokHeight = DefaultPropertyForBlock.Height;
            foreach (ConditionBlock itemListConditionBlock in listConditionBlock)
            {
                Point Point1 = new Point(0, valueBlokHeight / 2);
                Point Point2 = new Point(valueBlokWidth / 2, valueBlokHeight);
                Point Point3 = new Point(valueBlokWidth, valueBlokHeight / 2);
                Point Point4 = new Point(valueBlokWidth / 2, 0);
                Point Point5 = new Point(0, valueBlokHeight / 2);
                PointCollection myPointCollection = new PointCollection();
                myPointCollection.Add(Point1);
                myPointCollection.Add(Point2);
                myPointCollection.Add(Point3);
                myPointCollection.Add(Point4);
                myPointCollection.Add(Point5);
                itemListConditionBlock.polygonConditionBlock.Points = myPointCollection;
                itemListConditionBlock.textBoxOfConditionBlock.Width = valueBlokWidth / 2;
                itemListConditionBlock.textBlocOfConditionBlock.Width = valueBlokWidth / 2;
                Canvas.SetLeft(itemListConditionBlock.textBlocOfConditionBlock, valueBlokWidth / 2 - (valueBlokWidth / 4));
                Canvas.SetLeft(itemListConditionBlock.textBoxOfConditionBlock, valueBlokWidth / 2 - (valueBlokWidth / 4));
                Canvas.SetLeft(itemListConditionBlock.firstPointToConnect, valueBlokWidth / 2 - 3);
                Canvas.SetLeft(itemListConditionBlock.secondPointToConnect, -2 + 2);
                Canvas.SetLeft(itemListConditionBlock.thirdPointToConnect, valueBlokWidth / 2 - 3);
                Canvas.SetLeft(itemListConditionBlock.fourthPointToConnect, valueBlokWidth - 6);
            }
            foreach (StartEndBlock itemListStartEndBlock in listStartEndBlock)
            {
                itemListStartEndBlock.canvasStartEndBlock.Width = valueBlokWidth;
                itemListStartEndBlock.rectangleStartEndBlock.Width = valueBlokWidth;
                itemListStartEndBlock.textBlockOfStartEnd.Width = valueBlokWidth;
            }
            foreach (InputOutputBlock itemListInputOutputBlock in listInputOutputBlock)
            {
                Point Point1 = new Point(20, 0);
                Point Point2 = new Point(0, valueBlokHeight);
                Point Point3 = new Point(valueBlokWidth - 20, valueBlokHeight);
                Point Point4 = new Point(valueBlokWidth, 0);

                PointCollection myPointCollection = new PointCollection();
                myPointCollection.Add(Point1);
                myPointCollection.Add(Point2);
                myPointCollection.Add(Point3);
                myPointCollection.Add(Point4);

                itemListInputOutputBlock.polygonInputOutputBlock.Points = myPointCollection;
                itemListInputOutputBlock.canvasInputOutputBlock.Width = valueBlokWidth;
                //itemListInputOutputBlock.textBoxOfConditionBlock.Width = valueBlokWidth / 2;
                //itemListInputOutputBlock.textBlocOfConditionBlock.Width = valueBlokWidth / 2;
            }
            
        }
        private void blockHeightComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int valueBlokHeight = Convert.ToInt32(blockHeightComboBox.SelectedItem);
            DefaultPropertyForBlock.Height = (int)valueBlokHeight;
            foreach (ActionBlock listActionBlock in listActionBlock)
            {
                listActionBlock.canvasOfActionBlock.Height = valueBlokHeight;
                listActionBlock.textBoxOfActionBlock.Height = valueBlokHeight;
                Canvas.SetTop(listActionBlock.secondPointToConnect, valueBlokHeight / 2 - 2);
                Canvas.SetTop(listActionBlock.thirdPointToConnect, valueBlokHeight - 3);
                Canvas.SetTop(listActionBlock.fourthPointToConnect, valueBlokHeight / 2 - 2);
            }
            int valueBlokWidth = DefaultPropertyForBlock.Width;
            foreach (ConditionBlock itemListConditionBlock in listConditionBlock)
            {
                Point Point1 = new Point(0, valueBlokHeight / 2);
                Point Point2 = new Point(valueBlokWidth / 2, valueBlokHeight);
                Point Point3 = new Point(valueBlokWidth, valueBlokHeight / 2);
                Point Point4 = new Point(valueBlokWidth / 2, 0);
                Point Point5 = new Point(0, valueBlokHeight / 2);
                PointCollection myPointCollection = new PointCollection();
                myPointCollection.Add(Point1);
                myPointCollection.Add(Point2);
                myPointCollection.Add(Point3);
                myPointCollection.Add(Point4);
                myPointCollection.Add(Point5);
                itemListConditionBlock.polygonConditionBlock.Points = myPointCollection;
                Canvas.SetTop(itemListConditionBlock.textBoxOfConditionBlock, valueBlokHeight / 4);
                Canvas.SetTop(itemListConditionBlock.textBlocOfConditionBlock, valueBlokHeight / 4);
                Canvas.SetTop(itemListConditionBlock.firstPointToConnect, -2);
                Canvas.SetTop(itemListConditionBlock.secondPointToConnect, valueBlokHeight / 2 - 3);
                Canvas.SetTop(itemListConditionBlock.thirdPointToConnect, valueBlokHeight - 3);
                Canvas.SetTop(itemListConditionBlock.fourthPointToConnect, valueBlokHeight / 2 - 3);
            }
            foreach (StartEndBlock itemListStartEndBlock in listStartEndBlock)
            {
                itemListStartEndBlock.canvasStartEndBlock.Height = valueBlokHeight / 2;
                itemListStartEndBlock.rectangleStartEndBlock.Height = valueBlokHeight / 2;
                itemListStartEndBlock.textBlockOfStartEnd.VerticalAlignment = VerticalAlignment.Center;
            }
            foreach (InputOutputBlock itemListInputOutputBlock in listInputOutputBlock)
            {
                Point Point1 = new Point(20, 0);
                Point Point2 = new Point(0, valueBlokHeight);
                Point Point3 = new Point(valueBlokWidth - 20, valueBlokHeight);
                Point Point4 = new Point(valueBlokWidth, 0);

                PointCollection myPointCollection = new PointCollection();
                myPointCollection.Add(Point1);
                myPointCollection.Add(Point2);
                myPointCollection.Add(Point3);
                myPointCollection.Add(Point4);

                itemListInputOutputBlock.polygonInputOutputBlock.Points = myPointCollection;
                itemListInputOutputBlock.canvasInputOutputBlock.Width = valueBlokWidth;
                //itemListInputOutputBlock.textBoxOfConditionBlock.Width = valueBlokWidth / 2;
                //itemListInputOutputBlock.textBlocOfConditionBlock.Width = valueBlokWidth / 2;
            }
        }
    }
}