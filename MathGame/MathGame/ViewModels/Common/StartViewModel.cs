namespace MathGame.ViewModels.Common
{
    public class StartViewModel
    {
        public StartMenuViewModel StartMenuViewModel { get; set; }
        public UserViewModel UserViewModel { get; set; }

        public StartViewModel(StartMenuViewModel startMenuViewModel, UserViewModel userViewModel)
        {
            this.StartMenuViewModel = startMenuViewModel;
            this.UserViewModel = userViewModel;
        }

    }
}
