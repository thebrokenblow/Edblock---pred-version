using System.Windows;
using System.Windows.Media;
using Flowchart_Editor.Model;
using System.Windows.Shapes;

namespace Flowchart_Editor.Models
{
    [BlockName("StartEndBlock")]
    public class StartEndBlock : Block
    {
        private readonly Rectangle startEndBlock = new();
        private const int radiusStartEndBlock = 20;
        private const int valueOffsetTextField = 3;

        public StartEndBlock()
        {
            initialText = "Начало / Конец";
            SetSize(startEndBlock, ControlSize);
            SetRadius();
            FrameBlock.Children.Add(startEndBlock);
            ControlSize sizeTextField = GetSizeTextField(ControlSize);
            ControlOffset offsetTextField = GetOffsetTextField();
            SetPropertyTextField(sizeTextField, offsetTextField);
            SetCoordinatesConnectionPoints();
            InitializingConnectionPoints();
            DrawHighlightedBlock();
        }

        private void SetRadius()
        {
            startEndBlock.RadiusX = radiusStartEndBlock;
            startEndBlock.RadiusY = radiusStartEndBlock;
        }

        private static ControlSize GetSizeTextField(ControlSize controlSize)
        {
            double width = controlSize.Width - radiusStartEndBlock;
            double height = controlSize.Height - valueOffsetTextField;
            ControlSize sizeTextField = new(width, height);
            return sizeTextField;
        }

        private static ControlOffset GetOffsetTextField()
        {
            double offsetLeft = radiusStartEndBlock / 2;
            double offsetTop = valueOffsetTextField;
            ControlOffset offsetTextField = new(offsetLeft, offsetTop);
            return offsetTextField;
        }

        private void SetPropertyControl()
        {
            ControlSize textFieldSize = GetSizeTextField(ControlSize);
            ControlOffset textFieldOffset = GetOffsetTextField();
            SetSize(startEndBlock, ControlSize);
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

        protected override void SetBackground()
        {
            string color = "#FFF25252";
            Brush backgroundColor = GetBackgroundColor(color);
            startEndBlock.Fill = backgroundColor;
        }

        public override Block GetCopyBlock()
        {
            throw new System.NotImplementedException();
        }
    }
}