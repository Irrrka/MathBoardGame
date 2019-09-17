namespace MathGame.Views
{
    using MathGame.ViewModels;
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for StartMenuView.xaml
    /// </summary>
    public partial class StartMenuView : UserControl
    {
        public StartMenuView()
        {
            InitializeComponent();
        }

        private void Play(object sender, RoutedEventArgs e)
        {
            var startMenu = DataContext as StartMenuViewModel;
            if (categoryBox.SelectedIndex == 0)
            {
                MessageBox.Show("МОЛЯ, ИЗБЕРИ ИГРА");
            }
            else
            {
                startMenu.StartNewGame(categoryBox.SelectedIndex);
            }
        }

        private void About(object sender, RoutedEventArgs e)
        {
            var screen = new AboutView();
            Window.GetWindow(this).Close();
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }
    }
}
