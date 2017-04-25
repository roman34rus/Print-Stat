using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.EF;

namespace WebUI.Models.Printers
{
    public class SetSupplyViewModel
    {
        public int SupplySlotId { get; set; }

        public int SupplyId { get; set; }

        public int PrinterModelId { get; set; }

        public int PrinterId { get; set; }

        public List<SelectListItem> CompatibleSupplies { get; set; }

        public SetSupplyViewModel()
        { }

        public SetSupplyViewModel(SupplySlot supplySlot)
        {
            SupplySlotId = supplySlot.Id;
            SupplyId = supplySlot.GetSupplyId();
            PrinterModelId = supplySlot.Printer.ModelId;
            PrinterId = supplySlot.PrinterId;
        }
    }
}