using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using Flowchart_Editor.Models.Comment;

namespace Flowchart_Editor.Models
{
    public abstract class Block
    {
        protected Canvas? canvas;
        public TextBox? TextBox { get; set; }
        public Edblock? MainWindow { get; set; }
        public TextBlock? TextBlock { get; set; }
        public CommentControls? comment;
        protected Ellipse? firstPointToConnect;
        protected Ellipse? secondPointToConnect;
        protected Ellipse? thirdPointToConnect;
        protected Ellipse? fourthPointToConnect;
        public Line[]? FirstLineConnectionBlock { get; set; }
        public Line[]? SecondLineConnectionBlock { get; set; }
        public Line[]? ThirdLineConnectionBlock { get; set; }
        public Line[]? FourthLineConnectionBlock { get; set; }
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
        public bool flagForEnteringFirstConnectionPoint = false;
        public bool flagForEnteringSecondConnectionPoint = false;
        public bool flagForEnteringThirdConnectionPoint = false;
        public bool flagForEnteringFourthConnectionPoint = false;
        public bool flagForEnteringThirdConnectionPointAndFirst = false;
        public bool flagForEnteringFirstConnectionPointAndThird = false;
        public int numberOfOccurrencesInBlock = 0;
        protected int valueOfClicksOnTextBlock = 0;
        protected int keyOfBlock = 0;
        public bool? flag = null;
        public bool flagCase = false;
        protected const int radiusPoint = 6;
        protected double blockWidthCoefficient;
        protected double blockHeightCoefficient;
        protected string? initialText;
        protected readonly FontFamily defaultFontFamily = DefaultPropertyForBlock.fontFamily;
        protected readonly Uri uri = new("WindowsTheme/theme.xaml", UriKind.Relative);

        abstract public UIElement GetUIElement();

        public void SetComment(string textOfComment)
        {
            CommentControls commentControls = new(blockWidthCoefficient, blockHeightCoefficient);
            comment = commentControls;
            UIElement commentUIElement = comment.GetUIElement();
            SetСoordinatesComment(commentUIElement);
            comment.TextBox.Text = textOfComment;
            if (canvas != null)
                canvas.Children.Add(commentUIElement); 
        }

        public abstract void SetLeftBlockForConditionCaseFirstOption(UIElement uIElementBlock, double coordinateLeft);
        public abstract void SetTopBlockForConditionCaseFirstOption(UIElement uIElementBlock, double coordinateTop);
        public abstract void SetLeftBlockForConditionCaseSecondOption(UIElement uIElementBlock, double coordinateLeft);
        public abstract void SetTopBlockForConditionCaseSecondOption(UIElement uIElementBlock, double coordinateTop);
        public abstract double GetWidthCoefficient();
        public abstract double GetHeightCoefficient();
        public Canvas? GetCanvas() => canvas;

        public Block? GetMainBlock() => mainBlock;

        public object? GetFirstSenderMainBlock() => firstSenderMainBlock;

        public object? GetSecondSenderMainBlock() => secondSenderMainBlock;

        public object? GetThirdSenderMainBlock() => thirdSenderMainBlock;

        public object? GetFourthSenderMainBlock() => fourthSenderMainBlock;

        public int GetNumberOfOccurrencesInBlock() => numberOfOccurrencesInBlock;
      
        protected void MouseMoveBlockForMovements(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                if (!flagCase && !(e.OriginalSource is TextBox))
                    Edblock.DoDragDropControlElement(typeof(Canvas), sender, sender);

            e.Handled = true;
        }
        protected void SetPropertyForFirstPointToConnect(double valueForSetLeft, double valueForSetTop)
        {
            if (firstPointToConnect != null)
            {
                if (Application.LoadComponent(uri) is ResourceDictionary resourceDict)
                    firstPointToConnect.Style = resourceDict["EllipseStyle"] as Style;

                firstPointToConnect.Height = radiusPoint;
                firstPointToConnect.Width = radiusPoint;
                Canvas.SetLeft(firstPointToConnect, valueForSetLeft);
                Canvas.SetTop(firstPointToConnect, valueForSetTop);
            }
        }
        protected void SetPropertyForSecondPointToConnect(double valueForSetLeft, double valueForSetTop)
        {
            if (secondPointToConnect != null)
            {
                if (Application.LoadComponent(uri) is ResourceDictionary resourceDict)
                    secondPointToConnect.Style = resourceDict["EllipseStyle"] as Style;
                secondPointToConnect.Height = radiusPoint;
                secondPointToConnect.Width = radiusPoint;
                Canvas.SetLeft(secondPointToConnect, valueForSetLeft);
                Canvas.SetTop(secondPointToConnect, valueForSetTop);
            }
        }
        protected void SetPropertyForThirdPointToConnect(double valueForSetLeft, double valueForSetTop)
        {
            if (thirdPointToConnect != null)
            {
                if (Application.LoadComponent(uri) is ResourceDictionary resourceDict)
                    thirdPointToConnect.Style = resourceDict["EllipseStyle"] as Style;
                thirdPointToConnect.Height = radiusPoint;
                thirdPointToConnect.Width = radiusPoint;
                Canvas.SetLeft(thirdPointToConnect, valueForSetLeft);
                Canvas.SetTop(thirdPointToConnect, valueForSetTop);
            }
        }
        protected void SetPropertyForFourthPointToConnect(double valueForSetLeft, double valueForSetTop)
        {
            if (fourthPointToConnect != null)
            {
                if (Application.LoadComponent(uri) is ResourceDictionary resourceDict)
                    fourthPointToConnect.Style = resourceDict["EllipseStyle"] as Style;
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
                canvas.Children.Add(TextBox);
                canvas.Children.Add(firstPointToConnect);
                canvas.Children.Add(secondPointToConnect);
                canvas.Children.Add(thirdPointToConnect);
                canvas.Children.Add(fourthPointToConnect);
                canvas.MouseMove += MouseMoveBlockForMovements;
            }
        }

        protected void SetPropertyForTextBox(int defaultWidth, int defaulHeight, string? textOfBlock = null, double valueForSetLeft = 0, double valueForSetTop = 0)
        {
            if (TextBox != null)
            {
                if (textOfBlock != null)
                    TextBox.Text = textOfBlock;
                TextBox.Width = defaultWidth;
                TextBox.Height = defaulHeight;
                TextBox.MouseDoubleClick += ChangeTextBoxToTextBlock;
                if (Application.LoadComponent(uri) is ResourceDictionary resourceDict)
                    TextBox.Style = resourceDict["TextBoxStyleForBlock"] as Style;
                if (valueForSetLeft != 0)
                    Canvas.SetLeft(TextBox, valueForSetLeft);
                if (valueForSetTop != 0)
                    Canvas.SetTop(TextBox, valueForSetTop);
            }
        }

        protected void SetPropertyForTextBlock(int defaultWidth, int defaulHeight, double valueForSetLeft = 0, double valueForSetTop = 0)
        {
            if (TextBlock != null)
            {
                TextBlock.Width = defaultWidth;
                TextBlock.Height = defaulHeight;
                TextBlock.MouseDown += ChangeTextBoxToTextBlock;
                if (Application.LoadComponent(uri) is ResourceDictionary resourceDict)
                    TextBlock.Style = resourceDict["TextBlockStyleForBlock"] as Style;
                if (valueForSetLeft != 0)
                    Canvas.SetLeft(TextBlock, valueForSetLeft);
                if (valueForSetTop != 0)
                    Canvas.SetTop(TextBlock, valueForSetTop);
            }
        }

        protected void ChangeTextBoxToTextBlock(object sender, MouseEventArgs e)
        {
            if (canvas != null && TextBox != null && TextBlock != null)
            {
                if (textChangeStatus)
                {
                    valueOfClicksOnTextBlock++;
                    if (valueOfClicksOnTextBlock == 2)
                    {
                        canvas.Children.Remove(TextBox);
                        canvas.Children.Remove(TextBlock);
                        TextBox.Text = TextBlock.Text;
                        canvas.Children.Add(TextBox);
                        textChangeStatus = false;
                        valueOfClicksOnTextBlock = 0;
                    }
                }
                else
                {
                    canvas.Children.Remove(TextBox);
                    canvas.Children.Remove(TextBlock);
                    if (Application.LoadComponent(uri) is ResourceDictionary resourceDict)
                        TextBlock.Style = resourceDict["TextBlockStyleForBlock"] as Style;
                    TextBlock.Text = TextBox.Text;
                    canvas.Children.Add(TextBlock);
                    textChangeStatus = true;
                }
            }
        }

        protected static bool CheckForZeroCoordinates(double coordinatesBlockPointX, double coordinatesBlockPointY) => coordinatesBlockPointX == 0 && coordinatesBlockPointY == 0;
        protected double GetCoordinatesX1(object sender) => Canvas.GetLeft((Ellipse)sender) + Canvas.GetLeft(canvas) + 3;
        protected double GetCoordinatesY1(object sender) => Canvas.GetTop((Ellipse)sender) + Canvas.GetTop(canvas) + 3;
        protected double GetCoordinatesX2(object sender, UIElement uIElement) => Canvas.GetLeft((Ellipse)sender) + Canvas.GetLeft(uIElement) + 3;
        protected double GetCoordinatesY2(object sender, UIElement uIElement) => Canvas.GetTop((Ellipse)sender) + Canvas.GetTop(uIElement) + 3;

        protected static void SeveCoordinates(double coordinatesBlockPointX, double coordinatesBlockPointY)
        {
            CoordinatesBlock.coordinatesBlockPointX = coordinatesBlockPointX;
            CoordinatesBlock.coordinatesBlockPointY = coordinatesBlockPointY;
        }

        protected void SaveСontrolsForConnectionPoint(object sender)
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

        protected void GetDataForCoordinates(object sender, string initialText, Edblock mainWindow)
        {
            //bool checkForZeroCoordinates = CheckForZeroCoordinates(CoordinatesBlock.coordinatesBlockPointX, CoordinatesBlock.coordinatesBlockPointY);
            //TODO: Обновлять сендер при перемещении блока
            if (StaticBlock.block == null)
            {
                double coordinatesBlockPointX = GetCoordinatesX1(sender);
                double coordinatesBlockPointY = GetCoordinatesY1(sender);

                SeveCoordinates(coordinatesBlockPointX, coordinatesBlockPointY);
                numberOfOccurrencesInBlock++;

                flag = false;

                StaticBlock.block = this;
                StaticBlock.sender = sender;

                CoordinatesBlock.keyFirstBlock = keyOfBlock;

                SaveСontrolsForConnectionPoint(sender);

                mainWindow.WriteFirstNameOfBlockToConect(initialText);
            }
            else
            {
                double x1 = GetCoordinatesX2(StaticBlock.sender, StaticBlock.block.GetUIElement());
                double y1 = GetCoordinatesY2(StaticBlock.sender, StaticBlock.block.GetUIElement());

                double x2 = GetCoordinatesX1(sender);
                double y2 = GetCoordinatesY1(sender);

                flag = true;

                CoordinatesBlock.keySecondBlock = keyOfBlock;

                mainWindow.WriteSecondNameOfBlockToConect(initialText);

                numberOfOccurrencesInBlock++;

                SaveСontrolsForConnectionPoint(sender);

                if (StaticBlock.block != null)
                {
                    if (FirstLineConnectionBlock == null)
                    {
                        Line[]? line = mainWindow.DrawConnectionLine(x1, y1, x2, y2, this, StaticBlock.block);
                        if (line != null)
                        {
                            FirstLineConnectionBlock = line;
                            SavingСontrols.Save(StaticBlock.block, this, line);
                        }
                        else numberOfOccurrencesInBlock -= 2;
                    }
                    else if (SecondLineConnectionBlock == null)
                    {
                        Line[]? line = mainWindow.DrawConnectionLine(x1, y1, x2, y2, this, StaticBlock.block);
                        if (line != null)
                        {
                            SecondLineConnectionBlock = line;
                            SavingСontrols.Save(StaticBlock.block, this, line);
                        }
                        else numberOfOccurrencesInBlock -= 2;
                    }
                    else if (ThirdLineConnectionBlock == null)
                    {
                        Line[]? line = mainWindow.DrawConnectionLine(x1, y1, x2, y2, this, StaticBlock.block);
                        if (line != null)
                        {
                            ThirdLineConnectionBlock = line;
                            SavingСontrols.Save(StaticBlock.block, this, line);
                        }
                        else numberOfOccurrencesInBlock -= 2;
                    }
                    else if (FourthLineConnectionBlock == null)
                    {
                        Line[]? line = mainWindow.DrawConnectionLine(x1, y1, x2, y2, this, StaticBlock.block);
                        if (line != null)
                        {
                            FourthLineConnectionBlock = line;
                            SavingСontrols.Save(StaticBlock.block, this, line);
                        }
                        else numberOfOccurrencesInBlock -= 2;
                    }
                }
                StaticBlock.block = null;
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

        abstract public void SetWidth(int valueBlockWidth);

        abstract public void SetHeight(int valueBlockHeight);

        public void SetValueSenderOfBlockWithSingleLineOccurrence(Block block, object sender, Line[] lineConnection)
        {
            firstBlock = block;
            firstSenderBlock = sender;
            FirstLineConnectionBlock = lineConnection;
        }
        public void SetValueSenderOfBlockWithTwoLineOccurrence(Block block, object sender, Line[] lineConnection)
        {
            secondBlock = block;
            secondSenderBlock = sender;
            SecondLineConnectionBlock = lineConnection;
        }
        public void SetValueSenderOfBlockWithThreeLineOccurrence(Block block, object sender, Line[] lineConnection)
        {
            thirdBlock = block;
            thirdSenderBlock = sender;
            ThirdLineConnectionBlock = lineConnection;
        }
        public void SetValueSenderOfBlockWithFourLineOccurrence(Block block, object sender, Line[] lineConnection)
        {
            fourthBlock = block;
            fourthSenderBlock = sender;
            FourthLineConnectionBlock = lineConnection;
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
        public void Reset() => 
            canvas = null;

        protected void ClickOnFirstConnectionPoint(object sender, MouseEventArgs e)
        {
            if (!flagForEnteringFirstConnectionPoint)
            {
                if (StaticBlock.firstPointToConnect == "")
                    StaticBlock.firstPointToConnect = "firstPointToConnect";
                else
                    StaticBlock.secondPointToConnect = "firstPointToConnect";
                flagForEnteringFirstConnectionPoint = true;
                if (MainWindow != null && initialText != null)
                    GetDataForCoordinates(sender, initialText, MainWindow);
            }
        }

        protected void ClickOnSecondConnectionPoint(object sender, MouseEventArgs e)
        {
            if (!flagForEnteringSecondConnectionPoint)
            {
                if (StaticBlock.firstPointToConnect == "")
                    StaticBlock.firstPointToConnect = "secondPointToConnect";
                else
                    StaticBlock.secondPointToConnect = "secondPointToConnect";
                flagForEnteringSecondConnectionPoint = true;
                if (MainWindow != null && initialText != null)
                    GetDataForCoordinates(sender, initialText, MainWindow);
            }
        }

        protected void ClickOnThirdConnectionPoint(object sender, MouseEventArgs e)
        {
            if (!flagForEnteringThirdConnectionPoint)
            {
                if (StaticBlock.firstPointToConnect == "")
                    StaticBlock.firstPointToConnect = "thirdPointToConnect";
                else
                    StaticBlock.secondPointToConnect = "thirdPointToConnect";
                flagForEnteringThirdConnectionPoint = true;
                if (MainWindow != null && initialText != null)
                    GetDataForCoordinates(sender, initialText, MainWindow);
            }
        }

        protected abstract void SetСoordinatesComment(UIElement comment);

        protected void ClickOnFourthConnectionPoint(object sender, MouseEventArgs e)
        {
            if (!flagForEnteringFourthConnectionPoint)
            {
                if (StaticBlock.firstPointToConnect == "")
                    StaticBlock.firstPointToConnect = "fourthPointToConnect";
                else
                    StaticBlock.secondPointToConnect = "fourthPointToConnect";
                if (PinningComment.flagPinningComment && canvas != null)
                {
                    flagForEnteringFourthConnectionPoint = true;
                    CommentControls instanceOfComment = new(blockWidthCoefficient, blockHeightCoefficient);
                    UIElement commentUIElement = instanceOfComment.GetUIElement();
                    comment = instanceOfComment;
                    canvas.Children.Add(commentUIElement);
                    SetСoordinatesComment(commentUIElement);
                    if (MainWindow != null)
                        MainWindow.WriteFirstNameOfBlockToConect("");
                    PinningComment.flagPinningComment = false;
                }
                else
                {
                    flagForEnteringFourthConnectionPoint = true;
                    if (MainWindow != null && initialText != null)
                        GetDataForCoordinates(sender, initialText, MainWindow);
                }
            }
        }

        protected void ClickRightButton(object sender, MouseEventArgs e)
        {
            if (!flagCase && !StaticBlock.flagDeleteBlockOfCase)
            {
                if (MessageBox.Show("Вы действиетельно хотите удалить фигуру", "Удаление блока", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    if (MainWindow != null)
                    {
                        MainWindow.RemoveBlock(canvas, this, FirstLineConnectionBlock, SecondLineConnectionBlock, ThirdLineConnectionBlock, FourthLineConnectionBlock);
                        FirstLineConnectionBlock = null;
                        SecondLineConnectionBlock = null;
                        ThirdLineConnectionBlock = null;
                        FourthLineConnectionBlock = null;
                        numberOfOccurrencesInBlock = 0;
                        StaticBlock.flagDeleteBlockOfCase = true;
                    }
                }
            }
        }
    }
}