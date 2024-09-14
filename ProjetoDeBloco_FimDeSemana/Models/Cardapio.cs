using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoDeBloco_FimDeSemana.Models
{
    public class Cardapio
    {
        public int Id { get; set; }
        public List<ItemCardapio> ItensDoCardapio { get; set; } = new List<ItemCardapio>();

        [ForeignKey("EventoId")]
        public int? EventoId { get; set; }
        public Evento Evento { get; set; }
    }
}
