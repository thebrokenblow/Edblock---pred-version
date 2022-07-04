using Flowchart_Editor.Models;

namespace Flowchart_Editor.View
{
    public interface IBlockView
    {
        Block GetBlock(Edblock mainWindow, int key);
    }
}
