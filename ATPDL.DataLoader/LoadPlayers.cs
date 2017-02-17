using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using ATPDL.DataLoader.Interfaces;
using ATPDL.Specification.IStore;
using ATPDL.Specification.Models;

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
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            var list = new List<Task<Player>>();

            using (var httpClient = new System.Net.Http.HttpClient { BaseAddress = new Uri(UrlResource.Site) })
            {
                var playerUrlList = await playerUrlListGetter.Get(httpClient, 1, 20);
                foreach (var item in playerUrlList)
                {
                    list.Add(PayerInfoText(httpClient, item));
                }

                foreach (var item in list)
                {
                    await store.PlayerRepository.Save(await item);
                }

                stopWatch.Stop();
                Console.WriteLine("RunTime " + stopWatch.ElapsedMilliseconds);
                Console.WriteLine();
                await store.SubmitChangesAsync();
            }
        }

        private async Task<Player> PayerInfoText(HttpClient httpClient, string item)
        {
            var response = await httpClient.GetAsync(item);
            var payerInfoText = await response.Content.ReadAsStringAsync();
            var player = playerBuilder.Build(payerInfoText);
            return player;
        }


        //public async Task Load()
        //{
        //    Stopwatch stopWatch = new Stopwatch();
        //    stopWatch.Start();
            
        //    using (var httpClient = new System.Net.Http.HttpClient { BaseAddress = new Uri(UrlResource.Site) })
        //    {
        //        var playerUrlList = await playerUrlListGetter.Get(httpClient, 1, 20);
        //        foreach (var item in playerUrlList)
        //        {
        //            var response = await httpClient.GetAsync(item);
        //            var payerInfoText = await response.Content.ReadAsStringAsync();
        //            var player = playerBuilder.Build(payerInfoText);
        //            await store.PlayerRepository.Save(player);
        //        }

        //        stopWatch.Stop();
        //        Console.WriteLine("RunTime " + stopWatch.ElapsedMilliseconds);
        //        Console.WriteLine();
        //        await store.SubmitChangesAsync();
        //    }
        //}
    }
}