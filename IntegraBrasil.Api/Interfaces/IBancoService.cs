using IntegraBrasil.Api.Dtos;

namespace IntegraBrasil.Api.Interfaces;

public interface IBancoService
{
    Task<ResponseObject<List<BancoResponse>>> BuscarTodos();
    Task<ResponseObject<BancoResponse>> BuscarBanco(string codigoBanco);
}
