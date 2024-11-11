using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using players_catalog.Data;
using players_catalog.Data.Models;
using players_catalog.Models;

namespace players_catalog.Controllers
{
    [Route("[controller]")]
    public class TeamController : Controller
    {
        private DataContext DataContext { get; set; }
        private HttpClient HttpClient { get; set; }

        public TeamController(DataContext dataContext, HttpClient httpClient)
        {
            DataContext = dataContext;
            HttpClient = httpClient;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            HttpClient.DefaultRequestHeaders.Add("X-Auth-Token", "token-here");

            var response = await HttpClient.GetAsync("https://api.football-data.org/v4/competitions");
            if (!response.IsSuccessStatusCode)
            {
                var responseMessage = await response.Content.ReadAsStringAsync();
                return View("Error");
            }

            var apiContent = await response.Content.ReadAsStringAsync();
            var apiCompetitions = JsonConvert.DeserializeObject<CompetitionsModel>(apiContent);

            List<Team> teams = DataContext.Teams.Include(x => x.Coach).ToList();
            List<TeamViewmodel> teamViewmodel = new List<TeamViewmodel>();
            foreach (Team team in teams)
            {
                teamViewmodel.Add(new TeamViewmodel
                {
                    Id = team.Id,
                    Name = team.Name,
                    CoachName = team.Coach.Name,
                    CompetitionsModel = apiCompetitions
                });
            }

            return View(teamViewmodel);
        }

        [HttpGet("Create")]
        public ActionResult Create()
        {
            ViewBag.Coaches = DataContext.Coaches.ToList(); // Potrzebne do wyboru trenera
            return View();
        }

        [HttpPost("Create")]
        public ActionResult Create(TeamFormModel team)
        {
            if (ModelState.IsValid)
            {
                Team team2 = new Team
                {
                    Name = team.Name,
                    CoachId = team.CoachId
                };

                DataContext.Teams.Add(team2);
                DataContext.SaveChanges();

                return RedirectToAction("Index");
            }

            return Create();
        }
    }
}