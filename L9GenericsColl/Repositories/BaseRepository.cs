using Castle.Core.Logging;
using L9GenericsColl.Entities;
using L9GenericsColl.Interfaces;
using L9GenericsColl.SomeStuff;
using L9GenericsColl.DbContexts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace L9GenericsColl.Repositories
{
    public class BaseRepository<T> : EntityComparer<T>,IDisposable ,IRepository<T> where T : BaseEntity
    {

        

        protected List<T> InternalList;
        private readonly ILogger _logger;
        protected MyGameDbContext _dbContext;


        public BaseRepository()
        {
            InternalList = new List<T>(30);
        }
        public BaseRepository(MyGameDbContext dbContext)
        {
           //_dbContext= new MyGameDbContext();
            _dbContext = dbContext;
           
        }
        public BaseRepository(ILogger log)
        {
            _logger = log;
            InternalList = new List<T>(30);
        }

        public List<T> GetAll()
        {
            return InternalList;
        }
        
        public async Task<T> GetById(int id)
        {
            //var user = UserList.Where(user => user.Id == id).FirstOrDefault();
            //var entity = InternalList.Find(e => e.Id == id);
            return await _dbContext.Set<T>().SingleOrDefaultAsync(e => e.Id==id);      //entity;
        }
        public async Task<T> TryGetById(int id)
        {
            var entity = await GetById(id);
            if (entity == null)
            {
                throw new Exception();
            }
            return entity;
        }
        public async Task<T> Add(T entity)
        {
            //_logger.Info("Added new Entity");
            //InternalList.Add(entity);
            await _dbContext.Set<T>().AddAsync(entity);
            //Audit();
            await _dbContext.SaveChangesAsync();
           return entity;

        }
        public async Task Update(T entity)
        {

           // var foundEntity = InternalList.Find(e => e.Id == entity.Id);
            //foundEntity = entity;
            _dbContext.Entry(entity).State = EntityState.Modified;
           // Audit();
            await _dbContext.SaveChangesAsync();

        }
        public void Remove(T baseEntity)
        {
            _dbContext.Set<T>().Remove(baseEntity);
            //InternalList.Remove(baseEntity);
        }
        public override void CompareId(BaseEntity x, BaseEntity y)
        {
            base.CompareId(x, y);
        }
        public Dictionary<int, string> CreateDic()
        {
            Dictionary<int, string> dct = new Dictionary<int, string>();
            foreach (var baseEntities in InternalList)
            {
                dct.Add(baseEntities.Id, baseEntities.CreatedDate.ToString());
            }
            return dct;
        }

        public void Dispose() => _dbContext?.Dispose();
        
    }
}
