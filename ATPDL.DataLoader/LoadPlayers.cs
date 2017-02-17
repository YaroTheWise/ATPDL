using System;
using System.Threading.Tasks;
using ATPDL.DataLoader.Interfaces;
using ATPDL.Specification.IStore;

namespace ATPDL.DataLoader
{
    public class LoadPlayers : ILoadPlayers
    {
        private readonly IPlayerUrlListGetter playerUrlListGetter;
        private readonly IPlayerBuilder playerBuilder;
        private readonly IStore store;

        public LoadPlayers(IPlayerUrlListGetter playerUrlListGetter,
            IPlayerBuilder playerBuilder, 
            IStore store)
        {
            this.playerUrlListGetter = playerUrlListGetter;
            this.playerBuilder = playerBuilder;
            this.store = store;
        }

        public async Task Load()
        {
            using (var httpClient = new System.Net.Http.HttpClient { BaseAddress = new Uri(UrlResource.Site) })
            {
                var playerUrlList = await playerUrlListGetter.Get(httpClient, 1, 10);
                foreach (var item in playerUrlList)
                {
                    var response = await httpClient.GetAsync(item);
                    var payerInfoText = await response.Content.ReadAsStringAsync();
                    var player = playerBuilder.Build(payerInfoText);
                    await store.PlayerRepository.Save(player);
                }

                await store.SubmitChangesAsync();
            }
        }
    }
}