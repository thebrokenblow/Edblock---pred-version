using System.Windows.Controls;
using Flowchart_Editor.View.StylyTextField;


namespace Flowchart_Editor.View.Menu.ToolBar
{
    /// <summary>
    /// Логика взаимодействия для FontFamily.xaml
    /// </summary>
    public partial class FontFamily : UserControl
    {
        public static int test = 0;
        public FontFamily()
        {
            InitializeComponent();
            var StylyText2 = new StylyText(listFontFamily);
        }
    }
}
