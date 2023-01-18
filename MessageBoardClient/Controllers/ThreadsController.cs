using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MessageBoard.Models;

namespace MessageBoard.Controllers;

public class ThreadsController : Controller
{
    private readonly ILogger<ThreadsController> _logger;

    public ThreadsController(ILogger<ThreadsController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        List<Threads> threads = await Threads.GetAllThreadsAsync();
        return View(threads);
    }

    public async Task<IActionResult> Details(int id)
    {
        Threads thisThread = await Threads.GetThreadAsync(id);
        List<Post> thisPosts = await Post.GetPostsAsync();
        ViewBag.posts = thisPosts.Where(po => po.ThreadsId == id);
        return View(thisThread);
    }
}