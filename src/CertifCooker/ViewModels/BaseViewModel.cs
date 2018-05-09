namespace CertifCooker.ViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows.Input;
    using CertifCooker.Commands;

    internal abstract class BaseViewModel : INotifyPropertyChanged
    {
        #region [ Constructor & Initialize ]

        public BaseViewModel()
        {
            this.Commands = new List<DelegateCommand>();
            this.PropertyChanged += this.OnPropertyChanged;

            this.Initialize();
        }

        public virtual void Initialize()
        {
        }

        #endregion [ Constructor & Initialize ]

        #region [ Technicals ]

        private bool isLoading;

        public bool IsLoading
        {
            get { return this.isLoading; }
            set { this.SetProperty(ref this.isLoading, value); }
        }

        #endregion [ Technicals ]

        #region [ Events ]

        protected virtual void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(this.IsLoading))
            {
                Mouse.OverrideCursor = (this.IsLoading) ? Cursors.Wait : null;
            }

            this.RaiseCanExecuteChanged();
        }

        #endregion [ Events ]

        #region [ Commands ]

        protected IList<DelegateCommand> Commands { get; set; }

        protected void RegisterCommand(DelegateCommand command)
        {
            if (command != null)
            {
                if (!this.Commands.Contains(command))
                {
                    this.Commands.Add(command);
                }
            }
        }

        protected virtual void RaiseCanExecuteChanged()
        {
            foreach (var command in this.Commands)
            {
                command.RaiseCanExecuteChanged();
            }
        }

        #endregion [ Commands ]

        #region [ INotifyPropertyChanged Implementation ]

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T member, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(member, value))
            {
                return false;
            }

            member = value;

            this.NotifyPropertyChanged(propertyName);

            return true;
        }

        #endregion [ INotifyPropertyChanged Implementation ]
    }
}