using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using Flowchart_Editor.Model;
using System;

namespace Flowchart_Editor.Models
{
    [BlockName("ActionBlock")]
    public class ActionBlock : Block
    {
        private const int offsetConnectionPoint = 2;
        public ActionBlock(Canvas editField)
        {
            EditField = editField;
            initialText = "Действие";
            Brush backgroundColor = GetBackgroundColor("#FF52C0AA");

            SetPropertyFrameBlock(backgroundColor);
            
            SetPropertyTextField(ControlSize, ControlOffset);

            SetCoordinatesConnectionPoints();

            InitializingConnectionPoints(listCoordinatesConnectionPoints);
        }

        override public UIElement GetUIElement()
        {
            return FrameBlock;
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
            connectionPointsY = height - offsetConnectionPoint * 2;
            coordinatesConnectionPoints = new(connectionPointsX, connectionPointsY);
            listCoordinatesConnectionPoints.Add(coordinatesConnectionPoints);

            connectionPointsX = width - offsetConnectionPoint * 2;
            connectionPointsY = height / 2 - offsetConnectionPoint;
            coordinatesConnectionPoints = new(connectionPointsX, connectionPointsY);
            listCoordinatesConnectionPoints.Add(coordinatesConnectionPoints);

            coordinatesConnectionPoints = new(connectionPointsX, connectionPointsY);
        }

        public override void SetWidth(int valueBlockWidth)
        {
            ControlSize controlSize = new(valueBlockWidth, 0);
            SetSize(FrameBlock, controlSize);
            SetSize(TextBoxOfBlock, controlSize);
            SetSize(TextBlockOfBlock, controlSize);
            int[] coordinatesConnectionPoints = new int[4];
            coordinatesConnectionPoints[0] = valueBlockWidth / 2 - offsetConnectionPoint;
            coordinatesConnectionPoints[2] = valueBlockWidth / 2 - offsetConnectionPoint;
            coordinatesConnectionPoints[3] = valueBlockWidth - offsetConnectionPoint * 2;
            SetLeftCoordinatesConnectionPoints(coordinatesConnectionPoints);
        }

        public override void SetHeight(int valueBlockHeight)
        {
            ControlSize controlSize = new(0, valueBlockHeight);
            SetSize(FrameBlock, controlSize);
            SetSize(TextBoxOfBlock, controlSize);
            SetSize(TextBlockOfBlock, controlSize);
            int[] coordinatesConnectionPoints = new int[4];
            coordinatesConnectionPoints[1] = valueBlockHeight / 2 - offsetConnectionPoint;
            coordinatesConnectionPoints[2] = valueBlockHeight - offsetConnectionPoint;
            coordinatesConnectionPoints[3] = valueBlockHeight / 2 - offsetConnectionPoint;
            SetTopCoordinatesConnectionPoints(coordinatesConnectionPoints);   
        }
    }
}