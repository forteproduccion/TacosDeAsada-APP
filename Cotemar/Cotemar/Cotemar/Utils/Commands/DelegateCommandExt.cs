using System;
using System.Windows.Input;

namespace Cotemar.Utils.Commands
{
    public class DelegateCommandExt<T> : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public DelegateCommandExt(Action<T> execute) : this(execute, null)
        {
        }

        public DelegateCommandExt(Action<T> execute, Predicate<T> canExecute)
        {
            m_execute = execute;
            m_canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            if (m_canExecute == null)
            {
                return true;
            }

            return m_canExecute((T)parameter);
        }

        public void Execute(object parameter)
        {
            m_execute((T)parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        readonly Predicate<T> m_canExecute;
        readonly Action<T> m_execute;
    }
}