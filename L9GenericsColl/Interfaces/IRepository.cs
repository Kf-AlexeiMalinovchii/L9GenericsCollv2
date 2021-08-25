using L9GenericsColl.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace L9GenericsColl.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> GetById(int id);
        Task<T> TryGetById(int id);
        List<T> GetAll();
        Task<T> Add(T user);
        Task Update(T user);
        void Remove(T user);

       // Dictionary<int, string> CreateDic();
    }
}
