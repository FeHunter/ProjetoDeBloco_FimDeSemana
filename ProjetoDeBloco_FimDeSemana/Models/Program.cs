using System;

namespace ProjetoDeBloco_FimDeSemana.Models
{
    class Program {
        static void Main (){
            Console.WriteLine("TP3 - Projeto de Bloco (Fim de Semana) \nCadastrar Usuários na plataforma");
            string path = "DadosDeCadastro.csv";
            List<CadastrarUsuario> usuarios = CarregarArquivoCSV(path);

            // Adicionar Usuários
            int count = usuarios.Count > 0 ? usuarios.Count : 0;
            int end = 1;
            do {
                Console.WriteLine("[1] Inserir Usuário | [2] Finalizar");
                end = int.Parse(Console.ReadLine());
                if (end == 1){
                    usuarios.Add(PreencherDadosDoUsuario());
                    count ++;
                }
            }
            while (end == 1);

            // Gravar dados no csv
            GravarArquivoCSV(path, usuarios);

            // Fazer Login
            FazerLogin(usuarios);
        }

        static CadastrarUsuario PreencherDadosDoUsuario (){
            Console.Write("\nNome do Usuário: ");
            string nomeCompleto = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Senha: ");
            string senha = Console.ReadLine();
            Console.Write("Telefone: ");
            string telefone = Console.ReadLine();
            Console.Write("Data de Nascimento: ");
            DateTime dataNascimento = DateTime.Parse(Console.ReadLine());
            Console.Write("Genêro: ");
            string genero = Console.ReadLine();
            string idUsuario = nomeCompleto+email+dataNascimento;
            return new CadastrarUsuario(idUsuario, nomeCompleto, email, senha, telefone, dataNascimento, genero);
        }

        static void FazerLogin (List<CadastrarUsuario> users){
            Console.WriteLine("Fazer Login");
            Console.Write("\nEmail: ");
            string email = Console.ReadLine();
            Console.Write("Senha: ");
            string senha = Console.ReadLine();
            int logando = 1;
            do {
                foreach (CadastrarUsuario user in users){
                if (email == user.Email && senha == user.Senha){
                    Console.Clear();
                    Console.WriteLine("Logado com sucesso!");
                    break;
                }else {
                    Console.WriteLine("Dados incorretos \n[1] Tentar Novamente | [2] Sair");
                    logando = int.Parse(Console.ReadLine());
                }
            }
            }while (logando == 0);
        }
    
        static void GravarArquivoCSV (string path, List<CadastrarUsuario> usuarios){
            using (StreamWriter sw = new StreamWriter(path)){
                try {
                    foreach (CadastrarUsuario user in usuarios){
                        sw.WriteLine(user.FormatoParaSalvar());
                    }
                    Console.WriteLine("Salvo com Sucesso!");
                }
                catch (Exception e){
                    Console.WriteLine("Erro ao Salvar: " + e.Message);
                }
            }
        }
    
        static List<CadastrarUsuario> CarregarArquivoCSV (string path){
            List<CadastrarUsuario> loadUsuarios = new List<CadastrarUsuario>();
            using (StreamReader sr = new StreamReader(path)){
                try {
                    string lerDados;
                    while((lerDados = sr.ReadLine()) != null){
                        string[] dados = lerDados.Split(',');
                        string idDoUsuario = dados[0];
                        string nomeCompleto = dados[1];
                        string email = dados[2];
                        string senha = dados[3];
                        string telefone = dados[4];
                        DateTime dataNascimento = DateTime.Parse(dados[5]);
                        string genero = dados[6];
                        loadUsuarios.Add(new CadastrarUsuario(idDoUsuario, nomeCompleto, email, senha, telefone, dataNascimento, genero));
                    }
                }
                catch (Exception e){
                    Console.WriteLine("Erro ao carregar dados: " + e.Message);
                }
            }
            return loadUsuarios;
        }
    }
}