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
            startMenu.StartNewGame(categoryBox.SelectedIndex);
        }

        private void About(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Тази игра е създадена по българския детски сериал \"Островът на Сините птици\". \r\n Гледайте на www.bnt.bg");
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }
    }
}
