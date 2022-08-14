﻿using System.Windows.Controls;
using Flowchart_Editor.Models;

namespace Flowchart_Editor.View
{
    /// <summary>
    /// Логика взаимодействия для CycleBlockForView.xaml
    /// </summary>
    public partial class CycleBlockForView : UserControl, IBlockView
    {
        public CycleBlockForView()
        {
            InitializeComponent();
        }

        public Block GetBlock()
        {
            CycleForBlock cycleForBlock = new();
            return cycleForBlock;
        }
    }
}