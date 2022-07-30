using System.Windows.Controls;
using Flowchart_Editor.Models;

namespace Flowchart_Editor.View
{
    /// <summary>
    /// Логика взаимодействия для ConditionBlockView.xaml
    /// </summary>
    public partial class ConditionBlockView : UserControl, IBlockView
    {
        public ConditionBlockView()
        {
            InitializeComponent();
        }

        public Block GetBlock(Canvas destination) => 
            new ConditionBlock(destination);
    }
}
