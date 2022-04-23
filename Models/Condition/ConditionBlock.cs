using Flowchart_Editor.Models.Action;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Flowchart_Editor.Models
{
    public class ConditionBlock : Block
    {
        public Canvas? canvasConditionBlock;
        public Polygon? polygonConditionBlock = null;
        public TextBox textBoxOfConditionBlock;
        public TextBlock textBlocOfConditionBlock;
        public Ellipse? firstPointToConnect = null;
        public Ellipse? secondPointToConnect = null;
        public Ellipse? thirdPointToConnect = null;
        public Ellipse? fourthPointToConnect = null;
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
        private readonly int defaultWidth = DefaultPropertyForBlock.width;
        private readonly int defaulHeight = DefaultPropertyForBlock.height;
        private readonly string defaulColorPoint = DefaultPropertyForBlock.colorPoint;
        private readonly int defaulFontSize = DefaultPropertyForBlock.fontSize;
        private readonly FontFamily defaultFontFamily = DefaultPropertyForBlock.fontFamily;
        private bool textChangeStatus = false;
        private int valueOfClicksOnTextBlock = 0;
        private int numberOfOccurrencesInBlock = 0;
        private readonly MainWindow mainWindow;
        private const int radiusPoint = 6;
        private readonly int keyConditionBlock = 0;
        const string textOfConditionBlock = "Условие";

        public ConditionBlock(MainWindow mainWindow, int keyBlock)
        {
            this.mainWindow = mainWindow;
            keyConditionBlock = keyBlock;
        }

        private void MouseMoveConditionBlock(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (textChangeStatus)
                {
                    BlockForMovements instanceOfConditionBlock = new(sender, mainBlock, firstBlock, secondBlock, thirdBlock, fourthBlock, firstSenderMainBlock,
                    secondSenderMainBlock, thirdSenderMainBlock, fourthSenderMainBlock, senderFirstBlock, senderSecondBlock,
                    senderThirdBlock, senderFourthBlock, firstLineConnectionBlock, secondLineConnectionBlock, thirdLineConnectionBlock,
                    fourthLineConnectionBlock, numberOfOccurrencesInBlock);
                    DataObject dataObjectInformationOConditionBlock = new (typeof(BlockForMovements), instanceOfConditionBlock);
                    DragDrop.DoDragDrop(sender as DependencyObject, dataObjectInformationOConditionBlock, DragDropEffects.Copy);
                }
            }
            e.Handled = true;
        }

        public UIElement GetUIElement()
        {
            if (canvasConditionBlock == null)
            {
                firstPointToConnect = new Ellipse();
                secondPointToConnect = new Ellipse();
                thirdPointToConnect = new Ellipse();
                fourthPointToConnect = new Ellipse();
                canvasConditionBlock = new Canvas();
                polygonConditionBlock = new Polygon();
                textBoxOfConditionBlock = new TextBox();
                textBlocOfConditionBlock = new TextBlock();

                var backgroundColor = new BrushConverter();
                polygonConditionBlock.Fill = (Brush)backgroundColor.ConvertFrom("#FF60B2D3");
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

                polygonConditionBlock.Points = myPointCollection;
                canvasConditionBlock.Children.Add(polygonConditionBlock);

                textBoxOfConditionBlock.Text = textOfConditionBlock;
                textBoxOfConditionBlock.FontSize = defaulFontSize;
                textBoxOfConditionBlock.Width = defaultWidth / 2;
                textBoxOfConditionBlock.Foreground = Brushes.White;
                textBoxOfConditionBlock.FontFamily = defaultFontFamily;
                textBoxOfConditionBlock.HorizontalAlignment = HorizontalAlignment.Center;
                textBoxOfConditionBlock.VerticalAlignment = VerticalAlignment.Center;
                textBoxOfConditionBlock.TextAlignment = TextAlignment.Center;
                textBoxOfConditionBlock.TextWrapping = TextWrapping.Wrap;
                textBoxOfConditionBlock.MouseDoubleClick += ChangeTextBoxToTextBlock;
                Canvas.SetLeft(textBoxOfConditionBlock, defaultWidth / 2 - (defaultWidth / 4));
                Canvas.SetTop(textBoxOfConditionBlock, defaulHeight / 4);

                textBlocOfConditionBlock.FontSize = defaulFontSize;
                textBlocOfConditionBlock.Width = defaultWidth / 2;
                textBlocOfConditionBlock.Foreground = Brushes.White;
                textBlocOfConditionBlock.FontFamily = defaultFontFamily;
                textBlocOfConditionBlock.HorizontalAlignment = HorizontalAlignment.Center;
                textBlocOfConditionBlock.VerticalAlignment = VerticalAlignment.Center;
                textBlocOfConditionBlock.TextAlignment = TextAlignment.Center;
                textBlocOfConditionBlock.TextWrapping = TextWrapping.Wrap;
                textBlocOfConditionBlock.MouseDown += ChangeTextBoxToTextBlock;
                Canvas.SetLeft(textBlocOfConditionBlock, defaultWidth / 2 - (defaultWidth / 4));
                Canvas.SetTop(textBlocOfConditionBlock, defaulHeight / 4);

                firstPointToConnect.Fill = (Brush)backgroundColor.ConvertFrom(defaulColorPoint);
                firstPointToConnect.Height = radiusPoint;
                firstPointToConnect.Width = radiusPoint;
                Canvas.SetLeft(firstPointToConnect, defaultWidth / 2 - 3);
                Canvas.SetTop(firstPointToConnect, -2);
                firstPointToConnect.MouseDown += GetСoordinatesOfConnectionPoint;

                secondPointToConnect.Fill = (Brush)backgroundColor.ConvertFrom(defaulColorPoint);
                secondPointToConnect.Height = radiusPoint;
                secondPointToConnect.Width = radiusPoint;
                Canvas.SetLeft(secondPointToConnect, -2 + 2);
                Canvas.SetTop(secondPointToConnect, defaulHeight / 2 - 3);
                secondPointToConnect.MouseDown += GetСoordinatesOfConnectionPoint;

                thirdPointToConnect.Fill = (Brush)backgroundColor.ConvertFrom(defaulColorPoint);
                thirdPointToConnect.Height = radiusPoint;
                thirdPointToConnect.Width = radiusPoint;
                Canvas.SetLeft(thirdPointToConnect, defaultWidth / 2 - 3);
                Canvas.SetTop(thirdPointToConnect, defaulHeight - 3);
                thirdPointToConnect.MouseDown += GetСoordinatesOfConnectionPoint;

                fourthPointToConnect.Fill = (Brush)backgroundColor.ConvertFrom(defaulColorPoint);
                fourthPointToConnect.Height = radiusPoint;
                fourthPointToConnect.Width = radiusPoint;
                Canvas.SetLeft(fourthPointToConnect, defaultWidth - 6);
                Canvas.SetTop(fourthPointToConnect, defaulHeight / 2 - 3);
                fourthPointToConnect.MouseDown += GetСoordinatesOfConnectionPoint;

                canvasConditionBlock.Children.Add(textBoxOfConditionBlock);
                canvasConditionBlock.Children.Add(firstPointToConnect);
                canvasConditionBlock.Children.Add(secondPointToConnect);
                canvasConditionBlock.Children.Add(thirdPointToConnect);
                canvasConditionBlock.Children.Add(fourthPointToConnect);
                canvasConditionBlock.MouseMove += MouseMoveConditionBlock;
            }
            return canvasConditionBlock;
        }
        private void GetСoordinatesOfConnectionPoint(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (CoordinatesBlock.coordinatesBlockPointX == 0 && CoordinatesBlock.coordinatesBlockPointY == 0)
                {
                    CoordinatesBlock.coordinatesBlockPointX = Canvas.GetLeft((Ellipse)sender) + Canvas.GetLeft(canvasConditionBlock) + 3;
                    CoordinatesBlock.coordinatesBlockPointY = Canvas.GetTop((Ellipse)sender) + Canvas.GetTop(canvasConditionBlock) + 3;

                    CoordinatesBlock.keyFirstBlock = keyConditionBlock;
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
                    mainWindow.WriteFirstNameOfBlockToConect(textOfConditionBlock);

                }
                else
                {
                    double x1 = CoordinatesBlock.coordinatesBlockPointX;
                    double y1 = CoordinatesBlock.coordinatesBlockPointY;

                    double x2 = Canvas.GetLeft((Ellipse)sender) + Canvas.GetLeft(canvasConditionBlock) + 3;
                    double y2 = Canvas.GetTop((Ellipse)sender) + Canvas.GetTop(canvasConditionBlock) + 3;

                    mainWindow.WriteSecondNameOfBlockToConect(textOfConditionBlock);

                    CoordinatesBlock.keySecondBlock = keyConditionBlock;

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
            if (canvasConditionBlock != null && textBoxOfConditionBlock != null && textBlocOfConditionBlock != null)
            {
                if (textChangeStatus)
                {
                    valueOfClicksOnTextBlock++;
                    if (valueOfClicksOnTextBlock == 2)
                    {
                        canvasConditionBlock.Children.Remove(textBoxOfConditionBlock);
                        canvasConditionBlock.Children.Remove(textBlocOfConditionBlock);
                        textBoxOfConditionBlock.Text = textBlocOfConditionBlock.Text;
                        canvasConditionBlock.Children.Add(textBoxOfConditionBlock);

                        textChangeStatus = false;
                        valueOfClicksOnTextBlock = 0;
                    }
                }
                else
                {
                    canvasConditionBlock.Children.Remove(textBoxOfConditionBlock);
                    canvasConditionBlock.Children.Remove(textBlocOfConditionBlock);
                    textBlocOfConditionBlock.Text = textBoxOfConditionBlock.Text;
                    canvasConditionBlock.Children.Add(textBlocOfConditionBlock);
                    textChangeStatus = true;
                }
            }
        }

        public void SetWidthAndHeightOfBlock(int valueBlokWidth, int valueBlokHeight)
        {
            if (polygonConditionBlock != null && textBoxOfConditionBlock != null && textBlocOfConditionBlock != null)
            {
                Point Point1 = new(0, valueBlokHeight / 2);
                Point Point2 = new(valueBlokWidth / 2, valueBlokHeight);
                Point Point3 = new(valueBlokWidth, valueBlokHeight / 2);
                Point Point4 = new(valueBlokWidth / 2, 0);
                Point Point5 = new(0, valueBlokHeight / 2);
                PointCollection myPointCollection = new();
                myPointCollection.Add(Point1);
                myPointCollection.Add(Point2);
                myPointCollection.Add(Point3);
                myPointCollection.Add(Point4);
                myPointCollection.Add(Point5);
                polygonConditionBlock.Points = myPointCollection;
                textBoxOfConditionBlock.Width = valueBlokWidth / 2;
                textBlocOfConditionBlock.Width = valueBlokWidth / 2;
                Canvas.SetLeft(textBlocOfConditionBlock, valueBlokWidth / 2 - (valueBlokWidth / 4));
                Canvas.SetLeft(textBoxOfConditionBlock, valueBlokWidth / 2 - (valueBlokWidth / 4));
                Canvas.SetLeft(firstPointToConnect, valueBlokWidth / 2 - 3);
                Canvas.SetLeft(secondPointToConnect, 0);
                Canvas.SetLeft(thirdPointToConnect, valueBlokWidth / 2 - 3);
                Canvas.SetLeft(fourthPointToConnect, valueBlokWidth - 6);
            }
        }
    }
}