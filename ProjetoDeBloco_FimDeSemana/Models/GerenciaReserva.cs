using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjetoDeBloco_FimDeSemana.Models
{
    public class GerenciaReserva
    {
        [Key]
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public List<Evento> Eventos { get; set; } = new List<Evento>();

        public void CustomizarEvento(int id) { }
        public void RemoverEvento(int id) { }
        public void ReservaEvento(int id) { }
    }
}
