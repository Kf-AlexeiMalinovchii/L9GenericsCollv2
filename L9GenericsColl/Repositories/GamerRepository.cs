using L9GenericsColl.Interfaces;
using L9GenericsColl.Entities;
using System.Collections.Generic;
using System.Linq;
using L9GenericsColl.Enums;
using L9GenericsColl.DbContexts;

namespace L9GenericsColl.Repositories
{
    public class GamerRepository : BaseRepository<Gamer>, IGamerRepository
    {
        
        public List<Gamer> GetGamersWithStatus(UserState userState)
        {

            var list = InternalList.Where(p => p.State == userState).ToList();

            return list;
        }
        public GamerRepository(MyGameDbContext dbContext)
        {
            //_dbContext= new MyGameDbContext();
            _dbContext = dbContext;

        }
    }
}
