using System.Windows.Input;

namespace Schedule.Infrastructure.Commands.Base
{
    public abstract class Command : ICommand
    {
        event EventHandler? ICommand.CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested += value;
        }

        bool ICommand.CanExecute(object? parameter)
        {
            return CanExecute(parameter);
        }

        void ICommand.Execute(object? parameter)
        {
            if (((ICommand)this).CanExecute(parameter))
            {
                Execute(parameter);
            }
        }

        protected virtual bool CanExecute(object? p)
        {
            return true;
        }

        protected abstract void Execute(object? p);
    }
}