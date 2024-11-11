namespace players_catalog.Models
{
    public class Area
    {
        public int id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public string flag { get; set; }
    }

    public class Competition
    {
        public int id { get; set; }
        public Area area { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public string type { get; set; }
        public string emblem { get; set; }
        public string plan { get; set; }
        public CurrentSeason currentSeason { get; set; }
        public int numberOfAvailableSeasons { get; set; }
        public DateTime lastUpdated { get; set; }
    }

    public class CurrentSeason
    {
        public int id { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public int? currentMatchday { get; set; }
        public Winner winner { get; set; }
    }

    public class Filters
    {
    }

    public class CompetitionsModel
    {
        public int count { get; set; }
        public Filters filters { get; set; }
        public List<Competition> competitions { get; set; }
    }

    public class Winner
    {
        public int id { get; set; }
        public string name { get; set; }
        public string shortName { get; set; }
        public string tla { get; set; }
        public string crest { get; set; }
        public string address { get; set; }
        public string website { get; set; }
        public int founded { get; set; }
        public string clubColors { get; set; }
        public string venue { get; set; }
        public DateTime lastUpdated { get; set; }
    }

}