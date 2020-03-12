using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Gufi.WebApi.Manha.Domains;
using Senai.Gufi.WebApi.Manha.Interfaces;
using Senai.Gufi.WebApi.Manha.Repositories;

namespace Senai.Gufi.WebApi.Manha.Controllers
{
    // Resposta em Json da requisição
    [Produces("application/json")]
    // Definindo meu endpoint
    [Route("api/[controller]")]
    // Indicando que meu tipo da requisição vai ser em HTTP API
    [ApiController]
    [Authorize]
    public class PresencasController : ControllerBase
    {
        // crio uma variável para minha interface
        private IPresencaRepository _presencaRepository { get; set; }

        public PresencasController()
        {
            // Instancio meu repositório na minha variável
            _presencaRepository = new PresencaRepository();
        }

        /// <summary>
        /// Lista de presenças
        /// </summary>
        /// <returns>Retorna um status code 200</returns>
        [Authorize(Roles= "Administrador")]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_presencaRepository.Listar());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Lista de presenças confirmadas e não confirmadas
        /// </summary>
        /// <returns>Retorna um status code 200</returns>
        [Authorize(Roles = "Administrador")]
        [HttpGet("{status}")]
        public IActionResult GetByStatus(string status)
        {
            try
            {
                return Ok(_presencaRepository.Aprovacao(status));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}