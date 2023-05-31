using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fortes111.Models
{
        [Table("Fornecedor")]
        public class Fornecedor
        {
        [Key]
            public int fornecedorCNPJ {get; set;}
            public string fornecedorRazao { get; set;}
            public string fornecedorUf { get; set;}
            public string fornecedorEmail { get; set;}
            public string fornecedorContato { get; set;}    

        }
    }
