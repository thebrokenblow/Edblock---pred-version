using System.Windows.Controls;
using System.Windows.Media;

namespace Flowchart_Editor.View.Menu.Blocks.CanvasBasedBlock
{
    public interface ICanvasBased
    {
        public void SetPropertyCanvasBlock();
        public static void SetBackground(Canvas canvasBlock, Brush backgroundColor)
        {
            canvasBlock.Background = backgroundColor;
        }
    }
}