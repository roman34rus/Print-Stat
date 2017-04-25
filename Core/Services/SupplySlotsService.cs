using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.EF;

namespace Core.Services
{
    public class SupplySlotsService : BaseService
    {
        public SupplySlot GetById(int id)
        {
            return context.SupplySlotSet.Find(id);
        }

        public Result Update(int id, int supplyId)
        {
            var supplySlot = context.SupplySlotSet.Find(id);
            
            if (supplySlot == null)
                return new Result("", string.Format("Слот для расходного материала Id = {0} не найден.", id));

            if (supplySlot.GetSupplyId() != supplyId)
            {
                if (supplySlot.Supply != null)
                    context.HistorySet.Add(new History(History.ActionCode.Remove, supplySlot.Printer, supplySlot.Supply));

                if (supplyId == 0)
                {
                    supplySlot.SupplyId = null;
                }
                else
                {
                    var supply = context.SupplySet.Find(supplyId);

                    if (supply == null)
                        return new Result("", string.Format("Расходный материал Id = {0} не найден.", supplyId));

                    supplySlot.SupplyId = supplyId;

                    context.HistorySet.Add(new History(History.ActionCode.Install, supplySlot.Printer, supply));
                }
            }

            return context.SaveChangesWithValidation();
        }
    }
}
