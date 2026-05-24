using DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly TasksManagerContext _tasks;
        protected readonly DbSet<T> dbSet;


        public Repository(TasksManagerContext tasksManagerContext)
        {
            this._tasks = tasksManagerContext;
            this.dbSet = tasksManagerContext.Set<T>();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public void DeleteById(int id)
        {
            dbSet.Remove(GetById(id));
        }

        public List<T> GetAll()
        {
            return dbSet.ToList();
        }

        public T GetById(int id)
        {
           return dbSet.Find(id);
        }

        public void SaveChanges()
        {
            _tasks.SaveChanges();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}

