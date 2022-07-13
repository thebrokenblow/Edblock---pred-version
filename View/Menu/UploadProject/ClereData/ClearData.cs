using Flowchart_Editor.Models;
using Flowchart_Editor.Models.Comment;
using Flowchart_Editor.View.Condition.Case;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Flowchart_Editor.Menu.UploadProject.ClereData
{
    public class ClearData
    {
        public static void Clear(Canvas canvas, List<Block> listOfBlock, List<Line> listLineConnection, 
            List<CommentControls> listComment, List<CaseBlock> listCaseBlock)
        {
            canvas.Children.Clear();
            listOfBlock.Clear();
            listLineConnection.Clear();
            listComment.Clear();
            listCaseBlock.Clear();
        }
    }
}
