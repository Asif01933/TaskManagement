using Microsoft.AspNetCore.JsonPatch;
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
        void check();
        T FindById(string Id);
        
       

    }
}
