using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InstructorInformationSystem.Data;
using InstructorInformationSystem.Models;


namespace InstructorInformationSystem.Controllers
{
    public class AccountController : Controller 
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }
        

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(Admin admin)
        {
            if (ModelState.IsValid)
            {
                _context.Admins.Add(admin);
                _context.SaveChanges();
                
                TempData["SuccessMessage"] = "Registration successful! You can now log in.";
                return RedirectToAction("Login");
            }
            TempData["ErrorMessage"] = "Invalid input details. Please fix the errors below.";
            return View(admin);
        }

        public IActionResult Login()
        {
            HttpContext.Session.Clear(); 
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string email, string password)
        {
            var admin = _context.Admins.FirstOrDefault(a => a.Email == email && a.Password == password);
            if (admin != null)
            {

                HttpContext.Session.SetString("AdminSession", admin.Email);
                HttpContext.Session.SetString("AdminName", admin.FirstName);

                TempData["SuccessMessage"] = $"Welcome back, {admin.FirstName}!";

                return RedirectToAction("Index", "Instructors");
            }

            TempData["ErrorMessage"] = "Invalid email or password. Please try again.";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); 
            TempData["SuccessMessage"] = "You have been logged out successfully.";
            return RedirectToAction("Login");
        }
    }
}