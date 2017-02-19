using System;
using System.Threading.Tasks;
using ATPDL.DataLoader.Interfaces;

namespace ATPDL.Main
{
    public class StartLoadData
    {
        private const int batch = 10;
        private readonly ILoadPlayers loadPlayers;

        public StartLoadData(ILoadPlayers loadPlayers)
        {
            this.loadPlayers = loadPlayers;
        }

        public async Task Start(int from, int to)
        {
            for (int i = from; i <= to; i = i + batch)
            {
                await loadPlayers.Load(i, Math.Min(i + batch - 1, to));
            }
        }
    }
}