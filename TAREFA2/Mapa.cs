using CsvHelper.Configuration.Attributes;
using System;

namespace TAREFA2
{
    class Mapa
    {
        [Index(0)]
        public string Local { get; set; }

        [Index(1)]
        public int Populacao { get; set; }
    }
}
