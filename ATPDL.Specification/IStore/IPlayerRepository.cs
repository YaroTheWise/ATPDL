using System.Linq;
using System.Threading.Tasks;
using ATPDL.Specification.Models;

namespace ATPDL.Specification.IStore
{
    public interface IPlayerRepository
    {
        Task Save(Player player);
        IQueryable<Player> Query();
    }
}