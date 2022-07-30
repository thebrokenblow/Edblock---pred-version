using System;

namespace Flowchart_Editor
{
    [AttributeUsage(AttributeTargets.All)]
    public class BlockName : Attribute
    {
        private readonly string name;

        public BlockName(string name) => 
            this.name = name;
        public string Name => name;

    }
}
