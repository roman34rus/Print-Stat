using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.EF;

namespace Core.Services
{
    public class PrintersService : BaseService
    {
        public List<Printer> GetAll()
        {
            return context.PrinterSet.OrderBy(x => x.Name).ToList();
        }

        public Printer GetById(int id)
        {
            return context.PrinterSet.Find(id);
        }

        public Result Add(int modelId, string name, string location, string owner, string comment)
        {
            var printer = new Printer()
            {
				ModelId = modelId,
                Name = name,
                Location = location,
                Owner = owner,
                Comment = comment
            };

            context.PrinterSet.Add(printer);

            var printerModel = context.PrinterModelSet.Find(modelId);

            if (printerModel == null)
                return new Result("", string.Format("Модель принтера Id = {0} не найдена.", modelId));
            
            for (int i = 1; i <= printerModel.SuppliesCount; i++)
                printer.SupplySlots.Add(new SupplySlot()
                {
                    PrinterId = printer.Id,
                    SupplyId = null
                });

            return context.SaveChangesWithValidation();
        }

        public Result Update(int id, string name, string location, string owner, string comment)
        {
            var printer = context.PrinterSet.Find(id);

            if (printer == null)
                return new Result("", string.Format("Принтер Id = {0} не найден.", id));
            
            printer.Name = name;
            printer.Location = location;
            printer.Owner = owner;
            printer.Comment = comment;

            return context.SaveChangesWithValidation();
        }

        public Result Delete(int id)
        {
            var printer = context.PrinterSet.Find(id);

            if (printer == null)
                return new Result("", string.Format("Принтер Id = {0} не найден.", id));
            
            foreach (var supplySlot in printer.SupplySlots.ToList())
            {
                if (supplySlot.Supply != null)
                    context.HistorySet.Add(new History(History.ActionCode.Remove, printer, supplySlot.Supply));

                context.SupplySlotSet.Remove(supplySlot);
            }

            context.PrinterSet.Remove(printer);

            return context.SaveChangesWithValidation();
        }
    }
}
