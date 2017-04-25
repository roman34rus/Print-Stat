using System;

namespace Core.EF
{
    public partial class History
    {
        public enum ActionCode
        {
            Install = 1,
            Remove = 2
        }

        public History()
        { }

        public History(ActionCode actionCode, Printer printer, Supply supply)
        {
            Date = DateTime.Now;
            Action = (int)actionCode;

            PrinterId = printer.Id;
            PrinterModel = printer.PrinterModel.Name;
            PrinterName = printer.Name;
            PrinterLocation = printer.Location;
            PrinterOwner = printer.Owner;
            PrinterComment = printer.Comment;

            SupplyId = supply.Id;
            SupplyPartNumber = supply.SupplyModel.PartNumber;
            SupplyName = supply.SupplyModel.Name;
            SupplyComment = supply.Comment;
        }
    }
}
