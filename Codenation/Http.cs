using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Codenation
{
    class Http
    {
        readonly HttpClient client = new HttpClient();

        public  async Task<Arquivo> GetApi()
        {
            HttpResponseMessage response = await client.GetAsync(@"https://api.codenation.dev/v1/challenge/dev-ps/generate-data?token=829ff5107c5dbee9cb83ef45811c6d07eae57636");
            response.EnsureSuccessStatusCode();            
            var output = await response.Content.ReadAsStringAsync();
            Arquivo teste = JsonConvert.DeserializeObject<Arquivo>(output);
            return teste;
        }
        public async Task PostApi(Arquivo arquivo)
        {
            //Fazer metodo post
        }
        
    }
}
