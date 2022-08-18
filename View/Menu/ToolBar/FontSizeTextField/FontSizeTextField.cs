using Flowchart_Editor.Models;
using System.Collections.Generic;

namespace Flowchart_Editor.View.Menu.ToolBar.FontSizeTextField
{
    public class FontSizeTextField
    {
        public static void SetFontSize(List<Block> listHighlightedBlock, double fontSize)
        {
            foreach (Block block in listHighlightedBlock)
                block.SetFontSize(fontSize);
        }
    }
}
