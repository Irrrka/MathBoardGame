namespace MathGame
{
    using MathGame.ViewModels;
    using MathGame.ViewModels.Common;

    public partial class MainWindow
    {
        //public StartViewModel StartViewModel { get; set; }

        public MainWindow()
        {
            //StartViewModel = new StartViewModel(new StartMenuViewModel(this), new UserViewModel());
            InitializeComponent();
            DataContext = new StartMenuViewModel(this);
        }
    }
}
