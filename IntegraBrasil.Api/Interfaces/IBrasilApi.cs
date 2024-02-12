using IntegraBrasil.Api.Dtos;
using IntegraBrasil.Api.Models;

namespace IntegraBrasil.Api.Interfaces;

public interface IBrasilApi
{
    Task<ResponseObject<EnderecoModel>> BuscarEnderecoPorCep(string cep);
    Task<ResponseObject<BancoModel>> BuscarBanco(string codigoBanco);
    Task<ResponseObject<List<BancoModel>>> BuscarTodosBancos();
}
