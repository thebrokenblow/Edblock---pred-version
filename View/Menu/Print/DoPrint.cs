using System.Windows;
using System.Windows.Controls;

namespace Flowchart_Editor.Menu.Print
{
    public class DoPrint
    {
        private static int numberPrintInSession = 0;

        public static void Print(UIElement uIElement)
        {
            numberPrintInSession++;
            PrintDialog printDialog = new();
            if (printDialog.ShowDialog() == true)
                printDialog.PrintVisual(uIElement, "Flowchart" + numberPrintInSession.ToString());
        }
    }
}