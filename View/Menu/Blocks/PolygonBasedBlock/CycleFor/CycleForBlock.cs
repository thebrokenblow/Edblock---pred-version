﻿using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using System.Collections.Generic;
using Flowchart_Editor.Model;
using Flowchart_Editor.View.Menu.Blocks.PolygonBasedBlock;
using System.Windows.Shapes;

namespace Flowchart_Editor.Models
{
    [BlockName("CycleForBlock")]
    public class CycleForBlock : Block, IPolygonBased
    {
        private readonly List<Point> listPoints = new();
        private const int sideProjection = 10; 
        public CycleForBlock(Canvas destination)
        {
            EditField = destination;
            initialText = "Цикл for";

            SetPropertyFrameBlock();
            SetPropertyPolyginBlock();

            ControlSize sizeTextField = GetSizeTextField(ControlSize);
            ControlOffset offsetTextField = GetOffsetTextField();
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
            double width = controlSize.Width - sideProjection * 2;
            double height = controlSize.Height;
            ControlSize sizeTextField = new(width, height);
            return sizeTextField;
        }

        private static ControlOffset GetOffsetTextField()
        {
            double offsetLeft = sideProjection;
            double offsetTop = 0;
            ControlOffset offsetTextField = new(offsetLeft, offsetTop);
            return offsetTextField;
        }

        private void SetPropertyControl(ControlSize blockSize)
        {
            ControlSize textFieldSize = GetSizeTextField(blockSize);
            ControlOffset textFieldOffset = GetOffsetTextField();
            //SetCoordinatesCycleForBlock(blockSize);
            //SetPointPolygon(listPoints);
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

        public void SetCoordinatesPoints(ControlSize polygonSize)
        {
            double height = polygonSize.Height;
            double width = polygonSize.Width;

            listPoints.Clear();

            Point poinCycleForBlock = new(sideProjection, 0);
            listPoints.Add(poinCycleForBlock);

            poinCycleForBlock = new(sideProjection, 0);
            listPoints.Add(poinCycleForBlock);

            poinCycleForBlock = new(0, sideProjection);
            listPoints.Add(poinCycleForBlock);

            poinCycleForBlock = new(0, height - sideProjection);
            listPoints.Add(poinCycleForBlock);

            poinCycleForBlock = new(sideProjection, height);
            listPoints.Add(poinCycleForBlock);

            poinCycleForBlock = new(width - sideProjection, height);
            listPoints.Add(poinCycleForBlock);

            poinCycleForBlock = new(width, height - sideProjection);
            listPoints.Add(poinCycleForBlock);

            poinCycleForBlock = new(width, sideProjection);
            listPoints.Add(poinCycleForBlock);

            poinCycleForBlock = new(width - sideProjection, 0);
            listPoints.Add(poinCycleForBlock);
        }

        public void SetPropertyPolyginBlock()
        {
            SetCoordinatesPoints(ControlSize);
            Polygon cycleForBlock = IPolygonBased.SetPointPolygon(listPoints);
            IPolygonBased.AddPointPolygon(FrameBlock, cycleForBlock);

            string color = "#FFFFC618";
            Brush backgroundColor = GetBackgroundColor(color);
            IPolygonBased.SetFillPolygon(cycleForBlock, backgroundColor);
        }
    }
}