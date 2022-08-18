using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using Flowchart_Editor.Model;

namespace Flowchart_Editor.Models
{
    [BlockName("LinkBlock")]
    public class LinkBlock : Block
    {
        private readonly Ellipse linkBlock = new();
        private const int valueOffsetTextField = 10;
        public LinkBlock()
        {
            initialText = "Ссылка";

            ControlSize.Width = ControlSize.Height;
            SetPropertyFrameBlock();
            

            string color = "#FF5761A8";
            Brush backgroundColor = GetBackgroundColor(color);
            linkBlock.Fill = backgroundColor;

            SetSize(linkBlock, ControlSize);
            FrameBlock.Children.Add(linkBlock);

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
            double width = controlSize.Height - valueOffsetTextField * 2;
            double height = controlSize.Height - valueOffsetTextField * 2;
            ControlSize sizeTextField = new(width, height);
            return sizeTextField;
        }

        private static ControlOffset GetOffsetTextField()
        {
            double offsetLeft = valueOffsetTextField;
            double offsetTop = valueOffsetTextField;
            ControlOffset offsetTextField = new(offsetLeft, offsetTop);
            return offsetTextField;
        }

        private void SetPropertyControl()
        {
            ControlSize textFieldSize = GetSizeTextField(ControlSize);
            ControlOffset textFieldOffset = GetOffsetTextField();

            SetSize(linkBlock, ControlSize);
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

        }

        public override void SetHeight(int valueBlockHeight)
        {
            ControlSize.Height = valueBlockHeight;
            ControlSize.Width = valueBlockHeight;
            SetPropertyControl();
        }
    }
}