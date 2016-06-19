using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QManager.Models
{
    public class Usuario
    {
        public int ID { get; set; }

        public string Nome { get; set; }

        public string QuantidadePessoas { get; set; }

        public string DataHoraChegada { get; set; }
    }
}