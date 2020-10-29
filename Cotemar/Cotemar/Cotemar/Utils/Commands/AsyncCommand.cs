using System;
using System.Threading.Tasks;

namespace Cotemar.Utils.Commands
{
    public class AsyncCommand : AsyncCommandBase
    {
        private readonly Func<Task> command;
        private readonly Func<bool> canExecute;

        public AsyncCommand(Func<Task> command, Func<bool> canExecute = null)
        {
            this.command = command;
            this.canExecute = canExecute;
        }
        public override bool CanExecute(object parameter)
        {
            return command != null && !IsExecuting && (canExecute?.Invoke() ?? true);
        }

        public override async Task ExecuteAsync(object parameter)
        {
            await command?.Invoke();
        }
    }

    public class AsyncCommand<T> : AsyncCommandBase
    {
        private readonly Func<T, Task> command;
        private readonly Func<T, bool> canExecute;

        public AsyncCommand(Func<T, Task> command, Func<T, bool> canExecute = null)
        {
            this.command = command;
            this.canExecute = canExecute;
        }
        public override bool CanExecute(object parameter)
        {
            return command != null && !IsExecuting && (canExecute?.Invoke((T)parameter) ?? true);
        }

        public override async Task ExecuteAsync(object parameter)
        {
            await command?.Invoke((T)parameter);
        }
    }
}