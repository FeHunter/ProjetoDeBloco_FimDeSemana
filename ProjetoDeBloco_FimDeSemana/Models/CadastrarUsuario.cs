using System;

namespace ProjetoDeBloco_FimDeSemana.Models{
    class CadastrarUsuario {
        
        private string _IdDoUsuario;
        public string NomeCompleto {get; set;}
        public string Email {get; set;}
        public string Senha {get; set;}
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Genero {get; set;}

        public CadastrarUsuario(string idDoUsuario, string nomeCompleto, string email, string senha, string telefone, DateTime dataNascimento, string genero)
        {
            _IdDoUsuario = idDoUsuario;
            NomeCompleto = nomeCompleto;
            Email = email;
            Senha = senha;
            Telefone = telefone;
            DataNascimento = dataNascimento;
            Genero = genero;
        }

        public override string ToString()
        {
            return "\nNome Completo: " + NomeCompleto
            + "\nEmail: " + Email
            + "\nSenha: " + Senha 
            + "\nTelefone: " + Telefone
            + "\nData de Nascimento: " + DataNascimento
            + "\nGenêro: " + Genero;
        }

        public string FormatoParaSalvar (){
            return $"{_IdDoUsuario},{NomeCompleto},{Email},{Senha},{Telefone},{DataNascimento},{Genero}";
        }

    }
}