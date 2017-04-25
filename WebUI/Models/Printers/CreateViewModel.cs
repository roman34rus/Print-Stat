using System.Collections.Generic;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebUI.Models.Printers
{
    public class CreateViewModel
    {
        [Display(Name = "Модель")]
        public int ModelId { get; set; }

        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Display(Name = "Размещение")]
        public string Location { get; set; }

        [Display(Name = "Владелец")]
        public string Owner { get; set; }

        [Display(Name = "Комментарий")]
        public string Comment { get; set; }

        public List<SelectListItem> AllPrinterModels { get; set; }
    }
}