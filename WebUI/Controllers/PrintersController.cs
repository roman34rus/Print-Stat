using System.Net;
using System.Web;
using System.Web.Mvc;
using WebUI.Models.Shared;
using WebUI.Models.Printers;

namespace WebUI.Controllers
{
    public class PrintersController : BaseController
    {
        // GET: Printers
        public ActionResult Index()
        {
            var viewModel = new IndexViewModel(printers.GetAll());

            return View(viewModel);
        }

        // GET: Printers/Create
        public ActionResult Create()
        {
            var viewModel = new CreateViewModel();

            viewModel.AllPrinterModels = PrinterModelsToSelectList(printerModels.GetAll());
            
            return View(viewModel);
        }

        // POST: Printers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateViewModel viewModel)
        {
            var result = printers.Add(viewModel.ModelId, viewModel.Name, viewModel.Location, viewModel.Owner, viewModel.Comment);

            if (result.Success)
                return RedirectToAction("Index");
            else
                AddModelStateErrors(result);

            viewModel.AllPrinterModels = PrinterModelsToSelectList(printerModels.GetAll());

            return View(viewModel);
        }

        // GET: Printers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var printer = printers.GetById((int)id);

            if (printer == null)
                return HttpNotFound();

            var viewModel = new EditViewModel(printer);

            return View(viewModel);
        }

        // POST: Printers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditViewModel viewModel)
        {
            var result = printers.Update(viewModel.Id, viewModel.Name, viewModel.Location, viewModel.Owner, viewModel.Comment);

            if (result.Success)
                return RedirectToAction("Index");
            else
                AddModelStateErrors(result);

            return View(viewModel);
        }

        // GET: Printers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var printer = printers.GetById((int)id);

            if (printer == null)
                return HttpNotFound();

            var viewModel = new DeleteViewModel(printer.Id, printer.Name);

            return View(viewModel);
        }

        // POST: Printers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(DeleteViewModel viewModel)
        {
            var result = printers.Delete(viewModel.Id);

            if (result.Success)
                return RedirectToAction("Index");
            else
                AddModelStateErrors(result);

            return View(viewModel);
        }
        	
        // GET: Printers/Supplies/5
        public ActionResult Supplies(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var printer = printers.GetById((int)id);

            if (printer == null)
                return HttpNotFound();

            var viewModel = new SuppliesViewModel(printer);

            return View(viewModel);
        }

        // GET: Printers/SetSupply/5
        public ActionResult SetSupply(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var supplySlot = supplySlots.GetById((int)id);

            if (supplySlot == null)
                return HttpNotFound();

            var viewModel = new SetSupplyViewModel(supplySlot);

            viewModel.CompatibleSupplies = SuppliesToSelectList(supplies.GetCompatibleNotInUse(viewModel.PrinterModelId));

            return View(viewModel);
        }

        // POST: Printers/SetSupply/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SetSupply(SetSupplyViewModel viewModel)
        {
            var result = supplySlots.Update(viewModel.SupplySlotId, viewModel.SupplyId);

            if (result.Success)
                return RedirectToAction("Supplies", new { id = viewModel.PrinterId });
            else
                AddModelStateErrors(result);

            viewModel.CompatibleSupplies = SuppliesToSelectList(supplies.GetCompatibleNotInUse(viewModel.PrinterModelId));

            return View(viewModel);
        }

        // GET: Printers/History/5
        public ActionResult History(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var printer = printers.GetById((int)id);

            if (printer == null)
                return HttpNotFound();

            var viewModel = new HistoryViewModel(printer, histories.GetByPrinterId(printer.Id));

            return View(viewModel);
        }
    }
}