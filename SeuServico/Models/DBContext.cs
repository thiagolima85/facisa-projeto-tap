using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SeuServico.Models
{
    public class DBContext : DbContext
    {

        public DBContext() : base("SeuServico")
        {

        }

        public System.Data.Entity.DbSet<SeuServico.Models.Pessoa> Pessoas { get; set; }

        public System.Data.Entity.DbSet<SeuServico.Models.TipoServico> TipoServicos { get; set; }

        public System.Data.Entity.DbSet<SeuServico.Models.Servico> Servicos { get; set; }
    }
}