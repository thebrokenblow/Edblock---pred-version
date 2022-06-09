using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Flowchart_Editor.Models.Comment
{
    public class CommentControls : Block
    {
        private const int gapBetweenCommentLines = 15;
        private int coordinatesX = 0;
        private readonly int minimumHeightOfAllBlocks = DefaultPropertyForBlock.height;
        private readonly int minimumWidthOfAllBlocks = DefaultPropertyForBlock.width;
        private const string textComment = "Комментарий";
        private static readonly int valueDottedPartOfTheComment = 3;
        private Style? styleLine;
        public Line[]? DottedPartOfTheComment{ get; private set; }
        public Line? FourthLine { get; private set; }
        public Line? FifthLine { get; private set; }
        public Line? SixthtLine { get; private set; }

        public CommentControls(double blockWidthCoefficient, double blockHeightCoefficient)
        {
            this.blockWidthCoefficient = blockWidthCoefficient;
            this.blockHeightCoefficient = blockHeightCoefficient;
        }

        public static string GetTextOfComment() => textComment;

        public override void SetHeight(int height)
        {
            if (DottedPartOfTheComment != null && FourthLine != null && FifthLine != null && SixthtLine != null)
            {
                if (blockHeightCoefficient == 1)
                {
                    foreach (Line line in DottedPartOfTheComment)
                    {
                        line.Y1 = (height - minimumHeightOfAllBlocks) / 2;
                        line.Y2 = (height - minimumHeightOfAllBlocks) / 2;
                    }

                    FourthLine.Y1 = -gapBetweenCommentLines * 2 + (height - minimumHeightOfAllBlocks) / 2;
                    FourthLine.Y2 = gapBetweenCommentLines * 2 + (height - minimumHeightOfAllBlocks) / 2;

                    FifthLine.Y1 = -gapBetweenCommentLines * 2 + (height - minimumHeightOfAllBlocks) / 2;
                    FifthLine.Y2 = -gapBetweenCommentLines * 2 + (height - minimumHeightOfAllBlocks) / 2;

                    SixthtLine.Y1 = gapBetweenCommentLines * 2 + (height - minimumHeightOfAllBlocks) / 2;
                    SixthtLine.Y2 = gapBetweenCommentLines * 2 + (height - minimumHeightOfAllBlocks) / 2;

                    Canvas.SetTop(TextBox, -gapBetweenCommentLines * 2 + (height - minimumHeightOfAllBlocks) / 2);
                }
                else if (blockHeightCoefficient == 0.5 && blockWidthCoefficient == 0.5)
                {
                    foreach (Line line in DottedPartOfTheComment)
                    {
                        line.Y1 = (height - minimumHeightOfAllBlocks) / 4;
                        line.Y2 = (height - minimumHeightOfAllBlocks) / 4;
                    }

                    FourthLine.Y1 = -gapBetweenCommentLines * 2 + (height - minimumHeightOfAllBlocks) / 4;
                    FourthLine.Y2 = gapBetweenCommentLines * 2 + (height - minimumHeightOfAllBlocks) / 4;

                    FifthLine.Y1 = -gapBetweenCommentLines * 2 + (height - minimumHeightOfAllBlocks) / 4;
                    FifthLine.Y2 = -gapBetweenCommentLines * 2 + (height - minimumHeightOfAllBlocks) / 4;

                    SixthtLine.Y1 = gapBetweenCommentLines * 2 + (height - minimumHeightOfAllBlocks) / 4;
                    SixthtLine.Y2 = gapBetweenCommentLines * 2 + (height - minimumHeightOfAllBlocks) / 4;

                    Canvas.SetTop(TextBox, -gapBetweenCommentLines * 2 + (height - minimumHeightOfAllBlocks) / 4);

                    int blockOffset = (height - minimumHeightOfAllBlocks) / 2;
                    foreach (Line line in DottedPartOfTheComment)
                    {
                        line.X1 = blockOffset + coordinatesX;
                        line.X2 = blockOffset + coordinatesX + gapBetweenCommentLines;
                        coordinatesX += gapBetweenCommentLines * 2;
                    }

                    coordinatesX -= gapBetweenCommentLines;

                    FourthLine.X1 = blockOffset + coordinatesX;
                    FourthLine.X2 = FourthLine.X1;

                    FifthLine.X1 = FourthLine.X2;
                    FifthLine.X2 = FifthLine.X1 + gapBetweenCommentLines;

                    SixthtLine.X1 = FifthLine.X1;
                    SixthtLine.X2 = SixthtLine.X1 + gapBetweenCommentLines;

                    Canvas.SetLeft(TextBox, SixthtLine.X1 + gapBetweenCommentLines / 4);
                    coordinatesX = 0;
                }
            }
        }

        public override void SetWidth(int width)
        {
            int blockOffset = width - minimumWidthOfAllBlocks;
            if (DottedPartOfTheComment != null && FourthLine != null && FifthLine != null && SixthtLine != null)
            {
                if (blockWidthCoefficient == 1)
                {
                    foreach (Line line in DottedPartOfTheComment)
                    {
                        line.X1 = blockOffset + coordinatesX;
                        line.X2 = blockOffset + coordinatesX + gapBetweenCommentLines;
                        coordinatesX += gapBetweenCommentLines * 2;
                    }
                    coordinatesX -= gapBetweenCommentLines;

                    FourthLine.X1 = blockOffset + coordinatesX;
                    FourthLine.X2 = FourthLine.X1;

                    FifthLine.X1 = FourthLine.X2;
                    FifthLine.X2 = FifthLine.X1 + gapBetweenCommentLines;

                    SixthtLine.X1 = FifthLine.X1;
                    SixthtLine.X2 = SixthtLine.X1 + gapBetweenCommentLines;

                    coordinatesX = 0;
                    Canvas.SetLeft(TextBox, SixthtLine.X1 + gapBetweenCommentLines / 4);
                }
            }
        }

        public override UIElement GetUIElement()
        {
            if (canvas == null)
            {
                canvas = new();
                TextBox = new();
                TextBlock = new();
                FourthLine = new();
                FifthLine = new();
                SixthtLine = new();

                if (Application.LoadComponent(uri) is ResourceDictionary resourceDict)
                {
                    styleLine = resourceDict["LineStyle"] as Style;
                    TextBox.Style = resourceDict["TextBoxStyleForComment"] as Style;
                }

                SetPropertyLineOfComment();
                TextBox.Text = textComment;
                TextBox.MouseDoubleClick += ChangeTextBoxToTextBlock;
                TextBlock.MouseDown += ChangeTextBoxToTextBlock;

                Canvas.SetLeft(TextBox, coordinatesX + gapBetweenCommentLines / 4);
                Canvas.SetTop(TextBox, -gapBetweenCommentLines * 2);

                Canvas.SetLeft(TextBlock, coordinatesX + gapBetweenCommentLines / 4 + 5);
                Canvas.SetTop(TextBlock, -gapBetweenCommentLines * 2 + 5);

                TextBox.TextChanged += new TextChangedEventHandler((obj, args) =>
                {
                    double heightTextBox = TextBox.ActualHeight;
                    int valueFontSize = StaticBlock.fontSize;
                    FourthLine.Y1 = -heightTextBox / 2 - valueFontSize * 2;
                    FourthLine.Y2 = heightTextBox / 2 + valueFontSize * 2;

                    FifthLine.Y1 = -heightTextBox / 2 - valueFontSize * 2;
                    FifthLine.Y2 = -heightTextBox / 2 - (valueFontSize * 2);

                    SixthtLine.Y1 = heightTextBox / 2 + valueFontSize * 2;
                    SixthtLine.Y2 = heightTextBox / 2 + valueFontSize * 2;

                    Canvas.SetTop(TextBlock, -TextBox.ActualHeight / 2);
                    Canvas.SetTop(TextBox, -TextBox.ActualHeight / 2);
                });

                TextBox.LostFocus += new RoutedEventHandler((obj, args) =>
                {
                    double heightTextBox = TextBox.ActualHeight;

                    Canvas.SetTop(TextBox, 0);
                    FourthLine.Y1 = -heightTextBox / 2;
                    FourthLine.Y2 = heightTextBox / 2;

                    FifthLine.Y1 = -heightTextBox / 2;
                    FifthLine.Y2 = -heightTextBox / 2;

                    SixthtLine.Y1 = heightTextBox / 2;
                    SixthtLine.Y2 = heightTextBox / 2;

                    Canvas.SetTop(TextBlock, -TextBox.ActualHeight / 2);
                    Canvas.SetTop(TextBox, -TextBox.ActualHeight / 2);

                });
                coordinatesX = 0;

                canvas.Children.Add(FourthLine);
                canvas.Children.Add(FifthLine);
                canvas.Children.Add(SixthtLine);
                canvas.Children.Add(TextBox);
            }
            return canvas;
        }

        private void SetPropertyLineOfComment()
        {
            if (canvas != null && FourthLine != null && FifthLine != null && SixthtLine != null)
            {
                int index = 0;
                DottedPartOfTheComment = new Line[valueDottedPartOfTheComment];
                for (int i = 1; i <= valueDottedPartOfTheComment; i++)
                {
                    Line line = new();
                    line.X1 = coordinatesX;
                    line.Y1 = 0;

                    coordinatesX += gapBetweenCommentLines;

                    line.X2 = coordinatesX;
                    line.Y2 = 0;
                    line.Style = styleLine;

                    coordinatesX += gapBetweenCommentLines;
                    canvas.Children.Add(line);
                    DottedPartOfTheComment[index] = line;
                    index++;
                }
                coordinatesX -= gapBetweenCommentLines;

                FourthLine.X1 = coordinatesX;
                FourthLine.Y1 = -gapBetweenCommentLines * 2;
                FourthLine.X2 = coordinatesX;
                FourthLine.Y2 = gapBetweenCommentLines * 2;
                FourthLine.Style = styleLine;

                FifthLine.X1 = coordinatesX;
                FifthLine.Y1 = -gapBetweenCommentLines * 2;
                coordinatesX += gapBetweenCommentLines;
                FifthLine.X2 = coordinatesX;
                FifthLine.Y2 = -gapBetweenCommentLines * 2;
                FifthLine.Style = styleLine;

                SixthtLine.X2 = coordinatesX;
                SixthtLine.Y2 = gapBetweenCommentLines * 2;
                coordinatesX -= gapBetweenCommentLines;
                SixthtLine.X1 = coordinatesX;
                SixthtLine.Y1 = gapBetweenCommentLines * 2;
                SixthtLine.Style = styleLine;
            }
        }

        protected override void SetСoordinatesComment(UIElement comment) { }

        public override double GetWidthCoefficient() => 0;

        public override double GetHeightCoefficient() => 0;
    }
}