namespace MathGame.Views
{
    using Autofac;
    using MathGame.ViewModels;
    using System.Windows;
    using System.Windows.Controls;

    public partial class MemoryGameView : UserControl
    {
        private MemoryGameViewModel game;

        public MemoryGameView()
        {
            InitializeComponent();
            this.DataContext =
                Bootstraper.Container.Resolve<MemoryGameViewModel>();
            this.game = DataContext as MemoryGameViewModel;
        }

        private void PlayAgain(object sender, RoutedEventArgs e)
        {
            this.game.Restart();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            this.game.ClickedSlide(button.DataContext);
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
