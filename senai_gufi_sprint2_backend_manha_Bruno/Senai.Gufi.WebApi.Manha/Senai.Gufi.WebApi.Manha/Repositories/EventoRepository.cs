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
    public class EventoRepository : IEventoRepository
    {
        // Instancio meu contexto
        GufiContext ctx = new GufiContext();

        /// <summary>
        /// Atualiza um evento
        /// </summary>
        /// <param name="id">Id do evento que será buscado</param>
        /// <param name="eventoAtualizado">Objeto eventoAtualizado que será alterado</param>
        public void Atualizar(int id, Evento eventoAtualizado)
        {
            Evento eventoBuscado = ctx.Evento.Find(id);

            eventoBuscado.NomeEvento = eventoAtualizado.NomeEvento;
            eventoBuscado.IdInstituicao = eventoAtualizado.IdInstituicao;
            eventoBuscado.IdTipoEvento = eventoAtualizado.IdTipoEvento;
            eventoBuscado.AcessoLivre = eventoAtualizado.AcessoLivre;
            eventoBuscado.DataEvento = eventoAtualizado.DataEvento;
            eventoBuscado.Descricao = eventoAtualizado.Descricao;

            ctx.Evento.Update(eventoBuscado);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Buscar um evento por Id
        /// </summary>
        /// <param name="id">Id do tipo de evento que será buscado</param>
        /// <returns>Retorna um evento específico pelo Id</returns>
        public Evento BuscarPorId(int id)
        {
            return ctx.Evento.FirstOrDefault(te => te.IdEvento == id);
        }

        /// <summary>
        /// Cadastrar um novo evento
        /// </summary>
        /// <param name="novoEvento">Objeto novoEvento que será cadastrado</param>

        public void Cadastrar(Evento novoEvento)
        {
            ctx.Evento.Add(novoEvento);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Deletar um evento
        /// </summary>
        /// <param name="id">Id do evento que será buscado</param>
        public void Deletar(int id)
        {
            ctx.Evento.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        /// <summary>
        /// Listar eventos
        /// </summary>
        /// <returns>Retorna uma lista dos eventos</returns>
        public List<Evento> Listar()
        {
            return ctx.Evento.Include(e => e.IdInstituicaoNavigation).Include(e => e.IdTipoEventoNavigation).ToList();
        }
    }
}
