using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using Flowchart_Editor.Models;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Windows.Input;
using Flowchart_Editor.View.Condition.Case;

namespace Flowchart_Editor.View.ConditionCaseFirstOption
{
    public class CaseFirstOption : CaseBlock
    {
        private readonly int defaultWidth = DefaultPropertyForBlock.width;
        private readonly int defaulHeight = DefaultPropertyForBlock.height;
        private readonly Line firstLine = new();


        public CaseFirstOption(Canvas destination, int countLine) : base(destination)
        {
            EditField = destination;
            this.countLine = countLine;
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

                if (Application.LoadComponent(uri) is ResourceDictionary resourceDict)
                {
                    styleLine = resourceDict["LineStyle"] as Style;
                    styleTextBox = resourceDict["TextBoxStyleForCase"] as Style;
                }
                    
                listLine = new List<Line>();
                listTextBox = new List<TextBox>();

                firstLine.X1 = DefaultPropertyForBlock.width / 2;
                firstLine.Y1 = DefaultPropertyForBlock.height;
                firstLine.X2 = DefaultPropertyForBlock.width / 2;
                firstLine.Y2 = DefaultPropertyForBlock.height / 2 + (DefaultPropertyForBlock.height + 10) * countLine;
                firstLine.Style = styleLine;
                FrameBlock.Children.Add(firstLine);

                for (int i = 1; i <= countLine; i++)
                {
                    Line line = new();
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
                    FrameBlock.Children.Add(line);
                    FrameBlock.Children.Add(textBox);
                    listTextBox.Add(textBox);
                }

                //FrameBlock.Children.Add(polygonBlock);
                
                
                
            }
            return FrameBlock;
        }

        public override void SetWidth(int valueBlockWidth)
        {
            //if (polygonBlock != null)
            {
                

                double valueForSetLeftTextBoxAndTextBlock = valueBlockWidth / 2 - valueBlockWidth / 4;
                double valueForSetTopTextBoxAndTextBlock = DefaultPropertyForBlock.height / 4;

                //SetPropertyForTextBox(valueBlockWidth / 2, DefaultPropertyForBlock.height / 2, valueForSetLeft: valueForSetLeftTextBoxAndTextBlock, valueForSetTop: valueForSetTopTextBoxAndTextBlock);
                //SetPropertyForTextBlock(valueBlockWidth / 2, DefaultPropertyForBlock.height / 2, valueForSetLeftTextBoxAndTextBlock, valueForSetTopTextBoxAndTextBlock);

                //Canvas.SetLeft(firstPointConnect, valueBlockWidth / 2 - 3);
                //Canvas.SetLeft(secondPointConnect, 0);
                //Canvas.SetLeft(thirdPointConnect, valueBlockWidth / 2 - 3);
                //Canvas.SetLeft(fourthPointConnect, valueBlockWidth - 6);

                firstLine.X1 = DefaultPropertyForBlock.width / 2;
                firstLine.X2 = DefaultPropertyForBlock.width / 2;
                if (listLine != null)
                {
                    for (int i = 0; i < listLine.Count; i++)
                    {
                        listLine[i].X1 = DefaultPropertyForBlock.width / 2;
                        listLine[i].X2 = DefaultPropertyForBlock.width;
                    }
                }

                if (listTextBox != null)
                    foreach (TextBox textBox in listTextBox)
                        Canvas.SetLeft(textBox, DefaultPropertyForBlock.width / 2);

                
            }
        }

        public override void SetHeight(int valueBlockHeight)
        {
            //if (polygonBlock != null)
            {
                

                double valueForSetLeftTextBoxAndTextBlock = DefaultPropertyForBlock.width / 2 - DefaultPropertyForBlock.width / 4;
                double valueForSetTopTextBoxAndTextBlock = valueBlockHeight / 4;

                //SetPropertyForTextBox(DefaultPropertyForBlock.width / 2, valueBlockHeight / 2, valueForSetLeft: valueForSetLeftTextBoxAndTextBlock, valueForSetTop: valueForSetTopTextBoxAndTextBlock);
                //SetPropertyForTextBlock(DefaultPropertyForBlock.width / 2, valueBlockHeight / 2, valueForSetLeftTextBoxAndTextBlock, valueForSetTopTextBoxAndTextBlock);

                //Canvas.SetTop(firstPointConnect, -2);
                //Canvas.SetTop(secondPointConnect, valueBlockHeight / 2 - 3);
                //Canvas.SetTop(thirdPointConnect, valueBlockHeight - 3);
                //Canvas.SetTop(fourthPointConnect, valueBlockHeight / 2 - 3);

                firstLine.Y1 = DefaultPropertyForBlock.height;
                firstLine.Y2 = DefaultPropertyForBlock.height / 2 + (DefaultPropertyForBlock.height + 10) * countLine;

                if (listLine != null)
                {
                    for (int i = 1; i <= listLine.Count; i++)
                    {
                        listLine[i - 1].Y1 = DefaultPropertyForBlock.height / 2 + i * (DefaultPropertyForBlock.height + 10);
                        listLine[i - 1].Y2 = DefaultPropertyForBlock.height / 2 + i * (DefaultPropertyForBlock.height + 10);
                    }
                }

                if (listTextBox != null)
                    for (int i = 1; i <= listTextBox.Count; i++)
                        Canvas.SetTop(listTextBox[i - 1], (DefaultPropertyForBlock.height / 2 + i * (DefaultPropertyForBlock.height + 10)) - 25);

                
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
                    //if (StaticBlock.block is CaseFirstOption option)
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

        private void ClickRightButtonOnBlock(object sender, MouseEventArgs e)
        {
            if (MessageBox.Show("Вы действиетельно хотите удалить фигуру", "Удаление блока", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                if (FrameBlock != null)
                    FrameBlock.Children.Remove((UIElement)sender);
                //StaticBlock.FlagDeleteBlockOfCase = false;
            }
        }
    }
}