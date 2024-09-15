using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoDeBloco_FimDeSemana.Models
{
    public class Cardapio
    {
        [Key]
        public int Id { get; set; }
        public List<ItemCardapio> ItensDoCardapio { get; set; } = new List<ItemCardapio>();

        // Relacionamento com Evento (Um Cardapio pertence a um Evento)
        [ForeignKey("EventoId")]
        public int EventoId { get; set; }
        public Evento? Evento { get; set; }
    }
}
