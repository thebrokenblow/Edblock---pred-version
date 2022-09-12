using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using Flowchart_Editor.Model;
using System.Collections.Generic;
using Flowchart_Editor.View.Menu.Blocks.PolygonBasedBlock;

namespace Flowchart_Editor.Models
{
    [BlockName("CycleWhileBeginBlock")]
    public class CycleWhileBeginBlock : Block, IPolygonBased
    {
        private readonly PolygonBased cycleWhileBeginBlock;
        private const int sideProjection = 10;
        public CycleWhileBeginBlock()
        {
            initialText = "Цикл while начало";
            cycleWhileBeginBlock = new();
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

        private void SetPropertyControl()
        {
            ControlSize textFieldSize = GetSizeTextField(ControlSize);
            ControlOffset textFieldOffset = GetOffsetTextField();
            SetCoordinatesPoints(ControlSize);
            cycleWhileBeginBlock.SetPointPolygon();
            SetSize(FrameBlock, ControlSize);
            SetSize(TextBoxOfBlock, textFieldSize);
            SetSize(TextBlockOfBlock, textFieldSize);
            SetCoordinates(TextBoxOfBlock, textFieldOffset);
            SetCoordinates(TextBlockOfBlock, textFieldOffset);

            SetCoordinatesConnectionPoints();
            ChangeCoordinatesConnectionPoints();
            ChangeHighlightedBlock();
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

        public void SetCoordinatesPoints(ControlSize polygonSize)
        {
            List<Point> pointsCycleWhileBeginBlock = cycleWhileBeginBlock.PointsPolygon;
            double height = polygonSize.Height;
            double width = polygonSize.Width;

            pointsCycleWhileBeginBlock.Clear();

            Point poinCycleForBlock = new(0, height);
            pointsCycleWhileBeginBlock.Add(poinCycleForBlock);

            poinCycleForBlock = new(0, sideProjection);
            pointsCycleWhileBeginBlock.Add(poinCycleForBlock);

            poinCycleForBlock = new(sideProjection, 0);
            pointsCycleWhileBeginBlock.Add(poinCycleForBlock);

            poinCycleForBlock = new(width - sideProjection, 0);
            pointsCycleWhileBeginBlock.Add(poinCycleForBlock);

            poinCycleForBlock = new(width, sideProjection);
            pointsCycleWhileBeginBlock.Add(poinCycleForBlock);

            poinCycleForBlock = new(width, height);
            pointsCycleWhileBeginBlock.Add(poinCycleForBlock);
        }

        public void SetPropertyPolyginBlock()
        {
            Polygon polygonCycleWhileBegin = cycleWhileBeginBlock.FramePolygon;
            SetCoordinatesPoints(ControlSize);
            cycleWhileBeginBlock.SetPointPolygon();
            string color = "#FFCCCCFF";
            Brush backgroundColor = GetBackgroundColor(color);
            polygonCycleWhileBegin.Fill = backgroundColor;
            FrameBlock.Children.Add(polygonCycleWhileBegin);
        }
    }
}