using System.Dynamic;
using System.Net;

namespace IntegraBrasil.Api.Dtos;

public class ResponseObject<T> where T : class
{ 
    public HttpStatusCode CodigoHttp { get; set; }
    public T? DadosRetorno { get; set; }
    public ExpandoObject? ErroRetorno { get; set; }
}
