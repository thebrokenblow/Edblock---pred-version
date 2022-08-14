using System.Windows.Controls;
using Flowchart_Editor.Models;

namespace Flowchart_Editor.View
{
    /// <summary>
    /// Логика взаимодействия для CycleBlockWhileBeginView.xaml
    /// </summary>
    public partial class CycleBlockWhileBeginView : UserControl, IBlockView
    {
        public CycleBlockWhileBeginView()
        {
            InitializeComponent();
        }

        public Block GetBlock()
        {
            CycleWhileBeginBlock cycleWhileBeginBlock = new();
            return cycleWhileBeginBlock;
        }
    }
}
