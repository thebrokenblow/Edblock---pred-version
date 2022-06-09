using Flowchart_Editor.Models;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Flowchart_Editor.View.ConditionCaseSecondOption
{
    public class ConditionCaseSecondOptionBlock : ConditionBlock
    {
        private readonly int defaultWidth = DefaultPropertyForBlock.width;
        private readonly int defaulHeight = DefaultPropertyForBlock.height;
        private Style? styleLine;
        private Style? styleTextBox;
        private List<Line>? listLine;
        private List<TextBox>? listTextBox;
        private Dictionary<Line, Block> dictionaryLineAndBlock = new();
        private readonly int countLineOfConditionCaseFirstOption = 0;
        public ConditionCaseSecondOptionBlock(MainWindow mainWindow, int keyBlock, int countLineOfConditionCaseFirstOption) : base(mainWindow, keyBlock)
        {
            MainWindow = mainWindow;
            keyOfBlock = keyBlock;
            this.countLineOfConditionCaseFirstOption = --countLineOfConditionCaseFirstOption;
            initialText = "Условие";
        }
        override public UIElement GetUIElement()
        {
            if (canvas == null)
            {
                canvas = new Canvas();
                polygon = new Polygon();
                TextBox = new TextBox();
                TextBlock = new TextBlock();
                firstPointToConnect = new Ellipse();
                secondPointToConnect = new Ellipse();
                thirdPointToConnect = new Ellipse();
                fourthPointToConnect = new Ellipse();

                canvas.Width = defaultWidth;
                canvas.Height = defaulHeight;

                BrushConverter brushConverter = new();
                Brush backgroundColor = (Brush)brushConverter.ConvertFrom("#FF60B2D3");

                polygon.Fill = backgroundColor;
                Point Point1 = new(0, defaulHeight / 2);
                Point Point2 = new(defaultWidth / 2, defaulHeight);
                Point Point3 = new(defaultWidth, defaulHeight / 2);
                Point Point4 = new(defaultWidth / 2, 0);
                Point Point5 = new(0, defaulHeight / 2);
      
                PointCollection myPointCollection = new();
                myPointCollection.Add(Point1);
                myPointCollection.Add(Point2);
                myPointCollection.Add(Point3);
                myPointCollection.Add(Point4);
                myPointCollection.Add(Point5);
                polygon.Points = myPointCollection;

                double valueForSetLeftTextBoxAndTextBlock = defaultWidth / 2 - defaultWidth / 4;
                double valueForSetTopTextBoxAndTextBlock = defaulHeight / 4;

                SetPropertyForTextBox(defaultWidth / 2, defaulHeight / 2, initialText, valueForSetLeftTextBoxAndTextBlock, valueForSetTopTextBoxAndTextBlock);
                
                SetPropertyForTextBlock(defaultWidth / 2, defaulHeight / 2, valueForSetLeftTextBoxAndTextBlock, valueForSetTopTextBoxAndTextBlock);

                SetPropertyForFirstPointToConnect(defaultWidth / 2 - 3, -2);

                SetPropertyForSecondPointToConnect(0, defaulHeight / 2 - 3);

                SetPropertyForThirdPointToConnect(defaultWidth / 2 - 3, defaulHeight - 3);

                SetPropertyForFourthPointToConnect(defaultWidth - 6, defaulHeight / 2 - 3);

                listLine = new List<Line>();
                listTextBox = new List<TextBox>();

                if (Application.LoadComponent(uri) is ResourceDictionary resourceDict)
                {
                    styleLine = resourceDict["LineStyle"] as Style;
                    styleTextBox = resourceDict["TextBoxStyleForComment"] as Style;
                }

                Line firstLine = new();
                firstLine.X1 = DefaultPropertyForBlock.width / 2;
                firstLine.Y1 = DefaultPropertyForBlock.height;
                firstLine.X2 = DefaultPropertyForBlock.width / 2;
                firstLine.Y2 = firstLine.Y1 + 20;
                firstLine.Style = styleLine;
                listLine.Add(firstLine);
                canvas.Children.Add(firstLine);
              
                double displacementCoefficient = (DefaultPropertyForBlock.width + 10) * countLineOfConditionCaseFirstOption;

                Line secondLine = new();
                secondLine.X1 = -displacementCoefficient / 2;
                secondLine.Y1 = firstLine.Y2;
                secondLine.X2 = displacementCoefficient / 2;
                secondLine.Y2 = secondLine.Y1;
                secondLine.Style = styleLine;
                Canvas.SetLeft(secondLine, DefaultPropertyForBlock.width / 2); 
                listLine.Add(secondLine);
                canvas.Children.Add(secondLine);

                for (int i = 1; i <= countLineOfConditionCaseFirstOption + 1; i++)
                {
                    Line line = new();
                    TextBox textBox = new();
                    int j = i;
                    if (i == 1)
                    {
                        textBox.Text = initialText;
                        Canvas.SetLeft(textBox, -displacementCoefficient / 2 + DefaultPropertyForBlock.width / 2);
                        Canvas.SetTop(textBox, DefaultPropertyForBlock.height + 20);
                        
                        line.X1 = -displacementCoefficient / 2;
                        line.Y1 = secondLine.Y2;
                        line.X2 = -displacementCoefficient / 2;
                        line.Y2 = line.Y1 + 20;
                        Canvas.SetLeft(line, defaultWidth / 2);
                    }
                    else
                    {
                        line.X1 = -displacementCoefficient / 2 + (DefaultPropertyForBlock.width + 10) * --j;
                        line.Y1 = secondLine.Y2;
                        line.X2 = -displacementCoefficient / 2 + (DefaultPropertyForBlock.width + 10) * j;
                        line.Y2 = line.Y1 + 20;
                        Canvas.SetLeft(line, DefaultPropertyForBlock.width / 2);

                        textBox.Text = initialText;
                        Canvas.SetLeft(textBox, (-displacementCoefficient / 2 + (DefaultPropertyForBlock.width + 10) * j) + DefaultPropertyForBlock.width / 2);
                        Canvas.SetTop(textBox, DefaultPropertyForBlock.height + 20);
                    }
                    line.MouseDown += MouseDown;
                    line.Style = styleLine;
                    textBox.Style = styleTextBox;

                    listLine.Add(line);
                    canvas.Children.Add(line);
                    listTextBox.Add(textBox);
                    canvas.Children.Add(textBox);
                }
                canvas.Children.Add(polygon);
                canvas.Children.Add(firstPointToConnect);
                canvas.Children.Add(secondPointToConnect);
                canvas.Children.Add(thirdPointToConnect);
                canvas.Children.Add(fourthPointToConnect);
                canvas.Children.Add(TextBox);
                canvas.MouseMove += MouseMoveBlockForMovements;
                canvas.MouseRightButtonDown += ClickRightButton;
            }
            return canvas;
        }
        private void ChangeLine()
        {
            double count = (DefaultPropertyForBlock.width + 10) * countLineOfConditionCaseFirstOption;
            int i = 1;
            if (listLine != null)
            {
                foreach (Line line in listLine)
                {
                    if (i == 1)
                    {
                        line.X1 = DefaultPropertyForBlock.width / 2;
                        line.X2 = DefaultPropertyForBlock.width / 2;
                    }
                    else if (i == 2)
                    {
                        line.X1 = -count / 2;
                        line.X2 = count / 2;
                        Canvas.SetLeft(line, DefaultPropertyForBlock.width / 2);
                    }
                    else if (i == 3)
                    {
                        line.X1 = -count / 2;
                        line.X2 = -count / 2;
                        Canvas.SetLeft(line, DefaultPropertyForBlock.width / 2);
                    }
                    else
                    {
                        int j = i - 3;
                        line.X1 = -count / 2 + (DefaultPropertyForBlock.width + 10) * j;
                        line.X2 = -count / 2 + (DefaultPropertyForBlock.width + 10) * j;
                        Canvas.SetLeft(line, DefaultPropertyForBlock.width / 2);
                    }
                    i++;
                }
            }
            if (listTextBox != null)
            {
                int j = 0;
                foreach (TextBox textBox in listTextBox)
                {
                    Canvas.SetLeft(textBox, (-count / 2 + (DefaultPropertyForBlock.width + 10) * j) + DefaultPropertyForBlock.width / 2);
                    j++;
                }
            }
        }
        public override void SetWidth(int valueBlockWidth)
        {
            if (polygon != null)
            {
                Point Point1 = new(0, DefaultPropertyForBlock.height / 2);
                Point Point2 = new(valueBlockWidth / 2, DefaultPropertyForBlock.height);
                Point Point3 = new(valueBlockWidth, DefaultPropertyForBlock.height / 2);
                Point Point4 = new(valueBlockWidth / 2, 0);
                Point Point5 = new(0, DefaultPropertyForBlock.height / 2);
                PointCollection myPointCollection = new();
                myPointCollection.Add(Point1);
                myPointCollection.Add(Point2);
                myPointCollection.Add(Point3);
                myPointCollection.Add(Point4);
                myPointCollection.Add(Point5);
                polygon.Points = myPointCollection;

                double valueForSetLeftTextBoxAndTextBlock = valueBlockWidth / 2 - valueBlockWidth / 4;
                double valueForSetTopTextBoxAndTextBlock = DefaultPropertyForBlock.height / 4;

                SetPropertyForTextBox(valueBlockWidth / 2, DefaultPropertyForBlock.height / 2, valueForSetLeft: valueForSetLeftTextBoxAndTextBlock, valueForSetTop: valueForSetTopTextBoxAndTextBlock);
                SetPropertyForTextBlock(valueBlockWidth / 2, DefaultPropertyForBlock.height / 2, valueForSetLeftTextBoxAndTextBlock, valueForSetTopTextBoxAndTextBlock);

                Canvas.SetLeft(firstPointToConnect, valueBlockWidth / 2 - 3);
                Canvas.SetLeft(secondPointToConnect, 0);
                Canvas.SetLeft(thirdPointToConnect, valueBlockWidth / 2 - 3);
                Canvas.SetLeft(fourthPointToConnect, valueBlockWidth - 6);

                ChangeLine();

                foreach (KeyValuePair<Line, Block> itemLineAndBlock in dictionaryLineAndBlock)
                    Canvas.SetLeft(itemLineAndBlock.Value.GetUIElement(), itemLineAndBlock.Key.X2 - 1);
            }
        }

        public override void SetHeight(int valueBlockHeight)
        {
            if (polygon != null)
            {
                Point Point1 = new(0, valueBlockHeight / 2);
                Point Point2 = new(DefaultPropertyForBlock.width / 2, valueBlockHeight);
                Point Point3 = new(DefaultPropertyForBlock.width, valueBlockHeight / 2);
                Point Point4 = new(DefaultPropertyForBlock.width / 2, 0);
                Point Point5 = new(0, valueBlockHeight / 2);
                PointCollection myPointCollection = new();
                myPointCollection.Add(Point1);
                myPointCollection.Add(Point2);
                myPointCollection.Add(Point3);
                myPointCollection.Add(Point4);
                myPointCollection.Add(Point5);
                polygon.Points = myPointCollection;

                double valueForSetLeftTextBoxAndTextBlock = DefaultPropertyForBlock.width / 2 - DefaultPropertyForBlock.width / 4;
                double valueForSetTopTextBoxAndTextBlock = valueBlockHeight / 4;

                SetPropertyForTextBox(DefaultPropertyForBlock.width / 2, valueBlockHeight / 2, valueForSetLeft: valueForSetLeftTextBoxAndTextBlock, valueForSetTop: valueForSetTopTextBoxAndTextBlock);
                SetPropertyForTextBlock(DefaultPropertyForBlock.width / 2, valueBlockHeight / 2, valueForSetLeftTextBoxAndTextBlock, valueForSetTopTextBoxAndTextBlock);

                Canvas.SetTop(firstPointToConnect, -2);
                Canvas.SetTop(secondPointToConnect, valueBlockHeight / 2 - 3);
                Canvas.SetTop(thirdPointToConnect, valueBlockHeight - 3);
                Canvas.SetTop(fourthPointToConnect, valueBlockHeight / 2 - 3);

                foreach (Line line in listLine)
                    Canvas.SetTop(line, DefaultPropertyForBlock.height - defaulHeight);

                foreach (TextBox textBox in listTextBox)
                    Canvas.SetTop(textBox, DefaultPropertyForBlock.height + 20);

                foreach (KeyValuePair<Line, Block> itemLineAndBlock in dictionaryLineAndBlock)
                    Canvas.SetTop(itemLineAndBlock.Value.GetUIElement(), itemLineAndBlock.Key.Y2 + 1 + DefaultPropertyForBlock.height - defaulHeight);
            }
        }
        private void MouseDown(object sender, RoutedEventArgs e)
        {
            if (StaticBlock.block != null)
            {
                //TODO: Валидация линии, так как сейччас к одной лиинии можно приделать два блока
                //TODO: Неправильно соединятеся с блоком ссылка
                StaticBlock.block.numberOfOccurrencesInBlock--;
                MainWindow.RemoveUIElemet(StaticBlock.block.GetUIElement());
                Canvas.SetLeft(StaticBlock.block.GetUIElement(), ((Line)sender).X2 - 1);
                Canvas.SetTop(StaticBlock.block.GetUIElement(), ((Line)sender).Y2 + 1 + DefaultPropertyForBlock.height - defaulHeight);
                StaticBlock.block.flagCase = true;
                canvas.Children.Remove(StaticBlock.block.GetUIElement());
                canvas.Children.Add(StaticBlock.block.GetUIElement());
                dictionaryLineAndBlock.Add((Line)sender, StaticBlock.block);
                MainWindow.CommectionDone();
                StaticBlock.block = null;
            }
        }
        public override double GetWidthCoefficient() => blockWidthCoefficient;

        public override double GetHeightCoefficient() => blockHeightCoefficient;
    }
}
