using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FacturasOsprint.ViewModel
{
    internal class ParamCommand : ICommand
    {
        private Action<object> _action;
        private readonly Func<bool> _canExecute;

        public ParamCommand(Action<object> action)
        {
            _action = action;
            _canExecute = () => true;
        }

        public ParamCommand(Action<object> action, Func<bool> canExecute)
        {
            _action = action;
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecute == null)
            {
                return true;
            }
            else
            {
                bool result = _canExecute.Invoke();
                return result;
            }
        }

        public void Execute(object parameter)
        {
            if (CanExecute(parameter))
            {
                if (parameter != null)
                {
                    _action(parameter);
                }
            }
        }
    }
}
