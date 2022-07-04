using Flowchart_Editor.Models;
using System.Windows.Controls;

namespace Flowchart_Editor.View
{
    /// <summary>
    /// Логика взаимодействия для CycleBlockWhileEndView.xaml
    /// </summary>
    public partial class CycleBlockWhileEndView : UserControl, IBlockView
    {
        public CycleBlockWhileEndView()
        {
            InitializeComponent();
        }

        public Block GetBlock(Edblock mainWindow, int key) => new CycleWhileEndBlock(mainWindow, key);
    }
}
