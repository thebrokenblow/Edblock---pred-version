using Flowchart_Editor.Models;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Flowchart_Editor.View.ConditionCaseFirstOption
{
    public class ConditionCaseFirstOptionBlock : ConditionBlock
    {
        private readonly int defaultWidth = DefaultPropertyForBlock.width;
        private readonly int defaulHeight = DefaultPropertyForBlock.height;
        private List<Line>? listLine;
        private List<TextBox>? listTextBox;
        private Style? styleLine;
        private Style? styleTextBox;
        private readonly int countLineOfConditionCaseFirstOption = 0;
        private readonly Dictionary<Line, Block> dictionaryLineAndBlock = new();

        public ConditionCaseFirstOptionBlock(MainWindow mainWindow, int keyBlock, int countLineOfConditionCaseFirstOption) : base(mainWindow, keyBlock)
        {
            MainWindow = mainWindow;
            keyOfBlock = keyBlock;
            this.countLineOfConditionCaseFirstOption = countLineOfConditionCaseFirstOption;
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
                firstPointToConnect.MouseDown += ClickOnFirstConnectionPoint;

                SetPropertyForSecondPointToConnect(0, defaulHeight / 2 - 3);
                secondPointToConnect.MouseDown += ClickOnSecondConnectionPoint;

                SetPropertyForThirdPointToConnect(defaultWidth / 2 - 3, defaulHeight - 3);

                SetPropertyForFourthPointToConnect(defaultWidth - 6, defaulHeight / 2 - 3);
                fourthPointToConnect.MouseDown += ClickOnFourthConnectionPoint;

                if (Application.LoadComponent(uri) is ResourceDictionary resourceDict)
                {
                    styleLine = resourceDict["LineStyle"] as Style;
                    styleTextBox = resourceDict["TextBoxStyleForComment"] as Style;
                }
                    
                listLine = new List<Line>();
                listTextBox = new List<TextBox>();

                Line line = new();
                line.X1 = DefaultPropertyForBlock.width / 2;
                line.Y1 = DefaultPropertyForBlock.height;
                line.X2 = DefaultPropertyForBlock.width / 2;
                line.Y2 = DefaultPropertyForBlock.height / 2 + (DefaultPropertyForBlock.height + 10) * countLineOfConditionCaseFirstOption;
                line.Style = styleLine;
                
                listLine.Add(line);
                canvas.Children.Add(line);
                for (int i = 1; i <= countLineOfConditionCaseFirstOption; i++)
                {
                    line = new();
                    line.X1 = DefaultPropertyForBlock.width / 2;
                    line.Y1 = DefaultPropertyForBlock.height / 2 + i * (DefaultPropertyForBlock.height + 10);
                    line.X2 = DefaultPropertyForBlock.width;
                    line.Y2 = DefaultPropertyForBlock.height / 2 + i * (DefaultPropertyForBlock.height + 10);
                    line.Style = styleLine;
                    line.MouseDown += MouseDown;

                    TextBox textBox = new();
                    textBox.Text = initialText;
                    textBox.Style = styleTextBox;
                    Canvas.SetTop(textBox, (DefaultPropertyForBlock.height / 2 + i * (DefaultPropertyForBlock.height + 10)) - 25);
                    Canvas.SetLeft(textBox, DefaultPropertyForBlock.width / 2);
                    
                    listLine.Add(line);
                    canvas.Children.Add(line);
                    canvas.Children.Add(textBox);
                    listTextBox.Add(textBox);
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

                if (listLine != null)
                {
                    listLine[0].X1 = DefaultPropertyForBlock.width / 2;
                    listLine[0].X2 = DefaultPropertyForBlock.width / 2;

                    for (int i = 1; i < listLine.Count; i++)
                    {
                        listLine[i].X1 = DefaultPropertyForBlock.width / 2;
                        listLine[i].X2 = DefaultPropertyForBlock.width;
                    }
                }

                if (listTextBox != null)
                    foreach (TextBox textBox in listTextBox)
                        Canvas.SetLeft(textBox, DefaultPropertyForBlock.width / 2);

                foreach (KeyValuePair<Line, Block> itemLineAndBlock in dictionaryLineAndBlock)
                    Canvas.SetLeft(itemLineAndBlock.Value.GetUIElement(), DefaultPropertyForBlock.width);
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

                if (listLine != null)
                {
                    listLine[0].Y1 = DefaultPropertyForBlock.height;
                    listLine[0].Y2 = DefaultPropertyForBlock.height / 2 + (DefaultPropertyForBlock.height + 10) * countLineOfConditionCaseFirstOption;
                    for (int i = 1; i < listLine.Count; i++)
                    {
                        listLine[i].Y1 = DefaultPropertyForBlock.height / 2 + i * (DefaultPropertyForBlock.height + 10);
                        listLine[i].Y2 = DefaultPropertyForBlock.height / 2 + i * (DefaultPropertyForBlock.height + 10);
                    }
                }

                if (listTextBox != null)
                    for (int i = 1; i <= listTextBox.Count; i++)
                        Canvas.SetTop(listTextBox[i - 1], (DefaultPropertyForBlock.height / 2 + i * (DefaultPropertyForBlock.height + 10)) - 25);

                foreach (KeyValuePair<Line, Block> itemLineAndBlock in dictionaryLineAndBlock)
                    Canvas.SetTop(itemLineAndBlock.Value.GetUIElement(), itemLineAndBlock.Key.Y2 - DefaultPropertyForBlock.height / 2 - 1);

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
                Canvas.SetTop(StaticBlock.block.GetUIElement(), ((Line)sender).Y2 - DefaultPropertyForBlock.height / 2 - 1);
                StaticBlock.block.flagCase = true;
                canvas.Children.Remove(StaticBlock.block.GetUIElement());
                canvas.Children.Add(StaticBlock.block.GetUIElement());
                dictionaryLineAndBlock.Add((Line)sender, StaticBlock.block);
                MainWindow.CommectionDone();
                StaticBlock.block = null;
            }
        }
    }
}