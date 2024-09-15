using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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
        [ForeignKey("GerenciaReservaId")]
        public int? GerenciaReservaId { get; set; }
        public GerenciaReserva GerenciaReserva { get; set; }

        // Relacionamento com Usuario (Um Usuario pode criar muitos eventos)
        [ForeignKey("UsuarioId")]
        public int? UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public Cardapio Cardapio { get; set; }

        public List<CardapioPersonalizado> CardapiosPersonalizados { get; set; } = new List<CardapioPersonalizado>();

        public void DetalhesDoEvento()
        {
        }

        public void PersonalizarCardapio()
        {
        }

        public void FazerPergunta()
        {
        }

        public void FazerAvaliacao()
        {
        }
    }
}
