using CRUD.Application.Interfaces;
using CRUD.Application.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace CRUD.Application.Services
{
    public class AddressService : IAddressService
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly string url;

        public AddressService(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
            url = "https://viacep.com.br/ws/{0}/json/";
        }

        public async Task<ViaCepModel> GetAddressByCep(string cep)
        {
            var client = httpClientFactory.CreateClient();

            var response = await client.GetAsync(string.Format(url, cep));

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                var viaCep = JsonConvert.DeserializeObject<ViaCepModel>(content);

                if (string.IsNullOrEmpty(viaCep.Cep))
                    return null;

                return viaCep;
            }

            return null;
        }
    }
}
