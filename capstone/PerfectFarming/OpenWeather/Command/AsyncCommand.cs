using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OpenWeather.Command
{
    class AsyncCommand: ICommand
    {
        private readonly Func<Task> _execute;
        private readonly Func<bool> _canExecute;
        private bool isExecuting;

        public AsyncCommand(Func<Task> execute) : this(execute, () => true) { }

        public AsyncCommand(Func<Task> execute, Func<bool> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {           
            return !(isExecuting && _canExecute());
        }

        public event EventHandler CanExecuteChanged;

        public async void Execute(object parameter)
        {           
            isExecuting = true;
            OnCanExecuteChanged();
            try
            {               
                await _execute();
            }
            finally
            {               
                isExecuting = false;
                OnCanExecuteChanged();
            }
        }

        protected virtual void OnCanExecuteChanged()
        {
            if (CanExecuteChanged != null) CanExecuteChanged(this, new EventArgs());
        }
    }
} 