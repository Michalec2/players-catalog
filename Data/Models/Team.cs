using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace players_catalog.Data.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        // Lista piłkarzy w zespole
        public ICollection<Player> Players { get; set; }

        // Klucz obcy do trenera
        public int CoachId { get; set; }
        public Coach Coach { get; set; }
    }
}