using Flowchart_Editor.Models;
using System.Collections.Generic;

namespace Flowchart_Editor.View.Menu.ToolBar.FormatTextField
{
    public class FormatTextField
    {
        public static void SetFormat(List<Block> listHighlightedBlock, string formatText)
        {
            foreach (Block itemBlock in listHighlightedBlock)
                itemBlock.SetFormatTextField(formatText);
        }
    }
}
