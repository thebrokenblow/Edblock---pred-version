using System.Windows;
using System.Windows.Controls;

namespace Flowchart_Editor.View.Menu.ToolBar
{
    /// <summary>
    /// Логика взаимодействия для ListHeightBlock.xaml
    /// </summary>
    public partial class ListHeightBlock : UserControl
    {
        public ListHeightBlock()
        {
            InitializeComponent();
        }

        private void LoadedListHeightBlock(object sender, RoutedEventArgs e)
        {
            for (int i = 60; i <= 250; i += 10)
                listHeightBlock.Items.Add(i);
        }
    }
}