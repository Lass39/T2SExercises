using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MvcContainer.Models
{
    public class TipoMovimentacao
    {
        public int Id { get; set; }

        [Display(Name = "Tipo Movimentacao")]
        public string Tipo_movimentacao { get; set; }
    }
}
