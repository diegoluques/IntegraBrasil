using AutoMapper;
using IntegraBrasil.Api.Dtos;
using IntegraBrasil.Api.Interfaces;

namespace IntegraBrasil.Api.Services;

public class BancoService : IBancoService
{
    private readonly IMapper _mapper;
    private readonly IBrasilApi _brasilApi;

    public BancoService(IMapper mapper, IBrasilApi brasilApi)
    {
        _mapper = mapper;
        _brasilApi = brasilApi;
    }

    public async Task<ResponseObject<BancoResponse>> BuscarBanco(string codigoBanco)
    {
        var response = await _brasilApi.BuscarBanco(codigoBanco);
        return _mapper.Map<ResponseObject<BancoResponse>>(response);
    }

    public async Task<ResponseObject<List<BancoResponse>>> BuscarTodos()
    {
        var response = await _brasilApi.BuscarTodosBancos();
        return _mapper.Map<ResponseObject<List<BancoResponse>>>(response);
    }
}
