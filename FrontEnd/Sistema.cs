using FrontEnd.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd
{
    public class Sistema
    {
        UsuarioUC usuario = new UsuarioUC();

        public void IniciarSistema()
        {
            int resposta = ExibirLogin();

            if (resposta == 0)
            {
                return;
            }
            if (resposta == 1)
            {
                //Login
            }
            if (resposta == 2)
            {
                Usuario createdUsuario = usuario.CreateUsuario();

                usuario.CadastrarUsuario(createdUsuario);
            }

        }
        public int ExibirLogin()
        {
            Console.WriteLine("---------- Login ----------");
            Console.WriteLine("1- Deseja Fazer Login");
            Console.WriteLine("2- Deseja Se cadastrar");
            Console.WriteLine("0- Sair");
            return int.Parse(Console.ReadLine());

        }
        public void Cadastrar()
        {

        }

    }
}

