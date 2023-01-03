using Flowchart_Editor.Models;
using System.Collections.Generic;

namespace Flowchart_Editor.View.Menu.ToolBar.HeightBlock
{
    public class HeightBlock
    {
        public static void SetHeight(List<Block> listHighlightedBlock, int valueBlokHeight)
        {
            foreach (Block itemBlock in listHighlightedBlock)
                itemBlock.SetHeight(valueBlokHeight);
        }
    }
}
