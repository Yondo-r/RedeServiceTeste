namespace TesteRedeservice.Services.Interfaces
{
    public interface IApiService
    {
        Task<string> ConsultaCorreio(string cep);
        Task<string> ConsultaBanco();
    }
}
