using System.Text.Json.Serialization;

namespace TAREFA3
{
    class Localizacao
    {
        [JsonPropertyName("cep")]
        public string CEP { get; set; }

        [JsonPropertyName("logradouro")]
        public string Logradouro { get; set; }

        [JsonPropertyName("complemento")]
        public string Complemento { get; set; }

        [JsonPropertyName("bairro")]
        public string Bairro { get; set; }

        [JsonPropertyName("localidade")]
        public string Localidade { get; set; }

        [JsonPropertyName("uf")]
        public string UF { get; set; }

        [JsonPropertyName("ibge")]
        public string IBGE { get; set; }

        [JsonPropertyName("gia")]
        public string GIA { get; set; }

        public string? Unidade { get; set; }
    }
}
