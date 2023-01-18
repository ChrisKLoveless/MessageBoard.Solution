using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MessageBoard.Models;

namespace MessageBoard.Controllers;

public class UsersController : Controller
{
    private readonly ILogger<UsersController> _logger;

    public UsersController(ILogger<UsersController> logger)
    {
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        List<Users> users = await Users.GetUsersAsync();
        return View(users);
    }
}