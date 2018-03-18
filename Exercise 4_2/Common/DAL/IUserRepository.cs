using Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DAL
{
    interface IUserRepository: IRepository<User>
    {
        void DeleteItem(User user);
    }
}
