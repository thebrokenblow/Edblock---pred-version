using System.Windows;
using System.Windows.Controls;

namespace Flowchart_Editor.View.Menu.ToolBar
{
    /// <summary>
    /// Логика взаимодействия для ListWidthBlock.xaml
    /// </summary>
    public partial class ListWidthBlock : UserControl
    {
        public ListWidthBlock()
        {
            InitializeComponent();
        }

        private void LoadedListWidthBlock(object sender, RoutedEventArgs e)
        {
            for (int i = 110; i <= 250; i += 10)
                listWidthBlock.Items.Add(i);
        }
    }
}