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

            SetPropertyFrameBlock();
            
            string color = "#FFF25252";
            Brush backgroundColor = GetBackgroundColor(color);

            SetSize(startEndBlock, ControlSize);
            startEndBlock.Fill = backgroundColor;

            startEndBlock.RadiusX = radiusStartEndBlock;
            startEndBlock.RadiusY = radiusStartEndBlock;

            FrameBlock.Children.Add(startEndBlock);

            ControlSize sizeTextField = GetSizeTextField(ControlSize);
            ControlOffset offsetTextField = GetOffsetTextField();
            SetPropertyTextField(sizeTextField, offsetTextField);

            SetCoordinatesConnectionPoints();
            InitializingConnectionPoints();

            DrawHighlightedBlock();
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

        override public UIElement GetUIElement()
        {
            return FrameBlock;
        }

        private void SetPropertyControl()
        {
            ControlSize textFieldSize = GetSizeTextField(ControlSize);
            ControlOffset textFieldOffset = GetOffsetTextField();

            SetSize(FrameBlock, ControlSize);
            SetSize(startEndBlock, ControlSize);
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
    }
}