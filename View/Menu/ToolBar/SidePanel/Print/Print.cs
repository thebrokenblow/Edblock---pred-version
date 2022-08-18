using System.Windows;
using System.Windows.Controls;

namespace Flowchart_Editor.Menu.Print
{
    public class Print
    {
        private static int numberPrintInSession = 0;

        public static void DoPrint(UIElement uIElement)
        {
            numberPrintInSession++;
            PrintDialog printDialog = new();
            if (printDialog.ShowDialog() == true)
                printDialog.PrintVisual(uIElement, "Flowchart" + numberPrintInSession.ToString());
        }
    }
}