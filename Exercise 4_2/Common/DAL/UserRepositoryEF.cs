using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Model;
using CommonContext;

namespace Common.DAL
{
    class UserRepositoryEF : IUserRepository
    {
        private CoreContext context;

        public UserRepositoryEF(CoreContext context)
        {
            this.context = context;
        }

        public void DeleteItem(int id)
        {
            var user = context.Users.Find(id);
            context.Users.Remove(user);
        }

        public void DeleteItem(User user)
        {
            context.Users.Remove(user);
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IEnumerable<User> GetAllItems()
        {
            return context.Users.ToList();
        }

        public User GetItemById(int id)
        {
            return context.Users.Find(id);
        }

        public void InsertItem(User item)
        {
            context.Users.Add(item);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateItem(User item)
        {
            context.Entry(item).CurrentValues.SetValues(item); // Not sure if 100% correct..
        }
    }
}
