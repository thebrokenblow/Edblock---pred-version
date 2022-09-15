using System.Windows.Shapes;
using Flowchart_Editor.Models;
using System.Windows.Controls;
using System.Collections.Generic;
using Flowchart_Editor.View.Menu.Blocks.PolygonBasedBlock;
using System;

namespace Flowchart_Editor.View.Condition.Case
{
    public abstract class CaseBlock : ConditionBlock
    {
        protected int countLineCase;
        protected List<Tuple<Line, TextBox>> linesCase;
        protected Line baseLine;
        protected PolygonBased caseBlock;
        public CaseBlock() : base()
        {
            linesCase = new();
            baseLine = new();
            caseBlock = new();
        }

        protected abstract void DrawLine();
    }
}