using Flowchart_Editor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Flowchart_Editor.View.Menu.Blocks.RectangleBaseBlock
{
    public interface IRectangleBased
    {
        public void SetPropertyRectangleBlock();

        public static void SetFill(Rectangle rectangleBlock, Brush backgroundColor)
        {
            rectangleBlock.Fill = backgroundColor;
        }

        public static void SetSize(Rectangle rectangleBlock, ControlSize controlSize)
        {
            rectangleBlock.Width = controlSize.Width;
            rectangleBlock.Height = controlSize.Height;
        }

        public static void SetRadius(Rectangle rectangleBlock, int radiusX, int radiusY)
        {
            rectangleBlock.RadiusX = radiusX;
            rectangleBlock.RadiusY = radiusY;
        }

        public static void AddRectangle(Canvas frameBlock, Rectangle rectangleBlock)
        {
            frameBlock.Children.Add(rectangleBlock);
        }
    }
}
