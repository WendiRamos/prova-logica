using CsvHelper;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TAREFA3
{
    class Program
    {
        static async Task Main()
        {
            using var reader = new StreamReader("../../../../CEPs.csv");
            using var writer = new StreamWriter("../../../../CEPs-tarefa3.csv");

            var csvConfig = new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";",
                BadDataFound = null,
            };

            using var csvOriginal = new CsvReader(reader, csvConfig);
            var localizacoes = csvOriginal.GetRecords<Localizacao>().ToList();

            List<Localizacao> localizacoesAtualizadas = new List<Localizacao>();

            using (HttpClient client = new HttpClient())
            {
                foreach (var localizacao in localizacoes)
                {
                    var cep = Regex.Replace(localizacao.CEP, "[^0-9]", "");
                    try
                    {
                        string url = $"https://viacep.com.br/ws/{cep}/json/";
                        HttpResponseMessage response = await client.GetAsync(url);
                        
                        if (response.IsSuccessStatusCode)
                        {
                            string responseBody = await response.Content.ReadAsStringAsync();
                            Localizacao cepInfo = JsonSerializer.Deserialize<Localizacao>(responseBody);
                            localizacoesAtualizadas.Add(cepInfo);
                        }
                    }
                    catch (HttpRequestException)
                    {

                    }
                }
            }

            using var csvAlterado = new CsvWriter(writer, csvConfig);
            csvAlterado.WriteRecords(localizacoesAtualizadas);
        }
    }
}
