using Flowchart_Editor.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Windows.Shapes;

namespace Flowchart_Editor.Menu.SaveProject
{
    public class SaveProject
    {
        private static int numberFilesInSession = 0;

        private static void SaveBlockModel(List<BlockModel> listBlockModels)
        {
            //foreach (Block itemBlock in Edblock.ListHighlightedBlock)
            //{
            //    Type typeOfBlock = itemBlock.GetType();
            //    BlockModel blockModel = GetProperty.GetProperty.BlockModel(itemBlock, typeOfBlock.Name);
            //    listBlockModels.Add(blockModel);
            //}
        }

        private static void SaveLineModel(List<LineModel> listLineModels)
        {
            //foreach (Line itemLine in Edblock.ListLineConnection)
            //{
            //    LineModel lineModel = GetProperty.GetProperty.LineModel(itemLine);
            //    listLineModels.Add(lineModel);
            //}
        }

        private static void SaveCaseModel(List<CaseModel> listCaseModels)
        {
            //foreach (CaseBlock itemConditionCaseFirstOptionBlock in Edblock.ListCaseBlock)
            //{
            //    CaseModel caseModel = GetProperty.GetProperty.CaseModel(itemConditionCaseFirstOptionBlock);
            //    listCaseModels.Add(caseModel);
            //}
        }

        private static readonly JsonSerializerOptions jsonSerializerOptions = new()
        {
            AllowTrailingCommas = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
            WriteIndented = true
        };

        public async static void Save(string? fontFamily, string? fontSize)
        {
            numberFilesInSession++;
            List<BlockModel> listBlockModels = new();
            List<LineModel> listLineModels = new();
            List<CaseModel> listCaseModels = new();

            SaveFileDialog saveFileDialog = new()
            {
                Filter = "Files(*.json)|*.json|All(*.*)|*"
            };

            FileInfo file = new("Flowchart" + numberFilesInSession.ToString() + ".json");
            saveFileDialog.FileName = file.Name;
            if (saveFileDialog.ShowDialog() == true)
            {
                DeleteFile.Delete(saveFileDialog);
                using FileStream fileStream = new(saveFileDialog.FileName.ToString(), FileMode.OpenOrCreate);

                SaveBlockModel(listBlockModels);

                SaveLineModel(listLineModels);

                SaveCaseModel(listCaseModels);

                string? comboBoxItemFontFamily = fontFamily;
                string? comboBoxItemFontSize = fontSize;

                StyleModel styleModel = new(comboBoxItemFontFamily, comboBoxItemFontSize);
                ModelControls modelControls = new(listBlockModels, listLineModels, listCaseModels, styleModel);
                await JsonSerializer.SerializeAsync(fileStream, modelControls, jsonSerializerOptions);
            }
        }
    }
}