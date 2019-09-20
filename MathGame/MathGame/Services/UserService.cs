using MathGame.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame.Services
{
    public class UserService
    {
        public void AddUser(string name)
        {
            using (AppDBContext dbContext = new AppDBContext())
            {
                User user = new User();
                user.Name = name;
               
                dbContext.Users.Add(user);
                dbContext.SaveChanges();
            }
        }
    }
}
