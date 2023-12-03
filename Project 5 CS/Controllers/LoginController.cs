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
        return View();
    }

    [HttpPost]
    public IActionResult Index(string username, string password)
    {
        var user = _context.Table.FirstOrDefault(u => u.User == username && u.Password == password);

        if (user != null)
        {
            if (user.AccessLevel == "admin")
            {
                // Redirect admin to Admin.cs
                return RedirectToAction("Admin");
            }
            else if (user.AccessLevel == "customer")
            {
                // Redirect customer to MusicStore.cs
                return RedirectToAction("MusicStore");
            }
        }

        // Authentication failed, return to login page with an error message
        ViewBag.Error = "Invalid username or password";
        return View();
    }

    public IActionResult Admin()
    {
        // Logic for admin view (Admin.cs)
        return View("Admin");
    }

    public IActionResult MusicStore()
    {
        // Logic for customer view (MusicStore.cs)
        return View("MusicStore");
    }
}
