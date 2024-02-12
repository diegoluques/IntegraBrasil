﻿using IntegraBrasil.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace IntegraBrasil.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class BancoController : ControllerBase
{
    private readonly IBancoService _bancoService;

    public BancoController(IBancoService bancoService)
    {
        _bancoService = bancoService;
    }

    [HttpGet("busca/todos")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> BuscarTodos()
    {
        var response = await _bancoService.BuscarTodos();
        if (response.CodigoHttp == System.Net.HttpStatusCode.OK)
            return Ok(response.DadosRetorno);
        else
            return StatusCode((int)response.CodigoHttp, response.ErroRetorno);
    }

    [HttpGet("busca/{codigoBanco}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> BuscarBanco([RegularExpression("^[0-9]*$")] string codigoBanco)
    {
        var response = await _bancoService.BuscarBanco(codigoBanco);
        if (response.CodigoHttp == System.Net.HttpStatusCode.OK)
            return Ok(response.DadosRetorno);
        else
            return StatusCode((int)response.CodigoHttp, response.ErroRetorno);
    }
}
