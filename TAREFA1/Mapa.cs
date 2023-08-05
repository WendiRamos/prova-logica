using CsvHelper.Configuration.Attributes;
using System;

namespace TAREFA1
{
    class Mapa
    {
        [Index(0)]
        public string Local { get; set; }

        [Index(1)]
        public string Populacao { get; set; }
    }
}
