using Flowchart_Editor.Models;
using System.Windows;
using System.Windows.Controls;

namespace Flowchart_Editor
{
    /// <summary>
    /// Логика взаимодействия для Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public Settings()
        {
            InitializeComponent();
            //checkBoxOriginLine.IsChecked = StaticBlock.ISOOriginLines;
            //checkBoxLineEntry.IsChecked = StaticBlock.ISOLineEntry;
        }

        //private void CheckedLineEntry(object sender, RoutedEventArgs e) =>
        //    StaticBlock.ISOLineEntry = ((CheckBox)sender).IsChecked;

        //private void CheckedOriginLine(object sender, RoutedEventArgs e) =>
        //    StaticBlock.ISOOriginLines = ((CheckBox)sender).IsChecked;

    }
}
