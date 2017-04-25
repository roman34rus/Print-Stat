using System.Collections.Generic;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebUI.Models.SupplyModels
{
    public class CreateViewModel
    {
        [Display(Name = "Номер")]
        public string PartNumber { get; set; }

        [Display(Name = "Название")]
        public string Name { get; set; }

        [Display(Name = "Комментарий")]
        public string Comment { get; set; }

        [Display(Name = "Совместимые модели принтеров")]
        public List<int> PrinterModelIds { get; set; }

        public List<SelectListItem> AllPrinterModels { get; set; }
    }
}