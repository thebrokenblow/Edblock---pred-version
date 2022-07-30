using System;
using System.Windows.Input;

namespace Flowchart_Editor.Command
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object?> execute;
        private readonly Func<object, bool>? canExecute;

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object?> execute, Func<object, bool>? canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object? parameter)
        {
            if (canExecute == null)
                return true;
            if (parameter != null)
                return canExecute(parameter);
            return false;
        }

        public void Execute(object? parameter) =>
            execute(parameter);
    }
}