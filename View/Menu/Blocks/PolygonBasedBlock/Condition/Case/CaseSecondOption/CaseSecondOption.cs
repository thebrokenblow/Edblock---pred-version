using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using Flowchart_Editor.Models;
using System.Windows.Controls;
using System.Collections.Generic;
using Flowchart_Editor.View.Condition.Case;

namespace Flowchart_Editor.View.ConditionCaseSecondOption
{
    [BlockName("ConditionCaseSecondOptionBlock")]
    public class CaseSecondOption : CaseBlock
    {
        private readonly int defaultWidth = DefaultPropertyForBlock.width;
        private readonly int defaulHeight = DefaultPropertyForBlock.height;
        int countOfHeight = DefaultPropertyForBlock.height;
        public readonly Line firstLine = new();
        public readonly Line secondLine = new();
        public CaseSecondOption(Canvas destination, int countLine)
        {
            EditField = destination;
            this.countLine = --countLine;
            initialText = "Условие";
        }
        override public UIElement GetUIElement()
        {
            if (FrameBlock == null)
            {
                FrameBlock = new Canvas();
                //polygonBlock = new Polygon();
                TextBoxOfBlock = new TextBox();
                TextBlockOfBlock = new TextBlock();
                

                FrameBlock.Width = defaultWidth;
                FrameBlock.Height = defaulHeight;

                BrushConverter brushConverter = new();
                Brush backgroundColor = (Brush)brushConverter.ConvertFrom("#FF60B2D3");

                //polygonBlock.Fill = backgroundColor;
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
                //polygonBlock.Points = myPointCollection;

                double valueForSetLeftTextBoxAndTextBlock = defaultWidth / 2 - defaultWidth / 4;
                double valueForSetTopTextBoxAndTextBlock = defaulHeight / 4;

                //SetPropertyForTextBox(defaultWidth / 2, defaulHeight / 2, initialText, valueForSetLeftTextBoxAndTextBlock, valueForSetTopTextBoxAndTextBlock);
                
                //SetPropertyForTextBlock(defaultWidth / 2, defaulHeight / 2, valueForSetLeftTextBoxAndTextBlock, valueForSetTopTextBoxAndTextBlock);

                //SetPropertyPointConnect(firstPointToConnect, defaultWidth / 2 - 3, -2);
                //firstPointToConnect.MouseDown += ClickOnFirstConnectionPoint;

                //SetPropertyPointConnect(secondPointToConnect, 0, defaulHeight / 2 - 3);
                //secondPointToConnect.MouseDown += ClickOnSecondConnectionPoint;

                //SetPropertyPointConnect(thirdPointToConnect, defaultWidth / 2 - 3, defaulHeight - 3);

                //SetPropertyPointConnect(fourthPointToConnect, defaultWidth - 6, defaulHeight / 2 - 3);
                //fourthPointToConnect.MouseDown += ClickOnFourthConnectionPoint;

                listLine = new List<Line>();
                listTextBox = new List<TextBox>();

                if (Application.LoadComponent(uri) is ResourceDictionary resourceDict)
                {
                    styleLine = resourceDict["LineStyle"] as Style;
                    styleTextBox = resourceDict["TextBoxStyleForCase"] as Style;
                }

                firstLine.X1 = DefaultPropertyForBlock.width / 2;
                firstLine.Y1 = DefaultPropertyForBlock.height;
                firstLine.X2 = DefaultPropertyForBlock.width / 2;
                firstLine.Y2 = firstLine.Y1 + 20;
                firstLine.Style = styleLine;
                FrameBlock.Children.Add(firstLine);
              
                double displacementCoefficient = (DefaultPropertyForBlock.width + 10) * countLine;

                secondLine.X1 = -displacementCoefficient / 2;
                secondLine.Y1 = firstLine.Y2;
                secondLine.X2 = displacementCoefficient / 2;
                secondLine.Y2 = secondLine.Y1;
                secondLine.Style = styleLine;
                Canvas.SetLeft(secondLine, DefaultPropertyForBlock.width / 2); 
                FrameBlock.Children.Add(secondLine);

                for (int i = 1; i <= countLine + 1; i++)
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
                    FrameBlock.Children.Add(line);
                    listTextBox.Add(textBox);
                    FrameBlock.Children.Add(textBox);
                }
                //FrameBlock.Children.Add(polygonBlock);
                
                
            }
            return FrameBlock;
        }

        private void ClickRightButtonOnBlock(object sender, MouseEventArgs e)
        {
            if (MessageBox.Show("Вы действиетельно хотите удалить фигуру", "Удаление блока", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                if (FrameBlock != null)
                    FrameBlock.Children.Remove((UIElement)sender);
                //StaticBlock.FlagDeleteBlockOfCase = false;
            }
        }
        
        private void ChangeLine()
        {
            double count = (DefaultPropertyForBlock.width + 10) * countLine;
            int i = 1;

            firstLine.X1 = DefaultPropertyForBlock.width / 2;
            firstLine.X2 = DefaultPropertyForBlock.width / 2;

            secondLine.X1 = -count / 2;
            secondLine.X2 = count / 2;

            Canvas.SetLeft(secondLine, DefaultPropertyForBlock.width / 2);
            if (listLine != null)
            {
                foreach (Line line in listLine)
                {
                    if (i == 1)
                    {
                        line.X1 = -count / 2;
                        line.X2 = -count / 2;
                        Canvas.SetLeft(line, DefaultPropertyForBlock.width / 2);
                    }
                    else
                    {
                        int j = i - 1;
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
            //if (polygonBlock != null)
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
                //polygonBlock.Points = myPointCollection;

                double valueForSetLeftTextBoxAndTextBlock = valueBlockWidth / 2 - valueBlockWidth / 4;
                double valueForSetTopTextBoxAndTextBlock = DefaultPropertyForBlock.height / 4;

                //SetPropertyForTextBox(valueBlockWidth / 2, DefaultPropertyForBlock.height / 2, valueForSetLeft: valueForSetLeftTextBoxAndTextBlock, valueForSetTop: valueForSetTopTextBoxAndTextBlock);
                //SetPropertyForTextBlock(valueBlockWidth / 2, DefaultPropertyForBlock.height / 2, valueForSetLeftTextBoxAndTextBlock, valueForSetTopTextBoxAndTextBlock);

                //Canvas.SetLeft(firstPointConnect, valueBlockWidth / 2 - 3);
                //Canvas.SetLeft(secondPointConnect, 0);
                //Canvas.SetLeft(thirdPointConnect, valueBlockWidth / 2 - 3);
                //Canvas.SetLeft(fourthPointConnect, valueBlockWidth - 6);

                ChangeLine();

                
            }
        }

        public override void SetHeight(int valueBlockHeight)
        {
            //if (polygonBlock != null)
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
                //polygonBlock.Points = myPointCollection;

                double valueForSetLeftTextBoxAndTextBlock = DefaultPropertyForBlock.width / 2 - DefaultPropertyForBlock.width / 4;
                double valueForSetTopTextBoxAndTextBlock = valueBlockHeight / 4;

                //SetPropertyForTextBox(DefaultPropertyForBlock.width / 2, valueBlockHeight / 2, valueForSetLeft: valueForSetLeftTextBoxAndTextBlock, valueForSetTop: valueForSetTopTextBoxAndTextBlock);
                //SetPropertyForTextBlock(DefaultPropertyForBlock.width / 2, valueBlockHeight / 2, valueForSetLeftTextBoxAndTextBlock, valueForSetTopTextBoxAndTextBlock);

                //Canvas.SetTop(firstPointConnect, -2);
                //Canvas.SetTop(secondPointConnect, valueBlockHeight / 2 - 3);
                //Canvas.SetTop(thirdPointConnect, valueBlockHeight - 3);
                //Canvas.SetTop(fourthPointConnect, valueBlockHeight / 2 - 3);

                Canvas.SetTop(firstLine, DefaultPropertyForBlock.height - defaulHeight);
                Canvas.SetTop(secondLine, DefaultPropertyForBlock.height - defaulHeight);
     
                if (listLine != null)
                {
                    foreach (Line line in listLine)
                    {
                        line.Y1 += DefaultPropertyForBlock.height - countOfHeight;
                        line.Y2 += DefaultPropertyForBlock.height - countOfHeight;

                    }
                }
                countOfHeight = DefaultPropertyForBlock.height;

                if (listTextBox != null)
                    foreach (TextBox textBox in listTextBox)
                        Canvas.SetTop(textBox, DefaultPropertyForBlock.height + 20);

                foreach (KeyValuePair<Line, Block> itemLineAndBlock in dictionaryLineAndBlock)
                {
                    itemLineAndBlock.Value.SetHeight(valueBlockHeight);
                    Canvas.SetTop(itemLineAndBlock.Value.GetUIElement(), itemLineAndBlock.Key.Y2);
                }
            }
        }

        

        private void MouseDown(object sender, RoutedEventArgs e)
        {
            //if (StaticBlock.Block != null && FrameBlock != null)
            {
                //TODO: Неправильно соединятеся с блоком ссылка
                double coordinateLeft = ((Line)sender).X2;
                double coordinateTop = ((Line)sender).Y2;
                try
                {
                    //if (StaticBlock.block is CaseSecondOption option)
                    //    Edblock.RemoveItemFromListCaseBlock(option);

                    //dictionaryLineAndBlock.Add((Line)sender, StaticBlock.Block);
                    //UIElement uIElementBlock = StaticBlock.Block.GetUIElement();
                    
                    
                    //MainWindow.RemoveBlockFormList(StaticBlock.block);
                    //StaticBlock.Block.GetUIElement().MouseRightButtonDown += ClickRightButtonOnBlock;
                    
                    //if (EditField != null)
                    //    EditField.Children.Remove(uIElementBlock);
                    
                    //FrameBlock.Children.Remove(uIElementBlock);
                    //FrameBlock.Children.Add(uIElementBlock);
                    //MainWindow.WriteSecondNameOfBlockToConect(initialText);
                    //StaticBlock.Block = null;
                }
                catch
                {
                    //MainWindow.MessageThisLineIsAlreadyOccupied();
                }
            }
        }

       
    }
}