using System.Collections.Generic;
using System.Security.Claims;
namespace TaskManagement.Repositories
{
    public interface IPersonRepository<T> where T : class
    {
        IEnumerable<T> GetAll
        {
            get;
        }
        void Add(T entity);
        void Update(T entity);
        T FindById(string Id);
        T FindByName(string Name);
    }
}
