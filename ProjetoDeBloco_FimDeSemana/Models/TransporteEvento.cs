using System;

namespace ProjetoDeBloco_FimDeSemana.Models
{
    class TransporteEvento {
        public string EnderecoDoUsuário { get; set; }
        public string EnderecoDoEvento { get; set; }
        public string TipoDeTransporte { get; set; }
        public double TempoEstimado { get; set; }
        public string TransportePorAplicativo { get; set; }

        private void CalcularTempoEstimado(){}
        private void  ChamarTransportePorApp(string TransportePorAplicativo){}
    }
}
