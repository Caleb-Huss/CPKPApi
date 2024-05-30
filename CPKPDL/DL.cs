using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPKPModels;
using Microsoft.EntityFrameworkCore;

namespace CPKPDL
{
    public class DL : IDL
    {
        private CpkpDbContext dbContext;
        public DL(CpkpDbContext p_context) 
        {
            dbContext = p_context;
        }
        public async Task<StatDTO> UpdatePlayerStats(StatDTO p_stats)
        {
            Stat playerStats = await dbContext.Stats.FirstAsync(s => s.Playerid == p_stats.Playerid);
            playerStats.Totalguesses = p_stats.Totalguesses;
            playerStats.Correctguesses = p_stats.Correctguesses;
            playerStats.Higheststreak = p_stats.Higheststreak;
            playerStats.Shiniesseen = p_stats.Shiniesseen;
            await dbContext.SaveChangesAsync();
            return new StatDTO(await dbContext.Stats.FirstAsync(s => s.Playerid == p_stats.Playerid));
        }
        public async Task<StatDTO> GetPlayerStats(int p_playerid)
        {
            return new StatDTO(await dbContext.Stats.FirstAsync(s => s.Playerid == p_playerid));
        }
        public async Task<PlayerDTO> CreatePlayer(PlayerDTO p_player)
        {
            Player newPlayer = new Player()
            {
                Playerid = p_player.Playerid,
                Email = p_player.Email,
                Username = p_player.Username,
                Createdate = DateTime.Now,
                Lastlogin = DateTime.Now,
                Stat = null
            };

            await dbContext.Players.AddAsync(newPlayer);
            await dbContext.SaveChangesAsync();

            PlayerDTO newestPlayer = new PlayerDTO(await dbContext.Players.FirstAsync(p => p.Email == p_player.Email));

            Stat newStats = new Stat()
            {
                Playerid = newestPlayer.Playerid,
                Correctguesses = 0,
                Totalguesses = 0,
                Shiniesseen = 0,
                Higheststreak = 0,
                Player = null
            };

            await dbContext.Stats.AddAsync(newStats);
            await dbContext.SaveChangesAsync();

            return newestPlayer;
        }
        public async Task<PlayerDTO> UpdatePlayer(PlayerDTO p_player)
        {
            Player player = await dbContext.Players.FirstAsync(p => p.Playerid == p_player.Playerid);

            player.Email = p_player.Email;
            player.Username = p_player.Username;
            player.Lastlogin = DateTime.Now;

            await dbContext.SaveChangesAsync();

            return new PlayerDTO(await dbContext.Players.FirstAsync(p => p.Playerid == p_player.Playerid));
        }
        public async Task<PlayerDTO> GetPlayer(PlayerDTO p_player)
        {
            Player player = await dbContext.Players.FirstAsync(p => p.Email == p_player.Email);

            player.Lastlogin = DateTime.Now;

            await dbContext.SaveChangesAsync();

            return new PlayerDTO(await dbContext.Players.FirstAsync(s => s.Email == p_player.Email));
        }


        public async Task<int> TestVal(int pval)
        {
            return pval + pval;
        }

        
    }
}
