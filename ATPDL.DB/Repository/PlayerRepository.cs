using System;
using System.Linq;
using System.Threading.Tasks;
using ATPDL.Specification.IStore;
using ATPDL.Specification.Models;

namespace ATPDL.DB.Repository
{
    internal class PlayerRepository : IPlayerRepository
    {
        private readonly StoreContext storeContext;

        public PlayerRepository(StoreContext storeContext)
        {
            this.storeContext = storeContext;
        }

        public Task Save(Player playerInfo)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Player>> Query()
        {
            throw new NotImplementedException();
        }
    }
}