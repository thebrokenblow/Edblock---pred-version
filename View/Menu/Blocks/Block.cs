using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using Flowchart_Editor.Model;
using System.Windows.Controls;
using System.Collections.Generic;
using Flowchart_Editor.View.Menu.ConnectionLine;
using Flowchart_Editor.View.Menu;

namespace Flowchart_Editor.Models
{
    public abstract class Block
    {
        public Canvas FrameBlock { get; set; }
        public static Canvas? EditField { get; set; }
        public static Edblock? Edblock { get; set; }
        public TextBox TextBoxOfBlock { get; set; }
        public TextBlock TextBlockOfBlock { get; set; }
        private const int defaultWidth = 140;
        private const int defaulHeight = 60;
        protected const int offsetConnectionPoint = 3;
        protected string initialText = "";
        private readonly Border borderHighlightedLine;
        protected ControlSize ControlSize { get; set; }
        protected Tuple<double, double> coordinateConnectionPoint;
        protected List<Tuple<double, double>> coordinatesConnectionPoints;
        protected List<ConnectionPoint> connectionsPoints;
        public static LineCreation lineCreation;
        protected readonly Uri uri;

        public Block()
        {
            FrameBlock = new();
            TextBoxOfBlock = new();
            TextBlockOfBlock = new();
            borderHighlightedLine = new();
            ControlSize = new(defaultWidth, defaulHeight);
            coordinateConnectionPoint = new(0, 0);
            coordinatesConnectionPoints = new();
            connectionsPoints = new();
            uri = new("View/СontrolStyle/СontrolsStyle.xaml", UriKind.Relative);
            SetPropertyFrameBlock();
            SetBackground();
        }

        public UIElement GetUIElement()
        {
            return FrameBlock;
        }

        abstract public void SetWidth(int valueBlockWidth);
        abstract public void SetHeight(int valueBlockHeight);
        abstract protected void SetBackground();
        abstract public Block GetCopyBlock();


        private void MouseMoveBlockForMovements(object sender, MouseEventArgs e)
        {
            if (lineCreation == null)
            {
                if (e.LeftButton == MouseButtonState.Pressed && e.Source is not TextBox)
                {
                    Type typeBlock = typeof(Canvas);
                    DoDragDropControlElement(typeBlock, sender, sender);
                }
                e.Handled = true;
            }
        }

        public static void DoDragDropControlElement(Type typeControlElement, object controlElement, object sender)
        {
            DataObject data = new(typeControlElement, controlElement);
            DragDrop.DoDragDrop(sender as DependencyObject, data, DragDropEffects.Copy);
        }

        public void SetStyle(FrameworkElement frameworkElement, string nameStyle)
        {
            if (Application.LoadComponent(uri) is ResourceDictionary resourceDict)
                frameworkElement.Style = resourceDict[nameStyle] as Style;
        }

        protected static void SetSize(FrameworkElement frameworkElement, ControlSize blockSize)
        {
            double width = blockSize.Width;
            double height = blockSize.Height;

            if (width != 0)
                frameworkElement.Width = width;
            if (height != 0)
                frameworkElement.Height = height;
        }

        public static void SetCoordinates(UIElement uIElement, ControlOffset controlOffset)
        {
            double valueSetLeft = controlOffset.ValueSetLeft;
            double valueSetTop = controlOffset.ValueSetTop;

            if (valueSetLeft != 0)
                Canvas.SetLeft(uIElement, valueSetLeft);
            if (valueSetTop != 0)
                Canvas.SetTop(uIElement, valueSetTop);
        }

        protected void SetProperty(FrameworkElement frameworkElement, string nameStyle, ControlOffset controlOffset, ControlSize blockSize)
        {
            SetSize(frameworkElement, blockSize);
            SetCoordinates(frameworkElement, controlOffset);
            SetStyle(frameworkElement, nameStyle);
        }

        protected void SetPropertyTextField(ControlSize blockSize, ControlOffset controlOffset)
        {
            SetPropertyTextBox(blockSize, controlOffset);
            SetPropertyTextBlock(blockSize, controlOffset);
        }

        private void SetPropertyTextBox(ControlSize blockSize, ControlOffset controlOffset)
        {
            TextBoxOfBlock.MouseDoubleClick += ClickTextField;
            string nameStyle = "TextBoxStyle";
            SetProperty(TextBoxOfBlock, nameStyle, controlOffset, blockSize);
        }

        private void SetPropertyTextBlock(ControlSize blockSize, ControlOffset controlOffset)
        {
            TextBlockOfBlock.MouseDown += ClickTextField;
            TextBlockOfBlock.Text = initialText;
            
            string nameStyle = "TextBlockStyle";
            SetProperty(TextBlockOfBlock, nameStyle, controlOffset, blockSize);
            if (FrameBlock != null)
                FrameBlock.Children.Add(TextBlockOfBlock);
        }

        protected void DrawHighlightedBlock()
        {
            if (!FrameBlock.Children.Contains(borderHighlightedLine))
            {
                borderHighlightedLine.BorderBrush = Brushes.Blue;
                borderHighlightedLine.Width = ControlSize.Width;
                borderHighlightedLine.Height = ControlSize.Height;
                borderHighlightedLine.BorderThickness = new Thickness(1);
                FrameBlock.Children.Add(borderHighlightedLine);
            }
        }

        protected void SetTextTextField(string text)
        {
            TextBlockOfBlock.Text = text;
            TextBoxOfBlock.Text = text;
        }

        protected void ChangeHighlightedBlock()
        {
            if (FrameBlock.Children.Contains(borderHighlightedLine))
            {
                borderHighlightedLine.Width = ControlSize.Width;
                borderHighlightedLine.Height = ControlSize.Height;
            }
        }

        public void RemoveHighlightedBlock()
        {
            FrameBlock.Children.Remove(borderHighlightedLine);
        }

        public void ChangeTextField()
        {
            if (!FrameBlock.Children.Contains(TextBlockOfBlock))
            {
                FrameBlock.Children.Remove(TextBoxOfBlock);
                TextBlockOfBlock.Text = TextBoxOfBlock.Text;
                FrameBlock.Children.Add(TextBlockOfBlock);
            }
        }

        protected void ClickTextField(object sender, MouseButtonEventArgs e)
        {
            if (e.Source is TextBlock)
            {
                if (e.ClickCount == 1)
                {
                    DrawHighlightedBlock();
                    Edblock.AddHighlightedBlock(this);
                }
                else if (e.ClickCount == 2)
                {
                    FrameBlock.Children.Remove(TextBlockOfBlock);
                    TextBoxOfBlock.Text = TextBlockOfBlock.Text;
                    FrameBlock.Children.Add(TextBoxOfBlock);
                }
            }
            else if (e.Source is TextBox)
            {
                FrameBlock.Children.Remove(TextBoxOfBlock);
                TextBlockOfBlock.Text = TextBoxOfBlock.Text;
                FrameBlock.Children.Add(TextBlockOfBlock);
            }
        }

        protected void SetPropertyFrameBlock()
        {
            SetSize(FrameBlock, ControlSize);
            FrameBlock.MouseMove += MouseMoveBlockForMovements;
        }

        protected void ClickOnConnectionPoint(object sender, MouseEventArgs e)
        {
            if (e.RightButton == MouseButtonState.Pressed)
            {
                if (Edblock.current != null)
                {
                    if (lineCreation == null)
                    {
                        ConnectionPoint connectionPoint1 = null;
                        foreach (var item in connectionsPoints)
                        {
                            if ((Ellipse)sender == item.EllipseConnectionPoint)
                            {
                                connectionPoint1 = item;
                            }
                        }

                        lineCreation = new LineCreation(this, connectionPoint1);
                        Edblock.current.StartLineCreation(lineCreation);  
                    }
                }
            }   
        }

        public void SetCoordinatesConnectionPoints(int sideProjection = 0)
        {
            double width = ControlSize.Width;
            double height = ControlSize.Height;
            coordinatesConnectionPoints.Clear();

            double connectionPointsX = width / 2 - offsetConnectionPoint;
            double connectionPointsY = -offsetConnectionPoint;
            coordinateConnectionPoint = new(connectionPointsX, connectionPointsY);
            coordinatesConnectionPoints.Add(coordinateConnectionPoint);

            connectionPointsX = sideProjection / 2 - offsetConnectionPoint;
            connectionPointsY = height / 2 - offsetConnectionPoint;
            coordinateConnectionPoint = new(connectionPointsX, connectionPointsY);
            coordinatesConnectionPoints.Add(coordinateConnectionPoint);

            connectionPointsX = width / 2 - offsetConnectionPoint;
            connectionPointsY = height - offsetConnectionPoint;
            coordinateConnectionPoint = new(connectionPointsX, connectionPointsY);
            coordinatesConnectionPoints.Add(coordinateConnectionPoint);

            connectionPointsX = width - sideProjection / 2 - offsetConnectionPoint;
            connectionPointsY = height / 2 - offsetConnectionPoint;
            coordinateConnectionPoint = new(connectionPointsX, connectionPointsY);
            coordinatesConnectionPoints.Add(coordinateConnectionPoint);
        }

        protected void InitializingConnectionPoints()
        {
            string nameStyle = "EllipseStyle";
            int i = 0;
            foreach (var itemCoordinatesPoint in coordinatesConnectionPoints)
            {
                ConnectionPoint connectionPoint;
                if (i % 2 == 0)
                {
                    connectionPoint = new(OrientationConnectionPoint.Vertical);
                }
                else
                {
                    connectionPoint = new(OrientationConnectionPoint.Horizontal);
                }
                i++;
                ControlOffset offsetConnectionPoints = new(itemCoordinatesPoint.Item1, itemCoordinatesPoint.Item2);

                SetStyle(connectionPoint.EllipseConnectionPoint, nameStyle);
                SetCoordinates(connectionPoint.EllipseConnectionPoint, offsetConnectionPoints);
                  
                connectionsPoints.Add(connectionPoint);
                connectionPoint.EllipseConnectionPoint.MouseMove += ClickOnConnectionPoint;
                connectionPoint.EllipseConnectionPoint.MouseEnter += ConnectionPoint_MouseEnter;
                connectionPoint.EllipseConnectionPoint.MouseLeave += ConnectionPoint_MouseLeave;
                FrameBlock.Children.Add(connectionPoint.EllipseConnectionPoint);
            }
        }

        private void ConnectionPoint_MouseLeave(object sender, MouseEventArgs e)
        {
            SetStyle((Ellipse)sender, "EllipseStyle");
        }

        private void ConnectionPoint_MouseEnter(object sender, MouseEventArgs e)
        {
            if (lineCreation == null)
            {
                SetStyle((Ellipse)sender, "HighlightedEllipseStyle");
            }
        }

        protected void ChangeCoordinatesConnectionPoints()
        {
            for (int i = 0; i < coordinatesConnectionPoints.Count; i++)
            {
                ControlOffset offsetConnectionPoints = new(coordinatesConnectionPoints[i].Item1, coordinatesConnectionPoints[i].Item2);
                SetCoordinates(connectionsPoints[i].EllipseConnectionPoint, offsetConnectionPoints);
            }
        }

        protected static Brush GetBackgroundColor(string color)
        {
            BrushConverter brushConverter = new();
            Brush backgroundColor = (Brush)brushConverter.ConvertFrom(color);
            return backgroundColor;
        }

        public void SetFontFamily(FontFamily fontFamily)
        {
            TextBlockOfBlock.FontFamily = fontFamily;
            TextBoxOfBlock.FontFamily = fontFamily;
        }

        public void SetFontSize(double fontSize)
        {
            TextBlockOfBlock.FontSize = fontSize;
            TextBoxOfBlock.FontSize = fontSize;
        }

        public void SetFormatAlign(string formatAlign)
        {
            if (formatAlign == "FormatAlignLeft")
            {
                TextBlockOfBlock.TextAlignment = TextAlignment.Left;
                TextBoxOfBlock.TextAlignment = TextAlignment.Left;
            }
            else if (formatAlign == "FormatAlignCentre")
            {
                TextBlockOfBlock.TextAlignment = TextAlignment.Center;
                TextBoxOfBlock.TextAlignment = TextAlignment.Center;
            }
            else if (formatAlign == "FormatAlignRight")
            {
                TextBlockOfBlock.TextAlignment = TextAlignment.Right;
                TextBoxOfBlock.TextAlignment = TextAlignment.Right;
            }
            else if (formatAlign == "FormatAlignJustify")
            {
                TextBlockOfBlock.TextAlignment = TextAlignment.Justify;
                TextBoxOfBlock.TextAlignment = TextAlignment.Justify;
            }
        }

        public void SetFormatTextField(string formatText)
        {
            if (formatText == "FormatBold")
            {
                TextBlockOfBlock.FontWeight = FontWeights.Bold;
                TextBoxOfBlock.FontWeight = FontWeights.Bold;
            }
            else if (formatText == "FormatItalic")
            {
                TextBlockOfBlock.FontStyle = FontStyles.Italic;
                TextBoxOfBlock.FontStyle = FontStyles.Italic;
            }
            else if (formatText == "FormatUnderline")
            {
                TextBlockOfBlock.TextDecorations = TextDecorations.Underline;
                TextBoxOfBlock.TextDecorations = TextDecorations.Underline;
            }
        }

        public void SetFontWeight()
        {
            TextBlockOfBlock.FontWeight = FontWeights.Bold;
            TextBoxOfBlock.FontWeight = FontWeights.Bold;
        }

        public void SetFontStyles()
        {
            TextBlockOfBlock.FontStyle = FontStyles.Italic;
            TextBoxOfBlock.FontStyle = FontStyles.Italic;
        }

        public void SetTextDecorations()
        {
            TextBlockOfBlock.TextDecorations = TextDecorations.Underline;
            TextBoxOfBlock.TextDecorations = TextDecorations.Underline;
        }

        public void UnsetFontWeight()
        {
            TextBlockOfBlock.FontWeight = FontWeights.Normal;
            TextBoxOfBlock.FontWeight = FontWeights.Normal;
        }

        public void UnsetFontStyles()
        {
            TextBlockOfBlock.FontStyle = FontStyles.Normal;
            TextBoxOfBlock.FontStyle = FontStyles.Normal;
        }

        public void UnsetTextDecorations()
        {
            TextBlockOfBlock.TextDecorations = null;
            TextBoxOfBlock.TextDecorations = null;
        }

        protected void SetPropertyControl(ControlSize textFieldSize, ControlOffset? textFieldOffset = null)
        {
            SetSize(FrameBlock, ControlSize);
            SetSize(TextBoxOfBlock, textFieldSize);
            SetSize(TextBlockOfBlock, textFieldSize);
            if (textFieldOffset != null)
            {
                SetCoordinates(TextBoxOfBlock, textFieldOffset);
                SetCoordinates(TextBlockOfBlock, textFieldOffset);
            }
            
            ChangeCoordinatesConnectionPoints();
            ChangeHighlightedBlock();
        }
    }
}