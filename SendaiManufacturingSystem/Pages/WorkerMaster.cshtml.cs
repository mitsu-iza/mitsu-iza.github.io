using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace SendaiManufacturingSystem.Pages
{
    public class WorkerMasterModel : PageModel
    {
        [BindProperty]
        public WorkerViewModel Worker { get; set; } = new WorkerViewModel();

        public List<WorkerViewModel> Workers { get; set; } = new List<WorkerViewModel>();

        public void OnGet()
        {
            LoadWorkers();
        }

        public IActionResult OnPostRegister()
        {
            LoadWorkers();
            
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // 登録処理
            if (Workers.Any(w => w.WorkerNumber == Worker.WorkerNumber))
            {
                ModelState.AddModelError("Worker.WorkerNumber", "この作業者番号は既に存在します。");
                return Page();
            }

            Workers.Add(new WorkerViewModel 
            { 
                WorkerNumber = Worker.WorkerNumber, 
                FirstName = Worker.FirstName, 
                LastName = Worker.LastName 
            });
            
            SaveWorkers();

            // 登録後、フォームをクリア
            Worker = new WorkerViewModel();
            
            return RedirectToPage();
        }

        public IActionResult OnPostDelete(string workerNumber)
        {
            LoadWorkers();
            Workers.RemoveAll(w => w.WorkerNumber == workerNumber);
            SaveWorkers();
            return RedirectToPage();
        }

        private void LoadWorkers()
        {
            // セッションからデータを読み込み、存在しない場合は初期データを設定
            var workersJson = HttpContext.Session.GetString("Workers");
            if (!string.IsNullOrEmpty(workersJson))
            {
                Workers = System.Text.Json.JsonSerializer.Deserialize<List<WorkerViewModel>>(workersJson) ?? new List<WorkerViewModel>();
            }
            else
            {
                // 初期データの設定
                Workers = new List<WorkerViewModel>
                {
                    new WorkerViewModel { WorkerNumber = "001", FirstName = "JFE", LastName = "タロウ" }
                };
                SaveWorkers();
            }
        }

        private void SaveWorkers()
        {
            // セッションにデータを保存
            var workersJson = System.Text.Json.JsonSerializer.Serialize(Workers);
            HttpContext.Session.SetString("Workers", workersJson);
        }
    }

    public class WorkerViewModel
    {
        [Required(ErrorMessage = "作業者番号は必須です。")]
        [Display(Name = "作業者番号")]
        public string WorkerNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "名前1は必須です。")]
        [Display(Name = "名前1(性)")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "名前2は必須です。")]
        [Display(Name = "名前2(名)")]
        public string LastName { get; set; } = string.Empty;
    }
}