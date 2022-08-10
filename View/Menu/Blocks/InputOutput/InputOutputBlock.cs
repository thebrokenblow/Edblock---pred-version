using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using System.Collections.Generic;
using Flowchart_Editor.Model;

namespace Flowchart_Editor.Models
{
    [BlockName("InputOutputBlock")]
    public class InputOutputBlock : Block
    {
        private readonly List<Point> listPoints = new();
        private const int sideProjection = 20;
        private const int offsetConnectionPoint = 2;

        public InputOutputBlock(Canvas destination)
        {
            EditField = destination;       
            initialText = "Ввод/Вывод";

            SetPropertyFrameBlock();
            SetCoordinatesCycleWhileEndBlock(ControlSize);
            polygonBlock = SetPointPolygon(listPoints);
            AddPointPolygon(polygonBlock);

            string color = "#FF008080";
            Brush backgroundColor = GetBackgroundColor(color);
            SetFillPolygon(backgroundColor);

            ControlSize sizeTextField = GetSizeTextField(ControlSize);
            ControlOffset offsetTextField = GetOffsetTextField();
            SetPropertyTextField(sizeTextField, offsetTextField);

            SetCoordinatesConnectionPoints();
            InitializingConnectionPoints(listCoordinatesConnectionPoints);
        }

        override public UIElement GetUIElement()
        {
            return FrameBlock;
        }

        private static ControlSize GetSizeTextField(ControlSize controlSize)
        {
            double width = controlSize.Width - sideProjection * 2;
            double height = controlSize.Height - offsetConnectionPoint * 2;
            ControlSize sizeTextField = new(width, height);
            return sizeTextField;
        }

        private static ControlOffset GetOffsetTextField()
        {
            double offsetLeft = sideProjection;
            double offsetTop = offsetConnectionPoint * 2;
            ControlOffset offsetTextField = new(offsetLeft, offsetTop);
            return offsetTextField;
        }

        private void SetCoordinatesCycleWhileEndBlock(ControlSize controlSize)
        {
            double height = controlSize.Height;
            double width = controlSize.Width;

            listPoints.Clear();

            Point poinCycleForBlock = new(sideProjection, 0);
            listPoints.Add(poinCycleForBlock);

            poinCycleForBlock = new(0, height);
            listPoints.Add(poinCycleForBlock);

            poinCycleForBlock = new(width - sideProjection, height);
            listPoints.Add(poinCycleForBlock);

            poinCycleForBlock = new(width, 0);
            listPoints.Add(poinCycleForBlock);
        }

        public override void SetWidth(int valueBlockWidth)
        {
            //Canvas.SetLeft(firstPointConnect, valueBlockWidth / 2);
            //Canvas.SetLeft(thirdPointConnect, valueBlockWidth / 2);
            //Canvas.SetLeft(fourthPointConnect, valueBlockWidth - 13);
        }

        public override void SetHeight(int valueBlockHeight)
        {
            //Canvas.SetTop(secondPointConnect, valueBlockHeight / 2 - 5);
            //Canvas.SetTop(thirdPointConnect, valueBlockHeight - 3);
            //Canvas.SetTop(fourthPointConnect, valueBlockHeight / 2 - 5);
        }

        protected override void SetCoordinatesConnectionPoints()
        {
            double width = ControlSize.Width;
            double height = ControlSize.Height;

            double connectionPointsX = width / 2 - offsetConnectionPoint;
            double connectionPointsY = -offsetConnectionPoint;
            coordinatesConnectionPoints = new(connectionPointsX, connectionPointsY);
            listCoordinatesConnectionPoints.Add(coordinatesConnectionPoints);

            connectionPointsX = sideProjection / 2 - offsetConnectionPoint;
            connectionPointsY = height / 2 - offsetConnectionPoint * 2;
            coordinatesConnectionPoints = new(connectionPointsX, connectionPointsY);
            listCoordinatesConnectionPoints.Add(coordinatesConnectionPoints);

            connectionPointsX = width / 2 - offsetConnectionPoint;
            connectionPointsY = height - offsetConnectionPoint;
            coordinatesConnectionPoints = new(connectionPointsX, connectionPointsY);
            listCoordinatesConnectionPoints.Add(coordinatesConnectionPoints);

            connectionPointsX = width - sideProjection / 2 - offsetConnectionPoint;
            connectionPointsY = height / 2 - offsetConnectionPoint * 2;
            coordinatesConnectionPoints = new(connectionPointsX, connectionPointsY);
            listCoordinatesConnectionPoints.Add(coordinatesConnectionPoints);
        }
    }
}