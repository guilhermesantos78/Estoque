namespace FrontEnd
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Username { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public override string ToString()
        {
            return $"Id: {Id}, Nome: {Nome}, Username: {Username}, Email: {Email}";
        }

    }
}
