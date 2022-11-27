using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TaskManagement.Repositories;

namespace TaskManagement.Repositories
{
    public class PersonRepository<T> : IPersonRepository<T> where T : class
    {
        private readonly MainDbContext context;
        private DbSet<T> DbSet;

        IEnumerable<T> IPersonRepository<T>.GetAll => GetAll();

        public PersonRepository(MainDbContext _context)
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
        public void Update(T entity)
        {
            DbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
        public T FindById(string id)
        {
            return DbSet.Find(id);
        }
        public T FindByName(string Name)
        {
            return DbSet.Find(Name);
        }

    }
}
