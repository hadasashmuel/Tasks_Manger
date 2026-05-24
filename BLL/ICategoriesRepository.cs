using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface ICategoriesRepository:IRepository<Categories>
    {
        List<Categories> GetCategoriesByName(string name);
    }
}
