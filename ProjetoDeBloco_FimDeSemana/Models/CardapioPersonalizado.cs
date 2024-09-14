using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoDeBloco_FimDeSemana.Models
{
    public class CardapioPersonalizado
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public Cardapio CardapioDisponivel { get; set; }
        public int EventoId { get; set; }
        public Evento Evento { get; set; }
    }
}
