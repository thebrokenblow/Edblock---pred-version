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
using MaterialDesignThemes.Wpf;
using System.Windows.Media;
using System.Configuration;

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
        public static StylyText StylyText { get; private set; }
        public static List<Block> ListOfBlock { get; private set; } = new();
        public static List<CommentControls> ListComment { get; private set; } = new();
        public static List<Line> ListLineConnection { get; private set; } = new();
        public static List<CaseBlock> ListCaseBlock { get; private set; } = new();
        string connectionString;
        public Edblock()
        {
            InitializeComponent();
            DataContext = new ApplicationViewModel();
            EditField = editField;
            ListControlls = new(ListOfBlock, ListComment, ListCaseBlock);
            MinHeight = minHeight;
            MinWidth = minWidth;
            connectionString = ConfigurationManager.ConnectionStrings["Edblock"].ConnectionString;
        }

        public void MouseMoveBlock(object sender, MouseEventArgs e) //Обработка нахождения курсора на блоке
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Block instanceOfBlock = ((IBlockView)sender).GetBlock(editField);
                ListOfBlock.Add(instanceOfBlock);
                Block.DoDragDropControlElement(typeof(Block), instanceOfBlock, sender);
            }
            e.Handled = true;
        }

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

        private void DragLeaveDestination(object sender, DragEventArgs e) //Отображение перемещение блока
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

        private void MouseDownEditField(object sender, MouseButtonEventArgs e)
        {
            if (Keyboard.FocusedElement is TextBox felem)
                if (sender != felem)
                    Keyboard.ClearFocus();
        }

        private void MenuDarkModeButton_Click(object sender, RoutedEventArgs e)
        {
            bool isDarkTheme = false;

            if (toggleButtonStyleTheme.IsChecked != null)
                isDarkTheme = (bool)toggleButtonStyleTheme.IsChecked;

            PaletteHelper paletteHelper = new();
            ITheme theme = paletteHelper.GetTheme();
            theme.SetBaseTheme(isDarkTheme ? Theme.Dark : Theme.Light);
            paletteHelper.SetTheme(theme);
        }

        private void ButtonOpen_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ку-Ку");
        }
    }
}