using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Controls;

namespace Flowchart_Editor.View.Menu.ConnectionLine
{
    public enum StateArrow
    {
        Bottom,
        Upper,
        Left,
        Right,
        None
    }

    public class LineCreation
    {
        private const int cursorOffset = 0; //Отступ необходим, так как при нажатии на другую точку соединения курсор будет кликать на стрелочку линии 
        private readonly Canvas canvasDrawBlock;
        private readonly Point coordinateConnectionPoint;
        public StateArrow StateArrow { get; private set; }
        public OrientationConnectionPoint OrientationConnectionPoint { get; private set; }
        public LineArrow LineArrow { get; private set; }
        public Line FirstLine { get; set; }
        public Line? SecondLine { get; set; }

        public LineCreation(Point coordinateConnectionPoint, OrientationConnectionPoint orientationConnectionPoint, Canvas canvasDrawBlock)
        {
            LineArrow = new();
            FirstLine = new()
            {
                X1 = coordinateConnectionPoint.X,
                Y1 = coordinateConnectionPoint.Y,
                X2 = coordinateConnectionPoint.X,
                Y2 = coordinateConnectionPoint.Y,
                Stroke = Brushes.Black
            };
            
            canvasDrawBlock.Children.Add(FirstLine);
            canvasDrawBlock.Children.Add(LineArrow.Arrow);
            Canvas.SetTop(LineArrow.Arrow, coordinateConnectionPoint.Y);
            Canvas.SetLeft(LineArrow.Arrow, coordinateConnectionPoint.X);
            
            OrientationConnectionPoint = orientationConnectionPoint;
            this.canvasDrawBlock = canvasDrawBlock;
            this.coordinateConnectionPoint = coordinateConnectionPoint;
            StateArrow = StateArrow.None;
        }

        public void DrawLine(Point cursorPoint) //Отрисовка и изменение длин линий
        {
            if (OrientationConnectionPoint == OrientationConnectionPoint.Horizontal)
            {
                ChangeLengthFirstHorizotalLine(cursorPoint, FirstLine);
            }
            else if (OrientationConnectionPoint == OrientationConnectionPoint.Vertical)
            {
                ChangeLengthFirstVerticalLine(cursorPoint, FirstLine);
            }

            if (cursorPoint.X > coordinateConnectionPoint.X 
                || cursorPoint.X < coordinateConnectionPoint.X
                || cursorPoint.Y > coordinateConnectionPoint.X 
                || cursorPoint.Y < coordinateConnectionPoint.X)
            {
                InitializationSecondLine();
                if (SecondLine != null)
                {
                    ChangeSecondLine(cursorPoint, SecondLine);
                }
            }

            ChangeOrientationArrow(cursorPoint);
        }

        private void InitializationSecondLine() 
        {
            if (SecondLine == null)
            {
                SecondLine = new()
                {
                    Stroke = Brushes.Black
                };
                canvasDrawBlock.Children.Add(SecondLine);
            }
        }

        private void ChangeLengthFirstVerticalLine(Point cursorPoint, Line line) //Изменение длины первой вертикальной линии
        {
            if (coordinateConnectionPoint.X < cursorPoint.X)
            {
                //cursorPoint.X -= cursorOffset;
                line.X2 = cursorPoint.X;
                Canvas.SetLeft(LineArrow.Arrow, cursorPoint.X);
            }
            else if (coordinateConnectionPoint.X > cursorPoint.X)
            {
                //cursorPoint.X += cursorOffset;
                line.X2 = cursorPoint.X;
                Canvas.SetLeft(LineArrow.Arrow, cursorPoint.X);
            }
        }

        private void ChangeLengthFirstHorizotalLine(Point cursorPoint, Line line) //Изменение длины первой горизонтальной линии
        {
            if (coordinateConnectionPoint.Y < cursorPoint.Y)
            {
                cursorPoint.Y -= cursorOffset;
                line.Y2 = cursorPoint.Y;
                Canvas.SetTop(LineArrow.Arrow, cursorPoint.Y);
            }
            else if (coordinateConnectionPoint.Y > cursorPoint.Y)
            {
                cursorPoint.Y += cursorOffset;
                line.Y2 = cursorPoint.Y;
                Canvas.SetTop(LineArrow.Arrow, cursorPoint.Y);
            }
        }

        private void ChangeSecondLine(Point cursorPoint, Line line) //Изменение длины второй линии
        {
            line.X1 = FirstLine.X2;
            line.Y1 = FirstLine.Y2;

            line.X2 = FirstLine.X2;
            line.Y2 = FirstLine.Y2;

            ChangeLengthFirstHorizotalLine(cursorPoint, line);
            ChangeLengthFirstVerticalLine(cursorPoint, line);
        }

        private void ChangeOrientationArrow(Point cursorPoint) //Изменение направление стрелочки у линии
        {
            if (cursorPoint.Y < coordinateConnectionPoint.Y && StateArrow != StateArrow.Upper)
            {
                LineArrow.DrawUpperArrow();
                StateArrow = StateArrow.Upper;
            }

            if (cursorPoint.Y > coordinateConnectionPoint.Y && StateArrow != StateArrow.Bottom)
            {
                LineArrow.DrawBottomArrow();
                StateArrow = StateArrow.Bottom;
            }

            if (cursorPoint.X > coordinateConnectionPoint.X && StateArrow != StateArrow.Left)
            {
                LineArrow.DrawLeftArrow();
                StateArrow = StateArrow.Left;
            }

            if (cursorPoint.X < coordinateConnectionPoint.X && StateArrow != StateArrow.Right)
            {
                LineArrow.DrawRigthArrow();
                StateArrow = StateArrow.Right;
            }
        }

        public void Delete()
        {
            canvasDrawBlock.Children.Remove(FirstLine);
            canvasDrawBlock.Children.Remove(SecondLine);
            DeleteArrow();
        }

        public void DeleteArrow()
        {
            canvasDrawBlock.Children.Remove(LineArrow.Arrow);
        }
    }
}