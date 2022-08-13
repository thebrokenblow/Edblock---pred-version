using System.Windows.Media;
using System.Windows.Shapes;
using Flowchart_Editor.Model;
using System.Windows.Controls;

namespace Flowchart_Editor.View.Menu.Blocks.EllipseBasedBlock
{
    public interface IEllipseBased
    {
        public void SetPropertyEllipseBlock();
        
        public static void SetFill(Ellipse ellipsBlock, Brush backgroundColor)
        {
            ellipsBlock.Fill = backgroundColor;
        }

        public static void SetSize(Ellipse ellipseBlock, ControlSize controlSize)
        {
            ellipseBlock.Width = controlSize.Width;
            ellipseBlock.Height = controlSize.Height;
        }

        public static void AddEllipse(Canvas frameBlock, Ellipse ellipseBlock)
        {
            frameBlock.Children.Add(ellipseBlock);
        }
    }
}