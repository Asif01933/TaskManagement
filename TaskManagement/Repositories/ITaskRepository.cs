using System.Collections.Generic;
using System.Security.Claims;
namespace TaskManagement.Repositories
{
    public interface ITaskRepository<T> where T : class
    {
        IEnumerable<T> GetAll
        {
            get;
        }
       
        
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        T FindById(string Id);
        
       

    }
}
