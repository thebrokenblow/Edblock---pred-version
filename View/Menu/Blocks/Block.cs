using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using Flowchart_Editor.Model;
using System.Windows.Controls;
using System.Collections.Generic;

namespace Flowchart_Editor.Models
{
    public abstract class Block
    {
        public Canvas FrameBlock { get; set; } = new();
        public static Canvas? EditField { get; set; }
        public TextBox TextBoxOfBlock { get; set; } = new();
        public TextBlock TextBlockOfBlock { get; set; } = new();
        public List<List<Line>> ListsLineConnectionBlock { get; set; } = new();
        private const int defaultWidth = 140;
        private const int defaulHeight = 60;
        private const int radiusPoint = 6;
        protected const int offsetConnectionPoint = 3;
        protected string initialText = "";
        private readonly Border borderHighlightedLine = new();
        protected static ControlSize ControlSize { get; set; } = new(defaultWidth, defaulHeight);
        protected Tuple<double, double> coordinatesConnectionPoints = new(0, 0);
        protected List<Tuple<double, double>> listCoordinatesConnectionPoints = new();
        protected List<Ellipse> connectionPoints = new();
        protected readonly Uri uri = new("View/СontrolStyle/СontrolsStyle.xaml", UriKind.Relative);

        abstract public UIElement GetUIElement();
        abstract public void SetWidth(int valueBlockWidth);
        abstract public void SetHeight(int valueBlockHeight);

        private void MouseMoveBlockForMovements(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && e.Source is not TextBox)
            {
                Type typeBlock = typeof(Canvas);
                DoDragDropControlElement(typeBlock, sender, sender);
            }
            e.Handled = true;
        }

        public static void DoDragDropControlElement(Type typeControlElement, object controlElement, object sender)
        {
            DataObject data = new(typeControlElement, controlElement);
            DragDrop.DoDragDrop(sender as DependencyObject, data, DragDropEffects.Copy);
        }

        protected void SetStyle(FrameworkElement frameworkElement, string nameStyle)
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
            TextBoxOfBlock.LostFocus += TextBoxOfBlock_LostFocus; ; ;
            TextBoxOfBlock.MouseDoubleClick += SetTypeTextField;
            string nameStyle = "TextBoxStyleForBlock";
            SetProperty(TextBoxOfBlock, nameStyle, controlOffset, blockSize);
        }

        private void TextBoxOfBlock_LostFocus(object sender, RoutedEventArgs e)
        {
           
        }

        private void SetPropertyTextBlock(ControlSize blockSize, ControlOffset controlOffset)
        {
            
            TextBlockOfBlock.MouseDown += SetTypeTextField;
            TextBlockOfBlock.Text = initialText;
            string nameStyle = "TextBlockStyleForBlock";
            SetProperty(TextBlockOfBlock, nameStyle, controlOffset, blockSize);
            if (FrameBlock != null)
                FrameBlock.Children.Add(TextBlockOfBlock);
        }

        private void HighlightedBlock(object sender, MouseButtonEventArgs e)
        {
            DrawHighlightedBlock();
            Edblock.ListHighlightedBlock.Add(this);
        }

        protected void DrawHighlightedBlock()
        {
            borderHighlightedLine.BorderBrush = Brushes.Blue;
            borderHighlightedLine.Width = ControlSize.Width;
            borderHighlightedLine.Height = ControlSize.Height;
            borderHighlightedLine.BorderThickness = new Thickness(1);
            if (!FrameBlock.Children.Contains(borderHighlightedLine))
                FrameBlock.Children.Add(borderHighlightedLine);
            Edblock.ListHighlightedBlock.Add(this);
        }

        public void RemoveHighlightedBlock()
        {
            FrameBlock.Children.Remove(borderHighlightedLine);
            Edblock.ListHighlightedBlock.Remove(this);
        }

        protected void SetTypeTextField(object sender, MouseButtonEventArgs e)
        {
            if (e.Source is TextBlock)
            {
                if (e.ClickCount == 1)
                {
                    DrawHighlightedBlock();
                }
                else if (e.ClickCount == 2)
                {
                    FrameBlock.Children.Remove(TextBlockOfBlock);
                    TextBoxOfBlock.Text = TextBlockOfBlock.Text;
                    FrameBlock.Children.Add(TextBoxOfBlock);
                }
            }
            else
            {
                FrameBlock.Children.Remove(TextBoxOfBlock);
                TextBlockOfBlock.Text = TextBoxOfBlock.Text;
                FrameBlock.Children.Add(TextBlockOfBlock);
            }
        }

        protected void InitializingConnectionPoints(List<Tuple<double, double>> coordinatesConnectionPoints)
        {
            string nameStyle = "EllipseStyle";
            foreach (var itemCoordinatesPoint in coordinatesConnectionPoints)
            {
                Ellipse connectionPoint = new();
                ControlSize sizeConnectionPoints = new(radiusPoint, radiusPoint);
                ControlOffset offsetConnectionPoints = new(itemCoordinatesPoint.Item1, itemCoordinatesPoint.Item2);

                SetProperty(connectionPoint, nameStyle, offsetConnectionPoints, sizeConnectionPoints);

                connectionPoints.Add(connectionPoint);
                connectionPoint.MouseMove += ClickOnConnectionPoint;
                FrameBlock.Children.Add(connectionPoint);
            }
        }

        protected void SetLeftConnectionPoints(int[] coordinatesConnectionPoints)
        {
            for (int i = 0; i < connectionPoints.Count; i++)
            {
                if (i != 1) //1 - это левая точка соединения, её не надо смещать при увеличении блока 
                    Canvas.SetLeft(connectionPoints[i], coordinatesConnectionPoints[i]);
            }
        }

        protected void SetTopConnectionPoints(int[] coordinatesConnectionPoints)
        {
            for (int i = 1; i < connectionPoints.Count; i++) //перебор начинается с 1, так как при масштабировании высоты блока не надо менять самую верхнюю точку соединения
                Canvas.SetTop(connectionPoints[i], coordinatesConnectionPoints[i]);
        }

        protected void SetPropertyFrameBlock()
        {
            SetSize(FrameBlock, ControlSize);
            FrameBlock.MouseMove += MouseMoveBlockForMovements;
        }

        protected void ClickOnConnectionPoint(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                
            }   
        }

        public void SetCoordinatesConnectionPoints(int offsetConnectionPoint, int sideProjection = 0)
        {
            double width = ControlSize.Width;
            double height = ControlSize.Height;

            double connectionPointsX = width / 2 - offsetConnectionPoint;
            double connectionPointsY = -offsetConnectionPoint;
            coordinatesConnectionPoints = new(connectionPointsX, connectionPointsY);
            listCoordinatesConnectionPoints.Add(coordinatesConnectionPoints);

            connectionPointsX = sideProjection / 2 - offsetConnectionPoint;
            connectionPointsY = height / 2 - offsetConnectionPoint;
            coordinatesConnectionPoints = new(connectionPointsX, connectionPointsY);
            listCoordinatesConnectionPoints.Add(coordinatesConnectionPoints);

            connectionPointsX = width / 2 - offsetConnectionPoint;
            connectionPointsY = height - offsetConnectionPoint;
            coordinatesConnectionPoints = new(connectionPointsX, connectionPointsY);
            listCoordinatesConnectionPoints.Add(coordinatesConnectionPoints);

            connectionPointsX = width - sideProjection / 2 - offsetConnectionPoint;
            connectionPointsY = height / 2 - offsetConnectionPoint;
            coordinatesConnectionPoints = new(connectionPointsX, connectionPointsY);
            listCoordinatesConnectionPoints.Add(coordinatesConnectionPoints);
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
    }
}