using System.Net.Http.Json;
using System.Text.Json;

namespace FrontEnd.UseCases
{
    public class UsuarioUC
    {
        private readonly HttpClient _Cliente;
        public UsuarioUC(HttpClient cliente)
        {
            _Cliente = cliente;
        }
        public List<Usuario> ListarUsuario()
        {
            return _Cliente.GetFromJsonAsync<List<Usuario>>("Usuario/listar-usuario").Result;

        }

        public void CadastrarUsuario(Usuario usuario)
        {
            HttpResponseMessage response = _Cliente.PostAsJsonAsync("Usuario/adicionar-usuario", usuario).Result;
        }

        public Usuario CreateUsuario()
        {
            Usuario usuario = new Usuario();
            Console.WriteLine("Digite seu nome: ");
            usuario.Nome = Console.ReadLine();
            Console.WriteLine("Digite seu username: ");
            usuario.Username = Console.ReadLine();
            Console.WriteLine("Digite sua senha: ");
            usuario.Senha = Console.ReadLine();
            Console.WriteLine("Digite email: ");
            usuario.Email = Console.ReadLine();

            return usuario;
        }
    }
}
