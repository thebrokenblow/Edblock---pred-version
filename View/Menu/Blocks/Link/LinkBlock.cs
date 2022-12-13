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
            SetSize(linkBlock, ControlSize);
            FrameBlock.Children.Add(linkBlock);
            ControlSize sizeTextField = GetSizeTextField(ControlSize);
            ControlOffset offsetTextField = GetOffsetTextField();
            SetPropertyTextField(sizeTextField, offsetTextField);
            SetPropertyLinkBlock();
            SetCoordinatesConnectionPoints();
            InitializingConnectionPoints();
            DrawHighlightedBlock();
           
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

        private void SetPropertyLinkBlock()
        {
            ControlOffset textFieldOffset = GetOffsetTextField();
            SetSize(linkBlock, ControlSize);
            SetCoordinatesConnectionPoints();
            SetPropertyControl(ControlSize, textFieldOffset);
        }

        public override void SetWidth(int valueBlockWidth)
        {
            ControlSize.Height = valueBlockWidth;
            ControlSize.Width = valueBlockWidth;
            SetPropertyLinkBlock();
        }

        public override void SetHeight(int valueBlockHeight)
        {
            ControlSize.Height = valueBlockHeight;
            ControlSize.Width = valueBlockHeight;
            SetPropertyLinkBlock();
        }

        protected override void SetBackground()
        {
            string color = "#FF5761A8";
            Brush backgroundColor = GetBackgroundColor(color);
            linkBlock.Fill = backgroundColor;
        }

        public override Block GetCopyBlock()
        {
            throw new System.NotImplementedException();
        }
    }
}