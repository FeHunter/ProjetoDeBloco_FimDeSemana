using System;

namespace FimDeSeProjetoDeBloco_FimDeSemana.Modelsmana
{
    class EventoAvaliacoes {
        public string NomeDoUsuario { get; set; }
        public DateTime DataDaPublicacao { get; set; }
        public string TextoAvaliacao { get; set; }
        public int AvaliacaoEstrelas { get; set; }
        // public File Fotos { get; set; }

        private bool ValidarForm (DateTime Data, string Avalicao, int Estrelas){
            return true;
        }
        private void PostarAvaliacao(DateTime Data, string Avalicao, int Estrelas){}
    }
}
