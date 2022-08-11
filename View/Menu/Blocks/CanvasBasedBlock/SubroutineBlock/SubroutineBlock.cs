using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using Flowchart_Editor.Model;
using Flowchart_Editor.View.Menu.Blocks.CanvasBasedBlock;

namespace Flowchart_Editor.Models
{
    [BlockName("SubroutineBlock")]
    public class SubroutineBlock : Block, ICanvasBased
    { 
        private const int offsetBorderLine = 20;

        public SubroutineBlock(Canvas destination)
        {
            EditField = destination;
            initialText = "Подпрограмма";

            SetPropertyCanvasBlock();

            ControlSize sizeTextField = GetSizeTextField(ControlSize);
            ControlOffset offsetTextField = GetOffsetTextField();
            SetPropertyTextField(sizeTextField, offsetTextField);

            SetCoordinatesConnectionPoints(offsetConnectionPoint);
            InitializingConnectionPoints(listCoordinatesConnectionPoints);
        }

        private void SetBorderLine()
        {
            Border borderLine = new();
            borderLine.BorderBrush = Brushes.Black;
            borderLine.Width = ControlSize.Width - offsetBorderLine * 2;
            borderLine.Height = ControlSize.Height;
            borderLine.BorderThickness = new Thickness(1);
            Canvas.SetLeft(borderLine, offsetBorderLine);
            FrameBlock.Children.Add(borderLine);

        }

        private static ControlSize GetSizeTextField(ControlSize controlSize)
        {
            double width = controlSize.Width - offsetBorderLine * 2;
            double height = controlSize.Height;
            ControlSize sizeTextField = new(width, height);
            return sizeTextField;
        }

        private static ControlOffset GetOffsetTextField()
        {
            double offsetLeft = offsetBorderLine;
            double offsetTop = 0;
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

        public void SetPropertyCanvasBlock()
        {
            SetPropertyFrameBlock();
            SetBorderLine();
            string color = "#FFBA64C8";
            Brush backgroundColor = GetBackgroundColor(color);
            ICanvasBased.SetBackground(FrameBlock, backgroundColor);
        }
    }
}