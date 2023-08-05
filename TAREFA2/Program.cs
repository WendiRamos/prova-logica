using CsvHelper;
using System.Globalization;
using System.IO;
using System.Linq;

namespace TAREFA2
{
    class Program
    {
        static void Main()
        {
            using var reader = new StreamReader("../../../../mapa.csv");
            using var writer = new StreamWriter("../../../../mapa-tarefa2.csv");

            var csvConfig = new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";",
                BadDataFound = null,
            };

            using var csvOriginal = new CsvReader(reader, csvConfig);
            var mapas = csvOriginal.GetRecords<Mapa>().ToList();

            int tamanho = mapas.Count;
            for (int i = 0; i < tamanho - 1; i++)
            {
                for (int j = 0; j < tamanho - i - 1; j++)
                {
                    if (mapas[j].Populacao < mapas[j + 1].Populacao)
                    {
                        Mapa temp = mapas[j];
                        mapas[j] = mapas[j + 1];
                        mapas[j + 1] = temp;
                    }
                }
            }

            using var csvAlterado = new CsvWriter(writer, csvConfig);
            csvAlterado.WriteRecords(mapas);
        }
    }
}
