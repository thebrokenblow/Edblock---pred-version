using System.Windows;
using System.Windows.Media;
using Flowchart_Editor.Model;
using System.Windows.Controls;
using System.Collections.Generic;
using Flowchart_Editor.View.Menu.Blocks.PolygonBasedBlock;
using System.Windows.Shapes;

namespace Flowchart_Editor.Models
{
    [BlockName("InputOutputBlock")]
    public class InputOutputBlock : Block, IPolygonBased
    {
        private readonly List<Point> listPoints = new();
        private const int sideProjection = 20;

        public InputOutputBlock(Canvas destination)
        {
            EditField = destination;       
            initialText = "Ввод/Вывод";

            SetPropertyFrameBlock();
            SetPropertyPolyginBlock();

            ControlSize sizeTextField = GetSizeTextField(ControlSize);
            ControlOffset offsetTextField = GetOffsetTextField();
            SetPropertyTextField(sizeTextField, offsetTextField);

            SetCoordinatesConnectionPoints(offsetConnectionPoint, sideProjection);
            InitializingConnectionPoints(listCoordinatesConnectionPoints);
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

        private void SetCoordinatesCycleWhileEndBlock(ControlSize controlSize)
        {
            double height = controlSize.Height;
            double width = controlSize.Width;

            listPoints.Clear();

            Point poinCycleForBlock = new(sideProjection, 0);
            listPoints.Add(poinCycleForBlock);

            poinCycleForBlock = new(0, height);
            listPoints.Add(poinCycleForBlock);

            poinCycleForBlock = new(width - sideProjection, height);
            listPoints.Add(poinCycleForBlock);

            poinCycleForBlock = new(width, 0);
            listPoints.Add(poinCycleForBlock);
        }

        public override void SetWidth(int valueBlockWidth)
        {
            //Canvas.SetLeft(firstPointConnect, valueBlockWidth / 2);
            //Canvas.SetLeft(thirdPointConnect, valueBlockWidth / 2);
            //Canvas.SetLeft(fourthPointConnect, valueBlockWidth - 13);
        }

        public override void SetHeight(int valueBlockHeight)
        {
            //Canvas.SetTop(secondPointConnect, valueBlockHeight / 2 - 5);
            //Canvas.SetTop(thirdPointConnect, valueBlockHeight - 3);
            //Canvas.SetTop(fourthPointConnect, valueBlockHeight / 2 - 5);
        }

        public void SetCoordinatesPoints(ControlSize polygonSize)
        {
            double height = polygonSize.Height;
            double width = polygonSize.Width;

            listPoints.Clear();

            Point poinCycleForBlock = new(sideProjection, 0);
            listPoints.Add(poinCycleForBlock);

            poinCycleForBlock = new(0, height);
            listPoints.Add(poinCycleForBlock);

            poinCycleForBlock = new(width - sideProjection, height);
            listPoints.Add(poinCycleForBlock);

            poinCycleForBlock = new(width, 0);
            listPoints.Add(poinCycleForBlock);
        }

        public void SetPropertyPolyginBlock()
        {
            SetCoordinatesCycleWhileEndBlock(ControlSize);
            Polygon polygonBlock = IPolygonBased.SetPointPolygon(listPoints);
            IPolygonBased.AddPolygon(FrameBlock, polygonBlock);

            string color = "#FF008080";
            Brush backgroundColor = GetBackgroundColor(color);
            IPolygonBased.SetFill(polygonBlock, backgroundColor);
        }
    }
}