namespace Flowchart_Editor.Model
{
    public class StyleModel
    {
        public string? fontFamily { get; private set; }
        public string? fontSize { get; private set; }
        public StyleModel(string? fontFamily, string? fontSize)
        {
            if (fontFamily != null && fontSize != null)
            {
                this.fontFamily = fontFamily;
                this.fontSize = fontSize;
            }
        }
    }
}
