using System;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace Flowchart_Editor.Menu.Theme
{
    public class Theme1
    {
        public static void SetTheme(ToggleButton toggleButtonStyleTheme)
        {
            if (toggleButtonStyleTheme.IsChecked != null)
            {
                if ((bool)toggleButtonStyleTheme.IsChecked)
                    СonnectionTheme("themeForLine");
                else
                    СonnectionTheme("theme");
            }
        }
        public static void СonnectionTheme(string nameOfTheme)
        {
            Uri uri = new($"View/WindowsTheme/{nameOfTheme}.xaml", UriKind.Relative);
            ResourceDictionary? resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }
    }
}
