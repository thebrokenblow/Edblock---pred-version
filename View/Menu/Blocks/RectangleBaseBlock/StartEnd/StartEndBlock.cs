using System.Windows;
using System.Windows.Media;
using Flowchart_Editor.Model;
using System.Windows.Shapes;
using System.Windows.Controls;
using Flowchart_Editor.View.Menu.Blocks.RectangleBaseBlock;

namespace Flowchart_Editor.Models
{
    [BlockName("StartEndBlock")]
    public class StartEndBlock : Block, IRectangleBased
    {
        private readonly Rectangle? startEndBlock = new();
        private const int radiusRectangle = 20;
        private const int valueOffsetTextField = 3;

        public StartEndBlock(Canvas destination)
        {
            EditField = destination;
            initialText = "Начало / Конец";

            SetPropertyRectangleBlock();

            ControlSize sizeTextField = GetSizeTextField(ControlSize);
            ControlOffset offsetTextField = GetOffsetTextField();
            SetPropertyTextField(sizeTextField, offsetTextField);

            SetCoordinatesConnectionPoints(offsetConnectionPoint);
            InitializingConnectionPoints(listCoordinatesConnectionPoints);
        }

        private static ControlSize GetSizeTextField(ControlSize controlSize)
        {
            double width = controlSize.Width - radiusRectangle;
            double height = controlSize.Height - valueOffsetTextField;
            ControlSize sizeTextField = new(width, height);
            return sizeTextField;
        }

        private static ControlOffset GetOffsetTextField()
        {
            double offsetLeft = radiusRectangle / 2;
            double offsetTop = valueOffsetTextField;
            ControlOffset offsetTextField = new(offsetLeft, offsetTop);
            return offsetTextField;
        }

        override public UIElement GetUIElement()
        {
            return FrameBlock;
        }

        public override void SetWidth(int valueBlockWidth)
        {
        }

        public override void SetHeight(int valueBlockHeight)
        {
        }

        public void SetPropertyRectangleBlock()
        {
            SetPropertyFrameBlock();
            Rectangle startEndBlock = new();
            string color = "#FFF25252";
            Brush backgroundColor = GetBackgroundColor(color);
            IRectangleBased.SetSize(startEndBlock, ControlSize);
            IRectangleBased.SetFill(startEndBlock, backgroundColor);
            IRectangleBased.SetRadius(startEndBlock, radiusRectangle, radiusRectangle);
            IRectangleBased.AddRectangle(FrameBlock, startEndBlock);
        }
    }
}