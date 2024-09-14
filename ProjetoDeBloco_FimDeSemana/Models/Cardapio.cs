using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoDeBloco_FimDeSemana.Models
{
    public class Cardapio {
        public List<ItemCardapio> ItensDoCardapio { get; set; }

        [ForeignKey("EventoId")]
        public int EventoId { get; set; }
        public Evento Evento { get; set; }
    }
}