using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.EF;

namespace Core.Services
{
    public class PrinterModelsService : BaseService
    {
        public List<PrinterModel> GetAll()
        {
            return context.PrinterModelSet.OrderBy(x => x.Name).ToList();
        }

        public PrinterModel GetById(int id)
        {
            return context.PrinterModelSet.Find(id);
        }

        public Result Add(string name, int suppliesCount, string comment)
        {
            var printerModel = new PrinterModel()
            {
                Name = name,
                SuppliesCount = suppliesCount,
                Comment = comment
            };

            context.PrinterModelSet.Add(printerModel);

            return context.SaveChangesWithValidation();
        }

        public Result Update(int id, string name, string comment)
        {            
            var printerModel = context.PrinterModelSet.Find(id);

            if (printerModel == null)
                return new Result("", string.Format("Модель принтера Id = {0} не найдена.", id));
            
            printerModel.Name = name;
            printerModel.Comment = comment;
            
            return context.SaveChangesWithValidation();
        }

        public Result Delete(int id)
        {
            var printerModel = context.PrinterModelSet.Find(id);

            if (printerModel == null)
                return new Result("", string.Format("Модель принтера Id = {0} не найдена.", id));

            printerModel.SupplyModels.ToList().ForEach(x => printerModel.SupplyModels.Remove(x));

            context.PrinterModelSet.Remove(printerModel);

            return context.SaveChangesWithValidation();
        }
    }
}
