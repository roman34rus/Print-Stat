using Core.EF;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WebUI.Models.Printers
{
    public class EditViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Display(Name = "Размещение")]
        public string Location { get; set; }

        [Display(Name = "Владелец")]
        public string Owner { get; set; }

        [Display(Name = "Комментарий")]
        public string Comment { get; set; }

        public EditViewModel()
        { }

        public EditViewModel(Printer printer)
        {
            Id = printer.Id;
            Name = printer.Name;
            Location = printer.Location;
            Owner = printer.Owner;
            Comment = printer.Comment;
        }
    }
}