using System.Data.Entity;
using System.Threading.Tasks;
using ATPDL.DB.Migrations;
using ATPDL.DB.Repository;
using ATPDL.Specification.IStore;

namespace ATPDL.DB
{
    public class Store : IStore
    {
        private readonly StoreContext storeContext;

        public Store()
        {
            storeContext = new StoreContext();
            PlayerRepository = new PlayerRepository(storeContext);
        }

        public IPlayerRepository PlayerRepository { get; }

        public void SubmitChanges()
        {
            storeContext.SubmitChanges();
        }
        public async Task SubmitChangesAsync()
        {
            await storeContext.SubmitChangesAsync();
        }
        public void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ATPDLContext, Configuration>());
        }
    }
}