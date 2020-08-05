using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Financeiro.Model
{
    public class Titulo
    {
        [Key]
        public int TituloId { get; set; }
        [Required]
        public decimal ValorTotal { get; set; }
        [Required]
        public decimal ValorJuros { get; set; }
        [Required]
        public int QuantidadeParcelas { get; set; }
        [Required]
        public DateTime DataCompra { get; set; }
    }
}
