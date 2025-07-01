using Microsoft.AspNetCore.Mvc;
using SeizoManagementSystem.Models;

namespace SeizoManagementSystem.Controllers
{
    public class WorkerMasterController : Controller
    {
        private static List<Worker> workers = new List<Worker>
        {
            new Worker { WorkerId = "001", Name1 = "JFE", Name2 = "タロウ" }
        };

        public IActionResult Index()
        {
            ViewBag.Workers = workers;
            return View();
        }

        [HttpPost]
        public IActionResult Register(Worker worker)
        {
            if (!string.IsNullOrEmpty(worker.WorkerId))
            {
                var existingWorker = workers.FirstOrDefault(w => w.WorkerId == worker.WorkerId);
                if (existingWorker != null)
                {
                    existingWorker.Name1 = worker.Name1;
                    existingWorker.Name2 = worker.Name2;
                }
                else
                {
                    workers.Add(worker);
                }
            }
            ViewBag.Workers = workers;
            return View("Index");
        }

        [HttpPost]
        public IActionResult Delete(string workerId)
        {
            var worker = workers.FirstOrDefault(w => w.WorkerId == workerId);
            if (worker != null)
            {
                workers.Remove(worker);
            }
            ViewBag.Workers = workers;
            return View("Index");
        }

        [HttpGet]
        public IActionResult GetWorker(string workerId)
        {
            var worker = workers.FirstOrDefault(w => w.WorkerId == workerId);
            if (worker != null)
            {
                return Json(new { success = true, worker });
            }
            return Json(new { success = false });
        }

        [HttpPost]
        public IActionResult Search()
        {
            ViewBag.Workers = workers;
            return View("Index");
        }

        [HttpPost]
        public IActionResult Maintenance()
        {
            // 作業者メンテナンス処理
            ViewBag.Workers = workers;
            return View("Index");
        }

        [HttpPost]
        public IActionResult Parameter()
        {
            // パラメータ処理
            ViewBag.Workers = workers;
            return View("Index");
        }

        [HttpPost]
        public IActionResult ServerManagement()
        {
            // サーバー管理処理
            ViewBag.Workers = workers;
            return View("Index");
        }
    }
}