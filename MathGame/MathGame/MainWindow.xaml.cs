namespace MathGame
{
    using MathGame.ViewModels;
    using System.Windows.Controls;

    public partial class MainWindow
    {

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new StartMenuViewModel(this);
        }
    }
}
