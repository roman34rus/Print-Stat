using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Core.EF;

namespace WebUI.Models.SupplyModels
{
    public class EditViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Номер")]
        public string PartNumber { get; set; }

        [Display(Name = "Название")]
        public string Name { get; set; }

        [Display(Name = "Комментарий")]
        public string Comment { get; set; }

        [Display(Name = "Совместимые модели принтеров")]
        public List<int> PrinterModelIds { get; set; }

        public List<SelectListItem> AllPrinterModels { get; set; }

        public EditViewModel()
        { }

        public EditViewModel(SupplyModel supplyModel)
        {
            Id = supplyModel.Id;
            PartNumber = supplyModel.PartNumber;
            Name = supplyModel.Name;
            Comment = supplyModel.Comment;
            PrinterModelIds = supplyModel.PrinterModels.Select(x => x.Id).ToList();
        }
    }
}