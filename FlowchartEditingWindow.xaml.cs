using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using Flowchart_Editor.Models;
using System.Windows.Controls;
using System.Collections.Generic;
using Flowchart_Editor.Models.Comment;

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

        readonly List<ActionBlock> listActionBlock = new();
        int keyBlock = 0;
        public void MouseMoveActionBlock(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                keyBlock++;
                ActionBlock instanceOfActionBlock = new(this, keyBlock);
                listActionBlock.Add(instanceOfActionBlock);
                DataObject dataObjectInformationOfActionBlock = new(typeof(ActionBlock), instanceOfActionBlock);
                DragDrop.DoDragDrop(sender as DependencyObject, dataObjectInformationOfActionBlock, DragDropEffects.Copy);
            }
            e.Handled = true;
        }

        readonly List<ConditionBlock> listConditionBlock = new();
        private void MouseMoveConditionBlock(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                keyBlock++;
                ConditionBlock instanceOfConditionBlock = new(this, keyBlock);
                listConditionBlock.Add(instanceOfConditionBlock);
                DataObject dataObjectInformationOConditionBlock = new(typeof(ConditionBlock), instanceOfConditionBlock);
                DragDrop.DoDragDrop(conditionBlock, dataObjectInformationOConditionBlock, DragDropEffects.Copy);
            }
            e.Handled = true;
        }

        readonly List<StartEndBlock> listStartEndBlock = new();
        private void MouseMoveStartEndBlock(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                keyBlock++;
                StartEndBlock instanceOfStartEndBlock = new(this, keyBlock);
                listStartEndBlock.Add(instanceOfStartEndBlock);
                DataObject dataObjectInformationOfStartEndBlock = new(typeof(StartEndBlock), instanceOfStartEndBlock);
                DragDrop.DoDragDrop(sender as DependencyObject, dataObjectInformationOfStartEndBlock, DragDropEffects.Copy);
            }
            e.Handled = true;
        }

        readonly List<InputOutputBlock> listInputOutputBlock = new();
        private void MouseMoveInputOutputBlock(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                keyBlock++;
                InputOutputBlock instanceOfInputOutputBlock = new(this, keyBlock);
                listInputOutputBlock.Add(instanceOfInputOutputBlock);
                DataObject dataObjectInformationOfInputOutputBlock = new(typeof(InputOutputBlock), instanceOfInputOutputBlock);
                DragDrop.DoDragDrop(inputOutputBlock, dataObjectInformationOfInputOutputBlock, DragDropEffects.Copy);
            }
            e.Handled = true;
        }

        readonly List<SubroutineBlock> listSubroutineBlock = new();
        private void MouseMoveSubroutineBlock(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                keyBlock++;
                var instanceSubroutineBlock = new SubroutineBlock(this, keyBlock);
                listSubroutineBlock.Add(instanceSubroutineBlock);
                var dataObjectInformationOfSubroutineBlock = new DataObject(typeof(SubroutineBlock), instanceSubroutineBlock);
                DragDrop.DoDragDrop(subroutineBlock, dataObjectInformationOfSubroutineBlock, DragDropEffects.Copy);
            }
            e.Handled = true;
        }

        readonly List<CycleForBlock> listCycleForBlock = new();
        private void MouseMoveCycleBlockFor(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                keyBlock++;
                var instanceOfCycleForBlock = new CycleForBlock(this, keyBlock);
                listCycleForBlock.Add(instanceOfCycleForBlock);
                var dataObjectInstanceOfCycleForBlock = new DataObject(typeof(CycleForBlock), instanceOfCycleForBlock);
                DragDrop.DoDragDrop(sender as DependencyObject, dataObjectInstanceOfCycleForBlock, DragDropEffects.Copy);
            }
            e.Handled = true;
        }

        readonly List<CycleWhileBeginBlock> listCycleWhileBeginBlock = new();
        private void MouseMoveCycleBlockWhileBegin(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                keyBlock++;
                var instanceOfCycleWhileBlock = new CycleWhileBeginBlock(this, keyBlock);
                listCycleWhileBeginBlock.Add(instanceOfCycleWhileBlock);
                var dataObjectInstanceOfCycleWhileBlock = new DataObject(typeof(CycleWhileBeginBlock), instanceOfCycleWhileBlock);
                DragDrop.DoDragDrop(sender as DependencyObject, dataObjectInstanceOfCycleWhileBlock, DragDropEffects.Copy);
            }
            e.Handled = true;
        }

        private readonly List<CycleWhileEndBlock> listCycleWhileEndBlock = new();
        private void MouseMoveCycleBlockWhileEnd(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                keyBlock++;
                var instanceOfCycleWhileBlock = new CycleWhileEndBlock(this, keyBlock);
                listCycleWhileEndBlock.Add(instanceOfCycleWhileBlock);
                var dataObjectInstanceOfCycleWhileBlock = new DataObject(typeof(CycleWhileEndBlock), instanceOfCycleWhileBlock);
                DragDrop.DoDragDrop(sender as DependencyObject, dataObjectInstanceOfCycleWhileBlock, DragDropEffects.Copy);
            }
            e.Handled = true;
        }

        readonly List<LinkBlock> listLinkBlock = new();
        private void MouseMoveLinkBlock(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                keyBlock++;
                var instanceOfLinkBlock = new LinkBlock(this, keyBlock);
                listLinkBlock.Add(instanceOfLinkBlock);
                var dataObjectInformationOfLinkBlock = new DataObject(typeof(LinkBlock), instanceOfLinkBlock);
                DragDrop.DoDragDrop(sender as DependencyObject, dataObjectInformationOfLinkBlock, DragDropEffects.Copy);
            }
            e.Handled = true;
        }

        readonly List<Comment> listComment = new();
        private void DropDestination(object sender, DragEventArgs e)
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
            else if (e.Data.GetDataPresent(typeof(Comment)))
            {
                var position = e.GetPosition(destination);
                var featuresOfComment = ((Comment)e.Data.GetData(typeof(Comment))).GetUIElement();
                Canvas.SetLeft(featuresOfComment, position.X);
                Canvas.SetTop(featuresOfComment, position.Y);
            }
            e.Handled = true;
        }

        private void DragOverDestination(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ActionBlock)))
            {
                e.Effects = DragDropEffects.Copy;
                Point position = e.GetPosition(destination);
                ActionBlock dataInformationOfActionBlock = (ActionBlock)e.Data.GetData(typeof(ActionBlock));
                UIElement actionBlockOfUIElement;
                if (dataInformationOfActionBlock.GetUIElementWithoutCreate() == null)
                {
                    actionBlockOfUIElement = ((ActionBlock)e.Data.GetData(typeof(ActionBlock))).GetUIElement();
                    destination.Children.Add(actionBlockOfUIElement);
                }
                else
                    actionBlockOfUIElement = ((ActionBlock)e.Data.GetData(typeof(ActionBlock))).GetUIElement();

                Canvas.SetLeft(actionBlockOfUIElement, position.X + 1);
                Canvas.SetTop(actionBlockOfUIElement, position.Y + 1);

            }
            else if (e.Data.GetDataPresent(typeof(BlockForMovements)))
            {
                e.Effects = DragDropEffects.Copy;
                Point position = e.GetPosition(destination);
                BlockForMovements resultTransferInformation = (BlockForMovements)e.Data.GetData(typeof(BlockForMovements));
                object transferInformationActionBlock = resultTransferInformation.GetTransferInformationActionBlock();
                Canvas.SetLeft((UIElement)transferInformationActionBlock, position.X + 1);
                Canvas.SetTop((UIElement)transferInformationActionBlock, position.Y + 1);
                
                int numberOfOccurrencesInBlock = resultTransferInformation.GetNumberOfOccurrencesInBlock();
                ChangingLines changingLines = new(resultTransferInformation, numberOfOccurrencesInBlock);
                changingLines.ChooseWayToChangeCoordinatesForLine();
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
                    conditionBlockOfUIElement = ((ConditionBlock)e.Data.GetData(typeof(ConditionBlock))).GetUIElement();
                Canvas.SetLeft(conditionBlockOfUIElement, position.X + 1);
                Canvas.SetTop(conditionBlockOfUIElement, position.Y + 1);

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
                    startEndBlockOfUIElement = ((StartEndBlock)e.Data.GetData(typeof(StartEndBlock))).GetUIElement();
                
                Canvas.SetLeft(startEndBlockOfUIElement, position.X + 1);
                Canvas.SetTop(startEndBlockOfUIElement, position.Y + 1);

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
                    inputOutputBlockOfUIElement = ((InputOutputBlock)e.Data.GetData(typeof(InputOutputBlock))).GetUIElement();
                
                Canvas.SetLeft(inputOutputBlockOfUIElement, position.X + 1);
                Canvas.SetTop(inputOutputBlockOfUIElement, position.Y + 1);

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
                    subroutineBlockOfUIElement = ((SubroutineBlock)e.Data.GetData(typeof(SubroutineBlock))).GetUIElement();
                
                Canvas.SetLeft(subroutineBlockOfUIElement, position.X + 1);
                Canvas.SetTop(subroutineBlockOfUIElement, position.Y + 1);

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
                    subroutineBlockOfUIElement = ((CycleForBlock)e.Data.GetData(typeof(CycleForBlock))).GetUIElement();

                Canvas.SetLeft(subroutineBlockOfUIElement, position.X + 1);
                Canvas.SetTop(subroutineBlockOfUIElement, position.Y + 1);

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
                    subroutineBlockOfUIElement = ((CycleWhileBeginBlock)e.Data.GetData(typeof(CycleWhileBeginBlock))).GetUIElement();

                Canvas.SetLeft(subroutineBlockOfUIElement, position.X + 1);
                Canvas.SetTop(subroutineBlockOfUIElement, position.Y + 1);

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
                    subroutineBlockOfUIElement = ((CycleWhileEndBlock)e.Data.GetData(typeof(CycleWhileEndBlock))).GetUIElement();

                Canvas.SetLeft(subroutineBlockOfUIElement, position.X + 1);
                Canvas.SetTop(subroutineBlockOfUIElement, position.Y + 1);

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
                    linkBlockOfUIElement = ((LinkBlock)e.Data.GetData(typeof(LinkBlock))).GetUIElement();
                
                Canvas.SetLeft(linkBlockOfUIElement, position.X + 1);
                Canvas.SetTop(linkBlockOfUIElement, position.Y + 1);

            }
            else e.Effects = DragDropEffects.None;
            e.Handled = true;
        }

        private void DragLeaveDestination(object sender, DragEventArgs e)
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

        private void ClickToggleButtonStyleTheme(object sender, RoutedEventArgs e)
        {
            if (toggleButtonStyleTheme.IsChecked != null)
            {
                if ((bool)toggleButtonStyleTheme.IsChecked)
                {
                    BrushConverter color = new();

                    homeIcon.Foreground = (Brush)color.ConvertFrom(darkWhite);
                    homeText.Foreground = (Brush)color.ConvertFrom(darkWhite);

                    authorizationIcon.Foreground = (Brush)color.ConvertFrom(darkWhite);
                    authorizationText.Foreground = (Brush)color.ConvertFrom(darkWhite);

                    registrationIcon.Foreground = (Brush)color.ConvertFrom(darkWhite);
                    registrationText.Foreground = (Brush)color.ConvertFrom(darkWhite);

                    listOfProjectsIcon.Foreground = (Brush)color.ConvertFrom(darkWhite);
                    listOfProjectsText.Foreground = (Brush)color.ConvertFrom(darkWhite);

                    informationIcon.Foreground = (Brush)color.ConvertFrom(darkWhite);
                    informationText.Foreground = (Brush)color.ConvertFrom(darkWhite);

                    supportIcon.Foreground = (Brush)color.ConvertFrom(darkWhite);
                    supportText.Foreground = (Brush)color.ConvertFrom(darkWhite);

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

                    labelNameOfFirstBlockToConnect.Foreground = (Brush)color.ConvertFrom(darkWhite);
                    textNameOfFirstBlockToConnect.Foreground = (Brush)color.ConvertFrom(darkWhite);

                    labelNameOfSecondBlockToConnect.Foreground = (Brush)color.ConvertFrom(darkWhite);
                    textNameOfSecondBlockToConnect.Foreground = (Brush)color.ConvertFrom(darkWhite);

                    firstLineOfComment.Stroke = (Brush)color.ConvertFrom(darkWhite);
                    secondLineOfComment.Stroke = (Brush)color.ConvertFrom(darkWhite);
                    thirdLineOfComment.Stroke = (Brush)color.ConvertFrom(darkWhite);
                    fourthLineOfComment.Stroke = (Brush)color.ConvertFrom(darkWhite);
                    fifthLineOfComment.Stroke = (Brush)color.ConvertFrom(darkWhite);
                    sixthLineOfComment.Stroke = (Brush)color.ConvertFrom(darkWhite);

                    textComment.Foreground = (Brush)color.ConvertFrom(darkWhite);

                    DefaultPropertyForBlock.colorPoint = darkWhite;

                    foreach (ActionBlock itemListActionBlock in listActionBlock)
                        itemListActionBlock.SetFillOfPointToConnect(darkWhite);

                    foreach (ConditionBlock itemListConditionBlock in listConditionBlock)
                        itemListConditionBlock.SetFillOfPointToConnect(darkWhite);
                    
                    foreach (StartEndBlock itemListStartEndBlock in listStartEndBlock)
                        itemListStartEndBlock.SetFillOfPointToConnect(darkWhite);
                        
                    foreach (InputOutputBlock itemListInputOutputBlock in listInputOutputBlock)
                        itemListInputOutputBlock.SetFillOfPointToConnect(darkWhite);
                    
                    foreach (SubroutineBlock itemListSubroutineBlock in listSubroutineBlock)
                        itemListSubroutineBlock.SetFillOfPointToConnect(darkWhite);

                    foreach (CycleForBlock itemListCycleForBlock in listCycleForBlock)
                        itemListCycleForBlock.SetFillOfPointToConnect(darkWhite);
                    
                    foreach (CycleWhileBeginBlock itemListCycleWhileBeginBlock in listCycleWhileBeginBlock)
                        itemListCycleWhileBeginBlock.SetFillOfPointToConnect(darkWhite);
                       
                    foreach (CycleWhileEndBlock itemListCycleWhileEndBlock in listCycleWhileEndBlock)
                        itemListCycleWhileEndBlock.SetFillOfPointToConnect(darkWhite);
                    
                    foreach (LinkBlock itemListLinkBlock in listLinkBlock)
                        itemListLinkBlock.SetFillOfPointToConnect(darkWhite);

                    foreach (Line itemListLineConnection in listLineConnection)
                        itemListLineConnection.Stroke = (Brush)color.ConvertFrom(darkWhite);

                    DefaultPropertyForBlock.colorLine = darkWhite;
                }
                else
                {
                    BrushConverter color = new();

                    homeIcon.Foreground = (Brush)color.ConvertFrom(darkBlack);
                    homeText.Foreground = (Brush)color.ConvertFrom(darkBlack);

                    authorizationIcon.Foreground = (Brush)color.ConvertFrom(darkBlack);
                    authorizationText.Foreground = (Brush)color.ConvertFrom(darkBlack);

                    registrationIcon.Foreground = (Brush)color.ConvertFrom(darkBlack);
                    registrationText.Foreground = (Brush)color.ConvertFrom(darkBlack);

                    listOfProjectsIcon.Foreground = (Brush)color.ConvertFrom(darkBlack);
                    listOfProjectsText.Foreground = (Brush)color.ConvertFrom(darkBlack);

                    informationIcon.Foreground = (Brush)color.ConvertFrom(darkBlack);
                    informationText.Foreground = (Brush)color.ConvertFrom(darkBlack);

                    supportIcon.Foreground = (Brush)color.ConvertFrom(darkBlack);
                    supportText.Foreground = (Brush)color.ConvertFrom(darkBlack);

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

                    labelNameOfFirstBlockToConnect.Foreground = (Brush)color.ConvertFrom(darkBlack);
                    textNameOfFirstBlockToConnect.Foreground = (Brush)color.ConvertFrom(darkBlack);

                    labelNameOfSecondBlockToConnect.Foreground = (Brush)color.ConvertFrom(darkBlack);
                    textNameOfSecondBlockToConnect.Foreground = (Brush)color.ConvertFrom(darkBlack);

                    firstLineOfComment.Stroke = (Brush)color.ConvertFrom(darkBlack);
                    secondLineOfComment.Stroke = (Brush)color.ConvertFrom(darkBlack);
                    thirdLineOfComment.Stroke = (Brush)color.ConvertFrom(darkBlack);
                    fourthLineOfComment.Stroke = (Brush)color.ConvertFrom(darkBlack);
                    fifthLineOfComment.Stroke = (Brush)color.ConvertFrom(darkBlack);
                    sixthLineOfComment.Stroke = (Brush)color.ConvertFrom(darkBlack);

                    textComment.Foreground = (Brush)color.ConvertFrom(darkBlack);

                    DefaultPropertyForBlock.colorPoint = darkBlack;

                    foreach (ActionBlock itemListActionBlock in listActionBlock)
                        itemListActionBlock.SetFillOfPointToConnect(darkBlack);
                   
                    foreach (ConditionBlock itemListConditionBlock in listConditionBlock)
                        itemListConditionBlock.SetFillOfPointToConnect(darkBlack);

                    foreach (StartEndBlock itemListStartEndBlock in listStartEndBlock)
                        itemListStartEndBlock.SetFillOfPointToConnect(darkBlack);

                    foreach (StartEndBlock itemListStartEndBlock in listStartEndBlock)
                        itemListStartEndBlock.SetFillOfPointToConnect(darkBlack);
                    
                    foreach (InputOutputBlock itemListInputOutputBlock in listInputOutputBlock)
                        itemListInputOutputBlock.SetFillOfPointToConnect(darkBlack);

                    foreach (SubroutineBlock itemListSubroutineBlock in listSubroutineBlock)
                        itemListSubroutineBlock.SetFillOfPointToConnect(darkBlack);
                    
                    foreach (CycleForBlock itemListCycleForBlock in listCycleForBlock)
                        itemListCycleForBlock.SetFillOfPointToConnect(darkBlack);
                    
                    foreach (CycleWhileBeginBlock itemListCycleWhileBeginBlock in listCycleWhileBeginBlock)
                        itemListCycleWhileBeginBlock.SetFillOfPointToConnect(darkBlack);

                    foreach (CycleWhileEndBlock itemListCycleWhileEndBlock in listCycleWhileEndBlock)
                        itemListCycleWhileEndBlock.SetFillOfPointToConnect(darkBlack);

                    foreach (LinkBlock itemListLinkBlock in listLinkBlock)
                        itemListLinkBlock.SetFillOfPointToConnect(darkBlack);

                    foreach (Line itemListLineConnection in listLineConnection)
                        itemListLineConnection.Stroke = (Brush)color.ConvertFrom(darkBlack);

                    DefaultPropertyForBlock.colorLine = darkBlack;
                }
            }
        }

        private void SelectionChangedListOfFontsComboBox(object sender, SelectionChangedEventArgs e)
        {
            FontFamily fontFamily = new(((ComboBoxItem)listOfFontsComboBox.SelectedItem).Content.ToString());
            DefaultPropertyForBlock.fontFamily = fontFamily;

            foreach (ActionBlock itemListActionBlock in listActionBlock)
                itemListActionBlock.SetFontFamily(fontFamily);

            foreach (ConditionBlock itemListConditionBlock in listConditionBlock)
                itemListConditionBlock.SetFontFamily(fontFamily);

            foreach (StartEndBlock itemListStartEndBlock in listStartEndBlock)
                itemListStartEndBlock.SetFontFamily(fontFamily);
            
            foreach (InputOutputBlock itemListInputOutputBlock in listInputOutputBlock)
                itemListInputOutputBlock.SetFontFamily(fontFamily);

            foreach (SubroutineBlock itemListSubroutineBlock in listSubroutineBlock)
                itemListSubroutineBlock.SetFontFamily(fontFamily);
               
            foreach (CycleForBlock itemListCycleForBlock in listCycleForBlock)
                itemListCycleForBlock.SetFontFamily(fontFamily);

            foreach (CycleWhileBeginBlock itemListCycleWhileBeginBlock in listCycleWhileBeginBlock)
                itemListCycleWhileBeginBlock.SetFontFamily(fontFamily);

            foreach (CycleWhileEndBlock itemListCycleWhileEndBlock in listCycleWhileEndBlock)
                itemListCycleWhileEndBlock.SetFontFamily(fontFamily);

            foreach (LinkBlock itemListLinkBlock in listLinkBlock)
                itemListLinkBlock.SetFontFamily(fontFamily);
        }

        private void SelectionChangedFontSizeComboBox(object sender, SelectionChangedEventArgs e)
        {
            int valueFontSize = Convert.ToInt32(fontSizeComboBox.SelectedItem);
            DefaultPropertyForBlock.fontSize = valueFontSize;

            foreach (ActionBlock itemListActionBlock in listActionBlock)
                itemListActionBlock.SetFontSize(valueFontSize);
            
            foreach (ConditionBlock itemListConditionBlock in listConditionBlock)
                itemListConditionBlock.SetFontSize(valueFontSize);
               
            foreach (StartEndBlock itemListStartEndBlock in listStartEndBlock)
                itemListStartEndBlock.SetFontSize(valueFontSize);
            
            foreach (InputOutputBlock itemListInputOutputBlock in listInputOutputBlock)
                itemListInputOutputBlock.SetFontSize(valueFontSize);
            
            foreach (SubroutineBlock itemListSubroutineBlock in listSubroutineBlock)
                itemListSubroutineBlock.SetFontSize(valueFontSize);

            foreach (CycleForBlock itemListCycleForBlock in listCycleForBlock)
                itemListCycleForBlock.SetFontSize(valueFontSize);
            
            foreach (CycleWhileBeginBlock itemListCycleWhileBeginBlock in listCycleWhileBeginBlock)
                itemListCycleWhileBeginBlock.SetFontSize(valueFontSize);
            
            foreach (CycleWhileEndBlock itemListCycleWhileEndBlock in listCycleWhileEndBlock)
                itemListCycleWhileEndBlock.SetFontSize(valueFontSize);

            foreach (LinkBlock itemListLinkBlock in listLinkBlock)
                itemListLinkBlock.SetFontSize(valueFontSize);
        }

        private void SelectionChangedBlockWidthComboBox(object sender, SelectionChangedEventArgs e)
        {
            int valueBlockWidth = Convert.ToInt32(blockWidthComboBox.SelectedItem);
            DefaultPropertyForBlock.width = (int)valueBlockWidth;
            int valueBlockHeight = DefaultPropertyForBlock.height;

            foreach (ActionBlock itemListActionBlock in listActionBlock)
                itemListActionBlock.SetWidthOfBlock(valueBlockWidth);
            
            foreach (ConditionBlock itemListConditionBlock in listConditionBlock)
                itemListConditionBlock.SetWidthAndHeightOfBlock(valueBlockWidth, valueBlockHeight);

            foreach (StartEndBlock itemListStartEndBlock in listStartEndBlock)
                itemListStartEndBlock.SetWidthOfBlock(valueBlockWidth);

            foreach (InputOutputBlock itemListInputOutputBlock in listInputOutputBlock)
                itemListInputOutputBlock.SetWidthAndHeightOfBlock(valueBlockWidth, valueBlockHeight);
            
            foreach (SubroutineBlock itemListSubroutineBlock in listSubroutineBlock)
                itemListSubroutineBlock.SetWidthOfBlock(valueBlockWidth);
                
            foreach (CycleForBlock itemListCycleForBlock in listCycleForBlock)
                itemListCycleForBlock.SetWidthAndHeightOfBlock(valueBlockWidth, valueBlockHeight);

            foreach (CycleWhileBeginBlock itemListCycleWhileBeginBlock in listCycleWhileBeginBlock)
                itemListCycleWhileBeginBlock.SetWidthAndHeightOfBlock(valueBlockWidth, valueBlockHeight);
                
            foreach (CycleWhileEndBlock itemListCycleWhileEndBlock in listCycleWhileEndBlock)
                itemListCycleWhileEndBlock.SetWidthAndHeightOfBlock(valueBlockWidth, valueBlockHeight);

            foreach (Comment itemListComment in listComment)
                itemListComment.SetWidtht(valueBlockWidth);
        }
        private void SelectionChangedBlockHeightComboBox(object sender, SelectionChangedEventArgs e)
        {
            int valueBlokHeight = Convert.ToInt32(blockHeightComboBox.SelectedItem);
            DefaultPropertyForBlock.height = (int)valueBlokHeight;
            int valueBlokWidth = DefaultPropertyForBlock.width;

            foreach (ActionBlock itemListActionBlock in listActionBlock)
                itemListActionBlock.SetHeightOfBlock(valueBlokHeight);

            foreach (ConditionBlock itemListConditionBlock in listConditionBlock)
                itemListConditionBlock.SetWidthAndHeightOfBlock(valueBlokWidth, valueBlokHeight);

            foreach (StartEndBlock itemListStartEndBlock in listStartEndBlock)
                itemListStartEndBlock.SetHeightOfBlock(valueBlokHeight);
            
            foreach (InputOutputBlock itemListInputOutputBlock in listInputOutputBlock)
                itemListInputOutputBlock.SetWidthAndHeightOfBlock(valueBlokWidth, valueBlokHeight);
                
            foreach (SubroutineBlock itemListSubroutineBlock in listSubroutineBlock)
                itemListSubroutineBlock.SetHeightOfBlock(valueBlokHeight);

            foreach (CycleForBlock itemListCycleForBlock in listCycleForBlock)
                itemListCycleForBlock.SetWidthAndHeightOfBlock(valueBlokWidth, valueBlokHeight);

            foreach (CycleWhileBeginBlock itemListCycleWhileBeginBlock in listCycleWhileBeginBlock)
                itemListCycleWhileBeginBlock.SetWidthAndHeightOfBlock(valueBlokWidth, valueBlokHeight);
              
            foreach (CycleWhileEndBlock itemListCycleWhileEndBlock in listCycleWhileEndBlock)
                itemListCycleWhileEndBlock.SetWidthAndHeightOfBlock(valueBlokWidth, valueBlokHeight);

            foreach (LinkBlock itemListLinkBlock in listLinkBlock)
                itemListLinkBlock.SetHeightOfBlock(valueBlokHeight);
                
            foreach (Comment itemListComment in listComment)
                itemListComment.SetHeight(valueBlokHeight);
        }

        readonly List<Line> listLineConnection = new();
        
        public Line? DrawConnectionLine(double x1, double y1, double x2, double y2)
        {
            if (CoordinatesBlock.keyFirstBlock == CoordinatesBlock.keySecondBlock)
            {
                MessageBox.Show("Ошибка соединения блоков");
                WriteFirstNameOfBlockToConect("");
                WriteSecondNameOfBlockToConect("");
                return null;
            }
            else
            {
                BrushConverter color = new();
                Line lineConnection = new();

                lineConnection.X1 = x1;
                lineConnection.Y1 = y1;
                lineConnection.X2 = x2;
                lineConnection.Y2 = y2;
                lineConnection.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);

                listLineConnection.Add(lineConnection);
                destination.Children.Add(lineConnection);
                
                return lineConnection;
            }
        }
        public void WriteFirstNameOfBlockToConect(string nameOfFirstBlockToConnect)
        {
            textNameOfFirstBlockToConnect.Text = nameOfFirstBlockToConnect;
            textNameOfSecondBlockToConnect.Text = "";
        }
        public void WriteSecondNameOfBlockToConect(string nameOfSecondBlockToConnect)
        {
            textNameOfSecondBlockToConnect.Text = nameOfSecondBlockToConnect;
        }
        
        private void MouseLeftButtonDownComment(object sender, MouseButtonEventArgs e)
        {
            Comment instanceOfComment = new();
            string textOfComment = Comment.GetTextOfComment();
            WriteFirstNameOfBlockToConect(textOfComment);
            listComment.Add(instanceOfComment);
            PinningComment.flagPinningComment = true;
            PinningComment.comment = instanceOfComment;
        }
    }
}