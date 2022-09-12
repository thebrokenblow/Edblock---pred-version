﻿using Flowchart_Editor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Flowchart_Editor.View.Condition.Case
{
    public abstract class CaseBlock : ConditionBlock
    {
        protected Style? styleLine;
        protected Style? styleTextBox;
        public List<Line>? listLine;
        public List<TextBox>? listTextBox;
        public Dictionary<Line, Block> dictionaryLineAndBlock = new();
        protected int countLine = 0;

        public abstract new UIElement GetUIElement();

        public void SetTextForTextBox(List<string> listTextOfLine)
        {
            IEnumerable<Tuple<string, TextBox>>? listCompliteTextBox = null;
            if (listTextBox != null)
            {
                listCompliteTextBox = listTextOfLine.Zip(
                   listTextBox,
                   (textOfLine, textBox) => new Tuple<string, TextBox>(textOfLine, textBox));
            }

            if (listCompliteTextBox != null)
            {
                foreach (Tuple<string, TextBox> itemListCompliteTextBox in listCompliteTextBox)
                    itemListCompliteTextBox.Item2.Text = itemListCompliteTextBox.Item1;
            }

        }

        public void PindingBlock(CaseBlock caseBlock, Block block, Line line)
        {
            if (block != null)
            {
                
                double coordinateLeft = line.X2;
                double coordinateTop = line.Y2;
                UIElement uIElementBlock = block.GetUIElement();
                
                if (FrameBlock != null)
                    FrameBlock.Children.Add(block.GetUIElement());
                dictionaryLineAndBlock.Add(line, block);
            }
            else
            {
                
                double coordinateLeft = line.X2;
                double coordinateTop = line.Y2;
                UIElement uIElementBlock = caseBlock.GetUIElement();
                
                if (FrameBlock != null)
                    FrameBlock.Children.Add(caseBlock.GetUIElement());
                dictionaryLineAndBlock.Add(line, caseBlock);
            }
        }      
    }
}