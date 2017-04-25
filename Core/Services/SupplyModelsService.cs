using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.EF;

namespace Core.Services
{
    public class SupplyModelsService : BaseService
    {
        public List<SupplyModel> GetAll()
        {
            return context.SupplyModelSet.OrderBy(x => x.PartNumber).ToList();
        }

        public SupplyModel GetById(int id)
        {
            return context.SupplyModelSet.Find(id);
        }

        public Result Add(string partNumber, string name, string comment, IEnumerable<int> printerModelIds)
        {
            var supplyModel = new SupplyModel()
            {
                PartNumber = partNumber,
                Name = name,
                Comment = comment
            };

            context.SupplyModelSet.Add(supplyModel);

            if (printerModelIds != null)
            {
                var printerModels = context.PrinterModelSet.Where(x => printerModelIds.Contains(x.Id)).ToList();

                printerModels.ForEach(x => supplyModel.PrinterModels.Add(x));
            }
            
            return context.SaveChangesWithValidation();
        }

        public Result Update(int id, string partNumber, string name, string comment, IEnumerable<int> printerModelIds)
        {
            var supplyModel = context.SupplyModelSet.Find(id);

            var result = new Result();

			if (supplyModel == null)
                return new Result("", string.Format("Модель расходного материала Id = {0} не найдена.", id));
            
            supplyModel.PartNumber = partNumber;
            supplyModel.Name = name;
            supplyModel.Comment = comment;

            if (printerModelIds != null)
            {
                var printerModels = context.PrinterModelSet.Where(x => printerModelIds.Contains(x.Id)).ToList();

                supplyModel.PrinterModels.ToList().ForEach(x => supplyModel.PrinterModels.Remove(x));

                printerModels.ForEach(x => supplyModel.PrinterModels.Add(x));
            }

            // Необходимо для валидации совместимых моделей принтеров.
            // Метод ValidateEntity не будет вызван, если изменяются только совместимые
            // модели принтеров т.к. они не относятся к сущности SupplyModel.
            context.Entry(supplyModel).State = System.Data.Entity.EntityState.Modified;

            return context.SaveChangesWithValidation();
        }

        public Result Delete(int id)
        {
            var supplyModel = context.SupplyModelSet.Find(id);

            if (supplyModel == null)
                return new Result("", string.Format("Модель расходного материала Id = {0} не найдена.", id));

            supplyModel.PrinterModels.ToList().ForEach(x => supplyModel.PrinterModels.Remove(x));

            context.SupplyModelSet.Remove(supplyModel);

            return context.SaveChangesWithValidation();
        }
    }
}
