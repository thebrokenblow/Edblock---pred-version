using System.Windows;
using System.Windows.Media;
using Flowchart_Editor.Model;
using System.Collections.Generic;
using Flowchart_Editor.View.Menu.Blocks.PolygonBasedBlock;
using System.Windows.Shapes;

namespace Flowchart_Editor.Models
{
    [BlockName("CycleWhileEndBlock")]
    public class CycleWhileEndBlock : Block, IPolygonBased
    {
        private readonly PolygonBased cycleWhileEndBlock;
        private const int sideProjection = 10;

        public CycleWhileEndBlock()
        {
            initialText = "Цикл while конец";
            cycleWhileEndBlock = new();
            SetPropertyFrameBlock();
            SetPropertyPolyginBlock();
            ControlSize sizeTextField = GetSizeTextField(ControlSize);
            ControlOffset offsetTextField = GetOffsetTextField();
            SetPropertyTextField(sizeTextField, offsetTextField);
            SetCoordinatesConnectionPoints();
            InitializingConnectionPoints();
            DrawHighlightedBlock();
        }

        private static ControlSize GetSizeTextField(ControlSize controlSize)
        {
            double width = controlSize.Width - sideProjection * 2;
            double height = controlSize.Height;
            ControlSize sizeTextField = new(width, height);
            return sizeTextField;
        }

        private static ControlOffset GetOffsetTextField()
        {
            double offsetLeft = sideProjection;
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
            cycleWhileEndBlock.SetPointPolygon();
            SetSize(FrameBlock, ControlSize);
            SetSize(TextBoxOfBlock, textFieldSize);
            SetSize(TextBlockOfBlock, textFieldSize);
            SetCoordinates(TextBoxOfBlock, textFieldOffset);
            SetCoordinates(TextBlockOfBlock, textFieldOffset);
            SetCoordinatesConnectionPoints();
            ChangeCoordinatesConnectionPoints();
            ChangeHighlightedBlock();
        }

        public void SetCoordinatesPoints(ControlSize polygonSize)
        {
            List<Point> pointsCycleWhileEndBlock = cycleWhileEndBlock.PointsPolygon;
            double height = polygonSize.Height;
            double width = polygonSize.Width;

            pointsCycleWhileEndBlock.Clear();

            Point poinCycleForBlock = new(0, 0);
            pointsCycleWhileEndBlock.Add(poinCycleForBlock);

            poinCycleForBlock = new(0, height - sideProjection);
            pointsCycleWhileEndBlock.Add(poinCycleForBlock);

            poinCycleForBlock = new(sideProjection, height);
            pointsCycleWhileEndBlock.Add(poinCycleForBlock);

            poinCycleForBlock = new(width - sideProjection, height);
            pointsCycleWhileEndBlock.Add(poinCycleForBlock);

            poinCycleForBlock = new(width, height - sideProjection);
            pointsCycleWhileEndBlock.Add(poinCycleForBlock);

            poinCycleForBlock = new(width, 0);
            pointsCycleWhileEndBlock.Add(poinCycleForBlock);
        }

        public void SetPropertyPolyginBlock()
        {
            Polygon polygonCycleWhileEnd = cycleWhileEndBlock.FramePolygon;
            SetCoordinatesPoints(ControlSize);
            cycleWhileEndBlock.SetPointPolygon();
            string color = "#FFCCCCFF";
            Brush backgroundColor = GetBackgroundColor(color);
            polygonCycleWhileEnd.Fill = backgroundColor;
            FrameBlock.Children.Add(polygonCycleWhileEnd);
        }
    }
}