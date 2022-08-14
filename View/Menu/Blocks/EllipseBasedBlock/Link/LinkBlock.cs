using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Controls;
using Flowchart_Editor.Model;
using Flowchart_Editor.View.Menu.Blocks.EllipseBasedBlock;

namespace Flowchart_Editor.Models
{
    [BlockName("LinkBlock")]
    public class LinkBlock : Block, IEllipseBased
    {
        private const int valueOffsetTextField = 10;
        public LinkBlock()
        {
            initialText = "Ссылка";

            SetPropertyEllipseBlock();
            ControlSize sizeTextField = GetSizeTextField(ControlSize);
            ControlOffset offsetTextField = GetOffsetTextField();
            SetPropertyTextField(sizeTextField, offsetTextField);

            SetCoordinatesConnectionPoints(offsetConnectionPoint);
            InitializingConnectionPoints();
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

        public void SetPropertyEllipseBlock()
        {
            ControlSize.Width = ControlSize.Height;
            SetPropertyFrameBlock();
            Ellipse linkBlock = new();

            string color = "#FF5761A8";
            Brush backgroundColor = GetBackgroundColor(color);
            IEllipseBased.SetFill(linkBlock, backgroundColor);
            IEllipseBased.SetSize(linkBlock, ControlSize);
            IEllipseBased.AddEllipse(FrameBlock, linkBlock);
        }
    }
}