using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    public class TasksManagerContext :DbContext
    {
        public TasksManagerContext(DbContextOptions<TasksManagerContext> options) : base(options)
        {

        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<Categories> Categories { get; set; }
    }
}
