using System.ComponentModel.DataAnnotations;

namespace SeizoManagementSystem.Models
{
    public class Worker
    {
        [Display(Name = "作業者番号")]
        public string WorkerId { get; set; } = string.Empty;

        [Display(Name = "名前1")]
        public string Name1 { get; set; } = string.Empty;

        [Display(Name = "名前2")]
        public string Name2 { get; set; } = string.Empty;
    }
}