using Flowchart_Editor.Models;
using System.Collections.Generic;

namespace Flowchart_Editor.View.Menu.ToolBar.WidthBlock
{
    public class WidthBlock
    {
        public static void SetWidth(List<Block> listHighlightedBlock, int valueBlockWidth)
        {
            foreach (Block itemBlock in listHighlightedBlock)
                itemBlock.SetWidth(valueBlockWidth);
        }
    }
}
