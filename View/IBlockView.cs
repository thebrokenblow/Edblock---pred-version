using Flowchart_Editor.Models;

namespace Flowchart_Editor.View
{
    public interface IBlockView
    {
        Block GetBlock(MainWindow mainWindow, int key);
    }
}
