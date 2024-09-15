using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoDeBloco_FimDeSemana.Models
{
    public class ItemCardapio
    {
        [Key]
        public int Id { get; set; }

        // Relacionamento com Cardapio (Um ItemCardapio pertence a um Cardapio)
        public int CardapioId { get; set; }
        public Cardapio? Cardapio { get; set; }

        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public double Preco { get; set; }
        public double ValorTotal { get; set; }
    }
}
