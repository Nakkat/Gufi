using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
  
    public class EventosController : Controller
    {
        // crio uma variável para minha interface
        private IEventoRepository _eventoRepository { get; set; }

        public EventosController()
        {
            // Instancio meu repositório na minha variável
            _eventoRepository = new EventoRepository();
        }

        /// <summary>
        /// Listar os eventos
        /// </summary>
        /// <returns>Retorna uma lista e um status code 200</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_eventoRepository.Listar());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }

        }

        /// <summary>
        /// Buscar um evento pelo ID
        /// </summary>
        /// <param name="id">Id do evento que será buscado</param>
        /// <returns>Retorna um evento específico pelo Id</returns>
        
        [Authorize(Roles = "Administrador")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_eventoRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }

        }

        /// <summary>
        /// Cadastrar um novo evento
        /// </summary>
        /// <param name="novoEvento">Objeto novoEvento que será cadastrado</param>
        /// <returns>Retorna um status code 201</returns>
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public IActionResult Post(Evento novoEvento)
        {
            try
            {
                _eventoRepository.Cadastrar(novoEvento);

                // Created
                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }

        }

        /// <summary>
        /// Atualiza um evento
        /// </summary>
        /// <param name="id">Id do evento que será buscado</param>
        /// <param name="eventoAtualizado">Objeto eventoAtualizado que será alterado</param>
        /// <returns>Retorna um status code 204</returns>
        [Authorize(Roles = "Administrador")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Evento eventoAtualizado)
        {
            try
            {
                _eventoRepository.Atualizar(id, eventoAtualizado);
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
        /// Deletar um evento
        /// </summary>
        /// <param name="id">Id do evento que será buscado</param>
        /// <returns>Retorna um status code 204</returns>
        [Authorize(Roles = "Administrador")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _eventoRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }

        }
    }
}