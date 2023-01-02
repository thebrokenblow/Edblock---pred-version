using System;
using System.Windows.Media;
using System.ComponentModel;
using System.Windows.Controls;
using Flowchart_Editor.Models;
using MaterialDesignThemes.Wpf;
using Flowchart_Editor.Command;
using System.Collections.Generic;
using Flowchart_Editor.Menu.Print;
using Flowchart_Editor.Menu.SaveImg;
using Flowchart_Editor.Menu.SaveProject;
using Flowchart_Editor.View.Menu.ToolBar;
using Flowchart_Editor.View.СontrolsStyle;
using Flowchart_Editor.View.Menu.ToolBar.FontSizeTextField;
using Flowchart_Editor.View.Menu.ToolBar.FormatAlignTextField;
using Flowchart_Editor.View.Menu.ToolBar.HeightBlock;
using Flowchart_Editor.View.Menu.ToolBar.WidthBlock;
using Flowchart_Editor.View.ConditionCaseSecondOption;
using Flowchart_Editor.View.ConditionCaseFirstOption;
using Flowchart_Editor.View.Menu.Blocks;
using System.Windows.Shapes;
using Flowchart_Editor.View.Menu.ConnectionLine;

namespace Flowchart_Editor.ViewModel
{
    public class ApplicationViewModel : IDataErrorInfo
    {
        private readonly List<Block>? listBlock;
        private readonly List<Block> listHighlightedBlock;
        private readonly Canvas? editField;
        private readonly List<Block> listCopyBlock;

        public ApplicationViewModel(Canvas editField, List<Block> listBlock, List<Block> listHighlightedBlock)
        {
            this.editField = editField;
            this.listBlock = listBlock;
            this.listHighlightedBlock = listHighlightedBlock;
            listCopyBlock = new();
        }

        public ApplicationViewModel(List<Block> listHighlightedBlock)
        {
            this.listHighlightedBlock = listHighlightedBlock;
            listCopyBlock = new();
        }

        

        public ListBoxItem SelectedFormatAlign
        {
            set
            {
                if (value != null)
                {
                    object itemContent = value.Content;
                    PackIcon packIconValue = (PackIcon)itemContent;
                    string formatAlign = packIconValue.Kind.ToString();
                    FormatAlignTextField.SetFormatAlignTextField(listHighlightedBlock, formatAlign);
                }
            }
        }

        

        public void SetFontWeight()
        {
            foreach (Block itemBlock in listHighlightedBlock)
                itemBlock.SetFontWeight();
        }

        public void SetFontStyles()
        {
            foreach (Block itemBlock in listHighlightedBlock)
                itemBlock.SetFontStyles();
        }

        public void SetTextDecorations()
        {
            foreach (Block itemBlock in listHighlightedBlock)
                itemBlock.SetTextDecorations();
        }

        public void UnsetFontWeight()
        {
            foreach (Block itemBlock in listHighlightedBlock)
                itemBlock.UnsetFontWeight();
        }

        public void UnsetFontStyles()
        {
            foreach (Block itemBlock in listHighlightedBlock)
                itemBlock.UnsetFontStyles();
        }

        public void UnsetTextDecorations()
        {
            foreach (Block itemBlock in listHighlightedBlock)
                itemBlock.UnsetTextDecorations();
        }

        public static bool StyleTheme
        {
            set
            {
                ThemeStyle.SetTheme(value);
            }
        }

        private RelayCommand? copyBlock;
        public RelayCommand CopyBlock
        {
            get
            {
                return copyBlock ??= new RelayCommand(obj =>
                {
                    foreach (Block itemBlock in listHighlightedBlock)
                    {
                        Block copyBlock = itemBlock.GetCopyBlock();
                        listCopyBlock.Add(copyBlock);
                    }
                    foreach (Block blockItem in listCopyBlock)
                    {
                        listHighlightedBlock.Add(blockItem);
                    }
                });
            }
        }

        private RelayCommand? insertBlock;
        public RelayCommand InsertBlock
        {
            get
            {
                return insertBlock ??= new RelayCommand(obj =>
                {
                    if (editField != null)
                    {
                        foreach (Block itemBlock in listCopyBlock)
                        {
                            editField.Children.Add(itemBlock.GetUIElement());

                        }
                        listCopyBlock.Clear();
                    }
                });
            }
        }

        private RelayCommand? pressEsc;
        public RelayCommand PressEsc 
        {
            get
            {
                return pressEsc ??= new RelayCommand(obj =>
                {
                    Edblock.lineCreation?.Cancel(editField);
                    Edblock.lineCreation = null;
                    Block.lineCreation = null;
                });
            }
        }

        private RelayCommand? mouseMoveBlock;
        public RelayCommand MouseMoveBlock
        {
            get
            {
                return mouseMoveBlock ??= new RelayCommand(obj =>
                {
                    if (editField != null)
                        Print.DoPrint(editField);
                });
            }
        }

        private RelayCommand? printCommand;
        public RelayCommand PrintCommand
        {
            get
            {
                return printCommand ??= new RelayCommand(obj =>
                {
                    if (editField != null)
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
                    if (editField != null)
                        ImgEditField.SaveImg(editField);
                });
            }
        }

        private bool errorConditionFirst = false;
        public string CountLineConditionFirst { get; set; } = "2";
        private RelayCommand? addConditionFirst;
        public RelayCommand AddConditionFirst
        {
            get
            {
                return addConditionFirst ??= new RelayCommand(obj =>
                {
                    if (!errorConditionFirst && editField != null)
                    {
                        CaseFirstOption conditionCaseFirstOptionBlock = new(Convert.ToInt32(CountLineConditionFirst));
                        editField.Children.Add(conditionCaseFirstOptionBlock.GetUIElement());
                    }
                });
            }
        }

        private bool errorConditionSecond = false;
        public string CountLineConditionSecond { get; set; } = "2";
        private RelayCommand? addConditionSecond;
        public RelayCommand AddConditionSecond
        {
            get
            {
                return addConditionSecond ??= new RelayCommand(obj =>
                {
                    if (!errorConditionSecond && editField != null)
                    {
                        CaseSecondOption conditionCaseSecondOptionBlock = new(Convert.ToInt32(CountLineConditionSecond));
                        editField.Children.Add(conditionCaseSecondOptionBlock.GetUIElement());
                    }
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
                string errorAddCondition = "";
                switch (columnName)
                {
                    case "CountLineConditionFirst":
                        try
                        {
                            int count = Convert.ToInt32(CountLineConditionFirst);
                            if (count <= 1)
                            {
                                errorAddCondition = "Значение должно быть больше 1";
                                errorConditionFirst = true;
                            }
                            else
                                errorConditionFirst = false;
                        }
                        catch
                        {
                            errorAddCondition = "Введены некорректные данные";
                            errorConditionFirst = true;
                        }
                        break;

                    case "CountLineConditionSecond":
                        try
                        {
                            int count1 = Convert.ToInt32(CountLineConditionSecond);
                            if (count1 <= 1)
                            {
                                errorAddCondition = "Значение должно быть больше 1";
                                errorConditionSecond = true;
                            }
                            else
                                errorConditionSecond = false;
                        }
                        catch
                        {
                            errorAddCondition = "Введены некорректные данные";
                            errorConditionSecond = true;
                        }
                        break;
                }
                return errorAddCondition;
            }
        }

        public string Error => 
            throw new NotImplementedException();


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