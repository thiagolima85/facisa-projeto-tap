using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SeuServico.Models
{
    public class TipoServico
    {
        public int Id { get; set; }

        public string Tipo { get; set; }
    }
}