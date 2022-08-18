using System.Windows;
using System.Windows.Controls;
using Flowchart_Editor.ViewModel;

namespace Flowchart_Editor.View.Menu.ToolBar
{
    public partial class FormatText : UserControl
    {
        private readonly ApplicationViewModel viewModel = new(Edblock.ListHighlightedBlock);
        public FormatText()
        {
            InitializeComponent();
        }

        private void SelectedFormatBold(object sender, RoutedEventArgs e)
        {
            viewModel.SetFontWeight();
        }

        private void SelectedFormatItalic(object sender, RoutedEventArgs e)
        {
            viewModel.SetFontStyles();
        }

        private void SelectedUnderline(object sender, RoutedEventArgs e)
        {
            viewModel.SetTextDecorations();
        }

        private void UnselectedFormatBold(object sender, RoutedEventArgs e)
        {
            viewModel.UnsetFontWeight();
        }

        private void UnselectedFormatItalic(object sender, RoutedEventArgs e)
        {
            viewModel.UnsetFontStyles();
        }

        private void UnselectedUnderline(object sender, RoutedEventArgs e)
        {
            viewModel.UnsetTextDecorations();
        }
    }
}