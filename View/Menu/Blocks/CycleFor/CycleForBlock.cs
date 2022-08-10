using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.Collections.Generic;
using Flowchart_Editor.Model;

namespace Flowchart_Editor.Models
{
    [BlockName("CycleForBlock")]
    public class CycleForBlock : Block
    {
        protected List<Point> listPoints = new();
        private const int offsetConnectionPoint = 2;
        private const int sizeClippedCorner = 10; //подумать ещё над названием
        public CycleForBlock(Canvas destination)
        {
            EditField = destination;
            initialText = "Цикл for";

            SetPropertyFrameBlock();
            SetCoordinatesCycleForBlock(ControlSize);
            polygonBlock = SetPointPolygon(listPoints);
            AddPointPolygon(polygonBlock);

            string color = "#FFFFC618";
            Brush backgroundColor = GetBackgroundColor(color);
            SetFillPolygon(backgroundColor);

            ControlSize sizeTextField = GetSizeTextField();

            ControlOffset offsetTextField = GetOffsetTextField();

            SetPropertyTextField(sizeTextField, offsetTextField);

            SetCoordinatesConnectionPoints();

            InitializingConnectionPoints(listCoordinatesConnectionPoints);
        }

        override public UIElement GetUIElement()
        {            
            return FrameBlock;
        }

        private static ControlSize GetSizeTextField()
        {
            double width = ControlSize.Width - sizeClippedCorner * 2;
            double height = ControlSize.Height;
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

        private void SetCoordinatesCycleForBlock(ControlSize controlSize)
        {
            double height = controlSize.Height;
            double width = controlSize.Width;

            listPoints.Clear();

            Point poinCycleForBlock = new(sizeClippedCorner, 0);
            listPoints.Add(poinCycleForBlock);

            poinCycleForBlock = new(sizeClippedCorner, 0);
            listPoints.Add(poinCycleForBlock);

            poinCycleForBlock = new(0, sizeClippedCorner);
            listPoints.Add(poinCycleForBlock);

            poinCycleForBlock = new(0, height - sizeClippedCorner);
            listPoints.Add(poinCycleForBlock);

            poinCycleForBlock = new(sizeClippedCorner, height);
            listPoints.Add(poinCycleForBlock);

            poinCycleForBlock = new(width - sizeClippedCorner, height);
            listPoints.Add(poinCycleForBlock);

            poinCycleForBlock = new(width, height - sizeClippedCorner);
            listPoints.Add(poinCycleForBlock);

            poinCycleForBlock = new(width, sizeClippedCorner);
            listPoints.Add(poinCycleForBlock);

            poinCycleForBlock = new(width - sizeClippedCorner, 0);
            listPoints.Add(poinCycleForBlock);
        }

        private void SetPropertyControl(ControlSize blockSize, ControlSize textFieldSize, ControlOffset textFieldOffset)
        {
            SetCoordinatesCycleForBlock(blockSize);
            SetPointPolygon(listPoints);
            SetSize(FrameBlock, blockSize);
            SetSize(TextBoxOfBlock, textFieldSize);
            SetSize(TextBlockOfBlock, textFieldSize);
            SetCoordinates(TextBoxOfBlock, textFieldOffset);
            SetCoordinates(TextBlockOfBlock, textFieldOffset);
        }

        public override void SetWidth(int valueBlockWidth)
        {
            ControlSize.Width = valueBlockWidth;
            ControlSize blockSize = new(valueBlockWidth, ControlSize.Height);

            double textFielwidth = valueBlockWidth / 2;
            double textFielHeight = ControlSize.Height / 2;
            ControlSize textFieldSize = new(textFielwidth, textFielHeight);

            double offsetLeft = valueBlockWidth / 2 - valueBlockWidth / 4;
            double offsetTop = ControlSize.Height / 4;
            ControlOffset textFieldOffset = new(offsetLeft, offsetTop);

            SetPropertyControl(blockSize, textFieldSize, textFieldOffset);

            int[] coordinatesConnectionPoints = new int[4];
            coordinatesConnectionPoints[0] = valueBlockWidth / 2 - offsetConnectionPoint;
            coordinatesConnectionPoints[2] = valueBlockWidth / 2 - offsetConnectionPoint;
            coordinatesConnectionPoints[3] = valueBlockWidth - offsetConnectionPoint * 2;
            SetLeftConnectionPoints(coordinatesConnectionPoints);
        }

        public override void SetHeight(int valueBlockHeight)
        {
            ControlSize.Height = valueBlockHeight;
            ControlSize blockSize = new(ControlSize.Width, valueBlockHeight);

            double textFielHeight = valueBlockHeight / 2;
            double textFielwidth = ControlSize.Width / 2;
            ControlSize textFieldSize = new(textFielwidth, textFielHeight);

            double offsetLeft = ControlSize.Width / 2 - ControlSize.Width / 4;
            double offsetTop = valueBlockHeight / 4;
            ControlOffset textFieldOffset = new(offsetLeft, offsetTop);

            SetPropertyControl(blockSize, textFieldSize, textFieldOffset);

            int[] coordinatesConnectionPoints = new int[4];
            coordinatesConnectionPoints[1] = valueBlockHeight / 2 - offsetConnectionPoint;
            coordinatesConnectionPoints[2] = valueBlockHeight - offsetConnectionPoint;
            coordinatesConnectionPoints[3] = valueBlockHeight / 2 - offsetConnectionPoint;
            SetTopConnectionPoints(coordinatesConnectionPoints);
        } 
    }
}