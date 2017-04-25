using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Core.EF
{
    internal class SupplyModelMetadata
    {
        [Required(ErrorMessage = "Укажите значение.")]
        public string PartNumber { get; set; }

        [Required(ErrorMessage = "Укажите значение.")]
        public string Name { get; set; }
    }
}
