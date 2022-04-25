using Flowchart_Editor.Models.Action;
using Flowchart_Editor.Models.Interface;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Flowchart_Editor.Models
{
    public class CycleForBlock : Block
    {
        public Polygon polygonCycleForBlock;
        public TextBox textBoxOfCycleForBlock;
        public TextBlock textBlockOfCycleForBlock;
        public Ellipse firstPointToConnect;
        public Ellipse secondPointToConnect;
        public Ellipse thirdPointToConnect;
        public Ellipse fourthPointToConnect;
        private Line firstLineConnectionBlock;
        private Line secondLineConnectionBlock;
        private Line thirdLineConnectionBlock;
        private Line fourthLineConnectionBlock;
        private Block mainBlock;
        private Block firstBlock;
        private Block secondBlock;
        private Block thirdBlock;
        private Block fourthBlock;
        private object firstSenderMainBlock;
        private object secondSenderMainBlock;
        private object thirdSenderMainBlock;
        private object fourthSenderMainBlock;
        private object senderFirstBlock;
        private object senderSecondBlock;
        private object senderThirdBlock;
        private object senderFourthBlock;
        private int numberOfOccurrencesInBlock = 0;
        private readonly int defaultWidth = DefaultPropertyForBlock.width;
        private readonly int defaulHeight = DefaultPropertyForBlock.height;
        private readonly string defaulColorPoint = DefaultPropertyForBlock.colorPoint;
        private readonly int defaulFontSize = DefaultPropertyForBlock.fontSize;
        private readonly FontFamily defaultFontFamily = DefaultPropertyForBlock.fontFamily;
        private bool textChangeStatus = false;
        private int valueOfClicksOnTextBlock = 0;
        private readonly MainWindow mainWindow;
        private const int radiusPoint = 6;
        private readonly int keyCycleForBlock = 0;
        const string textOfCycleForBlock = "Цикл for";

        public CycleForBlock(MainWindow mainWindow, int keyBlock)
        {
            this.mainWindow = mainWindow;
            keyCycleForBlock = keyBlock;
        }

        private void MouseMoveCycleForBlock(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (textChangeStatus)
                {
                    BlockForMovements instanceOfCycleForBlock = new BlockForMovements(sender, mainBlock, firstBlock, secondBlock, thirdBlock, fourthBlock, firstSenderMainBlock,
                    secondSenderMainBlock, thirdSenderMainBlock, fourthSenderMainBlock, senderFirstBlock, senderSecondBlock,
                    senderThirdBlock, senderFourthBlock, firstLineConnectionBlock, secondLineConnectionBlock, thirdLineConnectionBlock,
                    fourthLineConnectionBlock, numberOfOccurrencesInBlock);
                    var dataObjectInformationOfCycleForBlock = new DataObject(typeof(BlockForMovements), instanceOfCycleForBlock);
                    DragDrop.DoDragDrop(sender as DependencyObject, dataObjectInformationOfCycleForBlock, DragDropEffects.Copy);
                }
            }
            e.Handled = true;
        }

        public UIElement GetUIElement()
        {
            if (canvas == null)
            {
                canvas = new Canvas();
                polygonCycleForBlock = new Polygon();
                textBoxOfCycleForBlock = new TextBox();
                textBlockOfCycleForBlock = new TextBlock(); 
                firstPointToConnect = new Ellipse();
                secondPointToConnect = new Ellipse();
                thirdPointToConnect = new Ellipse();
                fourthPointToConnect = new Ellipse();

                var backgroundColor = new BrushConverter();
                polygonCycleForBlock.Fill = (Brush)backgroundColor.ConvertFrom("#FFFFC618");
                Point Point1 = new(10, 0);
                Point Point2 = new(0, 10);
                Point Point3 = new(0, defaulHeight - 10);
                Point Point4 = new(10, defaulHeight);
                Point Point5 = new(defaultWidth - 10, defaulHeight);
                Point Point6 = new(defaultWidth, defaulHeight - 10);
                Point Point7 = new(defaultWidth, 10);
                Point Point8 = new(defaultWidth - 10, 0);
                PointCollection myPointCollection = new();
                myPointCollection.Add(Point1);
                myPointCollection.Add(Point2);
                myPointCollection.Add(Point3);
                myPointCollection.Add(Point4);
                myPointCollection.Add(Point5);
                myPointCollection.Add(Point6);
                myPointCollection.Add(Point7);
                myPointCollection.Add(Point8);
                polygonCycleForBlock.Points = myPointCollection;
                canvas.Children.Add(polygonCycleForBlock);

                firstPointToConnect.Fill = (Brush)backgroundColor.ConvertFrom(defaulColorPoint);
                firstPointToConnect.Height = radiusPoint;
                firstPointToConnect.Width = radiusPoint;
                Canvas.SetLeft(firstPointToConnect, defaultWidth / 2 - 2);
                Canvas.SetTop(firstPointToConnect, -2);
                firstPointToConnect.MouseDown += GetСoordinatesOfConnectionPoint;

                secondPointToConnect.Fill = (Brush)backgroundColor.ConvertFrom(defaulColorPoint);
                secondPointToConnect.Height = radiusPoint;
                secondPointToConnect.Width = radiusPoint;
                Canvas.SetLeft(secondPointToConnect, -2);
                Canvas.SetTop(secondPointToConnect, defaulHeight / 2 - 2);
                secondPointToConnect.MouseDown += GetСoordinatesOfConnectionPoint;

                thirdPointToConnect.Fill = (Brush)backgroundColor.ConvertFrom(defaulColorPoint);
                thirdPointToConnect.Height = radiusPoint;
                thirdPointToConnect.Width = radiusPoint;
                Canvas.SetLeft(thirdPointToConnect, defaultWidth / 2 - 2);
                Canvas.SetTop(thirdPointToConnect, defaulHeight - 3);
                thirdPointToConnect.MouseDown += GetСoordinatesOfConnectionPoint;

                fourthPointToConnect.Fill = (Brush)backgroundColor.ConvertFrom(defaulColorPoint);
                fourthPointToConnect.Height = radiusPoint;
                fourthPointToConnect.Width = radiusPoint;
                Canvas.SetLeft(fourthPointToConnect, defaultWidth - 4);
                Canvas.SetTop(fourthPointToConnect, defaulHeight / 2 - 2);
                fourthPointToConnect.MouseDown += GetСoordinatesOfConnectionPoint;

                textBoxOfCycleForBlock.Text = textOfCycleForBlock;
                textBoxOfCycleForBlock.Width = defaultWidth;
                textBoxOfCycleForBlock.Height = defaulHeight;
                textBoxOfCycleForBlock.FontSize = defaulFontSize;
                textBoxOfCycleForBlock.FontFamily = defaultFontFamily;
                textBoxOfCycleForBlock.VerticalAlignment = VerticalAlignment.Center;
                textBoxOfCycleForBlock.HorizontalAlignment = HorizontalAlignment.Center;
                textBoxOfCycleForBlock.TextAlignment = TextAlignment.Center;
                textBoxOfCycleForBlock.Foreground = Brushes.White;
                textBoxOfCycleForBlock.TextWrapping = TextWrapping.Wrap;
                textBoxOfCycleForBlock.MouseDoubleClick += ChangeTextBoxToTextBlock;

                textBlockOfCycleForBlock.Text = textOfCycleForBlock;
                textBlockOfCycleForBlock.Width = defaultWidth;
                textBlockOfCycleForBlock.Height = defaulHeight;
                textBlockOfCycleForBlock.FontSize = defaulFontSize;
                textBlockOfCycleForBlock.FontFamily = defaultFontFamily;
                textBlockOfCycleForBlock.VerticalAlignment = VerticalAlignment.Center;
                textBlockOfCycleForBlock.HorizontalAlignment = HorizontalAlignment.Center;
                textBlockOfCycleForBlock.TextAlignment = TextAlignment.Center;
                textBlockOfCycleForBlock.Foreground = Brushes.White;
                textBlockOfCycleForBlock.TextWrapping = TextWrapping.Wrap;
                textBlockOfCycleForBlock.MouseDown += ChangeTextBoxToTextBlock;

                canvas.Children.Add(textBoxOfCycleForBlock);
                canvas.Children.Add(firstPointToConnect);
                canvas.Children.Add(secondPointToConnect);
                canvas.Children.Add(thirdPointToConnect);
                canvas.Children.Add(fourthPointToConnect);
                canvas.MouseMove += MouseMoveCycleForBlock;
            }
            return canvas;
        }
        private void GetСoordinatesOfConnectionPoint(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (CoordinatesBlock.coordinatesBlockPointX == 0 && CoordinatesBlock.coordinatesBlockPointY == 0)
                {
                    CoordinatesBlock.coordinatesBlockPointX = Canvas.GetLeft((Ellipse)sender) + Canvas.GetLeft(canvas) + 3;
                    CoordinatesBlock.coordinatesBlockPointY = Canvas.GetTop((Ellipse)sender) + Canvas.GetTop(canvas) + 3;

                    CoordinatesBlock.keyFirstBlock = keyCycleForBlock;

                    numberOfOccurrencesInBlock++;

                    if (numberOfOccurrencesInBlock == 1)
                    {
                        mainBlock = this;
                        firstSenderMainBlock = sender;
                        StaticBlock.block = this;
                    }
                    if (numberOfOccurrencesInBlock == 2)
                    {
                        StaticBlock.block = this;
                        secondSenderMainBlock = sender;
                    }
                    if (numberOfOccurrencesInBlock == 3)
                    {
                        StaticBlock.block = this;
                        thirdSenderMainBlock = sender;
                    }
                    if (numberOfOccurrencesInBlock == 4)
                    {
                        StaticBlock.block = this;
                        fourthSenderMainBlock = sender;
                    }

                    mainWindow.WriteFirstNameOfBlockToConect(textOfCycleForBlock);
                }
                else
                {
                    double x1 = CoordinatesBlock.coordinatesBlockPointX;
                    double y1 = CoordinatesBlock.coordinatesBlockPointY;

                    double x2 = Canvas.GetLeft((Ellipse)sender) + Canvas.GetLeft(canvas) + 3;
                    double y2 = Canvas.GetTop((Ellipse)sender) + Canvas.GetTop(canvas) + 3;

                    mainWindow.WriteSecondNameOfBlockToConect(textOfCycleForBlock);

                    CoordinatesBlock.keySecondBlock = keyCycleForBlock;

                    numberOfOccurrencesInBlock++;

                    if (numberOfOccurrencesInBlock == 1)
                    {
                        mainBlock = this;
                        firstSenderMainBlock = sender;
                    }
                    if (numberOfOccurrencesInBlock == 2)
                        secondSenderMainBlock = sender;
                    if (numberOfOccurrencesInBlock == 3)
                        thirdSenderMainBlock = sender;
                    if (numberOfOccurrencesInBlock == 4)
                        fourthSenderMainBlock = sender;

                    SavingСontrols savingСontrols = new();

                    if (StaticBlock.block != null)
                    {
                        if (firstLineConnectionBlock == null)
                        {
                            Line? line = mainWindow.DrawConnectionLine(x1, y1, x2, y2);
                            if (line != null)
                            {
                                firstLineConnectionBlock = line;
                                savingСontrols.Save(StaticBlock.block, this, line);
                            }
                            else numberOfOccurrencesInBlock -= 2;
                        }
                        else if (secondLineConnectionBlock == null)
                        {
                            Line? line = mainWindow.DrawConnectionLine(x1, y1, x2, y2);
                            if (line != null)
                            {
                                secondLineConnectionBlock = line;
                                savingСontrols.Save(StaticBlock.block, this, line);
                            }
                            else numberOfOccurrencesInBlock -= 2;
                        }
                        else if (thirdLineConnectionBlock == null)
                        {
                            Line? line = mainWindow.DrawConnectionLine(x1, y1, x2, y2);
                            if (line != null)
                            {
                                thirdLineConnectionBlock = line;
                                savingСontrols.Save(StaticBlock.block, this, line);
                            }
                            else numberOfOccurrencesInBlock -= 2;
                        }
                        else if (fourthLineConnectionBlock == null)
                        {
                            Line? line = mainWindow.DrawConnectionLine(x1, y1, x2, y2);
                            if (line != null)
                            {
                                fourthLineConnectionBlock = line;
                                savingСontrols.Save(StaticBlock.block, this, line);
                            }
                            else numberOfOccurrencesInBlock -= 2;
                        }
                    }
                    CoordinatesBlock.coordinatesBlockPointX = 0;
                    CoordinatesBlock.coordinatesBlockPointY = 0;
                }
            }
        }
        private void ChangeTextBoxToTextBlock(object sender, MouseEventArgs e)
        {
            if (canvas != null && textBoxOfCycleForBlock != null && textBlockOfCycleForBlock != null)
            {
                if (textChangeStatus)
                {
                    valueOfClicksOnTextBlock++;
                    if (valueOfClicksOnTextBlock == 2)
                    {
                        canvas.Children.Remove(textBoxOfCycleForBlock);
                        canvas.Children.Remove(textBlockOfCycleForBlock);
                        textBoxOfCycleForBlock.Text = textBlockOfCycleForBlock.Text;
                        canvas.Children.Add(textBoxOfCycleForBlock);
                        textChangeStatus = false;
                        valueOfClicksOnTextBlock = 0;
                    }
                }
                else
                {
                    canvas.Children.Remove(textBoxOfCycleForBlock);
                    canvas.Children.Remove(textBlockOfCycleForBlock);
                    textBlockOfCycleForBlock.Text = textBoxOfCycleForBlock.Text;
                    Canvas.SetTop(textBlockOfCycleForBlock, 3.5);
                    canvas.Children.Add(textBlockOfCycleForBlock);
                    textChangeStatus = true;
                }
            }
        }

        public void SetWidthAndHeightOfBlock(int valueBlokWidth, int valueBlokHeight)
        {
            if (polygonCycleForBlock != null && canvas != null && 
                textBoxOfCycleForBlock != null && textBlockOfCycleForBlock != null)
            {
                Point Point1 = new(10, 0);
                Point Point2 = new(0, 10);
                Point Point3 = new(0, valueBlokHeight - 10);
                Point Point4 = new(10, valueBlokHeight);
                Point Point5 = new(valueBlokWidth - 10, valueBlokHeight);
                Point Point6 = new(valueBlokWidth, valueBlokHeight - 10);
                Point Point7 = new(valueBlokWidth, 10);
                Point Point8 = new(valueBlokWidth - 10, 0);
                PointCollection myPointCollection = new();
                myPointCollection.Add(Point1);
                myPointCollection.Add(Point2);
                myPointCollection.Add(Point3);
                myPointCollection.Add(Point4);
                myPointCollection.Add(Point5);
                myPointCollection.Add(Point6);
                myPointCollection.Add(Point7);
                myPointCollection.Add(Point8);
                polygonCycleForBlock.Points = myPointCollection;
                canvas.Width = valueBlokWidth;
                textBoxOfCycleForBlock.Width = valueBlokWidth;
                textBlockOfCycleForBlock.Width = valueBlokWidth;
                Canvas.SetLeft(firstPointToConnect, valueBlokWidth / 2 - 2);
                Canvas.SetLeft(thirdPointToConnect, valueBlokWidth / 2 - 2);
                Canvas.SetLeft(fourthPointToConnect, valueBlokWidth - 4);
            }
        }
    }
}