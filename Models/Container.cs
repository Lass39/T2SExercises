using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using T2SExercises.Models;

namespace MvcContainer.Models
    { 
        public class Container
        {
            public int Id { get; set; }
        [Display(Name = "Nome Cliente")]
        public int ClientId { get; set; }
            public virtual Client Client { get; set; }

        [Display(Name = "Codigo Controle")]
        public string Nmr_control { get; set; }
        [Display(Name = "Tipo Container")]
        public int TipoContainerId { get; set; }
            public virtual TipoContainer TipoContainer { get; set; }
        [Display(Name = "Status")]
        public int StatusContainerId { get; set; }

            public virtual StatusContainer StatusContainer { get; set; }
        [Display(Name = "Categoria")]
        public int CategoriaContainerId { get; set; }
            public virtual CategoriaContainer CategoriaContainer { get; set; }


    }
    }

