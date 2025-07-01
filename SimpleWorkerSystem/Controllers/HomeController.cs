using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SimpleWorkerSystem.Models;

namespace SimpleWorkerSystem.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private static List<Worker> _workers = new List<Worker>
    {
        new Worker { Id = "001", Name1 = "JFE", Name2 = "タロウ" }
    };

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        ViewBag.Workers = _workers;
        return View();
    }

    [HttpPost]
    public IActionResult AddWorker(string id, string name1, string name2)
    {
        if (!string.IsNullOrEmpty(id))
        {
            var existing = _workers.FirstOrDefault(w => w.Id == id);
            if (existing != null)
            {
                existing.Name1 = name1 ?? "";
                existing.Name2 = name2 ?? "";
            }
            else
            {
                _workers.Add(new Worker { Id = id, Name1 = name1 ?? "", Name2 = name2 ?? "" });
            }
        }
        ViewBag.Workers = _workers;
        ViewBag.Message = "作業者情報を登録しました。";
        return View("Index");
    }

    [HttpPost]
    public IActionResult DeleteWorker(string id)
    {
        var worker = _workers.FirstOrDefault(w => w.Id == id);
        if (worker != null)
        {
            _workers.Remove(worker);
            ViewBag.Message = "作業者情報を削除しました。";
        }
        ViewBag.Workers = _workers;
        return View("Index");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
