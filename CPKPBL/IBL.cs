using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPKPModels;

namespace CPKPBL
{
    public interface IBL
    {
        /// <summary>
        /// Update the stats of the player
        /// </summary>
        /// <param name="p_stats"></param>
        /// <returns></returns>
        Task<StatDTO> UpdatePlayerStats(StatDTO p_stats);

        /// <summary>
        /// Get The Stats Of A Given Player
        /// </summary>
        /// <param name="p_playerid"></param>
        /// <returns></returns>
        Task<StatDTO> GetPlayerStats(int p_playerid);

        /// <summary>
        /// Create A New Player Entry
        /// </summary>
        /// <param name="p_playerid"></param>
        /// <returns></returns>
        Task<PlayerDTO> CreatePlayer(PlayerDTO p_player);

        /// <summary>
        /// Update Player Info
        /// </summary>
        /// <param name="p_playerid"></param>
        /// <returns></returns>
        Task<PlayerDTO> UpdatePlayer(PlayerDTO p_player);

    }
}
