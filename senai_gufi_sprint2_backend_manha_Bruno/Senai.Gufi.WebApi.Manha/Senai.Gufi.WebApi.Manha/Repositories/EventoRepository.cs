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
        /// Atualiza um tipo de evento
        /// </summary>
        /// <param name="id">Id do tipo evento que será buscado</param>
        /// <param name="tipoEventoAtualizado">Objeto tipoEventoAtualizado que será alterado</param>
        public void Atualizar(int id, Evento EventoAtualizado)
        {
            Evento EventoBuscado = ctx.Evento.Find(id);

            EventoBuscado.NomeEvento = EventoAtualizado.NomeEvento;
            EventoBuscado.NomeEvento = EventoAtualizado.NomeEvento;
            EventoBuscado.NomeEvento = EventoAtualizado.NomeEvento;
            EventoBuscado.NomeEvento = EventoAtualizado.NomeEvento;
            EventoBuscado.NomeEvento = EventoAtualizado.NomeEvento;

            ctx.Evento.Update(EventoBuscado);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Buscar um tipo de evento por Id
        /// </summary>
        /// <param name="id">Id do tipo de evento que será buscado</param>
        /// <returns>Retorna um tipo de evento específico pelo Id</returns>
        public Evento BuscarPorId(int id)
        {
            return ctx.Evento.FirstOrDefault(te => te.IdEvento == id);
        }

        /// <summary>
        /// Cadastrar um novo tipo de evento
        /// </summary>
        /// <param name="novoEvento">Objeto novoTipoEvento que será cadastrado</param>

        public void Cadastrar(Evento novoEvento)
        {
            ctx.Evento.Add(novoEvento);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Deletar um tipo de evento
        /// </summary>
        /// <param name="id">Id do tipo de evento que será buscado</param>
        public void Deletar(int id)
        {
            ctx.Evento.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        /// <summary>
        /// Listar tipos de eventos
        /// </summary>
        /// <returns>Retorna uma lista dos tipos de eventos</returns>
        public List<Evento> Listar()
        {
            return ctx.Evento.ToList();
        }
    }
}
