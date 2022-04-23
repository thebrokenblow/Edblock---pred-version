using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Flowchart_Editor.Models.Comment
{
    public class Comment
    {
        private Canvas? canvasOfComment;
        private TextBox textBoxOfComment;
        private TextBlock textBlockOfComment;
        private bool textChangeStatus = false;
        private readonly int defaulFontSize = DefaultPropertyForBlock.fontSize;
        private readonly FontFamily defaultFontFamily = DefaultPropertyForBlock.fontFamily;
        private readonly string defaulLineColor = DefaultPropertyForBlock.colorLine;
        private int valueOfClicksOnTextBlock = 0;
        private readonly int gapBetweenCommentLines = 15;
        private readonly int minimumHeightOfAllBlocks = DefaultPropertyForBlock.height;
        private readonly int minimumWidthOfAllBlocks = DefaultPropertyForBlock.width;
        private readonly double initialСoordinatesX = 0;
        private readonly double initialСoordinatesY = 0;
        private const string textComment = "Комментарий";
        private Line firstLine;
        private Line secondLine;
        private Line thirdLine;
        private Line fourthLine;
        private Line fifthLine;
        private Line sixthtLine;

        public UIElement? GetUIElementWithoutCreate() => canvasOfComment;

        public static string GetTextOfComment() => textComment;

        public void SetHeight(int height)
        {
            if (firstLine != null && secondLine != null && thirdLine != null && fourthLine != null && fifthLine != null && sixthtLine != null)
            {
                firstLine.Y1 = (height - minimumHeightOfAllBlocks) / 2;
                firstLine.Y2 = (height - minimumHeightOfAllBlocks) / 2;

                secondLine.Y1 = (height - minimumHeightOfAllBlocks) / 2;
                secondLine.Y2 = (height - minimumHeightOfAllBlocks) / 2;

                thirdLine.Y1 = (height - minimumHeightOfAllBlocks) / 2;
                thirdLine.Y2 = (height - minimumHeightOfAllBlocks) / 2;

                fourthLine.Y1 = -gapBetweenCommentLines * 2 + (height - minimumHeightOfAllBlocks) / 2;
                fourthLine.Y2 = gapBetweenCommentLines * 2 + (height - minimumHeightOfAllBlocks) / 2;

                fifthLine.Y1 = -gapBetweenCommentLines * 2 + (height - minimumHeightOfAllBlocks) / 2;
                fifthLine.Y2 = -gapBetweenCommentLines * 2 + (height - minimumHeightOfAllBlocks) / 2;

                sixthtLine.Y1 = gapBetweenCommentLines * 2 + (height - minimumHeightOfAllBlocks) / 2;
                sixthtLine.Y2 = gapBetweenCommentLines * 2 + (height - minimumHeightOfAllBlocks) / 2;

                Canvas.SetTop(textBoxOfComment, -gapBetweenCommentLines * 2 + (height - minimumHeightOfAllBlocks) / 2);

                Canvas.SetTop(textBlockOfComment, -gapBetweenCommentLines * 2 + (height - minimumHeightOfAllBlocks) / 2);
            }
        }
        public void SetWidtht(int width)
        {
            if (firstLine != null && secondLine != null && thirdLine != null && fourthLine != null && fifthLine != null && sixthtLine != null)
            {
                firstLine.X1 = width - minimumWidthOfAllBlocks;
                firstLine.X2 = width - minimumWidthOfAllBlocks + gapBetweenCommentLines;

                secondLine.X1 = width - minimumWidthOfAllBlocks + gapBetweenCommentLines * 2;
                secondLine.X2 = width - minimumWidthOfAllBlocks + gapBetweenCommentLines * 3;

                thirdLine.X1 = width - minimumWidthOfAllBlocks + gapBetweenCommentLines * 4;
                thirdLine.X2 = width - minimumWidthOfAllBlocks + gapBetweenCommentLines * 5;

                fourthLine.X1 = width - minimumWidthOfAllBlocks + gapBetweenCommentLines * 5;
                fourthLine.X2 = width - minimumWidthOfAllBlocks + gapBetweenCommentLines * 5;

                fifthLine.X1 = width - minimumWidthOfAllBlocks + gapBetweenCommentLines * 5;
                fifthLine.X2 = width - minimumWidthOfAllBlocks + gapBetweenCommentLines * 6;

                sixthtLine.X1 = width - minimumWidthOfAllBlocks + gapBetweenCommentLines * 5;
                sixthtLine.X2 = width - minimumWidthOfAllBlocks + gapBetweenCommentLines * 6;

                Canvas.SetLeft(textBoxOfComment, width - minimumWidthOfAllBlocks + gapBetweenCommentLines * 5 + gapBetweenCommentLines / 4);
                Canvas.SetLeft(textBlockOfComment, width - minimumWidthOfAllBlocks + gapBetweenCommentLines * 5 + gapBetweenCommentLines / 4);
            }
        }
        public UIElement GetUIElement()
        {
            if (canvasOfComment == null)
            {
                canvasOfComment = new Canvas();
                textBoxOfComment = new TextBox();
                textBlockOfComment = new TextBlock();
                firstLine = new Line();
                secondLine = new Line();
                thirdLine = new Line();
                fourthLine = new Line();
                fifthLine = new Line();
                sixthtLine = new Line();

                BrushConverter color = new();
             
                firstLine.X1 = initialСoordinatesX;
                firstLine.Y1 = initialСoordinatesY;
                firstLine.X2 = initialСoordinatesX + gapBetweenCommentLines;
                firstLine.Y2 = initialСoordinatesY;
                firstLine.Stroke = (Brush)color.ConvertFrom(defaulLineColor);

                secondLine.X1 = gapBetweenCommentLines * 2;
                secondLine.Y1 = initialСoordinatesY;
                secondLine.X2 = gapBetweenCommentLines * 3;
                secondLine.Y2 = initialСoordinatesY;
                secondLine.Stroke = (Brush)color.ConvertFrom(defaulLineColor);

                thirdLine.X1 = initialСoordinatesX + gapBetweenCommentLines * 4;
                thirdLine.Y1 = initialСoordinatesY;
                thirdLine.X2 = initialСoordinatesX + gapBetweenCommentLines * 5;
                thirdLine.Y2 = initialСoordinatesY;
                thirdLine.Stroke = (Brush)color.ConvertFrom(defaulLineColor);

                fourthLine.X1 = gapBetweenCommentLines * 5;
                fourthLine.Y1 = -gapBetweenCommentLines * 2;
                fourthLine.X2 = gapBetweenCommentLines * 5;
                fourthLine.Y2 = gapBetweenCommentLines * 2;
                fourthLine.Stroke = (Brush)color.ConvertFrom(defaulLineColor);

                fifthLine.X1 = gapBetweenCommentLines * 5;
                fifthLine.Y1 = -gapBetweenCommentLines * 2;
                fifthLine.X2 = gapBetweenCommentLines * 6;
                fifthLine.Y2 = -gapBetweenCommentLines * 2;
                fifthLine.Stroke = (Brush)color.ConvertFrom(defaulLineColor);

                sixthtLine.X1 = gapBetweenCommentLines * 5;
                sixthtLine.Y1 = gapBetweenCommentLines * 2;
                sixthtLine.X2 = gapBetweenCommentLines * 6;
                sixthtLine.Y2 = gapBetweenCommentLines * 2;
                sixthtLine.Stroke = (Brush)color.ConvertFrom(defaulLineColor);

                textBoxOfComment.Text = textComment;
                textBoxOfComment.FontSize = defaulFontSize;
                textBoxOfComment.FontFamily = defaultFontFamily;
                textBoxOfComment.VerticalAlignment = VerticalAlignment.Center;
                textBoxOfComment.HorizontalAlignment = HorizontalAlignment.Center;
                textBoxOfComment.TextAlignment = TextAlignment.Center;
                textBoxOfComment.Foreground = Brushes.Black;
                textBoxOfComment.TextWrapping = TextWrapping.Wrap;
                textBoxOfComment.AcceptsReturn = true;
                textBoxOfComment.MouseDoubleClick += ChangeTextBoxToLabel;
                Canvas.SetLeft(textBoxOfComment, gapBetweenCommentLines * 5 + gapBetweenCommentLines / 4);
                Canvas.SetTop(textBoxOfComment, -gapBetweenCommentLines * 2);

                textBlockOfComment.Text = textComment;
                textBlockOfComment.FontSize = defaulFontSize;
                textBlockOfComment.FontFamily = defaultFontFamily;
                textBlockOfComment.VerticalAlignment = VerticalAlignment.Center;
                textBlockOfComment.HorizontalAlignment = HorizontalAlignment.Center;
                textBlockOfComment.TextAlignment = TextAlignment.Center;
                textBlockOfComment.Foreground = Brushes.Black;
                textBlockOfComment.TextWrapping = TextWrapping.Wrap;
                textBlockOfComment.MouseDown += ChangeTextBoxToLabel;
                Canvas.SetLeft(textBlockOfComment, gapBetweenCommentLines * 5 + gapBetweenCommentLines / 4);
                Canvas.SetTop(textBlockOfComment, -gapBetweenCommentLines * 2);

                canvasOfComment.Children.Add(firstLine);
                canvasOfComment.Children.Add(secondLine);
                canvasOfComment.Children.Add(thirdLine);
                canvasOfComment.Children.Add(fourthLine);
                canvasOfComment.Children.Add(fifthLine);
                canvasOfComment.Children.Add(sixthtLine);
                canvasOfComment.Children.Add(textBoxOfComment);
            }
            return canvasOfComment;
        }
        private void ChangeTextBoxToLabel(object sender, MouseEventArgs e)
        {
            if (canvasOfComment != null)
            {
                if (textChangeStatus)
                {
                    valueOfClicksOnTextBlock++;
                    if (valueOfClicksOnTextBlock == 2)
                    {
                        canvasOfComment.Children.Remove(textBoxOfComment);
                        canvasOfComment.Children.Remove(textBlockOfComment);
                        textBoxOfComment.Text = textBlockOfComment.Text;
                        Canvas.SetTop(textBoxOfComment, -gapBetweenCommentLines * 2);
                        Canvas.SetLeft(textBoxOfComment, gapBetweenCommentLines * 5 + gapBetweenCommentLines / 4);
                        canvasOfComment.Children.Add(textBoxOfComment);
                        textChangeStatus = false;
                        valueOfClicksOnTextBlock = 0;
                    }
                }
                else
                {
                    canvasOfComment.Children.Remove(textBoxOfComment);
                    canvasOfComment.Children.Remove(textBlockOfComment);
                    textBlockOfComment.Text = textBoxOfComment.Text;
                    Canvas.SetTop(textBoxOfComment, -gapBetweenCommentLines * 2 + 3.5);
                    Canvas.SetLeft(textBlockOfComment, gapBetweenCommentLines * 5 + gapBetweenCommentLines / 4);
                    canvasOfComment.Children.Add(textBlockOfComment);
                    textChangeStatus = true;
                }
            }
        }
    }
}
