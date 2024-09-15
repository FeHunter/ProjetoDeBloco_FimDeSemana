using System;
using System.Collections.Generic;

namespace ProjetoDeBloco_FimDeSemana.Models
{
    public class Evento
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Endereco { get; set; }
        public DateTime DataDoEvento { get; set; }
        public double ValorTotal { get; set; }
        public string HorarioDeFuncionamento { get; set; }

        // Relacionamento com GerenciaReserva (Um GerenciaReserva pode ter vários eventos)
        public int? GerenciaReservaId { get; set; }
        public GerenciaReserva? GerenciaReserva { get; set; }

        // Relacionamento com Usuario (Um Usuario pode criar muitos eventos)
        public int? UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }

        // Relacionamento com Cardapio (Um Evento pode ter um Cardapio - Um para Um)
        public Cardapio? Cardapio { get; set; }

        // Relacionamento com CardapioPersonalizado (Um evento pode ter vários cardápios personalizados)
        public List<CardapioPersonalizado>? CardapiosPersonalizados { get; set; } = new List<CardapioPersonalizado>();

        public void DetalhesDoEvento() { }

        public void PersonalizarCardapio() { }

        public void FazerPergunta() { }

        public void FazerAvaliacao() { }
    }
}
