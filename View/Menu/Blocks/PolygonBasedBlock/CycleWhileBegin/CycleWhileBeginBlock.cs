using System.Windows;
using System.Windows.Media;
using Flowchart_Editor.Model;
using System.Collections.Generic;
using Flowchart_Editor.View.Menu.Blocks.PolygonBasedBlock;

namespace Flowchart_Editor.Models
{
    [BlockName("CycleWhileBeginBlock")]
    public class CycleWhileBeginBlock : Block, IPolygonBased
    {
        private readonly PolygonBased cycleWhileBeginBlock = new();
        private const int sideProjection = 10;
        public CycleWhileBeginBlock()
        {
            initialText = "Цикл while начало";
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

        private void SetPropertyControl()
        {
            ControlSize textFieldSize = GetSizeTextField(ControlSize);
            ControlOffset textFieldOffset = GetOffsetTextField();
            SetCoordinatesPoints(ControlSize);
            cycleWhileBeginBlock.SetPointPolygon();
            SetCoordinatesConnectionPoints();
            SetPropertyControl(textFieldSize, textFieldOffset);
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
            SetCoordinatesPoints(ControlSize);
            cycleWhileBeginBlock.SetPointPolygon();   
            FrameBlock.Children.Add(cycleWhileBeginBlock.FramePolygon);
        }

        protected override void SetBackground()
        {
            string color = "#FFCCCCFF";
            Brush backgroundColor = GetBackgroundColor(color);
            cycleWhileBeginBlock.FramePolygon.Fill = backgroundColor;
        }

        public override Block GetCopyBlock()
        {
            throw new System.NotImplementedException();
        }
    }
}