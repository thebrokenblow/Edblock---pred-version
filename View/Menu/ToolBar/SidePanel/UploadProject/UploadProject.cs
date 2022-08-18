using Flowchart_Editor.Model;
using Flowchart_Editor.Models;
using Flowchart_Editor.Models.Comment;
using Flowchart_Editor.View.Condition.Case;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Flowchart_Editor.Menu.UploadProject
{
    public class UploadProject
    {
        
        public static void Upload()
        {
            //OpenFileDialog openFileDialog = new()
            //{
            //    Filter = "File json|*.json"
            //};

            //if (openFileDialog.ShowDialog() == true)
            //{
            //    var blockDictionary = GetProperty.GetBlockDictionary();
            //    string fileName = openFileDialog.FileName;
            //    using FileStream fileStream = new(fileName, FileMode.OpenOrCreate);
            //    ModelControls? modelControls = null;
            //    try
            //    {
            //        modelControls = await JsonSerializer.DeserializeAsync<ModelControls>(fileStream);
            //    }
            //    catch
            //    {
            //        MessageBox.Show("Ошибка загруски проекта, вероятно файл испорчен");
            //    }
            //    if (modelControls != null)
            //    {
            //        ClearData.Clear(canvas, listOfBlock, listLineConnection, listComment, listCaseBlock);

            //        listOfFontFamily.Text = modelControls.styleModel.fontFamily;
            //        fontSizeComboBox.Text = modelControls.styleModel.fontSize;

            //        if (modelControls.listBlockModels?.Count != 0)
            //        {
            //            blockWidthComboBox.Text = GetProperty.GetBlockWidth(modelControls);
            //            blockHeightComboBox.Text = GetProperty.GetBlockHeight(modelControls);
            //        }
            //        if (modelControls.listCaseModel?.Count != 0)
            //        {
            //            blockWidthComboBox.Text = GetProperty.GetCaseWidth(modelControls);
            //            blockHeightComboBox.Text = GetProperty.GetCaseHeight(modelControls);
            //        }

            //        if (modelControls.listBlockModels != null)
            //        {
            //            foreach (BlockModel itemBlockModel in modelControls.listBlockModels)
            //            {
            //                Block? block = SetProperty.SetBlock(blockDictionary[itemBlockModel.nameOfBlock], itemBlockModel);
            //                if (block != null)
            //                {
            //                    listOfBlock.Add(block);
            //                    if (block.comment != null)
            //                        listComment.Add(block.comment);
            //                    canvas.Children.Add(block.GetUIElement());
            //                }
            //            }
            //        }

            //        if (modelControls.listLineModels != null)
            //        {
            //            foreach (LineModel itemBlockModel in modelControls.listLineModels)
            //            {
            //                Line line = SetProperty.SetLine(itemBlockModel);
            //                canvas.Children.Add(line);
            //            }
            //        }

            //        if (modelControls.listCaseModel != null)
            //        {
            //            foreach (CaseModel itemCaseModel in modelControls.listCaseModel)
            //            {
            //                CaseBlock? caseBlock = SetProperty.SetCaseBlock(itemCaseModel);
            //                if (caseBlock != null)
            //                    caseBlock.GetUIElement();
            //                //GetLineOfCase(itemCaseModel, blockDictionary, caseBlock);
            //                foreach (LineOfCase itemLineAndBlockOfCase in itemCaseModel.listLineOfCase)
            //                {
            //                    Line line = SetProperty.SetLine(itemLineAndBlockOfCase.lineModel);
            //                    Block? block;
            //                    if (itemLineAndBlockOfCase.caseModel != null)
            //                        block = SetProperty.SetCaseBlock(itemLineAndBlockOfCase.caseModel);
            //                    else
            //                        block = SetProperty.SetBlock(blockDictionary[itemLineAndBlockOfCase.blockModel.nameOfBlock], itemLineAndBlockOfCase.blockModel);

            //                    caseBlock.PindingBlock(caseBlock, block, line);
            //                }
            //                List<string> listTextOfLine = itemCaseModel.listTextOfLine;
            //                caseBlock.SetTextForTextBox(listTextOfLine);
            //                canvas.Children.Add(caseBlock.GetUIElement());
            //                listCaseBlock.Add(caseBlock);
            //            }
            //        }
            //    }
            //}
        }

        private static List<CaseModel> GetCaseForCase(CaseModel caseModel, List<CaseModel> listCaseModel, List<LineOfCase> lineModel)
        {
            if (caseModel != null)
            {
                listCaseModel.Add(caseModel);
                foreach (LineOfCase lineOfCase in caseModel.listLineOfCase)
                {
                    lineModel.Add(lineOfCase);
                    if (caseModel.listLineOfCase != null)
                        GetCaseForCase(lineOfCase.caseModel, listCaseModel, lineModel);
                }
            }
            return listCaseModel;
        }


        private static void GetLineOfCase(CaseModel caseModel , Dictionary<string, Type> blockDictionary, CaseBlock caseBlock)
        {
            //TODO: Норм, но привести в нормальный вид
            List<CaseModel> listCaseModel = new();
            List<LineOfCase> listLineModel = new();

            GetCaseForCase(caseModel, listCaseModel, listLineModel);

            Block? block = null;
            CaseBlock newCaseBlock;
            foreach (var compliteCase in listCaseModel.Zip(listLineModel, Tuple.Create))
            {
                Line line = SetProperty.SetLine(compliteCase.Item2.lineModel);
                if (compliteCase.Item1.nameOfBlock != "CaseFirstOption" && compliteCase.Item1.nameOfBlock != "CaseSecondOption")
                    block = SetProperty.SetBlock(blockDictionary[compliteCase.Item1.nameOfBlock], compliteCase.Item2.blockModel);
                newCaseBlock = SetProperty.SetCaseBlock(compliteCase.Item1);
                caseBlock.PindingBlock(newCaseBlock, block, line);
            }



            //caseBlock.PindingBlock(caseBlock, block, line);

        }
    }
}
