using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using System.Collections.Generic;
using Flowchart_Editor.Model;
using Flowchart_Editor.View.Menu.Blocks.PolygonBasedBlock;
using System.Windows.Shapes;

namespace Flowchart_Editor.Models
{
    [BlockName("CycleForBlock")]
    public class CycleForBlock : Block, IPolygonBased
    {
        private readonly Polygon cycleForBlock = new();
        private readonly List<Point> listPoints = new();
        private const int sideProjection = 10; 
        public CycleForBlock()
        {
            initialText = "Цикл for";

            SetPropertyFrameBlock();
            SetPropertyPolyginBlock();

            ControlSize sizeTextField = GetSizeTextField(ControlSize);
            ControlOffset offsetTextField = GetOffsetTextField();
            SetPropertyTextField(sizeTextField, offsetTextField);

            SetCoordinatesConnectionPoints();
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
            IPolygonBased.SetPointPolygon(cycleForBlock, listPoints);
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
            double height = polygonSize.Height;
            double width = polygonSize.Width;

            listPoints.Clear();

            Point poinCycleForBlock = new(sideProjection, 0);
            listPoints.Add(poinCycleForBlock);

            poinCycleForBlock = new(sideProjection, 0);
            listPoints.Add(poinCycleForBlock);

            poinCycleForBlock = new(0, sideProjection);
            listPoints.Add(poinCycleForBlock);

            poinCycleForBlock = new(0, height - sideProjection);
            listPoints.Add(poinCycleForBlock);

            poinCycleForBlock = new(sideProjection, height);
            listPoints.Add(poinCycleForBlock);

            poinCycleForBlock = new(width - sideProjection, height);
            listPoints.Add(poinCycleForBlock);

            poinCycleForBlock = new(width, height - sideProjection);
            listPoints.Add(poinCycleForBlock);

            poinCycleForBlock = new(width, sideProjection);
            listPoints.Add(poinCycleForBlock);

            poinCycleForBlock = new(width - sideProjection, 0);
            listPoints.Add(poinCycleForBlock);
        }

        public void SetPropertyPolyginBlock()
        {
            SetCoordinatesPoints(ControlSize);
            IPolygonBased.SetPointPolygon(cycleForBlock, listPoints);
            IPolygonBased.AddPolygon(FrameBlock, cycleForBlock);
            string color = "#FFFFC618";
            Brush backgroundColor = GetBackgroundColor(color);
            IPolygonBased.SetFill(cycleForBlock, backgroundColor);
        }
    }
}