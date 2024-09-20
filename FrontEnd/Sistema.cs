using FrontEnd.UseCases;

namespace FrontEnd
{
    public class Sistema
    {
        private readonly UsuarioUC _usuariouc;

        public Sistema(HttpClient cliente)
        {
            _usuariouc = new UsuarioUC(cliente);
        }
        public void IniciarSistema()
        {
            int resposta = -1;

            while (resposta != 0)
            {
                resposta = ExibirLogin();

                if (resposta == 0)
                {
                    return;
                }
                else if (resposta == 1)
                {
                    _usuariouc.ListarUsuario();
                }
                else if (resposta == 2)
                {
                    Usuario createdUsuario = _usuariouc.CreateUsuario();

                    _usuariouc.CadastrarUsuario(createdUsuario);

                    Console.WriteLine("Usuario cadastrado com sucesso!!");
                }
                else if (resposta == 3)
                {
                    List<Usuario> usuarios = _usuariouc.ListarUsuario();

                    foreach (Usuario u in usuarios)
                    {
                        Console.WriteLine(u.ToString());
                        Console.WriteLine("---------");
                    }
                }
            }


        }
        public int ExibirLogin()
        {
            Console.WriteLine("---------- Login ----------");
            Console.WriteLine("1- Deseja Fazer Login");
            Console.WriteLine("2- Deseja Se cadastrar");
            Console.WriteLine("3- Listar usuarios cadastrados");
            Console.WriteLine("0- Sair");
            return int.Parse(Console.ReadLine());

        }
        public void Cadastrar()
        {

        }

    }
}
