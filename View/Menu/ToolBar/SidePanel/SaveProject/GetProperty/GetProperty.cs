using Flowchart_Editor.Model;
using Flowchart_Editor.Models;
using Flowchart_Editor.View.Condition.Case;
using Flowchart_Editor.View.ConditionCaseFirstOption;
using Flowchart_Editor.View.ConditionCaseSecondOption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Flowchart_Editor.Menu.SaveProject.GetProperty
{
    public class GetProperty
    {
        public static BlockModel BlockModel(Block itemBlock, string nameOfBlock)
        {
            UIElement? itemBlockUIElement = itemBlock.GetUIElement();
            int height = 0;
            int width = 0;
            if (itemBlockUIElement != null)
            {
                height = DefaultPropertyForBlock.height;
                width = DefaultPropertyForBlock.width;
            }
            string textOfBlock = "";
            if (itemBlock.TextBoxOfBlock != null)
                textOfBlock = itemBlock.TextBoxOfBlock.Text;
            double topСoordinates = Canvas.GetTop(itemBlockUIElement);
            double leftСoordinates = Canvas.GetLeft(itemBlockUIElement);

            bool flagPresenceСomment = false;
            string textOfComment = "";
            

            return new(nameOfBlock, height, width, textOfBlock, topСoordinates, leftСoordinates, flagPresenceСomment, textOfComment);
        }

        public static LineModel LineModel(Line itemLine) => new(itemLine.X1, itemLine.Y1, itemLine.X2, itemLine.Y2);

        public static double GetTopLine(Line itemLine) => Canvas.GetTop(itemLine);
        public static double GetLeftLine(Line itemLine) => Canvas.GetLeft(itemLine);

        //public static int i = 0;
        //public static int countX2 = 0;
        //public static CaseModel CaseModel(CaseBlock caseBlock)
        //{
        //    UIElement? itemBlockUIElement = caseBlock.GetUIElement();
        //    int height = 0;
        //    int width = 0;
        //    if (itemBlockUIElement != null)
        //    {
        //        height = DefaultPropertyForBlock.height;
        //        width = DefaultPropertyForBlock.width;
        //    }
        //    string textOfBlock = "";
        //    if (caseBlock.TextBoxOfBlock != null)
        //        textOfBlock = caseBlock.TextBoxOfBlock.Text;
        //    double topСoordinates = Canvas.GetTop(itemBlockUIElement);
        //    double leftСoordinates = Canvas.GetLeft(itemBlockUIElement);

        //    if (Double.IsNaN(topСoordinates))
        //        topСoordinates = 0;

        //    if (Double.IsNaN(leftСoordinates))
        //        leftСoordinates = 0;

        //    bool flagPresenceСomment = false;
        //    string textOfComment = "";
            

        //    List<LineOfCase> listLineOfCase = new();

        //    //foreach (KeyValuePair<Line, Block> itemLineAndBlock in caseBlock.dictionaryLineAndBlock)
        //    //{
        //    //    LineModel lineModel = LineModel(itemLineAndBlock.Key);
                
        //    //    Type typeOfBlock = itemLineAndBlock.Value.GetType();
        //    //    CaseModel? caseModel = null;
        //    //    BlockModel? blockModel = null;
        //    //    if (itemLineAndBlock.Value is CaseBlock)
        //    //        caseModel = CaseModel((CaseBlock)itemLineAndBlock.Value);
        //    //    else 
        //    //        blockModel = BlockModel(itemLineAndBlock.Value, typeOfBlock.Name);
        //    //    listLineOfCase.Add(new(/*Canvas.GetTop(itemLineAndBlock.Key), Canvas.GetLeft(itemLineAndBlock.Key)*/ lineModel, caseModel, blockModel));
        //    //}
        //    List<string> listTextOfLine = new();
        //    //foreach (TextBox textBox in caseBlock.listTextBox)
        //    //    listTextOfLine.Add(textBox.Text);
        //    string nameOfBlock = "";
        //    if (caseBlock is CaseFirstOption)
        //        nameOfBlock = "CaseFirstOption";
        //    if (caseBlock is CaseSecondOption)
        //        nameOfBlock = "CaseSecondOption";

        //    return new(nameOfBlock, height, width, textOfBlock, topСoordinates, leftСoordinates, flagPresenceСomment,
        //        textOfComment, caseBlock.listLine.Count, listLineOfCase, listTextOfLine);
        //}

        public static Dictionary<string, Type> GetBlockDictionary()
        {
            var result =
                from a in AppDomain.CurrentDomain.GetAssemblies()
                from t in a.GetTypes()
                let attributes = t.GetCustomAttributes(typeof(BlockName), false)
                where attributes != null && attributes.Length > 0
                select new { name = (attributes[0] as BlockName).Name, type = t };
            return result.ToDictionary(x => x.name, x => x.type);
        }

        public static string? GetBlockWidth(ModelControls modelControls) =>
            modelControls.listBlockModels?.Count > 0 ? modelControls.listBlockModels?[0].width.ToString() : "";

        public static string? GetBlockHeight(ModelControls modelControls) =>
            modelControls.listBlockModels?.Count > 0 ? modelControls.listBlockModels?[0].height.ToString() : "";

        public static string? GetCaseWidth(ModelControls modelControls) =>
            modelControls.listCaseModel?.Count > 0 ? modelControls.listCaseModel?[0].width.ToString() : "";

        public static string? GetCaseHeight(ModelControls modelControls) =>
            modelControls.listCaseModel?.Count > 0 ? modelControls.listCaseModel?[0].height.ToString() : "";
    }
}
