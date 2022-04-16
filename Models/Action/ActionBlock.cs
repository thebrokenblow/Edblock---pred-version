﻿using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Controls;
using Flowchart_Editor.Models.Action;

namespace Flowchart_Editor.Models
{
    public class ActionBlock : Window
    {
        private Canvas? canvasOfActionBlock;
        private TextBox? textBoxOfActionBlock = null;
        private TextBlock? textBlockOfActionBlock = null;
        private Ellipse? firstPointToConnect = null;
        private Ellipse? secondPointToConnect = null;
        private Ellipse? thirdPointToConnect = null;
        private Ellipse? fourthPointToConnect = null;
        private bool textChangeStatus = false;
        private int defaultWidth = DefaultPropertyForBlock.width;
        private int defaulHeight = DefaultPropertyForBlock.height;
        private string defaulColorPoint = DefaultPropertyForBlock.colorPoint;
        private int defaulFontSize = DefaultPropertyForBlock.fontSize;
        private FontFamily defaultFontFamily = DefaultPropertyForBlock.fontFamily;
        private int valueOfClicksOnTextBlock = 0;
        private bool joiningFourthConnectionPoint = false;
        private MainWindow mainWindow;
        private const int radiusPoint = 6;
        private int keyOfActionBlock = 0;
        private const string textOfActionBlock = "Действие";

        public Line firstLineConnectionBlock;
        public Line secondLineConnectionBlock;
        public Line thirdLineConnectionBlock;
        public Line fourthLineConnectionBlock;

        public ActionBlock mainActionBlock;
        public ActionBlock firstActionBlock;
        public ActionBlock secondActionBlock;
        public ActionBlock thirdActionBlock;
        public ActionBlock fourthActionBlock;

        public object firstSenderMainActionBlock;
        public object secondSenderMainActionBlock;
        public object thirdSenderMainActionBlock;
        public object fourthSenderMainActionBlock;

        public object senderFirstActionBlock;
        public object senderSecondActionBlock;
        public object senderThirdActionBlock;
        public object senderFourthActionBlock;

        public int numberOfOccurrencesInBlock = 0;
        public ActionBlock(MainWindow mainWindow, int keyBlock)
        {
            this.mainWindow = mainWindow;
            keyOfActionBlock = keyBlock;
        }

        public UIElement? GetUIElementWithoutCreate() => canvasOfActionBlock;

        public Canvas? GetCanvas() => canvasOfActionBlock;


        private void actionBlockForMovements_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && textChangeStatus)
            {
                ActionBlockForMovements instanceOfActionBlockForMovements = new ActionBlockForMovements(sender);

                instanceOfActionBlockForMovements.mainActionBlock = mainActionBlock;
                instanceOfActionBlockForMovements.firstActionBlock = firstActionBlock;
                instanceOfActionBlockForMovements.secondActionBlock = secondActionBlock;
                instanceOfActionBlockForMovements.thirdActionBlock = thirdActionBlock;
                instanceOfActionBlockForMovements.fourthActionBlock = fourthActionBlock;

                instanceOfActionBlockForMovements.firstSenderMainActionBlock = firstSenderMainActionBlock;
                instanceOfActionBlockForMovements.secondSenderMainActionBlock = secondSenderMainActionBlock;
                instanceOfActionBlockForMovements.thirdSenderMainActionBlock = thirdSenderMainActionBlock;
                instanceOfActionBlockForMovements.fourthSenderMainActionBlock = fourthSenderMainActionBlock;

                instanceOfActionBlockForMovements.senderFirstdActionBlock = senderFirstActionBlock;
                instanceOfActionBlockForMovements.senderSecondActionBlock = senderSecondActionBlock;
                instanceOfActionBlockForMovements.senderThirdActionBlock = senderThirdActionBlock;
                instanceOfActionBlockForMovements.senderFourthActionBlock = senderFourthActionBlock;

                instanceOfActionBlockForMovements.firstLineConnectionBlock = firstLineConnectionBlock;
                instanceOfActionBlockForMovements.secondLineConnectionBlock = secondLineConnectionBlock;
                instanceOfActionBlockForMovements.thirdLineConnectionBlock = thirdLineConnectionBlock;
                instanceOfActionBlockForMovements.fourthLineConnectionBlock = fourthLineConnectionBlock;

                instanceOfActionBlockForMovements.numberOfOccurrencesInBlock = numberOfOccurrencesInBlock;

                var dataObjectInformationOfActionBlock = new DataObject(typeof(ActionBlockForMovements), instanceOfActionBlockForMovements);
                DragDrop.DoDragDrop(sender as DependencyObject, dataObjectInformationOfActionBlock, DragDropEffects.Copy);
            }
            e.Handled = true;
        }

        public UIElement GetUIElement()
        {
            if (canvasOfActionBlock == null)
            {
                canvasOfActionBlock = new Canvas();
                textBoxOfActionBlock = new TextBox();
                textBlockOfActionBlock = new TextBlock();
                firstPointToConnect = new Ellipse();
                secondPointToConnect = new Ellipse();
                thirdPointToConnect = new Ellipse();
                fourthPointToConnect = new Ellipse();

                textBoxOfActionBlock.Text = textOfActionBlock;
                textBoxOfActionBlock.Width = defaultWidth;
                textBoxOfActionBlock.Height = defaulHeight;
                textBoxOfActionBlock.FontSize = defaulFontSize;
                textBoxOfActionBlock.FontFamily = defaultFontFamily;
                textBoxOfActionBlock.VerticalAlignment = VerticalAlignment.Center;
                textBoxOfActionBlock.HorizontalAlignment = HorizontalAlignment.Center;
                textBoxOfActionBlock.TextAlignment = TextAlignment.Center;
                textBoxOfActionBlock.Foreground = Brushes.White;
                textBoxOfActionBlock.TextWrapping = TextWrapping.Wrap;
                textBoxOfActionBlock.MouseDoubleClick += ChangeTextBoxToLabel;

                textBlockOfActionBlock.Width = defaultWidth;
                textBlockOfActionBlock.Height = defaulHeight;
                textBlockOfActionBlock.FontSize = defaulFontSize;
                textBlockOfActionBlock.FontFamily = defaultFontFamily;
                textBlockOfActionBlock.VerticalAlignment = VerticalAlignment.Center;
                textBlockOfActionBlock.HorizontalAlignment = HorizontalAlignment.Center;
                textBlockOfActionBlock.TextAlignment = TextAlignment.Center;
                textBlockOfActionBlock.Foreground = Brushes.White;
                textBlockOfActionBlock.TextWrapping = TextWrapping.Wrap;
                textBlockOfActionBlock.MouseDown += ChangeTextBoxToLabel;

                var backgroundColor = new BrushConverter();
                canvasOfActionBlock.Background = (Brush)backgroundColor.ConvertFrom("#FF52C0AA");
                canvasOfActionBlock.Width = defaultWidth;
                canvasOfActionBlock.Height = defaulHeight;

                firstPointToConnect.Fill = (Brush)backgroundColor.ConvertFrom(defaulColorPoint); 
                firstPointToConnect.Height = radiusPoint;
                firstPointToConnect.Width = radiusPoint;
                Canvas.SetLeft(firstPointToConnect, defaultWidth / 2 - 2);
                Canvas.SetTop(firstPointToConnect,  -2);
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
                Canvas.SetTop(fourthPointToConnect, defaulHeight / 2 -2);
                fourthPointToConnect.MouseDown += AttachСommentGetСoordinatesOfConnectionPoint;

                canvasOfActionBlock.Children.Add(textBoxOfActionBlock);
                canvasOfActionBlock.Children.Add(firstPointToConnect);
                canvasOfActionBlock.Children.Add(secondPointToConnect);
                canvasOfActionBlock.Children.Add(thirdPointToConnect);
                canvasOfActionBlock.Children.Add(fourthPointToConnect);
                canvasOfActionBlock.MouseMove += actionBlockForMovements_MouseMove;
            }
            return canvasOfActionBlock;
        }

        private void AttachСommentGetСoordinatesOfConnectionPoint(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (PinningComment.flagPinningComment && PinningComment.comment != null && !joiningFourthConnectionPoint && canvasOfActionBlock != null)
                {
                    UIElement commentUIElement = PinningComment.comment.GetUIElement();
                    canvasOfActionBlock.Children.Add(commentUIElement);
                    Canvas.SetTop(commentUIElement, defaulHeight / 2 + 1);
                    Canvas.SetLeft(commentUIElement, defaultWidth + 1);
                    mainWindow.WriteFirstNameOfBlockToConect("");
                    PinningComment.flagPinningComment = false;
                    PinningComment.comment = null;
                    joiningFourthConnectionPoint = true;
                }
                else
                {
                    if (!joiningFourthConnectionPoint)
                        GetСoordinatesOfConnectionPoint(sender, e);
                }
            }
        }
        private void GetСoordinatesOfConnectionPoint(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (CoordinatesBlock.coordinatesBlockPointX == 0 && CoordinatesBlock.coordinatesBlockPointY == 0)
                {
                    CoordinatesBlock.coordinatesBlockPointX = Canvas.GetLeft((Ellipse)sender) + Canvas.GetLeft(canvasOfActionBlock) + 3;
                    CoordinatesBlock.coordinatesBlockPointY = Canvas.GetTop((Ellipse)sender) + Canvas.GetTop(canvasOfActionBlock) + 3;

                    joiningFourthConnectionPoint = true;

                    numberOfOccurrencesInBlock++;

                    CoordinatesBlock.keyFirstBlock = keyOfActionBlock;

                    if (numberOfOccurrencesInBlock == 1)
                    {
                        mainActionBlock = this;
                        firstSenderMainActionBlock = sender;
                        StaticActionBlock.actionBlock = this;
                    }
                    if (numberOfOccurrencesInBlock == 2)
                    {
                        StaticActionBlock.actionBlock = this;
                        secondSenderMainActionBlock = sender;
                    }
                    if (numberOfOccurrencesInBlock == 3)
                    {
                        StaticActionBlock.actionBlock = this;
                        thirdSenderMainActionBlock = sender;
                    }
                    if (numberOfOccurrencesInBlock == 4)
                    {
                        StaticActionBlock.actionBlock = this;
                        fourthSenderMainActionBlock = sender;
                    }

                    mainWindow.WriteFirstNameOfBlockToConect(textOfActionBlock);
                }
                else
                {
                    double x1 = CoordinatesBlock.coordinatesBlockPointX;
                    double y1 = CoordinatesBlock.coordinatesBlockPointY;

                    double x2 = Canvas.GetLeft((Ellipse)sender) + Canvas.GetLeft(canvasOfActionBlock) + 3;
                    double y2 = Canvas.GetTop((Ellipse)sender) + Canvas.GetTop(canvasOfActionBlock) + 3;

                    CoordinatesBlock.keySecondBlock = keyOfActionBlock;

                    mainWindow.WriteSecondNameOfBlockToConect(textOfActionBlock);

                    numberOfOccurrencesInBlock++;

                    joiningFourthConnectionPoint = true;

                    if (numberOfOccurrencesInBlock == 1)
                    {
                        mainActionBlock = this;
                        firstSenderMainActionBlock = sender;
                    }
                    if (numberOfOccurrencesInBlock == 2)
                        secondSenderMainActionBlock = sender;
                    if (numberOfOccurrencesInBlock == 3)
                        thirdSenderMainActionBlock = sender;
                    if (numberOfOccurrencesInBlock == 4)
                        fourthSenderMainActionBlock = sender;


                    if (firstLineConnectionBlock == null && StaticActionBlock.actionBlock != null)
                    {
                        Line? line = mainWindow.DrawConnectionLine(x1, y1, x2, y2, StaticActionBlock.actionBlock, this);
                        if (line != null)
                            firstLineConnectionBlock = line;
                    }
                    else if (secondLineConnectionBlock == null)
                        secondLineConnectionBlock = mainWindow.DrawConnectionLine(x1, y1, x2, y2, StaticActionBlock.actionBlock, this);
                    else if (thirdLineConnectionBlock == null)
                        thirdLineConnectionBlock = mainWindow.DrawConnectionLine(x1, y1, x2, y2, StaticActionBlock.actionBlock, this);
                    else if (fourthLineConnectionBlock == null)
                        fourthLineConnectionBlock = mainWindow.DrawConnectionLine(x1, y1, x2, y2, StaticActionBlock.actionBlock, this);
                        
                    CoordinatesBlock.coordinatesBlockPointX = 0;
                    CoordinatesBlock.coordinatesBlockPointY = 0;
                }
            }
        }
        
        private void ChangeTextBoxToLabel(object sender, MouseEventArgs e)
        {
            if (canvasOfActionBlock != null && textBoxOfActionBlock != null && textBlockOfActionBlock != null)
            {
                if (textChangeStatus)
                {
                    valueOfClicksOnTextBlock++;
                    if (valueOfClicksOnTextBlock == 2)
                    {
                        canvasOfActionBlock.Children.Remove(textBoxOfActionBlock);
                        canvasOfActionBlock.Children.Remove(textBlockOfActionBlock);
                        textBoxOfActionBlock.Text = textBlockOfActionBlock.Text;
                        canvasOfActionBlock.Children.Add(textBoxOfActionBlock);
                        textChangeStatus = false;
                        valueOfClicksOnTextBlock = 0;
                    }
                }
                else
                {
                    canvasOfActionBlock.Children.Remove(textBoxOfActionBlock);
                    canvasOfActionBlock.Children.Remove(textBlockOfActionBlock);
                    textBlockOfActionBlock.Text = textBoxOfActionBlock.Text;
                    Canvas.SetTop(textBlockOfActionBlock, 3.5);
                    canvasOfActionBlock.Children.Add(textBlockOfActionBlock);
                    textChangeStatus = true;
                }
            }
        }

        public void Reset()
        {
            canvasOfActionBlock = null;
        }

        public void SetFillOfPointToConnect(string darkWhite)
        {
            BrushConverter color = new BrushConverter();
            if (firstPointToConnect != null && secondPointToConnect != null && thirdPointToConnect != null && fourthPointToConnect != null)
            {
                firstPointToConnect.Fill = (Brush)color.ConvertFrom(darkWhite);
                secondPointToConnect.Fill = (Brush)color.ConvertFrom(darkWhite);
                thirdPointToConnect.Fill = (Brush)color.ConvertFrom(darkWhite);
                fourthPointToConnect.Fill = (Brush)color.ConvertFrom(darkWhite);
            }
        }

        public void SetFontFamily(FontFamily fontFamily)
        {
            if (textBoxOfActionBlock != null && textBlockOfActionBlock != null)
            {
                textBoxOfActionBlock.FontFamily = fontFamily;
                textBlockOfActionBlock.FontFamily = fontFamily;
            }
        }

        public void SetFontSize(int valueFontSize)
        {
            if (textBoxOfActionBlock != null && textBlockOfActionBlock != null)
            {
                textBoxOfActionBlock.FontSize = valueFontSize;
                textBlockOfActionBlock.FontSize = valueFontSize;
            }
        }

        public void SetWidthOfBlock(int valueBlokWidth)
        {
            if (canvasOfActionBlock != null && textBoxOfActionBlock != null && textBlockOfActionBlock != null)
            {
                canvasOfActionBlock.Width = valueBlokWidth;
                textBoxOfActionBlock.Width = valueBlokWidth;
                textBlockOfActionBlock.Width = valueBlokWidth;
                Canvas.SetLeft(firstPointToConnect, valueBlokWidth / 2 - 2);
                Canvas.SetLeft(thirdPointToConnect, valueBlokWidth / 2 - 2);
                Canvas.SetLeft(fourthPointToConnect, valueBlokWidth - 4);
            }
        }

        public void SetHeightBlock(int valueBlokHeight)
        {
            if (canvasOfActionBlock != null && textBoxOfActionBlock != null)
            {
                canvasOfActionBlock.Height = valueBlokHeight;
                textBoxOfActionBlock.Height = valueBlokHeight;
                Canvas.SetTop(secondPointToConnect, valueBlokHeight / 2 - 2);
                Canvas.SetTop(thirdPointToConnect, valueBlokHeight - 3);
                Canvas.SetTop(fourthPointToConnect, valueBlokHeight / 2 - 2);
            }
        }
    }
}