using System.Windows.Media;
using Flowchart_Editor.Models;
using System.Collections.Generic;

namespace Flowchart_Editor.View.Menu.ToolBar
{
    public class FontFamilyTextField
    {
        public static void SetFontFamily(List<Block> listHighlightedBlock, FontFamily fontFamily)
        {
            foreach (Block block in listHighlightedBlock)
                block.SetFontFamily(fontFamily);
        }
    }
}
