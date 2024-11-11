using System.Linq;
using Microsoft.AspNetCore.Mvc;
using players_catalog.Data;
using players_catalog.Data.Models;
using players_catalog.Models;

namespace players_catalog.Controllers
{
    [Route("[controller]")]
    public class CoachController : Controller
    {
        public DataContext DataContext { get; set; }
        public CoachController(DataContext dataContext)
        {
            DataContext = dataContext;
        }

        [HttpGet]
        public ActionResult Index()
        {
            List<Coach> coaches = DataContext.Coaches.ToList();
            List<CoachViewModel> coachViewModels = new List<CoachViewModel>();
            foreach (Coach coach in coaches)
            {
                coachViewModels.Add(new CoachViewModel
                {
                    ExperienceYears = coach.ExperienceYears,
                    Id = coach.Id,
                    Name = coach.Name
                });
            }
            return View(coachViewModels);
        }

        [HttpGet("Create")]
        public ActionResult Create()
        {
            CoachFormModel model = new CoachFormModel
            {
                ExperienceYears = 10
            };
            
            return View(model);
        }

        [HttpPost("Create")]
        public ActionResult Create(CoachFormModel coachFormModel)
        {
            if (ModelState.IsValid)
            {
                Coach coach = new Coach
                {
                    Name = coachFormModel.Name,
                    ExperienceYears = coachFormModel.ExperienceYears
                };

                DataContext.Coaches.Add(coach);
                DataContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return Create();
        }
    }
}
