using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fortes111.Models
{
        [Table("Pedido")]
        public class Pedido {
        [Key]
            public DateTime dataPedido { get; set; }
            public int valorPedido { set; get; }
            public string Produto { get; set;}
            public int qtdeProduto { get; set; }
            public string Fornecedor { get; set; }
            public int pedidoId { get; set; }

        }
    }

