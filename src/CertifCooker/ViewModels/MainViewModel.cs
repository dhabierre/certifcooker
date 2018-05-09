namespace CertifCooker.ViewModels
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Windows;
    using CertifCooker.Certificates;
    using CertifCooker.Commands;
    using CertifCooker.Configuration;
    using CertifCooker.Extensions;
    using CertifCooker.Models;

    internal class MainViewModel : BaseViewModel
    {
        #region [ Constructor & Initialize ]

        public MainViewModel()
            : base()
        {
            #region [ Registering Command ]

            this.GenerateCommand = new DelegateCommand(this.Generate, this.CanExecuteGenerate);
            base.RegisterCommand(this.GenerateCommand);

            #endregion [ Registering Command ]
        }

        public override void Initialize()
        {
            this.IsMale = true;
            this.IsPdfFormat = true;

            if (DateTime.Today.IsWeekEnd())
            {
                this.Date = (DateTime.Today.DayOfWeek == DayOfWeek.Saturday)
                    ? DateTime.Today.AddDays(-1)
                    : DateTime.Today.AddDays(-2);
            }
            else
            {
                this.Date = DateTime.Today;
            }

            // Configuration file overriding...

            var autoFill = ConfigurationManager.GetAutoFill();
            if (autoFill != null)
            {
                this.Fullname = autoFill.Fullname;
                this.Birthday = autoFill.Birthday;
                this.Activity = autoFill.Activity;

                this.IsFemale = autoFill.Sex.StartsWith("F", StringComparison.OrdinalIgnoreCase);
            }
        }

        #endregion [ Constructor & Initialize ]

        #region [ Properties ]

        private string fullname;

        public string Fullname
        {
            get { return this.fullname; }
            set { base.SetProperty(ref this.fullname, value); }
        }

        private string birthday;

        public string Birthday
        {
            get { return this.birthday; }
            set { base.SetProperty(ref this.birthday, value); }
        }

        private string activity;

        public string Activity
        {
            get { return this.activity; }
            set { base.SetProperty(ref this.activity, value); }
        }

        private DateTime? date;

        public DateTime? Date
        {
            get { return this.date; }
            set { base.SetProperty(ref this.date, value); }
        }

        private bool isMale;

        public bool IsMale
        {
            get { return this.isMale; }
            set { base.SetProperty(ref this.isMale, value); }
        }

        private bool isFemale;

        public bool IsFemale
        {
            get { return this.isFemale; }
            set { base.SetProperty(ref this.isFemale, value); }
        }

        private bool isImageFormat;

        public bool IsImageFormat
        {
            get { return this.isImageFormat; }
            set { base.SetProperty(ref this.isImageFormat, value); }
        }

        private bool isPdfFormat;

        public bool IsPdfFormat
        {
            get { return this.isPdfFormat; }
            set { base.SetProperty(ref this.isPdfFormat, value); }
        }

        #endregion [ Properties ]

        #region [ Events ]

        protected override void OnPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(sender, e);

            if (e.PropertyName == nameof(this.IsMale))
            {
                this.IsFemale = !this.IsMale;
            }
            else if (e.PropertyName == nameof(this.IsFemale))
            {
                this.IsMale = !this.IsFemale;
            }
            else if (e.PropertyName == nameof(this.IsImageFormat))
            {
                if (this.IsImageFormat)
                {
                    this.IsPdfFormat = false;
                }
            }
            else if (e.PropertyName == nameof(this.IsPdfFormat))
            {
                if (this.IsPdfFormat)
                {
                    this.IsImageFormat = false;
                }
            }
            else if (e.PropertyName == nameof(this.Date))
            {
                if (this.Date != null)
                {
                    if (this.Date.Value.IsWeekEnd())
                    {
                        MessageBox.Show(
                            $"Attention, la date sélectionnée tombe un week-end...",
                            "Attention !",
                            MessageBoxButton.OK,
                            MessageBoxImage.Warning);
                    }
                }
            }
        }

        #endregion [ Events ]

        #region [ Commands ]

        #region [ GenerateCommand ]

        public DelegateCommand GenerateCommand { get; set; }

        private bool CanExecuteGenerate(object parameter)
        {
            if (base.IsLoading)
            {
                return false;
            }

            var isGoodDate = this.Date != null && !this.Date.Value.IsWeekEnd();

            return !string.IsNullOrWhiteSpace(this.Fullname) &&
                   !string.IsNullOrWhiteSpace(this.Birthday) &&
                   !string.IsNullOrWhiteSpace(this.Activity) &&
                   isGoodDate;
        }

        private void Generate(object parameter)
        {
            this.IsLoading = true;

            string error = null;

            try
            {
                var builder = (this.IsImageFormat)
                    ? CertificateBuilderFactory.CreateJpg()
                    : CertificateBuilderFactory.CreatePdf();

                var data = new CertificateData(this.Fullname, this.Birthday, this.Activity, this.Date.Value, this.IsFemale);

                var filePath = builder.Build(data);

                Process.Start(Path.GetDirectoryName(filePath));
            }
            catch (Exception e)
            {
                error = $"Error while creating the certificate: {e.Message}";
            }
            finally
            {
                this.IsLoading = false;
            }

            if (!string.IsNullOrEmpty(error))
            {
                MessageBox.Show(error, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public bool Generate()
        {
            if (this.GenerateCommand.CanExecute(null))
            {
                this.GenerateCommand.Execute(null);

                return true;
            }

            return false;
        }

        #endregion [ GenerateCommand ]

        #endregion [ Commands ]
    }
}