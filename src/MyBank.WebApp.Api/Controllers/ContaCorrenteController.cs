using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBank.Contas.Domain.Application;

namespace MyBank.WebApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaCorrenteController : ControllerBase
    {
        private readonly IContaCorrenteService _contaCorrenteService;
        public ContaCorrenteController(IContaCorrenteService contaCorrenteService)
        {
            _contaCorrenteService = contaCorrenteService;
        }


        [HttpPost]
        [Route("sacar")]
        public async Task<IActionResult> Sacar(ContaCorrenteRequest contaCorrenteRequest)
        {
            try
            {
                return Ok(await _contaCorrenteService.RealizarSaque(contaCorrenteRequest.Conta, contaCorrenteRequest.Valor));
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    success = false,
                    errors = e.Message
                });
            }
        }

        [HttpPost]
        [Route("depositar")]
        public async Task<IActionResult> Depositar(ContaCorrenteRequest contaCorrenteRequest)
        {
            try
            {
                return Ok(await _contaCorrenteService.RealizarDeposito(contaCorrenteRequest.Conta, contaCorrenteRequest.Valor));
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    success = false,
                    errors = e.Message
                });
            }

        }

        [HttpPost]
        [Route("saldo")]
        public async Task<IActionResult> Saldo(ContaCorrenteRequest contaCorrenteRequest)
        {
            try
            {
                return Ok(await _contaCorrenteService.ConsultarConta(contaCorrenteRequest.Conta));
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    success = false,
                    errors = e.Message
                });
            }
        }
    }
}