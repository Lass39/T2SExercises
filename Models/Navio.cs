using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;




namespace MvcContainer.Models
{
    public class Navio
    {
        public int Id { get; set; }

        [Display(Name = "Nome Navio")]
        public string Nome_navio { get; set; }


    }
}

