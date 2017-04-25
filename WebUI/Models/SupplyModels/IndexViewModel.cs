using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using Core.EF;

namespace WebUI.Models.SupplyModels
{
    public class IndexViewModel
    { 
        public List<Item> Items { get; set; }

        public IndexViewModel(IEnumerable<SupplyModel> supplyModels)
        {
            Items = supplyModels.Select(x => new Item(x)).ToList();
        }

        public class Item
        {
            public int Id { get; set; }

            [Display(Name = "Номер")]
            public string PartNumber { get; set; }

            [Display(Name = "Название")]
            public string Name { get; set; }

            [Display(Name = "Комментарий")]
            public string Comment { get; set; }

            [Display(Name = "Совместимые модели принтеров")]
            public List<string> CompatiblePrinterModels { get; set; }

            [Display(Name = "Количество расходных материалов")]
            public int SuppliesCount { get; set; }

            public Item(SupplyModel supplyModel)
            {
                Id = supplyModel.Id;
                PartNumber = supplyModel.PartNumber;
                Name = supplyModel.Name;
                Comment = supplyModel.Comment;
                CompatiblePrinterModels = supplyModel.PrinterModels.Select(x => x.Name).ToList();
                SuppliesCount = supplyModel.Supplies.Count();
            }
        }
    }
}