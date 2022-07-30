using Flowchart_Editor.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Flowchart_Editor.View.ConnectionLine
{
    public class ConnectionLine
    {
        private Canvas? editField;
        const int valueOffsetOfLineFromTheBlockToSides = 20;
        public ConnectionLine(Canvas? editField)
        {
            this.editField = editField;
        }
        public Line[]? DrawConnectionLine(double x1, double y1, double x2, double y2, Block firstBlock, Block secondBlock)
        {
            Line[] lines = new Line[5];
            //vif (CoordinatesBlock.keyFirstBlock == CoordinatesBlock.keySecondBlock)
            {
                //MessageBox.Show("Ошибка соединения блоков");
                //StaticBlock.firstPointToConnect = "";
                //StaticBlock.secondPointToConnect = "";
                //return null;
            }
            //else
            {
                if (StaticBlock.FirstPointToConnect == "fourthPointToConnect" && StaticBlock.SecondPointToConnect == "firstPointToConnect")
                {
                    if (y2 > y1 && x1 >= x2)
                        lines = DrawConnectionLine4(x2, y2, x1, y1);
                    else if (y2 > y1 && x1 <= x2)
                        lines = DrawConnectionLine5(x2, y2, x1, y1);
                    else if (y1 > y2)
                        lines = DrawConnectionLine6(x2, y2, x1, y1);
                }
            }
            return lines;
        }
        //        //    else if (StaticBlock.firstPointToConnect == "fourthPointToConnect" && StaticBlock.secondPointToConnect == "secondPointToConnect")
        //        //    {
        //        //        if (x2 > x1)
        //        //            lines = DrawConnectionLine14(x1, y1, x2, y2);
        //        //        else
        //        //            lines = DrawConnectionLine13(x1, y1, x2, y2);
        //        //    }
        //        //    else if (StaticBlock.firstPointToConnect == "fourthPointToConnect" && StaticBlock.secondPointToConnect == "thirdPointToConnect")
        //        //    {
        //        //        if (x1 < x2 && y2 < y1)
        //        //            lines = DrawConnectionLine5(x2, y2, x1, y1);
        //        //        else
        //        //            lines = DrawConnectionLine17(x2, y2, x1, y1);
        //        //    }
        //        //    else if (StaticBlock.firstPointToConnect == "fourthPointToConnect" && StaticBlock.secondPointToConnect == "fourthPointToConnect")
        //        //    {
        //        //        if ((y1 + DefaultPropertyForBlock.height / 2 <= y2 && y1 > y2) || (y1 <= y2 && y1 >= y2 - DefaultPropertyForBlock.height) || (y1 == y2))
        //        //            lines = DrawConnectionLine20(x2, y2, x1, y1);
        //        //        else if (x2 > x1)
        //        //            lines = DrawConnectionLine18(x2, y2, x1, y1);
        //        //        else if (x2 < x1)
        //        //            lines = DrawConnectionLine18(x1, y1, x2, y2);
        //        //    }
        //        //    else if (StaticBlock.firstPointToConnect == "thirdPointToConnect" && StaticBlock.secondPointToConnect == "firstPointToConnect")
        //        //    {
        //        //        firstBlock.flagForEnteringThirdConnectionPointAndFirst = true;
        //        //        secondBlock.flagForEnteringFirstConnectionPointAndThird = true;
        //        //        if (x1 != x2 && y2 > y1)
        //        //            lines = DrawConnectionLine1(x1, y1, x2, y2);
        //        //        else if ((x2 - x1) > DefaultPropertyForBlock.height)
        //        //            lines = DrawConnectionLine2(x2, y2, x1, y1);
        //        //        else if (x1 == x2)
        //        //            lines = DrawConnectionLine3(x1, y1, x2, y2);
        //        //    }
        //        //    else if (StaticBlock.firstPointToConnect == "thirdPointToConnect" && StaticBlock.secondPointToConnect == "secondPointToConnect")
        //        //    {
        //        //        if (x1 < x2 && y2 > y1)
        //        //            lines = DrawConnectionLine5(x1, y1, x2, y2);
        //        //        else
        //        //            lines = DrawConnectionLine12(x1, y1, x2, y2);
        //        //    }
        //        //    else
        //        //    {
        //        //        MessageBox.Show("Ошибка соединения блоков");
        //        //        StaticBlock.firstPointToConnect = "";
        //        //        StaticBlock.secondPointToConnect = "";
        //        //    }
        //        //}
        //        //else if (!(bool)StaticBlock.ISOOriginLines && (bool)StaticBlock.ISOLineEntry)
        //        //{
        //        //    if (StaticBlock.firstPointToConnect == "firstPointToConnect" && StaticBlock.secondPointToConnect == "fourthPointToConnect")
        //        //    {
        //        //        if (y2 < y1 && x1 <= x2)
        //        //            lines = DrawConnectionLine4(x1, y1, x2, y2);
        //        //        else if (y2 < y1 && x1 >= x2)
        //        //            lines = DrawConnectionLine5(x1, y1, x2, y2);
        //        //        else if (y1 < y2)
        //        //            lines = DrawConnectionLine6(x1, y1, x2, y2);
        //        //    }
        //        //    else if (StaticBlock.firstPointToConnect == "firstPointToConnect" && StaticBlock.secondPointToConnect == "thirdPointToConnect")
        //        //    {
        //        //        firstBlock.flagForEnteringFirstConnectionPointAndThird = true;
        //        //        secondBlock.flagForEnteringThirdConnectionPointAndFirst = true;
        //        //        if (x1 != x2 && y2 < y1)
        //        //            lines = DrawConnectionLine1(x1, y1, x2, y2);
        //        //        else if ((x2 - x1) < DefaultPropertyForBlock.height)
        //        //            lines = DrawConnectionLine2(x1, y1, x2, y2);
        //        //        else if (x1 == x2)
        //        //            lines = DrawConnectionLine3(x1, y1, x2, y2);
        //        //    }
        //        //    else if (StaticBlock.firstPointToConnect == "firstPointToConnect" && StaticBlock.secondPointToConnect == "firstPointToConnect")
        //        //    {
        //        //        if ((x2 + DefaultPropertyForBlock.width / 2 < x1) || (x1 + DefaultPropertyForBlock.width / 2 < x2))
        //        //        {
        //        //            if (y1 > y2)
        //        //                lines = DrawConnectionLine8(x1, y1, x2, y2);
        //        //            else
        //        //                lines = DrawConnectionLine8(x2, y2, x1, y1);
        //        //        }
        //        //        else lines = DrawConnectionLine7(x1, y1, x2, y2);
        //        //    }
        //        //    else if (StaticBlock.firstPointToConnect == "firstPointToConnect" && StaticBlock.secondPointToConnect == "secondPointToConnect")
        //        //    {
        //        //        if (x1 <= x2)
        //        //            lines = DrawConnectionLine5(x1, y1, x2, y2);
        //        //        else if (y2 > y1)
        //        //            lines = DrawConnectionLine9(x1, y1, x2, y2);
        //        //    }
        //        //    else if (StaticBlock.firstPointToConnect == "secondPointToConnect" && StaticBlock.secondPointToConnect == "firstPointToConnect")
        //        //    {
        //        //        if (x1 >= x2)
        //        //            lines = DrawConnectionLine5(x2, y2, x1, y1);
        //        //        else if (y2 < y1)
        //        //            lines = DrawConnectionLine9(x2, y2, x1, y1);
        //        //        else if (x1 <= x2 && y2 > y1)
        //        //            lines = DrawConnectionLine9(x2, y2, x1, y1);
        //        //    }
        //        //    else if (StaticBlock.firstPointToConnect == "secondPointToConnect" && StaticBlock.secondPointToConnect == "secondPointToConnect")
        //        //    {
        //        //        if ((y2 + DefaultPropertyForBlock.height / 2 <= y1) || (y1 + DefaultPropertyForBlock.width / 2 >= y2))
        //        //            lines = DrawConnectionLine11(x2, y2, x1, y1);
        //        //        else if (x2 < x1)
        //        //            lines = DrawConnectionLine10(x2, y2, x1, y1);
        //        //        else if (x2 > x1)
        //        //            lines = DrawConnectionLine10(x1, y1, x2, y2);
        //        //    }
        //        //    else if (StaticBlock.firstPointToConnect == "secondPointToConnect" && StaticBlock.secondPointToConnect == "thirdPointToConnect")
        //        //    {
        //        //        if (x1 > x2 && y2 < y1)
        //        //            lines = DrawConnectionLine5(x2, y2, x1, y1);
        //        //        else
        //        //            lines = DrawConnectionLine12(x2, y2, x1, y1);
        //        //    }
        //        //    else
        //        //    {
        //        //        MessageBox.Show("Ошибка соединения блоков");
        //        //        StaticBlock.firstPointToConnect = "";
        //        //        StaticBlock.secondPointToConnect = "";
        //        //    }
        //        //}
        //        //else if (StaticBlock.ISOOriginLines != null && StaticBlock.ISOLineEntry != null)
        //        //{
        //        //    if ((bool)StaticBlock.ISOOriginLines && (bool)StaticBlock.ISOLineEntry)
        //        //    {
        //        //        if (StaticBlock.firstPointToConnect == "firstPointToConnect" && StaticBlock.secondPointToConnect == "fourthPointToConnect")
        //        //        {
        //        //            if (y2 < y1 && x1 <= x2)
        //        //                lines = DrawConnectionLine4(x1, y1, x2, y2);
        //        //            else if (y2 < y1 && x1 >= x2)
        //        //                lines = DrawConnectionLine5(x1, y1, x2, y2);
        //        //            else if (y1 < y2)
        //        //                lines = DrawConnectionLine6(x1, y1, x2, y2);
        //        //        }
        //        //        else if (StaticBlock.firstPointToConnect == "fourthPointToConnect" && StaticBlock.secondPointToConnect == "firstPointToConnect")
        //        //        {
        //        //            if (y2 > y1 && x1 >= x2)
        //        //                lines = DrawConnectionLine4(x2, y2, x1, y1);
        //        //            else if (y2 > y1 && x1 <= x2)
        //        //                lines = DrawConnectionLine5(x2, y2, x1, y1);
        //        //            else if (y1 > y2)
        //        //                lines = DrawConnectionLine6(x2, y2, x1, y1);
        //        //        }
        //        //        else if (StaticBlock.firstPointToConnect == "thirdPointToConnect" && StaticBlock.secondPointToConnect == "firstPointToConnect")
        //        //        {
        //        //            firstBlock.flagForEnteringThirdConnectionPointAndFirst = true;
        //        //            secondBlock.flagForEnteringFirstConnectionPointAndThird = true;
        //        //            if (x1 != x2 && y2 > y1)
        //        //                lines = DrawConnectionLine1(x1, y1, x2, y2);
        //        //            else if ((x2 - x1) > DefaultPropertyForBlock.height)
        //        //                lines = DrawConnectionLine2(x2, y2, x1, y1);
        //        //            else if (x1 == x2)
        //        //                lines = DrawConnectionLine3(x1, y1, x2, y2);
        //        //        }
        //        //        else if (StaticBlock.firstPointToConnect == "firstPointToConnect" && StaticBlock.secondPointToConnect == "thirdPointToConnect")
        //        //        {
        //        //            firstBlock.flagForEnteringFirstConnectionPointAndThird = true;
        //        //            secondBlock.flagForEnteringThirdConnectionPointAndFirst = true;
        //        //            if (x1 != x2 && y2 < y1)
        //        //                lines = DrawConnectionLine1(x1, y1, x2, y2);
        //        //            else if ((x2 - x1) < DefaultPropertyForBlock.height)
        //        //                lines = DrawConnectionLine2(x1, y1, x2, y2);
        //        //            else if (x1 == x2)
        //        //                lines = DrawConnectionLine3(x1, y1, x2, y2);
        //        //        }
        //        //        else if (StaticBlock.firstPointToConnect == "firstPointToConnect" && StaticBlock.secondPointToConnect == "firstPointToConnect")
        //        //        {
        //        //            if ((x2 + DefaultPropertyForBlock.width / 2 < x1) || (x1 + DefaultPropertyForBlock.width / 2 < x2))
        //        //            {
        //        //                if (y1 > y2)
        //        //                    lines = DrawConnectionLine8(x1, y1, x2, y2);
        //        //                else
        //        //                    lines = DrawConnectionLine8(x2, y2, x1, y1);
        //        //            }
        //        //            else lines = DrawConnectionLine7(x1, y1, x2, y2);
        //        //        }
        //        //        else if (StaticBlock.firstPointToConnect == "firstPointToConnect" && StaticBlock.secondPointToConnect == "secondPointToConnect")
        //        //        {
        //        //            if (x1 <= x2)
        //        //                lines = DrawConnectionLine5(x1, y1, x2, y2);
        //        //            else if (y2 > y1)
        //        //                lines = DrawConnectionLine9(x1, y1, x2, y2);
        //        //        }
        //        //        else if (StaticBlock.firstPointToConnect == "secondPointToConnect" && StaticBlock.secondPointToConnect == "firstPointToConnect")
        //        //        {
        //        //            if (x1 >= x2)
        //        //                lines = DrawConnectionLine5(x2, y2, x1, y1);
        //        //            else if (y2 < y1)
        //        //                lines = DrawConnectionLine9(x2, y2, x1, y1);
        //        //            else if (x1 <= x2 && y2 > y1)
        //        //                lines = DrawConnectionLine9(x2, y2, x1, y1);
        //        //        }
        //        //        else if (StaticBlock.firstPointToConnect == "secondPointToConnect" && StaticBlock.secondPointToConnect == "secondPointToConnect")
        //        //        {
        //        //            if ((y2 + DefaultPropertyForBlock.height / 2 <= y1) || (y1 + DefaultPropertyForBlock.width / 2 >= y2))
        //        //                lines = DrawConnectionLine11(x2, y2, x1, y1);
        //        //            else if (x2 < x1)
        //        //                lines = DrawConnectionLine10(x2, y2, x1, y1);
        //        //            else if (x2 > x1)
        //        //                lines = DrawConnectionLine10(x1, y1, x2, y2);
        //        //        }
        //        //        else if (StaticBlock.firstPointToConnect == "secondPointToConnect" && StaticBlock.secondPointToConnect == "thirdPointToConnect")
        //        //        {
        //        //            if (x1 > x2 && y2 < y1)
        //        //                lines = DrawConnectionLine5(x2, y2, x1, y1);
        //        //            else
        //        //                lines = DrawConnectionLine12(x2, y2, x1, y1);
        //        //        }
        //        //        else if (StaticBlock.firstPointToConnect == "thirdPointToConnect" && StaticBlock.secondPointToConnect == "secondPointToConnect")
        //        //        {
        //        //            if (x1 < x2 && y2 > y1)
        //        //                lines = DrawConnectionLine5(x1, y1, x2, y2);
        //        //            else
        //        //                lines = DrawConnectionLine12(x1, y1, x2, y2);
        //        //        }
        //        //        else if (StaticBlock.firstPointToConnect == "secondPointToConnect" && StaticBlock.secondPointToConnect == "fourthPointToConnect")
        //        //        {
        //        //            if (x2 < x1)
        //        //                lines = DrawConnectionLine14(x2, y2, x1, y1);
        //        //            else
        //        //                lines = DrawConnectionLine13(x2, y2, x1, y1);
        //        //        }
        //        //        else if (StaticBlock.firstPointToConnect == "fourthPointToConnect" && StaticBlock.secondPointToConnect == "secondPointToConnect")
        //        //        {
        //        //            if (x2 > x1)
        //        //                lines = DrawConnectionLine14(x1, y1, x2, y2);
        //        //            else
        //        //                lines = DrawConnectionLine13(x1, y1, x2, y2);
        //        //        }
        //        //        else if (StaticBlock.firstPointToConnect == "thirdPointToConnect" && StaticBlock.secondPointToConnect == "thirdPointToConnect")
        //        //        {
        //        //            if ((x2 + DefaultPropertyForBlock.width / 2 < x1) || (x1 + DefaultPropertyForBlock.width / 2 < x2))
        //        //            {
        //        //                if (y1 > y2)
        //        //                    lines = DrawConnectionLine16(x1, y1, x2, y2);
        //        //                else
        //        //                    lines = DrawConnectionLine16(x2, y2, x1, y1);
        //        //            }
        //        //            else lines = DrawConnectionLine15(x1, y1, x2, y2);
        //        //        }
        //        //        else if (StaticBlock.firstPointToConnect == "thirdPointToConnect" && StaticBlock.secondPointToConnect == "fourthPointToConnect")
        //        //        {
        //        //            if (x1 > x2 && y2 > y1)
        //        //                lines = DrawConnectionLine5(x1, y1, x2, y2);
        //        //            else
        //        //                lines = DrawConnectionLine17(x1, y1, x2, y2);
        //        //        }
        //        //        else if (StaticBlock.firstPointToConnect == "fourthPointToConnect" && StaticBlock.secondPointToConnect == "thirdPointToConnect")
        //        //        {
        //        //            if (x1 < x2 && y2 < y1)
        //        //                lines = DrawConnectionLine5(x2, y2, x1, y1);
        //        //            else
        //        //                lines = DrawConnectionLine17(x2, y2, x1, y1);
        //        //        }
        //        //        else if (StaticBlock.firstPointToConnect == "fourthPointToConnect" && StaticBlock.secondPointToConnect == "fourthPointToConnect")
        //        //        {
        //        //            if ((y1 + DefaultPropertyForBlock.height / 2 <= y2 && y1 > y2) || (y1 <= y2 && y1 >= y2 - DefaultPropertyForBlock.height) || (y1 == y2))
        //        //                lines = DrawConnectionLine20(x2, y2, x1, y1);
        //        //            else if (x2 > x1)
        //        //                lines = DrawConnectionLine18(x2, y2, x1, y1);
        //        //            else if (x2 < x1)
        //        //                lines = DrawConnectionLine18(x1, y1, x2, y2);
        //        //        }
        //            }
        //            else
        //            {
        //                MessageBox.Show("Ошибка соединения блоков");
        //                StaticBlock.firstPointToConnect = "";
        //                StaticBlock.secondPointToConnect = "";
        //            }
        //        }
        //    }

        //    StaticBlock.firstPointToConnect = "";
        //    StaticBlock.secondPointToConnect = "";
        //    return lines;
        //}

        //public Line[] DrawConnectionLine1(double x1, double y1, double x2, double y2)
        //{
        //    BrushConverter color = new();
        //    Line[] lines = new Line[5];

        //    Line firstLine = new();
        //    double distanceBetweenTwoPoints = y2 - y1;
        //    firstLine.Y1 = y1;
        //    firstLine.X1 = x1;
        //    firstLine.Y2 = y2 - distanceBetweenTwoPoints / 2;
        //    firstLine.X2 = x1;
        //    firstLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
        //    Edblock.listLineConnection.Add(firstLine);
        //    editField.Children.Add(firstLine);
        //    lines[0] = firstLine;

        //    Line secondLine = new();
        //    secondLine.Y1 = y1 + distanceBetweenTwoPoints / 2;
        //    secondLine.X1 = x1;
        //    secondLine.Y2 = y1 + distanceBetweenTwoPoints / 2;
        //    secondLine.X2 = x2;
        //    secondLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
        //    listLineConnection.Add(secondLine);
        //    editField.Children.Add(secondLine);
        //    lines[1] = secondLine;

        //    Line thirdLine = new();
        //    thirdLine.Y1 = y1 + distanceBetweenTwoPoints / 2;
        //    thirdLine.X1 = x2;
        //    thirdLine.Y2 = y2;
        //    thirdLine.X2 = x2;
        //    thirdLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
        //    listLineConnection.Add(thirdLine);
        //    editField.Children.Add(thirdLine);
        //    lines[2] = thirdLine;

        //    return lines;
        //}
        //public Line[] DrawConnectionLine2(double x1, double y1, double x2, double y2)
        //{
        //    BrushConverter color = new();
        //    Line[] lines = new Line[5];

        //    Line firstLine = new();
        //    firstLine.X1 = x1;
        //    firstLine.X2 = x1;
        //    firstLine.Y1 = y1 - valueOffsetOfLineFromTheBlockToSides;
        //    firstLine.Y2 = y1;
        //    firstLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
        //    listLineConnection.Add(firstLine);
        //    editField.Children.Add(firstLine);
        //    lines[0] = firstLine;

        //    Line secondLine = new();
        //    secondLine.X2 = x1;
        //    secondLine.Y1 = y1 - valueOffsetOfLineFromTheBlockToSides;
        //    secondLine.Y2 = y1 - valueOffsetOfLineFromTheBlockToSides;
        //    secondLine.X1 = x1 + DefaultPropertyForBlock.width / 2 + valueOffsetOfLineFromTheBlockToSides;
        //    secondLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
        //    listLineConnection.Add(secondLine);
        //    editField.Children.Add(secondLine);
        //    lines[1] = secondLine;

        //    Line thirdLine = new();
        //    thirdLine.Y1 = y1 - valueOffsetOfLineFromTheBlockToSides;
        //    thirdLine.X1 = x1 + DefaultPropertyForBlock.width / 2 + valueOffsetOfLineFromTheBlockToSides;
        //    thirdLine.Y2 = y2 + valueOffsetOfLineFromTheBlockToSides;
        //    thirdLine.X2 = x1 + DefaultPropertyForBlock.width / 2 + valueOffsetOfLineFromTheBlockToSides;
        //    thirdLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
        //    listLineConnection.Add(thirdLine);
        //    editField.Children.Add(thirdLine);
        //    lines[2] = thirdLine;

        //    Line fourthLine = new();
        //    fourthLine.X1 = x2;
        //    fourthLine.Y1 = y2 + valueOffsetOfLineFromTheBlockToSides;
        //    fourthLine.X2 = x1 + DefaultPropertyForBlock.width / 2 + valueOffsetOfLineFromTheBlockToSides;
        //    fourthLine.Y2 = y2 + valueOffsetOfLineFromTheBlockToSides;
        //    fourthLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
        //    listLineConnection.Add(fourthLine);
        //    editField.Children.Add(fourthLine);
        //    lines[3] = fourthLine;

        //    Line fifthLine = new();
        //    fifthLine.X2 = x2;
        //    fifthLine.Y1 = y2;
        //    fifthLine.X1 = x2;
        //    fifthLine.Y2 = y2 + valueOffsetOfLineFromTheBlockToSides;
        //    fifthLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
        //    listLineConnection.Add(fifthLine);
        //    editField.Children.Add(fifthLine);
        //    lines[4] = fifthLine;

        //    return lines;
        //}
        //public Line[] DrawConnectionLine3(double x1, double y1, double x2, double y2)
        //{
        //    BrushConverter color = new();
        //    Line[] lines = new Line[5];

        //    Line firstLine = new();
        //    firstLine.X1 = x1;
        //    firstLine.Y1 = y1;
        //    firstLine.X2 = x2;
        //    firstLine.Y2 = y2;
        //    firstLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
        //    listLineConnection.Add(firstLine);
        //    editField.Children.Add(firstLine);
        //    lines[0] = firstLine;

        //    return lines;
        //}
        public Line[] DrawConnectionLine4(double x1, double y1, double x2, double y2)
        {
            double distanceBetweenTwoPoints = y2 - y1;
            Line[] lines = new Line[5];

            BrushConverter color = new();
            Line firstLine = new();
            firstLine.X1 = x2;
            firstLine.Y1 = y2;
            firstLine.X2 = x2 + valueOffsetOfLineFromTheBlockToSides;
            firstLine.Y2 = y2;
            firstLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            Edblock.ListLineConnection.Add(firstLine);
            editField.Children.Add(firstLine);
            lines[0] = firstLine;


            Line secondLine = new();
            secondLine.X1 = x2 + valueOffsetOfLineFromTheBlockToSides;
            secondLine.Y1 = y2;
            secondLine.X2 = x2 + valueOffsetOfLineFromTheBlockToSides;
            secondLine.Y2 = y2 - distanceBetweenTwoPoints - valueOffsetOfLineFromTheBlockToSides;
            secondLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            Edblock.ListLineConnection.Add(secondLine);
            editField.Children.Add(secondLine);
            lines[1] = secondLine;

            Line thirdLine = new();
            thirdLine.X1 = x1;
            thirdLine.Y1 = y1 - valueOffsetOfLineFromTheBlockToSides;
            thirdLine.X2 = x2 + valueOffsetOfLineFromTheBlockToSides;
            thirdLine.Y2 = y2 - distanceBetweenTwoPoints - valueOffsetOfLineFromTheBlockToSides;
            thirdLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            Edblock.ListLineConnection.Add(thirdLine);
            editField.Children.Add(thirdLine);
            lines[2] = thirdLine;

            Line fourthLine = new();
            fourthLine.X1 = x1;
            fourthLine.Y1 = y1;
            fourthLine.X2 = x1;
            fourthLine.Y2 = y1 - valueOffsetOfLineFromTheBlockToSides;
            fourthLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            Edblock.ListLineConnection.Add(fourthLine);
            editField.Children.Add(fourthLine);
            lines[3] = fourthLine;

            return lines;
        }
        public Line[] DrawConnectionLine5(double x1, double y1, double x2, double y2)
        {
            Line[] lines = new Line[5];

            BrushConverter color = new();
            Line firstLine = new();
            firstLine.X1 = x2;
            firstLine.Y1 = y2;
            firstLine.X2 = x1;
            firstLine.Y2 = y2;
            firstLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            Edblock.ListLineConnection.Add(firstLine);
            editField.Children.Add(firstLine);
            lines[0] = firstLine;

            Line secondLine = new();
            secondLine.X1 = x1;
            secondLine.Y1 = y2;
            secondLine.X2 = x1;
            secondLine.Y2 = y1;
            secondLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            Edblock.ListLineConnection.Add(secondLine);
            editField.Children.Add(secondLine);
            lines[1] = secondLine;

            return lines;
        }
        public Line[] DrawConnectionLine6(double x1, double y1, double x2, double y2)
        {
            double distanceBetweenTwoPoints = x1 - x2;
            BrushConverter color = new();
            Line[] lines = new Line[5];

            Line firstLine = new();
            firstLine.X1 = x1;
            firstLine.Y1 = y1;
            firstLine.X2 = x1;
            firstLine.Y2 = y1 - valueOffsetOfLineFromTheBlockToSides;
            firstLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            Edblock.ListLineConnection.Add(firstLine);
            editField.Children.Add(firstLine);
            lines[0] = firstLine;

            Line secondLine = new();
            secondLine.X1 = x1;
            secondLine.Y1 = y1 - valueOffsetOfLineFromTheBlockToSides;
            secondLine.X2 = x1 - distanceBetweenTwoPoints + valueOffsetOfLineFromTheBlockToSides;
            secondLine.Y2 = y1 - valueOffsetOfLineFromTheBlockToSides;
            secondLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            Edblock.ListLineConnection.Add(secondLine);
            editField.Children.Add(secondLine);
            lines[1] = secondLine;

            Line thirdLine = new();
            thirdLine.X1 = x2;
            thirdLine.Y1 = y2;
            thirdLine.X2 = x2 + valueOffsetOfLineFromTheBlockToSides;
            thirdLine.Y2 = y2;
            thirdLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            Edblock.ListLineConnection.Add(thirdLine);
            editField.Children.Add(thirdLine);
            lines[2] = thirdLine;

            Line fourthLine = new();
            fourthLine.X1 = x2 + valueOffsetOfLineFromTheBlockToSides;
            fourthLine.Y1 = y2;
            fourthLine.X2 = x2 + valueOffsetOfLineFromTheBlockToSides;
            fourthLine.Y2 = y1 - valueOffsetOfLineFromTheBlockToSides;
            fourthLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
            Edblock.ListLineConnection.Add(fourthLine);
            editField.Children.Add(fourthLine);
            lines[3] = fourthLine;

            return lines;
        }
        //public Line[] DrawConnectionLine7(double x1, double y1, double x2, double y2)
        //{
        //    double distanceBetweenTwoPoints = y1 - y2;
        //    BrushConverter color = new();
        //    Line[] lines = new Line[5];

        //    Line firstLine = new();
        //    firstLine.X1 = x1;
        //    firstLine.Y1 = y1;
        //    firstLine.X2 = x1;
        //    firstLine.Y2 = y1 - valueOffsetOfLineFromTheBlockToSides;
        //    firstLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
        //    listLineConnection.Add(firstLine);
        //    editField.Children.Add(firstLine);
        //    lines[0] = firstLine;

        //    Line secondLine = new();
        //    secondLine.X1 = x2;
        //    secondLine.Y1 = y2 - valueOffsetOfLineFromTheBlockToSides;
        //    secondLine.X2 = x2 + DefaultPropertyForBlock.width / 2 + valueOffsetOfLineFromTheBlockToSides;
        //    secondLine.Y2 = y2 - valueOffsetOfLineFromTheBlockToSides;
        //    secondLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
        //    listLineConnection.Add(secondLine);
        //    editField.Children.Add(secondLine);
        //    lines[1] = secondLine;

        //    Line thirdLine = new();
        //    thirdLine.X1 = x2 + DefaultPropertyForBlock.width / 2 + valueOffsetOfLineFromTheBlockToSides;
        //    thirdLine.Y1 = y2 - valueOffsetOfLineFromTheBlockToSides;
        //    thirdLine.X2 = x2 + DefaultPropertyForBlock.width / 2 + valueOffsetOfLineFromTheBlockToSides;
        //    thirdLine.Y2 = y2 - valueOffsetOfLineFromTheBlockToSides + distanceBetweenTwoPoints;
        //    thirdLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
        //    listLineConnection.Add(thirdLine);
        //    editField.Children.Add(thirdLine);
        //    lines[2] = thirdLine;

        //    Line fourthLine = new();
        //    fourthLine.X1 = x2 + DefaultPropertyForBlock.width / 2 + valueOffsetOfLineFromTheBlockToSides;
        //    fourthLine.Y1 = y2 - valueOffsetOfLineFromTheBlockToSides + distanceBetweenTwoPoints;
        //    fourthLine.X2 = x1;
        //    fourthLine.Y2 = y1 - valueOffsetOfLineFromTheBlockToSides;
        //    fourthLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
        //    listLineConnection.Add(fourthLine);
        //    editField.Children.Add(fourthLine);
        //    lines[3] = fourthLine;

        //    Line fifthLine = new();
        //    fifthLine.X2 = x2;
        //    fifthLine.Y1 = y2;
        //    fifthLine.X1 = x2;
        //    fifthLine.Y2 = y2 - valueOffsetOfLineFromTheBlockToSides;
        //    fifthLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
        //    listLineConnection.Add(fifthLine);
        //    editField.Children.Add(fifthLine);
        //    lines[4] = fourthLine;

        //    return lines;
        //}

        //public Line[] DrawConnectionLine8(double x1, double y1, double x2, double y2)
        //{
        //    BrushConverter color = new();
        //    Line[] lines = new Line[5];

        //    Line firstLine = new();
        //    firstLine.X1 = x2;
        //    firstLine.Y1 = y2;
        //    firstLine.X2 = x2;
        //    firstLine.Y2 = y2 - valueOffsetOfLineFromTheBlockToSides;
        //    firstLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
        //    listLineConnection.Add(firstLine);
        //    editField.Children.Add(firstLine);
        //    lines[0] = firstLine;

        //    Line secondLine = new();
        //    secondLine.X1 = x2;
        //    secondLine.Y1 = y2 - valueOffsetOfLineFromTheBlockToSides;
        //    secondLine.X2 = x1;
        //    secondLine.Y2 = y2 - valueOffsetOfLineFromTheBlockToSides;
        //    secondLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
        //    listLineConnection.Add(secondLine);
        //    editField.Children.Add(secondLine);
        //    lines[1] = secondLine;

        //    Line thirdLine = new();
        //    thirdLine.X1 = x1;
        //    thirdLine.Y1 = y2 - valueOffsetOfLineFromTheBlockToSides;
        //    thirdLine.X2 = x1;
        //    thirdLine.Y2 = y1;
        //    thirdLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
        //    listLineConnection.Add(thirdLine);
        //    editField.Children.Add(thirdLine);
        //    lines[2] = thirdLine;

        //    return lines;
        //}

        //public Line[] DrawConnectionLine9(double x1, double y1, double x2, double y2)
        //{
        //    double distanceBetweenTwoPoints = y2 - y1;
        //    Line[] lines = new Line[5];
        //    BrushConverter color = new();

        //    Line firstLine = new();
        //    firstLine.X1 = x2;
        //    firstLine.Y1 = y2;
        //    firstLine.X2 = x2 - valueOffsetOfLineFromTheBlockToSides;
        //    firstLine.Y2 = y2;
        //    firstLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
        //    listLineConnection.Add(firstLine);
        //    editField.Children.Add(firstLine);
        //    lines[0] = firstLine;

        //    Line secondLine = new();
        //    secondLine.X1 = x2 - valueOffsetOfLineFromTheBlockToSides;
        //    secondLine.Y1 = y2;
        //    secondLine.X2 = x2 - valueOffsetOfLineFromTheBlockToSides;
        //    secondLine.Y2 = y2 - distanceBetweenTwoPoints - valueOffsetOfLineFromTheBlockToSides;
        //    secondLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
        //    listLineConnection.Add(secondLine);
        //    editField.Children.Add(secondLine);
        //    lines[1] = secondLine;

        //    Line thirdLine = new();
        //    thirdLine.X1 = x1;
        //    thirdLine.Y1 = y1 - valueOffsetOfLineFromTheBlockToSides;
        //    thirdLine.X2 = x2 - valueOffsetOfLineFromTheBlockToSides;
        //    thirdLine.Y2 = y2 - distanceBetweenTwoPoints - valueOffsetOfLineFromTheBlockToSides;
        //    thirdLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
        //    listLineConnection.Add(thirdLine);
        //    editField.Children.Add(thirdLine);
        //    lines[2] = thirdLine;

        //    Line fourthLine = new();
        //    fourthLine.X1 = x1;
        //    fourthLine.Y1 = y1;
        //    fourthLine.X2 = x1;
        //    fourthLine.Y2 = y1 - valueOffsetOfLineFromTheBlockToSides;
        //    fourthLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
        //    listLineConnection.Add(fourthLine);
        //    editField.Children.Add(fourthLine);
        //    lines[3] = fourthLine;

        //    return lines;
        //}

        //public Line[] DrawConnectionLine10(double x1, double y1, double x2, double y2)
        //{
        //    BrushConverter color = new();
        //    Line[] lines = new Line[5];

        //    Line firstLine = new();
        //    double distanceBetweenTwoPoints = x2 - x1;
        //    firstLine.X1 = x1;
        //    firstLine.Y1 = y1;
        //    firstLine.X2 = x1 - valueOffsetOfLineFromTheBlockToSides;
        //    firstLine.Y2 = y1;
        //    firstLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
        //    listLineConnection.Add(firstLine);
        //    editField.Children.Add(firstLine);
        //    lines[0] = firstLine;

        //    Line secondLine = new();
        //    secondLine.X1 = x1 - valueOffsetOfLineFromTheBlockToSides;
        //    secondLine.Y1 = y1;
        //    secondLine.X2 = x2 - distanceBetweenTwoPoints - valueOffsetOfLineFromTheBlockToSides;
        //    secondLine.Y2 = y2;
        //    secondLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
        //    listLineConnection.Add(secondLine);
        //    editField.Children.Add(secondLine);
        //    lines[1] = secondLine;

        //    Line thirdLine = new();
        //    thirdLine.X1 = x2;
        //    thirdLine.Y1 = y2;
        //    thirdLine.X2 = x2 - distanceBetweenTwoPoints - valueOffsetOfLineFromTheBlockToSides;
        //    thirdLine.Y2 = y2;
        //    thirdLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
        //    listLineConnection.Add(thirdLine);
        //    editField.Children.Add(thirdLine);
        //    lines[2] = thirdLine;

        //    return lines;
        //}

        //public Line[] DrawConnectionLine11(double x1, double y1, double x2, double y2)
        //{
        //    BrushConverter color = new();
        //    Line[] lines = new Line[5];

        //    Line firstLine = new();
        //    firstLine.X1 = x1;
        //    firstLine.Y1 = y1;
        //    firstLine.X2 = x1 - valueOffsetOfLineFromTheBlockToSides;
        //    firstLine.Y2 = y1;
        //    firstLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
        //    listLineConnection.Add(firstLine);
        //    editField.Children.Add(firstLine);
        //    lines[0] = firstLine;

        //    Line secondLine = new();
        //    secondLine.X1 = x1 - valueOffsetOfLineFromTheBlockToSides;
        //    secondLine.Y1 = y1;
        //    secondLine.X2 = x1 - valueOffsetOfLineFromTheBlockToSides;
        //    secondLine.Y2 = y2 + DefaultPropertyForBlock.height / 2 + valueOffsetOfLineFromTheBlockToSides;
        //    secondLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
        //    listLineConnection.Add(secondLine);
        //    editField.Children.Add(secondLine);
        //    lines[1] = secondLine;

        //    Line thirdLine = new();
        //    thirdLine.X1 = x1 - valueOffsetOfLineFromTheBlockToSides;
        //    thirdLine.Y1 = y2 + DefaultPropertyForBlock.height / 2 + valueOffsetOfLineFromTheBlockToSides;
        //    thirdLine.X2 = x2 - valueOffsetOfLineFromTheBlockToSides;
        //    thirdLine.Y2 = y2 + DefaultPropertyForBlock.height / 2 + valueOffsetOfLineFromTheBlockToSides;
        //    thirdLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
        //    listLineConnection.Add(thirdLine);
        //    editField.Children.Add(thirdLine);
        //    lines[2] = thirdLine;

        //    Line fourthLine = new();
        //    fourthLine.X1 = x2 - valueOffsetOfLineFromTheBlockToSides;
        //    fourthLine.Y1 = y2 + DefaultPropertyForBlock.height / 2 + valueOffsetOfLineFromTheBlockToSides;
        //    fourthLine.X2 = x2 - valueOffsetOfLineFromTheBlockToSides;
        //    fourthLine.Y2 = y2;
        //    fourthLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
        //    listLineConnection.Add(fourthLine);
        //    editField.Children.Add(fourthLine);
        //    lines[3] = fourthLine;

        //    Line fifthLine = new();
        //    fifthLine.X2 = x2;
        //    fifthLine.Y1 = y2;
        //    fifthLine.X1 = x2 - valueOffsetOfLineFromTheBlockToSides;
        //    fifthLine.Y2 = y2;
        //    fifthLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
        //    listLineConnection.Add(fifthLine);
        //    editField.Children.Add(fifthLine);
        //    lines[4] = fifthLine;

        //    return lines;
        //}

        //public Line[] DrawConnectionLine12(double x1, double y1, double x2, double y2)
        //{
        //    BrushConverter color = new();
        //    Line[] lines = new Line[5];

        //    Line firstLine = new();
        //    firstLine.X1 = x2;
        //    firstLine.Y1 = y2;
        //    firstLine.X2 = x2 - valueOffsetOfLineFromTheBlockToSides;
        //    firstLine.Y2 = y2;
        //    firstLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
        //    listLineConnection.Add(firstLine);
        //    editField.Children.Add(firstLine);
        //    lines[0] = firstLine;

        //    Line secondLine = new();
        //    secondLine.X1 = x2 - valueOffsetOfLineFromTheBlockToSides;
        //    secondLine.Y1 = y2;
        //    secondLine.X2 = x2 - valueOffsetOfLineFromTheBlockToSides;
        //    secondLine.Y2 = y1 + valueOffsetOfLineFromTheBlockToSides;
        //    secondLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
        //    listLineConnection.Add(secondLine);
        //    editField.Children.Add(secondLine);
        //    lines[1] = secondLine;

        //    Line thirdLine = new();
        //    thirdLine.X1 = x2 - valueOffsetOfLineFromTheBlockToSides;
        //    thirdLine.Y1 = y1 + valueOffsetOfLineFromTheBlockToSides;
        //    thirdLine.X2 = x1;
        //    thirdLine.Y2 = y1 + valueOffsetOfLineFromTheBlockToSides;
        //    thirdLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
        //    listLineConnection.Add(thirdLine);
        //    editField.Children.Add(thirdLine);
        //    lines[2] = thirdLine;

        //    Line fourthLine = new();
        //    fourthLine.X1 = x1;
        //    fourthLine.Y1 = y1;
        //    fourthLine.X2 = x1;
        //    fourthLine.Y2 = y1 + valueOffsetOfLineFromTheBlockToSides;
        //    fourthLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
        //    listLineConnection.Add(fourthLine);
        //    editField.Children.Add(fourthLine);
        //    lines[3] = fourthLine;

        //    return lines;
        //}

        //private Line[] DrawConnectionLine13(double x1, double y1, double x2, double y2)
        //{
        //    BrushConverter color = new();
        //    Line[] lines = new Line[5];

        //    Line firstLine = new();
        //    firstLine.X1 = x2;
        //    firstLine.Y1 = y2;
        //    firstLine.X2 = x2 - valueOffsetOfLineFromTheBlockToSides;
        //    firstLine.Y2 = y2;
        //    firstLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
        //    listLineConnection.Add(firstLine);
        //    editField.Children.Add(firstLine);
        //    lines[0] = firstLine;

        //    Line secondLine = new();
        //    secondLine.X1 = x2 - valueOffsetOfLineFromTheBlockToSides;
        //    secondLine.Y1 = y2;
        //    secondLine.X2 = x2 - valueOffsetOfLineFromTheBlockToSides;
        //    secondLine.Y2 = y2 + DefaultPropertyForBlock.height / 2 + valueOffsetOfLineFromTheBlockToSides;
        //    secondLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
        //    listLineConnection.Add(secondLine);
        //    editField.Children.Add(secondLine);
        //    lines[1] = secondLine;

        //    Line thirdLine = new();
        //    thirdLine.X1 = x2 - valueOffsetOfLineFromTheBlockToSides;
        //    thirdLine.Y1 = y2 + DefaultPropertyForBlock.height / 2 + valueOffsetOfLineFromTheBlockToSides;
        //    thirdLine.X2 = x1 + valueOffsetOfLineFromTheBlockToSides;
        //    thirdLine.Y2 = y2 + DefaultPropertyForBlock.height / 2 + valueOffsetOfLineFromTheBlockToSides;
        //    thirdLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
        //    listLineConnection.Add(thirdLine);
        //    editField.Children.Add(thirdLine);
        //    lines[2] = thirdLine;

        //    Line fourthLine = new();
        //    fourthLine.X1 = x1 + valueOffsetOfLineFromTheBlockToSides;
        //    fourthLine.Y1 = y1;
        //    fourthLine.X2 = x1 + valueOffsetOfLineFromTheBlockToSides;
        //    fourthLine.Y2 = y2 + DefaultPropertyForBlock.height / 2 + valueOffsetOfLineFromTheBlockToSides;
        //    fourthLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
        //    listLineConnection.Add(fourthLine);
        //    editField.Children.Add(fourthLine);
        //    lines[3] = fourthLine;

        //    Line fifthLine = new();
        //    fifthLine.X2 = x1;
        //    fifthLine.Y1 = y1;
        //    fifthLine.X1 = x1 + valueOffsetOfLineFromTheBlockToSides;
        //    fifthLine.Y2 = y1;
        //    fifthLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
        //    listLineConnection.Add(fifthLine);
        //    editField.Children.Add(fifthLine);
        //    lines[4] = fifthLine;

        //    return lines;
        //}
        //private Line[] DrawConnectionLine14(double x1, double y1, double x2, double y2)
        //{
        //    double distanceBetweenTwoPoints = x1 - x2;
        //    BrushConverter color = new();
        //    Line[] lines = new Line[5];

        //    Line firstLine = new();
        //    firstLine.X1 = x1;
        //    firstLine.Y1 = y1;
        //    firstLine.X2 = x1 - distanceBetweenTwoPoints / 2;
        //    firstLine.Y2 = y1;
        //    firstLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
        //    listLineConnection.Add(firstLine);
        //    editField.Children.Add(firstLine);
        //    lines[0] = firstLine;

        //    Line secondLine = new();
        //    secondLine.X1 = x1 - distanceBetweenTwoPoints / 2;
        //    secondLine.Y1 = y1;
        //    secondLine.X2 = x2 + distanceBetweenTwoPoints / 2;
        //    secondLine.Y2 = y2;
        //    secondLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
        //    listLineConnection.Add(secondLine);
        //    editField.Children.Add(secondLine);
        //    lines[1] = secondLine;

        //    Line thirdLine = new();
        //    thirdLine.X1 = x2;
        //    thirdLine.Y1 = y2;
        //    thirdLine.X2 = x2 + distanceBetweenTwoPoints / 2;
        //    thirdLine.Y2 = y2;
        //    thirdLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
        //    listLineConnection.Add(thirdLine);
        //    editField.Children.Add(thirdLine);
        //    lines[2] = thirdLine;

        //    return lines;
        //}

        //private Line[] DrawConnectionLine15(double x1, double y1, double x2, double y2)
        //{
        //    double distanceBetweenTwoPoints = y1 - y2;
        //    BrushConverter color = new();
        //    Line[] lines = new Line[5];

        //    Line firstLine = new();
        //    firstLine.X1 = x1;
        //    firstLine.Y1 = y1;
        //    firstLine.X2 = x1;
        //    firstLine.Y2 = y1 + valueOffsetOfLineFromTheBlockToSides;
        //    firstLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
        //    listLineConnection.Add(firstLine);
        //    editField.Children.Add(firstLine);
        //    lines[0] = firstLine;

        //    Line secondLine = new();
        //    secondLine.X1 = x2;
        //    secondLine.Y1 = y2 + valueOffsetOfLineFromTheBlockToSides;
        //    secondLine.X2 = x2 + DefaultPropertyForBlock.width / 2 + valueOffsetOfLineFromTheBlockToSides;
        //    secondLine.Y2 = y2 + valueOffsetOfLineFromTheBlockToSides;
        //    secondLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
        //    listLineConnection.Add(secondLine);
        //    editField.Children.Add(secondLine);
        //    lines[1] = secondLine;

        //    Line thirdLine = new();
        //    thirdLine.X1 = x2 + DefaultPropertyForBlock.width / 2 + valueOffsetOfLineFromTheBlockToSides;
        //    thirdLine.Y1 = y2 + valueOffsetOfLineFromTheBlockToSides;
        //    thirdLine.X2 = x2 + DefaultPropertyForBlock.width / 2 + valueOffsetOfLineFromTheBlockToSides;
        //    thirdLine.Y2 = y2 + valueOffsetOfLineFromTheBlockToSides + distanceBetweenTwoPoints;
        //    thirdLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
        //    listLineConnection.Add(thirdLine);
        //    editField.Children.Add(thirdLine);
        //    lines[2] = thirdLine;

        //    Line fourthLine = new();
        //    fourthLine.X1 = x2 + DefaultPropertyForBlock.width / 2 + valueOffsetOfLineFromTheBlockToSides;
        //    fourthLine.Y1 = y2 + valueOffsetOfLineFromTheBlockToSides + distanceBetweenTwoPoints;
        //    fourthLine.X2 = x1;
        //    fourthLine.Y2 = y1 + valueOffsetOfLineFromTheBlockToSides;
        //    fourthLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
        //    listLineConnection.Add(fourthLine);
        //    editField.Children.Add(fourthLine);
        //    lines[3] = thirdLine;

        //    Line fifthLine = new();
        //    fifthLine.X2 = x2;
        //    fifthLine.Y1 = y2;
        //    fifthLine.X1 = x2;
        //    fifthLine.Y2 = y2 + valueOffsetOfLineFromTheBlockToSides;
        //    fifthLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
        //    listLineConnection.Add(fifthLine);
        //    editField.Children.Add(fifthLine);
        //    lines[4] = fifthLine;

        //    return lines;
        //}

        //private Line[] DrawConnectionLine16(double x1, double y1, double x2, double y2)
        //{
        //    BrushConverter color = new();
        //    Line[] lines = new Line[5];
        //    double distanceBetweenTwoPoints = y1 - y2;

        //    Line firstLine = new();
        //    firstLine.X1 = x2;
        //    firstLine.Y1 = y2;
        //    firstLine.X2 = x2;
        //    firstLine.Y2 = y2 + distanceBetweenTwoPoints + valueOffsetOfLineFromTheBlockToSides;
        //    firstLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
        //    listLineConnection.Add(firstLine);
        //    editField.Children.Add(firstLine);
        //    lines[0] = firstLine;

        //    Line secondLine = new();
        //    secondLine.X1 = x2;
        //    secondLine.Y1 = y2 + distanceBetweenTwoPoints + valueOffsetOfLineFromTheBlockToSides;
        //    secondLine.X2 = x1;
        //    secondLine.Y2 = y1 + valueOffsetOfLineFromTheBlockToSides;
        //    secondLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
        //    listLineConnection.Add(secondLine);
        //    editField.Children.Add(secondLine);
        //    lines[1] = secondLine;

        //    Line thirdLine = new();
        //    thirdLine.X1 = x1;
        //    thirdLine.Y1 = y1;
        //    thirdLine.X2 = x1;
        //    thirdLine.Y2 = y1 + valueOffsetOfLineFromTheBlockToSides;
        //    thirdLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
        //    listLineConnection.Add(thirdLine);
        //    editField.Children.Add(thirdLine);
        //    lines[2] = thirdLine;

        //    return lines;
        //}

        //private Line[] DrawConnectionLine17(double x1, double y1, double x2, double y2)
        //{
        //    BrushConverter color = new();
        //    Line[] lines = new Line[5];

        //    Line firstLine = new();
        //    firstLine.X1 = x1;
        //    firstLine.Y1 = y1;
        //    firstLine.X2 = x1;
        //    firstLine.Y2 = y1 + valueOffsetOfLineFromTheBlockToSides;
        //    firstLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
        //    listLineConnection.Add(firstLine);
        //    editField.Children.Add(firstLine);
        //    lines[0] = firstLine;

        //    Line secondLine = new();
        //    secondLine.X1 = x2 + valueOffsetOfLineFromTheBlockToSides;
        //    secondLine.Y1 = y1 + valueOffsetOfLineFromTheBlockToSides;
        //    secondLine.X2 = x1;
        //    secondLine.Y2 = y1 + valueOffsetOfLineFromTheBlockToSides;
        //    secondLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
        //    listLineConnection.Add(secondLine);
        //    editField.Children.Add(secondLine);
        //    lines[1] = secondLine;

        //    Line thirdLine = new();
        //    thirdLine.X1 = x2 + valueOffsetOfLineFromTheBlockToSides;
        //    thirdLine.Y1 = y1 + valueOffsetOfLineFromTheBlockToSides;
        //    thirdLine.X2 = x2 + valueOffsetOfLineFromTheBlockToSides;
        //    thirdLine.Y2 = y2;
        //    thirdLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
        //    listLineConnection.Add(thirdLine);
        //    editField.Children.Add(thirdLine);
        //    lines[2] = thirdLine;

        //    Line fourthLine = new();
        //    fourthLine.X1 = x2;
        //    fourthLine.Y1 = y2;
        //    fourthLine.X2 = x2 + valueOffsetOfLineFromTheBlockToSides;
        //    fourthLine.Y2 = y2;
        //    fourthLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
        //    listLineConnection.Add(fourthLine);
        //    editField.Children.Add(fourthLine);
        //    lines[3] = fourthLine;

        //    return lines;
        //}

        //private Line[] DrawConnectionLine18(double x1, double y1, double x2, double y2)
        //{
        //    BrushConverter color = new();
        //    Line[] lines = new Line[5];
        //    Line firstLine = new();
        //    double distanceBetweenTwoPoints = x2 - x1;
        //    firstLine.X1 = x1;
        //    firstLine.Y1 = y1;
        //    firstLine.X2 = x1 + valueOffsetOfLineFromTheBlockToSides;
        //    firstLine.Y2 = y1;
        //    firstLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
        //    listLineConnection.Add(firstLine);
        //    editField.Children.Add(firstLine);
        //    lines[0] = firstLine;

        //    Line secondLine = new();
        //    secondLine.X1 = x1 + valueOffsetOfLineFromTheBlockToSides;
        //    secondLine.Y1 = y1;
        //    secondLine.X2 = x2 - distanceBetweenTwoPoints + valueOffsetOfLineFromTheBlockToSides;
        //    secondLine.Y2 = y2;
        //    secondLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
        //    listLineConnection.Add(secondLine);
        //    editField.Children.Add(secondLine);
        //    lines[1] = secondLine;

        //    Line thirdLine = new();
        //    thirdLine.X1 = x2;
        //    thirdLine.Y1 = y2;
        //    thirdLine.X2 = x2 - distanceBetweenTwoPoints + valueOffsetOfLineFromTheBlockToSides;
        //    thirdLine.Y2 = y2;
        //    thirdLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
        //    listLineConnection.Add(thirdLine);
        //    editField.Children.Add(thirdLine);
        //    lines[2] = thirdLine;

        //    return lines;
        //}

        //private Line[] DrawConnectionLine20(double x1, double y1, double x2, double y2)
        //{
        //    BrushConverter color = new();
        //    Line[] lines = new Line[5];

        //    Line firstLine = new();
        //    firstLine.X1 = x1;
        //    firstLine.Y1 = y1;
        //    firstLine.X2 = x1 + valueOffsetOfLineFromTheBlockToSides;
        //    firstLine.Y2 = y1;
        //    firstLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
        //    listLineConnection.Add(firstLine);
        //    editField.Children.Add(firstLine);
        //    lines[0] = firstLine;

        //    Line secondLine = new();
        //    secondLine.X1 = x1 + valueOffsetOfLineFromTheBlockToSides;
        //    secondLine.Y1 = y1;
        //    secondLine.X2 = x1 + valueOffsetOfLineFromTheBlockToSides;
        //    secondLine.Y2 = y2 + DefaultPropertyForBlock.height / 2 + valueOffsetOfLineFromTheBlockToSides;
        //    secondLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
        //    listLineConnection.Add(secondLine);
        //    editField.Children.Add(secondLine);
        //    lines[1] = secondLine;

        //    Line thirdLine = new();
        //    thirdLine.X1 = x1 + valueOffsetOfLineFromTheBlockToSides;
        //    thirdLine.Y1 = y2 + DefaultPropertyForBlock.height / 2 + valueOffsetOfLineFromTheBlockToSides;
        //    thirdLine.X2 = x2 + valueOffsetOfLineFromTheBlockToSides;
        //    thirdLine.Y2 = y2 + DefaultPropertyForBlock.height / 2 + valueOffsetOfLineFromTheBlockToSides;
        //    thirdLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
        //    listLineConnection.Add(thirdLine);
        //    editField.Children.Add(thirdLine);
        //    lines[2] = thirdLine;

        //    Line fourthLine = new();
        //    fourthLine.X1 = x2 + valueOffsetOfLineFromTheBlockToSides;
        //    fourthLine.Y1 = y2 + DefaultPropertyForBlock.height / 2 + valueOffsetOfLineFromTheBlockToSides;
        //    fourthLine.X2 = x2 + valueOffsetOfLineFromTheBlockToSides;
        //    fourthLine.Y2 = y2;
        //    fourthLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
        //    listLineConnection.Add(fourthLine);
        //    editField.Children.Add(fourthLine);
        //    lines[3] = fourthLine;

        //    Line fifthLine = new();
        //    fifthLine.X2 = x2;
        //    fifthLine.Y1 = y2;
        //    fifthLine.X1 = x2 + valueOffsetOfLineFromTheBlockToSides;
        //    fifthLine.Y2 = y2;
        //    fifthLine.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
        //    listLineConnection.Add(fifthLine);
        //    editField.Children.Add(fifthLine);
        //    lines[4] = fifthLine;

        //    return lines;
        //}

    }
            }
