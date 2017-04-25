using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace Core.EF
{
    [MetadataType(typeof(SupplyMetadata))]
    public partial class Supply
    {
        public string GetFullName()
        {
            return Id + " " + SupplyModel.GetFullName();
        }

        /// <summary>
        ///  Возвращает имя принтера, в который установлен, или пустую строку.
        /// </summary>
        public string GetPrinterName()
        {
            var supplySlot = SupplySlots.FirstOrDefault();

            if (supplySlot == null)
                return "";
            else
                return supplySlot.Printer.Name;
        }

        /// <summary>
        /// Возвращает Id принтера, в который установлен, или 0.
        /// </summary>
        public int GetPrinterId()
        {
            var supplySlot = SupplySlots.FirstOrDefault();

            if (supplySlot == null)
                return 0;
            else
                return supplySlot.Printer.Id;
        }

        /// <summary>
        /// Возвращает Id слота, в который установлен, или 0.
        /// </summary>
        public int GetSupplySlotId()
        {
            var supplySlot = SupplySlots.FirstOrDefault();

            if (supplySlot == null)
                return 0;
            else
                return supplySlot.Id;
        }
    }
}
