using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TaskManagement.Repositories;

namespace TaskManagement.Repositories
{
    public class TaskRepository<T> : ITaskRepository<T> where T : class
    {
        private readonly MainDbContext context;
        private DbSet<T> DbSet;

        IEnumerable<T> ITaskRepository<T>.GetAll => GetAll();
        

        public TaskRepository(MainDbContext _context)
        {
            this.context = _context;
            DbSet = context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return DbSet.AsEnumerable().ToList();
        }
       


        public void Add(T entity)
        {
            DbSet.Add(entity);
            context.SaveChanges();
        }
        public void Delete(T entity)
        {
            DbSet.Remove(entity);
            context.SaveChanges();
        }
        public T FindById(string id)
        {
            return DbSet.Find(id);
        }
        public T FindByName(string taskFrom)
        {
            return DbSet.Find(taskFrom);
        }
        public void Update(T entity)
        {
            DbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }


    }
}
