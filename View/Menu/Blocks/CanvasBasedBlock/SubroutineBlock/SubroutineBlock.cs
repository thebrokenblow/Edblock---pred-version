using System.Windows;
using System.Windows.Media;
using Flowchart_Editor.Model;
using System.Windows.Controls;

namespace Flowchart_Editor.Models
{
    [BlockName("SubroutineBlock")]
    public class SubroutineBlock : Block
    { 
        private const int offsetBorderLine = 20;
        private readonly Border borderLine = new();
        public SubroutineBlock()
        {
            initialText = "Подпрограмма";

            SetPropertyFrameBlock();
            SetBorderLine();
            string color = "#FFBA64C8";
            Brush backgroundColor = GetBackgroundColor(color);
            FrameBlock.Background = backgroundColor;

            ControlSize sizeTextField = GetSizeTextField(ControlSize);
            ControlOffset offsetTextField = GetOffsetTextField();
            SetPropertyTextField(sizeTextField, offsetTextField);

            SetCoordinatesConnectionPoints();
            InitializingConnectionPoints();

            DrawHighlightedBlock();
        }

        private void SetBorderLine()
        {
            if (FrameBlock.Children.Contains(borderLine))
            {
                SetSizeBorderLine();
                SetOffsetBorderLine();

            }
            else
            {
                SetSizeBorderLine();
                SetOffsetBorderLine();
                borderLine.BorderBrush = Brushes.Black;
                borderLine.BorderThickness = new Thickness(1);
                FrameBlock.Children.Add(borderLine);
            }

        }

        private void SetOffsetBorderLine()
        {
            Canvas.SetLeft(borderLine, offsetBorderLine);
        }

        private void SetSizeBorderLine()
        {
            borderLine.Width = ControlSize.Width - offsetBorderLine * 2;
            borderLine.Height = ControlSize.Height;
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

        private void SetPropertyControl()
        {
            ControlSize textFieldSize = GetSizeTextField(ControlSize);
            SetBorderLine();
            SetSize(FrameBlock, ControlSize);
            SetSize(TextBoxOfBlock, textFieldSize);
            SetSize(TextBlockOfBlock, textFieldSize);
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