using System.Windows;
using System.Windows.Controls;

namespace Flowchart_Editor.View.Menu.ToolBar
{
    /// <summary>
    /// Логика взаимодействия для HeightBlock.xaml
    /// </summary>
    public partial class HeightBlock : UserControl
    {
        public HeightBlock()
        {
            InitializeComponent();
        }
        private void LoadedHeightComboBox(object sender, RoutedEventArgs e)
        {
            for (int i = 60; i <= 250; i += 10)
                heightComboBox.Items.Add(i);
        }
    }
}
