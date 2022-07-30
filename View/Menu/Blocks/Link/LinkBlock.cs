using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Controls;

namespace Flowchart_Editor.Models
{
    [BlockName("LinkBlock")]
    public class LinkBlock : Block
    {
        private readonly int width = DefaultPropertyForBlock.width / 2;
        private readonly int defaultWidth = DefaultPropertyForBlock.height / 2;
        private readonly int defaulHeight = DefaultPropertyForBlock.height / 2;

        public LinkBlock(Canvas destination)
        {
            EditField = destination;
            blockWidthCoefficient = 0.5;
            blockHeightCoefficient = 0.5;
            initialText = "Ссылка";
        }

        override public UIElement GetUIElement()
        {
            if (FrameBlock == null)
            {
                FrameBlock = new Canvas();
                //ellipse = new Ellipse();
                TextBoxOfBlock = new TextBox();
                TextBlockOfBlock = new TextBlock();
                

                BrushConverter brushConverter = new();
                Brush backgroundColor = (Brush)brushConverter.ConvertFrom("#FF5761A8");

                SetPropertyFrameBlock(DefaultPropertyForBlock.height, DefaultPropertyForBlock.height);

                //ellipse.Width = defaultWidth;
                //ellipse.Height = defaulHeight;
                //ellipse.Fill = backgroundColor;

                //SetPropertyForTextBox(defaulHeight / 2, defaulHeight / 2, "", 7, 5);

                //SetPropertyForTextBlock(defaulHeight / 2, defaulHeight / 2, 7, 5);

                //SetPropertyPointConnect(firstPointToConnect, defaultWidth / 2 - 3, -2);
                //firstPointToConnect.MouseDown += ClickOnFirstConnectionPoint;

                //SetPropertyPointConnect(secondPointToConnect, -2, defaulHeight / 2 - 3);
                //secondPointToConnect.MouseDown += ClickOnSecondConnectionPoint;

                //SetPropertyPointConnect(thirdPointToConnect, defaulHeight / 2 - 3, defaulHeight - 3);
                //thirdPointToConnect.MouseDown += ClickOnThirdConnectionPoint;

                //SetPropertyPointConnect(fourthPointToConnect, defaultWidth - 3, defaulHeight / 2 - 3);
                //fourthPointToConnect.MouseDown += ClickOnFourthConnectionPoint;

                
                FrameBlock.MouseMove += MouseMoveBlockForMovements;
            }
            return FrameBlock;
        }

        protected override void SetСoordinatesComment(UIElement comment)
        {

           Canvas.SetLeft(comment, DefaultPropertyForBlock.height / 2);
           Canvas.SetTop(comment, defaulHeight / 2);            
        }

        public override void SetWidth(int valueBlockWidth){}

        public override void SetHeight(int valueBlockHeight)
        {
            if (FrameBlock != null)
            {
                FrameBlock.Width = valueBlockHeight / 2;
                FrameBlock.Height = valueBlockHeight / 2;

                //ellipse.Height = valueBlockHeight / 2;
                //ellipse.Width = valueBlockHeight / 2;

                SetPropertyForTextBox(valueBlockHeight / 2 - 12, valueBlockHeight / 2, valueSetLeft: 7, valueSetTop: 5);
                SetPropertyForTextBlock(valueBlockHeight / 2 - 12, valueBlockHeight / 2);

                //Canvas.SetLeft(firstPointConnect, valueBlockHeight / 4 - 3);
                //Canvas.SetTop(firstPointConnect, -2);

                //Canvas.SetLeft(secondPointConnect, -2);
                //Canvas.SetTop(secondPointConnect, valueBlockHeight / 4 - 3);

                //Canvas.SetLeft(thirdPointConnect, valueBlockHeight / 4 - 3);
                //Canvas.SetTop(thirdPointConnect, valueBlockHeight / 2 - 3);

                //Canvas.SetLeft(fourthPointConnect, valueBlockHeight / 2 - 3);
                //Canvas.SetTop(fourthPointConnect, valueBlockHeight / 4 - 3);
            }
        }
        public override double GetWidthCoefficient() => 
            blockWidthCoefficient;

        public override double GetHeightCoefficient() => 
            blockHeightCoefficient;

        public override void SetLeftBlockForConditionCaseSecondOption(UIElement uIElementBlock, double coordinateLeft) =>
            Canvas.SetLeft(uIElementBlock, coordinateLeft + DefaultPropertyForBlock.height);

        public override void SetTopBlockForConditionCaseSecondOption(UIElement uIElementBlock, double coordinateTop) =>
            Canvas.SetTop(uIElementBlock, coordinateTop);

        public override void SetLeftBlockForConditionCaseFirstOption(UIElement uIElementBlock, double coordinateLeft)
        {
            throw new System.NotImplementedException();
        }

        public override void SetTopBlockForConditionCaseFirstOption(UIElement uIElementBlock, double coordinateTop)
        {
            throw new System.NotImplementedException();
        }
    }
}