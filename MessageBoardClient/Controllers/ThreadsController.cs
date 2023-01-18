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

    public async Task<IActionResult> Index()
    {
        List<Threads> threads = await Threads.GetThreadsAsync();
        return View(threads);
    }
}