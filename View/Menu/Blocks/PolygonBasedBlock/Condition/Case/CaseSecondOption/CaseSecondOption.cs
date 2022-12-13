using System;
using System.Windows.Media;
using System.Windows.Shapes;
using Flowchart_Editor.Model;
using System.Windows.Controls;
using Flowchart_Editor.View.Condition.Case;

namespace Flowchart_Editor.View.ConditionCaseSecondOption
{
    [BlockName("ConditionCaseSecondOptionBlock")]
    public class CaseSecondOption : CaseBlock
    {
        private const int baselineLength = 20;
        private const int textBoxOffset = 5;
        private double displacementCoefficient = 0;
        private readonly Line firstBaseLine;
        private readonly Line secondBaseLine;
        private readonly Line lineCase;
        public CaseSecondOption(int countLineCase)
        {
            this.countLineCase = --countLineCase;
            firstBaseLine = new();
            secondBaseLine = new();
            lineCase = new();
            DrawLine();
        }

        public override void SetWidth(int widthBlock)
        {
            ControlSize.Width = widthBlock;
            SetPropertyControl();
            displacementCoefficient = (widthBlock + lineIndent) * countLineCase / 2;

            firstBaseLine.X1 = widthBlock / 2;
            firstBaseLine.X2 = widthBlock / 2;

            secondBaseLine.X1 = -displacementCoefficient;
            secondBaseLine.X2 = displacementCoefficient;
            Canvas.SetLeft(secondBaseLine, widthBlock / 2);

            lineCase.X1 = -displacementCoefficient;
            lineCase.X2 = -displacementCoefficient;

            for (int i = 0; i < linesCase.Count; i++)
            {
                linesCase[i].Item1.X1 = -displacementCoefficient + (widthBlock + lineIndent) * i;
                linesCase[i].Item1.X2 = -displacementCoefficient + (widthBlock + lineIndent) * i;
                Canvas.SetLeft(linesCase[i].Item1, widthBlock / 2);
                double offsetLeft = (-displacementCoefficient + (widthBlock + lineIndent) * i) + widthBlock / 2;
                Canvas.SetLeft(linesCase[i].Item2, offsetLeft);
            }
        }

        public override void SetHeight(int heightBlock)
        {
            ControlSize.Height = heightBlock;
            SetPropertyControl();

            firstBaseLine.Y1 = heightBlock;
            firstBaseLine.Y2 = heightBlock + baselineLength;

            secondBaseLine.Y1 = heightBlock + baselineLength;
            secondBaseLine.Y2 = heightBlock + baselineLength;

            foreach (var itemLineCase in linesCase)
            {
                itemLineCase.Item1.Y1 = heightBlock + baselineLength;
                itemLineCase.Item1.Y2 = heightBlock + baselineLength * 2;
                Canvas.SetTop(itemLineCase.Item2, heightBlock + baselineLength - textBoxOffset);
            }
        }

        private void DrawFirstBaseLine(double widthBlock, double heightBlock)
        {
            firstBaseLine.X1 = widthBlock / 2;
            firstBaseLine.Y1 = heightBlock;
            firstBaseLine.X2 = widthBlock / 2;
            firstBaseLine.Y2 = heightBlock + baselineLength;
            firstBaseLine.Stroke = Brushes.Black;
            FrameBlock.Children.Add(firstBaseLine);
        }

        private void DrawSecondBaseLine(double widthBlock, double heightBlock, double displacementCoefficient)
        {
            secondBaseLine.X1 = -displacementCoefficient;
            secondBaseLine.Y1 = heightBlock + baselineLength;
            secondBaseLine.X2 = displacementCoefficient;
            secondBaseLine.Y2 = heightBlock + baselineLength;
            Canvas.SetLeft(secondBaseLine, widthBlock / 2);
            secondBaseLine.Stroke = Brushes.Black;
            FrameBlock.Children.Add(secondBaseLine);
        }

        private void DrawFirstLineCase(double widthBlock, double heightBlock, double displacementCoefficient)
        {
            lineCase.X1 = -displacementCoefficient;
            lineCase.Y1 = heightBlock + baselineLength;
            lineCase.X2 = -displacementCoefficient;
            lineCase.Y2 = heightBlock + baselineLength * 2;
            Canvas.SetLeft(lineCase, widthBlock / 2);
            lineCase.Stroke = Brushes.Black;
            FrameBlock.Children.Add(lineCase);
        }

        private void DrawFirstTextCase(double widthBlock, double heightBlock, double displacementCoefficient)
        {
            TextBox textBoxCase = new();

            double offsetLeft = -displacementCoefficient + widthBlock / 2;
            double offsetTop = heightBlock + baselineLength - textBoxOffset;

            ControlOffset offsetTextField = new(offsetLeft, offsetTop);

            SetCoordinates(textBoxCase, offsetTextField);

            textBoxCase.Text = initialText;

            FrameBlock.Children.Add(textBoxCase);

            Tuple<Line, TextBox> itemLineCase = new(lineCase, textBoxCase);
            linesCase.Add(itemLineCase);
        }

        private void DrawCases(double xCoordinate, double widthBlock, double heightBlock)
        {
            Line lineCase = new();
            TextBox textBoxCase = new();

            lineCase.X1 = xCoordinate;
            lineCase.Y1 = heightBlock + baselineLength;
            lineCase.X2 = xCoordinate;
            lineCase.Y2 = heightBlock + baselineLength * 2;

            Canvas.SetLeft(lineCase, widthBlock / 2);
            lineCase.Stroke = Brushes.Black;

            double offsetLeft = xCoordinate + widthBlock / 2;
            double offsetTop = heightBlock + baselineLength - textBoxOffset;
            ControlOffset offsetTextField = new(offsetLeft, offsetTop);
            SetCoordinates(textBoxCase, offsetTextField);

            textBoxCase.Text = initialText;

            Tuple<Line, TextBox> itemLineCase = new(lineCase, textBoxCase);
            linesCase.Add(itemLineCase);

            FrameBlock.Children.Add(lineCase);
            FrameBlock.Children.Add(textBoxCase);
        }
        protected override void DrawLine()
        {
            double widthBlock = ControlSize.Width;
            double heightBlock = ControlSize.Height;
            displacementCoefficient = (widthBlock + lineIndent) * countLineCase / 2;

            DrawFirstBaseLine(widthBlock, heightBlock);
            DrawSecondBaseLine(widthBlock, heightBlock, displacementCoefficient);
            DrawFirstLineCase(widthBlock, heightBlock, displacementCoefficient);
            DrawFirstTextCase(widthBlock, heightBlock, displacementCoefficient);

            for (int i = 1; i <= countLineCase; i++)
            {
                double xCoordinate = -displacementCoefficient + (widthBlock + lineIndent) * i;
                DrawCases(xCoordinate, widthBlock, heightBlock);
            }
        }
    }
}