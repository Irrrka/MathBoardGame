namespace MathGame.Views
{
    using Autofac;
    using MathGame.Data;
    using MathGame.ViewModels;
    using System.Windows;
    using System.Windows.Controls;

    public partial class StartMenuView : UserControl
    {

        //private StartViewModel game;

        public StartMenuView()
        {
            InitializeComponent();
            //this.Users = this.game.GetUsers();
        }

        //ObservableCollection<User> Users { get; set; }

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
            AboutView about = new AboutView();
            about.Show();
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }

        private void Mute(object sender, RoutedEventArgs e)
        {
            SoundManager.Mute();
        }

        #region Users
        private void Add_Click(object sender, RoutedEventArgs e)
        {

            //var db = new UserViewModel();
            //this.DataContext = db as UserViewModel;
            ////var db = DataContext as StartViewModel;
            //var name = Name.Text;
            //this.game.Add(name);
        }

        private void GetUsers()
        {
            //var db = new UserViewModel();
            //this.DataContext = db as UserViewModel;
            //foreach (var user in db.Users)
            //{
            //    users.Items.Add(user.Name);
            //}
        }
        #endregion

    }
}
