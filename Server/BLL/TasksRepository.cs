using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TasksRepository : Repository<Tasks>, ITasksRepository
    {

        public TasksRepository(TasksManagerContext tasksM) : base(tasksM)
        {

        }
        public List<Tasks> GetTasksByName(string name)
        {
            return _tasks.Tasks.Where(x => x.TasksName.Contains(name)).ToList();
        }
    }
}
