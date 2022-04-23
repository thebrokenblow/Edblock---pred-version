using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Controls;

namespace Flowchart_Editor.Models.Interface
{
    public interface IBlock
    {
        public UIElement? GetUIElementWithoutCreate();
        public Canvas? GetCanvas();
        public IBlock GetMainBlock();
        public object GetFirstSenderMainBlock();
        public object GetSecondSenderMainBlock();
        public object GetThirdSenderMainBlock();
        public object GetFourthSenderMainBlock();
        public int GetNumberOfOccurrencesInBlock();
        public UIElement GetUIElement();
        public void SetFillOfPointToConnect(string darkWhite);
        public void SetFontFamily(FontFamily fontFamily);
        public void SetFontSize(int valueFontSize);
        public void SetWidthOfBlock(int valueBlokWidth);
        public void SetHeightBlock(int valueBlokHeight);
        public void SetValueSenderOfBlockWithSingleLineOccurrence(IBlock block, object sender, Line lineConnection);
        public void SetValueSenderOfBlockWithTwoLineOccurrence(IBlock block, object sender, Line lineConnection);
        public void SetValueSenderOfBlockWithThreeLineOccurrence(IBlock block, object sender, Line lineConnection);
        public void SetValueSenderOfBlockWithFourLineOccurrence(IBlock block, object sender, Line lineConnection);
        public void SetValueSenderOfFirstBlock(object sender);
        public void SetValueSenderOfSecondBlock(object sender);
        public void SetValueSenderOfThirdBlock(object sender);
        public void SetValueSenderOfFourthBlock(object sender);
        public void SetFirstBlock(IBlock block);
        public void SetSecondBlock(IBlock block);
        public void SetThirdBlock(IBlock block);
        public void SetFourthBlock(IBlock block);
        public void Reset();
    }
}
