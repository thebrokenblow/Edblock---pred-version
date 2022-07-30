using Flowchart_Editor.Models;
using Flowchart_Editor.Models.Comment;
using Flowchart_Editor.View.Condition.Case;
using System.Collections.Generic;

namespace Flowchart_Editor.View.ListControllsElement
{
    public struct ListControlls
    {
        public List<Block> ListOfBlock { get; private set; }
        public List<CommentControls> ListComment { get; private set; }
        public List<CaseBlock> ListCaseBlock { get; private set; }
        public ListControlls(List<Block> listOfBlock, List<CommentControls> listComment, List<CaseBlock> listCaseBlock)
        {
            ListOfBlock = listOfBlock;
            ListComment = listComment;
            ListCaseBlock = listCaseBlock;
        }
    }
}
