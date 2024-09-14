using System;
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
        public GerenciaReserva GerenciaReserva { get; set; }

        [ForeignKey("UsuarioId")]
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public Cardapio Cardapio { get; set; }
        public List<CardapioPersonalizado> CardapiosPersonalizados { get; set; } = new List<CardapioPersonalizado>();

        public void DetalhesDoEvento() {
        }

        public void PersonalizarCardapio() {
        }

        public void FazerPergunta() {
        }

        public void FazerAvaliacao() {
        }
    }
}
