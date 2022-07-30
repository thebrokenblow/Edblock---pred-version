using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Flowchart_Editor.Models
{
    [BlockName("ConditionBlock")]
    public class ConditionBlock : Block
    {
        protected List<Point> listPoints = new();
        private readonly int defaultWidth = DefaultPropertyForBlock.width;
        private readonly int defaulHeight = DefaultPropertyForBlock.height;
        public ConditionBlock(Canvas destination)
        {
            EditField = destination;
            blockWidthCoefficient = 1;
            blockHeightCoefficient = 1;
            initialText = "Условие";
        }

        override public UIElement? GetUIElement()
        {
            if (FrameBlock == null)
            {
                double valueSetLeftText = defaultWidth / 2 - defaultWidth / 4;
                double valueSetTopText = defaulHeight / 4;

                SetPropertyFrameBlock(defaultWidth, defaulHeight);

                SetPropertyForTextBox(defaultWidth, defaulHeight, initialText);

                SetPropertyForTextBox(defaultWidth / 2, defaulHeight / 2, initialText, valueSetLeftText, valueSetTopText);

                SetPropertyForTextBlock(defaultWidth / 2, defaulHeight / 2, initialText, valueSetLeftText, valueSetTopText);

                BrushConverter brushConverter = new();
                Brush backgroundColor = (Brush)brushConverter.ConvertFrom("#FF60B2D3");
                polygonBlock.Fill = backgroundColor;

                Point Point1 = new(0, defaulHeight / 2);
                listPoints.Add(Point1);
                Point Point2 = new(defaultWidth / 2, defaulHeight);
                listPoints.Add(Point2);
                Point Point3 = new(defaultWidth, defaulHeight / 2);
                listPoints.Add(Point3);
                Point Point4 = new(defaultWidth / 2, 0);
                listPoints.Add(Point4);
                Point Point5 = new(0, defaulHeight / 2);
                listPoints.Add(Point5);
                SetPointPolygon(listPoints);

                //InitializingConnectionPoints();

                //SetPropertyPointConnect(firstPointConnect, defaultWidth / 2 - 2, -2);

                //SetPropertyPointConnect(secondPointConnect, 0, defaulHeight / 2 - 2);

                //SetPropertyPointConnect(thirdPointConnect, defaultWidth / 2 - 2, defaulHeight - 2);

                //SetPropertyPointConnect(fourthPointConnect, defaultWidth - 2 * 2, defaulHeight / 2 - 2);

                AddTextFields();

                AddConnectionPoints();
            }
            return FrameBlock ?? null;
        }

        protected override void SetСoordinatesComment(UIElement comment)
        {
            Canvas.SetTop(comment, DefaultPropertyForBlock.height / 2);
            Canvas.SetLeft(comment, DefaultPropertyForBlock.width);
        }

        public override void SetWidth(int valueBlockWidth)
        {
            SetSizePolygon(listPoints, DefaultPropertyForBlock.height, valueBlockWidth);
            double valueSetLeftText = valueBlockWidth / 2 - valueBlockWidth / 4;
            double valueSetTopText = DefaultPropertyForBlock.height / 4;

            SetPropertyForTextBox(valueBlockWidth / 2, DefaultPropertyForBlock.height / 2, valueSetLeft: valueSetLeftText, valueSetTop: valueSetTopText);
            SetPropertyForTextBlock(valueBlockWidth / 2, DefaultPropertyForBlock.height / 2, valueSetLeft: valueSetLeftText, valueSetTop: valueSetTopText);

            //Canvas.SetLeft(firstPointConnect, valueBlockWidth / 2 - 3);
            //Canvas.SetLeft(secondPointConnect, 0);
            //Canvas.SetLeft(thirdPointConnect, valueBlockWidth / 2 - 3);
            //Canvas.SetLeft(fourthPointConnect, valueBlockWidth - 6);
        }

        public override void SetHeight(int valueBlockHeight)
        {
            SetSizePolygon(listPoints, valueBlockHeight, DefaultPropertyForBlock.width);
            double valueSetLeftText = DefaultPropertyForBlock.width / 2 - DefaultPropertyForBlock.width / 4;
            double valueSetTopText = valueBlockHeight / 4;

            SetPropertyForTextBox(DefaultPropertyForBlock.width / 2, valueBlockHeight / 2, valueSetLeft: valueSetLeftText, valueSetTop: valueSetTopText);
            SetPropertyForTextBlock(DefaultPropertyForBlock.width / 2, valueBlockHeight / 2, valueSetLeft: valueSetLeftText, valueSetTop: valueSetTopText);

            //Canvas.SetTop(firstPointConnect, -2);
            //Canvas.SetTop(secondPointConnect, valueBlockHeight / 2 - 3);
            //Canvas.SetTop(thirdPointConnect, valueBlockHeight - 3);
            //Canvas.SetTop(fourthPointConnect, valueBlockHeight / 2 - 3);
        }

        public override double GetWidthCoefficient() => 
            blockWidthCoefficient;

        public override double GetHeightCoefficient() => 
            blockHeightCoefficient;

        public override void SetLeftBlockForConditionCaseSecondOption(UIElement uIElementBlock, double coordinateLeft) => 
            Canvas.SetLeft(uIElementBlock, coordinateLeft);

        public override void SetTopBlockForConditionCaseSecondOption(UIElement uIElementBlock, double coordinateTop) =>
            Canvas.SetTop(uIElementBlock, coordinateTop);

        public override void SetLeftBlockForConditionCaseFirstOption(UIElement uIElementBlock, double coordinateLeft) =>
             Canvas.SetLeft(uIElementBlock, coordinateLeft - 1);

        public override void SetTopBlockForConditionCaseFirstOption(UIElement uIElementBlock, double coordinateTop) =>
            Canvas.SetTop(uIElementBlock, coordinateTop - DefaultPropertyForBlock.height / 2);
    }
}