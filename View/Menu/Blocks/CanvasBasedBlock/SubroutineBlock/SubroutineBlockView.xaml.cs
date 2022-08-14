using Flowchart_Editor.Models;
using System.Windows.Controls;

namespace Flowchart_Editor.View
{
    /// <summary>
    /// Логика взаимодействия для SubroutineBlockView.xaml
    /// </summary>
    public partial class SubroutineBlockView : UserControl, IBlockView
    {
        public SubroutineBlockView()
        {
            InitializeComponent();
        }

        public Block GetBlock()
        {
            SubroutineBlock subroutineBlock = new();
            return subroutineBlock;
        }
    }
}