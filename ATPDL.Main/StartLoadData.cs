using System.Threading.Tasks;
using ATPDL.DataLoader.Interfaces;

namespace ATPDL.Main
{
    public class StartLoadData
    {
        private readonly ILoadPlayers loadPlayers;

        public StartLoadData(ILoadPlayers loadPlayers)
        {
            this.loadPlayers = loadPlayers;
        }

        public async Task Start()
        {
            await loadPlayers.Load();
        }
    }
}