namespace MathGame.Views
{
    using MathGame.ViewModels;
    using System.Windows;
    using System.Windows.Controls;

    public partial class MemoryGameView : UserControl
    {
        public MemoryGameView()
        {
            InitializeComponent();
        }

        private void PlayAgain(object sender, RoutedEventArgs e)
        {
            var game = DataContext as MemoryGameViewModel;
            game.Restart();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var game = DataContext as MemoryGameViewModel;
            var button = sender as Button;
            game.ClickedSlide(button.DataContext);
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Window startScreen = new MainWindow();
            startScreen.Show();
            Window.GetWindow(this).Close();
        }

        private void Rules_Click(object sender, RoutedEventArgs e)
        {
            var gamename = nameof(MemoryGameView);
            RulesView rules = new RulesView(gamename);
            rules.Show();
        }
    }
}
