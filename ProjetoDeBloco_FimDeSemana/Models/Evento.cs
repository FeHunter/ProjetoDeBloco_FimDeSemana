using System;

namespace ProjetoDeBloco_FimDeSemana.Models
{
    class Evento {
        private int idDoUsuario;
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Endereco { get; set; }
        public DateTime DataDoEvento { get; set; }
        public double ValorTotal { get; set; }
        public string HorarioDeFuncionamento { get; set; }
        public GerenciaReserva GerenciaReserva { get; set; }
        // public Cardapio Cardapio { get; set; }
        // public PerguntasRespostas PerguntasRespostas { get; set; }
        // public Avaliacao Avaliacao { get; set; }
        // public TransporteEvento TransporteEvento { get; set; }

        private void RealizarReserva(){}
        public void DetalhesDoEvento(){}
        public void PersonalizarCardapio(int idUser, Evento evento){}
        public void FazerPergunta(){}
        public void FazerAvaliação(){}
    }
}

