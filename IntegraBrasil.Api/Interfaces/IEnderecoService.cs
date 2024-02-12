using IntegraBrasil.Api.Dtos;

namespace IntegraBrasil.Api.Interfaces;

public interface IEnderecoService
{
    Task<ResponseObject<EnderecoResponse>> BuscarEndereco(string cep);
}
