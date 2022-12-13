using System.Windows;
using System.Windows.Media;
using Flowchart_Editor.Model;
using System.Collections.Generic;
using Flowchart_Editor.View.Menu.Blocks.PolygonBasedBlock;

namespace Flowchart_Editor.Models
{
    [BlockName("CycleWhileEndBlock")]
    public class CycleWhileEndBlock : Block, IPolygonBased
    {
        private readonly PolygonBased cycleWhileEndBlock = new();
        private const int sideProjection = 10;

        public CycleWhileEndBlock()
        {
            initialText = "Цикл while конец";
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
            SetCoordinatesConnectionPoints();
            SetPropertyControl(textFieldSize, textFieldOffset);
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
            SetCoordinatesPoints(ControlSize);
            cycleWhileEndBlock.SetPointPolygon();   
            FrameBlock.Children.Add(cycleWhileEndBlock.FramePolygon);
        }

        protected override void SetBackground()
        {
            string color = "#FFCCCCFF";
            Brush backgroundColor = GetBackgroundColor(color);
            cycleWhileEndBlock.FramePolygon.Fill = backgroundColor;
        }

        public override Block GetCopyBlock()
        {
            throw new System.NotImplementedException();
        }
    }
}