using Flowchart_Editor.Command;
using Flowchart_Editor.Menu.Print;
using Flowchart_Editor.Menu.SaveImg;
using Flowchart_Editor.Models;
using Flowchart_Editor.View.ConditionCaseFirstOption;
using Flowchart_Editor.View.ConditionCaseSecondOption;
using Flowchart_Editor.View.Menu.OpenCloseMenu;
using Flowchart_Editor.View.СontrolsScaling;
using System;
using System.ComponentModel;

namespace Flowchart_Editor.ViewModel
{
    public class ApplicationViewModel : IDataErrorInfo
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
        private RelayCommand? closeMenu;
        public RelayCommand CloseMenu
        {
            get
            {
                return closeMenu ??= new RelayCommand(obj =>
                {
                    if (Edblock.ButtonCloseMenu != null && Edblock.ButtonOpenMenu != null)
                        new MenuCloseOpen(Edblock.ButtonCloseMenu, Edblock.ButtonOpenMenu);
                });
            }
        }
        private RelayCommand? openMenu;
        public RelayCommand OpenMenu
        {
            get
            {
                return openMenu ??= new RelayCommand(obj =>
                {
                    if (Edblock.ButtonCloseMenu != null && Edblock.ButtonOpenMenu != null)
                        new MenuCloseOpen(Edblock.ButtonOpenMenu, Edblock.ButtonCloseMenu);
                });
            }
        }
        private bool flagErrorConditionFirst = false;
        public int CountLineConditionFirst { get; set; } = 2;
        private RelayCommand? addConditionFirst;
        public RelayCommand AddConditionFirst
        {
            get
            {
                return addConditionFirst ??= new RelayCommand(obj =>
                {
                    if (!flagErrorConditionFirst && Edblock.EditField != null)
                    {
                        CaseFirstOption conditionCaseFirstOptionBlock = new(Edblock.EditField, CountLineConditionFirst);
                        Edblock.EditField.Children.Add(conditionCaseFirstOptionBlock.GetUIElement());
                        Edblock.listCaseBlock.Add(conditionCaseFirstOptionBlock);
                    }
                });
            }
        }

        private bool flagErrorConditionSecond = false;
        public int CountLineConditionSecond { get; set; } = 2;
        private RelayCommand? addConditionSecond;
        public RelayCommand AddConditionSecond
        {
            get
            {
                return addConditionSecond ??= new RelayCommand(obj =>
                {
                    if (!flagErrorConditionSecond && Edblock.EditField != null)
                    {
                        CaseSecondOption conditionCaseFirstOptionBlock = new(Edblock.EditField, CountLineConditionSecond);
                        Edblock.EditField.Children.Add(conditionCaseFirstOptionBlock.GetUIElement());
                        Edblock.listCaseBlock.Add(conditionCaseFirstOptionBlock);
                    }
                });
            }
        }
        private int blockWidth;

        public int BlockWidth
        {
            get { return blockWidth; }
            set
            {
                blockWidth = value;
                DefaultPropertyForBlock.width = blockWidth;
                ControlsScaling.ScaleWidth(Edblock.ListControlls, blockWidth);
            }
        }

        private int blockHeight;

        public int BlockHeight
        {
            get { return blockHeight; }
            set
            {
                blockHeight = value;
                DefaultPropertyForBlock.height = blockHeight;
                ControlsScaling.ScaleHeight(Edblock.ListControlls, blockHeight);
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
                        if (CountLineConditionFirst <= 1)
                        {
                            errorAddCondition = "Значение должно быть больше 1";
                            flagErrorConditionFirst = true;
                        }
                        else
                            flagErrorConditionFirst = false;
                        break;
                    case "CountLineConditionSecond":
                        if (CountLineConditionSecond <= 1)
                        {
                            errorAddCondition = "Значение должно быть больше 1";
                            flagErrorConditionSecond = true;
                        }
                        else
                            flagErrorConditionSecond = false;
                        break;
                }
                return errorAddCondition;
            }
        }

        public string Error => throw new NotImplementedException();
    }
}