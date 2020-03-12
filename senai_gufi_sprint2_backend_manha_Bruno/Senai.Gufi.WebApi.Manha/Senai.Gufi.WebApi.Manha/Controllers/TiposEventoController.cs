using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class TiposEventoController : ControllerBase
    {
        // crio uma variável para minha interface
        private ITipoEventoRepository _tipoEventoRepository { get; set; }

        public TiposEventoController()
        {
            // Instancio meu repositório na minha variável
            _tipoEventoRepository = new TipoEventoRepository();
        }

        /// <summary>
        /// Listar os tipos de eventos
        /// </summary>
        /// <returns>Retorna uma lista e um status code 200</returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_tipoEventoRepository.Listar());
        }

        /// <summary>
        /// Buscar um tipo de evento pelo ID
        /// </summary>
        /// <param name="id">Id do tipo do evento que será buscado</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_tipoEventoRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Cadastrar um novo tipo de evento
        /// </summary>
        /// <param name="novoTipoEvento">Objeto novoTipoEvento que será cadastrado</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(TipoEvento novoTipoEvento)
        {
            _tipoEventoRepository.Cadastrar(novoTipoEvento);

            // Created
            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza um tipo de evento
        /// </summary>
        /// <param name="id">Id do tipo do evento que será buscado</param>
        /// <param name="tipoEventoAtualizado">Objeto tipoEventoAtualizado que será alterado</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, TipoEvento tipoEventoAtualizado)
        {
            try
            {
                _tipoEventoRepository.Atualizar(id, tipoEventoAtualizado);
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
        /// Deletar um tipo de evento
        /// </summary>
        /// <param name="id">Id do tipo de evento que será buscado</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _tipoEventoRepository.Deletar(id);

            return StatusCode(204);
        }
    }
}