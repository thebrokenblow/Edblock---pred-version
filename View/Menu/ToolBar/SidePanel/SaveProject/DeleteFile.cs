using Microsoft.Win32;
using System.IO;

namespace Flowchart_Editor.Menu.SaveProject
{
    public class DeleteFile
    {
        public static void Delete(SaveFileDialog saveFileDialog)
        {
            FileInfo fileInfo = new(saveFileDialog.FileName);
            if (fileInfo.Exists)
                fileInfo.Delete();
        }
    }
}
