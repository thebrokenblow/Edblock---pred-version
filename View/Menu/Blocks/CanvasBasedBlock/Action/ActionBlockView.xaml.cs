using Flowchart_Editor.Models;
using System.Windows.Controls;

namespace Flowchart_Editor.View
{
    /// <summary>
    /// Логика взаимодействия для ActionBlockView.xaml
    /// </summary>
    public partial class ActionBlockView : UserControl, IBlockView
    {
        public ActionBlockView()
        {
            InitializeComponent();
        }

        public Block GetBlock(Canvas destination) => 
            new ActionBlock(destination);
    }
}