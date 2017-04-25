using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Core.EF;

namespace WebUI.Models.Printers
{
    public class HistoryViewModel
    {
        public string PrinterName { get; set; }

        public List<Item> Items { get; set; }

        public HistoryViewModel(Printer printer, List<History> histories)
        {
            PrinterName = printer.Name;

            Items = histories.Select(x => new Item(x)).ToList();
        }

        public class Item
        {
            [Display(Name = "Дата")]
            public System.DateTime Date { get; set; }

            [Display(Name = "Действие")]
            public string Action { get; set; }

            [Display(Name = "ID расходного материала")]
            public int SupplyId { get; set; }

            [Display(Name = "Номер расходного материала")]
            public string SupplyPartNumber { get; set; }

            [Display(Name = "Название расходного материала")]
            public string SupplyName { get; set; }

            [Display(Name = "Комментарий к расходному материалу")]
            public string SupplyComment { get; set; }

            public Item(History history)
            {
                Date = history.Date;
                
                switch (history.Action)
                {
                    case (int)History.ActionCode.Install:
                        Action = "Установлен";
                        break;

                    case (int)History.ActionCode.Remove:
                        Action = "Снят";
                        break;
                }

                SupplyId = history.SupplyId;
                SupplyPartNumber = history.SupplyPartNumber;
                SupplyName = history.SupplyName;
                SupplyComment = history.SupplyComment;
            }
        }
    }
}