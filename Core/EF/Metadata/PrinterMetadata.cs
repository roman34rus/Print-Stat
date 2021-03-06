﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Core.EF
{
    internal class PrinterMetadata
    {
        [Required(ErrorMessage = "Укажите значение.")]
        public int ModelId { get; set; }

        [Required(ErrorMessage = "Укажите значение.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Укажите значение.")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Укажите значение.")]
        public string Owner { get; set; }
    }
}
