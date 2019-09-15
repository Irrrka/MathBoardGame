namespace MathGame
{
    using MathGame.ViewModels;

    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new StartMenuViewModel(this);
        }
    }
}
