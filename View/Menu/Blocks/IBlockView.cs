using Flowchart_Editor.Models;
using System.Windows.Controls;

namespace Flowchart_Editor.View
{
    public interface IBlockView
    {
        Block GetBlock(Canvas destination);
    }
}
