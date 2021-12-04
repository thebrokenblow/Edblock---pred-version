using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Flowchart_Editor
{
    public class ActionBlock
    {
        private Canvas? canvasOfActionBlock = null;
        private TextBox? textOfActionBlock = null;
        private Ellipse? firstPointToConnect = null;
        private Ellipse? secondPointToConnect = null;
        private Ellipse? thirdPointToConnect = null;
        private Ellipse? fourthPointToConnect = null;
       

        

        public UIElement GetUIElementWithoutCreate()
        {
            #pragma warning disable CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
            return canvasOfActionBlock;
            #pragma warning restore CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
        }

        public void actionBlockForMovements_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var instanceOfActionBlock = new ActionBlockForMovements(sender);
                var dataObjectInformationOfActionBlock = new DataObject(typeof(ActionBlockForMovements), instanceOfActionBlock);
                DragDrop.DoDragDrop(sender as DependencyObject, dataObjectInformationOfActionBlock, DragDropEffects.Copy);
            }
            e.Handled = true;
        }

        public UIElement GetUIElement()
        {
            if (canvasOfActionBlock == null)
            {
                canvasOfActionBlock = new Canvas();
                textOfActionBlock = new TextBox();
                firstPointToConnect = new Ellipse();
                secondPointToConnect = new Ellipse();
                thirdPointToConnect = new Ellipse();
                fourthPointToConnect = new Ellipse();

                textOfActionBlock.Text = "Действие";
                textOfActionBlock.Foreground = Brushes.White;

                var backgroundColor = new BrushConverter();
                canvasOfActionBlock.Background = (Brush)backgroundColor.ConvertFrom("#FF52C0AA");
                canvasOfActionBlock.Width = 140;
                canvasOfActionBlock.Height = 60;

                Canvas.SetLeft(textOfActionBlock, 40);
                Canvas.SetTop(textOfActionBlock, 15);

                firstPointToConnect.Fill = Brushes.Black;
                firstPointToConnect.Height = 6;
                firstPointToConnect.Width = 6;
                firstPointToConnect.Margin = new Thickness(65, - 3, 0, 0);

                secondPointToConnect.Fill= Brushes.Black;
                secondPointToConnect.Height = 6;
                secondPointToConnect.Width = 6;
                secondPointToConnect.Margin = new Thickness(-3, 25, 0, 0);


                thirdPointToConnect.Fill = Brushes.Black;
                thirdPointToConnect.Height = 6;
                thirdPointToConnect.Width = 6;
                thirdPointToConnect.Margin = new Thickness(65, 57, 0, 0);

                fourthPointToConnect.Fill = Brushes.Black;
                fourthPointToConnect.Height = 6;
                fourthPointToConnect.Width = 6;
                fourthPointToConnect.Margin = new Thickness(136, 25, 0, 0);

                canvasOfActionBlock.Children.Add(textOfActionBlock);
                canvasOfActionBlock.Children.Add(firstPointToConnect);
                canvasOfActionBlock.Children.Add(secondPointToConnect);
                canvasOfActionBlock.Children.Add(thirdPointToConnect);
                canvasOfActionBlock.Children.Add(fourthPointToConnect);
                canvasOfActionBlock.MouseMove += actionBlockForMovements_MouseMove;
            }
            return canvasOfActionBlock;
        }

        internal void Reset()
        {
            canvasOfActionBlock = null;
        }
    }

    public class ActionBlockForMovements
    {
        private Canvas? canvasOfActionBlock = null;
        private TextBox? textOfActionBlock = null;
        public object transferInformationActionBlock = null;
        public ActionBlockForMovements(object sender) 
        {
            transferInformationActionBlock = sender;
        }

        public UIElement GetUIElementWithoutCreate()
        {
            #pragma warning disable CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
            return canvasOfActionBlock;
            #pragma warning restore CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
        }

        public UIElement GetUIElement()
        {
            if (canvasOfActionBlock == null)
            {
                canvasOfActionBlock = new Canvas();
                textOfActionBlock = new TextBox();

                textOfActionBlock.Text = "Действие";
                textOfActionBlock.Foreground = Brushes.White;

                var backgroundColor = new BrushConverter();
                canvasOfActionBlock.Background = (Brush)backgroundColor.ConvertFrom("#FF52C0AA");
                canvasOfActionBlock.Width = 140;
                canvasOfActionBlock.Height = 60;

                Canvas.SetLeft(textOfActionBlock, 40);
                Canvas.SetTop(textOfActionBlock, 15);
                canvasOfActionBlock.Children.Add(textOfActionBlock);
            }
            return canvasOfActionBlock;
        }
        internal void Reset()
        {
            canvasOfActionBlock = null;
        }
    }

    public class ConditionBlock
    {
        private Canvas canvasConditionBlock = null;
        private Polygon upperPartOfPolygonConditionBlock = null;
        private Polygon lowerPartOfPolygonConditionBlock = null;
        private TextBox textOfConditionBlockBox = null;
        private Ellipse firstPointToConnect = null;
        private Ellipse secondPointToConnect = null;
        private Ellipse thirdPointToConnect = null;
        private Ellipse fourthPointToConnect = null;

        public UIElement GetUIElementWithoutCreate()
        {
            return canvasConditionBlock;
        }

        private void conditionBlock_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var instanceOfConditionBlock = new ConditionBlockForMovements(sender);
                var dataObjectInformationOConditionBlock = new DataObject(typeof(ConditionBlockForMovements), instanceOfConditionBlock);
                DragDrop.DoDragDrop(sender as DependencyObject, dataObjectInformationOConditionBlock, DragDropEffects.Copy);
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
                upperPartOfPolygonConditionBlock = new Polygon();
                lowerPartOfPolygonConditionBlock = new Polygon();
                textOfConditionBlockBox = new TextBox();

                var backgroundColor = new BrushConverter();
                upperPartOfPolygonConditionBlock.Fill = (Brush)backgroundColor.ConvertFrom("#FF60B2D3");
                Point Point1 = new Point(55, 120);
                Point Point2 = new Point(120, 90);
                Point Point3 = new Point(190, 120);
                PointCollection myPointCollection1 = new PointCollection();
                myPointCollection1.Add(Point1);
                myPointCollection1.Add(Point2);
                myPointCollection1.Add(Point3);
                upperPartOfPolygonConditionBlock.Points = myPointCollection1;
                Canvas.SetTop(upperPartOfPolygonConditionBlock, -85.5);
                Canvas.SetLeft(upperPartOfPolygonConditionBlock, -50);
                canvasConditionBlock.Children.Add(upperPartOfPolygonConditionBlock);

                lowerPartOfPolygonConditionBlock.Fill = (Brush)backgroundColor.ConvertFrom("#FF60B2D3");
                Point Point4 = new Point(190, 120);
                Point Point5 = new Point(55, 120);
                Point Point6 = new Point(120, 150);
                PointCollection myPointCollection2 = new PointCollection();
                myPointCollection2.Add(Point4);
                myPointCollection2.Add(Point5);
                myPointCollection2.Add(Point6);
                lowerPartOfPolygonConditionBlock.Points = myPointCollection2;
                Canvas.SetTop(lowerPartOfPolygonConditionBlock, -86);
                Canvas.SetLeft(lowerPartOfPolygonConditionBlock, -50);
                canvasConditionBlock.Children.Add(lowerPartOfPolygonConditionBlock);

                firstPointToConnect.Fill = Brushes.Black;
                firstPointToConnect.Height = 6;
                firstPointToConnect.Width = 6;
                firstPointToConnect.Margin = new Thickness(68, 1, 0, 0);

                secondPointToConnect.Fill = Brushes.Black;
                secondPointToConnect.Height = 6;
                secondPointToConnect.Width = 6;
                secondPointToConnect.Margin = new Thickness(3, 32, 0, 0);


                thirdPointToConnect.Fill = Brushes.Black;
                thirdPointToConnect.Height = 6;
                thirdPointToConnect.Width = 6;
                thirdPointToConnect.Margin = new Thickness(67, 62, 0, 0);

                fourthPointToConnect.Fill = Brushes.Black;
                fourthPointToConnect.Height = 6;
                fourthPointToConnect.Width = 6;
                fourthPointToConnect.Margin = new Thickness(135, 32, 0, 0);

                textOfConditionBlockBox.Text = "Условие";
                textOfConditionBlockBox.FontSize = 12;
                textOfConditionBlockBox.Foreground = Brushes.White;
                Canvas.SetLeft(textOfConditionBlockBox, 47);
                Canvas.SetTop(textOfConditionBlockBox, 21);
                canvasConditionBlock.Children.Add(textOfConditionBlockBox);
                canvasConditionBlock.Children.Add(firstPointToConnect);
                canvasConditionBlock.Children.Add(secondPointToConnect);
                canvasConditionBlock.Children.Add(thirdPointToConnect);
                canvasConditionBlock.Children.Add(fourthPointToConnect);
                canvasConditionBlock.MouseMove += conditionBlock_MouseMove;
            }
            return canvasConditionBlock;
        }

        internal void Reset()
        {
            canvasConditionBlock = null;
        }
    }

    public class ConditionBlockForMovements
    {
        private Canvas canvasConditionBlock = null;
        private Polygon upperPartOfPolygonConditionBlock = null;
        private Polygon lowerPartOfPolygonConditionBlock = null;
        private TextBox textOfConditionBlockBox = null;
        public object transferInformation = null;
        public UIElement GetUIElementWithoutCreate()
        {
            return canvasConditionBlock;
        }

        public ConditionBlockForMovements(object sender)
        {
            transferInformation = sender;
        }

        public UIElement GetUIElement()
        {
            if (canvasConditionBlock == null)
            {
                canvasConditionBlock = new Canvas();
                upperPartOfPolygonConditionBlock = new Polygon();
                lowerPartOfPolygonConditionBlock = new Polygon();
                textOfConditionBlockBox = new TextBox();

                var backgroundColor = new BrushConverter();
                upperPartOfPolygonConditionBlock.Fill = (Brush)backgroundColor.ConvertFrom("#FF60B2D3");
                Point Point1 = new Point(55, 120);
                Point Point2 = new Point(120, 90);
                Point Point3 = new Point(190, 120);
                PointCollection myPointCollection1 = new PointCollection();
                myPointCollection1.Add(Point1);
                myPointCollection1.Add(Point2);
                myPointCollection1.Add(Point3);
                upperPartOfPolygonConditionBlock.Points = myPointCollection1;
                Canvas.SetTop(upperPartOfPolygonConditionBlock, -85.5);
                Canvas.SetLeft(upperPartOfPolygonConditionBlock, -50);
                canvasConditionBlock.Children.Add(upperPartOfPolygonConditionBlock);

                lowerPartOfPolygonConditionBlock.Fill = (Brush)backgroundColor.ConvertFrom("#FF60B2D3");
                Point Point4 = new Point(190, 120);
                Point Point5 = new Point(55, 120);
                Point Point6 = new Point(120, 150);
                PointCollection myPointCollection2 = new PointCollection();
                myPointCollection2.Add(Point4);
                myPointCollection2.Add(Point5);
                myPointCollection2.Add(Point6);
                lowerPartOfPolygonConditionBlock.Points = myPointCollection2;
                Canvas.SetTop(lowerPartOfPolygonConditionBlock, -86);
                Canvas.SetLeft(lowerPartOfPolygonConditionBlock, -50);
                canvasConditionBlock.Children.Add(lowerPartOfPolygonConditionBlock);

                textOfConditionBlockBox.Text = "Условие";
                textOfConditionBlockBox.FontSize = 12;
                textOfConditionBlockBox.Foreground = Brushes.White;
                Canvas.SetLeft(textOfConditionBlockBox, 47);
                Canvas.SetTop(textOfConditionBlockBox, 21);
                canvasConditionBlock.Children.Add(textOfConditionBlockBox);
            }
            return canvasConditionBlock;
        }

        internal void Reset()
        {
            canvasConditionBlock = null;
        }
    }


    public class StartEndBlock
    {
        private Canvas? canvasStartEndBlock = null;
        private Rectangle? rectangleStartEndBlock = null;
        private TextBox? textOfStartEndBox = null;
        private Ellipse firstPointToConnect = null;
        private Ellipse secondPointToConnect = null;
        private Ellipse thirdPointToConnect = null;
        private Ellipse fourthPointToConnect = null;

        public UIElement GetUIElementWithoutCreate()
        {
            #pragma warning disable CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
            return canvasStartEndBlock;
            #pragma warning restore CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
        }

        private void startEndBlock_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var instanceOfStartEndBlock = new StartEndBlockForMovements(sender);
                var dataObjectInformationOfStartEndBlock = new DataObject(typeof(StartEndBlockForMovements), instanceOfStartEndBlock);
                DragDrop.DoDragDrop(sender as DependencyObject, dataObjectInformationOfStartEndBlock, DragDropEffects.Copy);
            }
            e.Handled = true;
        }

        public UIElement GetUIElement()
        {
            if (canvasStartEndBlock == null)
            {
                canvasStartEndBlock = new Canvas();
                rectangleStartEndBlock = new Rectangle();
                textOfStartEndBox = new TextBox();
                firstPointToConnect = new Ellipse();
                secondPointToConnect = new Ellipse();
                thirdPointToConnect = new Ellipse();
                fourthPointToConnect = new Ellipse();

                var backgroundColor = new BrushConverter();
                rectangleStartEndBlock.Fill = (Brush)backgroundColor.ConvertFrom("#FFF25252");
                rectangleStartEndBlock.RadiusX = 25;
                rectangleStartEndBlock.RadiusY = 25;
                rectangleStartEndBlock.Width = 140;
                rectangleStartEndBlock.Height = 60;

                textOfStartEndBox.Text = "Начало";
                textOfStartEndBox.Foreground = Brushes.White;

                firstPointToConnect.Fill = Brushes.Black;
                firstPointToConnect.Height = 6;
                firstPointToConnect.Width = 6;
                firstPointToConnect.Margin = new Thickness(65, 7, 0, 0);

                secondPointToConnect.Fill = Brushes.Black;
                secondPointToConnect.Height = 6;
                secondPointToConnect.Width = 6;
                secondPointToConnect.Margin = new Thickness(-4, 35, 0, 0);


                thirdPointToConnect.Fill = Brushes.Black;
                thirdPointToConnect.Height = 6;
                thirdPointToConnect.Width = 6;
                thirdPointToConnect.Margin = new Thickness(65, 66, 0, 0);

                fourthPointToConnect.Fill = Brushes.Black;
                fourthPointToConnect.Height = 6;
                fourthPointToConnect.Width = 6;
                fourthPointToConnect.Margin = new Thickness(137, 35, 0, 0);

                Canvas.SetLeft(textOfStartEndBox, 47);
                Canvas.SetTop(textOfStartEndBox, 17);
                canvasStartEndBlock.Children.Add(rectangleStartEndBlock);
                canvasStartEndBlock.Children.Add(textOfStartEndBox);
                canvasStartEndBlock.Children.Add(firstPointToConnect);
                canvasStartEndBlock.Children.Add(secondPointToConnect);
                canvasStartEndBlock.Children.Add(thirdPointToConnect);
                canvasStartEndBlock.Children.Add(fourthPointToConnect);
                canvasStartEndBlock.MouseMove += startEndBlock_MouseMove;
            }
            return canvasStartEndBlock;
        }

        internal void Reset()
        {
            canvasStartEndBlock = null;
        }
    }

    public class StartEndBlockForMovements
    {
        private Canvas? canvasStartEndBlock = null;
        private Rectangle? rectangleStartEndBlock = null;
        private TextBox? textOfStartEndBox = null;
        public object transferInformation = null;

        public StartEndBlockForMovements(object sender)
        {
            transferInformation = sender;
        }

        public UIElement GetUIElementWithoutCreate()
        {
            #pragma warning disable CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
            return canvasStartEndBlock;
            #pragma warning restore CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
        }

        public UIElement GetUIElement()
        {
            if (canvasStartEndBlock == null)
            {
                canvasStartEndBlock = new Canvas();
                rectangleStartEndBlock = new Rectangle();
                textOfStartEndBox = new TextBox();

                var backgroundColor = new BrushConverter();
                rectangleStartEndBlock.Fill = (Brush)backgroundColor.ConvertFrom("#FFF25252");
                rectangleStartEndBlock.RadiusX = 25;
                rectangleStartEndBlock.RadiusY = 25;
                rectangleStartEndBlock.Width = 140;
                rectangleStartEndBlock.Height = 60;

                textOfStartEndBox.Text = "Начало";
                textOfStartEndBox.Foreground = Brushes.White;

                Canvas.SetLeft(textOfStartEndBox, 47);
                Canvas.SetTop(textOfStartEndBox, 17);
                canvasStartEndBlock.Children.Add(rectangleStartEndBlock);
                canvasStartEndBlock.Children.Add(textOfStartEndBox);
            }
            return canvasStartEndBlock;
        }

        internal void Reset()
        {
            canvasStartEndBlock = null;
        }
    }
    public class InputOutputBlock
    {
        private Canvas canvasInputOutputBlock = null;
        private Rectangle rectangleInputOutputBlock = null;
        private TextBox textInputOutputkBox = null;

        public UIElement GetUIElementWithoutCreate()
        {
            return canvasInputOutputBlock;
        }

        private void inputOutputBlock_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var instanceOfInputOutputBlock = new InputOutputBlockForMovements(sender);
                var dataObjectInformationOfStartEndBlock = new DataObject(typeof(InputOutputBlockForMovements), instanceOfInputOutputBlock);
                DragDrop.DoDragDrop(sender as DependencyObject, dataObjectInformationOfStartEndBlock, DragDropEffects.Copy);
            }
            e.Handled = true;
        }

        public UIElement GetUIElement()
        {
            if (canvasInputOutputBlock == null)
            {
                canvasInputOutputBlock = new Canvas();
                rectangleInputOutputBlock = new Rectangle();
                textInputOutputkBox = new TextBox();

                var backgroundColor = new BrushConverter();
                rectangleInputOutputBlock.Fill = (Brush)backgroundColor.ConvertFrom("#FF05273C");
                rectangleInputOutputBlock.Width = 102;
                rectangleInputOutputBlock.Height = 30;

                MatrixTransform matrix1 = new MatrixTransform(1, 0, 1, 2, 1, -3);
                Matrix matrix = new Matrix(1, 0, 1, 2, 1, -3);
                rectangleInputOutputBlock.RenderTransform = matrix1;

                Canvas.SetTop(rectangleInputOutputBlock, 11);
                Canvas.SetLeft(rectangleInputOutputBlock, 5);

                textInputOutputkBox.Text = "Ввод/Вывод";
                textInputOutputkBox.FontSize = 12;
                textInputOutputkBox.Foreground = Brushes.White;
                Canvas.SetTop(textInputOutputkBox, 25);
                Canvas.SetLeft(textInputOutputkBox, 37);

                canvasInputOutputBlock.Children.Add(rectangleInputOutputBlock);
                canvasInputOutputBlock.Children.Add(textInputOutputkBox);
                canvasInputOutputBlock.MouseMove += inputOutputBlock_MouseMove;
            }
            return canvasInputOutputBlock;
        }

        internal void Reset()
        {
            canvasInputOutputBlock = null;
        }
    }

    public class InputOutputBlockForMovements
    {
        private Canvas canvasInputOutputBlock = null;
        private Rectangle rectangleInputOutputBlock = null;
        private TextBox textInputOutputkBox = null;
        public object transferInformation = null;
        public InputOutputBlockForMovements(object sender)
        {
            transferInformation = sender;
        }
        public UIElement GetUIElementWithoutCreate()
        {
            return canvasInputOutputBlock;
        }

        public UIElement GetUIElement()
        {
            if (canvasInputOutputBlock == null)
            {
                canvasInputOutputBlock = new Canvas();
                rectangleInputOutputBlock = new Rectangle();
                textInputOutputkBox = new TextBox();

                var backgroundColor = new BrushConverter();
                rectangleInputOutputBlock.Fill = (Brush)backgroundColor.ConvertFrom("#FF05273C");
                rectangleInputOutputBlock.Width = 102;
                rectangleInputOutputBlock.Height = 30;

                MatrixTransform matrix1 = new MatrixTransform(1, 0, 1, 2, 1, -3);
                Matrix matrix = new Matrix(1, 0, 1, 2, 1, -3);
                rectangleInputOutputBlock.RenderTransform = matrix1;

                Canvas.SetTop(rectangleInputOutputBlock, 11);
                Canvas.SetLeft(rectangleInputOutputBlock, 5);

                textInputOutputkBox.Text = "Ввод/Вывод";
                textInputOutputkBox.FontSize = 12;
                textInputOutputkBox.Foreground = Brushes.White;
                Canvas.SetTop(textInputOutputkBox, 25);
                Canvas.SetLeft(textInputOutputkBox, 37);

                canvasInputOutputBlock.Children.Add(rectangleInputOutputBlock);
                canvasInputOutputBlock.Children.Add(textInputOutputkBox);
            }
            return canvasInputOutputBlock;
        }

        internal void Reset()
        {
            canvasInputOutputBlock = null;
        }
    }

    public class SubroutineBlock
    {
        private Canvas canvasSubroutineBlock = null;
        private Border borderSubroutineBlock = null;
        private Border internalBorderSubroutineBlock = null;
        private TextBox textOfSubroutineBlockBox = null;

        public UIElement GetUIElementWithoutCreate()
        {
            return canvasSubroutineBlock;
        }

        private void subroutineBlock_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var instanceOfInputOutputBlock = new SubroutineBlockForMovements(sender);
                var dataObjectInformationOfStartEndBlock = new DataObject(typeof(SubroutineBlockForMovements), instanceOfInputOutputBlock);
                DragDrop.DoDragDrop(sender as DependencyObject, dataObjectInformationOfStartEndBlock, DragDropEffects.Copy);
            }
            e.Handled = true;
        }

        public UIElement GetUIElement()
        {
            if (canvasSubroutineBlock == null)
            {
                canvasSubroutineBlock = new Canvas();
                borderSubroutineBlock = new Border();
                internalBorderSubroutineBlock = new Border();
                textOfSubroutineBlockBox = new TextBox();

                canvasSubroutineBlock.Width = 140;
                canvasSubroutineBlock.Height = 60;
                var backgroundColor = new BrushConverter();
                canvasSubroutineBlock.Background = (Brush)backgroundColor.ConvertFrom("#FFBA64C8");

                borderSubroutineBlock.BorderBrush = Brushes.Black;
                borderSubroutineBlock.Height = 60;
                borderSubroutineBlock.Width = 140;
                borderSubroutineBlock.BorderThickness = new Thickness(1);
                borderSubroutineBlock.CornerRadius = new CornerRadius(1);

                internalBorderSubroutineBlock.BorderBrush = Brushes.Black;
                internalBorderSubroutineBlock.Height = 60;
                internalBorderSubroutineBlock.Width = 100;
                internalBorderSubroutineBlock.BorderThickness = new Thickness(1);
                internalBorderSubroutineBlock.CornerRadius = new CornerRadius(1);
                Canvas.SetTop(internalBorderSubroutineBlock, 0);
                Canvas.SetLeft(internalBorderSubroutineBlock, 20);

                textOfSubroutineBlockBox.Text = "Подпрограмма";
                textOfSubroutineBlockBox.FontSize = 12;
                textOfSubroutineBlockBox.Foreground = Brushes.White;
                Canvas.SetTop(textOfSubroutineBlockBox, 15);
                Canvas.SetLeft(textOfSubroutineBlockBox, 25);

                canvasSubroutineBlock.Children.Add(borderSubroutineBlock);
                canvasSubroutineBlock.Children.Add(internalBorderSubroutineBlock);
                canvasSubroutineBlock.Children.Add(textOfSubroutineBlockBox);
                canvasSubroutineBlock.MouseMove += subroutineBlock_MouseMove;
            }
            return canvasSubroutineBlock;
        }

        internal void Reset()
        {
            canvasSubroutineBlock = null;
        }
    }

    public class SubroutineBlockForMovements
    {
        private Canvas canvasSubroutineBlock = null;
        private Border borderSubroutineBlock = null;
        private Border internalBorderSubroutineBlock = null;
        private TextBox textOfSubroutineBlockBox = null;
        public object transferInformation = null;
        public SubroutineBlockForMovements(object sender)
        {
            transferInformation = sender;
        }
        public UIElement GetUIElementWithoutCreate()
        {
            return canvasSubroutineBlock;
        }

        public UIElement GetUIElement()
        {
            if (canvasSubroutineBlock == null)
            {
                canvasSubroutineBlock = new Canvas();
                borderSubroutineBlock = new Border();
                internalBorderSubroutineBlock = new Border();
                textOfSubroutineBlockBox = new TextBox();

                canvasSubroutineBlock.Width = 140;
                canvasSubroutineBlock.Height = 60;
                var backgroundColor = new BrushConverter();
                canvasSubroutineBlock.Background = (Brush)backgroundColor.ConvertFrom("#FFBA64C8");

                borderSubroutineBlock.BorderBrush = Brushes.Black;
                borderSubroutineBlock.Height = 60;
                borderSubroutineBlock.Width = 140;
                borderSubroutineBlock.BorderThickness = new Thickness(1);
                borderSubroutineBlock.CornerRadius = new CornerRadius(1);

                internalBorderSubroutineBlock.BorderBrush = Brushes.Black;
                internalBorderSubroutineBlock.Height = 60;
                internalBorderSubroutineBlock.Width = 100;
                internalBorderSubroutineBlock.BorderThickness = new Thickness(1);
                internalBorderSubroutineBlock.CornerRadius = new CornerRadius(1);
                Canvas.SetTop(internalBorderSubroutineBlock, 0);
                Canvas.SetLeft(internalBorderSubroutineBlock, 20);

                textOfSubroutineBlockBox.Text = "Подпрограмма";
                textOfSubroutineBlockBox.FontSize = 12;
                textOfSubroutineBlockBox.Foreground = Brushes.White;
                Canvas.SetTop(textOfSubroutineBlockBox, 15);
                Canvas.SetLeft(textOfSubroutineBlockBox, 25);

                canvasSubroutineBlock.Children.Add(borderSubroutineBlock);
                canvasSubroutineBlock.Children.Add(internalBorderSubroutineBlock);
                canvasSubroutineBlock.Children.Add(textOfSubroutineBlockBox);
            }
            return canvasSubroutineBlock;
        }

        internal void Reset()
        {
            canvasSubroutineBlock = null;
        }
    }


    public class LinkBlock
    {
        private Canvas canvasLinkBlock = null;
        private Ellipse eliposLinkBlock = null;
        private TextBox textOfLinkBlockBox = null;

        public UIElement GetUIElementWithoutCreate()
        {
            return canvasLinkBlock;
        }

        private void linkBlock_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var instanceOfLinkBlockBlock = new LinkBlockForMovements(sender);
                var dataObjectInformationOfLinkBlock = new DataObject(typeof(LinkBlockForMovements), instanceOfLinkBlockBlock);
                DragDrop.DoDragDrop(sender as DependencyObject, dataObjectInformationOfLinkBlock, DragDropEffects.Copy);
            }
            e.Handled = true;
        }

        public UIElement GetUIElement()
        {
            if (canvasLinkBlock == null)
            {
                canvasLinkBlock = new Canvas();
                eliposLinkBlock = new Ellipse();
                textOfLinkBlockBox = new TextBox();

                eliposLinkBlock.Width = 75;
                eliposLinkBlock.Height = 75;
                var backgroundColor = new BrushConverter();
                eliposLinkBlock.Fill = (Brush)backgroundColor.ConvertFrom("#5761A8");

                textOfLinkBlockBox.Text = "Ссылка";
                textOfLinkBlockBox.FontSize = 12;
                textOfLinkBlockBox.Foreground = Brushes.White;
                Canvas.SetTop(textOfLinkBlockBox, 15);
                Canvas.SetLeft(textOfLinkBlockBox, 25);

                canvasLinkBlock.Children.Add(eliposLinkBlock);
                canvasLinkBlock.Children.Add(textOfLinkBlockBox);
                canvasLinkBlock.MouseMove += linkBlock_MouseMove;
            }
            return canvasLinkBlock;
        }

        internal void Reset()
        {
            canvasLinkBlock = null;
        }
    }


    public class LinkBlockForMovements
    {
        private Canvas canvasLinkBlock = null;
        private Ellipse eliposLinkBlock = null;
        private TextBox textOfLinkBlockBox = null;
        public object transferInformation = null;

        public LinkBlockForMovements(object sender)
        {
            transferInformation = sender;
        }

        public UIElement GetUIElementWithoutCreate()
        {
            return canvasLinkBlock;
        }

        public UIElement GetUIElement()
        {
            if (canvasLinkBlock == null)
            {
                canvasLinkBlock = new Canvas();
                eliposLinkBlock = new Ellipse();
                textOfLinkBlockBox = new TextBox();

                eliposLinkBlock.Width = 75;
                eliposLinkBlock.Height = 75;
                var backgroundColor = new BrushConverter();
                eliposLinkBlock.Fill = (Brush)backgroundColor.ConvertFrom("#5761A8");

                textOfLinkBlockBox.Text = "Ссылка";
                textOfLinkBlockBox.FontSize = 12;
                textOfLinkBlockBox.Foreground = Brushes.White;
                Canvas.SetTop(textOfLinkBlockBox, 15);
                Canvas.SetLeft(textOfLinkBlockBox, 25);

                canvasLinkBlock.Children.Add(eliposLinkBlock);
                canvasLinkBlock.Children.Add(textOfLinkBlockBox);
            }
            return canvasLinkBlock;
        }

        internal void Reset()
        {
            canvasLinkBlock = null;
        }
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void actionBlock_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var instanceOfActionBlock = new ActionBlock();
                var dataObjectInformationOfActionBlock = new DataObject(typeof(ActionBlock), instanceOfActionBlock);
                DragDrop.DoDragDrop(sender as DependencyObject, dataObjectInformationOfActionBlock, DragDropEffects.Copy);
            }
            e.Handled = true;
        }
        private void conditionBlock_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var instanceOfConditionBlock = new ConditionBlock();
                var dataObjectInformationOConditionBlock = new DataObject(typeof(ConditionBlock), instanceOfConditionBlock);
                DragDrop.DoDragDrop(conditionBlock, dataObjectInformationOConditionBlock, DragDropEffects.Copy);
            }
            e.Handled = true;
        }
        private void startEndBlock_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var instanceOfStartEndBlock = new StartEndBlock();
                var dataObjectInformationOfStartEndBlock = new DataObject(typeof(StartEndBlock), instanceOfStartEndBlock);
                DragDrop.DoDragDrop(sender as DependencyObject, dataObjectInformationOfStartEndBlock, DragDropEffects.Copy);
            }
            e.Handled = true;
        }
        private void inputOutputBlock_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var instanceOfInputOutputBlock = new InputOutputBlock();
                var dataObjectInformationOfInputOutputBlock = new DataObject(typeof(InputOutputBlock), instanceOfInputOutputBlock);
                DragDrop.DoDragDrop(inputOutputBlock, dataObjectInformationOfInputOutputBlock, DragDropEffects.Copy);
            }
            e.Handled = true;
        }
        private void subroutineBlock_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var instanceSubroutineBlock = new SubroutineBlock();
                var dataObjectInformationOfSubroutineBlock = new DataObject(typeof(SubroutineBlock), instanceSubroutineBlock);
                DragDrop.DoDragDrop(subroutineBlock, dataObjectInformationOfSubroutineBlock, DragDropEffects.Copy);
            }
            e.Handled = true;
        }
        private void linkBlock_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var instanceOfLinkBlockBlock = new LinkBlock();
                var dataObjectInformationOfLinkBlock = new DataObject(typeof(LinkBlock), instanceOfLinkBlockBlock);
                DragDrop.DoDragDrop(sender as DependencyObject, dataObjectInformationOfLinkBlock, DragDropEffects.Copy);
            }
            e.Handled = true;
        }

        private void destination_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ActionBlock)))
            {
                var position = e.GetPosition(destination);
                var featuresOfActionBlock = ((ActionBlock)e.Data.GetData(typeof(ActionBlock))).GetUIElement();
                Canvas.SetLeft(featuresOfActionBlock, position.X);
                Canvas.SetTop(featuresOfActionBlock, position.Y);
            }
            else if (e.Data.GetDataPresent(typeof(ConditionBlock)))
            {
                var position = e.GetPosition(destination);
                var featuresOfConditionBlock = ((ConditionBlock)e.Data.GetData(typeof(ConditionBlock))).GetUIElement();
                Canvas.SetLeft(featuresOfConditionBlock, position.X);
                Canvas.SetTop(featuresOfConditionBlock, position.Y);
            }
            else if (e.Data.GetDataPresent(typeof(StartEndBlock)))
            {
                var position = e.GetPosition(destination);
                var featuresOfStartEndBlock = ((StartEndBlock)e.Data.GetData(typeof(StartEndBlock))).GetUIElement();
                Canvas.SetLeft(featuresOfStartEndBlock, position.X);
                Canvas.SetTop(featuresOfStartEndBlock, position.Y);
            }
            else if (e.Data.GetDataPresent(typeof(InputOutputBlock)))
            {
                var position = e.GetPosition(destination);
                var featuresOfInputOutputBlock = ((InputOutputBlock)e.Data.GetData(typeof(InputOutputBlock))).GetUIElement();
                Canvas.SetLeft(featuresOfInputOutputBlock, position.X);
                Canvas.SetTop(featuresOfInputOutputBlock, position.Y);
            }
            else if (e.Data.GetDataPresent(typeof(SubroutineBlock)))
            {
                var position = e.GetPosition(destination);
                var featuresOfSubroutineBlock = ((SubroutineBlock)e.Data.GetData(typeof(SubroutineBlock))).GetUIElement();
                Canvas.SetLeft(featuresOfSubroutineBlock, position.X);
                Canvas.SetTop(featuresOfSubroutineBlock, position.Y);
            }
            else if (e.Data.GetDataPresent(typeof(LinkBlock)))
            {
                var position = e.GetPosition(destination);
                var featuresOfLinkBlock = ((LinkBlock)e.Data.GetData(typeof(LinkBlock))).GetUIElement();
                Canvas.SetLeft(featuresOfLinkBlock, position.X);
                Canvas.SetTop(featuresOfLinkBlock, position.Y);
            }
            e.Handled = true;
        }

        private void destination_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ActionBlock)))
            {
                e.Effects = DragDropEffects.Copy;
                var position = e.GetPosition(destination);
                var dataInformationOfActionBlock = (ActionBlock)e.Data.GetData(typeof(ActionBlock));
                UIElement actionBlockOfUIElement;
                if (dataInformationOfActionBlock.GetUIElementWithoutCreate() == null)
                {
                    actionBlockOfUIElement = ((ActionBlock)e.Data.GetData(typeof(ActionBlock))).GetUIElement();
                    destination.Children.Add(actionBlockOfUIElement);
                }
                else
                {
                    actionBlockOfUIElement = ((ActionBlock)e.Data.GetData(typeof(ActionBlock))).GetUIElement();
                }
                Canvas.SetLeft(actionBlockOfUIElement, position.X + 1);
                Canvas.SetTop(actionBlockOfUIElement, position.Y + 1);

            }
            else if (e.Data.GetDataPresent(typeof(ActionBlockForMovements)))
            {
                e.Effects = DragDropEffects.Copy;
                var position = e.GetPosition(destination);
                var resultTransferInformation = (ActionBlockForMovements)e.Data.GetData(typeof(ActionBlockForMovements));
                Canvas.SetLeft((UIElement)resultTransferInformation.transferInformationActionBlock, position.X + 1);
                Canvas.SetTop((UIElement)resultTransferInformation.transferInformationActionBlock, position.Y + 1);

            }
            else if (e.Data.GetDataPresent(typeof(ConditionBlock)))
            {
                e.Effects = DragDropEffects.Copy;
                var position = e.GetPosition(destination);
                var dataInformationConditionBlock = (ConditionBlock)e.Data.GetData(typeof(ConditionBlock)); 
                UIElement conditionBlockOfUIElement;
                if (dataInformationConditionBlock.GetUIElementWithoutCreate() == null)
                {
                    conditionBlockOfUIElement = ((ConditionBlock)e.Data.GetData(typeof(ConditionBlock))).GetUIElement();
                    destination.Children.Add(conditionBlockOfUIElement);
                }
                else
                {
                    conditionBlockOfUIElement = ((ConditionBlock)e.Data.GetData(typeof(ConditionBlock))).GetUIElement();
                }
                Canvas.SetLeft(conditionBlockOfUIElement, position.X + 1);
                Canvas.SetTop(conditionBlockOfUIElement, position.Y + 1);

            }
            else if (e.Data.GetDataPresent(typeof(ConditionBlockForMovements)))
            {
                e.Effects = DragDropEffects.Copy;
                var position = e.GetPosition(destination);
                var resultTransferInformation = (ConditionBlockForMovements)e.Data.GetData(typeof(ConditionBlockForMovements));
                Canvas.SetLeft((UIElement)resultTransferInformation.transferInformation, position.X + 1);
                Canvas.SetTop((UIElement)resultTransferInformation.transferInformation, position.Y + 1);

            }
            else if (e.Data.GetDataPresent(typeof(StartEndBlock)))
            {
                e.Effects = DragDropEffects.Copy;
                var position = e.GetPosition(destination);
                var dataInformationOfStartEndBlock = (StartEndBlock)e.Data.GetData(typeof(StartEndBlock)); 
                UIElement startEndBlockOfUIElement;
                if (dataInformationOfStartEndBlock.GetUIElementWithoutCreate() == null)
                {
                    startEndBlockOfUIElement = ((StartEndBlock)e.Data.GetData(typeof(StartEndBlock))).GetUIElement();
                    destination.Children.Add(startEndBlockOfUIElement);
                }
                else
                {
                    startEndBlockOfUIElement = ((StartEndBlock)e.Data.GetData(typeof(StartEndBlock))).GetUIElement();
                }
                Canvas.SetLeft(startEndBlockOfUIElement, position.X + 1);
                Canvas.SetTop(startEndBlockOfUIElement, position.Y + 1);

            } 
            else if (e.Data.GetDataPresent(typeof(StartEndBlockForMovements)))
            {
                e.Effects = DragDropEffects.Copy;
                var position = e.GetPosition(destination);
                var resultTransferInformation = (StartEndBlockForMovements)e.Data.GetData(typeof(StartEndBlockForMovements));
                Canvas.SetLeft((UIElement)resultTransferInformation.transferInformation, position.X + 1);
                Canvas.SetTop((UIElement)resultTransferInformation.transferInformation, position.Y + 1);
            } 
            else if (e.Data.GetDataPresent(typeof(InputOutputBlock)))
            {
                e.Effects = DragDropEffects.Copy;
                var position = e.GetPosition(destination);
                var dataInformationOfInputOutputBlock = (InputOutputBlock)e.Data.GetData(typeof(InputOutputBlock)); 
                UIElement inputOutputBlockOfUIElement;
                if (dataInformationOfInputOutputBlock.GetUIElementWithoutCreate() == null)
                {
                    inputOutputBlockOfUIElement = ((InputOutputBlock)e.Data.GetData(typeof(InputOutputBlock))).GetUIElement();
                    destination.Children.Add(inputOutputBlockOfUIElement);
                }
                else
                {
                    inputOutputBlockOfUIElement = ((InputOutputBlock)e.Data.GetData(typeof(InputOutputBlock))).GetUIElement();
                }
                Canvas.SetLeft(inputOutputBlockOfUIElement, position.X + 1);
                Canvas.SetTop(inputOutputBlockOfUIElement, position.Y + 1);

            }
            else if (e.Data.GetDataPresent(typeof(InputOutputBlockForMovements)))
            {
                e.Effects = DragDropEffects.Copy;
                var position = e.GetPosition(destination);
                var resultTransferInformation = (InputOutputBlockForMovements)e.Data.GetData(typeof(InputOutputBlockForMovements));
                Canvas.SetLeft((UIElement)resultTransferInformation.transferInformation, position.X + 1);
                Canvas.SetTop((UIElement)resultTransferInformation.transferInformation, position.Y + 1);
            }
            else if (e.Data.GetDataPresent(typeof(SubroutineBlock)))
            {
                e.Effects = DragDropEffects.Copy;
                var position = e.GetPosition(destination);
                var dataInformationOfSubroutineBlock = (SubroutineBlock)e.Data.GetData(typeof(SubroutineBlock));
                UIElement subroutineBlockOfUIElement;
                if (dataInformationOfSubroutineBlock.GetUIElementWithoutCreate() == null)
                {
                    subroutineBlockOfUIElement = ((SubroutineBlock)e.Data.GetData(typeof(SubroutineBlock))).GetUIElement();
                    destination.Children.Add(subroutineBlockOfUIElement);
                }
                else
                {
                    subroutineBlockOfUIElement = ((SubroutineBlock)e.Data.GetData(typeof(SubroutineBlock))).GetUIElement();
                }
                Canvas.SetLeft(subroutineBlockOfUIElement, position.X + 1);
                Canvas.SetTop(subroutineBlockOfUIElement, position.Y + 1);

            }
            else if (e.Data.GetDataPresent(typeof(SubroutineBlockForMovements)))
            {
                e.Effects = DragDropEffects.Copy;
                var position = e.GetPosition(destination);
                var resultTransferInformation = (SubroutineBlockForMovements)e.Data.GetData(typeof(SubroutineBlockForMovements));
                Canvas.SetLeft((UIElement)resultTransferInformation.transferInformation, position.X + 1);
                Canvas.SetTop((UIElement)resultTransferInformation.transferInformation, position.Y + 1);
            }
            else if (e.Data.GetDataPresent(typeof(LinkBlock)))
            {
                e.Effects = DragDropEffects.Copy;
                var position = e.GetPosition(destination);
                var dataInformationOfLinkBlock = (LinkBlock)e.Data.GetData(typeof(LinkBlock));
                UIElement linkBlockOfUIElement;
                if (dataInformationOfLinkBlock.GetUIElementWithoutCreate() == null)
                {
                    linkBlockOfUIElement = ((LinkBlock)e.Data.GetData(typeof(LinkBlock))).GetUIElement();
                    destination.Children.Add(linkBlockOfUIElement);
                }
                else
                {
                    linkBlockOfUIElement = ((LinkBlock)e.Data.GetData(typeof(LinkBlock))).GetUIElement();
                }
                Canvas.SetLeft(linkBlockOfUIElement, position.X + 1);
                Canvas.SetTop(linkBlockOfUIElement, position.Y + 1);

            }
            else if (e.Data.GetDataPresent(typeof(LinkBlockForMovements)))
            {
                e.Effects = DragDropEffects.Copy;
                var position = e.GetPosition(destination);
                var resultTransferInformation = (LinkBlockForMovements)e.Data.GetData(typeof(LinkBlockForMovements));
                Canvas.SetLeft((UIElement)resultTransferInformation.transferInformation, position.X + 1);
                Canvas.SetTop((UIElement)resultTransferInformation.transferInformation, position.Y + 1);
            }
            else e.Effects = DragDropEffects.None;
            e.Handled = true;
        }

        private void destination_DragLeave(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ActionBlock)))
            {
                var actionBlockOfUIElement = ((ActionBlock)e.Data.GetData(typeof(ActionBlock))).GetUIElement();
                destination.Children.Remove(actionBlockOfUIElement);
                var dataInformationOfActionBlock = (ActionBlock)e.Data.GetData(typeof(ActionBlock));
                dataInformationOfActionBlock.Reset();
            } else if (e.Data.GetDataPresent(typeof(ActionBlockForMovements)))
            {
                var actionBlockForMovementsOfUIElement = ((ActionBlockForMovements)e.Data.GetData(typeof(ActionBlockForMovements))).GetUIElement();
                destination.Children.Remove(actionBlockForMovementsOfUIElement); 
                var dataInformationOfActionBlockForMovements = (ActionBlockForMovements)e.Data.GetData(typeof(ActionBlockForMovements));
                dataInformationOfActionBlockForMovements.Reset();
            }
            else if (e.Data.GetDataPresent(typeof(ConditionBlock)))
            {
                var conditionBlockOfUIElement = ((ConditionBlock)e.Data.GetData(typeof(ConditionBlock))).GetUIElement();
                destination.Children.Remove(conditionBlockOfUIElement);
                var dataInformationOfconditionBlock = (ConditionBlock)e.Data.GetData(typeof(ConditionBlock));
                dataInformationOfconditionBlock.Reset();
            }
            else if (e.Data.GetDataPresent(typeof(ConditionBlockForMovements)))
            {
                var startEndBlockOfUIElement = ((ConditionBlockForMovements)e.Data.GetData(typeof(ConditionBlockForMovements))).GetUIElement();
                destination.Children.Remove(startEndBlockOfUIElement);
                var dataInformationOfStartEndBlock = (ConditionBlockForMovements)e.Data.GetData(typeof(ConditionBlockForMovements));
                dataInformationOfStartEndBlock.Reset();
            }
            else if (e.Data.GetDataPresent(typeof(StartEndBlock)))
            {
                var startEndBlockOfUIElement = ((StartEndBlock)e.Data.GetData(typeof(StartEndBlock))).GetUIElement();
                destination.Children.Remove(startEndBlockOfUIElement);
                var dataInformationOfStartEndBlock = (StartEndBlock)e.Data.GetData(typeof(StartEndBlock));
                dataInformationOfStartEndBlock.Reset();
            } 
            else if(e.Data.GetDataPresent(typeof(StartEndBlockForMovements)))
            {
                var startEndBlockOfUIElement = ((StartEndBlockForMovements)e.Data.GetData(typeof(StartEndBlockForMovements))).GetUIElement();
                destination.Children.Remove(startEndBlockOfUIElement);
                var dataInformationOfStartEndBlock = (StartEndBlockForMovements)e.Data.GetData(typeof(StartEndBlockForMovements));
                dataInformationOfStartEndBlock.Reset();
            }
            else if (e.Data.GetDataPresent(typeof(SubroutineBlock)))
            {
                var startEndBlockOfUIElement = ((SubroutineBlock)e.Data.GetData(typeof(SubroutineBlock))).GetUIElement();
                destination.Children.Remove(startEndBlockOfUIElement);
                var dataInformationOfStartEndBlock = (SubroutineBlock)e.Data.GetData(typeof(SubroutineBlock));
                dataInformationOfStartEndBlock.Reset();
            }
            else if (e.Data.GetDataPresent(typeof(SubroutineBlockForMovements)))
            {
                var startEndBlockOfUIElement = ((SubroutineBlockForMovements)e.Data.GetData(typeof(SubroutineBlockForMovements))).GetUIElement();
                destination.Children.Remove(startEndBlockOfUIElement);
                var dataInformationOfStartEndBlock = (SubroutineBlockForMovements)e.Data.GetData(typeof(SubroutineBlockForMovements));
                dataInformationOfStartEndBlock.Reset();
            }
            else if (e.Data.GetDataPresent(typeof(LinkBlock)))
            {
                var startEndBlockOfUIElement = ((LinkBlock)e.Data.GetData(typeof(LinkBlock))).GetUIElement();
                destination.Children.Remove(startEndBlockOfUIElement);
                var dataInformationOfStartEndBlock = (LinkBlock)e.Data.GetData(typeof(LinkBlock));
                dataInformationOfStartEndBlock.Reset();
            }
            else if (e.Data.GetDataPresent(typeof(LinkBlockForMovements)))
            {
                var startEndBlockOfUIElement = ((LinkBlockForMovements)e.Data.GetData(typeof(LinkBlockForMovements))).GetUIElement();
                destination.Children.Remove(startEndBlockOfUIElement);
                var dataInformationOfStartEndBlock = (LinkBlockForMovements)e.Data.GetData(typeof(LinkBlockForMovements));
                dataInformationOfStartEndBlock.Reset();
            }
            e.Handled = true;
        }
    }
}