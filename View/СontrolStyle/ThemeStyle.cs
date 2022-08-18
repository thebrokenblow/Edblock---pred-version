using MaterialDesignThemes.Wpf;

namespace Flowchart_Editor.View.СontrolsStyle
{
    public class ThemeStyle
    {
        public static void SetTheme(bool isDarkTheme)
        {
            PaletteHelper paletteHelper = new();
            ITheme theme = paletteHelper.GetTheme();
            theme.SetBaseTheme(isDarkTheme ? Theme.Dark : Theme.Light);
            paletteHelper.SetTheme(theme);
        }
    }
}
