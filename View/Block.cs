using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using Flowchart_Editor.Models.Comment;
using Flowchart_Editor.View.ConnectionPoint;

namespace Flowchart_Editor.Models
{
    public abstract class Block
    {
        public Canvas? Canvas { get; set; }
        protected Canvas? Destination { get; set; }
        public TextBox? TextBoxOfBlock { get; set; }
        public TextBlock? TextBlockOfBlock { get; set; }
        public Edblock? MainWindow { get; set; } 
        
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
        public object? FirstSenderMainBlock { get; private set; }
        public object? SecondSenderMainBlock { get; private set; }
        public object? ThirdSenderMainBlock { get; private set; }
        public object? FourthSenderMainBlock { get; private set; }
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
        public int NumberOfOccurrencesInBlock { get; private set; }
        protected int valueOfClicksOnTextBlock = 0;
        protected int keyOfBlock = 0;
        public bool? flag = null;
        public bool flagCase = false;
        protected const int radiusPoint = 6;
        protected double blockWidthCoefficient;
        protected double blockHeightCoefficient;
        protected string? initialText;
        private readonly int coefficientCoordinateDisplacement = 3;
        protected readonly FontFamily defaultFontFamily = DefaultPropertyForBlock.fontFamily;
        protected readonly Uri uri = new("WindowsTheme/theme.xaml", UriKind.Relative);

        abstract public UIElement GetUIElement();
        public abstract void SetLeftBlockForConditionCaseFirstOption(UIElement uIElementBlock, double coordinateLeft);
        public abstract void SetTopBlockForConditionCaseFirstOption(UIElement uIElementBlock, double coordinateTop);
        public abstract void SetLeftBlockForConditionCaseSecondOption(UIElement uIElementBlock, double coordinateLeft);
        public abstract void SetTopBlockForConditionCaseSecondOption(UIElement uIElementBlock, double coordinateTop);
        public abstract double GetWidthCoefficient();
        public abstract double GetHeightCoefficient();
        protected abstract void SetСoordinatesComment(UIElement comment);
        public Block? GetMainBlock() => mainBlock;

        protected void MouseMoveBlockForMovements(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && textChangeStatus)
                if (textChangeStatus && !flagCase)
                    DoDragDropControlElement(typeof(Canvas), sender, sender);

            e.Handled = true;
        }

        public void Reset() =>
            Canvas = null;
        protected void SetPropertyPointConnect(Ellipse? pointToConnect, double valueForSetLeft, double valueForSetTop)
        {
            if (pointToConnect != null)
            {
                SetStyle(pointToConnect, "EllipseStyle");
                SetSize(pointToConnect, radiusPoint, radiusPoint);
                SetCoordinates(pointToConnect, valueForSetLeft, valueForSetTop);
                pointToConnect.MouseDown += ClickOnConnectionPoint;
            }
        }

        private void SetStyle(FrameworkElement frameworkElement, string nameStyle)
        {
            if (Application.LoadComponent(uri) is ResourceDictionary resourceDict)
                frameworkElement.Style = resourceDict[nameStyle] as Style;
        }

        private static void SetSize(FrameworkElement pointConnect, int width, int height)
        {
            pointConnect.Width = width;
            pointConnect.Height = height;
        }

        public static void SetCoordinates(UIElement uIElement, double valueForSetLeft, double valueForSetTop)
        {
            if (valueForSetLeft != 0)
                Canvas.SetLeft(uIElement, valueForSetLeft);
            if (valueForSetTop != 0)
                Canvas.SetTop(uIElement, valueForSetTop);
        }

        protected void SetPropertyForTextBox(int defaultWidth, int defaulHeight, string? textOfBlock = null, double valueForSetLeft = 0, double valueForSetTop = 0)
        {
            TextBoxOfBlock = new();
            if (textOfBlock != null)
                TextBoxOfBlock.Text = textOfBlock;
            TextBoxOfBlock.MouseDoubleClick += ChangeTextBoxToTextBlock;
            SetSize(TextBoxOfBlock, defaultWidth, defaulHeight);
            SetStyle(TextBoxOfBlock, "TextBoxStyleForBlock");
            SetCoordinates(TextBoxOfBlock, valueForSetLeft, valueForSetTop);
        }

        protected void SetPropertyForTextBlock(int defaultWidth, int defaulHeight, double valueForSetLeft = 0, double valueForSetTop = 0)
        {
            TextBlockOfBlock = new();
            TextBlockOfBlock.MouseDown += ChangeTextBoxToTextBlock;
            SetSize(TextBlockOfBlock, defaultWidth, defaulHeight);
            SetStyle(TextBlockOfBlock, "TextBlockStyleForBlock");
            SetCoordinates(TextBlockOfBlock, valueForSetLeft, valueForSetTop);
        }

        protected void ChangeTextBoxToTextBlock(object sender, MouseEventArgs e)
        {
            if (Canvas != null && TextBoxOfBlock != null && TextBlockOfBlock != null)
            {
                if (textChangeStatus)
                {
                    valueOfClicksOnTextBlock++;
                    if (valueOfClicksOnTextBlock == 2)
                    {
                        Canvas.Children.Remove(TextBoxOfBlock);
                        Canvas.Children.Remove(TextBlockOfBlock);
                        TextBoxOfBlock.Text = TextBlockOfBlock.Text;
                        Canvas.Children.Add(TextBoxOfBlock);
                        textChangeStatus = false;
                        valueOfClicksOnTextBlock = 0;
                    }
                }
                else
                {
                    Canvas.Children.Remove(TextBoxOfBlock);
                    Canvas.Children.Remove(TextBlockOfBlock);
                    SetStyle(TextBlockOfBlock, "TextBlockStyleForBlock");
                    TextBlockOfBlock.Text = TextBoxOfBlock.Text;
                    Canvas.Children.Add(TextBlockOfBlock);
                    textChangeStatus = true;
                }
            }
        }

        protected void InitializingConnectionPoints()
        {
            firstPointToConnect = new();
            firstPointToConnect.Tag = new ConnectionPoint("firstPointToConnect");

            secondPointToConnect = new();
            secondPointToConnect.Tag = new ConnectionPoint("secondPointToConnect");

            thirdPointToConnect = new();
            thirdPointToConnect.Tag = new ConnectionPoint("thirdPointToConnect");

            fourthPointToConnect = new();
            fourthPointToConnect.Tag = new ConnectionPoint("fourthPointToConnect");
        }
        protected double GetCoordinatesX1(object sender) => 
            Canvas.GetLeft((Ellipse)sender) + Canvas.GetLeft(Canvas) + coefficientCoordinateDisplacement;
        protected double GetCoordinatesY1(object sender) => 
            Canvas.GetTop((Ellipse)sender) + Canvas.GetTop(Canvas) + coefficientCoordinateDisplacement;
        protected double GetCoordinatesX2(object sender, UIElement uIElement) => 
            Canvas.GetLeft((Ellipse)sender) + Canvas.GetLeft(uIElement) + coefficientCoordinateDisplacement;
        protected double GetCoordinatesY2(object sender, UIElement uIElement) => 
            Canvas.GetTop((Ellipse)sender) + Canvas.GetTop(uIElement) + coefficientCoordinateDisplacement;

        protected void GetDataForCoordinates(object sender, string initialText, Canvas destionation)
        {
            //bool checkForZeroCoordinates = CheckForZeroCoordinates(CoordinatesBlock.coordinatesBlockPointX, CoordinatesBlock.coordinatesBlockPointY);
            //if (StaticBlock.block == null)
            //{
            //    double coordinatesBlockPointX = GetCoordinatesX1(sender);
            //    double coordinatesBlockPointY = GetCoordinatesY1(sender);

            //    SeveCoordinates(coordinatesBlockPointX, coordinatesBlockPointY);
            //    NumberOfOccurrencesInBlock++;

            //    flag = false;

            //    StaticBlock.block = this;
            //    StaticBlock.sender = sender;

            //    CoordinatesBlock.keyFirstBlock = keyOfBlock;

            //    SaveСontrolsForConnectionPoint(sender);

            //    //mainWindow.WriteFirstNameOfBlockToConect(initialText);
            //}
            //else
            //{
            //    double x1 = GetCoordinatesX2(StaticBlock.sender, StaticBlock.block.GetUIElement());
            //    double y1 = GetCoordinatesY2(StaticBlock.sender, StaticBlock.block.GetUIElement());

            //    double x2 = GetCoordinatesX1(sender);
            //    double y2 = GetCoordinatesY1(sender);

            //    flag = true;

            //    CoordinatesBlock.keySecondBlock = keyOfBlock;

            //    //mainWindow.WriteSecondNameOfBlockToConect(initialText);

            //    NumberOfOccurrencesInBlock++;

            //    SaveСontrolsForConnectionPoint(sender);

            //    if (StaticBlock.block != null)
            //    {
            //        if (FirstLineConnectionBlock == null)
            //        {
            //            Line[]? line = mainWindow.DrawConnectionLine(x1, y1, x2, y2, this, StaticBlock.block);
            //            if (line != null)
            //            {
            //                FirstLineConnectionBlock = line;
            //                SavingСontrols.Save(StaticBlock.block, this, line);
            //            }
            //            else NumberOfOccurrencesInBlock -= 2;
            //        }
            //        else if (SecondLineConnectionBlock == null)
            //        {
            //            Line[]? line = mainWindow.DrawConnectionLine(x1, y1, x2, y2, this, StaticBlock.block);
            //            if (line != null)
            //            {
            //                SecondLineConnectionBlock = line;
            //                SavingСontrols.Save(StaticBlock.block, this, line);
            //            }
            //            else NumberOfOccurrencesInBlock -= 2;
            //        }
            //        else if (ThirdLineConnectionBlock == null)
            //        {
            //            Line[]? line = mainWindow.DrawConnectionLine(x1, y1, x2, y2, this, StaticBlock.block);
            //            if (line != null)
            //            {
            //                ThirdLineConnectionBlock = line;
            //                SavingСontrols.Save(StaticBlock.block, this, line);
            //            }
            //            else NumberOfOccurrencesInBlock -= 2;
            //        }
            //        else if (FourthLineConnectionBlock == null)
            //        {
            //            Line[]? line = mainWindow.DrawConnectionLine(x1, y1, x2, y2, this, StaticBlock.block);
            //            if (line != null)
            //            {
            //                FourthLineConnectionBlock = line;
            //                SavingСontrols.Save(StaticBlock.block, this, line);
            //            }
            //            else NumberOfOccurrencesInBlock -= 2;
            //        }
            //    }
            //    StaticBlock.block = null;
            //    CoordinatesBlock.coordinatesBlockPointX = 0;
            //    CoordinatesBlock.coordinatesBlockPointY = 0;
            //}
        }

        protected void AddConnectionPoints()
        {
            if (Canvas != null)
            {
                Canvas.Children.Add(firstPointToConnect);
                Canvas.Children.Add(secondPointToConnect);
                Canvas.Children.Add(thirdPointToConnect);
                Canvas.Children.Add(fourthPointToConnect);
            }
        }
        protected void AddTextFields()
        {
            if (Canvas != null)
            {
                Canvas.Children.Add(TextBoxOfBlock);
                Canvas.Children.Add(TextBlockOfBlock);
            }
        }
        protected void SetPropertyForCanvas(int defaultWidth, int defaulHeight, Brush? backgroundColor = null)
        {
            Canvas = new();
            SetSize(Canvas, defaultWidth, defaulHeight);
            Canvas.Background = backgroundColor;
            Canvas.MouseMove += MouseMoveBlockForMovements;
        }

        abstract public void SetWidth(int valueBlockWidth);

        abstract public void SetHeight(int valueBlockHeight);

        protected void ClickOnConnectionPoint(object sender, MouseEventArgs e)
        {
            ConnectionPoint connectionPoint = (ConnectionPoint)((Ellipse)sender).Tag;
            string? nameConnectionPoint = connectionPoint.NameConnectionPoint;
            if (!connectionPoint.FlagEntry && nameConnectionPoint != null)
            {
                if (StaticBlock.firstPointToConnect == "")
                    StaticBlock.firstPointToConnect = nameConnectionPoint;
                else
                    StaticBlock.secondPointToConnect = nameConnectionPoint;

                connectionPoint.FlagEntry = true;
            }
            if (initialText != null && Destination != null)
                GetDataForCoordinates(sender, initialText, Destination);
        }

        public static void DoDragDropControlElement(Type typeControlElement, object controlElement, object sender)
        {
            DataObject data = new(typeControlElement, controlElement);
            DragDrop.DoDragDrop(sender as DependencyObject, data, DragDropEffects.Copy);
        }

        public void SetComment(string textOfComment)
        {
            CommentControls commentControls = new(blockWidthCoefficient, blockHeightCoefficient);
            comment = commentControls;
            UIElement commentUIElement = comment.GetUIElement();
            SetСoordinatesComment(commentUIElement);
            comment.TextBoxOfBlock.Text = textOfComment;
            if (Canvas != null)
                Canvas.Children.Add(commentUIElement);
        }
    }
}