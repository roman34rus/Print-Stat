using System.Net;
using System.Web.Mvc;
using WebUI.Models.Shared;
using WebUI.Models.PrinterModels;

namespace WebUI.Controllers
{
    public class PrinterModelsController : BaseController
    {
        // GET: PrinterModels
        public ActionResult Index()
        {
            var viewModel = new IndexViewModel(printerModels.GetAll());
            
            return View(viewModel);
        }
        
        // GET: PrinterModels/Create
        public ActionResult Create()
        {
            var viewModel = new CreateViewModel();

            return View(viewModel);
        }

        // POST: PrinterModels/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateViewModel viewModel)
        {
            var result = printerModels.Add(viewModel.Name, viewModel.SuppliesCount, viewModel.Comment);

            if (result.Success)
                return RedirectToAction("Index");
            else
                AddModelStateErrors(result);

            return View(viewModel);
        }

        // GET: PrinterModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var printerModel = printerModels.GetById((int)id);

            if (printerModel == null)
                return HttpNotFound();

            var viewModel = new EditViewModel(printerModel);
            
            return View(viewModel);
        }

        // POST: PrinterModels/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditViewModel viewModel)
        {
            var result = printerModels.Update(viewModel.Id, viewModel.Name, viewModel.Comment);

            if (result.Success)
                return RedirectToAction("Index");
            else
                AddModelStateErrors(result);

            return View(viewModel);
        }

        // GET: PrinterModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var printerModel = printerModels.GetById((int)id);

            if (printerModel == null)
                return HttpNotFound();

            var viewModel = new DeleteViewModel(printerModel.Id, printerModel.Name);

            return View(viewModel);
        }

        // POST: Printers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(DeleteViewModel viewModel)
        {
            var result = printerModels.Delete(viewModel.Id);

            if (result.Success)
                return RedirectToAction("Index");
            else
                AddModelStateErrors(result);

            return View(viewModel);
        }
    }
}
