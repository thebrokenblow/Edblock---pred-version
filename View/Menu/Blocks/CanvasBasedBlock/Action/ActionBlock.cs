using System.Windows;
using System.Windows.Media;
using Flowchart_Editor.Model;
using System.Windows.Controls;
using Flowchart_Editor.View.Menu.Blocks.CanvasBasedBlock;

namespace Flowchart_Editor.Models
{
    [BlockName("ActionBlock")]
    public class ActionBlock : Block, ICanvasBased
    {
        public ActionBlock(Canvas editField)
        {
            EditField = editField;
            initialText = "Действие";

            SetPropertyCanvasBlock();
            ControlOffset offsetTextField = new(0, 0);
            SetPropertyTextField(ControlSize, offsetTextField);
            SetCoordinatesConnectionPoints(offsetConnectionPoint);
            InitializingConnectionPoints(listCoordinatesConnectionPoints);
            DrawHighlightedBlock();

            FrameBlock.Tag = "Block";
            Edblock.ListHighlightedBlock.Add(this);
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
        }

        public override void SetWidth(int valueBlockWidth)
        {
            //ControlSize controlSize = new(valueBlockWidth, ControlSize.Height);
            //SetPropertyControl(controlSize);
            //int[] coordinatesConnectionPoints = new int[4];
            //coordinatesConnectionPoints[0] = valueBlockWidth / 2 - offsetConnectionPoint;
            //coordinatesConnectionPoints[2] = valueBlockWidth / 2 - offsetConnectionPoint;
            //coordinatesConnectionPoints[3] = valueBlockWidth - offsetConnectionPoint * 2;
            //SetLeftConnectionPoints(coordinatesConnectionPoints);
        }

        public override void SetHeight(int valueBlockHeight)
        {
            ControlSize.Height = valueBlockHeight;
            SetPropertyControl(ControlSize);
            //int[] coordinatesConnectionPoints = new int[4];
            //coordinatesConnectionPoints[1] = valueBlockHeight / 2 - offsetConnectionPoint;
            //coordinatesConnectionPoints[2] = valueBlockHeight - offsetConnectionPoint;
            //coordinatesConnectionPoints[3] = valueBlockHeight / 2 - offsetConnectionPoint;
            //SetTopConnectionPoints(coordinatesConnectionPoints);   
        }

        public void SetPropertyCanvasBlock()
        {
            SetPropertyFrameBlock();
            string color = "#FF52C0AA";
            Brush backgroundColor = GetBackgroundColor(color);
            ICanvasBased.SetBackground(FrameBlock, backgroundColor);
        }
    }
}