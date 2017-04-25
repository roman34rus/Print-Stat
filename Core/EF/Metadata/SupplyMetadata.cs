using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Core.EF
{
    internal class SupplyMetadata
    {
        [Required(ErrorMessage = "Укажите значение.")]
        public int ModelId { get; set; }
    }
}
