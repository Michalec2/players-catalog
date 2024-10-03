using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using players_catalog.Data;
using players_catalog.Data.Models;
using players_catalog.Models;

namespace players_catalog.Controllers
{
    public class TeamController : Controller
    {
        private DataContext DataContext { get; set; }

        public TeamController(DataContext dataContext)
        {
            DataContext = dataContext;
        }

        public ActionResult Index()
        {
            List<Team> teams = DataContext.Teams.Include(x => x.Coach).ToList();
            List<TeamViewmodel> teamViewmodel = new List<TeamViewmodel>();
            foreach (Team team in teams)
            {
                teamViewmodel.Add(new TeamViewmodel
                {
                    Id = team.Id,
                    Name = team.Name,
                    CoachName = team.Coach.Name
                });
            }

            return View(teamViewmodel);
        }

        public ActionResult Create()
        {
            ViewBag.Coaches = DataContext.Coaches.ToList(); // Potrzebne do wyboru trenera
            return View();
        }

        [HttpPost]
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