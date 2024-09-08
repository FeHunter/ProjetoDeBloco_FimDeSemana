using System;

namespace ProjetoDeBloco_FimDeSemana.Models
{
    class CardapioPersonalizado : Cardapio {
        public int idDoUsuario { get; set; }
        public Cardapio CardapioDisponivel { get; set; }

        public void PersonalizarCardapio (){}
    }
}
