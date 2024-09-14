using System;

namespace ProjetoDeBloco_FimDeSemana.Models
{
    public class GerenciaReserva {
        private int idDoUsuario;
        public List<Evento> Eventos { get; set; }

        public void CustomizarEvento (int id){}
        public void RemoverEvento(int id){}
        public void ReservaEvento(int id){}
    }
}