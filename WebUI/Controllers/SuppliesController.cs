using System.Web.Mvc;
using System.Net;
using WebUI.Models.Shared;
using WebUI.Models.Supplies;

namespace WebUI.Controllers
{
    public class SuppliesController : BaseController
    {
        // GET: Supplies
        public ActionResult Index()
        {
            var viewModel = new IndexViewModel(supplies.GetAll());
            
			return View(viewModel);
        }

        // GET: Supplies/Create
        public ActionResult Create()
        {
            var viewModel = new CreateViewModel();

            viewModel.AllSupplyModels = SupplyModelsToSelectList(supplyModels.GetAll());

            return View(viewModel);
        }

        // POST: Supplies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateViewModel viewModel)
        {
            var result = supplies.Add(viewModel.ModelId, viewModel.Comment);

            if (result.Success)
                return RedirectToAction("Index");
            else
                AddModelStateErrors(result);

            viewModel.AllSupplyModels = SupplyModelsToSelectList(supplyModels.GetAll());

            return View(viewModel);
        }
        
        // GET: Supplies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var supply = supplies.GetById((int)id);

            if (supply == null)
                return HttpNotFound();

            var viewModel = new EditViewModel(supply);

            return View(viewModel);
        }
        
        // POST: Supplies/Edit/5
        [HttpPost]
        public ActionResult Edit(EditViewModel viewModel)
        {
            var result = supplies.Update(viewModel.Id, viewModel.Comment);

            if (result.Success)
                return RedirectToAction("Index");
            else
                AddModelStateErrors(result);

            return View(viewModel);
        }

        // GET: Supplies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var supply = supplies.GetById((int)id);

            if (supply == null)
                return HttpNotFound();

            var viewModel = new DeleteViewModel(supply.Id, supply.GetFullName());

            return View(viewModel);
        }

        // POST: Supplies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(DeleteViewModel viewModel)
        {
            var result = supplies.Delete(viewModel.Id);

            if (result.Success)
                return RedirectToAction("Index");
            else
                AddModelStateErrors(result);

            return View(viewModel);
        }

        // GET: Supplies/History/5
        public ActionResult History(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var supply = supplies.GetById((int)id);

            if (supply == null)
                return HttpNotFound();

            var viewModel = new HistoryViewModel(supply, histories.GetBySupplyId(supply.Id));

            return View(viewModel);
        }
    }
}
