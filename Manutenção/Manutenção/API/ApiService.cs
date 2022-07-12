using Newtonsoft.Json;
using Servico;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Manutenção.API
{
    public static class ApiService
    {
        public const string Url = "https://servico-ef8.conveyor.cloud/";

        public static async Task<List<Funcionarios>> ObterFuncionarios()
        {
            try
            {
                HttpClient client = new HttpClient();
                string url = Url + "/api/Funcionarios";
                string response = await client.GetStringAsync(url);
                List<Funcionarios> funcionarios = JsonConvert.DeserializeObject<List<Funcionarios>>(response);
                return funcionarios;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
