using System;
using System.Collections.Generic;
using System.Windows;
using Flowchart_Editor.Model;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

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
        protected static ControlSize ControlSize { get; private set; } = new(defaultWidth, defaulHeight);
        protected ControlOffset ControlOffset { get; private set; } = new(0, 0);
        protected Polygon polygonBlock = new();
        
        protected string? initialText;
        protected Tuple<double, double> coordinatesConnectionPoints = new(0, 0);
        protected List<Tuple<double, double>> listCoordinatesConnectionPoints = new();
        protected List<Ellipse> connectionPoints = new();
        protected readonly FontFamily defaultFontFamily = DefaultPropertyForBlock.fontFamily;
        protected readonly Uri uri = new("View/Style/style.xaml", UriKind.Relative);

        abstract public UIElement GetUIElement();
        abstract public void SetWidth(int valueBlockWidth);
        abstract public void SetHeight(int valueBlockHeight);
        abstract protected void SetCoordinatesConnectionPoints();

        private void MouseMoveBlockForMovements(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && e.Source is not TextBox)
                DoDragDropControlElement(typeof(Canvas), sender, sender);
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
            TextBoxOfBlock.MouseDoubleClick += SetTypeTextField;
            string nameStyle = "TextBoxStyleForBlock";
            SetProperty(TextBoxOfBlock, nameStyle, controlOffset, blockSize);
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

        protected void SetTypeTextField(object sender, MouseButtonEventArgs e)
        {
            if (e.Source is TextBlock)
            {
                if (e.ClickCount == 2)
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
            for (int i = 1; i < connectionPoints.Count; i++) //перебор начинается с 0, так как при масштабировании высоты блока не надо менять самую верхнюю точку соединения
                Canvas.SetTop(connectionPoints[i], coordinatesConnectionPoints[i]);
        }

        protected void SetPropertyFrameBlock(Brush? backgroundColor = null)
        {
            SetSize(FrameBlock, ControlSize);
            if (backgroundColor != null)
                FrameBlock.Background = backgroundColor;
            FrameBlock.MouseMove += MouseMoveBlockForMovements;
        }

        protected void SetFillPolygon(Brush backgroundColor)
        {
            polygonBlock.Fill = backgroundColor;
        }

        protected Polygon SetPointPolygon(List<Point> listPoints)
        {
            PointCollection pointCollection = new();
            foreach (Point itemPoint in listPoints)
                pointCollection.Add(itemPoint);

            polygonBlock.Points = pointCollection;
            return polygonBlock;
        }

        protected void AddPointPolygon(Polygon polygonBlock)
        {
            FrameBlock.Children.Add(polygonBlock);
        }

        protected void ClickOnConnectionPoint(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                
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
    }
}