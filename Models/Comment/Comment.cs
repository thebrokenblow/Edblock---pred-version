using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Flowchart_Editor.Models.Comment
{
    public class Comment
    {
        public Canvas? canvasOComment = null;
        public TextBox? textBoxOfComment = null;
        public TextBlock? textBlockOfComment = null;
        private bool textChangeStatus = false;
        private int defaulFontSize = DefaultPropertyForBlock.fontSize;
        private FontFamily defaultFontFamily = DefaultPropertyForBlock.fontFamily;
        private string defaulLineColor = DefaultPropertyForBlock.colorLine;
        private int valueOfClicksOnTextBlock = 0;
        const string textOfActionBlock = "Комментарий";
        public Line firstLine;
        public Line secondLine;
        public Line thirdLine;
        public Line fourthLine;
        public Line fifthLine;
        public Line sixthtLine;

        public UIElement GetUIElementWithoutCreate() => canvasOComment;

        private void actionBlockForMovements_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (textChangeStatus)
                {
                    var instanceOfComment = new CommentForMovements(sender);
                    var dataObjectInformationOfComment = new DataObject(typeof(CommentForMovements), instanceOfComment);
                    DragDrop.DoDragDrop(sender as DependencyObject, dataObjectInformationOfComment, DragDropEffects.Copy);
                }
            }
            e.Handled = true;
        }

        public UIElement GetUIElement()
        {
            if (canvasOComment == null)
            {
                canvasOComment = new Canvas();
                textBoxOfComment = new TextBox();
                textBlockOfComment = new TextBlock();
                firstLine = new Line();
                secondLine = new Line();
                thirdLine = new Line();
                fourthLine = new Line();
                fifthLine = new Line();
                sixthtLine = new Line();

                BrushConverter color = new BrushConverter();
             
                firstLine.X1 = 30;
                firstLine.Y1 = 40;
                firstLine.X2 = 50;
                firstLine.Y2 = 40;
                firstLine.Stroke = (Brush)color.ConvertFrom(defaulLineColor);

                secondLine.X1 = 60;
                secondLine.Y1 = 40;
                secondLine.X2 = 80;
                secondLine.Y2 = 40;
                secondLine.Stroke = (Brush)color.ConvertFrom(defaulLineColor);

                thirdLine.X1 = 90;
                thirdLine.Y1 = 40;
                thirdLine.X2 = 110;
                thirdLine.Y2 = 40;
                thirdLine.Stroke = (Brush)color.ConvertFrom(defaulLineColor);

                fourthLine.X1 = 110;
                fourthLine.Y1 = 0;
                fourthLine.X2 = 110;
                fourthLine.Y2 = 75;
                fourthLine.Stroke = (Brush)color.ConvertFrom(defaulLineColor);

                fifthLine.X1 = 120;
                fifthLine.Y1 = 0;
                fifthLine.X2 = 110;
                fifthLine.Y2 = 0;
                fifthLine.Stroke = (Brush)color.ConvertFrom(defaulLineColor);

                sixthtLine.X1 = 120;
                sixthtLine.Y1 = 75;
                sixthtLine.X2 = 110;
                sixthtLine.Y2 = 75;
                sixthtLine.Stroke = (Brush)color.ConvertFrom(defaulLineColor);

                textBoxOfComment.Text = textOfActionBlock;
                textBoxOfComment.Width = 150;
                textBoxOfComment.Height = 75;
                textBoxOfComment.FontSize = defaulFontSize;
                textBoxOfComment.FontFamily = defaultFontFamily;
                textBoxOfComment.VerticalAlignment = VerticalAlignment.Center;
                textBoxOfComment.HorizontalAlignment = HorizontalAlignment.Center;
                textBoxOfComment.TextAlignment = TextAlignment.Center;
                textBoxOfComment.Foreground = Brushes.Black;
                textBoxOfComment.TextWrapping = TextWrapping.Wrap;
                textBoxOfComment.MouseDoubleClick += ChangeTextBoxToLabel;
                Canvas.SetLeft(textBoxOfComment, 110);


                textBlockOfComment.Width = 150;
                textBlockOfComment.Height = 750;
                textBlockOfComment.FontSize = defaulFontSize;
                textBlockOfComment.FontFamily = defaultFontFamily;
                textBlockOfComment.VerticalAlignment = VerticalAlignment.Center;
                textBlockOfComment.HorizontalAlignment = HorizontalAlignment.Center;
                textBlockOfComment.TextAlignment = TextAlignment.Center;
                textBlockOfComment.Foreground = Brushes.Black;
                textBlockOfComment.TextWrapping = TextWrapping.Wrap;
                textBlockOfComment.MouseDown += ChangeTextBoxToLabel;
                Canvas.SetLeft(textBoxOfComment, 110);

                canvasOComment.Children.Add(firstLine);
                canvasOComment.Children.Add(secondLine);
                canvasOComment.Children.Add(thirdLine);
                canvasOComment.Children.Add(fourthLine);
                canvasOComment.Children.Add(fifthLine);
                canvasOComment.Children.Add(sixthtLine);
                canvasOComment.Children.Add(textBoxOfComment);
                canvasOComment.MouseMove += actionBlockForMovements_MouseMove;
            }
            return canvasOComment;
        }
        private void ChangeTextBoxToLabel(object sender, MouseEventArgs e)
        {
            if (textChangeStatus)
            {
                valueOfClicksOnTextBlock++;
                if (valueOfClicksOnTextBlock == 2)
                {
                    canvasOComment.Children.Remove(textBoxOfComment);
                    canvasOComment.Children.Remove(textBlockOfComment);
                    textBoxOfComment.Text = textBlockOfComment.Text;
                    Canvas.SetLeft(textBoxOfComment, 110);
                    canvasOComment.Children.Add(textBoxOfComment);
                    textChangeStatus = false;
                    valueOfClicksOnTextBlock = 0;
                }
            }
            else
            {
                canvasOComment.Children.Remove(textBoxOfComment);
                canvasOComment.Children.Remove(textBlockOfComment);
                textBlockOfComment.Text = textBoxOfComment.Text;
                Canvas.SetTop(textBlockOfComment, 3.5);
                Canvas.SetLeft(textBlockOfComment, 110);
                canvasOComment.Children.Add(textBlockOfComment);
                textChangeStatus = true;
            }
        }

        public void Reset()
        {
            canvasOComment = null;
        }
    }
}
