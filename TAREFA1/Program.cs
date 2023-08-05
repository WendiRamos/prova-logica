using CsvHelper;
using System.Globalization;
using System.IO;
using System.Linq;

namespace TAREFA1
{
    class Program
    {
        static void Main()
        {
            using var reader = new StreamReader("../../../../mapa.csv");
            using var writer = new StreamWriter("../../../../mapa-tarefa1.csv");

            var csvConfig = new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";",
                BadDataFound = null,
            };

            using var csvOriginal = new CsvReader(reader, csvConfig);
            var mapas = csvOriginal.GetRecords<Mapa>().ToList();

            var mapasAtualizados = mapas.Select(mapa => new Mapa()
            {
                Local = mapa.Local,
                Populacao = int.Parse(mapa.Populacao).ToString("N0")
            });

            using var csvAlterado = new CsvWriter(writer, csvConfig);
            csvAlterado.WriteRecords(mapasAtualizados);
        }
    }
}
