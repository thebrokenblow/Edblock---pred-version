using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Flowchart_Editor.View.Menu.ToolBar
{
    /// <summary>
    /// Логика взаимодействия для ListFontFamily.xaml
    /// </summary>
    public partial class ListFontFamily : UserControl
    {
        public ListFontFamily()
        {
            InitializeComponent();
        }

        public void LoadedListFontFamily(object sender, RoutedEventArgs e)
        {
            FontFamily fontFamily = new("Times New Roman");
            listFontFamily.Items.Add(fontFamily);

            fontFamily = new("Calibri");
            listFontFamily.Items.Add(fontFamily);

            fontFamily = new("Proxima Nova");
            listFontFamily.Items.Add(fontFamily);

            fontFamily = new("Helvetica Neue Cyr");
            listFontFamily.Items.Add(fontFamily);

            fontFamily = new("San Francisco");
            listFontFamily.Items.Add(fontFamily);

            fontFamily = new("Gotham Pro");
            listFontFamily.Items.Add(fontFamily);

            fontFamily = new("Yandex Sans");
            listFontFamily.Items.Add(fontFamily);

            fontFamily = new("DIN Pro");
            listFontFamily.Items.Add(fontFamily);

            fontFamily = new("Geometria");
            listFontFamily.Items.Add(fontFamily);

            fontFamily = new("Montserrat");
            listFontFamily.Items.Add(fontFamily);
        }
    }
}