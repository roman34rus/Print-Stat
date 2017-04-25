using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Core.EF
{
    internal class PrinterModelMetadata
    {
        [Required(ErrorMessage = "Укажите значение.")]
        public string Name { get; set; }

        [Range(1, 10, ErrorMessage = "Укажите значение от 1 до 10.")]
        public int SuppliesCount { get; set; }
    }
}
