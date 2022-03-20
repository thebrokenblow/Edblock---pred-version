using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flowchart_Editor.Models.Comment
{
    public class CommentForMovements
    {
        public object? transferInformation = null;
        public CommentForMovements(object sender)
        {
            transferInformation = sender;
        }
    }
}
