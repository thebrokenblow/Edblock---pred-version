using System.Windows;
using System.Windows.Media;
using Flowchart_Editor.Model;
using System.Collections.Generic;
using Flowchart_Editor.View.Menu.Blocks.PolygonBasedBlock;

namespace Flowchart_Editor.Models
{
    [BlockName("InputOutputBlock")]
    public class InputOutputBlock : Block, IPolygonBased
    {
        private readonly PolygonBased inputOutputBlock = new();
        private const int sideProjection = 20;

        public InputOutputBlock()
        {       
            initialText = "Ввод/Вывод";
            SetPropertyPolyginBlock();
            ControlSize sizeTextField = GetSizeTextField(ControlSize);
            ControlOffset offsetTextField = GetOffsetTextField();
            SetPropertyTextField(sizeTextField, offsetTextField);
            SetCoordinatesConnectionPoints(sideProjection);
            InitializingConnectionPoints();
            DrawHighlightedBlock();
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
            SetCoordinatesConnectionPoints(sideProjection);
            SetPropertyControl(textFieldSize, textFieldOffset);
        }

        public void SetPropertyPolyginBlock()
        {
            SetCoordinatesPoints(ControlSize);
            inputOutputBlock.SetPointPolygon();   
            FrameBlock.Children.Add(inputOutputBlock.FramePolygon);
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

        protected override void SetBackground()
        {
            string color = "#FF008080";
            Brush backgroundColor = GetBackgroundColor(color);
            inputOutputBlock.FramePolygon.Fill = backgroundColor;
        }

        public override Block GetCopyBlock()
        {
            throw new System.NotImplementedException();
        }
    }
}