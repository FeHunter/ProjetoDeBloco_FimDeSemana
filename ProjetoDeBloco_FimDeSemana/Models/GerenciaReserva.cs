using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoDeBloco_FimDeSemana.Models
{
    public class GerenciaReserva
    {
        [Key]
        public int Id { get; set; }

        // Relacionamento com Usuario (Um usuário pode ter várias reservas)
        [ForeignKey("UsuarioId")]
        public int? UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public List<Evento> Eventos { get; set; } = new List<Evento>();

        public void CustomizarEvento(int id)
        {
        }

        public void RemoverEvento(int id)
        {
        }

        public void ReservaEvento(int id)
        {
        }
    }
}
