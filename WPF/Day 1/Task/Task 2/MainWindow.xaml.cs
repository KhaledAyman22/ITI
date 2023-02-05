using System.Windows;


namespace Task_2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OkClick(object sender, RoutedEventArgs e)
        {
            string str = $"Name = {FnBox.Text} {LnBox.Text}\n" +
                $"Gender = {GenBox.Text}\n" +
                $"Address = {AddBox.Text}\n" +
                $"Phone = {PhBox.Text}\n" +
                $"Mobile = {MobBox.Text}\n" +
                $"Email = {EmBox.Text}\n" +
                $"Job Title = {JobBox.Text}";

            var res = MessageBox.Show(str, "Personal Info", MessageBoxButton.OKCancel, MessageBoxImage.Information);

            if (res == MessageBoxResult.Cancel) 
                ClearFields();
            else
                MessageBox.Show("Data Saved Successfully", "Saving", MessageBoxButton.OK);
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            FnBox.Text = LnBox.Text = GenBox.Text = AddBox.Text = PhBox.Text = MobBox.Text = EmBox.Text = JobBox.Text = "";
        }
    }
}
