using Flowchart_Editor.Command;
using Flowchart_Editor.Menu.Print;
using Flowchart_Editor.Menu.SaveImg;
using Flowchart_Editor.Menu.SaveProject;
using Flowchart_Editor.Models;
using Flowchart_Editor.View.Menu.ToolBar;
using Flowchart_Editor.View.Menu.ToolBar.FontSizeTextField;
using Flowchart_Editor.View.Menu.ToolBar.HeightBlock;
using Flowchart_Editor.View.Menu.ToolBar.WidthBlock;
using Flowchart_Editor.View.СontrolsStyle;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Media;

namespace Flowchart_Editor.ViewModel
{
    public class ApplicationViewModel : IDataErrorInfo, INotifyPropertyChanged
    {
        private readonly List<Block> listHighlightedBlock;
        private readonly Canvas editField;
        public ApplicationViewModel(Canvas editField, List<Block> listHighlightedBlock)
        {
            this.editField = editField;
            this.listHighlightedBlock = listHighlightedBlock;
        }

        
        public ApplicationViewModel()
        {
            
        }



        public static bool StyleTheme
        {
            set
            {
                ThemeStyle.SetTheme(value);
            }
        } 

        private RelayCommand? printCommand;
        public RelayCommand PrintCommand
        {
            get
            {
                return printCommand ??= new RelayCommand(obj =>
                {
                    Print.DoPrint(editField);
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
                    ImgEditField.SaveImg(editField);
                });
            }
        }

        private bool flagErrorConditionFirst = false;
        public string CountLineConditionFirst { get; set; } = "2";
        private RelayCommand? addConditionFirst;
        public RelayCommand AddConditionFirst
        {
            get
            {
                return addConditionFirst ??= new RelayCommand(obj =>
                {
                    //if (!flagErrorConditionFirst && Edblock.EditField != null)
                    //{
                    //    CaseFirstOption conditionCaseFirstOptionBlock = new(Edblock.EditField, Convert.ToInt32(CountLineConditionFirst));
                    //    Edblock.EditField.Children.Add(conditionCaseFirstOptionBlock.GetUIElement());
                    //    Edblock.ListCaseBlock.Add(conditionCaseFirstOptionBlock);
                    //}
                });
            }
        }

        private bool flagErrorConditionSecond = false;
        public string CountLineConditionSecond { get; set; } = "2";
        private RelayCommand? addConditionSecond;
        public RelayCommand AddConditionSecond
        {
            get
            {
                return addConditionSecond ??= new RelayCommand(obj =>
                {
                    //if (!flagErrorConditionSecond && Edblock.EditField != null)
                    //{
                    //    CaseSecondOption conditionCaseFirstOptionBlock = new(Edblock.EditField, Convert.ToInt32(CountLineConditionSecond));
                    //    Edblock.EditField.Children.Add(conditionCaseFirstOptionBlock.GetUIElement());
                    //    Edblock.ListCaseBlock.Add(conditionCaseFirstOptionBlock);
                    //}
                });
            }
        }

        
        public FontFamily FontFamily
        {
            set
            {
                FontFamilyTextField.SetFontFamily(listHighlightedBlock, value);
            }
        }

        public double FontSize
        {
            set
            {
                FontSizeTextField.SetFontSize(listHighlightedBlock, value);
            }
        }

        public int BlockWidth
        {
            set
            {
                WidthBlock.SetWidth(listHighlightedBlock, value);
            }
        }

        public int BlockHeight
        {
            set
            {
                HeightBlock.SetHeight(listHighlightedBlock, value);
            }
        }

        public string this[string columnName]
        {
            get
            {
                //TODO: разобраться с валидацией, неправильно работает
                string errorAddCondition = "";
                switch (columnName)
                {
                    case "CountLineConditionFirst":
                        bool isNumeric = int.TryParse(CountLineConditionFirst, out int n);
                        if (!isNumeric)
                        {
                            errorAddCondition = "Вы введи не число";
                            
                             flagErrorConditionFirst = true;
                        }
                        if (n <= 1)
                            errorAddCondition = "Значение должно быть больше 1";
                        else
                            flagErrorConditionFirst = false;
                        break;
                    case "CountLineConditionSecond":
                        bool isNumeric1 = int.TryParse(CountLineConditionSecond, out int n1);
                        if (!isNumeric1)
                        {
                            errorAddCondition = "Вы введи не число";
                            if (n1 <= 1)
                                errorAddCondition = "Значение должно быть больше 1";
                            flagErrorConditionFirst = true;
                        }
                        else
                            flagErrorConditionSecond = false;
                        break;
                }
                return errorAddCondition;
            }
        }

        public string Error => throw new NotImplementedException();


        private RelayCommand? saveProjectCommand;
        public RelayCommand SaveProjectCommand
        {
            get
            {
                return saveProjectCommand ??= new RelayCommand(obj =>
                {
                    string? fontFamily = "";//Edblock.StylyText.GetFontFamily();
                    string? fonSize = "";// Edblock.StylyText.GetFontSize();
                    SaveProject.Save(fontFamily, fonSize);
                });
            }
        }


        private RelayCommand? uploadProjectCommand;

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public RelayCommand UploadProjectCommand
        {
            get
            {
                return uploadProjectCommand ??= new RelayCommand(obj =>
                {

                });
            }
        }
    }
}