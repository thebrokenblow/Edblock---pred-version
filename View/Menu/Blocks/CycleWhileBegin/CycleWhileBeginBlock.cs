using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using Flowchart_Editor.Model;
using System.Collections.Generic;

namespace Flowchart_Editor.Models
{
    [BlockName("CycleWhileBeginBlock")]
    public class CycleWhileBeginBlock : Block
    {
        private List<Point> listPoints = new();
        private const int offsetConnectionPoint = 2;
        private const int sizeClippedCorner = 10; //подумать ещё над названием
        public CycleWhileBeginBlock(Canvas editField)
        {
            EditField = editField;
            initialText = "Цикл while начало";

            SetPropertyFrameBlock();
            SetCoordinatesCycleWhileBeginBlock(ControlSize);
            polygonBlock = SetPointPolygon(listPoints);
            AddPointPolygon(polygonBlock);

            string color = "#FFCCCCFF";
            Brush backgroundColor = GetBackgroundColor(color);
            SetFillPolygon(backgroundColor);

            ControlSize sizeTextField = GetSizeTextField(ControlSize);
            ControlOffset offsetTextField = GetOffsetTextField();
            SetPropertyTextField(sizeTextField, offsetTextField);

            SetCoordinatesConnectionPoints();
            InitializingConnectionPoints(listCoordinatesConnectionPoints);
        }

        private static ControlSize GetSizeTextField(ControlSize controlSize)
        {
            double width = controlSize.Width - sizeClippedCorner * 2;
            double height = controlSize.Height;
            ControlSize sizeTextField = new(width, height);
            return sizeTextField;
        }

        private static ControlOffset GetOffsetTextField()
        {
            double offsetLeft = sizeClippedCorner;
            double offsetTop = 0;
            ControlOffset offsetTextField = new(offsetLeft, offsetTop);
            return offsetTextField;
        }

        override public UIElement GetUIElement()
        {
            return FrameBlock;
        }

        private void SetCoordinatesCycleWhileBeginBlock(ControlSize controlSize)
        {
            double height = controlSize.Height;
            double width = controlSize.Width;

            listPoints.Clear();

            Point poinCycleForBlock = new(0, height);
            listPoints.Add(poinCycleForBlock);

            poinCycleForBlock = new(0, sizeClippedCorner);
            listPoints.Add(poinCycleForBlock);

            poinCycleForBlock = new(sizeClippedCorner, 0);
            listPoints.Add(poinCycleForBlock);

            poinCycleForBlock = new(width - sizeClippedCorner, 0);
            listPoints.Add(poinCycleForBlock);

            poinCycleForBlock = new(width, sizeClippedCorner);
            listPoints.Add(poinCycleForBlock);

            poinCycleForBlock = new(width, height);
            listPoints.Add(poinCycleForBlock);
        }

        private void SetPropertyControl(ControlSize blockSize)
        {
            ControlSize textFieldSize = GetSizeTextField(blockSize);
            ControlOffset textFieldOffset = GetOffsetTextField();
            SetCoordinatesCycleWhileBeginBlock(blockSize);
            SetPointPolygon(listPoints);
            SetSize(FrameBlock, blockSize);
            SetSize(TextBoxOfBlock, textFieldSize);
            SetSize(TextBlockOfBlock, textFieldSize);
            SetCoordinates(TextBoxOfBlock, textFieldOffset);
            SetCoordinates(TextBlockOfBlock, textFieldOffset);
        }

        public override void SetWidth(int valueBlockWidth)
        {
            ControlSize blockSize = new(valueBlockWidth, ControlSize.Height);
            SetPropertyControl(blockSize);

            int[] coordinatesConnectionPoints = new int[4];
            coordinatesConnectionPoints[0] = valueBlockWidth / 2 - offsetConnectionPoint;
            coordinatesConnectionPoints[2] = valueBlockWidth / 2 - offsetConnectionPoint;
            coordinatesConnectionPoints[3] = valueBlockWidth - offsetConnectionPoint * 2;
            SetLeftConnectionPoints(coordinatesConnectionPoints);            
        }

        public override void SetHeight(int valueBlockHeight)
        {
            ControlSize blockSize = new(ControlSize.Width, valueBlockHeight);
            SetPropertyControl(blockSize);

            int[] coordinatesConnectionPoints = new int[4];
            coordinatesConnectionPoints[1] = valueBlockHeight / 2 - offsetConnectionPoint;
            coordinatesConnectionPoints[2] = valueBlockHeight - offsetConnectionPoint;
            coordinatesConnectionPoints[3] = valueBlockHeight / 2 - offsetConnectionPoint;
            SetTopConnectionPoints(coordinatesConnectionPoints);
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

            connectionPointsX = width - offsetConnectionPoint * 2;
            connectionPointsY = height / 2 - offsetConnectionPoint;
            coordinatesConnectionPoints = new(connectionPointsX, connectionPointsY);
            listCoordinatesConnectionPoints.Add(coordinatesConnectionPoints);
        }
    }
}