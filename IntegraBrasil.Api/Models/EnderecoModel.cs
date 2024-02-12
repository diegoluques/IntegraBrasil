using Newtonsoft.Json; 

namespace IntegraBrasil.Api.Models
{
    public class EnderecoModel
    {
        [JsonProperty("cep")] 
        public string? Cep;

        [JsonProperty("state")]
        public string? Estado;

        [JsonProperty("city")]
        public string? Cidade;

        [JsonProperty("neighborhood")]
        public string? Regiao;

        [JsonProperty("street")]
        public string? Rua;

        [JsonProperty("service")]
        public string? Servico;
    }
}
