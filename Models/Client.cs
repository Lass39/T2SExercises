using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;




namespace MvcContainer.Models
{
    public class Client
    {
        public int Id { get; set; }
       
        [Display(Name = "Nome Cliente")]
        public string Nome_cliente { get; set; }
      

    }
}

