﻿using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using Flowchart_Editor.Model;

namespace Flowchart_Editor.Models
{
    [BlockName("ActionBlock")]
    public class ActionBlock : Block
    {
        public ActionBlock(Canvas editField)
        {
            EditField = editField;
            initialText = "Действие";

            string color = "#FF52C0AA";
            Brush backgroundColor = GetBackgroundColor(color);

            SetPropertyFrameBlock(backgroundColor);
            
            SetPropertyTextField(ControlSize, ControlOffset);

            SetCoordinatesConnectionPoints(offsetConnectionPoint);
            InitializingConnectionPoints(listCoordinatesConnectionPoints);
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
            //ControlSize controlSize = new(ControlSize.Width, valueBlockHeight);
            //SetPropertyControl(controlSize);
            //int[] coordinatesConnectionPoints = new int[4];
            //coordinatesConnectionPoints[1] = valueBlockHeight / 2 - offsetConnectionPoint;
            //coordinatesConnectionPoints[2] = valueBlockHeight - offsetConnectionPoint;
            //coordinatesConnectionPoints[3] = valueBlockHeight / 2 - offsetConnectionPoint;
            //SetTopConnectionPoints(coordinatesConnectionPoints);   
        }
    }
}