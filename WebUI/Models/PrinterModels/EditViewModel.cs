using System.ComponentModel.DataAnnotations;
using Core.EF;

namespace WebUI.Models.PrinterModels
{
    public class EditViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Название")]
        public string Name { get; set; }

        [Display(Name = "Количество расходных материалов")]
        public int SuppliesCount { get; set; }

        [Display(Name = "Комментарий")]
        public string Comment { get; set; }

        public EditViewModel()
        { }

        public EditViewModel(PrinterModel printerModel)
        {
            Id = printerModel.Id;
            Name = printerModel.Name;
            SuppliesCount = printerModel.SuppliesCount;
            Comment = printerModel.Comment;
        }
    }
}