using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using Flowchart_Editor.Model;
using System.Windows.Controls;
using System.Collections.Generic;
using Flowchart_Editor.View.Menu.Blocks.PolygonBasedBlock;

namespace Flowchart_Editor.Models
{
    [BlockName("CycleWhileBeginBlock")]
    public class CycleWhileBeginBlock : Block, IPolygonBased
    {
        private readonly List<Point> listPoints = new();
        private const int sideProjection = 10;
        public CycleWhileBeginBlock()
        {
            initialText = "Цикл while начало";

            SetPropertyFrameBlock();
            SetPropertyPolyginBlock();

            ControlSize sizeTextField = GetSizeTextField(ControlSize);
            ControlOffset offsetTextField = GetOffsetTextField();
            SetPropertyTextField(sizeTextField, offsetTextField);

            SetCoordinatesConnectionPoints(offsetConnectionPoint);
            InitializingConnectionPoints();
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

        private void SetPropertyControl(ControlSize blockSize)
        {
            ControlSize textFieldSize = GetSizeTextField(blockSize);
            ControlOffset textFieldOffset = GetOffsetTextField();
            //SetCoordinatesCycleWhileBeginBlock(blockSize);
            //SetPointPolygon(listPoints);
            SetSize(FrameBlock, blockSize);
            SetSize(TextBoxOfBlock, textFieldSize);
            SetSize(TextBlockOfBlock, textFieldSize);
            SetCoordinates(TextBoxOfBlock, textFieldOffset);
            SetCoordinates(TextBlockOfBlock, textFieldOffset);
        }

        public override void SetWidth(int valueBlockWidth)
        {
            //ControlSize blockSize = new(valueBlockWidth, ControlSize.Height);
            //SetPropertyControl(blockSize);

            //int[] coordinatesConnectionPoints = new int[4];
            //coordinatesConnectionPoints[0] = valueBlockWidth / 2 - offsetConnectionPoint;
            //coordinatesConnectionPoints[2] = valueBlockWidth / 2 - offsetConnectionPoint;
            //coordinatesConnectionPoints[3] = valueBlockWidth - offsetConnectionPoint * 2;
            //SetLeftConnectionPoints(coordinatesConnectionPoints);            
        }

        public override void SetHeight(int valueBlockHeight)
        {
            //ControlSize blockSize = new(ControlSize.Width, valueBlockHeight);
            //SetPropertyControl(blockSize);

            //int[] coordinatesConnectionPoints = new int[4];
            //coordinatesConnectionPoints[1] = valueBlockHeight / 2 - offsetConnectionPoint;
            //coordinatesConnectionPoints[2] = valueBlockHeight - offsetConnectionPoint;
            //coordinatesConnectionPoints[3] = valueBlockHeight / 2 - offsetConnectionPoint;
            //SetTopConnectionPoints(coordinatesConnectionPoints);
        }

        public void SetCoordinatesPoints(ControlSize polygonSize)
        {
            double height = polygonSize.Height;
            double width = polygonSize.Width;

            listPoints.Clear();

            Point poinCycleForBlock = new(0, height);
            listPoints.Add(poinCycleForBlock);

            poinCycleForBlock = new(0, sideProjection);
            listPoints.Add(poinCycleForBlock);

            poinCycleForBlock = new(sideProjection, 0);
            listPoints.Add(poinCycleForBlock);

            poinCycleForBlock = new(width - sideProjection, 0);
            listPoints.Add(poinCycleForBlock);

            poinCycleForBlock = new(width, sideProjection);
            listPoints.Add(poinCycleForBlock);

            poinCycleForBlock = new(width, height);
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