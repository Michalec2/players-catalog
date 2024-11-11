using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using players_catalog.Data;
using players_catalog.Data.Models;
using players_catalog.Models;

namespace players_catalog.Controllers
{
    [Route("[controller]")]
    public class PlayerController : Controller
    {
        public DataContext DataContext { get; set; }

        public PlayerController(DataContext dataContext)
        {
            DataContext = dataContext;
        }

        [HttpGet]
        public ActionResult Index()
        {
            List<Player> players = DataContext.Players.Include(x => x.Team).ToList();
            List<PlayerViewModel> playerViewModels = new List<PlayerViewModel>();
            foreach (var player in players)
            {
                playerViewModels.Add(new PlayerViewModel
                {
                    Id = player.Id,
                    Name = player.Name,
                    Age = player.Age,
                    Position = player.Position,
                    TeamName = player.Team.Name
                });
            }
            return View(playerViewModels);
        }

        [HttpGet("Create")]
        public ActionResult Create()
        {
            ViewBag.Teams = DataContext.Teams.ToList();

            PlayerFormModel model = new PlayerFormModel
            {
                Age = 10
            };
            
            return View(model);
        }

        [HttpPost("Create")]
        public ActionResult Create(PlayerFormModel playerFormModel)
        {
            if (ModelState.IsValid)
            {
                Player player = new Player
                {
                    Name = playerFormModel.Name,
                    Age = playerFormModel.Age,
                    Position = playerFormModel.Position,
                    TeamId = playerFormModel.TeamId
                };

                DataContext.Players.Add(player);
                DataContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return Create();
        }

        [HttpGet("Edit")]
        public ActionResult Edit(int id)
        {
            ViewBag.Teams = DataContext.Teams.ToList();
            
            Player player = DataContext.Players.Find(id);
            if (player == null) return NotFound();

            var playerFormModel = new PlayerFormModel
            {
                Name = player.Name,
                Age = player.Age,
                Position = player.Position,
                TeamId = player.TeamId
            };

            return View(playerFormModel);
        }

        [HttpPost("Edit")]
        public ActionResult Edit(int id, PlayerFormModel playerFormModel)
        {
            Player player = DataContext.Players.Find(id);
            if (player == null) return NotFound();

            if (ModelState.IsValid)
            {
                player.Name = playerFormModel.Name;
                player.Age = playerFormModel.Age;
                player.Position = playerFormModel.Position;
                player.TeamId = playerFormModel.TeamId;

                DataContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return Edit(id);
        }

        [HttpGet("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            Player player = DataContext.Players.Find(id);
            if (player == null) return NotFound();

            DataContext.Players.Remove(player);
            DataContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
