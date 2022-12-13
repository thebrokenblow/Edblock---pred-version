using Flowchart_Editor.Model;
using Flowchart_Editor.Models;
using Flowchart_Editor.View.Condition.Case;
using Flowchart_Editor.View.ConditionCaseFirstOption;
using Flowchart_Editor.View.ConditionCaseSecondOption;
using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Flowchart_Editor.Menu.UploadProject
{
    public class SetProperty
    {
        private static readonly Uri uri = new("WindowsTheme/theme.xaml", UriKind.Relative);
        public static Block? SetBlock(Type type, BlockModel blockModel)
        {
            Block? block = null;
            ConstructorInfo? constructorInfo = type.GetConstructor(new Type[] { typeof(Edblock), typeof(int) });
            if (constructorInfo != null)
            {
                block = (Block)constructorInfo.Invoke(new object[] { new Edblock(), 0 });
                UIElement uIElementOfBlock = block.GetUIElement();
                if (block.TextBoxOfBlock != null)
                    block.TextBoxOfBlock.Text = blockModel.textOfBlock.ToString();
                block.SetWidth(blockModel.width);
                block.SetHeight(blockModel.height);

                //DefaultPropertyForBlock.width = blockModel.width;
                //DefaultPropertyForBlock.height = blockModel.height;

                Canvas.SetTop(uIElementOfBlock, blockModel.topCoordinates);
                Canvas.SetLeft(uIElementOfBlock, blockModel.leftCoordinates);

                
            }
            return block;
        }

        public static Line SetLine(LineModel lineModel)
        {
            Line line = new();
            line.X1 = lineModel.x1;
            line.Y1 = lineModel.y1;
            line.X2 = lineModel.x2;
            line.Y2 = lineModel.y2;
            if (Application.LoadComponent(uri) is ResourceDictionary resourceDict)
                line.Style = resourceDict["LineStyle"] as Style;
            return line;
        }

        public static CaseBlock? SetCaseBlock(CaseModel caseModel)
        {
            //DefaultPropertyForBlock.width = caseModel.width;
            //DefaultPropertyForBlock.height = caseModel.height;

            CaseBlock? caseBlock = null;
            //if (caseModel.nameOfBlock == "CaseFirstOption")
            //    caseBlock = new CaseFirstOption((Canvas)Edblock.EditField, caseModel.countOfLine);
            //else if (caseModel.nameOfBlock == "CaseSecondOption")
            //    caseBlock = new CaseSecondOption((Canvas)Edblock.EditField, caseModel.countOfLine);
            if (caseBlock != null)
            {
                UIElement uIElementOfСase = caseBlock.GetUIElement();
                if (caseBlock.TextBoxOfBlock != null)
                    caseBlock.TextBoxOfBlock.Text = caseModel.textOfBlock.ToString();

                Canvas.SetTop(uIElementOfСase, caseModel.topCoordinates);
                Canvas.SetLeft(uIElementOfСase, caseModel.leftCoordinates);

                
            }
            return caseBlock;
        }
    }
}
