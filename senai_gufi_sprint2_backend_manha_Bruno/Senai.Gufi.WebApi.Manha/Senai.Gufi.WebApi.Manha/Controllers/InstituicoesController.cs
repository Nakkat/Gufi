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
    public class InstituicoesController : ControllerBase
    {
        // crio uma variável para minha interface
        private IInstituicaoRepository _instituicaoRepository { get; set; }

        public InstituicoesController()
        {
            // Instancio meu repositório na minha variável
            _instituicaoRepository = new InstituicaoRepository();
        }

        /// <summary>
        /// Listar as insituições
        /// </summary>
        /// <returns>Retorna uma lista e um status code 200</returns>
        [Authorize(Roles = "Administrador")]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_instituicaoRepository.Listar());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }

        }

        /// <summary>
        /// Buscar uma Instituição pelo ID
        /// </summary>
        /// <param name="id">Id da Instituição que será buscado</param>
        /// <returns>Retorna uma Instituição específico pelo Id</returns>

        [Authorize(Roles = "Administrador")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_instituicaoRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }

        }

        /// <summary>
        /// Cadastrar uma nova instituição
        /// </summary>
        /// <param name="novaInstituicao">Objeto novaInstituicao que será cadastrado</param>
        /// <returns>Retorna um status code 201</returns>
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public IActionResult Post(Instituicao novaInstituicao)
        {
            try
            {
                _instituicaoRepository.Cadastrar(novaInstituicao);

                // Created
                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }

        }

        /// <summary>
        /// Atualiza uma instituição
        /// </summary>
        /// <param name="id">Id da Instituição que será buscado</param>
        /// <param name="instituicaoAtualizado">Objeto instituicaoAtualizado que será alterado</param>
        /// <returns>Retorna um status code 204</returns>
        [Authorize(Roles = "Administrador")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Instituicao instituicaoAtualizado)
        {
            try
            {
                _instituicaoRepository.Atualizar(id, instituicaoAtualizado);
                // No content
                return StatusCode(204);
            }
            catch (Exception erro)
            {
                // Má requisição
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Deletar uma instituição
        /// </summary>
        /// <param name="id">Id da instituição que será buscado</param>
        /// <returns>Retorna um status code 204</returns>
        [Authorize(Roles = "Administrador")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _instituicaoRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }

        }
    }
}