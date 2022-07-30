using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using Flowchart_Editor.Models.Comment;
using Flowchart_Editor.View.ConnectionLine;

namespace Flowchart_Editor.Models
{
    public abstract class Block
    {
        public Canvas? FrameBlock { get; set; }
        protected Canvas? EditField { get; set; }
        protected Polygon polygonBlock = new();
        public TextBox? TextBoxOfBlock { get; set; }
        public TextBlock? TextBlockOfBlock { get; set; }
        public Edblock? Edblock { get; set; }

        public CommentControls? comment;
        private Dictionary<Ellipse, Tuple<int, int>> listPointToConnect = new();
        private List<Ellipse> list = new();
        public Line[]? FirstLineConnectionBlock { get; set; }
        public Line[]? SecondLineConnectionBlock { get; set; }
        public Line[]? ThirdLineConnectionBlock { get; set; }
        public Line[]? FourthLineConnectionBlock { get; set; }
        protected Block? mainBlock;
        protected Block? firstBlock;
        protected Block? secondBlock;
        protected Block? thirdBlock;
        protected Block? fourthBlock;
        public object? FirstSenderMainBlock { get; private set; }
        public object? SecondSenderMainBlock { get; private set; }
        public object? ThirdSenderMainBlock { get; private set; }
        public object? FourthSenderMainBlock { get; private set; }
        protected object? firstSenderBlock;
        protected object? secondSenderBlock;
        protected object? thirdSenderBlock;
        protected object? fourthSenderBlock;
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
        protected readonly Uri uri = new("View/WindowsTheme/MaterialDesignDarkTheme.xaml", UriKind.Relative);
        abstract public UIElement? GetUIElement();
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
            if (e.LeftButton == MouseButtonState.Pressed && e.Source is not TextBox)
                DoDragDropControlElement(typeof(Canvas), sender, sender);
            e.Handled = true;
        }

        public void Reset() =>
            FrameBlock = null;

        protected void SetPropertyPointConnect(Ellipse? pointToConnect, double valueForSetLeft, double valueForSetTop)
        {
            foreach (var itemEllipse in listPointToConnect)
            {
                SetStyle(itemEllipse.Key, "EllipseStyle");
                SetSize(itemEllipse.Key, itemEllipse.Value.Item1, itemEllipse.Value.Item2);
                SetCoordinates(itemEllipse.Key, valueForSetLeft, valueForSetTop);
                itemEllipse.Key.MouseMove += ClickOnConnectionPoint;
            }
        }

        protected void SetStyle(FrameworkElement frameworkElement, string nameStyle)
        {
            if (Application.LoadComponent(uri) is ResourceDictionary resourceDict)
                frameworkElement.Style = resourceDict[nameStyle] as Style;
        }

        private static void SetSize(FrameworkElement pointConnect, int width, int height)
        {
            pointConnect.Width = width;
            pointConnect.Height = height;
        }

        public static void SetCoordinates(UIElement? uIElement, double valueForSetLeft, double valueForSetTop)
        {
            if (valueForSetLeft != 0)
                Canvas.SetLeft(uIElement, valueForSetLeft);
            if (valueForSetTop != 0)
                Canvas.SetTop(uIElement, valueForSetTop);
        }

        protected void SetPropertyForTextBox(int defaultWidth, int defaulHeight, string? textOfBlock = null, double valueSetLeft = 0, double valueSetTop = 0)
        {
            if (TextBoxOfBlock == null)
                TextBoxOfBlock = new();
            if (textOfBlock != null)
                TextBoxOfBlock.Text = textOfBlock;
            TextBoxOfBlock.MouseDoubleClick += ChangeTextBoxToTextBlock;
            SetSize(TextBoxOfBlock, defaultWidth, defaulHeight);
            SetStyle(TextBoxOfBlock, "TextBoxStyleForBlock");
            SetCoordinates(TextBoxOfBlock, valueSetLeft, valueSetTop);
            //if (FrameBlock != null)
                //FrameBlock.Children.Add(TextBoxOfBlock);
        }

        protected void SetPropertyForTextBlock(int defaultWidth, int defaulHeight, string? textOfBlock = null, double valueSetLeft = 0, double valueSetTop = 0)
        {
            if (TextBlockOfBlock == null)
                TextBlockOfBlock = new();
            if (textOfBlock != null)
                TextBlockOfBlock.Text = textOfBlock;
            TextBlockOfBlock.MouseDown += ChangeTextBoxToTextBlock;
            SetSize(TextBlockOfBlock, defaultWidth, defaulHeight);
            SetStyle(TextBlockOfBlock, "TextBlockStyleForBlock");
            SetCoordinates(TextBlockOfBlock, valueSetLeft, valueSetTop);
            //if (FrameBlock != null)
            //    FrameBlock.Children.Add(TextBlockOfBlock);
        }

        protected void ChangeTextBoxToTextBlock(object sender, MouseEventArgs e)
        {
            if (FrameBlock != null && TextBoxOfBlock != null && TextBlockOfBlock != null)
            {
                if (e.Source is TextBlock)
                {
                    valueOfClicksOnTextBlock++;
                    if (valueOfClicksOnTextBlock == 2)
                    {
                        FrameBlock.Children.Remove(TextBoxOfBlock);
                        FrameBlock.Children.Remove(TextBlockOfBlock);
                        TextBoxOfBlock.Text = TextBlockOfBlock.Text;
                        FrameBlock.Children.Add(TextBoxOfBlock);
                        valueOfClicksOnTextBlock = 0;
                    }
                }
                else
                {
                    FrameBlock.Children.Remove(TextBoxOfBlock);
                    FrameBlock.Children.Remove(TextBlockOfBlock);
                    SetStyle(TextBlockOfBlock, "TextBlockStyleForBlock");
                    TextBlockOfBlock.Text = TextBoxOfBlock.Text;
                    FrameBlock.Children.Add(TextBlockOfBlock);
                }
            }
        }

        protected void InitializingConnectionPoints(Dictionary<int, int> list)
        {
            foreach (var itemCoordinatesPoint in list)
            {
                Ellipse connectionPoint = new();
                Tuple<int, int> coordinates = new(itemCoordinatesPoint.Key, itemCoordinatesPoint.Value);
                listPointToConnect.Add(connectionPoint, coordinates);
            }

            //listPointToConnect.Keys. = new ConnectionPoint("firstPointToConnect");

            //secondPointConnect = new();
            //secondPointConnect.Tag = new ConnectionPoint("secondPointToConnect");

            //thirdPointConnect = new();
            //thirdPointConnect.Tag = new ConnectionPoint("thirdPointToConnect");

            //fourthPointConnect = new();
            //fourthPointConnect.Tag = new ConnectionPoint("fourthPointToConnect");
        }

        protected double GetCoordinatesX1(object sender) => 
            Canvas.GetLeft((Ellipse)sender) + Canvas.GetLeft(FrameBlock) + coefficientCoordinateDisplacement;

        protected double GetCoordinatesY1(object sender) => 

            Canvas.GetTop((Ellipse)sender) + Canvas.GetTop(FrameBlock) + coefficientCoordinateDisplacement;

        protected double GetCoordinatesX2(object? sender, UIElement? uIElement)
        {
            if (sender != null)
                return Canvas.GetLeft((Ellipse)sender) + Canvas.GetLeft(uIElement) + coefficientCoordinateDisplacement;
            else
                return 0;
        }

        protected double GetCoordinatesY2(object? sender, UIElement? uIElement)
        {
            if(sender != null)
                return Canvas.GetTop((Ellipse)sender) + Canvas.GetTop(uIElement) + coefficientCoordinateDisplacement;
            else
                return 0;
        }

        protected void GetDataForCoordinates(object sender, string initialText, Canvas destionation)
        {
            if (StaticBlock.Block == null)
            {
                StaticBlock.Block = this;
                StaticBlock.Sender = sender;
            }
            else
            {
                double x1 = GetCoordinatesX2(StaticBlock.Sender, StaticBlock.Block.FrameBlock);
                double y1 = GetCoordinatesY2(StaticBlock.Sender, StaticBlock.Block.FrameBlock);

                double x2 = GetCoordinatesX1(sender);
                double y2 = GetCoordinatesY1(sender);

                if (StaticBlock.Block != null)
                {
                    if (FirstLineConnectionBlock == null)
                        FirstLineConnectionBlock = new ConnectionLine(EditField).DrawConnectionLine(x1, y1, x2, y2, this, StaticBlock.Block);
                    else if (SecondLineConnectionBlock == null)
                        SecondLineConnectionBlock = new ConnectionLine(EditField).DrawConnectionLine(x1, y1, x2, y2, this, StaticBlock.Block);
                    else if (ThirdLineConnectionBlock == null)
                        ThirdLineConnectionBlock = new ConnectionLine(EditField).DrawConnectionLine(x1, y1, x2, y2, this, StaticBlock.Block);
                    else if (FourthLineConnectionBlock == null)
                        FourthLineConnectionBlock = new ConnectionLine(EditField).DrawConnectionLine(x1, y1, x2, y2, this, StaticBlock.Block);
                }
                StaticBlock.Block = null;
                CoordinatesBlock.coordinatesBlockPointX = 0;
                CoordinatesBlock.coordinatesBlockPointY = 0;
            }
        }

        protected void AddConnectionPoints()
        {
            if (FrameBlock != null)
            {
                foreach(var item in listPointToConnect)
                    FrameBlock.Children.Add(item.Key);
            }
        }
        protected void AddTextFields()
        {
            if (FrameBlock != null)
            {
                FrameBlock.Children.Add(TextBoxOfBlock);
                FrameBlock.Children.Add(TextBlockOfBlock);
            }
        }
        protected void SetPropertyFrameBlock(int defaultWidth, int defaulHeight, Brush? backgroundColor = null)
        {
            SetSize(FrameBlock, defaultWidth, defaulHeight);
            FrameBlock.Background = backgroundColor;
            FrameBlock.MouseMove += MouseMoveBlockForMovements;
        }
        protected void SetPointPolygon(List<Point> listPoints)
        {
            if (FrameBlock != null)
            {
                PointCollection myPointCollection = new();
                foreach (Point itemPoint in listPoints)
                    myPointCollection.Add(itemPoint);

                polygonBlock.Points = myPointCollection;
                FrameBlock.Children.Add(polygonBlock);
            }
        }
        protected void SetSizePolygon(List<Point> listPoints, int valueBlockHeight, int valueBlockWidth)
        {
            listPoints.Clear();
            Point Point1 = new(0, valueBlockHeight / 2);
            listPoints.Add(Point1);
            Point Point2 = new(valueBlockWidth / 2, valueBlockHeight);
            listPoints.Add(Point2);
            Point Point3 = new(valueBlockWidth, valueBlockHeight / 2);
            listPoints.Add(Point3);
            Point Point4 = new(valueBlockWidth / 2, 0);
            listPoints.Add(Point4);
            Point Point5 = new(0, valueBlockHeight / 2);
            listPoints.Add(Point5);
            SetPointPolygon(listPoints);
        }

        abstract public void SetWidth(int valueBlockWidth);

        abstract public void SetHeight(int valueBlockHeight);

        protected void ClickOnConnectionPoint(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                while (true)
                {
                    var x1 = GetCoordinatesX2(sender, FrameBlock);
                    var y1 = GetCoordinatesY2(sender, FrameBlock);
                    var x2 = Mouse.GetPosition(EditField).X;
                    var y2 = Mouse.GetPosition(EditField).Y;

                    Line line = new()
                    {
                        X1 = x2,
                        Y1 = y2,
                        X2 = x1,
                        Y2 = y1,
                        Stroke = Brushes.Black
                    };
                    EditField.Children.Add(line);
                }

                //ConnectionPoint connectionPoint = (ConnectionPoint)((Ellipse)sender).Tag;
                //string? nameConnectionPoint = connectionPoint.NameConnectionPoint;
                //if (!connectionPoint.FlagEntry && nameConnectionPoint != null)
                //{
                //    if (StaticBlock.firstPointToConnect == "")
                //        StaticBlock.firstPointToConnect = nameConnectionPoint;
                //    else
                //        StaticBlock.secondPointToConnect = nameConnectionPoint;

                //    connectionPoint.FlagEntry = true;
                //}
                //if (initialText != null && EditField != null)
                //    GetDataForCoordinates(sender, initialText, EditField);
            }   
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
            if (FrameBlock != null)
                FrameBlock.Children.Add(commentUIElement);
        }
    }
}