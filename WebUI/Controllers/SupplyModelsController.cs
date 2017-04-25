using System.Net;
using System.Web.Mvc;
using WebUI.Models.Shared;
using WebUI.Models.SupplyModels;

namespace WebUI.Controllers
{
    public class SupplyModelsController : BaseController
    {
        // GET: SupplyModels
        public ActionResult Index()
        {
            var viewModel = new IndexViewModel(supplyModels.GetAll());

            return View(viewModel);
        }
        
        // GET: SupplyModels/Create
        public ActionResult Create()
        {
            var viewModel = new CreateViewModel();

            viewModel.AllPrinterModels = PrinterModelsToSelectList(printerModels.GetAll());

            return View(viewModel);
        }

        // POST: SupplyModels/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateViewModel viewModel)
        {
            var result = supplyModels.Add(viewModel.PartNumber, viewModel.Name, viewModel.Comment, viewModel.PrinterModelIds);

            if (result.Success)
                return RedirectToAction("Index");
            else
                AddModelStateErrors(result);

            viewModel.AllPrinterModels = PrinterModelsToSelectList(printerModels.GetAll());

            return View(viewModel);
        }

        // GET: SupplyModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var supplyModel = supplyModels.GetById((int)id);

            if (supplyModel == null)
                return HttpNotFound();

            var viewModel = new EditViewModel(supplyModel);

            viewModel.AllPrinterModels = PrinterModelsToSelectList(printerModels.GetAll());

            return View(viewModel);
        }

        // POST: SupplyModels/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditViewModel viewModel)
        {
            var result = supplyModels.Update(viewModel.Id, viewModel.PartNumber, viewModel.Name, viewModel.Comment, viewModel.PrinterModelIds);

            if (result.Success)
                return RedirectToAction("Index");
            else
                AddModelStateErrors(result);

            viewModel.AllPrinterModels = PrinterModelsToSelectList(printerModels.GetAll());

            return View(viewModel);
        }

        // GET: SupplyModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var supplyModel = supplyModels.GetById((int)id);

            if (supplyModel == null)
                return HttpNotFound();

            var viewModel = new DeleteViewModel(supplyModel.Id, supplyModel.GetFullName());

            return View(viewModel);
        }

        // POST: SupplyModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(DeleteViewModel viewModel)
        {
            var result = supplyModels.Delete(viewModel.Id);

            if (result.Success)
                return RedirectToAction("Index");
            else
                AddModelStateErrors(result);

            return View(viewModel);
        }
    }
}