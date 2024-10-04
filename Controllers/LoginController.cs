using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using players_catalog.Data;
using players_catalog.Data.Models;
using players_catalog.Models;

namespace players_catalog.Controllers
{
    public class LoginController : Controller
    {
        private readonly DataContext DataContext;

        public LoginController(DataContext context)
        {
            DataContext = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterLoginViewModel model)
        {
            if(!ModelState.IsValid)
                return View(model);

            if (DataContext.Users.Any(u => u.Username == model.Username))
            {
                ModelState.AddModelError("", "Użytkownik o takiej nazwie już istnieje.");
                return View();
            }

            CreatePasswordHash(model.Password, out byte[] passwordHash);

            User user = new User
            {
                Username = model.Username,
                PasswordHash = passwordHash,
            };

            DataContext.Users.Add(user);
            DataContext.SaveChanges();
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(RegisterLoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = DataContext.Users.SingleOrDefault(u => u.Username.ToLower() == model.Username.ToLower());
            if (user == null || !VerifyPasswordHash(model.Password, user.PasswordHash))
            {
                ModelState.AddModelError("", "Nieprawidłowy login lub hasło.");
                return View();
            }

            // Logowanie użytkownika
            HttpContext.Session.SetString("userName", model.Username);
            return RedirectToAction("Index", "Player");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("userName");
            return RedirectToAction("Login");
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash)
        {
            using (var hmac = new HMACSHA512(System.Text.Encoding.UTF8.GetBytes("key")))
            {
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] storedHash)
        {
            using (var hmac = new HMACSHA512(System.Text.Encoding.UTF8.GetBytes("key")))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(storedHash);
            }
        }
    }
}
