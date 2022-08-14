using Flowchart_Editor.Models;
using System.Windows.Controls;

namespace Flowchart_Editor.View
{
    /// <summary>
    /// Логика взаимодействия для InputOutputBlockView.xaml
    /// </summary>
    public partial class InputOutputBlockView : UserControl, IBlockView
    {
        public InputOutputBlockView()
        {
            InitializeComponent();
        }

        public Block GetBlock()
        {
            InputOutputBlock inputOutputBlock = new();
            return inputOutputBlock;
        }
    }
}
