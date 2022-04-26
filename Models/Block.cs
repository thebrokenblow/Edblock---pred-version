using Flowchart_Editor.Models.Action;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Flowchart_Editor.Models
{
    public abstract class Block
    {
        protected Canvas? canvas;
        protected Rectangle? rectangle = null;
        protected TextBox? textBox;
        protected TextBlock? textBlock;
        protected Ellipse? firstPointToConnect;
        protected Ellipse? secondPointToConnect;
        protected Ellipse? thirdPointToConnect;
        protected Ellipse? fourthPointToConnect;
        protected Line? firstLineConnectionBlock;
        protected Line? secondLineConnectionBlock;
        protected Line? thirdLineConnectionBlock;
        protected Line? fourthLineConnectionBlock;
        protected Block? mainBlock;
        protected Block? firstBlock;
        protected Block? secondBlock;
        protected Block? thirdBlock;
        protected Block? fourthBlock;
        protected Ellipse? ellipse;
        protected object? firstSenderMainBlock;
        protected object? secondSenderMainBlock;
        protected object? thirdSenderMainBlock;
        protected object? fourthSenderMainBlock;
        protected object? firstSenderBlock;
        protected object? secondSenderBlock;
        protected object? thirdSenderBlock;
        protected object? fourthSenderBlock;
        protected bool textChangeStatus = false;
        protected bool flagForEnteringFirstConnectionPoint = false;
        protected bool flagForEnteringSecondConnectionPoint = false;
        protected bool flagForEnteringThirdConnectionPoint = false;
        protected bool flagForEnteringFourthConnectionPoint = false;
        protected int numberOfOccurrencesInBlock = 0;
        protected int valueOfClicksOnTextBlock = 0;
        protected int keyOfBlock = 0;
        protected const int radiusPoint = 6;
        protected readonly FontFamily defaultFontFamily = DefaultPropertyForBlock.fontFamily;
        protected readonly string defaulColorPoint = DefaultPropertyForBlock.colorPoint;
        protected readonly int defaulFontSize = DefaultPropertyForBlock.fontSize;

        public UIElement? GetUIElementWithoutCreate() => canvas;

        public Canvas? GetCanvas() => canvas;

        public Block? GetMainBlock() => mainBlock;

        public object? GetFirstSenderMainBlock() => firstSenderMainBlock;

        public object? GetSecondSenderMainBlock() => secondSenderMainBlock;

        public object? GetThirdSenderMainBlock() => thirdSenderMainBlock;

        public object? GetFourthSenderMainBlock() => fourthSenderMainBlock;

        public int GetNumberOfOccurrencesInBlock() => numberOfOccurrencesInBlock;

        protected void MouseMoveBlockForMovements(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && textChangeStatus)
            {
                BlockForMovements instanceOfActionBlockForMovements = new(sender,
                    mainBlock, firstBlock, secondBlock, thirdBlock, fourthBlock, firstSenderMainBlock,
                    secondSenderMainBlock, thirdSenderMainBlock, fourthSenderMainBlock, firstSenderBlock, secondSenderBlock,
                    thirdSenderBlock, fourthSenderBlock, firstLineConnectionBlock, secondLineConnectionBlock, thirdLineConnectionBlock,
                    fourthLineConnectionBlock, numberOfOccurrencesInBlock);

                var dataObjectInformationOfActionBlock = new DataObject(typeof(BlockForMovements), instanceOfActionBlockForMovements);
                DragDrop.DoDragDrop(sender as DependencyObject, dataObjectInformationOfActionBlock, DragDropEffects.Copy);
            }
            e.Handled = true;
        }
        protected void SetPropertyForFirstPointToConnect(double valueForSetLeft, double valueForSetTop, Brush? defaulColorPoint = null)
        {
            if (firstPointToConnect != null)
            {
                if (defaulColorPoint != null)
                    firstPointToConnect.Fill = defaulColorPoint;
                firstPointToConnect.Height = radiusPoint;
                firstPointToConnect.Width = radiusPoint;
                Canvas.SetLeft(firstPointToConnect, valueForSetLeft);
                Canvas.SetTop(firstPointToConnect, valueForSetTop);
            }
        }
        protected void SetPropertyForSecondPointToConnect(double valueForSetLeft, double valueForSetTop, Brush? defaulColorPoint = null)
        {
            if (secondPointToConnect != null)
            {
                if (defaulColorPoint != null)
                    secondPointToConnect.Fill = defaulColorPoint;
                secondPointToConnect.Height = radiusPoint;
                secondPointToConnect.Width = radiusPoint;
                Canvas.SetLeft(secondPointToConnect, valueForSetLeft);
                Canvas.SetTop(secondPointToConnect, valueForSetTop);
            }
        }
        protected void SetPropertyForThirdPointToConnect(double valueForSetLeft, double valueForSetTop, Brush? defaulColorPoint = null)
        {
            if (thirdPointToConnect != null)
            {
                if (defaulColorPoint != null)
                    thirdPointToConnect.Fill = defaulColorPoint;
                thirdPointToConnect.Height = radiusPoint;
                thirdPointToConnect.Width = radiusPoint;
                Canvas.SetLeft(thirdPointToConnect, valueForSetLeft);
                Canvas.SetTop(thirdPointToConnect, valueForSetTop);
            }
        }
        protected void SetPropertyForFourthPointToConnect(double valueForSetLeft, double valueForSetTop, Brush? defaulColorPoint = null)
        {
            if (fourthPointToConnect != null)
            {
                if (defaulColorPoint != null)
                    fourthPointToConnect.Fill = defaulColorPoint;
                fourthPointToConnect.Height = radiusPoint;
                fourthPointToConnect.Width = radiusPoint;
                Canvas.SetLeft(fourthPointToConnect, valueForSetLeft);
                Canvas.SetTop(fourthPointToConnect, valueForSetTop);
            }
        }
        protected void AddChildrenForCanvas()
        {
            if (canvas != null)
            {
                canvas.Children.Add(textBox);
                canvas.Children.Add(firstPointToConnect);
                canvas.Children.Add(secondPointToConnect);
                canvas.Children.Add(thirdPointToConnect);
                canvas.Children.Add(fourthPointToConnect);
                canvas.MouseMove += MouseMoveBlockForMovements;
            }
        }
        protected void SetPropertyForTextBox(int defaultWidth, int defaulHeight, string? textOfBlock = null, double valueForSetLeft = 0, double valueForSetTop = 0)
        {
            if (textBox != null)
            {
                if (textOfBlock != null)
                    textBox.Text = textOfBlock;
                textBox.Width = defaultWidth;
                textBox.Height = defaulHeight;
                textBox.FontSize = defaulFontSize;
                textBox.FontFamily = defaultFontFamily;
                textBox.VerticalAlignment = VerticalAlignment.Center;
                textBox.HorizontalAlignment = HorizontalAlignment.Center;
                textBox.TextAlignment = TextAlignment.Center;
                textBox.Foreground = Brushes.White;
                textBox.TextWrapping = TextWrapping.Wrap;
                textBox.AcceptsReturn = true;
                textBox.MouseDoubleClick += ChangeTextBoxToTextBlock;
                if (valueForSetLeft != 0)
                    Canvas.SetLeft(textBox, valueForSetLeft);
                if (valueForSetTop != 0)
                    Canvas.SetTop(textBox, valueForSetTop);
                
            }
        }
        protected void SetPropertyForTextBlock(int defaultWidth, int defaulHeight, double valueForSetLeft = 0, double valueForSetTop = 0)
        {
            if (textBlock != null)
            {
                textBlock.Width = defaultWidth;
                textBlock.Height = defaulHeight;
                textBlock.FontSize = defaulFontSize;
                textBlock.FontFamily = defaultFontFamily;
                textBlock.VerticalAlignment = VerticalAlignment.Center;
                textBlock.HorizontalAlignment = HorizontalAlignment.Center;
                textBlock.TextAlignment = TextAlignment.Center;
                textBlock.Foreground = Brushes.White;
                textBlock.TextWrapping = TextWrapping.Wrap;
                textBlock.MouseDown += ChangeTextBoxToTextBlock;
                if (valueForSetLeft != 0)
                    Canvas.SetLeft(textBox, valueForSetLeft);
                if (valueForSetTop != 0)
                    Canvas.SetTop(textBox, valueForSetTop);
            }
        }
        protected static bool CheckForZeroCoordinates(double coordinatesBlockPointX, double coordinatesBlockPointY) => coordinatesBlockPointX == 0 && coordinatesBlockPointY == 0;
        protected double GetCoordinatesX(object sender) => Canvas.GetLeft((Ellipse)sender) + Canvas.GetLeft(canvas) + 3;
        protected double GetCoordinatesY(object sender) => Canvas.GetTop((Ellipse)sender) + Canvas.GetTop(canvas) + 3;

        protected static void SeveCoordinates(double coordinatesBlockPointX, double coordinatesBlockPointY)
        {
            CoordinatesBlock.coordinatesBlockPointX = coordinatesBlockPointX;
            CoordinatesBlock.coordinatesBlockPointY = coordinatesBlockPointY;
        }
        protected void SaveControlsForConnectionPointToOutgoingLine(object sender)
        {
            switch (numberOfOccurrencesInBlock)
            {
                case 1:
                    mainBlock = this;
                    firstSenderMainBlock = sender;
                    break;
                case 2:
                    secondSenderMainBlock = sender;
                    break;
                case 3:
                    thirdSenderMainBlock = sender;
                    break;
                case 4:
                    fourthSenderMainBlock = sender;
                    break;
            }
        }
        protected void SaveСontrolsForConnectionPointToIncomingLine(object sender)
        {
            switch (numberOfOccurrencesInBlock)
            {
                case 1:
                    mainBlock = this;
                    StaticBlock.block = this;
                    firstSenderMainBlock = sender;
                    break;
                case 2:
                    StaticBlock.block = this;
                    secondSenderMainBlock = sender;
                    break;
                case 3:
                    StaticBlock.block = this;
                    thirdSenderMainBlock = sender;
                    break;
                case 4:
                    StaticBlock.block = this;
                    fourthSenderMainBlock = sender;
                    break;
            }
        }
        protected void GetDataForCoordinates(object sender, string initialText, MainWindow mainWindow)
        {
            bool checkForZeroCoordinates = CheckForZeroCoordinates(CoordinatesBlock.coordinatesBlockPointX, CoordinatesBlock.coordinatesBlockPointY);
            if (checkForZeroCoordinates)
            {
                double coordinatesBlockPointX = GetCoordinatesX(sender);
                double coordinatesBlockPointY = GetCoordinatesY(sender);

                SeveCoordinates(coordinatesBlockPointX, coordinatesBlockPointY);
                numberOfOccurrencesInBlock++;

                CoordinatesBlock.keyFirstBlock = keyOfBlock;

                SaveСontrolsForConnectionPointToIncomingLine(sender);

                mainWindow.WriteFirstNameOfBlockToConect(initialText);
            }
            else
            {
                double x1 = CoordinatesBlock.coordinatesBlockPointX;
                double y1 = CoordinatesBlock.coordinatesBlockPointY;

                double x2 = GetCoordinatesX(sender);
                double y2 = GetCoordinatesY(sender);

                CoordinatesBlock.keySecondBlock = keyOfBlock;

                mainWindow.WriteSecondNameOfBlockToConect(initialText);

                numberOfOccurrencesInBlock++;

                SaveControlsForConnectionPointToOutgoingLine(sender);

                if (StaticBlock.block != null)
                {
                    if (firstLineConnectionBlock == null)
                    {
                        Line? line = mainWindow.DrawConnectionLine(x1, y1, x2, y2);
                        if (line != null)
                        {
                            firstLineConnectionBlock = line;
                            SavingСontrols.Save(StaticBlock.block, this, line);
                        }
                        else numberOfOccurrencesInBlock -= 2;
                    }
                    else if (secondLineConnectionBlock == null)
                    {
                        Line? line = mainWindow.DrawConnectionLine(x1, y1, x2, y2);
                        if (line != null)
                        {
                            secondLineConnectionBlock = line;
                            SavingСontrols.Save(StaticBlock.block, this, line);
                        }
                        else numberOfOccurrencesInBlock -= 2;
                    }
                    else if (thirdLineConnectionBlock == null)
                    {
                        Line? line = mainWindow.DrawConnectionLine(x1, y1, x2, y2);
                        if (line != null)
                        {
                            thirdLineConnectionBlock = line;
                            SavingСontrols.Save(StaticBlock.block, this, line);
                        }
                        else numberOfOccurrencesInBlock -= 2;
                    }
                    else if (fourthLineConnectionBlock == null)
                    {
                        Line? line = mainWindow.DrawConnectionLine(x1, y1, x2, y2);
                        if (line != null)
                        {
                            fourthLineConnectionBlock = line;
                            SavingСontrols.Save(StaticBlock.block, this, line);
                        }
                        else numberOfOccurrencesInBlock -= 2;
                    }
                }
                CoordinatesBlock.coordinatesBlockPointX = 0;
                CoordinatesBlock.coordinatesBlockPointY = 0;
            }
        }
        protected void SetPropertyForCanvas(int defaultWidth, int defaulHeight, Brush? backgroundColor = null)
        {
            if (canvas != null)
            {
                canvas.Width = defaultWidth;
                canvas.Height = defaulHeight;
                canvas.Background = backgroundColor;
            }
        }
        protected void SetPropertyForEllipse(int defaultWidth, int defaulHeight, Brush backgroundColor)
        {
            if (ellipse != null)
            {
                ellipse.Width = defaultWidth;
                ellipse.Height = defaulHeight;
                ellipse.Fill = backgroundColor;
            }
        }
        protected void ChangeTextBoxToTextBlock(object sender, MouseEventArgs e)
        {
            if (canvas != null && textBlock != null && textBox != null)
            {
                if (textChangeStatus)
                {
                    valueOfClicksOnTextBlock++;
                    if (valueOfClicksOnTextBlock == 2)
                    {
                        canvas.Children.Remove(textBox);
                        canvas.Children.Remove(textBlock);
                        textBox.Text = textBlock.Text;
                        canvas.Children.Add(textBox);
                        textChangeStatus = false;
                        valueOfClicksOnTextBlock = 0;
                    }
                }
                else
                {
                    canvas.Children.Remove(textBox);
                    canvas.Children.Remove(textBlock);
                    textBlock.Text = textBox.Text;
                    Canvas.SetTop(textBlock, 3.5);
                    canvas.Children.Add(textBlock);
                    textChangeStatus = true;
                }
            }
        }
        public void SetFillOfPointToConnect(string darkWhite)
        {
            if (firstPointToConnect != null && secondPointToConnect != null &&
                thirdPointToConnect != null && fourthPointToConnect != null)
            {
                BrushConverter color = new();
                firstPointToConnect.Fill = (Brush)color.ConvertFrom(darkWhite);
                secondPointToConnect.Fill = (Brush)color.ConvertFrom(darkWhite);
                thirdPointToConnect.Fill = (Brush)color.ConvertFrom(darkWhite);
                fourthPointToConnect.Fill = (Brush)color.ConvertFrom(darkWhite);
            }
        }
        public void SetFontFamily(FontFamily fontFamily)
        {
            if (textBox != null && textBlock != null)
            {
                textBox.FontFamily = fontFamily;
                textBlock.FontFamily = fontFamily;
            }
        }
        public void SetFontSize(int valueFontSize)
        {
            if (textBox != null && textBlock != null)
            {
                textBox.FontSize = valueFontSize;
                textBlock.FontSize = valueFontSize;
            }
        }
        public void SetWidthOfBlock(int valueBlokWidth)
        {
            if (canvas != null && textBox != null && textBlock != null)
            {
                canvas.Width = valueBlokWidth;                 
                textBox.Width = valueBlokWidth;
                textBlock.Width = valueBlokWidth;
                if (rectangle != null)
                {
                    rectangle.Width = valueBlokWidth;
                    SetPropertyForTextBox(valueBlokWidth - 20, DefaultPropertyForBlock.height / 2 - 3, valueForSetLeft: 10);
                }
                Canvas.SetLeft(firstPointToConnect, valueBlokWidth / 2 - 2);
                Canvas.SetLeft(thirdPointToConnect, valueBlokWidth / 2 - 2);
                Canvas.SetLeft(fourthPointToConnect, valueBlokWidth - 4);
            }
        }

        public void SetHeightOfBlock(int valueBlokHeight)
        {
            if (canvas != null && textBox != null && textBlock != null)
            {
                canvas.Height = valueBlokHeight;
                textBox.Height = valueBlokHeight;
                textBlock.Height = valueBlokHeight;
                if (rectangle != null)
                {
                    rectangle.Height = valueBlokHeight;
                    SetPropertyForTextBox(DefaultPropertyForBlock.width - 20, valueBlokHeight - 3, valueForSetLeft: 10);
                }
                Canvas.SetTop(secondPointToConnect, valueBlokHeight / 2 - 2);
                Canvas.SetTop(thirdPointToConnect, valueBlokHeight - 4);
                Canvas.SetTop(fourthPointToConnect, valueBlokHeight / 2 - 2);
            }
        }
        public void SetValueSenderOfBlockWithSingleLineOccurrence(Block block, object sender, Line lineConnection)
        {
            firstBlock = block;
            firstSenderBlock = sender;
            firstLineConnectionBlock = lineConnection;
        }
        public void SetValueSenderOfBlockWithTwoLineOccurrence(Block block, object sender, Line lineConnection)
        {
            secondBlock = block;
            secondSenderBlock = sender;
            secondLineConnectionBlock = lineConnection;
        }
        public void SetValueSenderOfBlockWithThreeLineOccurrence(Block block, object sender, Line lineConnection)
        {
            thirdBlock = block;
            thirdSenderBlock = sender;
            thirdLineConnectionBlock = lineConnection;
        }
        public void SetValueSenderOfBlockWithFourLineOccurrence(Block block, object sender, Line lineConnection)
        {
            fourthBlock = block;
            fourthSenderBlock = sender;
            fourthLineConnectionBlock = lineConnection;
        }
        public void SetValueSenderOfFirstBlock(object sender)
        {
            firstSenderBlock = sender;
        }
        public void SetValueSenderOfSecondBlock(object sender)
        {
            secondSenderBlock = sender;
        }
        public void SetValueSenderOfThirdBlock(object sender)
        {
            thirdSenderBlock = sender;
        }
        public void SetValueSenderOfFourthBlock(object sender)
        {
            fourthSenderBlock = sender;
        }
        public void SetFirstBlock(Block block)
        {
            firstBlock = block;
        }
        public void SetSecondBlock(Block block)
        {
            secondBlock = block;
        }
        public void SetThirdBlock(Block block)
        {
            thirdBlock = block;
        }
        public void SetFourthBlock(Block block)
        {
            fourthBlock = block;
        }
        public void Reset()
        {
            canvas = null;
        }
    }
}