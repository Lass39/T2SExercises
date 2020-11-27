using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MvcContainer.Models
{
    public class StatusContainer
    {
        public int Id { get; set; }

        [Display(Name = "Status")]
        public string Status_name { get; set; }



    }
}
