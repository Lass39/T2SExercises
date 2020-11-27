using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using T2SExercises.Models;

namespace MvcContainer.Models
{
    public class Movimentacao
    {
        public int Id { get; set; }
        [Display(Name = "Codigo Container")]
        public int Containerid { get; set; }

        public virtual Container Container { get; set; }

        [Display(Name = "Nome Navio")]
        public int Navioid { get; set; }

        public virtual Navio Navio { get; set; }
        [Display(Name = "Tipo Movimentacao")]
        public int TipoMovimentacaoId { get; set; }

        public virtual TipoMovimentacao TipoMovimentacao { get; set; }
        [DataType(DataType.Date)]
        public DateTime DataInicio { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataFim { get; set; }




       // [Display(Name = "Nome Cliente")]
    //s        public string Nome_cliente { get; set; }


    }
}

