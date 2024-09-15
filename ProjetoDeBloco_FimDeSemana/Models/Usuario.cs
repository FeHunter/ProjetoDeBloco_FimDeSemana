namespace ProjetoDeBloco_FimDeSemana.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public string NomeDeUsuario { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public string Genero { get; set; }
        public Pagamentos? Pagamento { get; set; }
        public List<Evento>? Eventos { get; set; }

        public void PublicarAvaliacao() {}
    }
}
