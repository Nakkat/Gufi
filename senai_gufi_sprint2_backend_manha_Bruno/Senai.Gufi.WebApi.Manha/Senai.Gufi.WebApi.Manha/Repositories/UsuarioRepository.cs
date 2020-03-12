using Microsoft.EntityFrameworkCore;
using Senai.Gufi.WebApi.Manha.Domains;
using Senai.Gufi.WebApi.Manha.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gufi.WebApi.Manha.Repositories
{
    // Intancio minha interface com meus metódos
    public class UsuarioRepository : IUsuarioRepository
    {
        // Instancio meu contexto
        GufiContext ctx = new GufiContext();

        /// <summary>
        /// Atualiza um usuário
        /// </summary>
        /// <param name="id">Id do Usuario que será buscado</param>
        /// <param name="usuarioAtualizado">Objeto usuarioAtualizado que será alterado</param>
        public void Atualizar(int id, Usuario usuarioAtualizado)
        {
            Usuario usuarioBuscado = ctx.Usuario.Find(id);

            usuarioBuscado.Nome = usuarioAtualizado.Nome;
            usuarioBuscado.IdTipoUsuario = usuarioAtualizado.IdTipoUsuario;
            usuarioBuscado.Email = usuarioAtualizado.Email;
            usuarioBuscado.Senha = usuarioAtualizado.Senha;
            usuarioBuscado.Genero = usuarioBuscado.Genero;
            usuarioBuscado.DataCadastro = usuarioAtualizado.DataCadastro;
            

            ctx.Usuario.Update(usuarioBuscado);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Buscar um usuário por Id
        /// </summary>
        /// <param name="id">Id do usuário que será buscado</param>
        /// <returns>Retorna um usuário específico pelo Id</returns>
        public Usuario BuscarPorId(int id)
        {
            return ctx.Usuario.FirstOrDefault(te => te.IdUsuario == id);
        }

        /// <summary>
        /// Buscar email e a senha para fazer o login
        /// </summary>
        /// <param name="Email">Email do usuário que será buscado</param>
        /// <param name="Senha">Senha do usuário que será buscado</param>
        /// <returns>Retorna um token do login</returns>
        public Usuario BuscarPorEmailSenha(string Email, string Senha)
        {
            Usuario usuarioBuscado = ctx.Usuario.Include(u => u.IdTipoUsuarioNavigation).FirstOrDefault(a => a.Email == Email && a.Senha == Senha);

            return usuarioBuscado;
        }

        /// <summary>
        /// Cadastrar um novo usuário
        /// </summary>
        /// <param name="novoUsuario">Objeto novoUsuario que será cadastrado</param>
        public void Cadastrar(Usuario novoUsuario)
        {
            ctx.Usuario.Add(novoUsuario);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Deletar um usuário
        /// </summary>
        /// <param name="id">Id do usuário que será buscado</param>
        public void Deletar(int id)
        {
            ctx.Usuario.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        /// <summary>
        /// Listar usuários
        /// </summary>
        /// <returns>Retorna uma lista dos usuários</returns>
        public List<Usuario> Listar()
        {
            return ctx.Usuario.Include(u => u.IdTipoUsuarioNavigation).ToList();
        }
    }
}