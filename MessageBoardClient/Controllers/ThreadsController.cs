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
        List<Users> users = await Users.GetAllUsersAsync();
        ViewBag.users = users;
        return View(threads);
    }

    public async Task<IActionResult> Details(int id)
    {
        Threads thisThread = await Threads.GetThreadAsync(id);
        List<Post> thisPosts = await Post.GetAllPostsAsync();
        ViewBag.posts = thisPosts.Where(po => po.ThreadsId == id);
        List<Users> users = await Users.GetAllUsersAsync();
        ViewBag.users = users;
        return View(thisThread);
    }

    public async Task<ActionResult> Create()
    {
        List<Users> users = await Users.GetAllUsersAsync();
        ViewBag.users = users;
        return View();
    }

    [HttpPost]
    public ActionResult Create(Threads threads)
    {
        Threads.PostThreads(threads);
        Thread.Sleep(600);
        return RedirectToAction("Index");
    }

    [HttpPost("/threads/{id}/newPost")]
    public ActionResult NewPost(int id, string Body, int UsersId)
    {
        Post post = new Post();
        post.Body = Body;
        post.ThreadsId = id;
        post.UsersId = UsersId;
        Post.PostPost(post);
        Thread.Sleep(600);
        return Redirect($"/threads/details/{id}");
    }

    public async Task<ActionResult> Edit(int id)
    {
        Threads threads = await Threads.GetThreadAsync(id);
        return View(threads);
    }

    [HttpPost]
    public ActionResult Edit(Threads threads)
    {
        Threads.PutThreads(threads);
        Thread.Sleep(600);
        return RedirectToAction("Details", new { id = threads.ThreadsId });
    }

    [HttpPost("/threads/{id}/delete")]
    public async Task<ActionResult> DeletePost(int id)
    {
        Threads thisTHreads = await Threads.GetThreadAsync(id);
        Threads.DeleteThreads(thisTHreads);
        Thread.Sleep(600);
        return Redirect($"/threads");
    }
}