namespace CertifCooker.Commands
{
    using System;
    using System.Windows.Input;

    internal class DelegateCommand : ICommand
    {
        private readonly Func<object, bool> canExecute;
        private readonly Action<object> action;

        public DelegateCommand(Action<object> action)
            : this(action, null)
        {
        }

        public DelegateCommand(Action<object> action, Func<object, bool> canExecute)
        {
            this.action = action ?? throw new ArgumentNullException(nameof(action));
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            var result = true;

            if (this.canExecute != null)
            {
                result = this.canExecute(parameter);
            }

            return result;
        }

        public event EventHandler CanExecuteChanged;

        public void RaiseCanExecuteChanged()
        {
            this.CanExecuteChanged?.Invoke(this, new EventArgs());
        }

        public void Execute(object parameter)
        {
            this.action(parameter);
        }
    }
}