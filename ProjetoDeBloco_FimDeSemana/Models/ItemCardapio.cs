using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoDeBloco_FimDeSemana.Models
{
    public class ItemCardapio {
        [ForeignKey("CardapioId")]
        public int CardapioId { get; set; }
        [Key]
        public int Id { get; set; }
        public Cardapio Cardapio { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public double Preco { get; set; }
        public double ValorTotal { get; set; }
    }
}
