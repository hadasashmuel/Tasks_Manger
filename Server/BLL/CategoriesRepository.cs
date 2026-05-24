using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CategoriesRepository: Repository<Categories>, ICategoriesRepository
    {
        public CategoriesRepository(TasksManagerContext tasksM) : base(tasksM)
        {

        }
        public List<Categories> GetCategoriesByName(string name)
        {
            return _tasks.Categories.Where(x => x.CategoriesName.Contains(name)).ToList();
        }
    }
}
