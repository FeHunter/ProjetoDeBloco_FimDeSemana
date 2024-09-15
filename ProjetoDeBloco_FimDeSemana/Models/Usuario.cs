using System.ComponentModel.DataAnnotations;

namespace ProjetoDeBloco_FimDeSemana.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public string NomeDeUsuario { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public Pagamentos? Pagamento { get; set; }
        public ICollection<Evento>? Eventos { get; set; }

    }
}
