using AutoMapper;
using IntegraBrasil.Api.Dtos;
using IntegraBrasil.Api.Interfaces;

namespace IntegraBrasil.Api.Services;

public class EnderecoService : IEnderecoService
{
    private readonly IMapper _mapper;
    private readonly IBrasilApi _apiBrasil;

    public EnderecoService(IMapper mapper, IBrasilApi apiBrasil)
    {
        _mapper = mapper;
        _apiBrasil = apiBrasil;
    }

    public async Task<ResponseObject<EnderecoResponse>> BuscarEndereco(string cep)
    {
        var endereco = await _apiBrasil.BuscarEnderecoPorCep(cep);
        return _mapper.Map<ResponseObject<EnderecoResponse>>(endereco);
    }
}
