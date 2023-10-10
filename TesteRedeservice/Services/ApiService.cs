using TesteRedeservice.Services.Interfaces;

namespace TesteRedeservice.Services
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> ConsultaCorreio(string cep)
        {
            string endereco = "";
            if (!string.IsNullOrEmpty(cep))
            {
                string url = $"https://viacep.com.br/ws/{cep}/json/";
                HttpResponseMessage responseMessage = await _httpClient.GetAsync(url);

                if (responseMessage.IsSuccessStatusCode)
                {
                    endereco = await responseMessage.Content.ReadAsStringAsync();
                }
            }
            return endereco;
        }

        public async Task<string> ConsultaBanco()
        {
            string bancos = "";
            string url = "https://brasilapi.com.br/api/banks/v1";
            HttpResponseMessage responseMessage = await _httpClient.GetAsync(url);
            if (responseMessage.IsSuccessStatusCode)
            {
                bancos = await responseMessage.Content.ReadAsStringAsync();
            }
            return bancos;
        }
    }
}
