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
        [Authorize(Roles = "Administrador")]
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
        /// Lista de presenças pelo Id de um usuário específico
        /// </summary>
        /// <param name="id">Id do usuário que será buscad</param>
        /// <returns>Retorna uma lista e um status code 200</returns>
        [Authorize(Roles = "Administrador")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_presencaRepository.ListarMeusEventos(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Lista de presenças confirmadas e não confirmadas
        /// </summary>
        /// <param name="status">Objeto status que será buscado</param>
        /// <returns>Retorna uma lista e um status code 200</returns>
        [Authorize(Roles = "Administrador")]
        [HttpGet("situacao/{status}")]
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

        /// <summary>
        /// Cadastra uma nova presença
        /// </summary>
        /// <param name="novaPresenca">Objeto novaPresenca que será cadastrado</param>
        /// <returns></returns>

        [HttpPost]
        public IActionResult InscricaoConvite(Presenca novaPresenca)
        {
            try
            {
                _presencaRepository.InscricaoConvite(novaPresenca);
                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Alterar a situação de uma presença
        /// </summary>
        /// <param name="id">Id da presença que será buscado</param>
        /// <param name="statusAlterado">Objeto statusAlterado que será atualizado</param>
        /// <returns></returns>

        [Authorize(Roles = "Administrador")]
        [HttpPut("{id}")]
        public IActionResult Situacao(int id, Presenca statusAlterado)
        {
            try
            {
                _presencaRepository.Situacao(id, statusAlterado);
                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}