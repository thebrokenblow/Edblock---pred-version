using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Flowchart_Editor.View;
using System.Windows.Shapes;
using Flowchart_Editor.Models;
using System.Windows.Controls;
using System.Collections.Generic;
using Flowchart_Editor.Models.Comment;
using Flowchart_Editor.View.ConditionCaseSecondOption;
using Flowchart_Editor.View.ConditionCaseFirstOption;
using Flowchart_Editor.Menu.SaveImg;
using Flowchart_Editor.Menu.Print;
using Flowchart_Editor.Menu.SaveProject;
using Flowchart_Editor.View.Condition.Case;
using Flowchart_Editor.Menu.UploadProject;
using Flowchart_Editor.Menu.Theme;
using Flowchart_Editor.ViewModel;

namespace Flowchart_Editor
{
    public partial class Edblock : Window
    {
        const int minHeight = 760;
        const int minWidth = 1380;
        const int valueOffsetOfLineFromTheBlockToSides = 20;
        public static UIElement? EditField { get; private set; }


        public Edblock()
        {
            InitializeComponent();
            DataContext = new ApplicationViewModel();
            EditField = destination;
            MinHeight = minHeight;
            MinWidth = minWidth;
            toggleButtonStyleTheme.Click += ThemeChange;
            ThemeChange();

            for (int i = 110; i <= 250; i += 10)
                blockWidthComboBox.Items.Add(i);

            for (int i = 60; i <= 250; i += 10)
                blockHeightComboBox.Items.Add(i);
        }
        public void RemoveUIElemet(UIElement? uIElement)
        {
            destination.Children.Remove(uIElement);
        }
        public void RemoveBlock(UIElement? uIElement, Block block, Line[]? firstLine, Line[]? secondLine, Line[]? thirdLine, Line[]? fourthLine)
        {
            destination.Children.Remove(uIElement);
            listOfBlock.Remove(block);

            if (firstLine != null)
            {
                foreach (Line line in firstLine)
                {
                    destination.Children.Remove(line);
                    listLineConnection.Remove(line);
                }
            }
            if (secondLine != null)
            {
                foreach (Line line in secondLine)
                {
                    destination.Children.Remove(line);
                    listLineConnection.Remove(line);
                }
            }
            if (thirdLine != null)
            {
                foreach (Line line in thirdLine)
                {
                    destination.Children.Remove(line);
                    listLineConnection.Remove(line);
                }
            }
            if (fourthLine != null)
            {
                foreach (Line line in fourthLine)
                {
                    destination.Children.Remove(line);
                    listLineConnection.Remove(line);
                }
            }
        }

        private void ThemeChange(object? sender = null, RoutedEventArgs? e = null) =>
            Theme.SetTheme(toggleButtonStyleTheme); 
        
        public static readonly List<Block> listOfBlock = new();
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

        public static  List<CommentControls> listComment = new();
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

        public void MessageThisLineIsAlreadyOccupied() => 
            MessageBox.Show("Эта линия уже занята");

        public void RemoveBlockFormList(Block block) => listOfBlock.Remove(block);

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

        private void SelectionChangedBlockWidthComboBox(object sender, SelectionChangedEventArgs e)
        {
            int valueBlockWidth = Convert.ToInt32(blockWidthComboBox.SelectedItem);
            DefaultPropertyForBlock.width = valueBlockWidth;

            foreach (Block itemListOfBlock in listOfBlock)
                itemListOfBlock.SetWidth(valueBlockWidth);

            foreach (CommentControls itemListComment in listComment)
                itemListComment.SetWidth(valueBlockWidth);

            foreach (CaseBlock itemCaseBlock in listCaseBlock)
                itemCaseBlock.SetWidth(valueBlockWidth);

            foreach (Line itemLineConnection in listLineConnection)
            {
                itemLineConnection.X1 += 5;
                itemLineConnection.X2 += 5;
            }
        }

        private void SelectionChangedBlockHeightComboBox(object sender, SelectionChangedEventArgs e)
        {
            int valueBlokHeight = Convert.ToInt32(blockHeightComboBox.SelectedItem);
            DefaultPropertyForBlock.height = valueBlokHeight;

            foreach (Block itemListOfBlock in listOfBlock)
                itemListOfBlock.SetHeight(valueBlokHeight);

            foreach (CommentControls itemListComment in listComment)
                itemListComment.SetHeight(valueBlokHeight);

            foreach (CaseBlock itemCaseBlock in listCaseBlock)
                itemCaseBlock.SetHeight(valueBlokHeight);

            foreach (Line itemLineConnection in listLineConnection)
            {
                //if (itemLineConnection.Y1 == itemLineConnection.Y2)
                //{
                //    itemLineConnection.Y1 += 10;
                //    itemLineConnection.Y2 += 10;
                //}
               //TODO: Реализовать изменение координат линий 
                {
                    itemLineConnection.Y1 += 10;
                    itemLineConnection.Y2 += 10;
                }
            }
        }

        public static readonly List<Line> listLineConnection = new();
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

        public Line[]? DrawConnectionLine(double x1, double y1, double x2, double y2, Block firstBlock, Block secondBlock)
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
                if ((bool)StaticBlock.ISOOriginLines && !(bool)StaticBlock.ISOLineEntry)
                {
                    if (StaticBlock.firstPointToConnect == "fourthPointToConnect" && StaticBlock.secondPointToConnect == "firstPointToConnect")
                    {
                        if (y2 > y1 && x1 >= x2)
                            lines = DrawConnectionLine4(x2, y2, x1, y1);
                        else if (y2 > y1 && x1 <= x2)
                            lines = DrawConnectionLine5(x2, y2, x1, y1);
                        else if (y1 > y2)
                            lines = DrawConnectionLine6(x2, y2, x1, y1);
                    }
                    else if (StaticBlock.firstPointToConnect == "fourthPointToConnect" && StaticBlock.secondPointToConnect == "secondPointToConnect")
                    {
                        if (x2 > x1)
                            lines = DrawConnectionLine14(x1, y1, x2, y2);
                        else
                            lines = DrawConnectionLine13(x1, y1, x2, y2);
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
                    else if (StaticBlock.firstPointToConnect == "thirdPointToConnect" && StaticBlock.secondPointToConnect == "firstPointToConnect")
                    {
                        firstBlock.flagForEnteringThirdConnectionPointAndFirst = true;
                        secondBlock.flagForEnteringFirstConnectionPointAndThird = true;
                        if (x1 != x2 && y2 > y1)
                            lines = DrawConnectionLine1(x1, y1, x2, y2);
                        else if ((x2 - x1) > DefaultPropertyForBlock.height)
                            lines = DrawConnectionLine2(x2, y2, x1, y1);
                        else if (x1 == x2)
                            lines = DrawConnectionLine3(x1, y1, x2, y2);
                    }
                    else if (StaticBlock.firstPointToConnect == "thirdPointToConnect" && StaticBlock.secondPointToConnect == "secondPointToConnect")
                    {
                        if (x1 < x2 && y2 > y1)
                            lines = DrawConnectionLine5(x1, y1, x2, y2);
                        else
                            lines = DrawConnectionLine12(x1, y1, x2, y2);
                    }
                    else
                    {
                        MessageBox.Show("Ошибка соединения блоков");
                        WriteFirstNameOfBlockToConect("");
                        WriteSecondNameOfBlockToConect("");
                        StaticBlock.firstPointToConnect = "";
                        StaticBlock.secondPointToConnect = "";
                    }
                }
                else if (!(bool)StaticBlock.ISOOriginLines && (bool)StaticBlock.ISOLineEntry)
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
                    else if (StaticBlock.firstPointToConnect == "firstPointToConnect" && StaticBlock.secondPointToConnect == "thirdPointToConnect")
                    {
                        firstBlock.flagForEnteringFirstConnectionPointAndThird = true;
                        secondBlock.flagForEnteringThirdConnectionPointAndFirst = true;
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
                    else
                    {
                        MessageBox.Show("Ошибка соединения блоков");
                        WriteFirstNameOfBlockToConect("");
                        WriteSecondNameOfBlockToConect("");
                        StaticBlock.firstPointToConnect = "";
                        StaticBlock.secondPointToConnect = "";
                    }
                }
                else if (StaticBlock.ISOOriginLines != null && StaticBlock.ISOLineEntry != null)
                {
                    if ((bool)StaticBlock.ISOOriginLines && (bool)StaticBlock.ISOLineEntry)
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
                            firstBlock.flagForEnteringThirdConnectionPointAndFirst = true;
                            secondBlock.flagForEnteringFirstConnectionPointAndThird = true;
                            if (x1 != x2 && y2 > y1)
                                lines = DrawConnectionLine1(x1, y1, x2, y2);
                            else if ((x2 - x1) > DefaultPropertyForBlock.height)
                                lines = DrawConnectionLine2(x2, y2, x1, y1);
                            else if (x1 == x2)
                                lines = DrawConnectionLine3(x1, y1, x2, y2);
                        }
                        else if (StaticBlock.firstPointToConnect == "firstPointToConnect" && StaticBlock.secondPointToConnect == "thirdPointToConnect")
                        {
                            firstBlock.flagForEnteringFirstConnectionPointAndThird = true;
                            secondBlock.flagForEnteringThirdConnectionPointAndFirst = true;
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
                    else
                    {
                        MessageBox.Show("Ошибка соединения блоков");
                        WriteFirstNameOfBlockToConect("");
                        WriteSecondNameOfBlockToConect("");
                        StaticBlock.firstPointToConnect = "";
                        StaticBlock.secondPointToConnect = "";
                    }
                }
            }

            StaticBlock.firstPointToConnect = "";
            StaticBlock.secondPointToConnect = "";
            return lines;
        }

        public void WriteFirstNameOfBlockToConect(string nameOfFirstBlockToConnect)
        {
            textNameOfFirstBlockToConnect.Text = nameOfFirstBlockToConnect;
            textNameOfSecondBlockToConnect.Text = "";
        }

        public void WriteSecondNameOfBlockToConect(string nameOfSecondBlockToConnect) => 
            textNameOfSecondBlockToConnect.Text = nameOfSecondBlockToConnect;
        
        private void MouseLeftButtonDownComment(object sender, MouseButtonEventArgs e)
        {
            string textOfComment = CommentControls.GetTextOfComment();
            WriteFirstNameOfBlockToConect(textOfComment);
            PinningComment.flagPinningComment = true;
        }

        private string? GetFontFamily() => 
            listOfFontFamily.SelectedValue?.ToString();

        public string? GetFontSize() => 
            ((ComboBoxItem)fontSizeComboBox.SelectedItem)?.Content.ToString();
        
        private void ClickSaveProject(object sender, RoutedEventArgs e) =>
            SaveProject.Save(GetFontFamily(), GetFontSize()); 

        private void ClickUploadProject(object sender, RoutedEventArgs e) =>
            UploadProject.Upload(destination, listOfBlock, listLineConnection, listComment, 
                listCaseBlock, listOfFontFamily, fontSizeComboBox, blockWidthComboBox, blockHeightComboBox);

        public static readonly List<CaseBlock> listCaseBlock = new();
        private void AddConditionCaseFirstOption(object sender, RoutedEventArgs e)
        {
            try
            {
                int countLineOfConditionCaseFirstOption = Convert.ToInt32(CountLineOfConditionCaseFirstOption.Text);
                if (countLineOfConditionCaseFirstOption > 0)
                {
                    if (countLineOfConditionCaseFirstOption == 1)
                        MessageBox.Show("Введите большое число выходов из фигуры Условие");
                    else
                    {
                        CaseFirstOption conditionCaseFirstOptionBlock = new(this, 0, countLineOfConditionCaseFirstOption);
                        destination.Children.Add(conditionCaseFirstOptionBlock.GetUIElement());
                        listCaseBlock.Add(conditionCaseFirstOptionBlock);
                    }
                }
                else
                {
                    MessageBox.Show("Число изходящих линий должно быть положительным");
                }
            }
            catch
            {
                MessageBox.Show("Ошибка ввода");
            }
        }

        public void RemoveItemFromListCaseBlock(CaseBlock caseBlock) =>
            listCaseBlock.Remove(caseBlock);

        private void AddConditionCaseSecondOption(object sender, RoutedEventArgs e)
        {
            try
            {
                int countLineOfConditionCaseSecondOption = Convert.ToInt32(CountLineOfConditionCaseSecondOption.Text);
                if (countLineOfConditionCaseSecondOption > 0)
                {
                    if (countLineOfConditionCaseSecondOption == 1)
                        MessageBox.Show("Введите большое число выходов из фигуры Условие");
                    else
                    {
                        CaseSecondOption conditionCaseSecondOptionBlock = new(this, 0, countLineOfConditionCaseSecondOption);
                        listCaseBlock.Add(conditionCaseSecondOptionBlock);
                        destination.Children.Add(conditionCaseSecondOptionBlock.GetUIElement());
                    }
                }
                else
                {
                     MessageBox.Show("Число изходящих линий должно быть положительным");
                }
            }
            catch
            {
                MessageBox.Show("Ошибка ввода");
            }
        }
        private void SelectionChangedFontSize(object sender, SelectionChangedEventArgs e) =>
            StaticBlock.fontSize = Convert.ToInt32(((ComboBoxItem)fontSizeComboBox.SelectedItem)?.Content.ToString());
        private void ClickSettings(object sender, RoutedEventArgs e)
        {
            Settings settings = new();
            settings.Show();
        }
    }
}