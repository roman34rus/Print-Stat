using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Core.EF;

namespace WebUI.Models.Supplies
{
    public class HistoryViewModel
    {
        public string SupplyName { get; set; }

        public List<Item> Items { get; set; }

        public HistoryViewModel(Supply supply, List<History> histories)
        {
            SupplyName = supply.GetFullName();

            Items = histories.Select(x => new Item(x)).ToList();
        }

        public class Item
        {
            [Display(Name = "Дата")]
            public System.DateTime Date { get; set; }

            [Display(Name = "Действие")]
            public string Action { get; set; }

            [Display(Name = "ID принтера")]
            public int PrinterId { get; set; }

            [Display(Name = "Модель принтера")]
            public string PrinterModel { get; set; }

            [Display(Name = "Имя принтера")]
            public string PrinterName { get; set; }

            [Display(Name = "Расположение принтера")]
            public string PrinterLocation { get; set; }

            [Display(Name = "Владелец принтера")]
            public string PrinterOwner { get; set; }

            [Display(Name = "Комментарий к принтеру")]
            public string PrinterComment { get; set; }

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

                PrinterId = history.PrinterId;
                PrinterModel = history.PrinterModel;
                PrinterName = history.PrinterName;
                PrinterLocation = history.PrinterLocation;
                PrinterOwner = history.PrinterOwner;
                PrinterComment = history.PrinterComment;
            }
        }
    }
}
