using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.EF;

namespace Core.Services
{
    public class SuppliesService : BaseService
    {
        public List<Supply> GetAll()
        {
            return context.SupplySet.ToList();
        }

        public Supply GetById(int id)
        {
            return context.SupplySet.Find(id);
        }

        public List<Supply> GetCompatibleNotInUse(int printerModelId)
        {
            return context.SupplySet.Where(x => x.SupplyModel.PrinterModels.Any(y => y.Id == printerModelId && x.SupplySlots.Count == 0)).ToList();
        }

        public Result Add(int modelId, string comment)
        {
            var supply = new Supply()
            {
				ModelId = modelId,
                Comment = comment
            };

            context.SupplySet.Add(supply);

            return context.SaveChangesWithValidation();
        }

        public Result Update(int id, string comment)
        {
            var supply = context.SupplySet.Find(id);

            if (supply == null)
                return new Result("", string.Format("Расходный материал Id = {0} не найден.", id));

            supply.Comment = comment;

            return context.SaveChangesWithValidation();
        }

        public Result Delete(int id)
        {
            var supply = context.SupplySet.Find(id);

            if (supply == null)
                return new Result("", string.Format("Расходный материал Id = {0} не найден.", id));

            var supplySlot = supply.SupplySlots.FirstOrDefault();

            if (supplySlot != null)
                context.HistorySet.Add(new History(History.ActionCode.Remove, supplySlot.Printer, supply));

            context.SupplySet.Remove(supply);
            				
            return context.SaveChangesWithValidation();
        }
    }
}
