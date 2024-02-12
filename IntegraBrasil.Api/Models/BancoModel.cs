using Newtonsoft.Json;

namespace IntegraBrasil.Api.Models
{
    public class BancoModel
    {
        [JsonProperty("ispb")]
        public string? Ispb;

        [JsonProperty("name")]
        public string? Nome;

        [JsonProperty("code")]
        public int? Codigo;

        [JsonProperty("fullName")]
        public string? NomeCompleto;
    }
}
