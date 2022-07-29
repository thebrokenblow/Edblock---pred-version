using System.Windows;
using System.Windows.Controls;

namespace Flowchart_Editor.View.Menu.ToolBar
{
    /// <summary>
    /// Логика взаимодействия для ListFontSize.xaml
    /// </summary>
    public partial class ListFontSize : UserControl
    {
        public ListFontSize()
        {
            InitializeComponent();
        }

        private void LoadedListFontSize(object sender, RoutedEventArgs e)
        {
            for (double i = 8; i <= 26; i += 2)
                listFontSize.Items.Add(i);
        }
    }
}