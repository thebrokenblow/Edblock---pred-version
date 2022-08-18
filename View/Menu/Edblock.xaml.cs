using System.Windows;
using System.Windows.Input;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.Collections.Generic;
using Flowchart_Editor.ViewModel;
using Flowchart_Editor.View;
using Flowchart_Editor.Models;
using System.Configuration;
using Flowchart_Editor.Model;
using System;
using System.Windows.Media;
using System.ComponentModel;
using System.Windows.Data;

namespace Flowchart_Editor
{
    public class LineCreation
    {
        private Point startPoint;
        private Block startBlock;

        public LineCreation(Point startPoint, Block startBlock)
        {
            this.startPoint = startPoint;
            this.startBlock = startBlock;
        }

        private Line? line;

        public void MouseMove(Point currentPoint, Canvas canvas)
        {
            if (line == null)
            {
                line = new Line();
                line.X1 = startPoint.X;
                line.Y1 = startPoint.Y;
                line.Stroke = Brushes.Black;
                canvas.Children.Add(line);
            }
            if (line != null)
            {
                line.X2 = currentPoint.X;
                line.Y2 = currentPoint.Y;
            }

        }

        public void Cancel(Canvas canvas)
        {
            canvas.Children.Remove(line);
        }

    }

    public class BlockViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private double left,top;

        public double Left { get=>left; set
            {
                left = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Left)));

            }
            }

        public double Top
        {
            get => top; set
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
        private List<Block> ListHighlightedBlock { get; set; } = new();

        public void AddNewBlock(Block block)
        {
            //ListBlock.Add(block);
            //AddNewBlock(block);
            var blockViewModel = new BlockViewModel();
            ListBlockViewModel.Add(blockViewModel);
            {

                var binding = new Binding();
                binding.Source = blockViewModel;
                blockViewModel.Left = Canvas.GetLeft(block.FrameBlock);
                binding.Path = new PropertyPath("Left");
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
        }

        private readonly string connectionString;

        public static Edblock? current;

        public Edblock()
        {
            InitializeComponent();
            current = this;
            DataContext = new ApplicationViewModel(editField, ListHighlightedBlock);
            Block.EditField = editField;
            Block.ListHighlightedBlock = ListHighlightedBlock;
            MinHeight = minHeight;
            MinWidth = minWidth;
            connectionString = ConfigurationManager.ConnectionStrings["Edblock"].ConnectionString;
        }

        public void MouseMoveBlock(object sender, MouseEventArgs e) //Обработка нахождения курсора на блоке
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                RemoveFocusBlocks(ListHighlightedBlock);
                IBlockView blockView = (IBlockView)sender;
                Block instanceBlock = blockView.GetBlock();
                AddNewBlock(instanceBlock);
                //ListBlock.Add(instanceBlock);
                ListHighlightedBlock.Add(instanceBlock);
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
            var point = e.GetPosition(this.editField);
            lineCreation?.MouseMove(point,editField);
        }

        private void editField_MouseLeave(object sender, MouseEventArgs e)
        {
            lineCreation?.Cancel(editField);
            lineCreation = null;

        }

        private void editField_MouseUp(object sender, MouseButtonEventArgs e)
        {
            lineCreation = null;
            foreach (var blockViewModel in ListBlockViewModel)
            {
                blockViewModel.Left++;
            }
        }
    }
}