using System;
using System.Data.Entity;
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

        public async Task Save(Player player)
        {
            var playerDb = await storeContext.Db.Players
                .SingleOrDefaultAsync(x => x.Code == player.Info.Code);

            if (playerDb == null)
            {
                playerDb = new Model.Player();
                storeContext.Db.Players.Add(playerDb);
                storeContext.AfterSubmitChanges(() => player.Info.PlayerId = playerDb.PlayerId);
                playerDb.Code = player.Info.Code;
            }

            playerDb.FirstName = player.Info.FirstName;
            playerDb.LastName = player.Info.LastName;
            playerDb.NameCode = player.Info.NameCode;
            playerDb.Birthday = player.Info.Birthday;
            playerDb.StartYear = player.Info.StartYear;
            playerDb.BirthdayPlace = player.Info.BirthdayPlace;
            playerDb.Residence = player.Info.Residence;
            playerDb.NationalityCode = player.Info.Nationality;
            playerDb.Hand = (int)player.PhysicalParameter.Hand;
            playerDb.Backhand = (int)player.PhysicalParameter.Backhand;
            playerDb.WeightKg = player.PhysicalParameter.Weight.Kg;
            playerDb.WeightLbs = player.PhysicalParameter.Weight.Lbs;
            playerDb.HeightCm = player.PhysicalParameter.Height.Cm;
            playerDb.HeightFoot = player.PhysicalParameter.Height.Foot;
        }

        public IQueryable<Player> Query()
        {
            return storeContext.Db.Players
                .Select(x => new Player
                {
                    Info = new PlayerInfo
                    {
                        PlayerId = x.PlayerId,
                        Code = x.Code,
                        NameCode = x.NameCode,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        Birthday = x.Birthday,
                        Nationality = x.NationalityCode,
                        BirthdayPlace = x.BirthdayPlace,
                        Residence = x.Residence,
                        StartYear = x.StartYear,
                    },
                    PhysicalParameter = new PlayerPhysicalParameter
                    {
                        Hand = (Hand)x.Hand,
                        Backhand = (Backhand)x.Backhand,
                        Height = new Height
                        {
                            Foot = x.HeightFoot,
                            Cm = x.HeightCm,
                        },
                        Weight = new Weight
                        {
                            Lbs = x.WeightLbs,
                            Kg = x.WeightKg,
                        },
                    },
                });
        }
    }
}