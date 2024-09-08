using System;

namespace ProjetoDeBloco_FimDeSemana.Models
{
    class EventoPerguntasRespostas {
        public string NomeDoUsuario { get; set; }
        public DateTime DataDaPergunta { get; set; }
        public string Pergunta { get; set; }
        public DateTime DataDaResposta { get; set; }
        public string Respota { get; set; }

        private void PostarPergunta (){}
    }
}
