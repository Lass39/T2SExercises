using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace MvcContainer.Models
{
    public class TipoContainer
    {
        public int Id { get; set; }

        [Display(Name = "Tipo Container")]
        public int Tipo_container { get; set; }


    }
}
