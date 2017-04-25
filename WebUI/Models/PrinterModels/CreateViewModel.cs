using System.ComponentModel.DataAnnotations;
using Core.EF;

namespace WebUI.Models.PrinterModels
{
    public class CreateViewModel
    {
        [Display(Name = "Название")]
        public string Name { get; set; }

        [Display(Name = "Количество расходных материалов")]
        public int SuppliesCount { get; set; }

        [Display(Name = "Комментарий")]
        public string Comment { get; set; }

        public CreateViewModel()
        {
            SuppliesCount = 1;
        }
    }
}