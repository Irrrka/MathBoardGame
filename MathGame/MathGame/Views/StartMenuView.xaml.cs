namespace MathGame.Views
{
    using Autofac;
    using MathGame.Data;
    using MathGame.ViewModels;
    using MathGame.ViewModels.Common;
    using System.Collections.ObjectModel;
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
        //private void Add_Click(object sender, RoutedEventArgs e)
        //{
        //    var db = new UserViewModel();
        //    this.DataContext = db as UserViewModel;
        //    var name3 = Name.Text;
        //    db.Add(name3);
        //}

        //private void GetUsers()
        //{
        //    var db = new UserViewModel();
        //    this.DataContext = db as UserViewModel;
        //    foreach (var user in db.Users)
        //    {
        //        users.Items.Add(user.Name);
        //    }
        //}
        #endregion

    }
}
