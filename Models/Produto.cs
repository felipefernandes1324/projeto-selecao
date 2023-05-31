using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fortes111.Models
{
    [Table("Produto")]
    public class Produto
    {
    [Key]
        public int produtoId { get; set; }
        public string produtoDesc { get; set; }
        public DateTime cadastroProduto { get; set; }
        public int valorProduto { get; set;}

    }
}
