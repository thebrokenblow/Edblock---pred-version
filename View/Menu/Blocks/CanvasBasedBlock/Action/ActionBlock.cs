using System.Windows;
using System.Windows.Media;
using Flowchart_Editor.Model;
using System.Windows.Controls;

namespace Flowchart_Editor.Models
{
    [BlockName("ActionBlock")]
    public class ActionBlock : Block
    {
        public ActionBlock()
        {
            initialText = "Действие";
            
            SetPropertyFrameBlock();
            string color = "#FF52C0AA";
            Brush backgroundColor = GetBackgroundColor(color);
            FrameBlock.Background = backgroundColor;

            ControlOffset offsetTextField = new(0, 0);
            SetPropertyTextField(ControlSize, offsetTextField);
            SetCoordinatesConnectionPoints();
            InitializingConnectionPoints();

            DrawHighlightedBlock();
        }

        override public UIElement GetUIElement()
        {
            return FrameBlock;
        }

        private void SetPropertyControl(ControlSize controlSize)
        {
            SetSize(FrameBlock, controlSize);
            SetSize(TextBoxOfBlock, controlSize);
            SetSize(TextBlockOfBlock, controlSize);
            SetCoordinatesConnectionPoints();
            ChangeCoordinatesConnectionPoints();
            ChangeHighlightedBlock();
        }

        public override void SetWidth(int valueBlockWidth)
        {
            ControlSize.Width = valueBlockWidth;
            SetPropertyControl(ControlSize);
        }

        public override void SetHeight(int valueBlockHeight)
        {
            ControlSize.Height = valueBlockHeight;
            SetPropertyControl(ControlSize);   
        }
    }
}