using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Controls;
using Flowchart_Editor.Model;

namespace Flowchart_Editor.Models
{
    [BlockName("LinkBlock")]
    public class LinkBlock : Block
    {
        private const int valueOffsetTextField = 10;
        public LinkBlock(Canvas destination)
        {
            EditField = destination;
            initialText = "Ссылка";

            string color = "#FF5761A8";
            Brush backgroundColor = GetBackgroundColor(color);

            ControlSize.Width = ControlSize.Height;
            SetPropertyFrameBlock();

            Ellipse linkBlock = new();
            linkBlock.Width = ControlSize.Width;
            linkBlock.Height = ControlSize.Height;
            linkBlock.Fill = backgroundColor;
            FrameBlock.Children.Add(linkBlock);

            ControlSize sizeTextField = GetSizeTextField(ControlSize);
            ControlOffset offsetTextField = GetOffsetTextField();
            SetPropertyTextField(sizeTextField, offsetTextField);

            SetCoordinatesConnectionPoints(offsetConnectionPoint);
            InitializingConnectionPoints(listCoordinatesConnectionPoints);
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

        public override void SetWidth(int valueBlockWidth)
        {

        }

        public override void SetHeight(int valueBlockHeight)
        {

        }
    }
}