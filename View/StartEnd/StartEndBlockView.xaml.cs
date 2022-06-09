using Flowchart_Editor.Models;
using System.Windows.Controls;

namespace Flowchart_Editor.View
{
    /// <summary>
    /// Логика взаимодействия для StartEndBlockView.xaml
    /// </summary>
    public partial class StartEndBlockView : UserControl, IBlockView
    {
        public StartEndBlockView()
        {
            InitializeComponent();
        }

        public Block GetBlock(MainWindow mainWindow, int key) => new StartEndBlock(mainWindow, key);
    }
}
