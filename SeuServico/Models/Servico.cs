using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SeuServico.Models
{
    public class Servico
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public Decimal Custo { get; set; }

        public TipoServico Tipo { get; set; }
    }
}