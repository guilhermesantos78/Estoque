﻿namespace Core.Entidades
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Username { get; set; }
        public string TipoUsuario { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public int EmpresaId { get; set; }
    }
}