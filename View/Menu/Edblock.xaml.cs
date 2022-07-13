using System;
using System.Windows;
using System.Windows.Input;
using Flowchart_Editor.View;
using System.Windows.Shapes;
using Flowchart_Editor.Models;
using System.Windows.Controls;
using System.Collections.Generic;
using Flowchart_Editor.Models.Comment;
using Flowchart_Editor.Menu.SaveProject;
using Flowchart_Editor.View.Condition.Case;
using Flowchart_Editor.Menu.UploadProject;
using Flowchart_Editor.Menu.Theme;
using Flowchart_Editor.ViewModel;
using Flowchart_Editor.View.ListControllsElement;

namespace Flowchart_Editor
{
    public partial class Edblock : Window
    {
        const int minHeight = 760;
        const int minWidth = 1380;
        public static Canvas? EditField { get; private set; }
        public static Button? ButtonOpenMenu { get; private set; }
        public static Button? ButtonCloseMenu { get; private set; }

        public static ListControlls ListControlls { get; private set; }
        public Edblock()
        {
            InitializeComponent();
            DataContext = new ApplicationViewModel();
            EditField = editField;
            ButtonOpenMenu = buttonOpenMenu;
            ButtonCloseMenu = buttonCloseMenu;
            ListControlls = new(listOfBlock, listComment, listCaseBlock);
            MinHeight = minHeight;
            MinWidth = minWidth;
            toggleButtonStyleTheme.Click += ThemeChange;
            ThemeChange();
        }

        private void ThemeChange(object? sender = null, RoutedEventArgs? e = null) => // Установление темы (светлая, тёмная)
            Theme.SetTheme(toggleButtonStyleTheme);

        public static readonly List<Block> listOfBlock = new();
        public void MouseMoveBlock(object sender, MouseEventArgs e) //Обработка нахождения курсора на блоке
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Block instanceOfBlock = ((IBlockView)sender).GetBlock(editField);
                listOfBlock.Add(instanceOfBlock);
                Block.DoDragDropControlElement(typeof(Block), instanceOfBlock, sender);
            }
            e.Handled = true;
        }

        public static List<CommentControls> listComment = new();
        private void DropDestination(object sender, DragEventArgs e) //Отпускание блока
        {
            if (e.Data.GetDataPresent(typeof(Block)))
            {
                Point point = e.GetPosition(editField);
                UIElement? uIElementBlock = ((Block)e.Data.GetData(typeof(Block))).GetUIElement();
                Block.SetCoordinates(uIElementBlock, point.X, point.Y);
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
                UIElement? uIElementOfBlock = CreateUIElement(block, e);
                Block.SetCoordinates(uIElementOfBlock, point.X + 1, point.Y + 1);
            }
            else if (e.Data.GetDataPresent(typeof(Canvas)))
            {
                e.Effects = DragDropEffects.Copy;
                Point point = e.GetPosition(editField);
                UIElement uIElement = (Canvas)e.Data.GetData(typeof(Canvas));
                Block.SetCoordinates(uIElement, point.X + 1, point.Y + 1);
            }
            else
                e.Effects = DragDropEffects.None;
            e.Handled = true;
        }

        private UIElement? CreateUIElement(Block block, DragEventArgs e) //Создание и добавление блока 
        {
            UIElement? uIElement;
            if (block.FrameBlock == null)
            {
                uIElement = ((Block)e.Data.GetData(typeof(Block))).GetUIElement();
                editField.Children.Add(uIElement);
            }
            else
                uIElement = block.GetUIElement();

            return uIElement;
        }

        private void DragLeaveDestination(object sender, DragEventArgs e) //Обработка чтобы блок не вылез за границы приложения
        {
            if (e.Data.GetDataPresent(typeof(Block)))
            {
                UIElement? uIElementOfBlock = ((Block)e.Data.GetData(typeof(Block))).GetUIElement();
                editField.Children.Remove(uIElementOfBlock);
                Block dataInformationOfBlock = (Block)e.Data.GetData(typeof(Block));
                dataInformationOfBlock.Reset();
            }
            e.Handled = true;
        }

        public static readonly List<Line> listLineConnection = new();

        private void MouseLeftButtonDownComment(object sender, MouseButtonEventArgs e)
        {
            PinningComment.flagPinningComment = true;
        }

        private string? GetFontFamily() =>
            listOfFontFamily.SelectedValue?.ToString();

        public string? GetFontSize() =>
            ((ComboBoxItem)fontSizeComboBox.SelectedItem)?.Content.ToString();

        private void ClickSaveProject(object sender, RoutedEventArgs e) =>
            SaveProject.Save(GetFontFamily(), GetFontSize());

        private void ClickUploadProject(object sender, RoutedEventArgs e)
        {
            UploadProject.Upload(editField, listOfBlock, listLineConnection, listComment,
                listCaseBlock, listOfFontFamily, fontSizeComboBox, widthComboBox, heightComboBox);
        }

        public static readonly List<CaseBlock> listCaseBlock = new();

        public static void RemoveItemFromListCaseBlock(CaseBlock caseBlock) =>
            listCaseBlock.Remove(caseBlock);

        private void SelectionChangedFontSize(object sender, SelectionChangedEventArgs e) =>
            StaticBlock.fontSize = Convert.ToInt32(((ComboBoxItem)fontSizeComboBox.SelectedItem)?.Content.ToString());

        private void ClickSettings(object sender, RoutedEventArgs e)
        {
            Settings settings = new();
            settings.Show();
        }

        private void LoadedWidthComboBox(object sender, RoutedEventArgs e)
        {
            for (int i = 110; i <= 250; i += 10)
                widthComboBox.Items.Add(i);
        }

        private void LoadedHeightComboBox(object sender, RoutedEventArgs e)
        {
            for (int i = 60; i <= 250; i += 10)
                heightComboBox.Items.Add(i);
        }
    }
}