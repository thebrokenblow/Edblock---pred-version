using System.Windows;
using System.Windows.Media;
using Flowchart_Editor.Model;
using System.Collections.Generic;
using Flowchart_Editor.View.Menu.Blocks.PolygonBasedBlock;

namespace Flowchart_Editor.Models
{
    [BlockName("CycleForBlock")]
    public class CycleForBlock : Block, IPolygonBased
    {
        private readonly PolygonBased cycleForBlock = new();
        private const int sideProjection = 10; 

        public CycleForBlock()
        {
            initialText = "Цикл for";
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
            cycleForBlock.SetPointPolygon();
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
            List<Point> pointsCycleForBlock = cycleForBlock.PointsPolygon;
            double height = polygonSize.Height;
            double width = polygonSize.Width;

            pointsCycleForBlock.Clear();

            Point poinCycleForBlock = new(sideProjection, 0);
            pointsCycleForBlock.Add(poinCycleForBlock);

            poinCycleForBlock = new(sideProjection, 0);
            pointsCycleForBlock.Add(poinCycleForBlock);

            poinCycleForBlock = new(0, sideProjection);
            pointsCycleForBlock.Add(poinCycleForBlock);

            poinCycleForBlock = new(0, height - sideProjection);
            pointsCycleForBlock.Add(poinCycleForBlock);

            poinCycleForBlock = new(sideProjection, height);
            pointsCycleForBlock.Add(poinCycleForBlock);

            poinCycleForBlock = new(width - sideProjection, height);
            pointsCycleForBlock.Add(poinCycleForBlock);

            poinCycleForBlock = new(width, height - sideProjection);
            pointsCycleForBlock.Add(poinCycleForBlock);

            poinCycleForBlock = new(width, sideProjection);
            pointsCycleForBlock.Add(poinCycleForBlock);

            poinCycleForBlock = new(width - sideProjection, 0);
            pointsCycleForBlock.Add(poinCycleForBlock);
        }

        public void SetPropertyPolyginBlock()
        {
            SetCoordinatesPoints(ControlSize);
            cycleForBlock.SetPointPolygon();
            FrameBlock.Children.Add(cycleForBlock.FramePolygon);
        }

        protected override void SetBackground()
        {
            string color = "#FFFFC618";
            Brush backgroundColor = GetBackgroundColor(color);
            cycleForBlock.FramePolygon.Fill = backgroundColor;
        }

        public override Block GetCopyBlock()
        {
            throw new System.NotImplementedException();
        }
    }
}