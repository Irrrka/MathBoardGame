namespace MathGame.ViewModels.Common
{
    using MathGame.Data;
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;

    public class UserViewModel : NotifyPropertyChanged
    {
        private string name;
        private int scores;

        public UserViewModel()
        {
            this.Users = this.GetAllUsers();
        }

        private ObservableCollection<User> GetAllUsers()
        {
            using (var db = new AppDBContext())
            {
                this.Users = new ObservableCollection<User>(db.Users.ToList());
            }

            return this.Users;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
                OnPropertyChanged("Name");
            }
        }

        public int Scores
        {
            get
            {
                return this.scores;
            }
            set
            {
                this.scores = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<User> Users { get; set; }

        public void Add(string name)
        {
            using (AppDBContext dbContext = new AppDBContext())
            {
                User user = new User();
                user.Name = name;
                
                dbContext.Users.Add(user);
                dbContext.SaveChanges();
            }
        }

        public void Update(string name, int scores)
        {
            using (AppDBContext dbContext = new AppDBContext())
            {
                var user = dbContext.Users.FirstOrDefault(u => u.Name == name);
                dbContext.Users.Attach(user);
                user.Scores = scores;
                dbContext.SaveChanges();
            }
        }
    }
}
