using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using Flowchart_Editor.Model;
using System.Collections.Generic;
using Flowchart_Editor.View.Menu.Blocks.PolygonBasedBlock;

namespace Flowchart_Editor.Models
{
    [BlockName("InputOutputBlock")]
    public class InputOutputBlock : Block, IPolygonBased
    {
        private readonly PolygonBased inputOutputBlock;
        private const int sideProjection = 20;

        public InputOutputBlock()
        {       
            initialText = "Ввод/Вывод";
            inputOutputBlock = new();
            SetPropertyFrameBlock();
            SetPropertyPolyginBlock();
            ControlSize sizeTextField = GetSizeTextField(ControlSize);
            ControlOffset offsetTextField = GetOffsetTextField();
            SetPropertyTextField(sizeTextField, offsetTextField);
            SetCoordinatesConnectionPoints(sideProjection);
            InitializingConnectionPoints();
            DrawHighlightedBlock();
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

        public override void SetWidth(int valueBlockWidth)
        {
            ControlSize.Width = valueBlockWidth;
            SetPropertyControl();
        }

        public override void SetHeight(int valueBlockHeight)
        {
            ControlSize.Height = valueBlockHeight;
            SetPropertyControl();
        }

        private void SetPropertyControl()
        {
            ControlSize textFieldSize = GetSizeTextField(ControlSize);
            ControlOffset textFieldOffset = GetOffsetTextField();
            SetCoordinatesPoints(ControlSize);
            inputOutputBlock.SetPointPolygon();
            SetSize(FrameBlock, ControlSize);
            SetSize(TextBoxOfBlock, textFieldSize);
            SetSize(TextBlockOfBlock, textFieldSize);
            SetCoordinates(TextBoxOfBlock, textFieldOffset);
            SetCoordinates(TextBlockOfBlock, textFieldOffset);
            SetCoordinatesConnectionPoints(sideProjection);
            ChangeCoordinatesConnectionPoints();
            ChangeHighlightedBlock();
        }

        public void SetPropertyPolyginBlock()
        {
            Polygon polygonInputOutputBlock = inputOutputBlock.FramePolygon;
            SetCoordinatesPoints(ControlSize);
            inputOutputBlock.SetPointPolygon();
            string color = "#FF008080";
            Brush backgroundColor = GetBackgroundColor(color);
            polygonInputOutputBlock.Fill = backgroundColor;
            FrameBlock.Children.Add(polygonInputOutputBlock);
        }

        public void SetCoordinatesPoints(ControlSize polygonSize)
        {
            List<Point> pointsInputOutputBlock = inputOutputBlock.PointsPolygon;
            double height = polygonSize.Height;
            double width = polygonSize.Width;

            pointsInputOutputBlock.Clear();

            Point poinCycleForBlock = new(sideProjection, 0);
            pointsInputOutputBlock.Add(poinCycleForBlock);

            poinCycleForBlock = new(0, height);
            pointsInputOutputBlock.Add(poinCycleForBlock);

            poinCycleForBlock = new(width - sideProjection, height);
            pointsInputOutputBlock.Add(poinCycleForBlock);

            poinCycleForBlock = new(width, 0);
            pointsInputOutputBlock.Add(poinCycleForBlock);
        }
    }
}