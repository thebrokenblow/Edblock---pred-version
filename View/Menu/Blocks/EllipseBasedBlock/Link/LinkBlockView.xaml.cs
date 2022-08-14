using Flowchart_Editor.Models;
using System.Windows.Controls;

namespace Flowchart_Editor.View
{
    /// <summary>
    /// Логика взаимодействия для LinkBlockView.xaml
    /// </summary>
    public partial class LinkBlockView : UserControl, IBlockView
    {
        public LinkBlockView()
        {
            InitializeComponent();
        }

        public Block GetBlock()
        {
            LinkBlock linkBlock = new();
            return linkBlock;
        }
    }
}
