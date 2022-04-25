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
        public Polygon? polygonConditionBlock = null;
        private readonly int defaultWidth = DefaultPropertyForBlock.width;
        private readonly int defaulHeight = DefaultPropertyForBlock.height;
        private readonly MainWindow mainWindow;
        private readonly int keyConditionBlock = 0;
        const string textOfConditionBlock = "Условие";

        public ConditionBlock(MainWindow mainWindow, int keyBlock)
        {
            this.mainWindow = mainWindow;
            keyConditionBlock = keyBlock;
        }

        public UIElement GetUIElement()
        {
            if (canvas == null)
            {
                firstPointToConnect = new Ellipse();
                secondPointToConnect = new Ellipse();
                thirdPointToConnect = new Ellipse();
                fourthPointToConnect = new Ellipse();
                canvas = new Canvas();
                polygonConditionBlock = new Polygon();
                textBox = new TextBox();
                textBlock = new TextBlock();

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

                SetPropertyForTextBox(defaultWidth / 2, defaulHeight, textOfConditionBlock);
                Canvas.SetLeft(textBox, defaultWidth / 2 - (defaultWidth / 4));
                Canvas.SetTop(textBox, defaulHeight / 4);

                SetPropertyForTextBlock(defaultWidth / 2, defaulHeight);
                Canvas.SetLeft(textBlock, defaultWidth / 2 - (defaultWidth / 4));
                Canvas.SetTop(textBlock, defaulHeight / 4);

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

                canvas.Children.Add(textBox);
                canvas.Children.Add(polygonConditionBlock);
                canvas.Children.Add(firstPointToConnect);
                canvas.Children.Add(secondPointToConnect);
                canvas.Children.Add(thirdPointToConnect);
                canvas.Children.Add(fourthPointToConnect);
                canvas.MouseMove += MouseMoveBlockForMovements;
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

                    double x2 = Canvas.GetLeft((Ellipse)sender) + Canvas.GetLeft(canvas) + 3;
                    double y2 = Canvas.GetTop((Ellipse)sender) + Canvas.GetTop(canvas) + 3;

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

        public void SetWidthAndHeightOfBlock(int valueBlokWidth, int valueBlokHeight)
        {
            if (polygonConditionBlock != null && textBox != null && textBlock != null)
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
                textBox.Width = valueBlokWidth / 2;
                textBlock.Width = valueBlokWidth / 2;
                Canvas.SetLeft(textBlock, valueBlokWidth / 2 - (valueBlokWidth / 4));
                Canvas.SetLeft(textBox, valueBlokWidth / 2 - (valueBlokWidth / 4));
                Canvas.SetLeft(firstPointToConnect, valueBlokWidth / 2 - 3);
                Canvas.SetLeft(secondPointToConnect, 0);
                Canvas.SetLeft(thirdPointToConnect, valueBlokWidth / 2 - 3);
                Canvas.SetLeft(fourthPointToConnect, valueBlokWidth - 6);
            }
        }
    }
}