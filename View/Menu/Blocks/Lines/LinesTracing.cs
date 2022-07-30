namespace Flowchart_Editor.View.Lines
{
    public class LinesTracing
    {
        //public void ChangeLine1(Line[] masLine, double x1, double y1, double x2, double y2)
        //{
        //    int i = 0;
        //    double distanceBetweenTwoPoints = y2 - y1;
        //    BrushConverter color = new();
        //    foreach (Line line in masLine)
        //    {
        //        if (i == 0)
        //        {
        //            line.Y1 = y1 + distanceBetweenTwoPoints / 2;
        //            line.X1 = x2;
        //            line.Y2 = y2;
        //            line.X2 = x2;
        //            editField.Children.Remove(line);
        //            editField.Children.Add(line);
        //        }
        //        if (i == 1)
        //        {
        //            line.X1 = x1;
        //            line.Y1 = y1 + distanceBetweenTwoPoints / 2;
        //            line.X2 = x2;
        //            line.Y2 = y1 + distanceBetweenTwoPoints / 2;
        //            editField.Children.Remove(line);
        //            editField.Children.Add(line);
        //        }
        //        if (i == 2)
        //        {
        //            if (line == null)
        //            {
        //                Line lineConnection = new();
        //                lineConnection.Y1 = y1;
        //                lineConnection.X1 = x1;
        //                lineConnection.Y2 = y2 - distanceBetweenTwoPoints / 2;
        //                lineConnection.X2 = x1;
        //                lineConnection.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
        //                listLineConnection.Add(lineConnection);
        //                editField.Children.Remove(lineConnection);
        //                editField.Children.Add(lineConnection);
        //                masLine[i] = lineConnection;
        //            }
        //            else
        //            {
        //                line.Y1 = y1;
        //                line.X1 = x1;
        //                line.Y2 = y2 - distanceBetweenTwoPoints / 2;
        //                line.X2 = x1;
        //                editField.Children.Remove(line);
        //                editField.Children.Add(line);
        //            }
        //        }
        //        if (i == 3)
        //        {
        //            if (line != null)
        //                editField.Children.Remove(line);
        //        }
        //        if (i == 4)
        //        {
        //            if (line != null)
        //                editField.Children.Remove(line);
        //        }
        //        i++;
        //    }
        //}
        //public void ChangeLine2(Line[] masLine, double x1, double y1, double x2, double y2)
        //{
        //    int i = 0;
        //    BrushConverter color = new();
        //    foreach (Line line in masLine)
        //    {
        //        if (i == 0)
        //        {
        //            line.X2 = x2;
        //            line.Y1 = y2;
        //            line.X1 = x2;
        //            line.Y2 = y2 + valueOffsetOfLineFromTheBlockToSides;
        //            editField.Children.Remove(line);
        //            editField.Children.Add(line);
        //        }
        //        if (i == 1)
        //        {
        //            line.X1 = x1;
        //            line.X2 = x1;
        //            line.Y1 = y1 - valueOffsetOfLineFromTheBlockToSides;
        //            line.Y2 = y1;
        //            editField.Children.Remove(line);
        //            editField.Children.Add(line);
        //        }
        //        if (i == 2)
        //        {
        //            line.X2 = x1;
        //            line.Y1 = y1 - valueOffsetOfLineFromTheBlockToSides;
        //            line.Y2 = y1 - valueOffsetOfLineFromTheBlockToSides;
        //            line.X1 = x1 + DefaultPropertyForBlock.width / 2 + valueOffsetOfLineFromTheBlockToSides;
        //            editField.Children.Remove(line);
        //            editField.Children.Add(line);
        //        }
        //        if (i == 3)
        //        {
        //            if (line == null)
        //            {
        //                Line lineConnection = new();
        //                lineConnection.Y1 = y1 - valueOffsetOfLineFromTheBlockToSides;
        //                lineConnection.X1 = x1 + DefaultPropertyForBlock.width / 2 + valueOffsetOfLineFromTheBlockToSides;
        //                lineConnection.Y2 = y2 + valueOffsetOfLineFromTheBlockToSides;
        //                lineConnection.X2 = x1 + DefaultPropertyForBlock.width / 2 + valueOffsetOfLineFromTheBlockToSides;
        //                lineConnection.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
        //                listLineConnection.Add(lineConnection);
        //                editField.Children.Remove(lineConnection);
        //                editField.Children.Add(lineConnection);
        //                masLine[i] = lineConnection;
        //            }
        //            else
        //            {

        //                line.Y1 = y1 - valueOffsetOfLineFromTheBlockToSides;
        //                line.X1 = x1 + DefaultPropertyForBlock.width / 2 + valueOffsetOfLineFromTheBlockToSides;
        //                line.Y2 = y2 + valueOffsetOfLineFromTheBlockToSides;
        //                line.X2 = x1 + DefaultPropertyForBlock.width / 2 + valueOffsetOfLineFromTheBlockToSides;
        //                editField.Children.Remove(line);
        //                editField.Children.Add(line);

        //            }
        //        }
        //        if (i == 4)
        //        {
        //            if (line == null)
        //            {
        //                Line lineConnection = new();
        //                lineConnection.X1 = x2;
        //                lineConnection.Y1 = y2 + valueOffsetOfLineFromTheBlockToSides;
        //                lineConnection.X2 = x1 + DefaultPropertyForBlock.width / 2 + valueOffsetOfLineFromTheBlockToSides;
        //                lineConnection.Y2 = y2 + valueOffsetOfLineFromTheBlockToSides;
        //                lineConnection.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
        //                listLineConnection.Add(lineConnection);
        //                editField.Children.Remove(lineConnection);
        //                editField.Children.Add(lineConnection);
        //                masLine[i] = lineConnection;
        //            }
        //            else
        //            {
        //                line.X1 = x2;
        //                line.Y1 = y2 + valueOffsetOfLineFromTheBlockToSides;
        //                line.X2 = x1 + DefaultPropertyForBlock.width / 2 + valueOffsetOfLineFromTheBlockToSides;
        //                line.Y2 = y2 + valueOffsetOfLineFromTheBlockToSides;
        //                editField.Children.Remove(line);
        //                editField.Children.Add(line);
        //            }
        //        }
        //        i++;
        //    }
        //}

        //public void ChangeLine3(Line[] masLine, double x1, double y1, double x2, double y2)
        //{
        //    int i = 0;
        //    double distanceBetweenTwoPoints = y2 - y1;
        //    BrushConverter color = new();
        //    foreach (Line line in masLine)
        //    {
        //        if (i == 0)
        //        {
        //            line.X1 = x2;
        //            line.Y1 = y2;
        //            line.X2 = x2 + valueOffsetOfLineFromTheBlockToSides;
        //            line.Y2 = y2;
        //            editField.Children.Remove(line);
        //            editField.Children.Add(line);
        //        }
        //        if (i == 1)
        //        {
        //            line.X1 = x2 + valueOffsetOfLineFromTheBlockToSides;
        //            line.Y1 = y2;
        //            line.X2 = x2 + valueOffsetOfLineFromTheBlockToSides;
        //            line.Y2 = y2 - distanceBetweenTwoPoints - valueOffsetOfLineFromTheBlockToSides;
        //            editField.Children.Remove(line);
        //            editField.Children.Add(line);
        //        }
        //        if (i == 2)
        //        {
        //            if (line == null)
        //            {
        //                Line lineConnection = new();
        //                lineConnection.X1 = x1;
        //                lineConnection.Y1 = y1 - valueOffsetOfLineFromTheBlockToSides;
        //                lineConnection.X2 = x2 + valueOffsetOfLineFromTheBlockToSides;
        //                lineConnection.Y2 = y2 - distanceBetweenTwoPoints - valueOffsetOfLineFromTheBlockToSides;
        //                lineConnection.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
        //                listLineConnection.Add(lineConnection);
        //                editField.Children.Remove(lineConnection);
        //                editField.Children.Add(lineConnection);
        //                masLine[i] = lineConnection;
        //            }
        //            else
        //            {
        //                line.X1 = x1;
        //                line.Y1 = y1 - valueOffsetOfLineFromTheBlockToSides;
        //                line.X2 = x2 + valueOffsetOfLineFromTheBlockToSides;
        //                line.Y2 = y2 - distanceBetweenTwoPoints - valueOffsetOfLineFromTheBlockToSides;
        //                editField.Children.Remove(line);
        //                editField.Children.Add(line);
        //            }
        //        }
        //        if (i == 3)
        //        {
        //            if (line == null)
        //            {
        //                Line lineConnection = new();
        //                lineConnection.X1 = x1;
        //                lineConnection.Y1 = y1;
        //                lineConnection.X2 = x1;
        //                lineConnection.Y2 = y1 - valueOffsetOfLineFromTheBlockToSides;
        //                lineConnection.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
        //                listLineConnection.Add(lineConnection);
        //                editField.Children.Remove(lineConnection);
        //                editField.Children.Add(lineConnection);
        //                masLine[i] = lineConnection;
        //            }
        //            else
        //            {
        //                line.X1 = x1;
        //                line.Y1 = y1;
        //                line.X2 = x1;
        //                line.Y2 = y1 - valueOffsetOfLineFromTheBlockToSides;
        //                editField.Children.Remove(line);
        //                editField.Children.Add(line);
        //            }
        //        }
        //        i++;
        //    }
        //}

        //public void MessageThisLineIsAlreadyOccupied() =>
        //    MessageBox.Show("Эта линия уже занята");

        //public void RemoveBlockFormList(Block block) => listOfBlock.Remove(block);

        //public void ChangeLine4(Line[] masLine, double x1, double y1, double x2, double y2)
        //{
        //    int i = 0;
        //    foreach (Line line in masLine)
        //    {
        //        if (i == 0)
        //        {
        //            line.X1 = x2;
        //            line.Y1 = y2;
        //            line.X2 = x1;
        //            line.Y2 = y2;
        //            editField.Children.Remove(line);
        //            editField.Children.Add(line);
        //        }
        //        if (i == 1)
        //        {
        //            line.X1 = x1;
        //            line.Y1 = y2;
        //            line.X2 = x1;
        //            line.Y2 = y1;
        //            editField.Children.Remove(line);
        //            editField.Children.Add(line);
        //        }
        //        if (i == 2)
        //        {
        //            editField.Children.Remove(line);
        //        }
        //        if (i == 3)
        //        {
        //            editField.Children.Remove(line);
        //        }
        //        i++;
        //    }
        //}
        //public void ChangeLine5(Line[] masLine, double x1, double y1, double x2, double y2)
        //{
        //    double distanceBetweenTwoPoints = x1 - x2;
        //    int i = 0;
        //    BrushConverter color = new();
        //    foreach (Line line in masLine)
        //    {
        //        if (i == 0)
        //        {
        //            line.X1 = x1;
        //            line.Y1 = y1;
        //            line.X2 = x1;
        //            line.Y2 = y1 - valueOffsetOfLineFromTheBlockToSides;
        //            editField.Children.Remove(line);
        //            editField.Children.Add(line);
        //        }
        //        if (i == 1)
        //        {
        //            line.X1 = x1;
        //            line.Y1 = y1 - valueOffsetOfLineFromTheBlockToSides;
        //            line.X2 = x1 - distanceBetweenTwoPoints + valueOffsetOfLineFromTheBlockToSides;
        //            line.Y2 = y1 - valueOffsetOfLineFromTheBlockToSides;
        //            editField.Children.Remove(line);
        //            editField.Children.Add(line);
        //        }
        //        if (i == 2)
        //        {
        //            if (line == null)
        //            {
        //                Line lineConnection = new();
        //                lineConnection.X1 = x2;
        //                lineConnection.Y1 = y2;
        //                lineConnection.X2 = x2 + valueOffsetOfLineFromTheBlockToSides;
        //                lineConnection.Y2 = y1;
        //                lineConnection.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
        //                listLineConnection.Add(lineConnection);

        //                editField.Children.Remove(lineConnection);
        //                editField.Children.Add(lineConnection);
        //                masLine[i] = lineConnection;
        //            }
        //            else
        //            {
        //                line.X1 = x2;
        //                line.Y1 = y2;
        //                line.X2 = x2 + valueOffsetOfLineFromTheBlockToSides;
        //                line.Y2 = y2;
        //                editField.Children.Remove(line);
        //                editField.Children.Add(line);
        //            }
        //        }
        //        if (i == 3)
        //        {
        //            if (line == null)
        //            {
        //                Line lineConnection = new();
        //                lineConnection.X1 = x2 + valueOffsetOfLineFromTheBlockToSides;
        //                lineConnection.Y1 = y2;
        //                lineConnection.X2 = x2 + valueOffsetOfLineFromTheBlockToSides;
        //                lineConnection.Y2 = y1 - valueOffsetOfLineFromTheBlockToSides;
        //                lineConnection.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
        //                listLineConnection.Add(lineConnection);
        //                editField.Children.Remove(lineConnection);
        //                editField.Children.Add(lineConnection);
        //                masLine[i] = lineConnection;
        //            }
        //            else
        //            {
        //                line.X1 = x2 + valueOffsetOfLineFromTheBlockToSides;
        //                line.Y1 = y2;
        //                line.X2 = x2 + valueOffsetOfLineFromTheBlockToSides;
        //                line.Y2 = y1 - valueOffsetOfLineFromTheBlockToSides;
        //                editField.Children.Remove(line);
        //                editField.Children.Add(line);
        //            }
        //        }
        //        i++;
        //    }

        //}
        //public void ChangeLine6(Line[] masLine, double x1, double y1, double x2, double y2)
        //{
        //    double distanceBetweenTwoPoints = y1 - y2;
        //    int i = 0;
        //    BrushConverter color = new();
        //    foreach (Line line in masLine)
        //    {
        //        if (i == 0)
        //        {
        //            line.X1 = x1;
        //            line.Y1 = y1;
        //            line.X2 = x1;
        //            line.Y2 = y1 - valueOffsetOfLineFromTheBlockToSides;
        //        }
        //        if (i == 1)
        //        {
        //            line.X1 = x2;
        //            line.Y1 = y2 - valueOffsetOfLineFromTheBlockToSides;
        //            line.X2 = x2 + DefaultPropertyForBlock.width / 2 + valueOffsetOfLineFromTheBlockToSides;
        //            line.Y2 = y2 - valueOffsetOfLineFromTheBlockToSides;
        //        }
        //        if (i == 2)
        //        {
        //            line.X1 = x2 + DefaultPropertyForBlock.width / 2 + valueOffsetOfLineFromTheBlockToSides;
        //            line.Y1 = y2 - valueOffsetOfLineFromTheBlockToSides;
        //            line.X2 = x2 + DefaultPropertyForBlock.width / 2 + valueOffsetOfLineFromTheBlockToSides;
        //            line.Y2 = y2 - valueOffsetOfLineFromTheBlockToSides + distanceBetweenTwoPoints;
        //        }
        //        if (i == 3)
        //        {
        //            if (line == null)
        //            {
        //                Line lineConnection = new();
        //                lineConnection.X1 = x2 + DefaultPropertyForBlock.width / 2 + valueOffsetOfLineFromTheBlockToSides;
        //                lineConnection.Y1 = y2 - valueOffsetOfLineFromTheBlockToSides + distanceBetweenTwoPoints;
        //                lineConnection.X2 = x1;
        //                lineConnection.Y2 = y1 - valueOffsetOfLineFromTheBlockToSides;
        //                lineConnection.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
        //                listLineConnection.Add(lineConnection);
        //                editField.Children.Remove(lineConnection);
        //                editField.Children.Add(lineConnection);
        //                masLine[i] = lineConnection;
        //            }
        //            else
        //            {
        //                line.X1 = x2 + DefaultPropertyForBlock.width / 2 + valueOffsetOfLineFromTheBlockToSides;
        //                line.Y1 = y2 - valueOffsetOfLineFromTheBlockToSides + distanceBetweenTwoPoints;
        //                line.X2 = x1;
        //                line.Y2 = y1 - valueOffsetOfLineFromTheBlockToSides;
        //                editField.Children.Remove(line);
        //                editField.Children.Add(line);
        //            }
        //        }
        //        if (i == 4)
        //        {
        //            if (line == null)
        //            {
        //                Line lineConnection = new();
        //                lineConnection.X2 = x2;
        //                lineConnection.Y1 = y2;
        //                lineConnection.X1 = x2;
        //                lineConnection.Y2 = y2 - valueOffsetOfLineFromTheBlockToSides;
        //                lineConnection.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
        //                listLineConnection.Add(lineConnection);
        //                editField.Children.Remove(lineConnection);
        //                editField.Children.Add(lineConnection);
        //                masLine[i] = lineConnection;
        //            }
        //            else
        //            {
        //                line.X2 = x2;
        //                line.Y1 = y2;
        //                line.X1 = x2;
        //                line.Y2 = y2 - valueOffsetOfLineFromTheBlockToSides;
        //                editField.Children.Remove(line);
        //                editField.Children.Add(line);
        //            }
        //        }
        //        i++;
        //    }
        //}
        //public void ChangeLine7(Line[] masLine, double x1, double y1, double x2, double y2)
        //{
        //    int i = 0;
        //    foreach (Line line in masLine)
        //    {
        //        if (i == 0)
        //        {
        //            line.X1 = x2;
        //            line.Y1 = y2;
        //            line.X2 = x2;
        //            line.Y2 = y2 - valueOffsetOfLineFromTheBlockToSides;
        //        }
        //        if (i == 1)
        //        {
        //            line.X1 = x2;
        //            line.Y1 = y2 - valueOffsetOfLineFromTheBlockToSides;
        //            line.X2 = x1;
        //            line.Y2 = y2 - valueOffsetOfLineFromTheBlockToSides;
        //        }
        //        if (i == 2)
        //        {
        //            line.X1 = x1;
        //            line.Y1 = y2 - valueOffsetOfLineFromTheBlockToSides;
        //            line.X2 = x1;
        //            line.Y2 = y1;
        //        }
        //        if (i == 3)
        //        {
        //            editField.Children.Remove(line);
        //        }
        //        if (i == 4)
        //        {
        //            editField.Children.Remove(line);

        //        }
        //        i++;
        //    }
        //}
        //public void ChangeLine8(Line[] masLine, double x1, double y1, double x2, double y2)
        //{
        //    int i = 0;
        //    double distanceBetweenTwoPoints = y2 - y1;
        //    BrushConverter color = new();
        //    foreach (Line line in masLine)
        //    {
        //        if (i == 0)
        //        {
        //            line.X1 = x2;
        //            line.Y1 = y2;
        //            line.X2 = x2 - valueOffsetOfLineFromTheBlockToSides;
        //            line.Y2 = y2;
        //            editField.Children.Remove(line);
        //            editField.Children.Add(line);
        //        }
        //        if (i == 1)
        //        {
        //            line.X1 = x2 - valueOffsetOfLineFromTheBlockToSides;
        //            line.Y1 = y2;
        //            line.X2 = x2 - valueOffsetOfLineFromTheBlockToSides;
        //            line.Y2 = y2 - distanceBetweenTwoPoints - valueOffsetOfLineFromTheBlockToSides;
        //            editField.Children.Remove(line);
        //            editField.Children.Add(line);
        //        }
        //        if (i == 2)
        //        {
        //            if (line == null)
        //            {
        //                Line lineConnection = new();
        //                lineConnection.X1 = x1;
        //                lineConnection.Y1 = y1 - valueOffsetOfLineFromTheBlockToSides;
        //                lineConnection.X2 = x2 - valueOffsetOfLineFromTheBlockToSides;
        //                lineConnection.Y2 = y2 - distanceBetweenTwoPoints - valueOffsetOfLineFromTheBlockToSides;
        //                lineConnection.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
        //                listLineConnection.Add(lineConnection);
        //                editField.Children.Remove(lineConnection);
        //                editField.Children.Add(lineConnection);
        //                masLine[i] = lineConnection;
        //            }
        //            else
        //            {
        //                line.X1 = x1;
        //                line.Y1 = y1 - valueOffsetOfLineFromTheBlockToSides;
        //                line.X2 = x2 - valueOffsetOfLineFromTheBlockToSides;
        //                line.Y2 = y2 - distanceBetweenTwoPoints - valueOffsetOfLineFromTheBlockToSides;
        //                line.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
        //                editField.Children.Remove(line);
        //                editField.Children.Add(line);
        //            }
        //        }
        //        if (i == 3)
        //        {
        //            if (line == null)
        //            {
        //                Line lineConnection = new();
        //                lineConnection.X1 = x1;
        //                lineConnection.Y1 = y1;
        //                lineConnection.X2 = x1;
        //                lineConnection.Y2 = y1 - valueOffsetOfLineFromTheBlockToSides;
        //                lineConnection.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
        //                listLineConnection.Add(lineConnection);
        //                editField.Children.Remove(lineConnection);
        //                editField.Children.Add(lineConnection);
        //                masLine[i] = lineConnection;
        //            }
        //            else
        //            {
        //                line.X1 = x1;
        //                line.Y1 = y1;
        //                line.X2 = x1;
        //                line.Y2 = y1 - valueOffsetOfLineFromTheBlockToSides;
        //                line.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
        //                editField.Children.Remove(line);
        //                editField.Children.Add(line);
        //            }
        //        }
        //        i++;
        //    }
        //}
        //public void ChangeLine9(Line[] masLine, double x1, double y1, double x2, double y2)
        //{
        //    int i = 0;
        //    foreach (Line line in masLine)
        //    {
        //        if (i == 0)
        //        {
        //            line.X1 = x1;
        //            line.Y1 = y1;
        //            line.X2 = x1 - valueOffsetOfLineFromTheBlockToSides;
        //            line.Y2 = y1;
        //        }
        //        if (i == 1)
        //        {
        //            line.X1 = x1 - valueOffsetOfLineFromTheBlockToSides;
        //            line.Y1 = y1;
        //            line.X2 = x1 - valueOffsetOfLineFromTheBlockToSides;
        //            line.Y2 = y2;
        //        }
        //        if (i == 2)
        //        {
        //            line.X1 = x1 - valueOffsetOfLineFromTheBlockToSides;
        //            line.Y1 = y2;
        //            line.X2 = x2;
        //            line.Y2 = y2;
        //        }
        //        if (i == 3)
        //        {
        //            editField.Children.Remove(line);
        //        }
        //        if (i == 4)
        //        {
        //            editField.Children.Remove(line);
        //        }
        //        i++;
        //    }
        //}
        //public void ChangeLine10(Line[] masLine, double x1, double y1, double x2, double y2)
        //{
        //    int i = 0;
        //    BrushConverter color = new();
        //    foreach (Line line in masLine)
        //    {
        //        if (i == 0)
        //        {
        //            line.X1 = x1;
        //            line.Y1 = y1;
        //            line.X2 = x1 - valueOffsetOfLineFromTheBlockToSides;
        //            line.Y2 = y1;
        //            editField.Children.Remove(line);
        //            editField.Children.Add(line);
        //        }
        //        if (i == 1)
        //        {
        //            line.X1 = x1 - valueOffsetOfLineFromTheBlockToSides;
        //            line.Y1 = y1;
        //            line.X2 = x1 - valueOffsetOfLineFromTheBlockToSides;
        //            line.Y2 = y2 + DefaultPropertyForBlock.height / 2 + valueOffsetOfLineFromTheBlockToSides;
        //            editField.Children.Remove(line);
        //            editField.Children.Add(line);
        //        }
        //        if (i == 2)
        //        {
        //            line.X1 = x1 - valueOffsetOfLineFromTheBlockToSides;
        //            line.Y1 = y2 + DefaultPropertyForBlock.height / 2 + valueOffsetOfLineFromTheBlockToSides;
        //            line.X2 = x2 - valueOffsetOfLineFromTheBlockToSides;
        //            line.Y2 = y2 + DefaultPropertyForBlock.height / 2 + valueOffsetOfLineFromTheBlockToSides;
        //            editField.Children.Remove(line);
        //            editField.Children.Add(line);
        //        }
        //        if (i == 3)
        //        {
        //            if (line == null)
        //            {
        //                Line lineConnection = new();
        //                lineConnection.X1 = x2 - valueOffsetOfLineFromTheBlockToSides;
        //                lineConnection.Y1 = y2 + DefaultPropertyForBlock.height / 2 + valueOffsetOfLineFromTheBlockToSides;
        //                lineConnection.X2 = x2 - valueOffsetOfLineFromTheBlockToSides;
        //                lineConnection.Y2 = y2;
        //                lineConnection.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
        //                listLineConnection.Add(lineConnection);
        //                editField.Children.Remove(lineConnection);
        //                editField.Children.Add(lineConnection);
        //                masLine[i] = lineConnection;
        //            }
        //            else
        //            {
        //                line.X1 = x2 - valueOffsetOfLineFromTheBlockToSides;
        //                line.Y1 = y2 + DefaultPropertyForBlock.height / 2 + valueOffsetOfLineFromTheBlockToSides;
        //                line.X2 = x2 - valueOffsetOfLineFromTheBlockToSides;
        //                line.Y2 = y2;
        //                editField.Children.Remove(line);
        //                editField.Children.Add(line);
        //            }
        //        }
        //        if (i == 4)
        //        {
        //            if (line == null)
        //            {
        //                Line lineConnection = new();
        //                lineConnection.X2 = x2;
        //                lineConnection.Y1 = y2;
        //                lineConnection.X1 = x2 - valueOffsetOfLineFromTheBlockToSides;
        //                lineConnection.Y2 = y2;
        //                lineConnection.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
        //                listLineConnection.Add(lineConnection);
        //                editField.Children.Remove(lineConnection);
        //                editField.Children.Add(lineConnection);
        //                masLine[i] = lineConnection;
        //            }
        //            else
        //            {
        //                line.X2 = x2;
        //                line.Y1 = y2;
        //                line.X1 = x2 - valueOffsetOfLineFromTheBlockToSides;
        //                line.Y2 = y2;
        //                editField.Children.Remove(line);
        //                editField.Children.Add(line);
        //            }
        //        }
        //        i++;
        //    }
        //}
        //public void ChangeLine11(Line[] masLine, double x1, double y1, double x2, double y2)
        //{
        //    int i = 0;
        //    BrushConverter color = new();
        //    foreach (Line line in masLine)
        //    {
        //        if (i == 0)
        //        {
        //            line.X1 = x2;
        //            line.Y1 = y2;
        //            line.X2 = x2 - valueOffsetOfLineFromTheBlockToSides;
        //            line.Y2 = y2;
        //        }
        //        if (i == 1)
        //        {
        //            line.X1 = x2 - valueOffsetOfLineFromTheBlockToSides;
        //            line.Y1 = y2;
        //            line.X2 = x2 - valueOffsetOfLineFromTheBlockToSides;
        //            line.Y2 = y1 + valueOffsetOfLineFromTheBlockToSides;
        //        }
        //        if (i == 2)
        //        {
        //            if (line == null)
        //            {
        //                Line lineConnection = new();
        //                lineConnection.X1 = x2 - valueOffsetOfLineFromTheBlockToSides;
        //                lineConnection.Y1 = y1 + valueOffsetOfLineFromTheBlockToSides;
        //                lineConnection.X2 = x1;
        //                lineConnection.Y2 = y1 + valueOffsetOfLineFromTheBlockToSides;
        //                lineConnection.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
        //                listLineConnection.Add(lineConnection);
        //                editField.Children.Remove(lineConnection);
        //                editField.Children.Add(lineConnection);
        //                masLine[i] = lineConnection;
        //            }
        //            else
        //            {
        //                line.X1 = x2 - valueOffsetOfLineFromTheBlockToSides;
        //                line.Y1 = y1 + valueOffsetOfLineFromTheBlockToSides;
        //                line.X2 = x1;
        //                line.Y2 = y1 + valueOffsetOfLineFromTheBlockToSides;
        //                editField.Children.Remove(line);
        //                editField.Children.Add(line);
        //            }
        //        }
        //        if (i == 3)
        //        {
        //            if (line == null)
        //            {
        //                Line lineConnection = new();
        //                lineConnection.X1 = x1;
        //                lineConnection.Y1 = y1;
        //                lineConnection.X2 = x1;
        //                lineConnection.Y2 = y1 + valueOffsetOfLineFromTheBlockToSides;
        //                lineConnection.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
        //                listLineConnection.Add(lineConnection);
        //                editField.Children.Remove(lineConnection);
        //                editField.Children.Add(lineConnection);
        //                masLine[i] = lineConnection;
        //            }
        //            else
        //            {
        //                line.X1 = x1;
        //                line.Y1 = y1;
        //                line.X2 = x1;
        //                line.Y2 = y1 + valueOffsetOfLineFromTheBlockToSides;
        //                editField.Children.Remove(line);
        //                editField.Children.Add(line);
        //            }
        //        }
        //        i++;
        //    }
        //}

        //public void ChangeLine12(Line[] masLine, double x1, double y1, double x2, double y2)
        //{
        //    int i = 0;
        //    BrushConverter color = new();
        //    foreach (Line line in masLine)
        //    {
        //        if (i == 0)
        //        {
        //            line.X1 = x2;
        //            line.Y1 = y2;
        //            line.X2 = x2 - valueOffsetOfLineFromTheBlockToSides;
        //            line.Y2 = y2;
        //        }
        //        if (i == 1)
        //        {
        //            line.X1 = x2 - valueOffsetOfLineFromTheBlockToSides;
        //            line.Y1 = y2;
        //            line.X2 = x2 - valueOffsetOfLineFromTheBlockToSides;
        //            line.Y2 = y2 + DefaultPropertyForBlock.height / 2 + valueOffsetOfLineFromTheBlockToSides;
        //        }
        //        if (i == 2)
        //        {
        //            line.X1 = x2 - valueOffsetOfLineFromTheBlockToSides;
        //            line.Y1 = y2 + DefaultPropertyForBlock.height / 2 + valueOffsetOfLineFromTheBlockToSides;
        //            line.X2 = x1 + valueOffsetOfLineFromTheBlockToSides;
        //            line.Y2 = y2 + DefaultPropertyForBlock.height / 2 + valueOffsetOfLineFromTheBlockToSides;
        //        }
        //        if (i == 3)
        //        {
        //            if (line == null)
        //            {
        //                Line lineConnection = new();
        //                lineConnection.X1 = x1 + valueOffsetOfLineFromTheBlockToSides;
        //                lineConnection.Y1 = y1;
        //                lineConnection.X2 = x1 + valueOffsetOfLineFromTheBlockToSides;
        //                lineConnection.Y2 = y2 + DefaultPropertyForBlock.height / 2 + valueOffsetOfLineFromTheBlockToSides;
        //                lineConnection.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
        //                listLineConnection.Add(lineConnection);
        //                editField.Children.Remove(lineConnection);
        //                editField.Children.Add(lineConnection);
        //                masLine[i] = lineConnection;
        //            }
        //            else
        //            {
        //                line.X1 = x1 + valueOffsetOfLineFromTheBlockToSides;
        //                line.Y1 = y1;
        //                line.X2 = x1 + valueOffsetOfLineFromTheBlockToSides;
        //                line.Y2 = y2 + DefaultPropertyForBlock.height / 2 + valueOffsetOfLineFromTheBlockToSides;
        //                editField.Children.Remove(line);
        //                editField.Children.Add(line);
        //            }
        //        }
        //        if (i == 4)
        //        {
        //            if (line == null)
        //            {
        //                Line lineConnection = new();
        //                lineConnection.X2 = x1;
        //                lineConnection.Y1 = y1;
        //                lineConnection.X1 = x1 + valueOffsetOfLineFromTheBlockToSides;
        //                lineConnection.Y2 = y1;
        //                lineConnection.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
        //                listLineConnection.Add(lineConnection);
        //                editField.Children.Remove(lineConnection);
        //                editField.Children.Add(lineConnection);
        //                masLine[i] = lineConnection;
        //            }
        //            else
        //            {
        //                line.X2 = x1;
        //                line.Y1 = y1;
        //                line.X1 = x1 + valueOffsetOfLineFromTheBlockToSides;
        //                line.Y2 = y1;
        //                editField.Children.Remove(line);
        //                editField.Children.Add(line);
        //            }
        //        }
        //        i++;
        //    }
        //}
        //public void ChangeLine13(Line[] masLine, double x1, double y1, double x2, double y2)
        //{
        //    int i = 0;
        //    double distanceBetweenTwoPoints = x1 - x2;
        //    foreach (Line line in masLine)
        //    {
        //        if (i == 0)
        //        {
        //            line.X1 = x1;
        //            line.Y1 = y1;
        //            line.X2 = x1 - distanceBetweenTwoPoints / 2;
        //            line.Y2 = y1;
        //        }
        //        if (i == 1)
        //        {
        //            line.X1 = x1 - distanceBetweenTwoPoints / 2;
        //            line.Y1 = y1;
        //            line.X2 = x2 + distanceBetweenTwoPoints / 2;
        //            line.Y2 = y2;
        //        }
        //        if (i == 2)
        //        {
        //            line.X1 = x2;
        //            line.Y1 = y2;
        //            line.X2 = x2 + distanceBetweenTwoPoints / 2;
        //            line.Y2 = y2;
        //        }
        //        if (i == 3)
        //        {
        //            editField.Children.Remove(line);
        //        }
        //        if (i == 4)
        //        {
        //            editField.Children.Remove(line);
        //        }
        //        i++;
        //    }
        //}

        //public void ChangeLine14(Line[] masLine, double x1, double y1, double x2, double y2)
        //{
        //    int i = 0;
        //    double distanceBetweenTwoPoints = y1 - y2;
        //    BrushConverter color = new();
        //    foreach (Line line in masLine)
        //    {
        //        if (i == 0)
        //        {
        //            line.X1 = x1;
        //            line.Y1 = y1;
        //            line.X2 = x1;
        //            line.Y2 = y1 + valueOffsetOfLineFromTheBlockToSides;
        //            editField.Children.Remove(line);
        //            editField.Children.Add(line);
        //        }
        //        if (i == 1)
        //        {
        //            line.X1 = x2;
        //            line.Y1 = y2 + valueOffsetOfLineFromTheBlockToSides;
        //            line.X2 = x2 + DefaultPropertyForBlock.width / 2 + valueOffsetOfLineFromTheBlockToSides;
        //            line.Y2 = y2 + valueOffsetOfLineFromTheBlockToSides;
        //            editField.Children.Remove(line);
        //            editField.Children.Add(line);
        //        }
        //        if (i == 2)
        //        {
        //            line.X1 = x2 + DefaultPropertyForBlock.width / 2 + valueOffsetOfLineFromTheBlockToSides;
        //            line.Y1 = y2 + valueOffsetOfLineFromTheBlockToSides;
        //            line.X2 = x2 + DefaultPropertyForBlock.width / 2 + valueOffsetOfLineFromTheBlockToSides;
        //            line.Y2 = y2 + valueOffsetOfLineFromTheBlockToSides + distanceBetweenTwoPoints;
        //            editField.Children.Remove(line);
        //            editField.Children.Add(line);
        //        }
        //        if (i == 3)
        //        {
        //            if (line == null)
        //            {
        //                Line lineConnection = new();
        //                lineConnection.X1 = x2 + DefaultPropertyForBlock.width / 2 + valueOffsetOfLineFromTheBlockToSides;
        //                lineConnection.Y1 = y2 + valueOffsetOfLineFromTheBlockToSides + distanceBetweenTwoPoints;
        //                lineConnection.X2 = x1;
        //                lineConnection.Y2 = y1 + valueOffsetOfLineFromTheBlockToSides;
        //                lineConnection.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
        //                listLineConnection.Add(lineConnection);
        //                editField.Children.Remove(lineConnection);
        //                editField.Children.Add(lineConnection);
        //                masLine[i] = lineConnection;
        //            }
        //            else
        //            {
        //                line.X1 = x2 + DefaultPropertyForBlock.width / 2 + valueOffsetOfLineFromTheBlockToSides;
        //                line.Y1 = y2 + valueOffsetOfLineFromTheBlockToSides + distanceBetweenTwoPoints;
        //                line.X2 = x1;
        //                line.Y2 = y1 + valueOffsetOfLineFromTheBlockToSides;
        //                editField.Children.Remove(line);
        //                editField.Children.Add(line);
        //            }
        //        }
        //        if (i == 4)
        //        {
        //            if (line == null)
        //            {
        //                Line lineConnection = new();
        //                lineConnection.X2 = x2;
        //                lineConnection.Y1 = y2;
        //                lineConnection.X1 = x2;
        //                lineConnection.Y2 = y2 + valueOffsetOfLineFromTheBlockToSides;
        //                lineConnection.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
        //                listLineConnection.Add(lineConnection);
        //                editField.Children.Remove(lineConnection);
        //                editField.Children.Add(lineConnection);
        //                masLine[i] = lineConnection;
        //            }
        //            else
        //            {
        //                line.X2 = x2;
        //                line.Y1 = y2;
        //                line.X1 = x2;
        //                line.Y2 = y2 + valueOffsetOfLineFromTheBlockToSides;
        //                editField.Children.Remove(line);
        //                editField.Children.Add(line);
        //            }
        //        }
        //        i++;
        //    }
        //}
        //public void ChangeLine15(Line[] masLine, double x1, double y1, double x2, double y2)
        //{
        //    int i = 0;
        //    double distanceBetweenTwoPoints = y1 - y2;
        //    foreach (Line line in masLine)
        //    {
        //        if (i == 0)
        //        {
        //            line.X1 = x2;
        //            line.Y1 = y2;
        //            line.X2 = x2;
        //            line.Y2 = y2 + distanceBetweenTwoPoints + valueOffsetOfLineFromTheBlockToSides;
        //        }
        //        if (i == 1)
        //        {
        //            line.X1 = x2;
        //            line.Y1 = y2 + distanceBetweenTwoPoints + valueOffsetOfLineFromTheBlockToSides;
        //            line.X2 = x1;
        //            line.Y2 = y1 + valueOffsetOfLineFromTheBlockToSides;
        //        }
        //        if (i == 2)
        //        {
        //            line.X1 = x1;
        //            line.Y1 = y1;
        //            line.X2 = x1;
        //            line.Y2 = y1 + valueOffsetOfLineFromTheBlockToSides;
        //        }
        //        if (i == 3)
        //        {
        //            editField.Children.Remove(line);
        //        }
        //        if (i == 4)
        //        {
        //            editField.Children.Remove(line);
        //        }
        //        i++;
        //    }
        //}

        //public void ChangeLine16(Line[] masLine, double x1, double y1, double x2, double y2)
        //{
        //    int i = 0;
        //    BrushConverter color = new();
        //    foreach (Line line in masLine)
        //    {
        //        if (i == 0)
        //        {
        //            line.X1 = x1;
        //            line.Y1 = y1;
        //            line.X2 = x1;
        //            line.Y2 = y1 + valueOffsetOfLineFromTheBlockToSides;
        //        }
        //        if (i == 1)
        //        {
        //            line.X1 = x2 + valueOffsetOfLineFromTheBlockToSides;
        //            line.Y1 = y1 + valueOffsetOfLineFromTheBlockToSides;
        //            line.X2 = x1;
        //            line.Y2 = y1 + valueOffsetOfLineFromTheBlockToSides;
        //        }
        //        if (i == 2)
        //        {
        //            if (line == null)
        //            {
        //                Line lineConnection = new();
        //                lineConnection.X1 = x2 + valueOffsetOfLineFromTheBlockToSides;
        //                lineConnection.Y1 = y1 + valueOffsetOfLineFromTheBlockToSides;
        //                lineConnection.X2 = x2 + valueOffsetOfLineFromTheBlockToSides;
        //                lineConnection.Y2 = y2;
        //                lineConnection.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
        //                listLineConnection.Add(lineConnection);
        //                editField.Children.Remove(lineConnection);
        //                editField.Children.Add(lineConnection);
        //                masLine[i] = lineConnection;
        //            }
        //            else
        //            {
        //                line.X1 = x2 + valueOffsetOfLineFromTheBlockToSides;
        //                line.Y1 = y1 + valueOffsetOfLineFromTheBlockToSides;
        //                line.X2 = x2 + valueOffsetOfLineFromTheBlockToSides;
        //                line.Y2 = y2;
        //                editField.Children.Remove(line);
        //                editField.Children.Add(line);
        //            }
        //        }
        //        if (i == 3)
        //        {
        //            if (line == null)
        //            {
        //                Line lineConnection = new();
        //                lineConnection.X1 = x2;
        //                lineConnection.Y1 = y2;
        //                lineConnection.X2 = x2 + valueOffsetOfLineFromTheBlockToSides;
        //                lineConnection.Y2 = y2;
        //                lineConnection.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
        //                listLineConnection.Add(lineConnection);
        //                editField.Children.Remove(lineConnection);
        //                editField.Children.Add(lineConnection);
        //                masLine[i] = lineConnection;
        //            }
        //            else
        //            {
        //                line.X1 = x2;
        //                line.Y1 = y2;
        //                line.X2 = x2 + valueOffsetOfLineFromTheBlockToSides;
        //                line.Y2 = y2;
        //                editField.Children.Remove(line);
        //                editField.Children.Add(line);
        //            }
        //        }
        //        i++;
        //    }
        //}
        //public void ChangeLine17(Line[] masLine, double x1, double y1, double x2, double y2)
        //{
        //    int i = 0;
        //    double distanceBetweenTwoPoints = x2 - x1;
        //    foreach (Line line in masLine)
        //    {
        //        if (i == 0)
        //        {
        //            line.X1 = x1;
        //            line.Y1 = y1;
        //            line.X2 = x1 + valueOffsetOfLineFromTheBlockToSides;
        //            line.Y2 = y1;
        //        }
        //        if (i == 1)
        //        {
        //            line.X1 = x1 + valueOffsetOfLineFromTheBlockToSides;
        //            line.Y1 = y1;
        //            line.X2 = x2 - distanceBetweenTwoPoints + valueOffsetOfLineFromTheBlockToSides;
        //            line.Y2 = y2;
        //        }
        //        if (i == 2)
        //        {
        //            line.X1 = x2;
        //            line.Y1 = y2;
        //            line.X2 = x2 - distanceBetweenTwoPoints + valueOffsetOfLineFromTheBlockToSides;
        //            line.Y2 = y2;
        //        }
        //        if (i == 3)
        //        {
        //            editField.Children.Remove(line);
        //        }
        //        if (i == 4)
        //        {
        //            editField.Children.Remove(line);
        //        }
        //        i++;
        //    }
        //}

        //public void ChangeLine19(Line[] masLine, double x1, double y1, double x2, double y2)
        //{
        //    int i = 0;
        //    BrushConverter color = new();
        //    foreach (Line line in masLine)
        //    {
        //        if (i == 0)
        //        {
        //            line.X1 = x1;
        //            line.Y1 = y1;
        //            line.X2 = x1 + valueOffsetOfLineFromTheBlockToSides;
        //            line.Y2 = y1;
        //            editField.Children.Remove(line);
        //            editField.Children.Add(line);
        //        }
        //        if (i == 1)
        //        {
        //            line.X1 = x1 + valueOffsetOfLineFromTheBlockToSides;
        //            line.Y1 = y1;
        //            line.X2 = x1 + valueOffsetOfLineFromTheBlockToSides;
        //            line.Y2 = y2 + DefaultPropertyForBlock.height / 2 + valueOffsetOfLineFromTheBlockToSides;
        //            editField.Children.Remove(line);
        //            editField.Children.Add(line);
        //        }
        //        if (i == 2)
        //        {
        //            line.X1 = x1 + valueOffsetOfLineFromTheBlockToSides;
        //            line.Y1 = y2 + DefaultPropertyForBlock.height / 2 + valueOffsetOfLineFromTheBlockToSides;
        //            line.X2 = x2 + valueOffsetOfLineFromTheBlockToSides;
        //            line.Y2 = y2 + DefaultPropertyForBlock.height / 2 + valueOffsetOfLineFromTheBlockToSides;
        //            editField.Children.Remove(line);
        //            editField.Children.Add(line);
        //        }
        //        if (i == 3)
        //        {
        //            if (line == null)
        //            {
        //                Line lineConnection = new();
        //                lineConnection.X1 = x2 + valueOffsetOfLineFromTheBlockToSides;
        //                lineConnection.Y1 = y2 + DefaultPropertyForBlock.height / 2 + valueOffsetOfLineFromTheBlockToSides;
        //                lineConnection.X2 = x2 + valueOffsetOfLineFromTheBlockToSides;
        //                lineConnection.Y2 = y2;
        //                lineConnection.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
        //                listLineConnection.Add(lineConnection);
        //                editField.Children.Remove(lineConnection);
        //                editField.Children.Add(lineConnection);
        //                masLine[i] = lineConnection;
        //            }
        //            else
        //            {
        //                line.X1 = x2 + valueOffsetOfLineFromTheBlockToSides;
        //                line.Y1 = y2 + DefaultPropertyForBlock.height / 2 + valueOffsetOfLineFromTheBlockToSides;
        //                line.X2 = x2 + valueOffsetOfLineFromTheBlockToSides;
        //                line.Y2 = y2;
        //                editField.Children.Remove(line);
        //                editField.Children.Add(line);
        //            }
        //        }
        //        if (i == 4)
        //        {
        //            if (line == null)
        //            {
        //                Line lineConnection = new();
        //                lineConnection.X2 = x2;
        //                lineConnection.Y1 = y2;
        //                lineConnection.X1 = x2 + valueOffsetOfLineFromTheBlockToSides;
        //                lineConnection.Y2 = y2;
        //                lineConnection.Stroke = (Brush)color.ConvertFrom(DefaultPropertyForBlock.colorLine);
        //                listLineConnection.Add(lineConnection);
        //                editField.Children.Remove(lineConnection);
        //                editField.Children.Add(lineConnection);
        //                masLine[i] = lineConnection;
        //            }
        //            else
        //            {
        //                line.X2 = x2;
        //                line.Y1 = y2;
        //                line.X1 = x2 + valueOffsetOfLineFromTheBlockToSides;
        //                line.Y2 = y2;
        //                editField.Children.Remove(line);
        //                editField.Children.Add(line);
        //            }
        //        }
        //        i++;
        //    }
        //}
    }
}
