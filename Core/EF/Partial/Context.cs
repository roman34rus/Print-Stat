using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.EF
{
    internal partial class Context
    {
        protected override bool ShouldValidateEntity(DbEntityEntry entityEntry)
        {
            if (entityEntry.State == EntityState.Deleted)
                return true;

            return base.ShouldValidateEntity(entityEntry);
        }

        protected override DbEntityValidationResult ValidateEntity(DbEntityEntry entityEntry, IDictionary<object, object> items)
        {
            var result = base.ValidateEntity(entityEntry, items);

            if (entityEntry.Entity is PrinterModel)
            {
                var printerModel = (PrinterModel)entityEntry.Entity;

                if (entityEntry.State == EntityState.Added || entityEntry.State == EntityState.Modified)
                {
                    if (PrinterModelSet.Any(x => x.Id != printerModel.Id && x.Name.ToLower() == printerModel.Name.ToLower()))
                        AddDBValidationError(result, "Name", "Значение должно быть уникальным.");
                }

                if (entityEntry.State == EntityState.Deleted)
                {
                    if (PrinterSet.Any(x => x.ModelId == printerModel.Id))
                        AddDBValidationError(result, "", String.Format("Перед удалением {0} нужно удалить все принтеры этой модели.", printerModel.Name));
                }
            }

            if (entityEntry.Entity is Printer)
            {
                var printer = (Printer)entityEntry.Entity;

                if (entityEntry.State == EntityState.Added || entityEntry.State == EntityState.Modified)
                {
                    if (PrinterSet.Any(x => x.Id != printer.Id && x.Name.ToLower() == printer.Name.ToLower()))
                        AddDBValidationError(result, "Name", "Значение должно быть уникальным.");
                }
            }

            if (entityEntry.Entity is SupplyModel)
            {
                var supplyModel = (SupplyModel)entityEntry.Entity;

                if (entityEntry.State == EntityState.Added || entityEntry.State == EntityState.Modified)
                {
                    if (SupplyModelSet.Any(x => x.Id != supplyModel.Id && x.PartNumber.ToLower() == supplyModel.PartNumber.ToLower()))
                        AddDBValidationError(result, "PartNumber", "Значение должно быть уникальным.");

                    if (supplyModel.PrinterModels.Count() < 1)
                        AddDBValidationError(result, "PrinterModelIds", "Нужно выбрать хотя бы одну совместимую модель принтера.");
                }

                if (entityEntry.State == EntityState.Modified)
                {
                    foreach (var supply in supplyModel.Supplies)
                        foreach (var supplySlot in supply.SupplySlots)
                            if (!supplyModel.PrinterModels.Contains(supplySlot.Printer.PrinterModel))
                                AddDBValidationError(result, "PrinterModelIds",
                                    string.Format("Требуется совместимость с {0}. В принтере {1} установлены расходные материалы этой модели.", supplySlot.Printer.PrinterModel.Name, supplySlot.Printer.Name));
                }

                if (entityEntry.State == EntityState.Deleted)
                {
                    if (SupplySet.Any(x => x.ModelId == supplyModel.Id))
                        AddDBValidationError(result, "", String.Format("Перед удалением {0} нужно удалить все расходные материалы этой модели.", supplyModel.GetFullName()));
                }
            }

            if (entityEntry.Entity is SupplySlot)
            {
                var supplySlot = (SupplySlot)entityEntry.Entity;

                if (entityEntry.State == EntityState.Modified)
                {
                    if (supplySlot.Supply != null)
                    {
                        if (!supplySlot.Printer.PrinterModel.SupplyModels.Contains(supplySlot.Supply.SupplyModel))
                            AddDBValidationError(result, "SupplyId", string.Format("Расходный материал {0} не совместим с принтером.", supplySlot.SupplyId));

                        if (supplySlot.Supply.SupplySlots.Count() > 1)
                            AddDBValidationError(result, "SupplyId", string.Format("Расходный материал {0} установлен в другой принтер.", supplySlot.SupplyId));
                    }
                }
            }

            return result; 
        }

        private void AddDBValidationError(DbEntityValidationResult result, string propertyName, string errorMessage)
        {
            result.ValidationErrors.Add(new DbValidationError(propertyName, errorMessage));
        }

        public Result SaveChangesWithValidation()
        {
            var result = new Result();

            try
            {
                SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var error in ex.EntityValidationErrors)
                    result.AddDBValidationErrors(error.ValidationErrors);
            }
            catch
            {
                result.AddCustomError("", "При сохранении изменений возникла ошибка.");
            }

            return result;
        }
    }
}
