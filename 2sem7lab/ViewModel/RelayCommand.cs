using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MovieRating.ViewModel
{
    public class RelayCommand(Action execute, Func<bool> canExecute = null) : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly Action execute = execute ?? throw new ArgumentNullException(nameof(execute));
        private readonly Func<bool> canExecute = canExecute;
        public bool CanExecute(object parameter)
        {
            return canExecute == null || canExecute();
        }
        public void Execute(object parameter)
        {
            execute();
        }
    }
}