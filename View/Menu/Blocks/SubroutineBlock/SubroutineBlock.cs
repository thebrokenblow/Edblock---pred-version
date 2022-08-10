using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using Flowchart_Editor.Model;

namespace Flowchart_Editor.Models
{
    [BlockName("SubroutineBlock")]
    public class SubroutineBlock : Block
    {
        public Border borderLine = new();
        private const int offsetConnectionPoint = 2;
        private const int offsetBorderLine = 20;

        public SubroutineBlock(Canvas destination)
        {
            EditField = destination;
            initialText = "Подпрограмма";

            string color = "#FFBA64C8";
            Brush backgroundColor = GetBackgroundColor(color);
            SetPropertyFrameBlock(backgroundColor);
            SetBorderLine();

            ControlSize sizeTextField = GetSizeTextField(ControlSize);
            ControlOffset offsetTextField = GetOffsetTextField();
            SetPropertyTextField(sizeTextField, offsetTextField);

            SetCoordinatesConnectionPoints();
            InitializingConnectionPoints(listCoordinatesConnectionPoints);
        }

        private void SetBorderLine()
        {
            borderLine.BorderBrush = Brushes.Black;
            borderLine.Width = ControlSize.Width - offsetBorderLine * 2;
            borderLine.Height = ControlSize.Height;
            borderLine.BorderThickness = new Thickness(1);
            Canvas.SetLeft(borderLine, offsetBorderLine);
            FrameBlock.Children.Add(borderLine);

        }

        private static ControlSize GetSizeTextField(ControlSize controlSize)
        {
            double width = controlSize.Width - offsetBorderLine * 2;
            double height = controlSize.Height;
            ControlSize sizeTextField = new(width, height);
            return sizeTextField;
        }

        private static ControlOffset GetOffsetTextField()
        {
            double offsetLeft = offsetBorderLine;
            double offsetTop = 0;
            ControlOffset offsetTextField = new(offsetLeft, offsetTop);
            return offsetTextField;
        }

        override public UIElement GetUIElement()
        {
            return FrameBlock;
        }

        public override void SetWidth(int valueBlockWidth)
        {

        }

        public override void SetHeight(int valueBlockHeight)
        {

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