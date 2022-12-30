using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Collections.Generic;
using Flowchart_Editor.ViewModel;
using Flowchart_Editor.View;
using Flowchart_Editor.Models;
using System.Configuration;
using Flowchart_Editor.Model;
using System;
using System.ComponentModel;
using System.Windows.Data;
using Flowchart_Editor.View.Menu.ConnectionLine;
using Flowchart_Editor.View.Menu.Blocks;

namespace Flowchart_Editor
{
    public class BlockViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private double left,top;

        public double Left 
        { 
            get => left; 
            set
            {
                left = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Left)));

            }
        }

        public double Top
        {
            get => top; 
            set
            {
                top = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Top)));

            }
        }
    }

    public partial class Edblock : Window
    {
        const int minHeight = 760;
        const int minWidth = 1380;

        private List<BlockViewModel> ListBlockViewModel { get; set; } = new();
        private List<Block> ListBlock { get; set; } = new();
        public static List<Block> ListHighlightedBlock { get; set; } = new();
        public static RoutedCommand MyCommand = new();


        public void AddNewBlock(Block block)
        {
            var blockViewModel = new BlockViewModel();
            {
                var binding = new Binding();
                blockViewModel.Left = Canvas.GetLeft(block.FrameBlock);
                binding.Path = new PropertyPath("Left");
                binding.Source = blockViewModel;
                binding.Mode = BindingMode.OneWay;
                binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                BindingOperations.SetBinding(block.FrameBlock, Canvas.LeftProperty, binding);
            }
            {
                var binding = new Binding();
                blockViewModel.Top = Canvas.GetTop(block.FrameBlock);
                binding.Source = blockViewModel;
                binding.Path = new PropertyPath("Top");
                binding.Mode = BindingMode.OneWay;
                binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                BindingOperations.SetBinding(block.FrameBlock, Canvas.TopProperty, binding);
            }
            ListBlockViewModel.Add(blockViewModel);
        }

        private readonly string connectionString;
        public static Edblock? current;
        
        public Edblock()
        {
            InitializeComponent();
            current = this;
            DataContext = new ApplicationViewModel(editField, ListBlock, ListHighlightedBlock);
            PreviewKeyDown += new KeyEventHandler(HandleEsc);
            Block.EditField = editField;
            Block.Edblock = this;
            MinHeight = minHeight;
            MinWidth = minWidth;
            connectionString = ConfigurationManager.ConnectionStrings["Edblock"].ConnectionString;
        }

        private void HandleEsc(object sender, KeyEventArgs e) //Чото не работает
        {
            if (e.Key == Key.Escape)
                lineCreation?.Cancel(editField);
        }

        public void MouseMoveBlock(object sender, MouseEventArgs e) //Обработка нахождения курсора на блоке
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                RemoveFocusBlocks(ListHighlightedBlock);
                IBlockView blockView = (IBlockView)sender;
                Block instanceBlock = blockView.GetBlock();
                ListBlock.Add(instanceBlock);
                Type typeBlock = typeof(Block);
                Block.DoDragDropControlElement(typeBlock, instanceBlock, sender);
            }
            e.Handled = true;
        }

        private static void RemoveFocusBlocks(List<Block> listHighlightedBlock)
        {
            for (int i = 0; i < listHighlightedBlock.Count; i++)
                listHighlightedBlock[i].RemoveHighlightedBlock();

            listHighlightedBlock.Clear();
        }

        private void DropDestination(object sender, DragEventArgs e) //Отпускание блока
        {
            if (e.Data.GetDataPresent(typeof(Block)))
            {
                AddNewBlock((Block)e.Data.GetData(typeof(Block)));
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
            e.Effects = DragDropEffects.Copy;
            UIElement? uIElementBlock = null; 
            if (e.Data.GetDataPresent(typeof(Block)))
            {
                Block block = (Block)e.Data.GetData(typeof(Block));
                uIElementBlock = CreateUIElement(block, e);
            }
            else if (e.Data.GetDataPresent(typeof(Canvas))) 
                uIElementBlock = (Canvas)e.Data.GetData(typeof(Canvas));
            else
                e.Effects = DragDropEffects.None;

            if (uIElementBlock != null)
                SetData(uIElementBlock, e);

            e.Handled = true;
        }

        private void SetData(UIElement uIElementBlock, DragEventArgs e)
        {
            Point point = e.GetPosition(editField);
            ControlOffset controlOffset = new(point.X + 1, point.Y + 1);
            Block.SetCoordinates(uIElementBlock, controlOffset);
        }

        private UIElement CreateUIElement(Block block, DragEventArgs e) //Создание и добавление блока 
        {
            UIElement uIElement = ((Block)e.Data.GetData(typeof(Block))).GetUIElement();
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
                RemoveFocusBlocks(ListHighlightedBlock);
                for (int i = 0; i < ListBlock.Count; i++)
                    ListBlock[i].ChangeTextField();
            }
        }

        public void StartLineCreation(LineCreation lineCreation)
        {
            this.lineCreation = lineCreation;
        }

        private LineCreation? lineCreation;

        private void editField_MouseMove(object sender, MouseEventArgs e)
        {
            Point point = e.GetPosition(editField);
            lineCreation?.MouseMove(point, editField);
        }

        public static void AddHighlightedBlock(Block block)
        {
            if (!ListHighlightedBlock.Contains(block))
            {
                ListHighlightedBlock.Add(block);
            }
        }

        private void editField_MouseUp(object sender, MouseButtonEventArgs e) //Поднял курсор
        {
            lineCreation?.Cancel(editField);
            lineCreation = null;
            Block.lineCreation = null;
        }
    }
}