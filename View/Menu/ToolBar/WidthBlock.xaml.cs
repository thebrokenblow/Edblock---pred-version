using System.Windows;
using System.Windows.Controls;

namespace Flowchart_Editor.View.Menu.ToolBar
{
    /// <summary>
    /// Логика взаимодействия для WidthBlock.xaml
    /// </summary>
    public partial class WidthBlock : UserControl
    {
        public WidthBlock()
        {
            InitializeComponent();
        }

        private void LoadedWidthComboBox(object sender, RoutedEventArgs e)
        {
            for (int i = 110; i <= 250; i += 10)
                widthComboBox.Items.Add(i);
        }
    }
}
