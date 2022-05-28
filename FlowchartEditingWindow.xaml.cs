using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Windows;
using System.Text.Unicode;
using System.Windows.Input;
using System.Windows.Media;
using Flowchart_Editor.View;
using System.Windows.Shapes;
using Flowchart_Editor.Model;
using Flowchart_Editor.Models;
using System.Windows.Controls;
using System.Text.Encodings.Web;
using System.Collections.Generic;
using Flowchart_Editor.Models.Comment;
using Flowchart_Editor.Models.LineConnection;
using WinForms = System.Windows.Forms;

namespace Flowchart_Editor
{
    public partial class MainWindow : Window
    {
        const int minHeight = 760;
        const int minWidth = 1380;
        const int valueOffsetOfLineFromTheBlockToSides = 20;

        public MainWindow()
        {
            InitializeComponent();
            MinHeight = minHeight;
            MinWidth = minWidth;
            toggleButtonStyleTheme.Click += ThemeChange;
            ThemeChange();

            for (int i = 90; i <= 250; i += 10)
                blockWidthComboBox.Items.Add(i);

            for (int i = 60; i <= 250; i += 10)
                blockHeightComboBox.Items.Add(i);
        }
        public void RemoveBlock(UIElement? uIElement)
        {
            destination.Children.Remove(uIElement);
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
                    buttonOpenMenu.Foreground = darkWhiteBrush;
                    buttonCloseMenu.Foreground = darkWhiteBrush;
                    toggleButtonStyleTheme.Background = darkWhiteBrush;
                }
                else
                {
                    SetTheme();
                    buttonOpenMenu.Foreground = darkBlackBrush;
                    buttonCloseMenu.Foreground = darkBlackBrush;
                }
            }
        }

        private static void SetTheme()
        {
            Uri uri = new("WindowsTheme/theme.xaml", UriKind.Relative);
            ResourceDictionary? resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }

        readonly List<Block> listOfBlock = new();
        int keyBlock = 0;
        public void MouseMoveBlock(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                keyBlock++;
                Block instanceOfBlock = ((IBlockView)sender).GetBlock(this, keyBlock);
                listOfBlock.Add(instanceOfBlock);
                DataObject dataObjectInformationOfBlock = new(typeof(Block), instanceOfBlock);
                DragDrop.DoDragDrop(sender as DependencyObject, dataObjectInformationOfBlock, DragDropEffects.Copy);
            }
            e.Handled = true;
        }

        readonly List<Comment> listComment = new();
        private void DropDestination(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Block)))
            {
                Point position = e.GetPosition(destination);
                UIElement featuresOfBlock = ((Block)e.Data.GetData(typeof(Block))).GetUIElement();
                Canvas.SetLeft(featuresOfBlock, position.X);
                Canvas.SetTop(featuresOfBlock, position.Y);
            }
            else 
                e.Handled = true;
        }

        private void DragOverDestination(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Block)))
            {
                e.Effects = DragDropEffects.Copy;
                Point position = e.GetPosition(destination);
                Block dataInformationOfBlock = (Block)e.Data.GetData(typeof(Block));
                UIElement? uIElementOfBlock = dataInformationOfBlock.GetCanvas();
                if (uIElementOfBlock == null)
                {
                    uIElementOfBlock = ((Block)e.Data.GetData(typeof(Block))).GetUIElement();
                    destination.Children.Add(uIElementOfBlock);
                }
                else
                    uIElementOfBlock = ((Block)e.Data.GetData(typeof(Block))).GetUIElement();

                Canvas.SetLeft(uIElementOfBlock, position.X + 1);
                Canvas.SetTop(uIElementOfBlock, position.Y + 1);
            }
            else if (e.Data.GetDataPresent(typeof(BlockForMovements)))
            {
                e.Effects = DragDropEffects.Copy;
                Point position = e.GetPosition(destination);
                BlockForMovements resultTransferInformation = (BlockForMovements)e.Data.GetData(typeof(BlockForMovements));
                object transferInformation = resultTransferInformation.GetTransferInformationActionBlock();
                Canvas.SetLeft((UIElement)transferInformation, position.X + 1);
                Canvas.SetTop((UIElement)transferInformation, position.Y + 1);

                //int numberOfOccurrencesInBlock = resultTransferInformation.GetBlock().GetNumberOfOccurrencesInBlock();
                //Block block = resultTransferInformation.GetBlock();

                int numberOfOccurrencesInBlock = resultTransferInformation.GetNumberOfOccurrencesInBlock();
                if (numberOfOccurrencesInBlock > 0)
                {
                    ChangingLines changingLines = new(resultTransferInformation, numberOfOccurrencesInBlock);
                    changingLines.ChooseWayToChangeCoordinatesForLine(resultTransferInformation.mainBlock, 
                        resultTransferInformation.firstBlock, 
                        resultTransferInformation.secondBlock,
                        resultTransferInformation.thirdBlock, 
                        resultTransferInformation.fourthBlock,
                        resultTransferInformation);
                }


                //if (numberOfOccurrencesInBlock == 1)
                //    ChangeLine(block);
            }
            else
                e.Effects = DragDropEffects.None;
            e.Handled = true;
        }

        private void DragLeaveDestination(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Block)))
            {
                UIElement uIElementOfBlock = ((Block)e.Data.GetData(typeof(Block))).GetUIElement();
                destination.Children.Remove(uIElementOfBlock);
                Block dataInformationOfBlock = (Block)e.Data.GetData(typeof(Block));
                dataInformationOfBlock.Reset();
            }
            e.Handled = true;
        }

        public void ChangeLine1(Line[] masLine, double x1, double y1, double x2, double y2)
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
        public void ChangeLine2(Line[] masLine, double x1, double y1, double x2, double y2)
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
        public void ChangeLine3(Line[] masLine, double x1, double y1, double x2, double y2)
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
        public void ChangeLine4(Line[] masLine, double x1, double y1, double x2, double y2)
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
        public void ChangeLine5(Line[] masLine, double x1, double y1, double x2, double y2)
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
        public void ChangeLine6(Line[] masLine, double x1, double y1, double x2, double y2)
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
        public void ChangeLine7(Line[] masLine, double x1, double y1, double x2, double y2)
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
        public void ChangeLine8(Line[] masLine, double x1, double y1, double x2, double y2)
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
                    destination.Children.Remove(line);
                    destination.Children.Add(line);
                }
                if (i == 1)
                {
                    line.X1 = x2 - valueOffsetOfLineFromTheBlockToSides;
                    line.Y1 = y2;
                    line.X2 = x2 - valueOffsetOfLineFromTheBlockToSides;
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
                        line.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
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
                        line.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
                        destination.Children.Remove(line);
                        destination.Children.Add(line);
                    } 
                }
                i++;
            }
        }
        public void ChangeLine9(Line[] masLine, double x1, double y1, double x2, double y2)
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
        public void ChangeLine10(Line[] masLine, double x1, double y1, double x2, double y2)
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
        public void ChangeLine11(Line[] masLine, double x1, double y1, double x2, double y2)
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

        public void ChangeLine12(Line[] masLine, double x1, double y1, double x2, double y2)
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
        public void ChangeLine13(Line[] masLine, double x1, double y1, double x2, double y2)
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

        public void ChangeLine14(Line[] masLine, double x1, double y1, double x2, double y2)
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
        public void ChangeLine15(Line[] masLine, double x1, double y1, double x2, double y2)
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

        public void ChangeLine16(Line[] masLine, double x1, double y1, double x2, double y2)
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
        public void ChangeLine17(Line[] masLine, double x1, double y1, double x2, double y2)
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

        public void ChangeLine19(Line[] masLine, double x1, double y1, double x2, double y2)
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

        //private void ChangeLine(Block firstBlock)
        //{
        //    firstBlock = firstBlock.GetMyLine().GetFirstBlock();
        //    Block secondBlock = firstBlock.GetMyLine().GetSecondBlock();

        //    double x1 = Canvas.GetLeft((Ellipse)firstBlock.GetFirstSender()) + Canvas.GetLeft(firstBlock.GetCanvas()) + 3;
        //    double y1 = Canvas.GetTop((Ellipse)firstBlock.GetFirstSender()) + Canvas.GetTop(firstBlock.GetCanvas()) + 3;

        //    double x2 = Canvas.GetLeft((Ellipse)secondBlock.GetFirstSender()) + Canvas.GetLeft(secondBlock.GetCanvas()) + 3;
        //    double y2 = Canvas.GetTop((Ellipse)secondBlock.GetFirstSender()) + Canvas.GetTop(secondBlock.GetCanvas()) + 3;

        //    Line[] masLine;
        //    if (firstBlock.flag != null)
        //    {
        //        bool flagFirstBlock = (bool)firstBlock.flag;

        //        if (flagFirstBlock)
        //            masLine = firstBlock.GetMyLine().GetFirtLine();
        //        else
        //            masLine = secondBlock.GetMyLine().GetFirtLine();

        //        if (firstBlock.flagForEnteringFirstConnectionPoint && secondBlock.flagForEnteringThirdConnectionPoint)
        //        {
        //            if (x1 != x2 && y1 > y2)
        //                ChangeLine1(masLine, x2, y2, x1, y1);
        //            else if (x1 != x2 && y1 < y2)
        //                ChangeLine2(masLine, x1, y1, x2, y2);
        //        }
        //        if (firstBlock.flagForEnteringThirdConnectionPoint && secondBlock.flagForEnteringFirstConnectionPoint)
        //        {
        //            if (x1 != x2 && y1 < y2)
        //                ChangeLine1(masLine, x1, y1, x2, y2);
        //            else if (x1 != x2 && y1 > y2)
        //                ChangeLine2(masLine, x2, y2, x1, y1);
        //        }
        //        if (firstBlock.flagForEnteringFirstConnectionPoint && secondBlock.flagForEnteringFourthConnectionPoint)
        //        {
        //            if (y2 < y1 && x1 - valueOffsetOfLineFromTheBlockToSides <= x2)
        //                ChangeLine3(masLine, x1, y1, x2, y2);
        //            else if (y2 < y1 && x1 >= x2)
        //                ChangeLine4(masLine, x1, y1, x2, y2);
        //            else if (y2 > y1 - valueOffsetOfLineFromTheBlockToSides)
        //                ChangeLine5(masLine, x1, y1, x2, y2);
        //        }
        //        if (firstBlock.flagForEnteringFourthConnectionPoint && secondBlock.flagForEnteringFirstConnectionPoint)
        //        {
        //            if (y2 > y1 && x1 >= x2 - valueOffsetOfLineFromTheBlockToSides)
        //                ChangeLine3(masLine, x2, y2, x1, y1);
        //            else if (y2 > y1 && x1 <= x2)
        //                ChangeLine4(masLine, x2, y2, x1, y1);
        //            else if (y2 < y1 - valueOffsetOfLineFromTheBlockToSides)
        //                ChangeLine5(masLine, x2, y2, x1, y1);
        //        }
        //        if (firstBlock.flagForEnteringFirstConnectionPoint && secondBlock.flagForEnteringFirstConnectionPoint)
        //        {
        //            if ((x2 + DefaultPropertyForBlock.width / 2 < x1) || (x1 + DefaultPropertyForBlock.width / 2 < x2))
        //            {
        //                if (y1 > y2)
        //                    ChangeLine7(masLine, x1, y1, x2, y2);
        //                else
        //                    ChangeLine7(masLine, x2, y2, x1, y1);
        //            }
        //            else ChangeLine6(masLine, x1, y1, x2, y2);
        //        }
        //        if (firstBlock.flagForEnteringFirstConnectionPoint && secondBlock.flagForEnteringSecondConnectionPoint)
        //        {
        //            if (x1 <= x2 && y1 > y2)
        //                ChangeLine4(masLine, x1, y1, x2, y2);
        //            else
        //                ChangeLine8(masLine, x1, y1, x2, y2);
        //        }
        //        if (firstBlock.flagForEnteringSecondConnectionPoint && secondBlock.flagForEnteringFirstConnectionPoint)
        //        {
        //            if (x1 >= x2 && y1 < y2)
        //                ChangeLine4(masLine, x2, y2, x1, y1);
        //            else
        //                ChangeLine8(masLine, x2, y2, x1, y1);
        //        }
        //        if (firstBlock.flagForEnteringSecondConnectionPoint && secondBlock.flagForEnteringSecondConnectionPoint)
        //        {
        //            if ((y1 + DefaultPropertyForBlock.height / 2 <= y2 && y1 > y2) || (y1 <= y2 && y1 >= y2 - DefaultPropertyForBlock.height) || (y1 == y2))
        //                ChangeLine10(masLine, x2, y2, x1, y1);
        //            else if (x2 < x1)
        //                ChangeLine9(masLine, x2, y2, x1, y1);
        //            else if (x2 > x1)
        //                ChangeLine9(masLine, x1, y1, x2, y2);
        //        }
        //        if (firstBlock.flagForEnteringSecondConnectionPoint && secondBlock.flagForEnteringThirdConnectionPoint)
        //        {
        //            if (x1 > x2 && y2 < y1)
        //                ChangeLine4(masLine, x2, y2, x1, y1);
        //            else
        //                ChangeLine11(masLine, x2, y2, x1, y1);
        //        }
        //        if (firstBlock.flagForEnteringThirdConnectionPoint && secondBlock.flagForEnteringSecondConnectionPoint)
        //        {
        //            if (x1 < x2 && y2 > y1)
        //                ChangeLine4(masLine, x1, y1, x2, y2);
        //            else
        //                ChangeLine11(masLine, x1, y1, x2, y2);
        //        }
        //        if (firstBlock.flagForEnteringSecondConnectionPoint && secondBlock.flagForEnteringFourthConnectionPoint)
        //        {
        //            if (x2 < x1)
        //                ChangeLine13(masLine, x2, y2, x1, y1);
        //            else
        //                ChangeLine12(masLine, x2, y2, x1, y1);
        //        }
        //        if (firstBlock.flagForEnteringFourthConnectionPoint && secondBlock.flagForEnteringSecondConnectionPoint)
        //        {
        //            if (x2 > x1)
        //                ChangeLine13(masLine, x2, y2, x1, y1);
        //            else
        //                ChangeLine12(masLine, x1, y1, x2, y2);
        //        }
        //        if (firstBlock.flagForEnteringThirdConnectionPoint && secondBlock.flagForEnteringThirdConnectionPoint)
        //        {
        //            if ((x2 + DefaultPropertyForBlock.width / 2 < x1) || (x1 + DefaultPropertyForBlock.width / 2 < x2))
        //            {
        //                if (y1 > y2)
        //                    ChangeLine15(masLine, x1, y1, x2, y2);
        //                else
        //                    ChangeLine15(masLine, x2, y2, x1, y1);
        //            }
        //            else ChangeLine14(masLine, x1, y1, x2, y2);
        //        }
        //        if (firstBlock.flagForEnteringThirdConnectionPoint && secondBlock.flagForEnteringFourthConnectionPoint)
        //        {
        //            if (x1 > x2 && y2 > y1)
        //                ChangeLine4(masLine, x1, y1, x2, y2);
        //            else
        //                ChangeLine16(masLine, x1, y1, x2, y2);
        //        }
        //        if (firstBlock.flagForEnteringFourthConnectionPoint && secondBlock.flagForEnteringThirdConnectionPoint)
        //        {
        //            if (x1 < x2 && y2 < y1)
        //                ChangeLine4(masLine, x2, y2, x1, y1);
        //            else
        //                ChangeLine16(masLine, x2, y2, x1, y1);
        //        }
        //        if (firstBlock.flagForEnteringFourthConnectionPoint && secondBlock.flagForEnteringFourthConnectionPoint)
        //        {
        //            if ((y1 + DefaultPropertyForBlock.height / 2 <= y2 && y1 > y2) || (y1 <= y2 && y1 >= y2 - DefaultPropertyForBlock.height) || (y1 == y2))
        //                ChangeLine19(masLine, x2, y2, x1, y1);
        //            else if (x2 > x1) 
        //                ChangeLine17(masLine, x2, y2, x1, y1);
        //            else if (x2 < x1)
        //                ChangeLine17(masLine, x1, y1, x2, y2);
        //        }
        //    }
        //}

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
        public Line[] DrawConnectionLine1(double x1, double y1, double x2, double y2)
        {
            BrushConverter color = new();
            Line[] lines = new Line[5];

            Line firstLine = new();
            double distanceBetweenTwoPoints = y2 - y1;
            firstLine.Y1 = y1;
            firstLine.X1 = x1;
            firstLine.Y2 = y2 - distanceBetweenTwoPoints / 2;
            firstLine.X2 = x1;
            firstLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(firstLine);
            destination.Children.Add(firstLine);
            lines[0] = firstLine;

            Line secondLine = new();
            secondLine.Y1 = y1 + distanceBetweenTwoPoints / 2;
            secondLine.X1 = x1;
            secondLine.Y2 = y1 + distanceBetweenTwoPoints / 2;
            secondLine.X2 = x2;
            secondLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(secondLine);
            destination.Children.Add(secondLine);
            lines[1] = secondLine;

            Line thirdLine = new();
            thirdLine.Y1 = y1 + distanceBetweenTwoPoints / 2;
            thirdLine.X1 = x2;
            thirdLine.Y2 = y2;
            thirdLine.X2 = x2;
            thirdLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(thirdLine);
            destination.Children.Add(thirdLine);
            lines[2] = thirdLine;

            return lines;
        }
        public Line[] DrawConnectionLine2(double x1, double y1, double x2, double y2)
        {
            BrushConverter color = new();
            Line[] lines = new Line[5];

            Line firstLine = new();
            firstLine.X1 = x1;
            firstLine.X2 = x1;
            firstLine.Y1 = y1 - valueOffsetOfLineFromTheBlockToSides;
            firstLine.Y2 = y1;
            firstLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(firstLine);
            destination.Children.Add(firstLine);
            lines[0] = firstLine;

            Line secondLine = new();
            secondLine.X2 = x1;
            secondLine.Y1 = y1 - valueOffsetOfLineFromTheBlockToSides;
            secondLine.Y2 = y1 - valueOffsetOfLineFromTheBlockToSides;
            secondLine.X1 = x1 + DefaultPropertyForBlock.width / 2 + valueOffsetOfLineFromTheBlockToSides;
            secondLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(secondLine);
            destination.Children.Add(secondLine);
            lines[1] = secondLine;

            Line thirdLine = new();
            thirdLine.Y1 = y1 - valueOffsetOfLineFromTheBlockToSides;
            thirdLine.X1 = x1 + DefaultPropertyForBlock.width / 2 + valueOffsetOfLineFromTheBlockToSides;
            thirdLine.Y2 = y2 + valueOffsetOfLineFromTheBlockToSides;
            thirdLine.X2 = x1 + DefaultPropertyForBlock.width / 2 + valueOffsetOfLineFromTheBlockToSides;
            thirdLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(thirdLine);
            destination.Children.Add(thirdLine);
            lines[2] = thirdLine;

            Line fourthLine = new();
            fourthLine.X1 = x2;
            fourthLine.Y1 = y2 + valueOffsetOfLineFromTheBlockToSides;
            fourthLine.X2 = x1 + DefaultPropertyForBlock.width / 2 + valueOffsetOfLineFromTheBlockToSides;
            fourthLine.Y2 = y2 + valueOffsetOfLineFromTheBlockToSides;
            fourthLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(fourthLine);
            destination.Children.Add(fourthLine);
            lines[3] = fourthLine;

            Line fifthLine = new();
            fifthLine.X2 = x2;
            fifthLine.Y1 = y2;
            fifthLine.X1 = x2;
            fifthLine.Y2 = y2 + valueOffsetOfLineFromTheBlockToSides;
            fifthLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(fifthLine);
            destination.Children.Add(fifthLine);
            lines[4] = fifthLine;

            return lines;
        }
        public Line[] DrawConnectionLine3(double x1, double y1, double x2, double y2)
        {
            BrushConverter color = new();
            Line[] lines = new Line[5];

            Line firstLine = new();
            firstLine.X1 = x1;
            firstLine.Y1 = y1;
            firstLine.X2 = x2;
            firstLine.Y2 = y2;
            firstLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(firstLine);
            destination.Children.Add(firstLine);
            lines[0] = firstLine;

            return lines;
        }
        public Line[] DrawConnectionLine4(double x1, double y1, double x2, double y2)
        {
            double distanceBetweenTwoPoints = y2 - y1;
            Line[] lines = new Line[5];

            BrushConverter color = new();
            Line firstLine = new();
            firstLine.X1 = x2;
            firstLine.Y1 = y2;
            firstLine.X2 = x2 + valueOffsetOfLineFromTheBlockToSides;
            firstLine.Y2 = y2;
            firstLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(firstLine);
            destination.Children.Add(firstLine);
            lines[0] = firstLine;


            Line secondLine = new();
            secondLine.X1 = x2 + valueOffsetOfLineFromTheBlockToSides;
            secondLine.Y1 = y2;
            secondLine.X2 = x2 + valueOffsetOfLineFromTheBlockToSides;
            secondLine.Y2 = y2 - distanceBetweenTwoPoints - valueOffsetOfLineFromTheBlockToSides;
            secondLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(secondLine);
            destination.Children.Add(secondLine);
            lines[1] = secondLine;

            Line thirdLine = new();
            thirdLine.X1 = x1;
            thirdLine.Y1 = y1 - valueOffsetOfLineFromTheBlockToSides;
            thirdLine.X2 = x2 + valueOffsetOfLineFromTheBlockToSides;
            thirdLine.Y2 = y2 - distanceBetweenTwoPoints - valueOffsetOfLineFromTheBlockToSides;
            thirdLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(thirdLine);
            destination.Children.Add(thirdLine);
            lines[2] = thirdLine;

            Line fourthLine = new();
            fourthLine.X1 = x1;
            fourthLine.Y1 = y1;
            fourthLine.X2 = x1;
            fourthLine.Y2 = y1 - valueOffsetOfLineFromTheBlockToSides;
            fourthLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(fourthLine);
            destination.Children.Add(fourthLine);
            lines[3] = fourthLine;

            return lines;
        }
        public Line[] DrawConnectionLine5(double x1, double y1, double x2, double y2)
        {
            Line[] lines = new Line[5];

            BrushConverter color = new();
            Line firstLine = new();
            firstLine.X1 = x2;
            firstLine.Y1 = y2;
            firstLine.X2 = x1;
            firstLine.Y2 = y2;
            firstLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(firstLine);
            destination.Children.Add(firstLine);
            lines[0] = firstLine;

            Line secondLine = new();
            secondLine.X1 = x1;
            secondLine.Y1 = y2;
            secondLine.X2 = x1;
            secondLine.Y2 = y1;
            secondLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(secondLine);
            destination.Children.Add(secondLine);
            lines[1] = secondLine;

            return lines;
        }
        public Line[] DrawConnectionLine6(double x1, double y1, double x2, double y2)
        {
            double distanceBetweenTwoPoints = x1 - x2;
            BrushConverter color = new();
            Line[] lines = new Line[5];

            Line firstLine = new();
            firstLine.X1 = x1;
            firstLine.Y1 = y1;
            firstLine.X2 = x1;
            firstLine.Y2 = y1 - valueOffsetOfLineFromTheBlockToSides;
            firstLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(firstLine);
            destination.Children.Add(firstLine);
            lines[0] = firstLine;

            Line secondLine = new();
            secondLine.X1 = x1;
            secondLine.Y1 = y1 - valueOffsetOfLineFromTheBlockToSides;
            secondLine.X2 = x1 - distanceBetweenTwoPoints + valueOffsetOfLineFromTheBlockToSides;
            secondLine.Y2 = y1 - valueOffsetOfLineFromTheBlockToSides;
            secondLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(secondLine);
            destination.Children.Add(secondLine);
            lines[1] = secondLine;

            Line thirdLine = new();
            thirdLine.X1 = x2;
            thirdLine.Y1 = y2;
            thirdLine.X2 = x2 + valueOffsetOfLineFromTheBlockToSides;
            thirdLine.Y2 = y2;
            thirdLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(thirdLine);
            destination.Children.Add(thirdLine);
            lines[2] = thirdLine;

            Line fourthLine = new();
            fourthLine.X1 = x2 + valueOffsetOfLineFromTheBlockToSides;
            fourthLine.Y1 = y2;
            fourthLine.X2 = x2 + valueOffsetOfLineFromTheBlockToSides;
            fourthLine.Y2 = y1 - valueOffsetOfLineFromTheBlockToSides;
            fourthLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(fourthLine);
            destination.Children.Add(fourthLine);
            lines[3] = fourthLine;

            return lines;
        }
        public Line[] DrawConnectionLine7(double x1, double y1, double x2, double y2)
        {
            double distanceBetweenTwoPoints = y1 - y2;
            BrushConverter color = new();
            Line[] lines = new Line[5];

            Line firstLine = new();
            firstLine.X1 = x1;
            firstLine.Y1 = y1;
            firstLine.X2 = x1;
            firstLine.Y2 = y1 - valueOffsetOfLineFromTheBlockToSides;
            firstLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(firstLine);
            destination.Children.Add(firstLine);
            lines[0] = firstLine;

            Line secondLine = new();
            secondLine.X1 = x2;
            secondLine.Y1 = y2 - valueOffsetOfLineFromTheBlockToSides;
            secondLine.X2 = x2 + DefaultPropertyForBlock.width / 2 + valueOffsetOfLineFromTheBlockToSides;
            secondLine.Y2 = y2 - valueOffsetOfLineFromTheBlockToSides;
            secondLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(secondLine);
            destination.Children.Add(secondLine);
            lines[1] = secondLine;

            Line thirdLine = new();
            thirdLine.X1 = x2 + DefaultPropertyForBlock.width / 2 + valueOffsetOfLineFromTheBlockToSides;
            thirdLine.Y1 = y2 - valueOffsetOfLineFromTheBlockToSides;
            thirdLine.X2 = x2 + DefaultPropertyForBlock.width / 2 + valueOffsetOfLineFromTheBlockToSides;
            thirdLine.Y2 = y2 - valueOffsetOfLineFromTheBlockToSides + distanceBetweenTwoPoints;
            thirdLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(thirdLine);
            destination.Children.Add(thirdLine);
            lines[2] = thirdLine;

            Line fourthLine = new();
            fourthLine.X1 = x2 + DefaultPropertyForBlock.width / 2 + valueOffsetOfLineFromTheBlockToSides;
            fourthLine.Y1 = y2 - valueOffsetOfLineFromTheBlockToSides + distanceBetweenTwoPoints;
            fourthLine.X2 = x1;
            fourthLine.Y2 = y1 - valueOffsetOfLineFromTheBlockToSides;
            fourthLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(fourthLine);
            destination.Children.Add(fourthLine);
            lines[3] = fourthLine;

            Line fifthLine = new();
            fifthLine.X2 = x2;
            fifthLine.Y1 = y2;
            fifthLine.X1 = x2;
            fifthLine.Y2 = y2 - valueOffsetOfLineFromTheBlockToSides;
            fifthLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(fifthLine);
            destination.Children.Add(fifthLine);
            lines[4] = fourthLine;

            return lines;
        }

        public Line[] DrawConnectionLine8(double x1, double y1, double x2, double y2)
        {
            BrushConverter color = new();
            Line[] lines = new Line[5];

            Line firstLine = new();
            firstLine.X1 = x2;
            firstLine.Y1 = y2;
            firstLine.X2 = x2;
            firstLine.Y2 = y2 - valueOffsetOfLineFromTheBlockToSides;
            firstLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(firstLine);
            destination.Children.Add(firstLine);
            lines[0] = firstLine;

            Line secondLine = new();
            secondLine.X1 = x2;
            secondLine.Y1 = y2 - valueOffsetOfLineFromTheBlockToSides;
            secondLine.X2 = x1;
            secondLine.Y2 = y2 - valueOffsetOfLineFromTheBlockToSides;
            secondLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(secondLine);
            destination.Children.Add(secondLine);
            lines[1] = secondLine;

            Line thirdLine = new();
            thirdLine.X1 = x1;
            thirdLine.Y1 = y2 - valueOffsetOfLineFromTheBlockToSides;
            thirdLine.X2 = x1;
            thirdLine.Y2 = y1;
            thirdLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(thirdLine);
            destination.Children.Add(thirdLine);
            lines[2] = thirdLine;

            return lines;
        }

        public Line[] DrawConnectionLine9(double x1, double y1, double x2, double y2)
        {
            double distanceBetweenTwoPoints = y2 - y1;
            Line[] lines = new Line[5];
            BrushConverter color = new();

            Line firstLine = new();
            firstLine.X1 = x2;
            firstLine.Y1 = y2;
            firstLine.X2 = x2 - valueOffsetOfLineFromTheBlockToSides;
            firstLine.Y2 = y2;
            firstLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(firstLine);
            destination.Children.Add(firstLine);
            lines[0] = firstLine;

            Line secondLine = new();
            secondLine.X1 = x2 - valueOffsetOfLineFromTheBlockToSides;
            secondLine.Y1 = y2;
            secondLine.X2 = x2 - valueOffsetOfLineFromTheBlockToSides;
            secondLine.Y2 = y2 - distanceBetweenTwoPoints - valueOffsetOfLineFromTheBlockToSides;
            secondLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(secondLine);
            destination.Children.Add(secondLine);
            lines[1] = secondLine;

            Line thirdLine = new();
            thirdLine.X1 = x1;
            thirdLine.Y1 = y1 - valueOffsetOfLineFromTheBlockToSides;
            thirdLine.X2 = x2 - valueOffsetOfLineFromTheBlockToSides;
            thirdLine.Y2 = y2 - distanceBetweenTwoPoints - valueOffsetOfLineFromTheBlockToSides;
            thirdLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(thirdLine);
            destination.Children.Add(thirdLine);
            lines[2] = thirdLine;

            Line fourthLine = new();
            fourthLine.X1 = x1;
            fourthLine.Y1 = y1;
            fourthLine.X2 = x1;
            fourthLine.Y2 = y1 - valueOffsetOfLineFromTheBlockToSides;
            fourthLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(fourthLine);
            destination.Children.Add(fourthLine);
            lines[3] = fourthLine;

            return lines;
        }

        public Line[] DrawConnectionLine10(double x1, double y1, double x2, double y2)
        {
            BrushConverter color = new();
            Line[] lines = new Line[5];

            Line firstLine = new();
            double distanceBetweenTwoPoints = x2 - x1;
            firstLine.X1 = x1;
            firstLine.Y1 = y1;
            firstLine.X2 = x1 - valueOffsetOfLineFromTheBlockToSides;
            firstLine.Y2 = y1;
            firstLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(firstLine);
            destination.Children.Add(firstLine);
            lines[0] = firstLine;

            Line secondLine = new();
            secondLine.X1 = x1 - valueOffsetOfLineFromTheBlockToSides;
            secondLine.Y1 = y1;
            secondLine.X2 = x2 - distanceBetweenTwoPoints - valueOffsetOfLineFromTheBlockToSides;
            secondLine.Y2 = y2;
            secondLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(secondLine);
            destination.Children.Add(secondLine);
            lines[1] = secondLine;

            Line thirdLine = new();
            thirdLine.X1 = x2;
            thirdLine.Y1 = y2;
            thirdLine.X2 = x2  - distanceBetweenTwoPoints - valueOffsetOfLineFromTheBlockToSides;
            thirdLine.Y2 = y2;
            thirdLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(thirdLine);
            destination.Children.Add(thirdLine);
            lines[2] = thirdLine;

            return lines;
        }

        public Line[] DrawConnectionLine11(double x1, double y1, double x2, double y2)
        {
            BrushConverter color = new();
            Line[] lines = new Line[5];

            Line firstLine = new();
            firstLine.X1 = x1;
            firstLine.Y1 = y1;
            firstLine.X2 = x1 - valueOffsetOfLineFromTheBlockToSides;
            firstLine.Y2 = y1;
            firstLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(firstLine);
            destination.Children.Add(firstLine);
            lines[0] = firstLine;

            Line secondLine = new();
            secondLine.X1 = x1 - valueOffsetOfLineFromTheBlockToSides;
            secondLine.Y1 = y1;
            secondLine.X2 = x1 - valueOffsetOfLineFromTheBlockToSides;
            secondLine.Y2 = y2 + DefaultPropertyForBlock.height / 2 + valueOffsetOfLineFromTheBlockToSides;
            secondLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(secondLine);
            destination.Children.Add(secondLine);
            lines[1] = secondLine;

            Line thirdLine = new();
            thirdLine.X1 = x1 - valueOffsetOfLineFromTheBlockToSides;
            thirdLine.Y1 = y2 + DefaultPropertyForBlock.height / 2 + valueOffsetOfLineFromTheBlockToSides;
            thirdLine.X2 = x2 - valueOffsetOfLineFromTheBlockToSides;
            thirdLine.Y2 = y2 + DefaultPropertyForBlock.height / 2 + valueOffsetOfLineFromTheBlockToSides;
            thirdLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(thirdLine);
            destination.Children.Add(thirdLine);
            lines[2] = thirdLine;

            Line fourthLine = new();
            fourthLine.X1 = x2 - valueOffsetOfLineFromTheBlockToSides;
            fourthLine.Y1 = y2 + DefaultPropertyForBlock.height / 2 + valueOffsetOfLineFromTheBlockToSides;
            fourthLine.X2 = x2 - valueOffsetOfLineFromTheBlockToSides;
            fourthLine.Y2 = y2;
            fourthLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(fourthLine);
            destination.Children.Add(fourthLine);
            lines[3] = fourthLine;

            Line fifthLine = new();
            fifthLine.X2 = x2;
            fifthLine.Y1 = y2;
            fifthLine.X1 = x2 - valueOffsetOfLineFromTheBlockToSides;
            fifthLine.Y2 = y2;
            fifthLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(fifthLine);
            destination.Children.Add(fifthLine);
            lines[4] = fifthLine;

            return lines;
        }

        public Line[] DrawConnectionLine12(double x1, double y1, double x2, double y2)
        {
            BrushConverter color = new();
            Line[] lines = new Line[5];

            Line firstLine = new();
            firstLine.X1 = x2;
            firstLine.Y1 = y2;
            firstLine.X2 = x2 - valueOffsetOfLineFromTheBlockToSides;
            firstLine.Y2 = y2;
            firstLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(firstLine);
            destination.Children.Add(firstLine);
            lines[0] = firstLine;

            Line secondLine = new();
            secondLine.X1 = x2 - valueOffsetOfLineFromTheBlockToSides;
            secondLine.Y1 = y2;
            secondLine.X2 = x2 - valueOffsetOfLineFromTheBlockToSides;
            secondLine.Y2 = y1 + valueOffsetOfLineFromTheBlockToSides;
            secondLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(secondLine);
            destination.Children.Add(secondLine);
            lines[1] = secondLine;

            Line thirdLine = new();
            thirdLine.X1 = x2 - valueOffsetOfLineFromTheBlockToSides;
            thirdLine.Y1 = y1 + valueOffsetOfLineFromTheBlockToSides;
            thirdLine.X2 = x1;
            thirdLine.Y2 = y1 + valueOffsetOfLineFromTheBlockToSides;
            thirdLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(thirdLine);
            destination.Children.Add(thirdLine);
            lines[2] = thirdLine;

            Line fourthLine = new();
            fourthLine.X1 = x1;
            fourthLine.Y1 = y1;
            fourthLine.X2 = x1;
            fourthLine.Y2 = y1 + valueOffsetOfLineFromTheBlockToSides;
            fourthLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(fourthLine);
            destination.Children.Add(fourthLine);
            lines[3] = fourthLine;

            return lines;
        }

        private Line[] DrawConnectionLine13(double x1, double y1, double x2, double y2)
        {
            BrushConverter color = new();
            Line[] lines = new Line[5];

            Line firstLine = new();
            firstLine.X1 = x2;
            firstLine.Y1 = y2;
            firstLine.X2 = x2 - valueOffsetOfLineFromTheBlockToSides;
            firstLine.Y2 = y2;
            firstLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(firstLine);
            destination.Children.Add(firstLine);
            lines[0] = firstLine;

            Line secondLine = new();
            secondLine.X1 = x2 - valueOffsetOfLineFromTheBlockToSides;
            secondLine.Y1 = y2;
            secondLine.X2 = x2 - valueOffsetOfLineFromTheBlockToSides;
            secondLine.Y2 = y2 + DefaultPropertyForBlock.height / 2 + valueOffsetOfLineFromTheBlockToSides;
            secondLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(secondLine);
            destination.Children.Add(secondLine);
            lines[1] = secondLine;

            Line thirdLine = new();
            thirdLine.X1 = x2 - valueOffsetOfLineFromTheBlockToSides;
            thirdLine.Y1 = y2 + DefaultPropertyForBlock.height / 2 + valueOffsetOfLineFromTheBlockToSides;
            thirdLine.X2 = x1 + valueOffsetOfLineFromTheBlockToSides;
            thirdLine.Y2 = y2 + DefaultPropertyForBlock.height / 2 + valueOffsetOfLineFromTheBlockToSides;
            thirdLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(thirdLine);
            destination.Children.Add(thirdLine);
            lines[2] = thirdLine;

            Line fourthLine = new();
            fourthLine.X1 = x1 + valueOffsetOfLineFromTheBlockToSides;
            fourthLine.Y1 = y1;
            fourthLine.X2 = x1 + valueOffsetOfLineFromTheBlockToSides;
            fourthLine.Y2 = y2 + DefaultPropertyForBlock.height / 2 + valueOffsetOfLineFromTheBlockToSides;
            fourthLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(fourthLine);
            destination.Children.Add(fourthLine);
            lines[3] = fourthLine;

            Line fifthLine = new();
            fifthLine.X2 = x1;
            fifthLine.Y1 = y1;
            fifthLine.X1 = x1 + valueOffsetOfLineFromTheBlockToSides;
            fifthLine.Y2 = y1;
            fifthLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(fifthLine);
            destination.Children.Add(fifthLine);
            lines[4] = fifthLine;

            return lines;
        }
        private Line[] DrawConnectionLine14(double x1, double y1, double x2, double y2)
        {
            double distanceBetweenTwoPoints = x1 - x2;
            BrushConverter color = new();
            Line[] lines = new Line[5];

            Line firstLine = new();
            firstLine.X1 = x1;
            firstLine.Y1 = y1;
            firstLine.X2 = x1 - distanceBetweenTwoPoints / 2;
            firstLine.Y2 = y1;
            firstLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(firstLine);
            destination.Children.Add(firstLine);
            lines[0] = firstLine;

            Line secondLine = new();
            secondLine.X1 = x1 - distanceBetweenTwoPoints / 2;
            secondLine.Y1 = y1;
            secondLine.X2 = x2 + distanceBetweenTwoPoints / 2;
            secondLine.Y2 = y2;
            secondLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(secondLine);
            destination.Children.Add(secondLine);
            lines[1] = secondLine;

            Line thirdLine = new();
            thirdLine.X1 = x2;
            thirdLine.Y1 = y2;
            thirdLine.X2 = x2 + distanceBetweenTwoPoints / 2;
            thirdLine.Y2 = y2;
            thirdLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(thirdLine);
            destination.Children.Add(thirdLine);
            lines[2] = thirdLine;

            return lines;
        }

        private Line[] DrawConnectionLine15(double x1, double y1, double x2, double y2)
        {
            double distanceBetweenTwoPoints = y1 - y2;
            BrushConverter color = new();
            Line[] lines = new Line[5];

            Line firstLine = new();
            firstLine.X1 = x1;
            firstLine.Y1 = y1;
            firstLine.X2 = x1;
            firstLine.Y2 = y1 + valueOffsetOfLineFromTheBlockToSides;
            firstLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(firstLine);
            destination.Children.Add(firstLine);
            lines[0] = firstLine;

            Line secondLine = new();
            secondLine.X1 = x2;
            secondLine.Y1 = y2 + valueOffsetOfLineFromTheBlockToSides;
            secondLine.X2 = x2 + DefaultPropertyForBlock.width / 2 + valueOffsetOfLineFromTheBlockToSides;
            secondLine.Y2 = y2 + valueOffsetOfLineFromTheBlockToSides;
            secondLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(secondLine);
            destination.Children.Add(secondLine);
            lines[1] = secondLine;

            Line thirdLine = new();
            thirdLine.X1 = x2 + DefaultPropertyForBlock.width / 2 + valueOffsetOfLineFromTheBlockToSides;
            thirdLine.Y1 = y2 + valueOffsetOfLineFromTheBlockToSides;
            thirdLine.X2 = x2 + DefaultPropertyForBlock.width / 2 + valueOffsetOfLineFromTheBlockToSides;
            thirdLine.Y2 = y2 + valueOffsetOfLineFromTheBlockToSides + distanceBetweenTwoPoints;
            thirdLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(thirdLine);
            destination.Children.Add(thirdLine);
            lines[2] = thirdLine;

            Line fourthLine = new();
            fourthLine.X1 = x2 + DefaultPropertyForBlock.width / 2 + valueOffsetOfLineFromTheBlockToSides;
            fourthLine.Y1 = y2 + valueOffsetOfLineFromTheBlockToSides + distanceBetweenTwoPoints;
            fourthLine.X2 = x1;
            fourthLine.Y2 = y1 + valueOffsetOfLineFromTheBlockToSides;
            fourthLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(fourthLine);
            destination.Children.Add(fourthLine);
            lines[3] = thirdLine;

            Line fifthLine = new();
            fifthLine.X2 = x2;
            fifthLine.Y1 = y2;
            fifthLine.X1 = x2;
            fifthLine.Y2 = y2 + valueOffsetOfLineFromTheBlockToSides;
            fifthLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(fifthLine);
            destination.Children.Add(fifthLine);
            lines[4] = fifthLine;

            return lines;
        }

        private Line[] DrawConnectionLine16(double x1, double y1, double x2, double y2)
        {
            BrushConverter color = new();
            Line[] lines = new Line[5];
            double distanceBetweenTwoPoints = y1 - y2;

            Line firstLine = new();
            firstLine.X1 = x2;
            firstLine.Y1 = y2;
            firstLine.X2 = x2;
            firstLine.Y2 = y2 + distanceBetweenTwoPoints + valueOffsetOfLineFromTheBlockToSides;
            firstLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(firstLine);
            destination.Children.Add(firstLine);
            lines[0] = firstLine;

            Line secondLine = new();
            secondLine.X1 = x2;
            secondLine.Y1 = y2 + distanceBetweenTwoPoints + valueOffsetOfLineFromTheBlockToSides;
            secondLine.X2 = x1;
            secondLine.Y2 = y1 + valueOffsetOfLineFromTheBlockToSides;
            secondLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(secondLine);
            destination.Children.Add(secondLine);
            lines[1] = secondLine;

            Line thirdLine = new();
            thirdLine.X1 = x1;
            thirdLine.Y1 = y1;
            thirdLine.X2 = x1;
            thirdLine.Y2 = y1 + valueOffsetOfLineFromTheBlockToSides;
            thirdLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(thirdLine);
            destination.Children.Add(thirdLine);
            lines[2] = thirdLine;

            return lines;
        }

        private Line[] DrawConnectionLine17(double x1, double y1, double x2, double y2)
        {
            BrushConverter color = new();
            Line[] lines = new Line[5];

            Line firstLine = new();
            firstLine.X1 = x1;
            firstLine.Y1 = y1;
            firstLine.X2 = x1;
            firstLine.Y2 = y1 + valueOffsetOfLineFromTheBlockToSides;
            firstLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(firstLine);
            destination.Children.Add(firstLine);
            lines[0] = firstLine;

            Line secondLine = new();
            secondLine.X1 = x2 + valueOffsetOfLineFromTheBlockToSides;
            secondLine.Y1 = y1 + valueOffsetOfLineFromTheBlockToSides;
            secondLine.X2 = x1;
            secondLine.Y2 = y1 + valueOffsetOfLineFromTheBlockToSides;
            secondLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(secondLine);
            destination.Children.Add(secondLine);
            lines[1] = secondLine;

            Line thirdLine = new();
            thirdLine.X1 = x2 + valueOffsetOfLineFromTheBlockToSides;
            thirdLine.Y1 = y1 + valueOffsetOfLineFromTheBlockToSides;
            thirdLine.X2 = x2 + valueOffsetOfLineFromTheBlockToSides;
            thirdLine.Y2 = y2;
            thirdLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(thirdLine);
            destination.Children.Add(thirdLine);
            lines[2] = thirdLine;

            Line fourthLine = new();
            fourthLine.X1 = x2;
            fourthLine.Y1 = y2;
            fourthLine.X2 = x2 + valueOffsetOfLineFromTheBlockToSides;
            fourthLine.Y2 = y2;
            fourthLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(fourthLine);
            destination.Children.Add(fourthLine);
            lines[3] = fourthLine;

            return lines;
        }

        private Line[] DrawConnectionLine18(double x1, double y1, double x2, double y2)
        {
            BrushConverter color = new();
            Line[] lines = new Line[5];
            Line firstLine = new();
            double distanceBetweenTwoPoints = x2 - x1;
            firstLine.X1 = x1;
            firstLine.Y1 = y1;
            firstLine.X2 = x1 + valueOffsetOfLineFromTheBlockToSides;
            firstLine.Y2 = y1;
            firstLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(firstLine);
            destination.Children.Add(firstLine);
            lines[0] = firstLine;

            Line secondLine = new();
            secondLine.X1 = x1 + valueOffsetOfLineFromTheBlockToSides;
            secondLine.Y1 = y1;
            secondLine.X2 = x2 - distanceBetweenTwoPoints + valueOffsetOfLineFromTheBlockToSides;
            secondLine.Y2 = y2;
            secondLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(secondLine);
            destination.Children.Add(secondLine);
            lines[1] = secondLine;

            Line thirdLine = new();
            thirdLine.X1 = x2;
            thirdLine.Y1 = y2;
            thirdLine.X2 = x2 - distanceBetweenTwoPoints + valueOffsetOfLineFromTheBlockToSides;
            thirdLine.Y2 = y2;
            thirdLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(thirdLine);
            destination.Children.Add(thirdLine);
            lines[2] = thirdLine;

            return lines;
        }

        private Line[] DrawConnectionLine20(double x1, double y1, double x2, double y2)
        {
            BrushConverter color = new();
            Line[] lines = new Line[5];
            
            Line firstLine = new();
            firstLine.X1 = x1;
            firstLine.Y1 = y1;
            firstLine.X2 = x1 + valueOffsetOfLineFromTheBlockToSides;
            firstLine.Y2 = y1;
            firstLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(firstLine);
            destination.Children.Add(firstLine);
            lines[0] = firstLine;

            Line secondLine = new();
            secondLine.X1 = x1 + valueOffsetOfLineFromTheBlockToSides;
            secondLine.Y1 = y1;
            secondLine.X2 = x1 + valueOffsetOfLineFromTheBlockToSides;
            secondLine.Y2 = y2 + DefaultPropertyForBlock.height / 2 + valueOffsetOfLineFromTheBlockToSides;
            secondLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(secondLine);
            destination.Children.Add(secondLine);
            lines[1] = secondLine;

            Line thirdLine = new();
            thirdLine.X1 = x1 + valueOffsetOfLineFromTheBlockToSides;
            thirdLine.Y1 = y2 + DefaultPropertyForBlock.height / 2 + valueOffsetOfLineFromTheBlockToSides;
            thirdLine.X2 = x2 + valueOffsetOfLineFromTheBlockToSides;
            thirdLine.Y2 = y2 + DefaultPropertyForBlock.height / 2 + valueOffsetOfLineFromTheBlockToSides;
            thirdLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(thirdLine);
            destination.Children.Add(thirdLine);
            lines[2] = thirdLine;

            Line fourthLine = new();
            fourthLine.X1 = x2 + valueOffsetOfLineFromTheBlockToSides;
            fourthLine.Y1 = y2 + DefaultPropertyForBlock.height / 2 + valueOffsetOfLineFromTheBlockToSides;
            fourthLine.X2 = x2 + valueOffsetOfLineFromTheBlockToSides;
            fourthLine.Y2 = y2;
            fourthLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(fourthLine);
            destination.Children.Add(fourthLine);
            lines[3] = fourthLine;

            Line fifthLine = new();
            fifthLine.X2 = x2;
            fifthLine.Y1 = y2;
            fifthLine.X1 = x2 + valueOffsetOfLineFromTheBlockToSides;
            fifthLine.Y2 = y2;
            fifthLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            listLineConnection.Add(fifthLine);
            destination.Children.Add(fifthLine);
            lines[4] = fifthLine;

            return lines;
        }

        public Line[]? DrawConnectionLine(double x1, double y1, double x2, double y2)
        {
            Line[] lines = new Line[5];
            if (CoordinatesBlock.keyFirstBlock == CoordinatesBlock.keySecondBlock)
            {
                MessageBox.Show("Ошибка соединения блоков");
                WriteFirstNameOfBlockToConect("");
                WriteSecondNameOfBlockToConect("");
                StaticBlock.firstPointToConnect = "";
                StaticBlock.secondPointToConnect = "";
                return null;
            }
            else
            {
                if (StaticBlock.firstPointToConnect == "firstPointToConnect" && StaticBlock.secondPointToConnect == "fourthPointToConnect")
                {
                    if (y2 < y1 && x1 <= x2)
                        lines = DrawConnectionLine4(x1, y1, x2, y2);
                    else if (y2 < y1 && x1 >= x2)
                        lines = DrawConnectionLine5(x1, y1, x2, y2);
                    else if (y1 < y2)
                        lines = DrawConnectionLine6(x1, y1, x2, y2);
                }
                else if (StaticBlock.firstPointToConnect == "fourthPointToConnect" && StaticBlock.secondPointToConnect == "firstPointToConnect")
                {
                    if (y2 > y1 && x1 >= x2)
                        lines = DrawConnectionLine4(x2, y2, x1, y1);
                    else if (y2 > y1 && x1 <= x2)
                        lines = DrawConnectionLine5(x2, y2, x1, y1);
                    else if (y1 > y2)
                        lines = DrawConnectionLine6(x2, y2, x1, y1);
                }
                else if (StaticBlock.firstPointToConnect == "thirdPointToConnect" && StaticBlock.secondPointToConnect == "firstPointToConnect")
                {
                    if (x1 != x2 && y2 > y1)
                        lines = DrawConnectionLine1(x1, y1, x2, y2);
                    else if ((x2 - x1) > DefaultPropertyForBlock.height)
                        lines = DrawConnectionLine2(x2, y2, x1, y1);
                    else if (x1 == x2)
                        lines = DrawConnectionLine3(x1, y1, x2, y2);
                }
                else if (StaticBlock.firstPointToConnect == "firstPointToConnect" && StaticBlock.secondPointToConnect == "thirdPointToConnect")
                {
                    if (x1 != x2 && y2 < y1)
                        lines = DrawConnectionLine1(x1, y1, x2, y2);
                    else if ((x2 - x1) < DefaultPropertyForBlock.height)
                        lines = DrawConnectionLine2(x1, y1, x2, y2);
                    else if (x1 == x2)
                        lines = DrawConnectionLine3(x1, y1, x2, y2);
                }
                else if (StaticBlock.firstPointToConnect == "firstPointToConnect" && StaticBlock.secondPointToConnect == "firstPointToConnect")
                {
                    if ((x2 + DefaultPropertyForBlock.width / 2 < x1) || (x1 + DefaultPropertyForBlock.width / 2 < x2))
                    {
                        if (y1 > y2)
                            lines = DrawConnectionLine8(x1, y1, x2, y2);
                        else
                            lines = DrawConnectionLine8(x2, y2, x1, y1);
                    }
                    else lines = DrawConnectionLine7(x1, y1, x2, y2);
                }
                else if (StaticBlock.firstPointToConnect == "firstPointToConnect" && StaticBlock.secondPointToConnect == "secondPointToConnect")
                {
                    if (x1 <= x2)
                        lines = DrawConnectionLine5(x1, y1, x2, y2);
                    else if (y2 > y1)
                        lines = DrawConnectionLine9(x1, y1, x2, y2);
                }
                else if (StaticBlock.firstPointToConnect == "secondPointToConnect" && StaticBlock.secondPointToConnect == "firstPointToConnect")
                {
                    if (x1 >= x2)
                        lines = DrawConnectionLine5(x2, y2, x1, y1);
                    else if (y2 < y1)
                        lines = DrawConnectionLine9(x2, y2, x1, y1);
                    else if (x1 <= x2 && y2 > y1)
                        lines = DrawConnectionLine9(x2, y2, x1, y1);
                }
                else if (StaticBlock.firstPointToConnect == "secondPointToConnect" && StaticBlock.secondPointToConnect == "secondPointToConnect")
                {
                    if ((y2 + DefaultPropertyForBlock.height / 2 <= y1) || (y1 + DefaultPropertyForBlock.width / 2 >= y2))
                        lines = DrawConnectionLine11(x2, y2, x1, y1);
                    else if (x2 < x1)
                        lines = DrawConnectionLine10(x2, y2, x1, y1);
                    else if (x2 > x1)
                        lines = DrawConnectionLine10(x1, y1, x2, y2);
                }
                else if (StaticBlock.firstPointToConnect == "secondPointToConnect" && StaticBlock.secondPointToConnect == "thirdPointToConnect")
                {
                    if (x1 > x2 && y2 < y1)
                        lines = DrawConnectionLine5(x2, y2, x1, y1);
                    else
                        lines = DrawConnectionLine12(x2, y2, x1, y1);
                }
                else if (StaticBlock.firstPointToConnect == "thirdPointToConnect" && StaticBlock.secondPointToConnect == "secondPointToConnect")
                {
                    if (x1 < x2 && y2 > y1)
                        lines = DrawConnectionLine5(x1, y1, x2, y2);
                    else
                        lines = DrawConnectionLine12(x1, y1, x2, y2);
                }
                else if (StaticBlock.firstPointToConnect == "secondPointToConnect" && StaticBlock.secondPointToConnect == "fourthPointToConnect")
                {
                    if (x2 < x1)
                        lines = DrawConnectionLine14(x2, y2, x1, y1);
                    else
                        lines = DrawConnectionLine13(x2, y2, x1, y1);
                }
                else if (StaticBlock.firstPointToConnect == "fourthPointToConnect" && StaticBlock.secondPointToConnect == "secondPointToConnect")
                {
                    if (x2 > x1)
                        lines = DrawConnectionLine14(x1, y1, x2, y2);
                    else
                        lines = DrawConnectionLine13(x1, y1, x2, y2);
                }
                else if (StaticBlock.firstPointToConnect == "thirdPointToConnect" && StaticBlock.secondPointToConnect == "thirdPointToConnect")
                {
                    if ((x2 + DefaultPropertyForBlock.width / 2 < x1) || (x1 + DefaultPropertyForBlock.width / 2 < x2))
                    {
                        if (y1 > y2)
                            lines = DrawConnectionLine16(x1, y1, x2, y2);
                        else
                            lines = DrawConnectionLine16(x2, y2, x1, y1);
                    }
                    else lines = DrawConnectionLine15(x1, y1, x2, y2);
                }
                else if (StaticBlock.firstPointToConnect == "thirdPointToConnect" && StaticBlock.secondPointToConnect == "fourthPointToConnect")
                {
                    if (x1 > x2 && y2 > y1)
                        lines = DrawConnectionLine5(x1, y1, x2, y2);
                    else
                        lines = DrawConnectionLine17(x1, y1, x2, y2);
                }
                else if (StaticBlock.firstPointToConnect == "fourthPointToConnect" && StaticBlock.secondPointToConnect == "thirdPointToConnect")
                {
                    if (x1 < x2 && y2 < y1)
                        lines = DrawConnectionLine5(x2, y2, x1, y1);
                    else
                        lines = DrawConnectionLine17(x2, y2, x1, y1);
                }
                else if (StaticBlock.firstPointToConnect == "fourthPointToConnect" && StaticBlock.secondPointToConnect == "fourthPointToConnect")
                {
                    if ((y1 + DefaultPropertyForBlock.height / 2 <= y2 && y1 > y2) || (y1 <= y2 && y1 >= y2 - DefaultPropertyForBlock.height) || (y1 == y2))
                        lines = DrawConnectionLine20(x2, y2, x1, y1);
                    else if (x2 > x1)
                        lines = DrawConnectionLine18(x2, y2, x1, y1);
                    else if (x2 < x1)
                        lines = DrawConnectionLine18(x1, y1, x2, y2);
                }
            }
            StaticBlock.firstPointToConnect = "";
            StaticBlock.secondPointToConnect = "";
            return lines;
        }

        //public MyLine DrawConnectionLine(double x1, double y1, double x2, double y2, Block firstBlock, Block secondBlock)
        //{

        //    MyLine? myLine = null;
        //    if (StaticBlock.firstPointToConnect == "firstPointToConnect" && StaticBlock.secondPointToConnect == "fourthPointToConnect")
        //    {
        //        if (y2 < y1 && x1 <= x2)
        //            myLine = DrawConnectionLine4(x1, y1, x2, y2, firstBlock, secondBlock);
        //        else if (y2 < y1 && x1 >= x2)
        //            myLine = DrawConnectionLine5(x1, y1, x2, y2, firstBlock, secondBlock);
        //        else if (y1 < y2)
        //            myLine = DrawConnectionLine6(x1, y1, x2, y2, firstBlock, secondBlock);
        //    }
        //    else if (StaticBlock.firstPointToConnect == "fourthPointToConnect" && StaticBlock.secondPointToConnect == "firstPointToConnect")
        //    {
        //        if (y2 > y1 && x1 >= x2)
        //            myLine = DrawConnectionLine4(x2, y2, x1, y1, firstBlock, secondBlock);
        //        else if (y2 > y1 && x1 <= x2)
        //            myLine = DrawConnectionLine5(x2, y2, x1, y1, firstBlock, secondBlock);
        //        else if (y1 > y2)
        //            myLine = DrawConnectionLine6(x2, y2, x1, y1, firstBlock, secondBlock);
        //    }
        //    else if (StaticBlock.firstPointToConnect == "thirdPointToConnect" && StaticBlock.secondPointToConnect == "firstPointToConnect")
        //    {
        //        if (x1 != x2 && y2 > y1)
        //            myLine = DrawConnectionLine1(x1, y1, x2, y2, firstBlock, secondBlock);
        //        else if ((x2 - x1) > DefaultPropertyForBlock.height)
        //            myLine = DrawConnectionLine2(x2, y2, x1, y1, firstBlock, secondBlock);
        //        else if (x1 == x2)
        //            myLine = DrawConnectionLine3(x1, y1, x2, y2, firstBlock, secondBlock);
        //    }
        //    else if (StaticBlock.firstPointToConnect == "firstPointToConnect" && StaticBlock.secondPointToConnect == "thirdPointToConnect")
        //    {
        //        if (x1 != x2 && y2 < y1)
        //            myLine = DrawConnectionLine1(x1, y1, x2, y2, firstBlock, secondBlock);
        //        else if ((x2 - x1) < DefaultPropertyForBlock.height)
        //            myLine = DrawConnectionLine2(x1, y1, x2, y2, firstBlock, secondBlock);
        //        else if (x1 == x2)
        //            myLine = DrawConnectionLine3(x1, y1, x2, y2, firstBlock, secondBlock);
        //    }
        //    else if (StaticBlock.firstPointToConnect == "firstPointToConnect" && StaticBlock.secondPointToConnect == "firstPointToConnect")
        //    {
        //        if ((x2 + DefaultPropertyForBlock.width / 2 < x1) || (x1 + DefaultPropertyForBlock.width / 2 < x2))
        //        {
        //            if (y1 > y2)
        //                myLine = DrawConnectionLine8(x1, y1, x2, y2, firstBlock, secondBlock);
        //            else
        //                myLine = DrawConnectionLine8(x2, y2, x1, y1, firstBlock, secondBlock);
        //        }
        //        else myLine = DrawConnectionLine7(x1, y1, x2, y2, firstBlock, secondBlock);
        //    }
        //    else if (StaticBlock.firstPointToConnect == "firstPointToConnect" && StaticBlock.secondPointToConnect == "secondPointToConnect")
        //    {
        //        if (x1 <= x2)
        //            myLine = DrawConnectionLine5(x1, y1, x2, y2, firstBlock, secondBlock);
        //        else if (y2 > y1)
        //            myLine = DrawConnectionLine9(x1, y1, x2, y2, firstBlock, secondBlock);
        //    }
        //    else if (StaticBlock.firstPointToConnect == "secondPointToConnect" && StaticBlock.secondPointToConnect == "firstPointToConnect")
        //    {
        //        if (x1 >= x2)
        //            myLine = DrawConnectionLine5(x2, y2, x1, y1, firstBlock, secondBlock);
        //        else if (y2 < y1)
        //            myLine = DrawConnectionLine9(x2, y2, x1, y1, firstBlock, secondBlock);
        //        else if (x1 <= x2 && y2 > y1)
        //            myLine = DrawConnectionLine9(x2, y2, x1, y1, firstBlock, secondBlock);
        //    }
        //    else if (StaticBlock.firstPointToConnect == "secondPointToConnect" && StaticBlock.secondPointToConnect == "secondPointToConnect")
        //    {
        //        if ((y2 + DefaultPropertyForBlock.height / 2 <= y1) || (y1 + DefaultPropertyForBlock.width / 2 >= y2))
        //            myLine = DrawConnectionLine11(x2, y2, x1, y1, firstBlock, secondBlock);
        //        else if (x2 < x1)
        //            myLine = DrawConnectionLine10(x2, y2, x1, y1, firstBlock, secondBlock);
        //        else if (x2 > x1)
        //            myLine = DrawConnectionLine10(x1, y1, x2, y2, firstBlock, secondBlock);
        //    }
        //    else if (StaticBlock.firstPointToConnect == "secondPointToConnect" && StaticBlock.secondPointToConnect == "thirdPointToConnect")
        //    {
        //        if (x1 > x2 && y2 < y1)
        //            myLine = DrawConnectionLine5(x2, y2, x1, y1, firstBlock, secondBlock);
        //        else
        //            myLine = DrawConnectionLine12(x2, y2, x1, y1, firstBlock, secondBlock);
        //    }
        //    else if (StaticBlock.firstPointToConnect == "thirdPointToConnect" && StaticBlock.secondPointToConnect == "secondPointToConnect")
        //    {
        //        if (x1 < x2 && y2 > y1)
        //            myLine = DrawConnectionLine5(x1, y1, x2, y2, firstBlock, secondBlock);
        //        else
        //            myLine = DrawConnectionLine12(x1, y1, x2, y2, firstBlock, secondBlock);
        //    }
        //    else if (StaticBlock.firstPointToConnect == "secondPointToConnect" && StaticBlock.secondPointToConnect == "fourthPointToConnect")
        //    {
        //        if (x2 < x1)
        //            myLine = DrawConnectionLine14(x2, y2, x1, y1, firstBlock, secondBlock);
        //        else
        //            myLine = DrawConnectionLine13(x2, y2, x1, y1, firstBlock, secondBlock);
        //    }
        //    else if (StaticBlock.firstPointToConnect == "fourthPointToConnect" && StaticBlock.secondPointToConnect == "secondPointToConnect")
        //    {
        //        if (x2 > x1)
        //            myLine = DrawConnectionLine14(x1, y1, x2, y2, firstBlock, secondBlock);
        //        else
        //            myLine = DrawConnectionLine13(x1, y1, x2, y2, firstBlock, secondBlock);
        //    }
        //    else if (StaticBlock.firstPointToConnect == "thirdPointToConnect" && StaticBlock.secondPointToConnect == "thirdPointToConnect")
        //    {
        //        if ((x2 + DefaultPropertyForBlock.width / 2 < x1) || (x1 + DefaultPropertyForBlock.width / 2 < x2))
        //        {
        //            if (y1 > y2)
        //                myLine = DrawConnectionLine16(x1, y1, x2, y2, firstBlock, secondBlock);
        //            else
        //                myLine = DrawConnectionLine16(x2, y2, x1, y1, firstBlock, secondBlock);
        //        }
        //        else myLine = DrawConnectionLine15(x1, y1, x2, y2, firstBlock, secondBlock);
        //    }
        //    else if (StaticBlock.firstPointToConnect == "thirdPointToConnect" && StaticBlock.secondPointToConnect == "fourthPointToConnect")
        //    {
        //        if (x1 > x2 && y2 > y1)
        //            myLine = DrawConnectionLine5(x1, y1, x2, y2, firstBlock, secondBlock);
        //        else
        //            myLine = DrawConnectionLine17(x1, y1, x2, y2, firstBlock, secondBlock);
        //    }
        //    else if (StaticBlock.firstPointToConnect == "fourthPointToConnect" && StaticBlock.secondPointToConnect == "thirdPointToConnect")
        //    {
        //        if (x1 < x2 && y2 < y1)
        //            myLine = DrawConnectionLine5(x2, y2, x1, y1, firstBlock, secondBlock);
        //        else
        //            myLine = DrawConnectionLine17(x2, y2, x1, y1, firstBlock, secondBlock);
        //    }
        //    else if (StaticBlock.firstPointToConnect == "fourthPointToConnect" && StaticBlock.secondPointToConnect == "fourthPointToConnect")
        //    {
        //        if ((y1 + DefaultPropertyForBlock.height / 2 <= y2 && y1 > y2) || (y1 <= y2 && y1 >= y2 - DefaultPropertyForBlock.height) || (y1 == y2))
        //            myLine = DrawConnectionLine20(x2, y2, x1, y1, firstBlock, secondBlock);
        //        else if (x2 > x1)
        //            myLine = DrawConnectionLine18(x2, y2, x1, y1, firstBlock, secondBlock);
        //        else if (x2 < x1)
        //            myLine = DrawConnectionLine18(x1, y1, x2, y2, firstBlock, secondBlock);
        //    }
        //    if (myLine != null)
        //    {
        //        firstBlock.SaveLine(myLine);
        //        secondBlock.SaveLine(myLine);
        //    }
        //    StaticBlock.firstPointToConnect = "";
        //    StaticBlock.secondPointToConnect = "";
        //    return myLine;
        //}
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
        int numberOfSavedFilesInCurrentSession = 0;

        private static readonly JsonSerializerOptions jsonSerializerOptions = new()
        {
            AllowTrailingCommas = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
            WriteIndented = true
        };

        private static BlockModel GetDataOfBlockModel(Block itemBlock, string nameOfBlock)
        {
            UIElement? itemBlockUIElement = itemBlock.GetUIElement();
            int height = 0;
            int width = 0;
            if (itemBlockUIElement != null)
            {
                height = (int)((Canvas)itemBlockUIElement).Height;
                width = (int)((Canvas)itemBlockUIElement).Width;
            }
            string textOfBlock = "";
            if (itemBlock.TextBlock != null)
                textOfBlock = itemBlock.TextBlock.Text;
            if (itemBlock.TextBox != null && textOfBlock == "")
                textOfBlock = itemBlock.TextBox.Text;
            double topСoordinates = Canvas.GetTop(itemBlockUIElement);
            double leftСoordinates = Canvas.GetLeft(itemBlockUIElement);
            BlockModel conditionBlockModel = new(nameOfBlock, height, width, textOfBlock, topСoordinates, leftСoordinates);
            return conditionBlockModel;
        }

        private static LineModel GetDataOfLineModel(Line itemLine) => new(itemLine.X1, itemLine.Y1, itemLine.X2, itemLine.Y2);

        private async void SelectedItemViewSave(object sender, RoutedEventArgs e)
        {
            numberOfSavedFilesInCurrentSession++;
            List<BlockModel> listBlockModels = new();
            List<LineModel> listLineModels = new();
            List<CommentModel> listCommentModels = new();
            WinForms.FolderBrowserDialog folderBrowserDialog = new();
            if (folderBrowserDialog.ShowDialog() == WinForms.DialogResult.OK)
            {
                string fileName = folderBrowserDialog.SelectedPath + "\\Flowchart" + numberOfSavedFilesInCurrentSession.ToString() + ".json";
                using FileStream fileStream = new(fileName, FileMode.OpenOrCreate);
                foreach (Block itemBlock in listOfBlock)
                {
                    Type typeOfBlock = itemBlock.GetType();
                    BlockModel blockModel = GetDataOfBlockModel(itemBlock, typeOfBlock.Name);
                    listBlockModels.Add(blockModel);
                }
                foreach (Line itemLine in listLineConnection)
                {
                    LineModel lineModel = GetDataOfLineModel(itemLine);
                    listLineModels.Add(lineModel);
                }

                foreach (Comment itemComment in listComment)
                {
                    LineModel? firstLine = null;
                    if (itemComment.FirstLine != null)
                    {
                        firstLine = GetDataOfLineModel(itemComment.FirstLine);
                        listLineModels.Add(firstLine);
                    }
                    if (itemComment.SecondLine != null)
                    {
                        firstLine = GetDataOfLineModel(itemComment.SecondLine);
                        listLineModels.Add(firstLine);
                    }
                    if (itemComment.ThirdLine != null)
                    {
                        firstLine = GetDataOfLineModel(itemComment.ThirdLine);
                        listLineModels.Add(firstLine);
                    }
                    if (itemComment.FourthLine != null)
                    {
                        firstLine = GetDataOfLineModel(itemComment.FourthLine);
                        listLineModels.Add(firstLine);
                    }
                    if (itemComment.FifthLine != null)
                    {
                        firstLine = GetDataOfLineModel(itemComment.FifthLine);
                        listLineModels.Add(firstLine);
                    }
                    if (itemComment.SixthtLine != null)
                    {
                        firstLine = GetDataOfLineModel(itemComment.SixthtLine);
                        listLineModels.Add(firstLine);
                    }
                    CommentModel commentModel = new(listLineModels);
                    listCommentModels.Add(commentModel);
                }
                BlockAndLineModek blockAndLineModek = new(listBlockModels, listLineModels, listCommentModels);
                await JsonSerializer.SerializeAsync(fileStream, blockAndLineModek, jsonSerializerOptions);
            }
        }

        public Block? SetPropertyFor(Type type, BlockModel blockModel)
        {
            Block? block = null;
            ConstructorInfo? constructorInfo = type.GetConstructor(new Type[] { typeof(MainWindow), typeof(int) });
            if (constructorInfo != null)
            {
                block = (Block)constructorInfo.Invoke(new object[] { this, 0 });
                UIElement uIElementOfBlock = block.GetUIElement();
                if (block.TextBox != null)
                    block.TextBox.Text = blockModel.textOfBlock.ToString();
                block.SetWidth(blockModel.width);
                block.SetHeight(blockModel.height);
                Canvas.SetTop(uIElementOfBlock, blockModel.topCoordinates);
                Canvas.SetLeft(uIElementOfBlock, blockModel.leftCoordinates);
            }
            return block;
        }

        private static Line SetPropertyForLine(LineModel lineModel)
        {
            Line line = new();
            line.X1 = lineModel.x1;
            line.Y1 = lineModel.y1;
            line.X2 = lineModel.x2;
            line.Y2 = lineModel.y2;
            line.Stroke = Brushes.Black;
            return line;
        }

        private static Dictionary<string, Type> GetBlockDictionary()
        {
            var result =
                from a in AppDomain.CurrentDomain.GetAssemblies()
                from t in a.GetTypes()
                let attributes = t.GetCustomAttributes(typeof(BlockName), false)
                where attributes != null && attributes.Length > 0
                select new { name = (attributes[0] as BlockName).Name, type = t };
            return result.ToDictionary(x => x.name, x => x.type);    
        }

        private async void SelectedItemViewUpload(object sender, RoutedEventArgs e)
        {
            WinForms.OpenFileDialog openFileDialog = new()
            {
                Filter = "File json|*.json"
            };
            if (openFileDialog.ShowDialog() == WinForms.DialogResult.OK)
            {
                var blockDictionary = GetBlockDictionary();
                string fileName = openFileDialog.FileName;
                using FileStream fileStream = new(fileName, FileMode.OpenOrCreate);
                BlockAndLineModek? blockAndLineModels = await JsonSerializer.DeserializeAsync<BlockAndLineModek>(fileStream);
                if (blockAndLineModels != null)
                {
                    destination.Children.Clear();
                    listLineConnection.Clear();

                    if (blockAndLineModels.listBlockModels != null)
                    {
                        foreach (BlockModel itemBlockModel in blockAndLineModels.listBlockModels)
                        {
                            Block? block = SetPropertyFor(blockDictionary[itemBlockModel.nameOfBlock], itemBlockModel);
                            if (block != null)
                            {
                                listOfBlock.Add(block);
                                destination.Children.Add(block.GetUIElement());
                            }
                        }
                    }
                    if (blockAndLineModels.listLinekModels != null)
                    {
                        foreach (LineModel itemBlockModel in blockAndLineModels.listLinekModels)
                        {
                            Line line = SetPropertyForLine(itemBlockModel);
                            destination.Children.Add(line);
                        }
                    }
                    if (blockAndLineModels.listCommentsModels != null)
                    {
                        foreach (CommentModel itemBlockModel in blockAndLineModels.listCommentsModels)
                        {
                            Line line = new();
                            foreach (LineModel itemLine in itemBlockModel.listModel)
                            {
                                line = SetPropertyForLine(itemLine);
                                listLineConnection.Add(line);
                                destination.Children.Add(line);
                            }
                        }
                    }
                }
            }
        }
    }
}