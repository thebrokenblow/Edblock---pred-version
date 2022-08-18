using Flowchart_Editor.Models;
using System.Collections.Generic;

namespace Flowchart_Editor.View.Menu.ToolBar.FormatAlignTextField
{
    public class FormatAlignTextField
    {
        public static void SetFormatAlignTextField(List<Block> listHighlightedBlock, string formatAlign)
        {
            foreach (Block itemBlock in listHighlightedBlock)
                itemBlock.SetFormatAlign(formatAlign);
        }
    }
}
