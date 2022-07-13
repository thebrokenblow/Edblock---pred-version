using System.Windows;
using System.Windows.Controls;

namespace Flowchart_Editor.View.Menu.OpenCloseMenu
{
    public class MenuCloseOpen
    {
        public MenuCloseOpen(Button buttonCloseMenu, Button buttonOpenMenu)
        {
            buttonOpenMenu.Visibility = Visibility.Visible;
            buttonCloseMenu.Visibility = Visibility.Collapsed;
        }
    }
}
