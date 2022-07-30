using System;
using System.Collections.Generic;
using System.Windows.Shapes;

namespace Flowchart_Editor.Models.LineConnection
{
    public class MyLine
    {
        private Line[]? firstLine;
        private Line[]? secondLine;
        private Line[]? thirdLine;
        private Line[]? fourthLine;
        private Block? firstBlock;
        private Block? secondBlock;

        public MyLine(Block firstBlock, Block secondBlock, params Line[] lineConnection)
        {
            int i = 0;
            if (firstLine == null)
            {
                firstLine = new Line[5];
                foreach (Line line in lineConnection)
                {
                    firstLine[i] = line;
                    i++;
                }
            }
            else if (secondLine == null)
            {
                secondLine = new Line[5];
                foreach (Line line in lineConnection)
                {
                    secondLine[i] = line;
                    i++;
                }
            }
            else if (thirdLine == null)
            {
                thirdLine = new Line[5];
                foreach (Line line in lineConnection)
                {
                    thirdLine[i] = line;
                    i++;
                }
            }
            else if (fourthLine == null)
            {
                fourthLine = new Line[5];
                foreach (Line line in lineConnection)
                {
                    fourthLine[i] = line;
                    i++;
                }
            }
            this.firstBlock = firstBlock;
            this.secondBlock = secondBlock;
        }
        public Block? GetFirstBlock() => firstBlock;
        public Block? GetSecondBlock() => secondBlock;

        public Line[]? GetFirtLine() => firstLine;
    }
}
