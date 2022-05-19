using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using Flowchart_Editor.Models;
using System.Windows.Controls;
using System.Collections.Generic;
using Flowchart_Editor.Models.Action;
using Flowchart_Editor.Models.Comment;
using Flowchart_Editor.Models.LineConnection;

namespace Flowchart_Editor
{
    public partial class MainWindow : Window
    {
        const int minHeight = 760;
        const int minWidth = 1380;
        const int valueOffsetOfLineFromTheBlockToSides = 20;

        private enum WindowsTheme
        {
            light,
            dark
        }

        public MainWindow()
        {
            InitializeComponent();
            MinHeight = minHeight;
            MinWidth = minWidth;
            toggleButtonStyleTheme.Click += ThemeChange;
            ThemeChange();

            for (int i = 8; i <= 36; i += 2)
                fontSizeComboBox.Items.Add(i);

            for (int i = 90; i <= 250; i += 10)
                blockWidthComboBox.Items.Add(i);

            for (int i = 60; i <= 250; i += 10)
                blockHeightComboBox.Items.Add(i);
        }

        private void ThemeChange(object? sender = null, RoutedEventArgs? e = null)
        {
            BrushConverter brushConverter = new();
            Brush darkWhiteBrush = (Brush)brushConverter.ConvertFrom(darkWhite);
            Brush darkBlackBrush = (Brush)brushConverter.ConvertFrom(darkBlack);
            if (toggleButtonStyleTheme.IsChecked != null)
            {
                if ((bool)toggleButtonStyleTheme.IsChecked)
                {
                    SetTheme(WindowsTheme.dark);
                    buttonOpenMenu.Foreground = darkWhiteBrush;
                    buttonCloseMenu.Foreground = darkWhiteBrush;
                    toggleButtonStyleTheme.Background = darkWhiteBrush;
                }
                else
                {
                    SetTheme(WindowsTheme.light);
                    buttonOpenMenu.Foreground = darkBlackBrush;
                    buttonCloseMenu.Foreground = darkBlackBrush;
                }
            }
        }

        private static void SetTheme(WindowsTheme windowsTheme)
        {
            Uri uri = new("WindowsTheme/" + windowsTheme + ".xaml", UriKind.Relative);
            DefaultPropertyForBlock.uri = uri;
            ResourceDictionary? resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }

        readonly List<Block> listOfBlock = new();
        int keyBlock = 0;
        public void MouseMoveActionBlock(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                keyBlock++;
                ActionBlock instanceOfActionBlock = new(this, keyBlock);
                listOfBlock.Add(instanceOfActionBlock);
                DataObject dataObjectInformationOfActionBlock = new(typeof(ActionBlock), instanceOfActionBlock);
                DragDrop.DoDragDrop(sender as DependencyObject, dataObjectInformationOfActionBlock, DragDropEffects.Copy);
            }
            e.Handled = true;
        }

        private void MouseMoveConditionBlock(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                keyBlock++;
                ConditionBlock instanceOfConditionBlock = new(this, keyBlock);
                listOfBlock.Add(instanceOfConditionBlock);
                DataObject dataObjectInformationOConditionBlock = new(typeof(ConditionBlock), instanceOfConditionBlock);
                DragDrop.DoDragDrop(sender as DependencyObject, dataObjectInformationOConditionBlock, DragDropEffects.Copy);
            }
            e.Handled = true;
        }

        private void MouseMoveStartEndBlock(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                keyBlock++;
                StartEndBlock instanceOfStartEndBlock = new(this, keyBlock);
                listOfBlock.Add(instanceOfStartEndBlock);
                DataObject dataObjectInformationOfStartEndBlock = new(typeof(StartEndBlock), instanceOfStartEndBlock);
                DragDrop.DoDragDrop(sender as DependencyObject, dataObjectInformationOfStartEndBlock, DragDropEffects.Copy);
            }
            e.Handled = true;
        }

        private void MouseMoveInputOutputBlock(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                keyBlock++;
                InputOutputBlock instanceOfInputOutputBlock = new(this, keyBlock);
                listOfBlock.Add(instanceOfInputOutputBlock);
                DataObject dataObjectInformationOfInputOutputBlock = new(typeof(InputOutputBlock), instanceOfInputOutputBlock);
                DragDrop.DoDragDrop(sender as DependencyObject, dataObjectInformationOfInputOutputBlock, DragDropEffects.Copy);
            }
            e.Handled = true;
        }

        private void MouseMoveSubroutineBlock(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                keyBlock++;
                SubroutineBlock instanceSubroutineBlock = new(this, keyBlock);
                listOfBlock.Add(instanceSubroutineBlock);
                DataObject dataObjectInformationOfSubroutineBlock = new(typeof(SubroutineBlock), instanceSubroutineBlock);
                DragDrop.DoDragDrop(sender as DependencyObject, dataObjectInformationOfSubroutineBlock, DragDropEffects.Copy);
            }
            e.Handled = true;
        }

        private void MouseMoveCycleBlockFor(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                keyBlock++;
                CycleForBlock instanceOfCycleForBlock = new(this, keyBlock);
                listOfBlock.Add(instanceOfCycleForBlock);
                DataObject dataObjectInstanceOfCycleForBlock = new (typeof(CycleForBlock), instanceOfCycleForBlock);
                DragDrop.DoDragDrop(sender as DependencyObject, dataObjectInstanceOfCycleForBlock, DragDropEffects.Copy);
            }
            e.Handled = true;
        }

        private void MouseMoveCycleBlockWhileBegin(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                keyBlock++;
                CycleWhileBeginBlock instanceOfCycleWhileBlock = new(this, keyBlock);
                listOfBlock.Add(instanceOfCycleWhileBlock);
                DataObject dataObjectInstanceOfCycleWhileBlock = new(typeof(CycleWhileBeginBlock), instanceOfCycleWhileBlock);
                DragDrop.DoDragDrop(sender as DependencyObject, dataObjectInstanceOfCycleWhileBlock, DragDropEffects.Copy);
            }
            e.Handled = true;
        }

        private void MouseMoveCycleBlockWhileEnd(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                keyBlock++;
                CycleWhileEndBlock instanceOfCycleWhileBlock = new(this, keyBlock);
                listOfBlock.Add(instanceOfCycleWhileBlock);
                DataObject dataObjectInstanceOfCycleWhileBlock = new (typeof(CycleWhileEndBlock), instanceOfCycleWhileBlock);
                DragDrop.DoDragDrop(sender as DependencyObject, dataObjectInstanceOfCycleWhileBlock, DragDropEffects.Copy);
            }
            e.Handled = true;
        }

        private void MouseMoveLinkBlock(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                keyBlock++;
                LinkBlock instanceOfLinkBlock = new(this, keyBlock);
                listOfBlock.Add(instanceOfLinkBlock);
                DataObject dataObjectInformationOfLinkBlock = new(typeof(LinkBlock), instanceOfLinkBlock);
                DragDrop.DoDragDrop(sender as DependencyObject, dataObjectInformationOfLinkBlock, DragDropEffects.Copy);
            }
            e.Handled = true;
        }

        readonly List<Comment> listComment = new();
        private void DropDestination(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ActionBlock)))
            {
                Point position = e.GetPosition(destination);
                UIElement featuresOfActionBlock = ((ActionBlock)e.Data.GetData(typeof(ActionBlock))).GetUIElement();
                Canvas.SetLeft(featuresOfActionBlock, position.X);
                Canvas.SetTop(featuresOfActionBlock, position.Y);
            }
            else if (e.Data.GetDataPresent(typeof(ConditionBlock)))
            {
                Point position = e.GetPosition(destination);
                UIElement featuresOfConditionBlock = ((ConditionBlock)e.Data.GetData(typeof(ConditionBlock))).GetUIElement();
                Canvas.SetLeft(featuresOfConditionBlock, position.X);
                Canvas.SetTop(featuresOfConditionBlock, position.Y);
            }
            else if (e.Data.GetDataPresent(typeof(StartEndBlock)))
            {
                Point position = e.GetPosition(destination);
                UIElement featuresOfStartEndBlock = ((StartEndBlock)e.Data.GetData(typeof(StartEndBlock))).GetUIElement();
                Canvas.SetLeft(featuresOfStartEndBlock, position.X);
                Canvas.SetTop(featuresOfStartEndBlock, position.Y);
            }
            else if (e.Data.GetDataPresent(typeof(InputOutputBlock)))
            {
                Point position = e.GetPosition(destination);
                UIElement featuresOfInputOutputBlock = ((InputOutputBlock)e.Data.GetData(typeof(InputOutputBlock))).GetUIElement();
                Canvas.SetLeft(featuresOfInputOutputBlock, position.X);
                Canvas.SetTop(featuresOfInputOutputBlock, position.Y);
            }
            else if (e.Data.GetDataPresent(typeof(SubroutineBlock)))
            {
                Point position = e.GetPosition(destination);
                UIElement featuresOfSubroutineBlock = ((SubroutineBlock)e.Data.GetData(typeof(SubroutineBlock))).GetUIElement();
                Canvas.SetLeft(featuresOfSubroutineBlock, position.X);
                Canvas.SetTop(featuresOfSubroutineBlock, position.Y);
            }
            else if (e.Data.GetDataPresent(typeof(CycleForBlock)))
            {
                Point position = e.GetPosition(destination);
                UIElement featuresOfCycleForBlock = ((CycleForBlock)e.Data.GetData(typeof(CycleForBlock))).GetUIElement();
                Canvas.SetLeft(featuresOfCycleForBlock, position.X);
                Canvas.SetTop(featuresOfCycleForBlock, position.Y);
            }
            else if (e.Data.GetDataPresent(typeof(CycleWhileBeginBlock)))
            {
                Point position = e.GetPosition(destination);
                UIElement featuresOfCycleForBlock = ((CycleWhileBeginBlock)e.Data.GetData(typeof(CycleWhileBeginBlock))).GetUIElement();
                Canvas.SetLeft(featuresOfCycleForBlock, position.X);
                Canvas.SetTop(featuresOfCycleForBlock, position.Y);
            }
            else if (e.Data.GetDataPresent(typeof(CycleWhileEndBlock)))
            {
                Point position = e.GetPosition(destination);
                UIElement featuresOfCycleWhileBlock = ((CycleWhileEndBlock)e.Data.GetData(typeof(CycleWhileEndBlock))).GetUIElement();
                Canvas.SetLeft(featuresOfCycleWhileBlock, position.X);
                Canvas.SetTop(featuresOfCycleWhileBlock, position.Y);
            }
            else if (e.Data.GetDataPresent(typeof(LinkBlock)))
            {
                Point position = e.GetPosition(destination);
                UIElement featuresOfLinkBlock = ((LinkBlock)e.Data.GetData(typeof(LinkBlock))).GetUIElement();
                Canvas.SetLeft(featuresOfLinkBlock, position.X);
                Canvas.SetTop(featuresOfLinkBlock, position.Y);
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
            else if (e.Data.GetDataPresent(typeof(BlockForMovements)))
            {
                e.Effects = DragDropEffects.Copy;
                Point position = e.GetPosition(destination);
                BlockForMovements resultTransferInformation = (BlockForMovements)e.Data.GetData(typeof(BlockForMovements));
                object transferInformation = resultTransferInformation.GetTransferInformationActionBlock();
                Canvas.SetLeft((UIElement)transferInformation, position.X + 1);
                Canvas.SetTop((UIElement)transferInformation, position.Y + 1);
                
                if (resultTransferInformation.GetBlock().GetNumberOfOccurrencesInBlock() > 0)
                    ChangeLine(resultTransferInformation.GetBlock());
            }
            else e.Effects = DragDropEffects.None;
            e.Handled = true;
        }


        private void ChangeLine1(Line[] masLine, double x1, double y1, double x2, double y2)
        {
            int i = 0;
            double distanceBetweenTwoPoints = y2 - y1;
            BrushConverter color = new();
            foreach (Line line in masLine)
            {
                if (i == 0)
                {
                    line.Y1 = y1 + distanceBetweenTwoPoints / 2;
                    line.X1 = x2;
                    line.Y2 = y2;
                    line.X2 = x2;
                    destination.Children.Remove(line);
                    destination.Children.Add(line);
                }
                if (i == 1)
                {
                    line.X1 = x1;
                    line.Y1 = y1 + distanceBetweenTwoPoints / 2;
                    line.X2 = x2;
                    line.Y2 = y1 + distanceBetweenTwoPoints / 2;
                    destination.Children.Remove(line);
                    destination.Children.Add(line);
                }
                if (i == 2)
                {
                    if (line == null)
                    {
                        Line lineConnection = new();
                        lineConnection.Y1 = y1;
                        lineConnection.X1 = x1;
                        lineConnection.Y2 = y2 - distanceBetweenTwoPoints / 2;
                        lineConnection.X2 = x1;
                        lineConnection.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
                        listLineConnection.Add(lineConnection);
                        destination.Children.Remove(lineConnection);
                        destination.Children.Add(lineConnection);
                        masLine[i] = lineConnection;
                    }
                    else
                    {
                        line.Y1 = y1;
                        line.X1 = x1;
                        line.Y2 = y2 - distanceBetweenTwoPoints / 2;
                        line.X2 = x1;
                        destination.Children.Remove(line);
                        destination.Children.Add(line);
                    }
                }
                if (i == 3)
                {
                    if (line != null)
                        destination.Children.Remove(line);
                }
                if (i == 4)
                {
                    if (line != null)
                        destination.Children.Remove(line);
                }
                i++;
            }
        }
        private void ChangeLine2(Line[] masLine, double x1, double y1, double x2, double y2)
        {
            int i = 0;
            BrushConverter color = new();
            foreach (Line line in masLine)
            {
                if (i == 0)
                {
                    line.X2 = x2;
                    line.Y1 = y2;
                    line.X1 = x2;
                    line.Y2 = y2 + valueOffsetOfLineFromTheBlockToSides;
                    destination.Children.Remove(line);
                    destination.Children.Add(line);
                }
                if (i == 1)
                {
                    line.X1 = x1;
                    line.X2 = x1;
                    line.Y1 = y1 - valueOffsetOfLineFromTheBlockToSides;
                    line.Y2 = y1;
                    destination.Children.Remove(line);
                    destination.Children.Add(line);
                }
                if (i == 2)
                {
                    line.X2 = x1;
                    line.Y1 = y1 - valueOffsetOfLineFromTheBlockToSides;
                    line.Y2 = y1 - valueOffsetOfLineFromTheBlockToSides;
                    line.X1 = x1 + DefaultPropertyForBlock.width / 2 + valueOffsetOfLineFromTheBlockToSides;
                    destination.Children.Remove(line);
                    destination.Children.Add(line);
                }
                if (i == 3)
                {
                    if (line == null)
                    {
                        Line lineConnection = new();
                        lineConnection.Y1 = y1 - valueOffsetOfLineFromTheBlockToSides;
                        lineConnection.X1 = x1 + DefaultPropertyForBlock.width / 2 + valueOffsetOfLineFromTheBlockToSides;
                        lineConnection.Y2 = y2 + valueOffsetOfLineFromTheBlockToSides;
                        lineConnection.X2 = x1 + DefaultPropertyForBlock.width / 2 + valueOffsetOfLineFromTheBlockToSides;
                        lineConnection.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
                        listLineConnection.Add(lineConnection);
                        destination.Children.Remove(lineConnection);
                        destination.Children.Add(lineConnection);
                        masLine[i] = lineConnection;
                    }
                    else
                    {

                        line.Y1 = y1 - valueOffsetOfLineFromTheBlockToSides;
                        line.X1 = x1 + DefaultPropertyForBlock.width / 2 + valueOffsetOfLineFromTheBlockToSides;
                        line.Y2 = y2 + valueOffsetOfLineFromTheBlockToSides;
                        line.X2 = x1 + DefaultPropertyForBlock.width / 2 + valueOffsetOfLineFromTheBlockToSides;
                        destination.Children.Remove(line);
                        destination.Children.Add(line);

                    }
                }
                if (i == 4)
                {
                    if (line == null)
                    {
                        Line lineConnection = new();
                        lineConnection.X1 = x2;
                        lineConnection.Y1 = y2 + valueOffsetOfLineFromTheBlockToSides;
                        lineConnection.X2 = x1 + DefaultPropertyForBlock.width / 2 + valueOffsetOfLineFromTheBlockToSides;
                        lineConnection.Y2 = y2 + valueOffsetOfLineFromTheBlockToSides;
                        lineConnection.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
                        listLineConnection.Add(lineConnection);
                        destination.Children.Remove(lineConnection);
                        destination.Children.Add(lineConnection);
                        masLine[i] = lineConnection;
                    }
                    else
                    {
                        line.X1 = x2;
                        line.Y1 = y2 + valueOffsetOfLineFromTheBlockToSides;
                        line.X2 = x1 + DefaultPropertyForBlock.width / 2 + valueOffsetOfLineFromTheBlockToSides;
                        line.Y2 = y2 + valueOffsetOfLineFromTheBlockToSides;
                        destination.Children.Remove(line);
                        destination.Children.Add(line);
                    }
                }
                i++;
            }
        }
        private void ChangeLine3(Line[] masLine, double x1, double y1, double x2, double y2)
        {
            int i = 0;
            double distanceBetweenTwoPoints = y2 - y1;
            BrushConverter color = new();
            foreach (Line line in masLine)
            {
                if (i == 0)
                {
                    line.X1 = x2;
                    line.Y1 = y2;
                    line.X2 = x2 + valueOffsetOfLineFromTheBlockToSides;
                    line.Y2 = y2;
                    destination.Children.Remove(line);
                    destination.Children.Add(line);
                }
                if (i == 1)
                {
                    line.X1 = x2 + valueOffsetOfLineFromTheBlockToSides;
                    line.Y1 = y2;
                    line.X2 = x2 + valueOffsetOfLineFromTheBlockToSides;
                    line.Y2 = y2 - distanceBetweenTwoPoints - valueOffsetOfLineFromTheBlockToSides;
                    destination.Children.Remove(line);
                    destination.Children.Add(line);
                }
                if (i == 2)
                {
                    if (line == null)
                    {
                        Line lineConnection = new();
                        lineConnection.X1 = x1;
                        lineConnection.Y1 = y1 - valueOffsetOfLineFromTheBlockToSides;
                        lineConnection.X2 = x2 + valueOffsetOfLineFromTheBlockToSides;
                        lineConnection.Y2 = y2 - distanceBetweenTwoPoints - valueOffsetOfLineFromTheBlockToSides;
                        lineConnection.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
                        listLineConnection.Add(lineConnection);
                        destination.Children.Remove(lineConnection);
                        destination.Children.Add(lineConnection);
                        masLine[i] = lineConnection;
                    }
                    else
                    {
                        line.X1 = x1;
                        line.Y1 = y1 - valueOffsetOfLineFromTheBlockToSides;
                        line.X2 = x2 + valueOffsetOfLineFromTheBlockToSides;
                        line.Y2 = y2 - distanceBetweenTwoPoints - valueOffsetOfLineFromTheBlockToSides;
                        destination.Children.Remove(line);
                        destination.Children.Add(line);
                    }
                }
                if (i == 3)
                {
                    if (line == null)
                    {
                        Line lineConnection = new();
                        lineConnection.X1 = x1;
                        lineConnection.Y1 = y1;
                        lineConnection.X2 = x1;
                        lineConnection.Y2 = y1 - valueOffsetOfLineFromTheBlockToSides;
                        lineConnection.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
                        listLineConnection.Add(lineConnection);
                        destination.Children.Remove(lineConnection);
                        destination.Children.Add(lineConnection);
                        masLine[i] = lineConnection;
                    }
                    else
                    {
                        line.X1 = x1;
                        line.Y1 = y1;
                        line.X2 = x1;
                        line.Y2 = y1 - valueOffsetOfLineFromTheBlockToSides;
                        destination.Children.Remove(line);
                        destination.Children.Add(line);
                    }
                }
                i++;
            }
        }
        private void ChangeLine4(Line[] masLine, double x1, double y1, double x2, double y2)
        {
            int i = 0;
            foreach (Line line in masLine)
            {
                if (i == 0)
                {
                    line.X1 = x2;
                    line.Y1 = y2;
                    line.X2 = x1;
                    line.Y2 = y2;
                    destination.Children.Remove(line);
                    destination.Children.Add(line);
                }
                if (i == 1)
                {
                    line.X1 = x1;
                    line.Y1 = y2;
                    line.X2 = x1;
                    line.Y2 = y1;
                    destination.Children.Remove(line);
                    destination.Children.Add(line);
                }
                if (i == 2)
                {
                    destination.Children.Remove(line);
                }
                if (i == 3)
                {
                    destination.Children.Remove(line);
                }
                i++;
            }
        }
        private void ChangeLine5(Line[] masLine, double x1, double y1, double x2, double y2)
        {
            double distanceBetweenTwoPoints = x1 - x2;
            int i = 0;
            BrushConverter color = new();
            foreach (Line line in masLine) 
            {
                if (i == 0)
                {
                    line.X1 = x1;
                    line.Y1 = y1;
                    line.X2 = x1;
                    line.Y2 = y1 - valueOffsetOfLineFromTheBlockToSides;
                    destination.Children.Remove(line);
                    destination.Children.Add(line);
                }
                if (i == 1)
                {
                    line.X1 = x1;
                    line.Y1 = y1 - valueOffsetOfLineFromTheBlockToSides;
                    line.X2 = x1 - distanceBetweenTwoPoints + valueOffsetOfLineFromTheBlockToSides;
                    line.Y2 = y1 - valueOffsetOfLineFromTheBlockToSides;
                    destination.Children.Remove(line);
                    destination.Children.Add(line);
                }
                if (i == 2)
                {
                    if (line == null)
                    {
                        Line lineConnection = new();
                        lineConnection.X1 = x2;
                        lineConnection.Y1 = y2;
                        lineConnection.X2 = x2 + valueOffsetOfLineFromTheBlockToSides;
                        lineConnection.Y2 = y1;
                        lineConnection.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
                        listLineConnection.Add(lineConnection);

                        destination.Children.Remove(lineConnection);
                        destination.Children.Add(lineConnection);
                        masLine[i] = lineConnection;
                    }
                    else
                    {
                        line.X1 = x2;
                        line.Y1 = y2;
                        line.X2 = x2 + valueOffsetOfLineFromTheBlockToSides;
                        line.Y2 = y2;
                        destination.Children.Remove(line);
                        destination.Children.Add(line);
                    }
                }
                if (i == 3)
                {
                    if (line == null)
                    {
                        Line lineConnection = new();
                        lineConnection.X1 = x2 + valueOffsetOfLineFromTheBlockToSides;
                        lineConnection.Y1 = y2;
                        lineConnection.X2 = x2 + valueOffsetOfLineFromTheBlockToSides;
                        lineConnection.Y2 = y1 - valueOffsetOfLineFromTheBlockToSides;
                        lineConnection.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
                        listLineConnection.Add(lineConnection);
                        destination.Children.Remove(lineConnection);
                        destination.Children.Add(lineConnection);
                        masLine[i] = lineConnection;
                    }
                    else
                    {
                        line.X1 = x2 + valueOffsetOfLineFromTheBlockToSides;
                        line.Y1 = y2;
                        line.X2 = x2 + valueOffsetOfLineFromTheBlockToSides;
                        line.Y2 = y1 - valueOffsetOfLineFromTheBlockToSides;
                        destination.Children.Remove(line);
                        destination.Children.Add(line);
                    }
                }
                i++;
            }

        }
        private void ChangeLine6(Line[] masLine, double x1, double y1, double x2, double y2)
        {
            double distanceBetweenTwoPoints = y1 - y2;
            int i = 0;
            BrushConverter color = new();
            foreach (Line line in masLine)
            {
                if (i == 0)
                {
                    line.X1 = x1;
                    line.Y1 = y1;
                    line.X2 = x1;
                    line.Y2 = y1 - valueOffsetOfLineFromTheBlockToSides;
                }
                if (i == 1)
                {
                    line.X1 = x2;
                    line.Y1 = y2 - valueOffsetOfLineFromTheBlockToSides;
                    line.X2 = x2 + DefaultPropertyForBlock.width / 2 + valueOffsetOfLineFromTheBlockToSides;
                    line.Y2 = y2 - valueOffsetOfLineFromTheBlockToSides;
                }
                if (i == 2)
                {
                    line.X1 = x2 + DefaultPropertyForBlock.width / 2 + valueOffsetOfLineFromTheBlockToSides;
                    line.Y1 = y2 - valueOffsetOfLineFromTheBlockToSides;
                    line.X2 = x2 + DefaultPropertyForBlock.width / 2 + valueOffsetOfLineFromTheBlockToSides;
                    line.Y2 = y2 - valueOffsetOfLineFromTheBlockToSides + distanceBetweenTwoPoints;
                }
                if (i == 3)
                {
                    if (line == null)
                    {
                        Line lineConnection = new();
                        lineConnection.X1 = x2 + DefaultPropertyForBlock.width / 2 + valueOffsetOfLineFromTheBlockToSides;
                        lineConnection.Y1 = y2 - valueOffsetOfLineFromTheBlockToSides + distanceBetweenTwoPoints;
                        lineConnection.X2 = x1;
                        lineConnection.Y2 = y1 - valueOffsetOfLineFromTheBlockToSides;
                        lineConnection.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
                        listLineConnection.Add(lineConnection);
                        destination.Children.Remove(lineConnection);
                        destination.Children.Add(lineConnection);
                        masLine[i] = lineConnection;
                    }
                    else
                    {
                        line.X1 = x2 + DefaultPropertyForBlock.width / 2 + valueOffsetOfLineFromTheBlockToSides;
                        line.Y1 = y2 - valueOffsetOfLineFromTheBlockToSides + distanceBetweenTwoPoints;
                        line.X2 = x1;
                        line.Y2 = y1 - valueOffsetOfLineFromTheBlockToSides;
                        destination.Children.Remove(line);
                        destination.Children.Add(line);
                    }
                }
                if (i == 4)
                {
                    if (line == null)
                    {
                        Line lineConnection = new();
                        lineConnection.X2 = x2;
                        lineConnection.Y1 = y2;
                        lineConnection.X1 = x2;
                        lineConnection.Y2 = y2 - valueOffsetOfLineFromTheBlockToSides;
                        lineConnection.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
                        listLineConnection.Add(lineConnection);
                        destination.Children.Remove(lineConnection);
                        destination.Children.Add(lineConnection);
                        masLine[i] = lineConnection;
                    }
                    else
                    {
                        line.X2 = x2;
                        line.Y1 = y2;
                        line.X1 = x2;
                        line.Y2 = y2 - valueOffsetOfLineFromTheBlockToSides;
                        destination.Children.Remove(line);
                        destination.Children.Add(line);
                    }
                }
                i++;
            }
        }
        private void ChangeLine7(Line[] masLine, double x1, double y1, double x2, double y2)
        {
            int i = 0;
            foreach (Line line in masLine)
            {
                if (i == 0)
                {
                    line.X1 = x2;
                    line.Y1 = y2;
                    line.X2 = x2;
                    line.Y2 = y2 - valueOffsetOfLineFromTheBlockToSides;
                }
                if (i == 1)
                {
                    line.X1 = x2;
                    line.Y1 = y2 - valueOffsetOfLineFromTheBlockToSides;
                    line.X2 = x1;
                    line.Y2 = y2 - valueOffsetOfLineFromTheBlockToSides;
                }
                if (i == 2)
                {
                    line.X1 = x1;
                    line.Y1 = y2 - valueOffsetOfLineFromTheBlockToSides;
                    line.X2 = x1;
                    line.Y2 = y1;
                }
                if (i == 3)
                {
                    destination.Children.Remove(line);
                }
                if (i == 4)
                {
                    destination.Children.Remove(line);

                }
                i++;
            }
        }
        private void ChangeLine8(Line[] masLine, double x1, double y1, double x2, double y2)
        {
            int i = 0;
            double distanceBetweenTwoPoints = y2 - y1;
            BrushConverter color = new();
            foreach (Line line in masLine)
            {
                if (i == 0)
                {
                    line.X1 = x2;
                    line.Y1 = y2;
                    line.X2 = x2 - valueOffsetOfLineFromTheBlockToSides;
                    line.Y2 = y2;
                }
                if (i == 1)
                {
                    line.X1 = x2 - valueOffsetOfLineFromTheBlockToSides;
                    line.Y1 = y2;
                    line.X2 = x2 - valueOffsetOfLineFromTheBlockToSides;
                    line.Y2 = y2 - distanceBetweenTwoPoints - valueOffsetOfLineFromTheBlockToSides;
                }
                if (i == 2)
                {
                    if (line == null)
                    {
                        Line lineConnection = new();
                        lineConnection.X1 = x1;
                        lineConnection.Y1 = y1 - valueOffsetOfLineFromTheBlockToSides;
                        lineConnection.X2 = x2 - valueOffsetOfLineFromTheBlockToSides;
                        lineConnection.Y2 = y2 - distanceBetweenTwoPoints - valueOffsetOfLineFromTheBlockToSides;
                        lineConnection.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
                        listLineConnection.Add(lineConnection);
                        destination.Children.Remove(lineConnection);
                        destination.Children.Add(lineConnection);
                        masLine[i] = lineConnection;
                    }
                    else
                    {
                        line.X1 = x1;
                        line.Y1 = y1 - valueOffsetOfLineFromTheBlockToSides;
                        line.X2 = x2 - valueOffsetOfLineFromTheBlockToSides;
                        line.Y2 = y2 - distanceBetweenTwoPoints - valueOffsetOfLineFromTheBlockToSides;
                        destination.Children.Remove(line);
                        destination.Children.Add(line);
                    }
                }
                if (i == 3)
                {
                    if (line == null)
                    {
                        Line lineConnection = new();
                        lineConnection.X1 = x1;
                        lineConnection.Y1 = y1;
                        lineConnection.X2 = x1;
                        lineConnection.Y2 = y1 - valueOffsetOfLineFromTheBlockToSides;
                        lineConnection.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
                        listLineConnection.Add(lineConnection);
                        destination.Children.Remove(lineConnection);
                        destination.Children.Add(lineConnection);
                        masLine[i] = lineConnection;
                    }
                    else
                    {
                        line.X1 = x1;
                        line.Y1 = y1;
                        line.X2 = x1;
                        line.Y2 = y1 - valueOffsetOfLineFromTheBlockToSides;
                        destination.Children.Remove(line);
                        destination.Children.Add(line);
                    } 
                }
                i++;
            }
        }
        private void ChangeLine9(Line[] masLine, double x1, double y1, double x2, double y2)
        {
            int i = 0;
            foreach (Line line in masLine)
            {
                if (i == 0)
                {
                    line.X1 = x1;
                    line.Y1 = y1;
                    line.X2 = x1 - valueOffsetOfLineFromTheBlockToSides;
                    line.Y2 = y1;
                }
                if (i == 1)
                {
                    line.X1 = x1 - valueOffsetOfLineFromTheBlockToSides;
                    line.Y1 = y1;
                    line.X2 = x1 - valueOffsetOfLineFromTheBlockToSides;
                    line.Y2 = y2;
                }
                if (i == 2)
                {
                    line.X1 = x1 - valueOffsetOfLineFromTheBlockToSides;
                    line.Y1 = y2;
                    line.X2 = x2;
                    line.Y2 = y2;
                }
                if (i == 3)
                {
                    destination.Children.Remove(line); 
                }
                if (i == 4)
                {
                    destination.Children.Remove(line);
                }
                i++;
            }
        }
        private void ChangeLine10(Line[] masLine, double x1, double y1, double x2, double y2)
        {
            int i = 0;
            BrushConverter color = new();
            foreach (Line line in masLine)
            {
                if (i == 0)
                {
                    line.X1 = x1;
                    line.Y1 = y1;
                    line.X2 = x1 - valueOffsetOfLineFromTheBlockToSides;
                    line.Y2 = y1;
                    destination.Children.Remove(line);
                    destination.Children.Add(line);
                }
                if (i == 1)
                {
                    line.X1 = x1 - valueOffsetOfLineFromTheBlockToSides;
                    line.Y1 = y1;
                    line.X2 = x1 - valueOffsetOfLineFromTheBlockToSides;
                    line.Y2 = y2 + DefaultPropertyForBlock.height / 2 + valueOffsetOfLineFromTheBlockToSides;
                    destination.Children.Remove(line);
                    destination.Children.Add(line);
                }
                if (i == 2)
                {
                    line.X1 = x1 - valueOffsetOfLineFromTheBlockToSides;
                    line.Y1 = y2 + DefaultPropertyForBlock.height / 2 + valueOffsetOfLineFromTheBlockToSides;
                    line.X2 = x2 - valueOffsetOfLineFromTheBlockToSides;
                    line.Y2 = y2 + DefaultPropertyForBlock.height / 2 + valueOffsetOfLineFromTheBlockToSides;
                    destination.Children.Remove(line);
                    destination.Children.Add(line);
                }
                if (i == 3)
                {
                    if (line == null)
                    {
                        Line lineConnection = new();
                        lineConnection.X1 = x2 - valueOffsetOfLineFromTheBlockToSides;
                        lineConnection.Y1 = y2 + DefaultPropertyForBlock.height / 2 + valueOffsetOfLineFromTheBlockToSides;
                        lineConnection.X2 = x2 - valueOffsetOfLineFromTheBlockToSides;
                        lineConnection.Y2 = y2;
                        lineConnection.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
                        listLineConnection.Add(lineConnection);
                        destination.Children.Remove(lineConnection);
                        destination.Children.Add(lineConnection);
                        masLine[i] = lineConnection;
                    }
                    else
                    {
                        line.X1 = x2 - valueOffsetOfLineFromTheBlockToSides;
                        line.Y1 = y2 + DefaultPropertyForBlock.height / 2 + valueOffsetOfLineFromTheBlockToSides;
                        line.X2 = x2 - valueOffsetOfLineFromTheBlockToSides;
                        line.Y2 = y2;
                        destination.Children.Remove(line);
                        destination.Children.Add(line);
                    }
                }
                if (i == 4)
                {
                    if (line == null)
                    {
                        Line lineConnection = new();
                        lineConnection.X2 = x2;
                        lineConnection.Y1 = y2;
                        lineConnection.X1 = x2 - valueOffsetOfLineFromTheBlockToSides;
                        lineConnection.Y2 = y2;
                        lineConnection.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
                        listLineConnection.Add(lineConnection);
                        destination.Children.Remove(lineConnection);
                        destination.Children.Add(lineConnection);
                        masLine[i] = lineConnection;
                    }
                    else
                    {
                        line.X2 = x2;
                        line.Y1 = y2;
                        line.X1 = x2 - valueOffsetOfLineFromTheBlockToSides;
                        line.Y2 = y2;
                        destination.Children.Remove(line);
                        destination.Children.Add(line);
                    }
                }
                i++;
            }
        }
        private void ChangeLine11(Line[] masLine, double x1, double y1, double x2, double y2)
        {
            int i = 0;
            BrushConverter color = new();
            foreach (Line line in masLine)
            {
                if (i == 0)
                {
                    line.X1 = x2;
                    line.Y1 = y2;
                    line.X2 = x2 - valueOffsetOfLineFromTheBlockToSides;
                    line.Y2 = y2;
                }
                if (i == 1)
                {
                    line.X1 = x2 - valueOffsetOfLineFromTheBlockToSides;
                    line.Y1 = y2;
                    line.X2 = x2 - valueOffsetOfLineFromTheBlockToSides;
                    line.Y2 = y1 + valueOffsetOfLineFromTheBlockToSides;
                }
                if (i == 2)
                {
                    if (line == null)
                    {
                        Line lineConnection = new();
                        lineConnection.X1 = x2 - valueOffsetOfLineFromTheBlockToSides;
                        lineConnection.Y1 = y1 + valueOffsetOfLineFromTheBlockToSides;
                        lineConnection.X2 = x1;
                        lineConnection.Y2 = y1 + valueOffsetOfLineFromTheBlockToSides;
                        lineConnection.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
                        listLineConnection.Add(lineConnection);
                        destination.Children.Remove(lineConnection);
                        destination.Children.Add(lineConnection);
                        masLine[i] = lineConnection;
                    }
                    else
                    {
                        line.X1 = x2 - valueOffsetOfLineFromTheBlockToSides;
                        line.Y1 = y1 + valueOffsetOfLineFromTheBlockToSides;
                        line.X2 = x1;
                        line.Y2 = y1 + valueOffsetOfLineFromTheBlockToSides;
                        destination.Children.Remove(line);
                        destination.Children.Add(line);
                    }
                }
                if (i == 3)
                {
                    if (line == null)
                    {
                        Line lineConnection = new();
                        lineConnection.X1 = x1;
                        lineConnection.Y1 = y1;
                        lineConnection.X2 = x1;
                        lineConnection.Y2 = y1 + valueOffsetOfLineFromTheBlockToSides;
                        lineConnection.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
                        listLineConnection.Add(lineConnection);
                        destination.Children.Remove(lineConnection);
                        destination.Children.Add(lineConnection);
                        masLine[i] = lineConnection;
                    }
                    else
                    {
                        line.X1 = x1;
                        line.Y1 = y1;
                        line.X2 = x1;
                        line.Y2 = y1 + valueOffsetOfLineFromTheBlockToSides;
                        destination.Children.Remove(line);
                        destination.Children.Add(line);
                    }
                }
                i++;
            }
        }

        private void ChangeLine12(Line[] masLine, double x1, double y1, double x2, double y2)
        {
            int i = 0;
            BrushConverter color = new();
            foreach (Line line in masLine)
            {
                if (i == 0)
                {
                    line.X1 = x2;
                    line.Y1 = y2;
                    line.X2 = x2 - valueOffsetOfLineFromTheBlockToSides;
                    line.Y2 = y2;
                }
                if (i == 1)
                {
                    line.X1 = x2 - valueOffsetOfLineFromTheBlockToSides;
                    line.Y1 = y2;
                    line.X2 = x2 - valueOffsetOfLineFromTheBlockToSides;
                    line.Y2 = y2 + DefaultPropertyForBlock.height / 2 + valueOffsetOfLineFromTheBlockToSides;
                }
                if (i == 2)
                {
                    line.X1 = x2 - valueOffsetOfLineFromTheBlockToSides;
                    line.Y1 = y2 + DefaultPropertyForBlock.height / 2 + valueOffsetOfLineFromTheBlockToSides;
                    line.X2 = x1 + valueOffsetOfLineFromTheBlockToSides;
                    line.Y2 = y2 + DefaultPropertyForBlock.height / 2 + valueOffsetOfLineFromTheBlockToSides;
                }
                if (i == 3)
                {
                    if (line == null)
                    {
                        Line lineConnection = new();
                        lineConnection.X1 = x1 + valueOffsetOfLineFromTheBlockToSides;
                        lineConnection.Y1 = y1;
                        lineConnection.X2 = x1 + valueOffsetOfLineFromTheBlockToSides;
                        lineConnection.Y2 = y2 + DefaultPropertyForBlock.height / 2 + valueOffsetOfLineFromTheBlockToSides;
                        lineConnection.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
                        listLineConnection.Add(lineConnection);
                        destination.Children.Remove(lineConnection);
                        destination.Children.Add(lineConnection);
                        masLine[i] = lineConnection;
                    }
                    else
                    {
                        line.X1 = x1 + valueOffsetOfLineFromTheBlockToSides;
                        line.Y1 = y1;
                        line.X2 = x1 + valueOffsetOfLineFromTheBlockToSides;
                        line.Y2 = y2 + DefaultPropertyForBlock.height / 2 + valueOffsetOfLineFromTheBlockToSides;
                        destination.Children.Remove(line);
                        destination.Children.Add(line);
                    }
                }
                if (i == 4)
                {
                    if (line == null)
                    {
                        Line lineConnection = new();
                        lineConnection.X2 = x1;
                        lineConnection.Y1 = y1;
                        lineConnection.X1 = x1 + valueOffsetOfLineFromTheBlockToSides;
                        lineConnection.Y2 = y1;
                        lineConnection.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
                        listLineConnection.Add(lineConnection);
                        destination.Children.Remove(lineConnection);
                        destination.Children.Add(lineConnection);
                        masLine[i] = lineConnection;
                    }
                    else
                    { 
                        line.X2 = x1;
                        line.Y1 = y1;
                        line.X1 = x1 + valueOffsetOfLineFromTheBlockToSides;
                        line.Y2 = y1;
                        destination.Children.Remove(line);
                        destination.Children.Add(line);
                    }
                }
                i++;
            }
        }
        private void ChangeLine13(Line[] masLine, double x1, double y1, double x2, double y2)
        {
            int i = 0;
            double distanceBetweenTwoPoints = x1 - x2;
            foreach (Line line in masLine)
            {
                if (i == 0)
                {
                    line.X1 = x1;
                    line.Y1 = y1;
                    line.X2 = x1 - distanceBetweenTwoPoints / 2;
                    line.Y2 = y1;
                }
                if (i == 1)
                {
                    line.X1 = x1 - distanceBetweenTwoPoints / 2;
                    line.Y1 = y1;
                    line.X2 = x2 + distanceBetweenTwoPoints / 2;
                    line.Y2 = y2;
                }
                if (i == 2)
                {
                    line.X1 = x2;
                    line.Y1 = y2;
                    line.X2 = x2 + distanceBetweenTwoPoints / 2;
                    line.Y2 = y2;
                }
                if (i == 3)
                {
                    destination.Children.Remove(line);
                }
                if (i == 4)
                {
                    destination.Children.Remove(line);
                }
                i++;
            }
        }

        private void ChangeLine14(Line[] masLine, double x1, double y1, double x2, double y2)
        {
            int i = 0;
            double distanceBetweenTwoPoints = y1 - y2;
            BrushConverter color = new();
            foreach (Line line in masLine)
            {
                if (i == 0)
                {
                    line.X1 = x1;
                    line.Y1 = y1;
                    line.X2 = x1;
                    line.Y2 = y1 + valueOffsetOfLineFromTheBlockToSides;
                    destination.Children.Remove(line);
                    destination.Children.Add(line);
                }
                if (i == 1)
                {
                    line.X1 = x2;
                    line.Y1 = y2 + valueOffsetOfLineFromTheBlockToSides;
                    line.X2 = x2 + DefaultPropertyForBlock.width / 2 + valueOffsetOfLineFromTheBlockToSides;
                    line.Y2 = y2 + valueOffsetOfLineFromTheBlockToSides;
                    destination.Children.Remove(line);
                    destination.Children.Add(line);
                }
                if (i == 2)
                {
                    line.X1 = x2 + DefaultPropertyForBlock.width / 2 + valueOffsetOfLineFromTheBlockToSides;
                    line.Y1 = y2 + valueOffsetOfLineFromTheBlockToSides;
                    line.X2 = x2 + DefaultPropertyForBlock.width / 2 + valueOffsetOfLineFromTheBlockToSides;
                    line.Y2 = y2 + valueOffsetOfLineFromTheBlockToSides + distanceBetweenTwoPoints;
                    destination.Children.Remove(line);
                    destination.Children.Add(line);
                }
                if (i == 3)
                {
                    if (line == null)
                    {
                        Line lineConnection = new();
                        lineConnection.X1 = x2 + DefaultPropertyForBlock.width / 2 + valueOffsetOfLineFromTheBlockToSides;
                        lineConnection.Y1 = y2 + valueOffsetOfLineFromTheBlockToSides + distanceBetweenTwoPoints;
                        lineConnection.X2 = x1;
                        lineConnection.Y2 = y1 + valueOffsetOfLineFromTheBlockToSides;
                        lineConnection.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
                        listLineConnection.Add(lineConnection);
                        destination.Children.Remove(lineConnection);
                        destination.Children.Add(lineConnection);
                        masLine[i] = lineConnection;
                    }
                    else
                    {
                        line.X1 = x2 + DefaultPropertyForBlock.width / 2 + valueOffsetOfLineFromTheBlockToSides;
                        line.Y1 = y2 + valueOffsetOfLineFromTheBlockToSides + distanceBetweenTwoPoints;
                        line.X2 = x1;
                        line.Y2 = y1 + valueOffsetOfLineFromTheBlockToSides;
                        destination.Children.Remove(line);
                        destination.Children.Add(line);
                    }
                }
                if (i == 4)
                {
                    if (line == null)
                    {
                        Line lineConnection = new();
                        lineConnection.X2 = x2;
                        lineConnection.Y1 = y2;
                        lineConnection.X1 = x2;
                        lineConnection.Y2 = y2 + valueOffsetOfLineFromTheBlockToSides;
                        lineConnection.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
                        listLineConnection.Add(lineConnection);
                        destination.Children.Remove(lineConnection);
                        destination.Children.Add(lineConnection);
                        masLine[i] = lineConnection;
                    }
                    else
                    {
                        line.X2 = x2;
                        line.Y1 = y2;
                        line.X1 = x2;
                        line.Y2 = y2 + valueOffsetOfLineFromTheBlockToSides;
                        destination.Children.Remove(line);
                        destination.Children.Add(line);
                    }
                }
                i++;
            }
        }
        private void ChangeLine15(Line[] masLine, double x1, double y1, double x2, double y2)
        {
            int i = 0;
            double distanceBetweenTwoPoints = y1 - y2;
            foreach (Line line in masLine)
            {
                if (i == 0)
                {
                    line.X1 = x2;
                    line.Y1 = y2;
                    line.X2 = x2;
                    line.Y2 = y2 + distanceBetweenTwoPoints + valueOffsetOfLineFromTheBlockToSides;
                }
                if (i == 1)
                {
                    line.X1 = x2;
                    line.Y1 = y2 + distanceBetweenTwoPoints + valueOffsetOfLineFromTheBlockToSides;
                    line.X2 = x1;
                    line.Y2 = y1 + valueOffsetOfLineFromTheBlockToSides;
                }
                if (i == 2)
                {
                    line.X1 = x1;
                    line.Y1 = y1;
                    line.X2 = x1;
                    line.Y2 = y1 + valueOffsetOfLineFromTheBlockToSides;
                }
                if (i == 3)
                {
                    destination.Children.Remove(line);
                }
                if (i == 4)
                {
                    destination.Children.Remove(line);
                }
                i++;
            }
        }

        private void ChangeLine16(Line[] masLine, double x1, double y1, double x2, double y2)
        {
            int i = 0;
            BrushConverter color = new();
            foreach (Line line in masLine)
            {
                if (i == 0)
                {
                    line.X1 = x1;
                    line.Y1 = y1;
                    line.X2 = x1;
                    line.Y2 = y1 + valueOffsetOfLineFromTheBlockToSides;
                }
                if (i == 1)
                {
                    line.X1 = x2 + valueOffsetOfLineFromTheBlockToSides;
                    line.Y1 = y1 + valueOffsetOfLineFromTheBlockToSides;
                    line.X2 = x1;
                    line.Y2 = y1 + valueOffsetOfLineFromTheBlockToSides;
                }
                if (i == 2)
                {
                    if (line == null)
                    {
                        Line lineConnection = new();
                        lineConnection.X1 = x2 + valueOffsetOfLineFromTheBlockToSides;
                        lineConnection.Y1 = y1 + valueOffsetOfLineFromTheBlockToSides;
                        lineConnection.X2 = x2 + valueOffsetOfLineFromTheBlockToSides;
                        lineConnection.Y2 = y2;
                        lineConnection.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
                        listLineConnection.Add(lineConnection);
                        destination.Children.Remove(lineConnection);
                        destination.Children.Add(lineConnection);
                        masLine[i] = lineConnection;
                    }
                    else
                    {
                        line.X1 = x2 + valueOffsetOfLineFromTheBlockToSides;
                        line.Y1 = y1 + valueOffsetOfLineFromTheBlockToSides;
                        line.X2 = x2 + valueOffsetOfLineFromTheBlockToSides;
                        line.Y2 = y2;
                        destination.Children.Remove(line);
                        destination.Children.Add(line);
                    }
                }
                if (i == 3)
                {
                    if (line == null)
                    {
                        Line lineConnection = new();
                        lineConnection.X1 = x2;
                        lineConnection.Y1 = y2;
                        lineConnection.X2 = x2 + valueOffsetOfLineFromTheBlockToSides;
                        lineConnection.Y2 = y2;
                        lineConnection.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
                        listLineConnection.Add(lineConnection);
                        destination.Children.Remove(lineConnection);
                        destination.Children.Add(lineConnection);
                        masLine[i] = lineConnection;
                    }
                    else
                    {
                        line.X1 = x2;
                        line.Y1 = y2;
                        line.X2 = x2 + valueOffsetOfLineFromTheBlockToSides;
                        line.Y2 = y2;
                        destination.Children.Remove(line);
                        destination.Children.Add(line);
                    }
                }
                i++;
            }
        }
        private void ChangeLine17(Line[] masLine, double x1, double y1, double x2, double y2)
        {
            int i = 0;
            double distanceBetweenTwoPoints = x2 - x1;
            foreach (Line line in masLine)
            {
                if (i == 0)
                {
                    line.X1 = x1;
                    line.Y1 = y1;
                    line.X2 = x1 + valueOffsetOfLineFromTheBlockToSides;
                    line.Y2 = y1;
                }
                if (i == 1)
                {
                    line.X1 = x1 + valueOffsetOfLineFromTheBlockToSides;
                    line.Y1 = y1;
                    line.X2 = x2 - distanceBetweenTwoPoints + valueOffsetOfLineFromTheBlockToSides;
                    line.Y2 = y2;
                }
                if (i == 2)
                {
                    line.X1 = x2;
                    line.Y1 = y2;
                    line.X2 = x2 - distanceBetweenTwoPoints + valueOffsetOfLineFromTheBlockToSides;
                    line.Y2 = y2;
                }
                if (i == 3)
                {
                    destination.Children.Remove(line);
                }
                if (i == 4)
                {
                    destination.Children.Remove(line);
                }
                i++;
            }
        }

        private void ChangeLine18(Line[] masLine, double x1, double y1, double x2, double y2)
        {
            int i = 0;
            foreach (Line line in masLine)
            {
                if (i == 0)
                {
                    line.X1 = x2;
                    line.Y1 = y2;
                    line.X2 = x2 + valueOffsetOfLineFromTheBlockToSides;
                    line.Y2 = y2;
                }
                if (i == 1)
                {
                    line.X1 = x2 + valueOffsetOfLineFromTheBlockToSides;
                    line.Y1 = y2;
                    line.X2 = x2 + valueOffsetOfLineFromTheBlockToSides;
                    line.Y2 = y1;
                }
                if (i == 2)
                {
                    line.X1 = x2 + valueOffsetOfLineFromTheBlockToSides;
                    line.Y1 = y1;
                    line.X2 = x1;
                    line.Y2 = y1;
                }
                if (i == 3)
                {
                    destination.Children.Remove(line);
                }
                if (i == 4)
                {
                    destination.Children.Remove(line);
                }
                i++;
            }
        }

        private void ChangeLine19(Line[] masLine, double x1, double y1, double x2, double y2)
        {
            int i = 0;
            BrushConverter color = new();
            foreach (Line line in masLine)
            {
                if (i == 0)
                {
                    line.X1 = x1;
                    line.Y1 = y1;
                    line.X2 = x1 + valueOffsetOfLineFromTheBlockToSides;
                    line.Y2 = y1;
                    destination.Children.Remove(line);
                    destination.Children.Add(line);
                }
                if (i == 1)
                {
                    line.X1 = x1 + valueOffsetOfLineFromTheBlockToSides;
                    line.Y1 = y1;
                    line.X2 = x1 + valueOffsetOfLineFromTheBlockToSides;
                    line.Y2 = y2 + DefaultPropertyForBlock.height / 2 + valueOffsetOfLineFromTheBlockToSides;
                    destination.Children.Remove(line);
                    destination.Children.Add(line);
                }
                if (i == 2)
                {
                    line.X1 = x1 + valueOffsetOfLineFromTheBlockToSides;
                    line.Y1 = y2 + DefaultPropertyForBlock.height / 2 + valueOffsetOfLineFromTheBlockToSides;
                    line.X2 = x2 + valueOffsetOfLineFromTheBlockToSides;
                    line.Y2 = y2 + DefaultPropertyForBlock.height / 2 + valueOffsetOfLineFromTheBlockToSides;
                    destination.Children.Remove(line);
                    destination.Children.Add(line);
                }
                if (i == 3)
                {
                    if (line == null)
                    {
                        Line lineConnection = new();
                        lineConnection.X1 = x2 + valueOffsetOfLineFromTheBlockToSides;
                        lineConnection.Y1 = y2 + DefaultPropertyForBlock.height / 2 + valueOffsetOfLineFromTheBlockToSides;
                        lineConnection.X2 = x2 + valueOffsetOfLineFromTheBlockToSides;
                        lineConnection.Y2 = y2;
                        lineConnection.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
                        listLineConnection.Add(lineConnection);
                        destination.Children.Remove(lineConnection);
                        destination.Children.Add(lineConnection);
                        masLine[i] = lineConnection;
                    }
                    else
                    {
                        line.X1 = x2 + valueOffsetOfLineFromTheBlockToSides;
                        line.Y1 = y2 + DefaultPropertyForBlock.height / 2 + valueOffsetOfLineFromTheBlockToSides;
                        line.X2 = x2 + valueOffsetOfLineFromTheBlockToSides;
                        line.Y2 = y2;
                        destination.Children.Remove(line);
                        destination.Children.Add(line);
                    }
                }
                if (i == 4)
                {
                    if (line == null)
                    {
                        Line lineConnection = new();
                        lineConnection.X2 = x2;
                        lineConnection.Y1 = y2;
                        lineConnection.X1 = x2 + valueOffsetOfLineFromTheBlockToSides;
                        lineConnection.Y2 = y2;
                        lineConnection.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
                        listLineConnection.Add(lineConnection);
                        destination.Children.Remove(lineConnection);
                        destination.Children.Add(lineConnection);
                        masLine[i] = lineConnection;
                    }
                    else
                    {
                        line.X2 = x2;
                        line.Y1 = y2;
                        line.X1 = x2 + valueOffsetOfLineFromTheBlockToSides;
                        line.Y2 = y2;
                        destination.Children.Remove(line);
                        destination.Children.Add(line);
                    }
                }
                i++;
            }
        }

        private void ChangeLine(Block firstBlock)
        {
            firstBlock = firstBlock.GetMyLine().GetFirstBlock();
            Block secondBlock = firstBlock.GetMyLine().GetSecondBlock();

            double x1 = Canvas.GetLeft((Ellipse)firstBlock.GetFirstSender()) + Canvas.GetLeft(firstBlock.GetCanvas()) + 3;
            double y1 = Canvas.GetTop((Ellipse)firstBlock.GetFirstSender()) + Canvas.GetTop(firstBlock.GetCanvas()) + 3;

            double x2 = Canvas.GetLeft((Ellipse)secondBlock.GetFirstSender()) + Canvas.GetLeft(secondBlock.GetCanvas()) + 3;
            double y2 = Canvas.GetTop((Ellipse)secondBlock.GetFirstSender()) + Canvas.GetTop(secondBlock.GetCanvas()) + 3;

            Line[] masLine;
            if (firstBlock.flag != null)
            {
                bool flagFirstBlock = (bool)firstBlock.flag;

                if (flagFirstBlock)
                    masLine = firstBlock.GetMyLine().GetFirtLine();
                else
                    masLine = secondBlock.GetMyLine().GetFirtLine();

                if (firstBlock.flagForEnteringFirstConnectionPoint && secondBlock.flagForEnteringThirdConnectionPoint)
                {
                    if (x1 != x2 && y1 > y2)
                        ChangeLine1(masLine, x2, y2, x1, y1);
                    else if (x1 != x2 && y1 < y2)
                        ChangeLine2(masLine, x1, y1, x2, y2);
                }
                if (firstBlock.flagForEnteringThirdConnectionPoint && secondBlock.flagForEnteringFirstConnectionPoint)
                {
                    if (x1 != x2 && y1 < y2)
                        ChangeLine1(masLine, x1, y1, x2, y2);
                    else if (x1 != x2 && y1 > y2)
                        ChangeLine2(masLine, x2, y2, x1, y1);
                }
                if (firstBlock.flagForEnteringFirstConnectionPoint && secondBlock.flagForEnteringFourthConnectionPoint)
                {
                    if (y2 < y1 && x1 - valueOffsetOfLineFromTheBlockToSides <= x2)
                        ChangeLine3(masLine, x1, y1, x2, y2);
                    else if (y2 < y1 && x1 >= x2)
                        ChangeLine4(masLine, x1, y1, x2, y2);
                    else if (y2 > y1 - valueOffsetOfLineFromTheBlockToSides)
                        ChangeLine5(masLine, x1, y1, x2, y2);
                }
                if (firstBlock.flagForEnteringFourthConnectionPoint && secondBlock.flagForEnteringFirstConnectionPoint)
                {
                    if (y2 > y1 && x1 >= x2 - valueOffsetOfLineFromTheBlockToSides)
                        ChangeLine3(masLine, x2, y2, x1, y1);
                    else if (y2 > y1 && x1 <= x2)
                        ChangeLine4(masLine, x2, y2, x1, y1);
                    else if (y2 < y1 - valueOffsetOfLineFromTheBlockToSides)
                        ChangeLine5(masLine, x2, y2, x1, y1);
                }
                if (firstBlock.flagForEnteringFirstConnectionPoint && secondBlock.flagForEnteringFirstConnectionPoint)
                {
                    if ((x2 + DefaultPropertyForBlock.width / 2 < x1) || (x1 + DefaultPropertyForBlock.width / 2 < x2))
                    {
                        if (y1 > y2)
                            ChangeLine7(masLine, x1, y1, x2, y2);
                        else
                            ChangeLine7(masLine, x2, y2, x1, y1);
                    }
                    else ChangeLine6(masLine, x1, y1, x2, y2);
                }
                if (firstBlock.flagForEnteringFirstConnectionPoint && secondBlock.flagForEnteringSecondConnectionPoint)
                {
                    if (x1 <= x2 && y1 > y2)
                        ChangeLine4(masLine, x1, y1, x2, y2);
                    else
                        ChangeLine8(masLine, x1, y1, x2, y2);
                }
                if (firstBlock.flagForEnteringSecondConnectionPoint && secondBlock.flagForEnteringFirstConnectionPoint)
                {
                    if (x1 >= x2 && y1 < y2)
                        ChangeLine4(masLine, x2, y2, x1, y1);
                    else
                        ChangeLine8(masLine, x2, y2, x1, y1);
                }
                if (firstBlock.flagForEnteringSecondConnectionPoint && secondBlock.flagForEnteringSecondConnectionPoint)
                {
                    if ((y1 + DefaultPropertyForBlock.height / 2 <= y2 && y1 > y2) || (y1 <= y2 && y1 >= y2 - DefaultPropertyForBlock.height) || (y1 == y2))
                        ChangeLine10(masLine, x2, y2, x1, y1);
                    else if (x2 < x1)
                        ChangeLine9(masLine, x2, y2, x1, y1);
                    else if (x2 > x1)
                        ChangeLine9(masLine, x1, y1, x2, y2);
                }
                if (firstBlock.flagForEnteringSecondConnectionPoint && secondBlock.flagForEnteringThirdConnectionPoint)
                {
                    if (x1 > x2 && y2 < y1)
                        ChangeLine4(masLine, x2, y2, x1, y1);
                    else
                        ChangeLine11(masLine, x2, y2, x1, y1);
                }
                if (firstBlock.flagForEnteringThirdConnectionPoint && secondBlock.flagForEnteringSecondConnectionPoint)
                {
                    if (x1 < x2 && y2 > y1)
                        ChangeLine4(masLine, x1, y1, x2, y2);
                    else
                        ChangeLine11(masLine, x1, y1, x2, y2);
                }
                if (firstBlock.flagForEnteringSecondConnectionPoint && secondBlock.flagForEnteringFourthConnectionPoint)
                {
                    if (x2 < x1)
                        ChangeLine13(masLine, x2, y2, x1, y1);
                    else
                        ChangeLine12(masLine, x2, y2, x1, y1);
                }
                if (firstBlock.flagForEnteringFourthConnectionPoint && secondBlock.flagForEnteringSecondConnectionPoint)
                {
                    if (x2 > x1)
                        ChangeLine13(masLine, x2, y2, x1, y1);
                    else
                        ChangeLine12(masLine, x1, y1, x2, y2);
                }
                if (firstBlock.flagForEnteringThirdConnectionPoint && secondBlock.flagForEnteringThirdConnectionPoint)
                {
                    if ((x2 + DefaultPropertyForBlock.width / 2 < x1) || (x1 + DefaultPropertyForBlock.width / 2 < x2))
                    {
                        if (y1 > y2)
                            ChangeLine15(masLine, x1, y1, x2, y2);
                        else
                            ChangeLine15(masLine, x2, y2, x1, y1);
                    }
                    else ChangeLine14(masLine, x1, y1, x2, y2);
                }
                if (firstBlock.flagForEnteringThirdConnectionPoint && secondBlock.flagForEnteringFourthConnectionPoint)
                {
                    if (x1 > x2 && y2 > y1)
                        ChangeLine4(masLine, x1, y1, x2, y2);
                    else
                        ChangeLine16(masLine, x1, y1, x2, y2);
                }
                if (firstBlock.flagForEnteringFourthConnectionPoint && secondBlock.flagForEnteringThirdConnectionPoint)
                {
                    if (x1 < x2 && y2 < y1)
                        ChangeLine4(masLine, x2, y2, x1, y1);
                    else
                        ChangeLine16(masLine, x2, y2, x1, y1);
                }
                if (firstBlock.flagForEnteringFourthConnectionPoint && secondBlock.flagForEnteringFourthConnectionPoint)
                {
                    if ((y1 + DefaultPropertyForBlock.height / 2 <= y2 && y1 > y2) || (y1 <= y2 && y1 >= y2 - DefaultPropertyForBlock.height) || (y1 == y2))
                        ChangeLine19(masLine, x2, y2, x1, y1);
                    else if (x2 > x1) 
                        ChangeLine17(masLine, x2, y2, x1, y1);
                    else if (x2 < x1)
                        ChangeLine17(masLine, x1, y1, x2, y2);
                }
            }
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

        private void ButtonOpenMenuClick(object sender, RoutedEventArgs e)
        {
            buttonOpenMenu.Visibility = Visibility.Collapsed;
            buttonCloseMenu.Visibility = Visibility.Visible;
        }

        private void ButtonCloseMenuClick(object sender, RoutedEventArgs e)
        {
            buttonOpenMenu.Visibility = Visibility.Visible;
            buttonCloseMenu.Visibility = Visibility.Collapsed;
        }

        const string darkWhite = "#FFF9F9FB";
        const string darkBlack = "#FF040205";

        private void SelectionChangedListOfFontsComboBox(object sender, SelectionChangedEventArgs e)
        {
            FontFamily fontFamily = new(((ComboBoxItem)listOfFontsComboBox.SelectedItem).Content.ToString());
            DefaultPropertyForBlock.fontFamily = fontFamily;

            foreach (Block itemListOfBlock in listOfBlock)
                itemListOfBlock.SetFontFamily(fontFamily);

            foreach (Comment itemListComment in listComment)
                itemListComment.SetFontFamily(fontFamily);
        }

        private void SelectionChangedFontSizeComboBox(object sender, SelectionChangedEventArgs e)
        {
            int valueFontSize = Convert.ToInt32(fontSizeComboBox.SelectedItem);
            DefaultPropertyForBlock.fontSize = valueFontSize;

            foreach (Block itemListOfBlock in listOfBlock)
                itemListOfBlock.SetFontSize(valueFontSize);

            foreach (Comment itemListComment in listComment)
                itemListComment.SetFontSize(valueFontSize);
        }

        private void SelectionChangedBlockWidthComboBox(object sender, SelectionChangedEventArgs e)
        {
            int valueBlockWidth = Convert.ToInt32(blockWidthComboBox.SelectedItem);
            DefaultPropertyForBlock.width = (int)valueBlockWidth;

            foreach (Block itemListOfBlock in listOfBlock)
                itemListOfBlock.SetWidth(valueBlockWidth);

            foreach (Comment itemListComment in listComment)
                itemListComment.SetWidtht(valueBlockWidth);
        }

        private void SelectionChangedBlockHeightComboBox(object sender, SelectionChangedEventArgs e)
        {
            int valueBlokHeight = Convert.ToInt32(blockHeightComboBox.SelectedItem);
            DefaultPropertyForBlock.height = (int)valueBlokHeight;

            foreach (Block itemListOfBlock in listOfBlock)
                itemListOfBlock.SetHeight(valueBlokHeight);

            foreach (Comment itemListComment in listComment)
                itemListComment.SetHeight(valueBlokHeight);
        }

        readonly List<Line> listLineConnection = new();
        private void DrawConnectionLine1(double x1, double y1, double x2, double y2, Block firstBlock, Block secondBlock)
        {
            BrushConverter color = new();
           
            Line firstLine = new();
            double distanceBetweenTwoPoints = y2 - y1;
            firstLine.Y1 = y1;
            firstLine.X1 = x1;
            firstLine.Y2 = y2 - distanceBetweenTwoPoints / 2;
            firstLine.X2 = x1;
            firstLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(firstLine);
            destination.Children.Add(firstLine);

            Line secondLine = new();
            secondLine.Y1 = y1 + distanceBetweenTwoPoints / 2;
            secondLine.X1 = x1;
            secondLine.Y2 = y1 + distanceBetweenTwoPoints / 2;
            secondLine.X2 = x2;
            secondLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(secondLine);
            destination.Children.Add(secondLine);

            Line thirdLine = new();
            thirdLine.Y1 = y1 + distanceBetweenTwoPoints / 2;
            thirdLine.X1 = x2;
            thirdLine.Y2 = y2;
            thirdLine.X2 = x2;
            thirdLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(thirdLine);
            destination.Children.Add(thirdLine);

            MyLine myLine = new(firstBlock, secondBlock, firstLine, secondLine, thirdLine);
            firstBlock.SaveLine(myLine);
            secondBlock.SaveLine(myLine);
        }
        private void DrawConnectionLine2(double x1, double y1, double x2, double y2, Block firstBlock, Block secondBlock)
        {
            BrushConverter color = new();
            Line firstLine = new();
            firstLine.X1 = x1;
            firstLine.X2 = x1;
            firstLine.Y1 = y1 - valueOffsetOfLineFromTheBlockToSides;
            firstLine.Y2 = y1;
            firstLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(firstLine);
            destination.Children.Add(firstLine);

            Line secondLine = new();
            secondLine.X2 = x1;
            secondLine.Y1 = y1 - valueOffsetOfLineFromTheBlockToSides;
            secondLine.Y2 = y1 - valueOffsetOfLineFromTheBlockToSides;
            secondLine.X1 = x1 + DefaultPropertyForBlock.width / 2 + valueOffsetOfLineFromTheBlockToSides;
            secondLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(secondLine);
            destination.Children.Add(secondLine);

            Line thirdLine = new();
            thirdLine.Y1 = y1 - valueOffsetOfLineFromTheBlockToSides;
            thirdLine.X1 = x1 + DefaultPropertyForBlock.width / 2 + valueOffsetOfLineFromTheBlockToSides;
            thirdLine.Y2 = y2 + valueOffsetOfLineFromTheBlockToSides;
            thirdLine.X2 = x1 + DefaultPropertyForBlock.width / 2 + valueOffsetOfLineFromTheBlockToSides;
            thirdLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(thirdLine);
            destination.Children.Add(thirdLine);

            Line fourthLine = new();
            fourthLine.X1 = x2;
            fourthLine.Y1 = y2 + valueOffsetOfLineFromTheBlockToSides;
            fourthLine.X2 = x1 + DefaultPropertyForBlock.width / 2 + valueOffsetOfLineFromTheBlockToSides;
            fourthLine.Y2 = y2 + valueOffsetOfLineFromTheBlockToSides;
            fourthLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(fourthLine);
            destination.Children.Add(fourthLine);

            Line fifthLine = new();
            fifthLine.X2 = x2;
            fifthLine.Y1 = y2;
            fifthLine.X1 = x2;
            fifthLine.Y2 = y2 + valueOffsetOfLineFromTheBlockToSides;
            fifthLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(fifthLine);
            destination.Children.Add(fifthLine);

            MyLine myLine = new(firstBlock, secondBlock, firstLine, secondLine, thirdLine, fourthLine, fifthLine);
            firstBlock.SaveLine(myLine);
            secondBlock.SaveLine(myLine);
        }
        private void DrawConnectionLine3(double x1, double y1, double x2, double y2, Block firstBlock, Block secondBlock)
        {
            BrushConverter color = new();
            Line firstLine = new();
            firstLine.X1 = x1;
            firstLine.Y1 = y1;
            firstLine.X2 = x2;
            firstLine.Y2 = y2;
            firstLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(firstLine);
            destination.Children.Add(firstLine);
            MyLine myLine = new(firstBlock, secondBlock, firstLine);
            firstBlock.SaveLine(myLine);
            secondBlock.SaveLine(myLine);
        }
        private void DrawConnectionLine4(double x1, double y1, double x2, double y2, Block firstBlock, Block secondBlock)
        {
            double distanceBetweenTwoPoints = y2 - y1;

            BrushConverter color = new();
            Line firstLine = new();
            firstLine.X1 = x2;
            firstLine.Y1 = y2;
            firstLine.X2 = x2 + valueOffsetOfLineFromTheBlockToSides;
            firstLine.Y2 = y2;
            firstLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(firstLine);
            destination.Children.Add(firstLine);
            
            Line secondLine = new();
            secondLine.X1 = x2 + valueOffsetOfLineFromTheBlockToSides;
            secondLine.Y1 = y2;
            secondLine.X2 = x2 + valueOffsetOfLineFromTheBlockToSides;
            secondLine.Y2 = y2 - distanceBetweenTwoPoints - valueOffsetOfLineFromTheBlockToSides;
            secondLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(secondLine);
            destination.Children.Add(secondLine);

            Line thirdLine = new();
            thirdLine.X1 = x1;
            thirdLine.Y1 = y1 - valueOffsetOfLineFromTheBlockToSides;
            thirdLine.X2 = x2 + valueOffsetOfLineFromTheBlockToSides;
            thirdLine.Y2 = y2 - distanceBetweenTwoPoints - valueOffsetOfLineFromTheBlockToSides;
            thirdLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(thirdLine);
            destination.Children.Add(thirdLine);

            Line fourthLine = new();
            fourthLine.X1 = x1;
            fourthLine.Y1 = y1;
            fourthLine.X2 = x1;
            fourthLine.Y2 = y1 - valueOffsetOfLineFromTheBlockToSides;
            fourthLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(fourthLine);
            destination.Children.Add(fourthLine);

            MyLine myLine = new(firstBlock, secondBlock, firstLine, secondLine, thirdLine, fourthLine);
            firstBlock.SaveLine(myLine);
            secondBlock.SaveLine(myLine);
        }
        private void DrawConnectionLine5(double x1, double y1, double x2, double y2, Block firstBlock, Block secondBlock)
        {
            BrushConverter color = new();
            Line firstLine = new();
            firstLine.X1 = x2;
            firstLine.Y1 = y2;
            firstLine.X2 = x1;
            firstLine.Y2 = y2;
            firstLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(firstLine);
            destination.Children.Add(firstLine);

            Line secondLine = new();
            secondLine.X1 = x1;
            secondLine.Y1 = y2;
            secondLine.X2 = x1;
            secondLine.Y2 = y1;
            secondLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(secondLine);
            destination.Children.Add(secondLine);

            MyLine myLine = new(firstBlock, secondBlock, firstLine, secondLine);
            firstBlock.SaveLine(myLine);
            secondBlock.SaveLine(myLine);
        }
        private void DrawConnectionLine6(double x1, double y1, double x2, double y2, Block firstBlock, Block secondBlock)
        {
            double distanceBetweenTwoPoints = x1 - x2;
            BrushConverter color = new();
            Line firstLine = new();
            firstLine.X1 = x1;
            firstLine.Y1 = y1;
            firstLine.X2 = x1;
            firstLine.Y2 = y1 - valueOffsetOfLineFromTheBlockToSides;
            firstLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(firstLine);
            destination.Children.Add(firstLine);

            Line secondLine = new();
            secondLine.X1 = x1;
            secondLine.Y1 = y1 - valueOffsetOfLineFromTheBlockToSides;
            secondLine.X2 = x1 - distanceBetweenTwoPoints + valueOffsetOfLineFromTheBlockToSides;
            secondLine.Y2 = y1 - valueOffsetOfLineFromTheBlockToSides;
            secondLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(secondLine);
            destination.Children.Add(secondLine);

            Line thirdLine = new();
            thirdLine.X1 = x2;
            thirdLine.Y1 = y2;
            thirdLine.X2 = x2 + valueOffsetOfLineFromTheBlockToSides;
            thirdLine.Y2 = y2;
            thirdLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(thirdLine);
            destination.Children.Add(thirdLine);

            Line fourthLine = new();
            fourthLine.X1 = x2 + valueOffsetOfLineFromTheBlockToSides;
            fourthLine.Y1 = y2;
            fourthLine.X2 = x2 + valueOffsetOfLineFromTheBlockToSides;
            fourthLine.Y2 = y1 - valueOffsetOfLineFromTheBlockToSides;
            fourthLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(fourthLine);
            destination.Children.Add(fourthLine);

            MyLine myLine = new(firstBlock, secondBlock, firstLine, secondLine, thirdLine, fourthLine);
            firstBlock.SaveLine(myLine);
            secondBlock.SaveLine(myLine);
        }
        private void DrawConnectionLine7(double x1, double y1, double x2, double y2, Block firstBlock, Block secondBlock)
        {
            double distanceBetweenTwoPoints = y1 - y2;
            BrushConverter color = new();
            Line firstLine = new();
            firstLine.X1 = x1;
            firstLine.Y1 = y1;
            firstLine.X2 = x1;
            firstLine.Y2 = y1 - valueOffsetOfLineFromTheBlockToSides;
            firstLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(firstLine);
            destination.Children.Add(firstLine);

            Line secondLine = new();
            secondLine.X1 = x2;
            secondLine.Y1 = y2 - valueOffsetOfLineFromTheBlockToSides;
            secondLine.X2 = x2 + DefaultPropertyForBlock.width / 2 + valueOffsetOfLineFromTheBlockToSides;
            secondLine.Y2 = y2 - valueOffsetOfLineFromTheBlockToSides;
            secondLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(secondLine);
            destination.Children.Add(secondLine);

            Line thirdLine = new();
            thirdLine.X1 = x2 + DefaultPropertyForBlock.width / 2 + valueOffsetOfLineFromTheBlockToSides;
            thirdLine.Y1 = y2 - valueOffsetOfLineFromTheBlockToSides;
            thirdLine.X2 = x2 + DefaultPropertyForBlock.width / 2 + valueOffsetOfLineFromTheBlockToSides;
            thirdLine.Y2 = y2 - valueOffsetOfLineFromTheBlockToSides + distanceBetweenTwoPoints;
            thirdLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(thirdLine);
            destination.Children.Add(thirdLine);

            Line fourthLine = new();
            fourthLine.X1 = x2 + DefaultPropertyForBlock.width / 2 + valueOffsetOfLineFromTheBlockToSides;
            fourthLine.Y1 = y2 - valueOffsetOfLineFromTheBlockToSides + distanceBetweenTwoPoints;
            fourthLine.X2 = x1;
            fourthLine.Y2 = y1 - valueOffsetOfLineFromTheBlockToSides;
            fourthLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(fourthLine);
            destination.Children.Add(fourthLine);

            Line fifthLine = new();
            fifthLine.X2 = x2;
            fifthLine.Y1 = y2;
            fifthLine.X1 = x2;
            fifthLine.Y2 = y2 - valueOffsetOfLineFromTheBlockToSides;
            fifthLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(fifthLine);
            destination.Children.Add(fifthLine);

            MyLine myLine = new(firstBlock, secondBlock, firstLine, secondLine, thirdLine, fourthLine, fifthLine);
            firstBlock.SaveLine(myLine);
            secondBlock.SaveLine(myLine);

        }
        private void DrawConnectionLine8(double x1, double y1, double x2, double y2, Block firstBlock, Block secondBlock)
        {
            BrushConverter color = new();
            Line firstLine = new();
            firstLine.X1 = x2;
            firstLine.Y1 = y2;
            firstLine.X2 = x2;
            firstLine.Y2 = y2 - valueOffsetOfLineFromTheBlockToSides;
            firstLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(firstLine);
            destination.Children.Add(firstLine);

            Line secondLine = new();
            secondLine.X1 = x2;
            secondLine.Y1 = y2 - valueOffsetOfLineFromTheBlockToSides;
            secondLine.X2 = x1;
            secondLine.Y2 = y2 - valueOffsetOfLineFromTheBlockToSides;
            secondLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(secondLine);
            destination.Children.Add(secondLine);

            Line thirdLine = new();
            thirdLine.X1 = x1;
            thirdLine.Y1 = y2 - valueOffsetOfLineFromTheBlockToSides;
            thirdLine.X2 = x1;
            thirdLine.Y2 = y1;
            thirdLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(thirdLine);
            destination.Children.Add(thirdLine);

            MyLine myLine = new(firstBlock, secondBlock, firstLine, secondLine, thirdLine);
            firstBlock.SaveLine(myLine);
            secondBlock.SaveLine(myLine);
        }
        private void DrawConnectionLine9(double x1, double y1, double x2, double y2, Block firstBlock, Block secondBlock)
        {
            double distanceBetweenTwoPoints = y2 - y1;

            BrushConverter color = new();
            Line firstLine = new();
            firstLine.X1 = x2;
            firstLine.Y1 = y2;
            firstLine.X2 = x2 - valueOffsetOfLineFromTheBlockToSides;
            firstLine.Y2 = y2;
            firstLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(firstLine);
            destination.Children.Add(firstLine);

            Line secondLine = new();
            secondLine.X1 = x2 - valueOffsetOfLineFromTheBlockToSides;
            secondLine.Y1 = y2;
            secondLine.X2 = x2 - valueOffsetOfLineFromTheBlockToSides;
            secondLine.Y2 = y2 - distanceBetweenTwoPoints - valueOffsetOfLineFromTheBlockToSides;
            secondLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(secondLine);
            destination.Children.Add(secondLine);

            Line thirdLine = new();
            thirdLine.X1 = x1;
            thirdLine.Y1 = y1 - valueOffsetOfLineFromTheBlockToSides;
            thirdLine.X2 = x2 - valueOffsetOfLineFromTheBlockToSides;
            thirdLine.Y2 = y2 - distanceBetweenTwoPoints - valueOffsetOfLineFromTheBlockToSides;
            thirdLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(thirdLine);
            destination.Children.Add(thirdLine);

            Line fourthLine = new();
            fourthLine.X1 = x1;
            fourthLine.Y1 = y1;
            fourthLine.X2 = x1;
            fourthLine.Y2 = y1 - valueOffsetOfLineFromTheBlockToSides;
            fourthLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(fourthLine);
            destination.Children.Add(fourthLine);

            MyLine myLine = new(firstBlock, secondBlock, firstLine, secondLine, thirdLine, fourthLine);
            firstBlock.SaveLine(myLine);
            secondBlock.SaveLine(myLine);
        }
        private void DrawConnectionLine10(double x1, double y1, double x2, double y2, Block firstBlock, Block secondBlock)
        {
            BrushConverter color = new();
            Line firstLine = new();
            double distanceBetweenTwoPoints = x2 - x1;
            firstLine.X1 = x1;
            firstLine.Y1 = y1;
            firstLine.X2 = x1 - valueOffsetOfLineFromTheBlockToSides;
            firstLine.Y2 = y1;
            firstLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(firstLine);
            destination.Children.Add(firstLine);

            Line secondLine = new();
            secondLine.X1 = x1 - valueOffsetOfLineFromTheBlockToSides;
            secondLine.Y1 = y1;
            secondLine.X2 = x2 - distanceBetweenTwoPoints - valueOffsetOfLineFromTheBlockToSides;
            secondLine.Y2 = y2;
            secondLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(secondLine);
            destination.Children.Add(secondLine);

            Line thirdLine = new();
            thirdLine.X1 = x2;
            thirdLine.Y1 = y2;
            thirdLine.X2 = x2  - distanceBetweenTwoPoints - valueOffsetOfLineFromTheBlockToSides;
            thirdLine.Y2 = y2;
            thirdLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(thirdLine);
            destination.Children.Add(thirdLine);

            MyLine myLine = new(firstBlock, secondBlock, firstLine, secondLine, thirdLine);
            firstBlock.SaveLine(myLine);
            secondBlock.SaveLine(myLine);
        }
        private void DrawConnectionLine11(double x1, double y1, double x2, double y2, Block firstBlock, Block secondBlock)
        {
            BrushConverter color = new();
            Line firstLine = new();
            firstLine.X1 = x1;
            firstLine.Y1 = y1;
            firstLine.X2 = x1 - valueOffsetOfLineFromTheBlockToSides;
            firstLine.Y2 = y1;
            firstLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(firstLine);
            destination.Children.Add(firstLine);

            Line secondLine = new();
            secondLine.X1 = x1 - valueOffsetOfLineFromTheBlockToSides;
            secondLine.Y1 = y1;
            secondLine.X2 = x1 - valueOffsetOfLineFromTheBlockToSides;
            secondLine.Y2 = y2 + DefaultPropertyForBlock.height / 2 + valueOffsetOfLineFromTheBlockToSides;
            secondLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(secondLine);
            destination.Children.Add(secondLine);

            Line thirdLine = new();
            thirdLine.X1 = x1 - valueOffsetOfLineFromTheBlockToSides;
            thirdLine.Y1 = y2 + DefaultPropertyForBlock.height / 2 + valueOffsetOfLineFromTheBlockToSides;
            thirdLine.X2 = x2 - valueOffsetOfLineFromTheBlockToSides;
            thirdLine.Y2 = y2 + DefaultPropertyForBlock.height / 2 + valueOffsetOfLineFromTheBlockToSides;
            thirdLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(thirdLine);
            destination.Children.Add(thirdLine);

            Line fourthLine = new();
            fourthLine.X1 = x2 - valueOffsetOfLineFromTheBlockToSides;
            fourthLine.Y1 = y2 + DefaultPropertyForBlock.height / 2 + valueOffsetOfLineFromTheBlockToSides;
            fourthLine.X2 = x2 - valueOffsetOfLineFromTheBlockToSides;
            fourthLine.Y2 = y2;
            fourthLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(fourthLine);
            destination.Children.Add(fourthLine);

            Line fifthLine = new();
            fifthLine.X2 = x2;
            fifthLine.Y1 = y2;
            fifthLine.X1 = x2 - valueOffsetOfLineFromTheBlockToSides;
            fifthLine.Y2 = y2;
            fifthLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(fifthLine);
            destination.Children.Add(fifthLine);

            MyLine myLine = new(firstBlock, secondBlock, firstLine, secondLine, thirdLine, fourthLine, fifthLine);
            firstBlock.SaveLine(myLine);
            secondBlock.SaveLine(myLine);
        }
        private void DrawConnectionLine12(double x1, double y1, double x2, double y2, Block firstBlock, Block secondBlock)
        {
            BrushConverter color = new();
            Line firstLine = new();
            firstLine.X1 = x2;
            firstLine.Y1 = y2;
            firstLine.X2 = x2 - valueOffsetOfLineFromTheBlockToSides;
            firstLine.Y2 = y2;
            firstLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(firstLine);
            destination.Children.Add(firstLine);

            Line secondLine = new();
            secondLine.X1 = x2 - valueOffsetOfLineFromTheBlockToSides;
            secondLine.Y1 = y2;
            secondLine.X2 = x2 - valueOffsetOfLineFromTheBlockToSides;
            secondLine.Y2 = y1 + valueOffsetOfLineFromTheBlockToSides;
            secondLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(secondLine);
            destination.Children.Add(secondLine);

            Line thirdLine = new();
            thirdLine.X1 = x2 - valueOffsetOfLineFromTheBlockToSides;
            thirdLine.Y1 = y1 + valueOffsetOfLineFromTheBlockToSides;
            thirdLine.X2 = x1;
            thirdLine.Y2 = y1 + valueOffsetOfLineFromTheBlockToSides;
            thirdLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(thirdLine);
            destination.Children.Add(thirdLine);

            Line fourthLine = new();
            fourthLine.X1 = x1;
            fourthLine.Y1 = y1;
            fourthLine.X2 = x1;
            fourthLine.Y2 = y1 + valueOffsetOfLineFromTheBlockToSides;
            fourthLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(fourthLine);
            destination.Children.Add(fourthLine);

            MyLine myLine = new(firstBlock, secondBlock, firstLine, secondLine, thirdLine, fourthLine);
            firstBlock.SaveLine(myLine);
            secondBlock.SaveLine(myLine);
        }

        private void DrawConnectionLine13(double x1, double y1, double x2, double y2, Block firstBlock, Block secondBlock)
        {
            BrushConverter color = new();
            Line firstLine = new();
            firstLine.X1 = x2;
            firstLine.Y1 = y2;
            firstLine.X2 = x2 - valueOffsetOfLineFromTheBlockToSides;
            firstLine.Y2 = y2;
            firstLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(firstLine);
            destination.Children.Add(firstLine);

            Line secondLine = new();
            secondLine.X1 = x2 - valueOffsetOfLineFromTheBlockToSides;
            secondLine.Y1 = y2;
            secondLine.X2 = x2 - valueOffsetOfLineFromTheBlockToSides;
            secondLine.Y2 = y2 + DefaultPropertyForBlock.height / 2 + valueOffsetOfLineFromTheBlockToSides;
            secondLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(secondLine);
            destination.Children.Add(secondLine);

            Line thirdLine = new();
            thirdLine.X1 = x2 - valueOffsetOfLineFromTheBlockToSides;
            thirdLine.Y1 = y2 + DefaultPropertyForBlock.height / 2 + valueOffsetOfLineFromTheBlockToSides;
            thirdLine.X2 = x1 + valueOffsetOfLineFromTheBlockToSides;
            thirdLine.Y2 = y2 + DefaultPropertyForBlock.height / 2 + valueOffsetOfLineFromTheBlockToSides;
            thirdLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(thirdLine);
            destination.Children.Add(thirdLine);

            Line fourthLine = new();
            fourthLine.X1 = x1 + valueOffsetOfLineFromTheBlockToSides;
            fourthLine.Y1 = y1;
            fourthLine.X2 = x1 + valueOffsetOfLineFromTheBlockToSides;
            fourthLine.Y2 = y2 + DefaultPropertyForBlock.height / 2 + valueOffsetOfLineFromTheBlockToSides;
            fourthLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(fourthLine);
            destination.Children.Add(fourthLine);

            Line fifthLine = new();
            fifthLine.X2 = x1;
            fifthLine.Y1 = y1;
            fifthLine.X1 = x1 + valueOffsetOfLineFromTheBlockToSides;
            fifthLine.Y2 = y1;
            fifthLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(fifthLine);
            destination.Children.Add(fifthLine);

            MyLine myLine = new(firstBlock, secondBlock, firstLine, secondLine, thirdLine, fourthLine, fifthLine);
            firstBlock.SaveLine(myLine);
            secondBlock.SaveLine(myLine);
        }
        private void DrawConnectionLine14(double x1, double y1, double x2, double y2, Block firstBlock, Block secondBlock)
        {
            double distanceBetweenTwoPoints = x1 - x2;
            BrushConverter color = new();
            Line firstLine = new();
            firstLine.X1 = x1;
            firstLine.Y1 = y1;
            firstLine.X2 = x1 - distanceBetweenTwoPoints / 2;
            firstLine.Y2 = y1;
            firstLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(firstLine);
            destination.Children.Add(firstLine);

            Line secondLine = new();
            secondLine.X1 = x1 - distanceBetweenTwoPoints / 2;
            secondLine.Y1 = y1;
            secondLine.X2 = x2 + distanceBetweenTwoPoints / 2;
            secondLine.Y2 = y2;
            secondLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(secondLine);
            destination.Children.Add(secondLine);

            Line thirdLine = new();
            thirdLine.X1 = x2;
            thirdLine.Y1 = y2;
            thirdLine.X2 = x2 + distanceBetweenTwoPoints / 2;
            thirdLine.Y2 = y2;
            thirdLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(thirdLine);
            destination.Children.Add(thirdLine);

            MyLine myLine = new(firstBlock, secondBlock, firstLine, secondLine, thirdLine);
            firstBlock.SaveLine(myLine);
            secondBlock.SaveLine(myLine);
        }

        private void DrawConnectionLine15(double x1, double y1, double x2, double y2, Block firstBlock, Block secondBlock)
        {
            double distanceBetweenTwoPoints = y1 - y2;
            BrushConverter color = new();
            Line firstLine = new();
            firstLine.X1 = x1;
            firstLine.Y1 = y1;
            firstLine.X2 = x1;
            firstLine.Y2 = y1 + valueOffsetOfLineFromTheBlockToSides;
            firstLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(firstLine);
            destination.Children.Add(firstLine);

            Line secondLine = new();
            secondLine.X1 = x2;
            secondLine.Y1 = y2 + valueOffsetOfLineFromTheBlockToSides;
            secondLine.X2 = x2 + DefaultPropertyForBlock.width / 2 + valueOffsetOfLineFromTheBlockToSides;
            secondLine.Y2 = y2 + valueOffsetOfLineFromTheBlockToSides;
            secondLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(secondLine);
            destination.Children.Add(secondLine);

            Line thirdLine = new();
            thirdLine.X1 = x2 + DefaultPropertyForBlock.width / 2 + valueOffsetOfLineFromTheBlockToSides;
            thirdLine.Y1 = y2 + valueOffsetOfLineFromTheBlockToSides;
            thirdLine.X2 = x2 + DefaultPropertyForBlock.width / 2 + valueOffsetOfLineFromTheBlockToSides;
            thirdLine.Y2 = y2 + valueOffsetOfLineFromTheBlockToSides + distanceBetweenTwoPoints;
            thirdLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(thirdLine);
            destination.Children.Add(thirdLine);

            Line fourthLine = new();
            fourthLine.X1 = x2 + DefaultPropertyForBlock.width / 2 + valueOffsetOfLineFromTheBlockToSides;
            fourthLine.Y1 = y2 + valueOffsetOfLineFromTheBlockToSides + distanceBetweenTwoPoints;
            fourthLine.X2 = x1;
            fourthLine.Y2 = y1 + valueOffsetOfLineFromTheBlockToSides;
            fourthLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(fourthLine);
            destination.Children.Add(fourthLine);

            Line fifthLine = new();
            fifthLine.X2 = x2;
            fifthLine.Y1 = y2;
            fifthLine.X1 = x2;
            fifthLine.Y2 = y2 + valueOffsetOfLineFromTheBlockToSides;
            fifthLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(fifthLine);
            destination.Children.Add(fifthLine);

            MyLine myLine = new(firstBlock, secondBlock, firstLine, secondLine, thirdLine, fourthLine, fifthLine);
            firstBlock.SaveLine(myLine);
            secondBlock.SaveLine(myLine);
        }

        private void DrawConnectionLine16(double x1, double y1, double x2, double y2, Block firstBlock, Block secondBlock)
        {
            BrushConverter color = new();
            Line firstLine = new();
            double distanceBetweenTwoPoints = y1 - y2;

            firstLine.X1 = x2;
            firstLine.Y1 = y2;
            firstLine.X2 = x2;
            firstLine.Y2 = y2 + distanceBetweenTwoPoints + valueOffsetOfLineFromTheBlockToSides;
            firstLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(firstLine);
            destination.Children.Add(firstLine);

            Line secondLine = new();
            secondLine.X1 = x2;
            secondLine.Y1 = y2 + distanceBetweenTwoPoints + valueOffsetOfLineFromTheBlockToSides;
            secondLine.X2 = x1;
            secondLine.Y2 = y1 + valueOffsetOfLineFromTheBlockToSides;
            secondLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(secondLine);
            destination.Children.Add(secondLine);

            Line thirdLine = new();
            thirdLine.X1 = x1;
            thirdLine.Y1 = y1;
            thirdLine.X2 = x1;
            thirdLine.Y2 = y1 + valueOffsetOfLineFromTheBlockToSides;
            thirdLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(thirdLine);
            destination.Children.Add(thirdLine);

            MyLine myLine = new(firstBlock, secondBlock, firstLine, secondLine, thirdLine);
            firstBlock.SaveLine(myLine);
            secondBlock.SaveLine(myLine);
        }

        private void DrawConnectionLine17(double x1, double y1, double x2, double y2, Block firstBlock, Block secondBlock)
        {
            BrushConverter color = new();
            Line firstLine = new();
            firstLine.X1 = x1;
            firstLine.Y1 = y1;
            firstLine.X2 = x1;
            firstLine.Y2 = y1 + valueOffsetOfLineFromTheBlockToSides;
            firstLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(firstLine);
            destination.Children.Add(firstLine);

            Line secondLine = new();
            secondLine.X1 = x2 + valueOffsetOfLineFromTheBlockToSides;
            secondLine.Y1 = y1 + valueOffsetOfLineFromTheBlockToSides;
            secondLine.X2 = x1;
            secondLine.Y2 = y1 + valueOffsetOfLineFromTheBlockToSides;
            secondLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(secondLine);
            destination.Children.Add(secondLine);

            Line thirdLine = new();
            thirdLine.X1 = x2 + valueOffsetOfLineFromTheBlockToSides;
            thirdLine.Y1 = y1 + valueOffsetOfLineFromTheBlockToSides;
            thirdLine.X2 = x2 + valueOffsetOfLineFromTheBlockToSides;
            thirdLine.Y2 = y2;
            thirdLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(thirdLine);
            destination.Children.Add(thirdLine);

            Line fourthLine = new();
            fourthLine.X1 = x2;
            fourthLine.Y1 = y2;
            fourthLine.X2 = x2 + valueOffsetOfLineFromTheBlockToSides;
            fourthLine.Y2 = y2;
            fourthLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(fourthLine);
            destination.Children.Add(fourthLine);

            MyLine myLine = new(firstBlock, secondBlock, firstLine, secondLine, thirdLine, fourthLine);
            firstBlock.SaveLine(myLine);
            secondBlock.SaveLine(myLine);
        }
        private void DrawConnectionLine18(double x1, double y1, double x2, double y2, Block firstBlock, Block secondBlock)
        {
            BrushConverter color = new();
            Line firstLine = new();
            double distanceBetweenTwoPoints = x2 - x1;
            firstLine.X1 = x1;
            firstLine.Y1 = y1;
            firstLine.X2 = x1 + valueOffsetOfLineFromTheBlockToSides;
            firstLine.Y2 = y1;
            firstLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(firstLine);
            destination.Children.Add(firstLine);

            Line secondLine = new();
            secondLine.X1 = x1 + valueOffsetOfLineFromTheBlockToSides;
            secondLine.Y1 = y1;
            secondLine.X2 = x2 - distanceBetweenTwoPoints + valueOffsetOfLineFromTheBlockToSides;
            secondLine.Y2 = y2;
            secondLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(secondLine);
            destination.Children.Add(secondLine);

            Line thirdLine = new();
            thirdLine.X1 = x2;
            thirdLine.Y1 = y2;
            thirdLine.X2 = x2 - distanceBetweenTwoPoints + valueOffsetOfLineFromTheBlockToSides;
            thirdLine.Y2 = y2;
            thirdLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(thirdLine);
            destination.Children.Add(thirdLine);

            MyLine myLine = new(firstBlock, secondBlock, firstLine, secondLine, thirdLine);
            firstBlock.SaveLine(myLine);
            secondBlock.SaveLine(myLine);
        }
        private void DrawConnectionLine19(double x1, double y1, double x2, double y2, Block firstBlock, Block secondBlock)
        {
            BrushConverter color = new();

            Line firstLine = new();
            firstLine.X1 = x2 + valueOffsetOfLineFromTheBlockToSides;
            firstLine.Y1 = y1;
            firstLine.X2 = x1;
            firstLine.Y2 = y1;
            firstLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(firstLine);
            destination.Children.Add(firstLine);

            Line secondLine = new();
            secondLine.X1 = x2 + valueOffsetOfLineFromTheBlockToSides;
            secondLine.Y1 = y2;
            secondLine.X2 = x2 + valueOffsetOfLineFromTheBlockToSides;
            secondLine.Y2 = y1;
            secondLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(secondLine);
            destination.Children.Add(secondLine);

            Line thirdLine = new();
            thirdLine.X1 = x2;
            thirdLine.Y1 = y2;
            thirdLine.X2 = x2 + valueOffsetOfLineFromTheBlockToSides;
            thirdLine.Y2 = y2;
            thirdLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(thirdLine);
            destination.Children.Add(thirdLine);

            MyLine myLine = new(firstBlock, secondBlock, firstLine, secondLine, thirdLine);
            firstBlock.SaveLine(myLine);
            secondBlock.SaveLine(myLine);
        }
        private void DrawConnectionLine20(double x1, double y1, double x2, double y2, Block firstBlock, Block secondBlock)
        {
            BrushConverter color = new();
            Line firstLine = new();
            firstLine.X1 = x1;
            firstLine.Y1 = y1;
            firstLine.X2 = x1 + valueOffsetOfLineFromTheBlockToSides;
            firstLine.Y2 = y1;
            firstLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(firstLine);
            destination.Children.Add(firstLine);

            Line secondLine = new();
            secondLine.X1 = x1 + valueOffsetOfLineFromTheBlockToSides;
            secondLine.Y1 = y1;
            secondLine.X2 = x1 + valueOffsetOfLineFromTheBlockToSides;
            secondLine.Y2 = y2 + DefaultPropertyForBlock.height / 2 + valueOffsetOfLineFromTheBlockToSides;
            secondLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(secondLine);
            destination.Children.Add(secondLine);

            Line thirdLine = new();
            thirdLine.X1 = x1 + valueOffsetOfLineFromTheBlockToSides;
            thirdLine.Y1 = y2 + DefaultPropertyForBlock.height / 2 + valueOffsetOfLineFromTheBlockToSides;
            thirdLine.X2 = x2 + valueOffsetOfLineFromTheBlockToSides;
            thirdLine.Y2 = y2 + DefaultPropertyForBlock.height / 2 + valueOffsetOfLineFromTheBlockToSides;
            thirdLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(thirdLine);
            destination.Children.Add(thirdLine);

            Line fourthLine = new();
            fourthLine.X1 = x2 + valueOffsetOfLineFromTheBlockToSides;
            fourthLine.Y1 = y2 + DefaultPropertyForBlock.height / 2 + valueOffsetOfLineFromTheBlockToSides;
            fourthLine.X2 = x2 + valueOffsetOfLineFromTheBlockToSides;
            fourthLine.Y2 = y2;
            fourthLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(fourthLine);
            destination.Children.Add(fourthLine);

            Line fifthLine = new();
            fifthLine.X2 = x2;
            fifthLine.Y1 = y2;
            fifthLine.X1 = x2 + valueOffsetOfLineFromTheBlockToSides;
            fifthLine.Y2 = y2;
            fifthLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(fifthLine);
            destination.Children.Add(fifthLine);

            MyLine myLine = new(firstBlock, secondBlock, firstLine, secondLine, thirdLine, fourthLine, fifthLine);
            firstBlock.SaveLine(myLine);
            secondBlock.SaveLine(myLine);
        }
        public void DrawConnectionLine(double x1, double y1, double x2, double y2, Block firstBlock, Block secondBlock)
        {
            if (StaticBlock.firstPointToConnect == "firstPointToConnect" && StaticBlock.secondPointToConnect == "fourthPointToConnect")
            {
                if (y2 < y1 && x1 <= x2)
                    DrawConnectionLine4(x1, y1, x2, y2, firstBlock, secondBlock);
                else if (y2 < y1 && x1 >= x2)
                    DrawConnectionLine5(x1, y1, x2, y2, firstBlock, secondBlock);
                else if (y1 < y2)
                    DrawConnectionLine6(x1, y1, x2, y2, firstBlock, secondBlock);
            }
            else if (StaticBlock.firstPointToConnect == "fourthPointToConnect" && StaticBlock.secondPointToConnect == "firstPointToConnect")
            {
                if (y2 > y1 && x1 >= x2)
                    DrawConnectionLine4(x2, y2, x1, y1, firstBlock, secondBlock);
                else if (y2 > y1 && x1 <= x2)
                    DrawConnectionLine5(x2, y2, x1, y1, firstBlock, secondBlock);
                else if (y1 > y2)
                    DrawConnectionLine6(x2, y2, x1, y1, firstBlock, secondBlock);
            }
            else if (StaticBlock.firstPointToConnect == "thirdPointToConnect" && StaticBlock.secondPointToConnect == "firstPointToConnect")
            {
                if (x1 != x2 && y2 > y1)
                    DrawConnectionLine1(x1, y1, x2, y2, firstBlock, secondBlock);
                else if ((x2 - x1) > DefaultPropertyForBlock.height)
                    DrawConnectionLine2(x2, y2, x1, y1, firstBlock, secondBlock);
                else if (x1 == x2)
                    DrawConnectionLine3(x1, y1, x2, y2, firstBlock, secondBlock);
            }
            else if (StaticBlock.firstPointToConnect == "firstPointToConnect" && StaticBlock.secondPointToConnect == "thirdPointToConnect")
            {
                if (x1 != x2 && y2 < y1)
                    DrawConnectionLine1(x1, y1, x2, y2, firstBlock, secondBlock);
                else if ((x2 - x1) < DefaultPropertyForBlock.height)
                    DrawConnectionLine2(x1, y1, x2, y2, firstBlock, secondBlock);
                else if (x1 == x2)
                    DrawConnectionLine3(x1, y1, x2, y2, firstBlock, secondBlock);
            }
            else if (StaticBlock.firstPointToConnect == "firstPointToConnect" && StaticBlock.secondPointToConnect == "firstPointToConnect")
            {
                if ((x2 + DefaultPropertyForBlock.width / 2 < x1) || (x1 + DefaultPropertyForBlock.width / 2 < x2))
                {
                    if (y1 > y2)
                        DrawConnectionLine8(x1, y1, x2, y2, firstBlock, secondBlock);
                    else
                        DrawConnectionLine8(x2, y2, x1, y1, firstBlock, secondBlock);
                }
                else DrawConnectionLine7(x1, y1, x2, y2, firstBlock, secondBlock);
            }
            else if (StaticBlock.firstPointToConnect == "firstPointToConnect" && StaticBlock.secondPointToConnect == "secondPointToConnect")
            {
                if (x1 <= x2)
                    DrawConnectionLine5(x1, y1, x2, y2, firstBlock, secondBlock);
                else if (y2 > y1)
                    DrawConnectionLine9(x1, y1, x2, y2, firstBlock, secondBlock);
            }
            else if (StaticBlock.firstPointToConnect == "secondPointToConnect" && StaticBlock.secondPointToConnect == "firstPointToConnect")
            {
                if (x1 >= x2)
                    DrawConnectionLine5(x2, y2, x1, y1, firstBlock, secondBlock);
                else if (y2 < y1)
                    DrawConnectionLine9(x2, y2, x1, y1, firstBlock, secondBlock);
                else if (x1 <= x2 && y2 > y1)
                    DrawConnectionLine9(x2, y2, x1, y1, firstBlock, secondBlock);
            }
            else if (StaticBlock.firstPointToConnect == "secondPointToConnect" && StaticBlock.secondPointToConnect == "secondPointToConnect")
            {
                if ((y2 + DefaultPropertyForBlock.height / 2 <= y1) || (y1 + DefaultPropertyForBlock.width / 2 >= y2))
                    DrawConnectionLine11(x2, y2, x1, y1, firstBlock, secondBlock);
                else if (x2 < x1)
                    DrawConnectionLine10(x2, y2, x1, y1, firstBlock, secondBlock);
                else if (x2 > x1)
                    DrawConnectionLine10(x1, y1, x2, y2, firstBlock, secondBlock);
            }
            else if (StaticBlock.firstPointToConnect == "secondPointToConnect" && StaticBlock.secondPointToConnect == "thirdPointToConnect")
            {
                if (x1 > x2 && y2 < y1)
                    DrawConnectionLine5(x2, y2, x1, y1, firstBlock, secondBlock);
                else
                    DrawConnectionLine12(x2, y2, x1, y1, firstBlock, secondBlock);
            }
            else if (StaticBlock.firstPointToConnect == "thirdPointToConnect" && StaticBlock.secondPointToConnect == "secondPointToConnect")
            {
                if (x1 < x2 && y2 > y1)
                    DrawConnectionLine5(x1, y1, x2, y2, firstBlock, secondBlock);
                else
                    DrawConnectionLine12(x1, y1, x2, y2, firstBlock, secondBlock);
            }
            else if (StaticBlock.firstPointToConnect == "secondPointToConnect" && StaticBlock.secondPointToConnect == "fourthPointToConnect")
            {
                if (x2 < x1)
                    DrawConnectionLine14(x2, y2, x1, y1, firstBlock, secondBlock);
                else
                    DrawConnectionLine13(x2, y2, x1, y1, firstBlock, secondBlock);
            }
            else if (StaticBlock.firstPointToConnect == "fourthPointToConnect" && StaticBlock.secondPointToConnect == "secondPointToConnect")
            {
                if (x2 > x1)
                    DrawConnectionLine14(x1, y1, x2, y2, firstBlock, secondBlock);
                else
                    DrawConnectionLine13(x1, y1, x2, y2, firstBlock, secondBlock);
            }
            else if (StaticBlock.firstPointToConnect == "thirdPointToConnect" && StaticBlock.secondPointToConnect == "thirdPointToConnect")
            {
                if ((x2 + DefaultPropertyForBlock.width / 2 < x1) || (x1 + DefaultPropertyForBlock.width / 2 < x2))
                {
                    if (y1 > y2)
                        DrawConnectionLine16(x1, y1, x2, y2, firstBlock, secondBlock);
                    else
                        DrawConnectionLine16(x2, y2, x1, y1, firstBlock, secondBlock);
                }
                else DrawConnectionLine15(x1, y1, x2, y2, firstBlock, secondBlock);
            }
            else if (StaticBlock.firstPointToConnect == "thirdPointToConnect" && StaticBlock.secondPointToConnect == "fourthPointToConnect")
            {
                if (x1 > x2 && y2 > y1)
                    DrawConnectionLine5(x1, y1, x2, y2, firstBlock, secondBlock);
                else
                    DrawConnectionLine17(x1, y1, x2, y2, firstBlock, secondBlock);
            }
            else if (StaticBlock.firstPointToConnect == "fourthPointToConnect" && StaticBlock.secondPointToConnect == "thirdPointToConnect")
            {
                if (x1 < x2 && y2 < y1)
                    DrawConnectionLine5(x2, y2, x1, y1, firstBlock, secondBlock);
                else
                    DrawConnectionLine17(x2, y2, x1, y1, firstBlock, secondBlock);
            }
            else if (StaticBlock.firstPointToConnect == "fourthPointToConnect" && StaticBlock.secondPointToConnect == "fourthPointToConnect")
            {
               if ((y1 + DefaultPropertyForBlock.height / 2 <= y2 && y1 > y2) || (y1 <= y2 && y1 >= y2 - DefaultPropertyForBlock.height) || (y1 == y2))
                    DrawConnectionLine20(x2, y2, x1, y1, firstBlock, secondBlock);
               else if (x2 > x1)
                    DrawConnectionLine18(x2, y2, x1, y1, firstBlock, secondBlock);
               else if (x2 < x1)
                    DrawConnectionLine18(x1, y1, x2, y2, firstBlock, secondBlock);
            }

            StaticBlock.firstPointToConnect = "";
            StaticBlock.secondPointToConnect = "";
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