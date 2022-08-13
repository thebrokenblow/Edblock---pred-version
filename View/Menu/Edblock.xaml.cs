using System.Windows;
using System.Windows.Input;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.Collections.Generic;
using Flowchart_Editor.ViewModel;
using Flowchart_Editor.View;
using Flowchart_Editor.Models;
using Flowchart_Editor.Models.Comment;
using Flowchart_Editor.View.Condition.Case;
using Flowchart_Editor.View.ListControllsElement;
using Flowchart_Editor.View.StylyTextField;
using System.Configuration;
using Flowchart_Editor.Model;
using System;

namespace Flowchart_Editor
{
    public partial class Edblock : Window
    {
        const int minHeight = 760;
        const int minWidth = 1380;
        public static Canvas? EditField { get; private set; }
        public static ListControlls ListControlls { get; private set; }
        public static StylyText StylyText { get; private set; }
        public static List<Block> ListHighlightedBlock { get; private set; } = new();
        public static List<CommentControls> ListComment { get; private set; } = new();
        public static List<Line> ListLineConnection { get; private set; } = new();
        public static List<CaseBlock> ListCaseBlock { get; private set; } = new();
        private readonly string connectionString;
        public Edblock()
        {
            InitializeComponent();
            DataContext = new ApplicationViewModel();
            Block.EditField = EditField;
            EditField = editField;
            ListControlls = new(ListHighlightedBlock, ListComment, ListCaseBlock);
            MinHeight = minHeight;
            MinWidth = minWidth;
            connectionString = ConfigurationManager.ConnectionStrings["Edblock"].ConnectionString;
        }

        public void MouseMoveBlock(object sender, MouseEventArgs e) //Обработка нахождения курсора на блоке
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                RemoveFocusBlocks();
                IBlockView blockView = (IBlockView)sender;
                Block instanceBlock = blockView.GetBlock(editField);
                Type typeBlock = typeof(Block);
                Block.DoDragDropControlElement(typeBlock, instanceBlock, sender);
            }
            e.Handled = true;
        }

        private static void RemoveFocusBlocks()
        {
            for (int i = 0; i < ListHighlightedBlock.Count; i++)
                ListHighlightedBlock[i].RemoveHighlightedBlock();
        }

        private void DropDestination(object sender, DragEventArgs e) //Отпускание блока
        {
            if (e.Data.GetDataPresent(typeof(Block)))
            {
                Point point = e.GetPosition(editField);
                UIElement uIElementBlock = ((Block)e.Data.GetData(typeof(Block))).GetUIElement();
                ControlOffset controlOffset = new(point.X, point.Y);
                Block.SetCoordinates(uIElementBlock, controlOffset);
            }
            else
                e.Handled = true;
        }

        private void DragOverDestination(object sender, DragEventArgs e) //Перемещение блока
        {
            if (e.Data.GetDataPresent(typeof(Block)))
            {
                e.Effects = DragDropEffects.Copy;
                Point point = e.GetPosition(editField);
                Block block = (Block)e.Data.GetData(typeof(Block));
                UIElement uIElementBlock = CreateUIElement(block, e);
                ControlOffset controlOffset = new(point.X + 1, point.Y + 1);
                Block.SetCoordinates(uIElementBlock, controlOffset);
            }
            else if (e.Data.GetDataPresent(typeof(Canvas)))
            {
                e.Effects = DragDropEffects.Copy;
                Point point = e.GetPosition(editField);
                UIElement uIElementBlock = (Canvas)e.Data.GetData(typeof(Canvas));
                ControlOffset controlOffset = new(point.X + 1, point.Y + 1);
                Block.SetCoordinates(uIElementBlock, controlOffset);
            }
            else
                e.Effects = DragDropEffects.None;
            e.Handled = true;
        }

        private UIElement CreateUIElement(Block block, DragEventArgs e) //Создание и добавление блока 
        {
            UIElement uIElement;
            uIElement = ((Block)e.Data.GetData(typeof(Block))).GetUIElement();
            bool containsUIElement = editField.Children.Contains(uIElement);

            if (containsUIElement)
                uIElement = block.GetUIElement();
            else
                editField.Children.Add(uIElement);

            return uIElement;
        }

        private void MouseDownEditField(object sender, MouseButtonEventArgs e)
        {
            Keyboard.ClearFocus();

            if (e.Source is not TextBlock)
            {
                for (int i = 0; i < ListHighlightedBlock.Count; i++)
                    ListHighlightedBlock[i].RemoveHighlightedBlock();
            }
        }
    }
}