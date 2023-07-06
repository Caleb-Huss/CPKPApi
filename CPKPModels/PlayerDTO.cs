using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CPKPModels
{
    public class PlayerDTO
    {
        [JsonConstructor]
        public PlayerDTO() { }

        public PlayerDTO(Player p_player) 
        { 
            this.Playerid = p_player.Playerid;
            this.Username = p_player.Username;
            this.Createdate = p_player.Createdate;
            this.Lastlogin = p_player.Lastlogin;
            this.Email = p_player.Email;
        }
        public int Playerid { get; set; }

        public string? Email { get; set; }

        public string? Username { get; set; }

        public DateTime? Createdate { get; set; }

        public DateTime? Lastlogin { get; set; }
    }
}
