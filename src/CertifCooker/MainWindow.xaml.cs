namespace CertifCooker
{
    using System.Windows;
    using System.Windows.Controls;
    using CertifCooker.Helpers;

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();

            this.SetTitle();
            this.SetFocus();

            this.ApplyDatePickerStyle();
        }

        private void SetTitle()
        {
            this.Title = string.Format(this.Title, AssemblyHelper.GetExecutingAssembly(5));
        }

        private void SetFocus()
        {
            if (string.IsNullOrEmpty(this.FullnameTextBox.Text))
            {
                this.FullnameTextBox.Focus();
            }
            else if (string.IsNullOrEmpty(this.BirthdayTextBox.Text))
            {
                this.BirthdayTextBox.Focus();
            }
            else if (string.IsNullOrEmpty(this.ActivityTextBox.Text))
            {
                this.ActivityTextBox.Focus();
            }
        }

        private void ApplyDatePickerStyle()
        {
            this.DateDatePicker.Loaded += delegate
            {
                var textBox = (TextBox)this.DateDatePicker.Template.FindName("PART_TextBox", this.DateDatePicker);

                textBox.Background = this.DateDatePicker.Background;
            };
        }
    }
}