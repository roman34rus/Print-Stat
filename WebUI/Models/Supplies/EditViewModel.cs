using Core.EF;
using System.ComponentModel.DataAnnotations;

namespace WebUI.Models.Supplies
{
    public class EditViewModel
    {
        public int Id { get; set; }
        
        [Display(Name = "Комментарий")]
        public string Comment { get; set; }

        public EditViewModel()
        { }

        public EditViewModel(Supply supply)
        {
            Id = supply.Id;
            Comment = supply.Comment;
        }
    }
}
