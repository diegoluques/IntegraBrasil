using IntegraBrasil.Api.Dtos;
using IntegraBrasil.Api.Interfaces;
using IntegraBrasil.Api.Models;
using Newtonsoft.Json;
using System.Dynamic;
using System.Net.Http.Headers;

namespace IntegraBrasil.Api.Rest;

public class BrasilApiRest : IBrasilApi
{
    private readonly Uri Url = new("https://brasilapi.com.br/");

    public async Task<ResponseObject<EnderecoModel>> BuscarEnderecoPorCep(string cep)
    {
        var response = new ResponseObject<EnderecoModel>();
        using (var httpClient = new HttpClient())
        {
            httpClient.BaseAddress = Url;
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage responseApiBrasil = await httpClient.GetAsync($"api/cep/v1/{cep}");
            string responseString = await responseApiBrasil.Content.ReadAsStringAsync();
            if (responseApiBrasil.IsSuccessStatusCode)
            {
                response.CodigoHttp = responseApiBrasil.StatusCode;
                response.DadosRetorno = JsonConvert.DeserializeObject<EnderecoModel>(responseString);
            }
            else
            {
                response.CodigoHttp = responseApiBrasil.StatusCode;
                response.ErroRetorno = JsonConvert.DeserializeObject<ExpandoObject>(responseString);
            }
        }
        return response;
    }

    public async Task<ResponseObject<BancoModel>> BuscarBanco(string codigoBanco)
    {
        var response = new ResponseObject<BancoModel>();
        using (var httpClient = new HttpClient())
        {
            httpClient.BaseAddress = Url;
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage responseApiBrasil = await httpClient.GetAsync($"api/banks/v1/{codigoBanco}");
            string responseString = await responseApiBrasil.Content.ReadAsStringAsync();
            if (responseApiBrasil.IsSuccessStatusCode)
            {
                response.CodigoHttp = responseApiBrasil.StatusCode;
                response.DadosRetorno = JsonConvert.DeserializeObject<BancoModel>(responseString);
            }
            else
            {
                response.CodigoHttp = responseApiBrasil.StatusCode;
                response.ErroRetorno = JsonConvert.DeserializeObject<ExpandoObject>(responseString);
            }
        }
        return response;
    }

    public async Task<ResponseObject<List<BancoModel>>> BuscarTodosBancos()
    {
        var response = new ResponseObject<List<BancoModel>>(); 
        using (var httpClient = new HttpClient())
        {
            httpClient.BaseAddress = Url;
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage responseApiBrasil = await httpClient.GetAsync("api/banks/v1");
            string responseString = await responseApiBrasil.Content.ReadAsStringAsync();
            if (responseApiBrasil.IsSuccessStatusCode)
            {
                response.CodigoHttp = responseApiBrasil.StatusCode;
                response.DadosRetorno = JsonConvert.DeserializeObject<List<BancoModel>>(responseString);
            }
            else
            {
                response.CodigoHttp = responseApiBrasil.StatusCode;
                response.ErroRetorno = JsonConvert.DeserializeObject<ExpandoObject>(responseString);
            }
        }
        return response;
    }
}
