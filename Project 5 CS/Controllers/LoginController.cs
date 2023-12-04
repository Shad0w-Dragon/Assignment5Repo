using Microsoft.AspNetCore.Mvc;
using Project_5_CS.Models;

public class LoginController : Controller
{
    private readonly LoginDbContext _context;

    public LoginController(LoginDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View(new LoginModel());
    }

    [HttpPost]
  
    public IActionResult Index(string username, string password)
    {
        var user = _context.Table.FirstOrDefault(u => u.User == username && u.Password == password);

        if (user != null)
        {
            if (user.AccessLevel == "customer")
            {
                // Redirect to MusicStore.cshtml for customers
                return Redirect("~/MusicStore/Index");
            }
            else if (user.AccessLevel == "admin")
            {
                // Redirect to the admin page for admins
                return RedirectToAction("Index", "Admin"); 
            }
        }

      
        ViewBag.Error = "Invalid username or password";
        return View();
    }

    public IActionResult LoggedIn()
    {
        return View();
    }

    // Other actions (Admin, MusicStore, etc.) remain the same
}
