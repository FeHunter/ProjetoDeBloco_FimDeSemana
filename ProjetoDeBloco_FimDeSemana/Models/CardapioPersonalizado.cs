using System;

namespace ProjetoDeBloco_FimDeSemana.Models
{
    public class CardapioPersonalizado : Cardapio {
        public int idDoUsuario { get; set; }
        public Cardapio CardapioDisponivel { get; set; }

        public void PersonalizarCardapio (){}
    }
}
