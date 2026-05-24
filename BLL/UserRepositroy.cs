using DAL;
using DAL.Migrations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserRepositroy: Repository<Users> ,IUserRepositroy
    {
        public UserRepositroy(TasksManagerContext tasksM) : base(tasksM)
        {

        }
        public List<Users> GetUsersByName(string name)
        {
           return _tasks.Users.Where(x => x.UserName.Contains(name)).ToList();
        }
    }
}
