using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MessageBoard.Models;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Web;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

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
    List<Post> thisPosts = await Post.GetAllPostsAsync();
    ViewBag.posts = thisPosts.Where(po => po.UsersId == id);
    
    return View(thisUser);
  }

  public ActionResult Create()
  {
    return View();
  }

  [HttpPost]
  public ActionResult Create(Users users)
  {
    Users.PostUsers(users);
    Thread.Sleep(600);
    return RedirectToAction("Index");
  }

  public async Task<ActionResult> Edit(int id)
  {
    Users users = await Users.GetUserAsync(id);
    return View(users);
  }

  [HttpPost]
  public ActionResult Edit(Users users)
  {
    Users.PutUsers(users);
    Thread.Sleep(600);
    return RedirectToAction("Details", new { id = users.UsersId});
  }

  [HttpGet("/users/{id}/posts/edit")]
  public async Task<ActionResult> EditPosts(int id)
  {
    List<Post> allPosts = await Post.GetAllPostsAsync();
    List<Post> thesePosts = allPosts.Where(po => po.UsersId == id).ToList();
    Users thisUser = await Users.GetUserAsync(id);
    ViewBag.posts = thesePosts;
    return View(thisUser);
  }

  [HttpPost("/users/{id}/posts/edit/{postId}")]
  public async Task<ActionResult> EditPost(int id, int postId, string Body)
  {
    List<Post> allPosts = await Post.GetAllPostsAsync();
    Post thisPost = allPosts.FirstOrDefault(po => po.PostId == postId);
    thisPost.Body = Body;
    Post.PutPost(thisPost);
    return Redirect($"/users/details/{id}");
  }

  [HttpPost("/users/{id}/posts/delete/{postId}")]
  public async Task<ActionResult> DeletePost(int id, int postId)
  {
    List<Post> allPosts = await Post.GetAllPostsAsync();
    Post thisPost = allPosts.FirstOrDefault(po => po.PostId == postId);
    Post.DeletePost(thisPost);
    return Redirect($"/users/details/{id}");
  }
}