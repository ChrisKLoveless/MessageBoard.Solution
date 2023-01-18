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

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        List<Users> users = await Users.GetAllUsersAsync();
        return View(users);
    }

    public async Task<IActionResult> Details(int id)
    {
        Users thisUser = await Users.GetUserAsync(id);
        List<Threads> thisThreads = await Threads.GetAllThreadsAsync();
        ViewBag.threads = thisThreads.Where(th => th.UsersId == id);
        List<Post> thisPosts = await Post.GetPostsAsync();
        ViewBag.posts = thisPosts.Where(po => po.UsersId == id);
        return View(thisUser);
    }
}