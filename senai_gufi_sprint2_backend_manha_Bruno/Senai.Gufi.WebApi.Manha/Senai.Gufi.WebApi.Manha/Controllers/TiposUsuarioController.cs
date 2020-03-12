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
    public class TiposUsuarioController : ControllerBase
    {
        // crio uma variável para minha interface
        private ITipoUsuarioRepository _tipoUsuarioRepository { get; set; }

        public TiposUsuarioController()
        {
            // Instancio meu repositório na minha variável
            _tipoUsuarioRepository = new TipoUsuarioRepository();
        }

        /// <summary>
        /// Listar os tipos de usuários
        /// </summary>
        /// <returns>Retorna uma lista e um status code 200</returns>
        [Authorize(Roles = "Administrador")]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_tipoUsuarioRepository.Listar());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
            
        }

        /// <summary>
        /// Buscar um tipo de usuário pelo ID
        /// </summary>
        /// <param name="id">Id do tipo do usuário que será buscado</param>
        /// <returns>Retorna um tipo de usuário específico pelo Id</returns>
        [Authorize(Roles = "Administrador")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_tipoUsuarioRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
            
        }

        /// <summary>
        /// Cadastrar um novo tipo de usuário
        /// </summary>
        /// <param name="novoTipoUsuario">Objeto novoTipoUsuario que será cadastrado</param>
        /// <returns>Retorna um status code 201</returns>
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public IActionResult Post(TipoUsuario novoTipoUsuario)
        {
            try
            {
                _tipoUsuarioRepository.Cadastrar(novoTipoUsuario);

                // Created
                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
            
        }

        /// <summary>
        /// Atualiza um tipo de usuário
        /// </summary>
        /// <param name="id">Id do tipo do usuário que será buscado</param>
        /// <param name="tipoUsuarioAtualizado">Objeto TipoUsuarioAtualizado que será alterado</param>
        /// <returns>Retorna um status code 204</returns>
        [Authorize(Roles = "Administrador")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, TipoUsuario tipoUsuarioAtualizado)
        {
            try
            {
                _tipoUsuarioRepository.Atualizar(id, tipoUsuarioAtualizado);
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
        /// Deletar um tipo de usuário
        /// </summary>
        /// <param name="id">Id do tipo de usuário que será buscado</param>
        /// <returns>Retorna um status code 204</returns>
        [Authorize(Roles = "Administrador")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _tipoUsuarioRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
          
        }
    }
}