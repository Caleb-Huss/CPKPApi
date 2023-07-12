using CPKPDL;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPKPModels;

namespace CPKPBL
{
    public class BL : IBL
    {

        private readonly CPKPDL.IDL _repo;

        public BL(IDL p_repo)
        {
            _repo = p_repo; 
        }
        public async Task<StatDTO> UpdatePlayerStats(StatDTO p_stats)
        {
            return await _repo.UpdatePlayerStats(p_stats);
        }
        public async Task<StatDTO> GetPlayerStats(int p_playerid)
        {
            return await _repo.GetPlayerStats(p_playerid);
        }
        public async Task<PlayerDTO> CreatePlayer(PlayerDTO p_player)
        {
            return await _repo.CreatePlayer(p_player);
        }
        public async Task<PlayerDTO> UpdatePlayer(PlayerDTO p_player)
        {
            return await _repo.UpdatePlayer(p_player);
        }

        public async Task<int> TestVal(int pval)
        {
            return await _repo.TestVal(pval);
        }
    }
}
