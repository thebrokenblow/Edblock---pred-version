using System.Windows;
using System.Windows.Media;
using Flowchart_Editor.Model;
using System.Windows.Shapes;
using System.Windows.Controls;

namespace Flowchart_Editor.Models
{
    [BlockName("StartEndBlock")]
    public class StartEndBlock : Block
    {
        private readonly Rectangle? startEndBlock = new();
        private const int radiusOfRectangleStartEndBlock = 20;
        private const int valueOffsetTextField = 3;

        public StartEndBlock(Canvas destination)
        {
            EditField = destination;
            initialText = "Начало / Конец";
            SetPropertyFrameBlock();

            BrushConverter brushConverter = new();
            Brush backgroundColor = (Brush)brushConverter.ConvertFrom("#FFF25252");
            startEndBlock.Fill = backgroundColor;
            startEndBlock.RadiusX = radiusOfRectangleStartEndBlock;
            startEndBlock.RadiusY = radiusOfRectangleStartEndBlock;

            FrameBlock.Children.Add(startEndBlock);
            
            startEndBlock.Width = ControlSize.Width;
            startEndBlock.Height = ControlSize.Height;

            ControlSize sizeTextField = GetSizeTextField(ControlSize);
            ControlOffset offsetTextField = GetOffsetTextField();
            SetPropertyTextField(sizeTextField, offsetTextField);

            SetCoordinatesConnectionPoints(offsetConnectionPoint);
            InitializingConnectionPoints(listCoordinatesConnectionPoints);
        }

        private static ControlSize GetSizeTextField(ControlSize controlSize)
        {
            double width = controlSize.Width - radiusOfRectangleStartEndBlock;
            double height = controlSize.Height - valueOffsetTextField;
            ControlSize sizeTextField = new(width, height);
            return sizeTextField;
        }

        private static ControlOffset GetOffsetTextField()
        {
            double offsetLeft = radiusOfRectangleStartEndBlock / 2;
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
    }
}