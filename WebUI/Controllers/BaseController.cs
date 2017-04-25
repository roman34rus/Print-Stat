using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Core.EF;
using Core.Services;

namespace WebUI.Controllers
{
    public class BaseController : Controller
    {
        protected PrinterModelsService printerModels = new PrinterModelsService();
        protected PrintersService printers = new PrintersService();
        protected SupplyModelsService supplyModels = new SupplyModelsService();
        protected SuppliesService supplies = new SuppliesService();
        protected SupplySlotsService supplySlots = new SupplySlotsService();
        protected HistoryService histories = new HistoryService();

        protected void AddModelStateErrors(Result result)
        {
            foreach (var error in result.Errors)
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
        }

        protected List<SelectListItem> PrinterModelsToSelectList(IEnumerable<PrinterModel> printerModels)
        {
            return printerModels.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();
        }

        protected List<SelectListItem> SupplyModelsToSelectList(IEnumerable<SupplyModel> supplyModels)
        {
            return supplyModels.Select(x => new SelectListItem()
            {
                Text = x.GetFullName(),
                Value = x.Id.ToString()
            }).ToList();
        }

        protected List<SelectListItem> SuppliesToSelectList(IEnumerable<Supply> supplies)
        {
            var list = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Text = "Не установлен",
                    Value = "0"
                }
            };

            list.AddRange(supplies.Select(x => new SelectListItem()
            {
                Text = x.GetFullName(),
                Value = x.Id.ToString()
            }).ToList());

            return list;
        }
    }
}