using System.Collections.Generic;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebUI.Models.Supplies
{
    public class CreateViewModel
    {
        [Display(Name = "Модель")]
        public int ModelId { get; set; }

        [Display(Name = "Комментарий")]
        public string Comment { get; set; }

        public List<SelectListItem> AllSupplyModels { get; set; }
    }
}
