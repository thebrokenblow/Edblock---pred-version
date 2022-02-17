using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flowchart_Editor.Models
{
    public class LinkBlockForMovements
    {
        public object? transferInformation = null;
        public LinkBlockForMovements(object sender)
        {
            transferInformation = sender;
        }
    }
}
