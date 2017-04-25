using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using Core.EF;

namespace WebUI.Models.Printers
{
    public class SuppliesViewModel
    {
        public string PrinterName { get; set; }

        public List<Item> Items { get; set; }

        public SuppliesViewModel(Printer printer)
        {
            PrinterName = printer.Name;

            Items = printer.SupplySlots.Select(x => new Item(x)).ToList();
        }

        public class Item
        {
            public int SupplySlotId { get; set; }

            public string SupplyName { get; set; }

            public Item(SupplySlot supplySlot)
            {
                SupplySlotId = supplySlot.Id;
                SupplyName = supplySlot.GetSupplyName();
            }
        }
    }
}