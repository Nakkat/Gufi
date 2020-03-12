using Senai.Gufi.WebApi.Manha.Domains;
using Senai.Gufi.WebApi.Manha.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gufi.WebApi.Manha.Repositories
{
    // Intancio minha interface com meus metódos
    public class TipoEventoRepository : ITipoEventoRepository
    {
        // Instancio meu contexto
        GufiContext ctx = new GufiContext();

        /// <summary>
        /// Atualiza um tipo de evento
        /// </summary>
        /// <param name="id">Id do tipo evento que será buscado</param>
        /// <param name="tipoEventoAtualizado">Objeto tipoEventoAtualizado que será alterado</param>
        public void Atualizar(int id, TipoEvento tipoEventoAtualizado)
        {
            TipoEvento tipoEventoBuscado = ctx.TipoEvento.Find(id);

            tipoEventoBuscado.TituloTipoEvento = tipoEventoAtualizado.TituloTipoEvento;

            ctx.TipoEvento.Update(tipoEventoBuscado);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Buscar um tipo de evento por Id
        /// </summary>
        /// <param name="id">Id do tipo de evento que será buscado</param>
        /// <returns>Retorna um tipo de evento específico pelo Id</returns>
        public TipoEvento BuscarPorId(int id)
        {
            return ctx.TipoEvento.FirstOrDefault(te=> te.IdTipoEvento == id);
        }

        /// <summary>
        /// Cadastrar um novo tipo de evento
        /// </summary>
        /// <param name="novoTipoEvento">Objeto novoTipoEvento que será cadastrado</param>
        public void Cadastrar(TipoEvento novoTipoEvento)
        {
            ctx.TipoEvento.Add(novoTipoEvento);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Deletar um tipo de evento
        /// </summary>
        /// <param name="id">Id do tipo de evento que será buscado</param>
        public void Deletar(int id)
        {
            ctx.TipoEvento.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        /// <summary>
        /// Listar tipos de eventos
        /// </summary>
        /// <returns>Retorna uma lista dos tipos de eventos</returns>
        public List<TipoEvento> Listar()
        {
            return ctx.TipoEvento.ToList();
        }
    }
}
