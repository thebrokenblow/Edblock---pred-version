using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flowchart_Editor.Models
{
    public class InputOutputBlockForMovements
    {
        public object transferInformation = null;
        public InputOutputBlockForMovements(object sender)
        {
            transferInformation = sender;
        }
    }
}
