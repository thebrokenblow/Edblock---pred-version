﻿using System.Windows;
using System.Windows.Media;
using Flowchart_Editor.Model;
using System.Windows.Controls;
using System.Collections.Generic;

namespace Flowchart_Editor.Models
{
    [BlockName("ConditionBlock")]
    public class ConditionBlock : Block
    {
        protected List<Point> listPoints = new();
        public ConditionBlock(Canvas destination)
        {
            EditField = destination;
            initialText = "Условие";

            SetPropertyFrameBlock();
            SetCoordinatesConditionBlock(ControlSize);
            polygonBlock = SetPointPolygon(listPoints);
            AddPointPolygon(polygonBlock);

            string color = "#FF60B2D3";
            Brush backgroundColor = GetBackgroundColor(color);
            SetFillPolygon(backgroundColor);

            ControlSize sizeTextField = GetSizeTextField(ControlSize);
            ControlOffset offsetTextField = GetOffsetTextField(ControlSize);
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
            double width = controlSize.Width / 2;
            double height = controlSize.Height / 2;
            ControlSize sizeTextField = new(width, height);
            return sizeTextField;
        }

        private static ControlOffset GetOffsetTextField(ControlSize controlSize)
        {
            double offsetLeft = controlSize.Width / 2 - controlSize.Width / 4;
            double offsetTop = controlSize.Height / 4;
            ControlOffset offsetTextField = new(offsetLeft, offsetTop);
            return offsetTextField;
        }

        private void SetCoordinatesConditionBlock(ControlSize controlSize)
        {
            double defaulWidth = controlSize.Width;
            double defaulHeight = controlSize.Height;

            listPoints.Clear();

            Point pointConditionBlock = new(0, defaulHeight / 2);
            listPoints.Add(pointConditionBlock);

            pointConditionBlock = new(defaulWidth / 2, defaulHeight);
            listPoints.Add(pointConditionBlock);

            pointConditionBlock = new(defaulWidth, defaulHeight / 2);
            listPoints.Add(pointConditionBlock);

            pointConditionBlock = new(defaulWidth / 2, 0);
            listPoints.Add(pointConditionBlock);

            pointConditionBlock = new(0, defaulHeight / 2);
            listPoints.Add(pointConditionBlock);
        }

        private void SetPropertyControl(ControlSize blockSize)
        {
            ControlSize textFieldSize = GetSizeTextField(blockSize);
            ControlOffset textFieldOffset = GetOffsetTextField(blockSize);
            SetCoordinatesConditionBlock(blockSize);
            SetPointPolygon(listPoints);
            SetSize(FrameBlock, blockSize);
            SetSize(TextBoxOfBlock, textFieldSize);
            SetSize(TextBlockOfBlock, textFieldSize);
            SetCoordinates(TextBoxOfBlock, textFieldOffset);
            SetCoordinates(TextBlockOfBlock, textFieldOffset);
        }

        public override void SetWidth(int valueBlockWidth)
        {
            //ControlSize blockSize = new(valueBlockWidth, ControlSize.Height);
            //SetPropertyControl(blockSize);

            //int[] coordinatesConnectionPoints = new int[4];
            //coordinatesConnectionPoints[0] = valueBlockWidth / 2 - offsetConnectionPoint;
            //coordinatesConnectionPoints[2] = valueBlockWidth / 2 - offsetConnectionPoint;
            //coordinatesConnectionPoints[3] = valueBlockWidth - offsetConnectionPoint * 2;
            //SetLeftConnectionPoints(coordinatesConnectionPoints);
        }

        public override void SetHeight(int valueBlockHeight)
        {
            //ControlSize blockSize = new(ControlSize.Width, valueBlockHeight);
            //SetPropertyControl(blockSize);

            //int[] coordinatesConnectionPoints = new int[4];
            //coordinatesConnectionPoints[1] = valueBlockHeight / 2 - offsetConnectionPoint;
            //coordinatesConnectionPoints[2] = valueBlockHeight - offsetConnectionPoint;
            //coordinatesConnectionPoints[3] = valueBlockHeight / 2 - offsetConnectionPoint;
            //SetTopConnectionPoints(coordinatesConnectionPoints);
        }
    }
}