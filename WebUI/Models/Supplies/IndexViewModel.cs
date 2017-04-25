using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using Core.EF;

namespace WebUI.Models.Supplies
{
    public class IndexViewModel
    {
        public List<Item> Items { get; set; }

        public IndexViewModel(IEnumerable<Supply> supplies)
        {
            Items = supplies.Select(x => new Item(x)).ToList();
        }

        public class Item
        {
            [Display(Name = "Идентификатор")]
            public int Id { get; set; }

            [Display(Name = "Модель")]
            public string Model { get; set; }

            [Display(Name = "Установлен в принтер")]
            public string Printer { get; set; }

            [Display(Name = "Комментарий")]
            public string Comment { get; set; }

            public Item(Supply supply)
            {
                Id = supply.Id;
                Model = supply.SupplyModel.GetFullName();
                Printer = supply.GetPrinterName();
                Comment = supply.Comment;
            }
        }
    }
}
