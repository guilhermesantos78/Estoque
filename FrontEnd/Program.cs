using FrontEnd;

HttpClient cliente = new HttpClient
{
    BaseAddress = new Uri("https://localhost:7096/")
};

Sistema sistem = new Sistema(cliente);
sistem.IniciarSistema();