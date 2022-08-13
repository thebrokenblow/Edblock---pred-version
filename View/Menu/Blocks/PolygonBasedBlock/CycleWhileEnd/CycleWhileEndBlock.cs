using System.Windows;
using System.Windows.Media;
using Flowchart_Editor.Model;
using System.Windows.Controls;
using System.Collections.Generic;
using Flowchart_Editor.View.Menu.Blocks.PolygonBasedBlock;
using System.Windows.Shapes;

namespace Flowchart_Editor.Models
{
    [BlockName("CycleWhileEndBlock")]
    public class CycleWhileEndBlock : Block, IPolygonBased
    {
        private readonly List<Point> listPoints = new();
        private const int sideProjection = 10;

        public CycleWhileEndBlock(Canvas destination)
        {
            EditField = destination;
            initialText = "Цикл while конец";

            SetPropertyFrameBlock();
            SetPropertyPolyginBlock();

            ControlSize sizeTextField = GetSizeTextField(ControlSize);
            ControlOffset offsetTextField = GetOffsetTextField();
            SetPropertyTextField(sizeTextField, offsetTextField);

            SetCoordinatesConnectionPoints(offsetConnectionPoint);
            InitializingConnectionPoints(listCoordinatesConnectionPoints);
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
        }

        public override void SetHeight(int valueBlockHeight)
        {
        }

        public void SetCoordinatesPoints(ControlSize polygonSize)
        {
            double height = polygonSize.Height;
            double width = polygonSize.Width;

            listPoints.Clear();

            Point poinCycleForBlock = new(0, 0);
            listPoints.Add(poinCycleForBlock);

            poinCycleForBlock = new(0, height - sideProjection);
            listPoints.Add(poinCycleForBlock);

            poinCycleForBlock = new(sideProjection, height);
            listPoints.Add(poinCycleForBlock);

            poinCycleForBlock = new(width - sideProjection, height);
            listPoints.Add(poinCycleForBlock);

            poinCycleForBlock = new(width, height - sideProjection);
            listPoints.Add(poinCycleForBlock);

            poinCycleForBlock = new(width, 0);
            listPoints.Add(poinCycleForBlock);
        }

        public void SetPropertyPolyginBlock()
        {
            SetCoordinatesPoints(ControlSize);
            Polygon polygonBlock = IPolygonBased.SetPointPolygon(listPoints);
            IPolygonBased.AddPolygon(FrameBlock, polygonBlock);

            string color = "#FFCCCCFF";
            Brush backgroundColor = GetBackgroundColor(color);
            IPolygonBased.SetFill(polygonBlock, backgroundColor);
        }
    }
}