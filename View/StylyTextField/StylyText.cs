using System.Windows.Controls;

namespace Flowchart_Editor.View.StylyTextField
{
    public struct StylyText
    {
        public ComboBox ListFontFamily { get; private set; }
        //public ComboBox ListFontSize { get; private set; }
        public StylyText(ComboBox listFontFamily)
        {
            ListFontFamily = listFontFamily;
        }
        //public StylyText(ComboBox listFontSize)
        //{
        //    ListFontSize = listFontSize;
        //}
       
        public string? GetFontFamily() =>
            ListFontFamily?.SelectedValue?.ToString();

        public string? GetFontSize() =>
            "";
        //public string? GetFontSize() =>
        //    ((ComboBoxItem)ListFontSize.SelectedItem)?.Content.ToString();
    }
}
