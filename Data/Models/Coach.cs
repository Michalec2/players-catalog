using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace players_catalog.Data.Models
{
    public class Coach
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ExperienceYears { get; set; }

        // Lista zespołów, które prowadzi trener
        public ICollection<Team> Teams { get; set; }
    }
}