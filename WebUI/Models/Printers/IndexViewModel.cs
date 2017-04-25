using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using Core.EF;

namespace WebUI.Models.Printers
{
    public class IndexViewModel
    {
        public List<Item> Items { get; set; }

        public IndexViewModel(IEnumerable<Printer> printers)
        {
            Items = printers.Select(x => new Item(x)).ToList();
        }

        public class Item
        {
            public int Id { get; set; }

            [Display(Name = "Имя")]
            public string Name { get; set; }

            [Display(Name = "Модель")]
            public string Model { get; set; }

            [Display(Name = "Размещение")]
            public string Location { get; set; }

            [Display(Name = "Владелец")]
            public string Owner { get; set; }

            [Display(Name = "Комментарий")]
            public string Comment { get; set; }

            public Item(Printer printer)
            {
                Id = printer.Id;
                Name = printer.Name;
                Model = printer.PrinterModel.Name;
                Location = printer.Location;
                Owner = printer.Owner;
                Comment = printer.Comment;
            }
        }

    }
}