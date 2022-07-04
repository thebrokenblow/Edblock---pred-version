using Flowchart_Editor.Command;
using Flowchart_Editor.Menu.Print;
using Flowchart_Editor.Menu.SaveImg;

namespace Flowchart_Editor.ViewModel
{
    public class ApplicationViewModel
    {
        private RelayCommand? printCommand;
        public RelayCommand PrintCommand
        {
            get
            {
                return printCommand ??= new RelayCommand(obj =>
                {
                    if (Edblock.EditField != null)
                        DoPrint.Print(Edblock.EditField);
                });
            }
        }
        private RelayCommand? imgCommand;
        public RelayCommand ImgCommand
        {
            get
            {
                return imgCommand ??= new RelayCommand(obj =>
                {
                    if (Edblock.EditField != null)
                        SaveImg.Save(Edblock.EditField);
                });
            }
        }
    }
}