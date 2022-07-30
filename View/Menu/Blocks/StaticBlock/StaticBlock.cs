namespace Flowchart_Editor.Models
{
    static public class StaticBlock
    {
        public static string FirstPointToConnect { get; set; } = "";
        public static string SecondPointToConnect { get; set; } = "";
        public static Block? Block { get; set; }
        public static object? Sender { get; set; }
        public static bool? ISOOriginLines { get; set; } = true;
        public static bool? ISOLineEntry { get; set; } = true;
        public static bool FlagDeleteBlockOfCase { get; set; } = false;
    }
}