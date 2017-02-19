using System.Threading.Tasks;

namespace ATPDL.DataLoader.Interfaces
{
    public interface ILoadPlayers
    {
        Task Load(int from, int to);
    }
}