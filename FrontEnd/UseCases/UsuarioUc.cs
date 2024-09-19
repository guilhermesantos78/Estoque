using System.Net.Http.Json;
using System.Text.Json;

namespace FrontEnd.UseCases
{
    public class UsuarioUC
    {
        public async void ListarUsuario()
        {
            string apiURL = "https://localhost:7096/Usuario/listar-usuario";

            using HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(apiURL);
            string resposta = await response.Content.ReadAsStringAsync();
            List<Usuario> usu = JsonSerializer.Deserialize<List<Usuario>>(resposta);
            Console.ReadLine();
        }

        public void CadastrarUsuario(Usuario usuario)
        {
            string apiURL = "https://localhost:7096/Usuario/adicionar-usuario";
            using HttpClient client = new HttpClient();
            //string JsonRequest = JsonSerializer.Serialize(usuario);
            //HttpResponseMessage response = await client.PostAsync(apiURL);

        }

        public Usuario CreateUsuario()
        {
            Usuario usuario = new Usuario();
            Console.WriteLine("Digite seu nome");
            string nome = Console.ReadLine();
            Console.WriteLine("Digite seu username");
            string username = Console.ReadLine();
            Console.WriteLine("Digite sua senha");
            string senha = Console.ReadLine();
            Console.WriteLine("Digite email");
            string email = Console.ReadLine();

            usuario.nome = nome;
            usuario.username = username;
            usuario.senha = senha;
            usuario.email = email;

            return usuario;
        }
    }
}
