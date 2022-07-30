using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using System;
using System.Collections.Generic;

namespace Flowchart_Editor.Models
{
    [BlockName("ActionBlock")]
    public class ActionBlock : Block
    {
        private readonly int defaultWidth = DefaultPropertyForBlock.width;
        private readonly int defaulHeight = DefaultPropertyForBlock.height;
        public Dictionary<int, int> dictionary = new();
        const int offsetConnectionPoint = 2;

        public ActionBlock(Canvas destination)
        {
            EditField = destination;
            blockWidthCoefficient = 1;
            blockHeightCoefficient = 1;
            initialText = "Действие";
        }

        override public UIElement GetUIElement()
        {
            if (FrameBlock == null)
            {
                FrameBlock = new Canvas();
                BrushConverter brushConverter = new();
                Brush backgroundColor = (Brush)brushConverter.ConvertFrom("#FF52C0AA");

                SetPropertyFrameBlock(defaultWidth, defaulHeight, backgroundColor);

                //SetPropertyForTextBox(defaultWidth, defaulHeight, initialText);
                TextBoxOfBlock = new();
                TextBoxOfBlock.Height = 30;
                TextBoxOfBlock.Width = 140;
                TextBoxOfBlock.Text = "Действие";
                
                FrameBlock.Children.Add(TextBoxOfBlock);

                SetStyle(TextBoxOfBlock, "TextBoxStyleForBlock");

                //SetPropertyForTextBlock(defaultWidth, defaulHeight, initialText);

                //dictionary.Add(defaultWidth / 2 - offsetConnectionPoint, -offsetConnectionPoint);
                //dictionary.Add(-offsetConnectionPoint, defaulHeight / 2 - offsetConnectionPoint);
                //dictionary.Add(defaultWidth / 2 - offsetConnectionPoint, defaulHeight - offsetConnectionPoint);
                //dictionary.Add(defaultWidth - offsetConnectionPoint * 2, defaulHeight / 2 - offsetConnectionPoint);

                //InitializingConnectionPoints(dictionary);

                //AddConnectionPoints();
            }
            return FrameBlock;
        }

        public override void SetWidth(int valueBlockWidth)
        {
            if (FrameBlock != null && TextBoxOfBlock != null && TextBlockOfBlock != null)
            {
                FrameBlock.Width = valueBlockWidth;
                TextBoxOfBlock.Width = valueBlockWidth;
                TextBlockOfBlock.Width = valueBlockWidth;
                //Canvas.SetLeft(firstPointConnect, valueBlockWidth / 2 - offsetConnectionPoint);
                //Canvas.SetLeft(thirdPointConnect, valueBlockWidth / 2 - offsetConnectionPoint);
                //Canvas.SetLeft(fourthPointConnect, valueBlockWidth - offsetConnectionPoint * 2);
            }
        }

        public override void SetHeight(int valueBlockHeight)
        {
            if (FrameBlock != null && TextBoxOfBlock != null && TextBlockOfBlock != null)
            {
                FrameBlock.Height = valueBlockHeight;
                TextBoxOfBlock.Height = valueBlockHeight;
                TextBlockOfBlock.Height = valueBlockHeight;
                //Canvas.SetTop(secondPointConnect, valueBlockHeight / 2 - offsetConnectionPoint);
                //Canvas.SetTop(thirdPointConnect, valueBlockHeight - offsetConnectionPoint);
                //Canvas.SetTop(fourthPointConnect, valueBlockHeight / 2 - offsetConnectionPoint);
            }
        }

        protected override void SetСoordinatesComment(UIElement comment)
        {
            Canvas.SetTop(comment, DefaultPropertyForBlock.height / 2 + 1);
            Canvas.SetLeft(comment, DefaultPropertyForBlock.width);
        }

        public override double GetWidthCoefficient() => 
            blockWidthCoefficient;

        public override double GetHeightCoefficient() => 
            blockHeightCoefficient;

        public override void SetLeftBlockForConditionCaseSecondOption(UIElement uIElementBlock, double coordinateLeft) =>
            Canvas.SetLeft(uIElementBlock, coordinateLeft - 1);

        public override void SetTopBlockForConditionCaseSecondOption(UIElement uIElementBlock, double coordinateTop) =>
            Canvas.SetTop(uIElementBlock, coordinateTop);

        public override void SetLeftBlockForConditionCaseFirstOption(UIElement uIElementBlock, double coordinateLeft) =>
             Canvas.SetLeft(uIElementBlock, coordinateLeft - 1);

        public override void SetTopBlockForConditionCaseFirstOption(UIElement uIElementBlock, double coordinateTop) =>
            Canvas.SetTop(uIElementBlock, coordinateTop - DefaultPropertyForBlock.height / 2 + 0.5);
    }
}