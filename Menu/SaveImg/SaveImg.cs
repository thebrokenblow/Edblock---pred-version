using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Flowchart_Editor.Menu.SaveImg
{
    public class SaveImg
    {
        private static int numberImageInSession = 0;
        public static void Save(UIElement uIElement)
        {
            numberImageInSession++;

            SaveFileDialog saveFileDialog = new()
            {
                Filter = "Files(*.jpeg)|*.jpeg|All(*.*)|*"
            };

            RenderTargetBitmap renderTargetBitmap = new(
                (int)uIElement.RenderSize.Width * 300 / 96,
                (int)uIElement.RenderSize.Height * 300 / 96,
                300d,
                300d,
                PixelFormats.Pbgra32
                );

            uIElement.Measure(new Size((int)uIElement.RenderSize.Width, (int)uIElement.RenderSize.Height));
            uIElement.Arrange(new Rect(new Size((int)uIElement.RenderSize.Width, (int)uIElement.RenderSize.Height)));
            renderTargetBitmap.Render(uIElement);

            JpegBitmapEncoder jpegBitmapEncoder = new();

            FileInfo fileInfo = new("Flowchart" + numberImageInSession.ToString() + ".jpeg");
            saveFileDialog.FileName = fileInfo.Name;
            jpegBitmapEncoder.Frames.Add(BitmapFrame.Create(renderTargetBitmap));
            if (saveFileDialog.ShowDialog() == true)
            {
                using FileStream fileStream = File.OpenWrite(saveFileDialog.FileName);
                jpegBitmapEncoder.Save(fileStream);
            }
        }
    }
}
