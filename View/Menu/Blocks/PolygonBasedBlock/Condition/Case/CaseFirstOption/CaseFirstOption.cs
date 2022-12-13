using Flowchart_Editor.Model;
using Flowchart_Editor.View.Condition.Case;
using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Flowchart_Editor.View.ConditionCaseFirstOption
{
    public class CaseFirstOption : CaseBlock
    {
        private readonly Line baseLine;
        public CaseFirstOption(int countLineCase)
        {
            this.countLineCase = countLineCase;
            baseLine = new();
            DrawLine();
        }

        public override void SetWidth(int widthBlock)
        {
            ControlSize.Width = widthBlock;
            SetPropertyControl();
           
            baseLine.X1 = widthBlock / 2;
            baseLine.X2 = widthBlock / 2;

            for (int i = 1; i <= linesCase.Count; i++)
            {
                linesCase[i - 1].Item1.X1 = widthBlock / 2;
                linesCase[i - 1].Item1.X2 = widthBlock;

                int offSetTopTextBox = widthBlock / 2;
                Canvas.SetLeft(linesCase[i - 1].Item2, offSetTopTextBox);
            }
        }

        public override void SetHeight(int heightBlock)
        {
            ControlSize.Height = heightBlock;
            SetPropertyControl();

            baseLine.Y1 = heightBlock;
            baseLine.Y2 = heightBlock / 2 + (heightBlock + lineIndent) * countLineCase;

            for (int i = 1; i <= linesCase.Count; i++)
            {
                linesCase[i - 1].Item1.Y1 = heightBlock / 2 + i * (heightBlock + lineIndent);
                linesCase[i - 1].Item1.Y2 = heightBlock / 2 + i * (heightBlock + lineIndent);

                int offSetTopTextBox = heightBlock / 2 + i * (heightBlock + lineIndent) - (lineIndent * 2 + lineIndent / 2);
                Canvas.SetTop(linesCase[i - 1].Item2, offSetTopTextBox);
            }
        }

        protected override void DrawLine()
        {
            double widthBlock = ControlSize.Width;
            double heightBlock = ControlSize.Height;

            baseLine.X1 = widthBlock / 2;
            baseLine.Y1 = heightBlock;
            baseLine.X2 = widthBlock / 2;
            baseLine.Y2 = heightBlock / 2 + (heightBlock + lineIndent) * countLineCase;
            baseLine.Stroke = Brushes.Black;
            FrameBlock.Children.Add(baseLine);

            for (int i = 1; i <= countLineCase; i++)
            {
                Line lineCase = new()
                {
                    X1 = widthBlock / 2,
                    Y1 = heightBlock / 2 + i * (heightBlock + lineIndent),
                    X2 = widthBlock,
                    Y2 = heightBlock / 2 + i * (heightBlock + lineIndent),
                    Stroke = Brushes.Black
                };

                TextBox textBoxCase = new()
                {
                    Text = initialText
                };

                double offsetLeft = widthBlock / 2;
                double offsetTop = heightBlock / 2 + i * (heightBlock + lineIndent) - (lineIndent * 2 + lineIndent / 2);
                ControlOffset offsetTextField = new(offsetLeft, offsetTop);
                SetCoordinates(textBoxCase, offsetTextField);

                Tuple<Line, TextBox> itemLineCase = new(lineCase, textBoxCase);

                linesCase.Add(itemLineCase);
                FrameBlock.Children.Add(lineCase);
                FrameBlock.Children.Add(textBoxCase);
            }
        }
    }
}