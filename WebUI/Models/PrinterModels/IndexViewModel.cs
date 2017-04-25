using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using Core.EF;

namespace WebUI.Models.PrinterModels
{
    public class IndexViewModel
    {
        public List<Item> Items { get; set; }

        public IndexViewModel(IEnumerable<PrinterModel> printerModels)
        {
            Items = printerModels.Select(x => new Item(x)).ToList();
        }

        public class Item
        {
            public int Id { get; set; }

            [Display(Name = "Название")]
            public string Name { get; set; }

            [Display(Name = "Количество расходных материалов")]
            public int SuppliesCount { get; set; }

            [Display(Name = "Комментарий")]
            public string Comment { get; set; }

            [Display(Name = "Количество принтеров")]
            public int PrintersCount { get; set; }

            public Item(PrinterModel printerModel)
            {
                Id = printerModel.Id;
                Name = printerModel.Name;
                SuppliesCount = printerModel.SuppliesCount;
                Comment = printerModel.Comment;
                PrintersCount = printerModel.Printers.Count();
            }
        }
    }
}