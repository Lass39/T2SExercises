using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MvcContainer.Models
{
    public class CategoriaContainer
    {

        public int Id { get; set; }

        [Display(Name = "Categoria")]
        public string CategoriaName { get; set; }

    }
}
