using System.Windows;
using System.Windows.Media;
using Flowchart_Editor.Model;
using System.Windows.Controls;
using System.Collections.Generic;
using Flowchart_Editor.View.Menu.Blocks.PolygonBasedBlock;
using System.Windows.Shapes;

namespace Flowchart_Editor.Models
{
    [BlockName("ConditionBlock")]
    public class ConditionBlock : Block, IPolygonBased
    {
        private readonly Polygon conditionBlock = new();
        private readonly List<Point> pointsConditionBlock = new();
        public ConditionBlock()
        {
            initialText = "Условие";

            SetPropertyFrameBlock();
            SetPropertyPolyginBlock();

            ControlSize sizeTextField = GetSizeTextField(ControlSize);
            ControlOffset offsetTextField = GetOffsetTextField(ControlSize);
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
            double width = controlSize.Width / 2;
            double height = controlSize.Height / 2;
            ControlSize sizeTextField = new(width, height);
            return sizeTextField;
        }

        private static ControlOffset GetOffsetTextField(ControlSize controlSize)
        {
            double offsetLeft = controlSize.Width / 2 - controlSize.Width / 4;
            double offsetTop = controlSize.Height / 4;
            ControlOffset offsetTextField = new(offsetLeft, offsetTop);
            return offsetTextField;
        }

        private void SetPropertyControl()
        {
            ControlSize textFieldSize = GetSizeTextField(ControlSize);
            ControlOffset textFieldOffset = GetOffsetTextField(ControlSize);
            SetCoordinatesPoints(ControlSize);
            IPolygonBased.SetPointPolygon(conditionBlock, pointsConditionBlock);
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

        public void SetPropertyPolyginBlock()
        {
            SetCoordinatesPoints(ControlSize);
            IPolygonBased.SetPointPolygon(conditionBlock, pointsConditionBlock);
            IPolygonBased.AddPolygon(FrameBlock, conditionBlock);

            string color = "#FF60B2D3";
            Brush backgroundColor = GetBackgroundColor(color);
            IPolygonBased.SetFill(conditionBlock, backgroundColor);
        }

        public void SetCoordinatesPoints(ControlSize polygonSize)
        {
            double width = polygonSize.Width;
            double height = polygonSize.Height;

            pointsConditionBlock.Clear();

            Point pointConditionBlock = new(0, height / 2);
            pointsConditionBlock.Add(pointConditionBlock);

            pointConditionBlock = new(width / 2, height);
            pointsConditionBlock.Add(pointConditionBlock);

            pointConditionBlock = new(width, height / 2);
            pointsConditionBlock.Add(pointConditionBlock);

            pointConditionBlock = new(width / 2, 0);
            pointsConditionBlock.Add(pointConditionBlock);

            pointConditionBlock = new(0, height / 2);
            pointsConditionBlock.Add(pointConditionBlock);
        }
    }
}