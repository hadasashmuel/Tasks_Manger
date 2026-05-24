using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IUserRepositroy:IRepository<Users>
    {
        List<Users> GetUsersByName(string name);
    }
}
