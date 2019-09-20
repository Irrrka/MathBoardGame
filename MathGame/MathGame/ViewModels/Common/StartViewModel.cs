//using MathGame.Data;
//using System.Collections.ObjectModel;
//using System.Windows.Controls;

//namespace MathGame.ViewModels.Common
//{
//    public class StartViewModel
//    {
//        private MainWindow mainWindow;

//        public StartMenuViewModel StartMenuViewModel { get; set; }
//        public UserViewModel UserViewModel { get; set; }

//        public StartViewModel(MainWindow main)
//        {
//            this.mainWindow = main;

//            this.UserViewModel = new UserViewModel();
//            this.StartMenuViewModel = new StartMenuViewModel(this.mainWindow);
//        }

//        #region Users
//        public void Add(string data)
//        {
//            this.UserViewModel.Add(data);
//        }

//        public ObservableCollection<User> GetUsers()
//        {
//            return this.UserViewModel.Users;
//        }
//        #endregion
//    }
//}
