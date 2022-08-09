using System.Windows;
using System.Windows.Media;
using Flowchart_Editor.Model;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Windows.Shapes;

namespace Flowchart_Editor.Models
{
    [BlockName("ConditionBlock")]
    public class ConditionBlock : Block
    {
        protected List<Point> listPoints = new();
        private const int offsetConnectionPoint = 3;
        public ConditionBlock(Canvas destination)
        {
            EditField = destination;
            initialText = "Условие";

            Brush backgroundColor = GetBackgroundColor("#FF60B2D3");
            polygonBlock.Fill = backgroundColor;

            SetPropertyFrameBlock();
            
            SetCoordinatesPoint(ControlSize);

            polygonBlock = SetPointPolygon(listPoints);

            AddPointPolygon(polygonBlock);

            double width = ControlSize.Width / 2;
            double height = ControlSize.Height / 2;
            ControlSize textFieldSize = new(width, height);

            double offsetLeft = ControlSize.Width / 2 - ControlSize.Width / 4;
            double offsetTop = ControlSize.Height / 4;
            ControlOffset textFieldOffset = new(offsetLeft, offsetTop);

            SetPropertyTextField(textFieldSize, textFieldOffset);

            SetCoordinatesConnectionPoints();

            InitializingConnectionPoints(listCoordinatesConnectionPoints);
        }

        override public UIElement GetUIElement()
        {
            return FrameBlock;
        }

        private void SetCoordinatesPoint(ControlSize controlSize)
        {
            double defaulWidth = controlSize.Width;
            double defaulHeight = controlSize.Height;

            Point Point1 = new(0, defaulHeight / 2);
            listPoints.Add(Point1);
            Point Point2 = new(defaulWidth / 2, defaulHeight);
            listPoints.Add(Point2);
            Point Point3 = new(defaulWidth, defaulHeight / 2);
            listPoints.Add(Point3);
            Point Point4 = new(defaulWidth / 2, 0);
            listPoints.Add(Point4);
            Point Point5 = new(0, defaulHeight / 2);
            listPoints.Add(Point5);
        }

        public override void SetWidth(int valueBlockWidth)
        {
            ControlSize.Width = valueBlockWidth;
            SetCoordinatesPoint(ControlSize);
            SetPointPolygon(listPoints);

            ControlSize controlSize = new(valueBlockWidth, 0);
            SetSize(FrameBlock, controlSize);
            SetSize(TextBoxOfBlock, controlSize);
            SetSize(TextBlockOfBlock, controlSize);

            double valueSetLeftText = valueBlockWidth / 2 - valueBlockWidth / 4;
            double valueSetTopText = DefaultPropertyForBlock.height / 4;
            Canvas.SetLeft(listConnectionPoints[0], valueBlockWidth / 2 - offsetConnectionPoint);
            Canvas.SetLeft(listConnectionPoints[1], 0);
            Canvas.SetLeft(listConnectionPoints[2], valueBlockWidth / 2 - offsetConnectionPoint);
            Canvas.SetLeft(listConnectionPoints[3], valueBlockWidth - offsetConnectionPoint * 2);
        }

        public override void SetHeight(int valueBlockHeight)
        {
            ControlSize.Height = valueBlockHeight;
            SetCoordinatesPoint(ControlSize);
            SetPointPolygon(listPoints);
            double valueSetLeftText = DefaultPropertyForBlock.width / 2 - DefaultPropertyForBlock.width / 4;
            double valueSetTopText = valueBlockHeight / 4;
            Canvas.SetTop(listConnectionPoints[0], -offsetConnectionPoint);
            Canvas.SetTop(listConnectionPoints[1], valueBlockHeight / 2 - offsetConnectionPoint);
            Canvas.SetTop(listConnectionPoints[2], valueBlockHeight - offsetConnectionPoint);
            Canvas.SetTop(listConnectionPoints[3], valueBlockHeight / 2 - offsetConnectionPoint);
        }

        protected override void SetCoordinatesConnectionPoints()
        {
            double width = ControlSize.Width;
            double height = ControlSize.Height;

            double connectionPointsX = width / 2 - offsetConnectionPoint;
            double connectionPointsY = -offsetConnectionPoint;
            coordinatesConnectionPoints = new(connectionPointsX, connectionPointsY);
            listCoordinatesConnectionPoints.Add(coordinatesConnectionPoints);

            connectionPointsX = -offsetConnectionPoint;
            connectionPointsY = height / 2 - offsetConnectionPoint;
            coordinatesConnectionPoints = new(connectionPointsX, connectionPointsY);
            listCoordinatesConnectionPoints.Add(coordinatesConnectionPoints);

            connectionPointsX = width / 2 - offsetConnectionPoint;
            connectionPointsY = height - offsetConnectionPoint;
            coordinatesConnectionPoints = new(connectionPointsX, connectionPointsY);
            listCoordinatesConnectionPoints.Add(coordinatesConnectionPoints);

            connectionPointsX = width - offsetConnectionPoint;
            connectionPointsY = height / 2 - offsetConnectionPoint;
            coordinatesConnectionPoints = new(connectionPointsX, connectionPointsY);
            listCoordinatesConnectionPoints.Add(coordinatesConnectionPoints);

            coordinatesConnectionPoints = new(connectionPointsX, connectionPointsY);
        }
    }
}