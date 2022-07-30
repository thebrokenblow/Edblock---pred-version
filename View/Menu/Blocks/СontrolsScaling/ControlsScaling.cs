using Flowchart_Editor.Models;
using Flowchart_Editor.Models.Comment;
using Flowchart_Editor.View.Condition.Case;
using Flowchart_Editor.View.ListControllsElement;

namespace Flowchart_Editor.View.СontrolsScaling
{
    public class ControlsScaling
    {
        public static void ScaleWidth(ListControlls listControlls, int valueBlockWidth)
        {
            foreach (Block itemListOfBlock in listControlls.ListOfBlock)
                itemListOfBlock.SetWidth(valueBlockWidth);

            foreach (CommentControls itemListComment in listControlls.ListComment)
                itemListComment.SetWidth(valueBlockWidth);

            foreach (CaseBlock itemCaseBlock in listControlls.ListCaseBlock)
                itemCaseBlock.SetWidth(valueBlockWidth);
        }

        public static void ScaleHeight(ListControlls listControlls, int valueBlokHeight)
        {
            foreach (Block itemListOfBlock in listControlls.ListOfBlock)
                itemListOfBlock.SetHeight(valueBlokHeight);

            foreach (CommentControls itemListComment in listControlls.ListComment)
                itemListComment.SetHeight(valueBlokHeight);

            foreach (CaseBlock itemCaseBlock in listControlls.ListCaseBlock)
                itemCaseBlock.SetHeight(valueBlokHeight);
        }
    }
}
