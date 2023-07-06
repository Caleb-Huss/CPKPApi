using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CPKPModels
{
    public class StatDTO
    {
        [JsonConstructor]
        public StatDTO() { }

        public StatDTO(Stat p_stat)
        {
            this.Playerid = p_stat.Playerid;
            this.Totalguesses = p_stat.Totalguesses;
            this.Shiniesseen = p_stat.Shiniesseen;
            this.Correctguesses = p_stat.Correctguesses;
            this.Higheststreak = p_stat.Higheststreak;
        
        }
        public int Playerid { get; set; }

        public int? Totalguesses { get; set; }

        public int? Correctguesses { get; set; }

        public int? Higheststreak { get; set; }

        public int? Shiniesseen { get; set; }
    }

}
