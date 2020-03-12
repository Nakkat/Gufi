using Senai.Gufi.WebApi.Manha.Domains;
using Senai.Gufi.WebApi.Manha.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gufi.WebApi.Manha.Repositories
{
    // Intancio minha interface com meus metódos
    public class InstituicaoRepository : IInstituicaoRepository
    {
        // Instancio meu contexto
        GufiContext ctx = new GufiContext();

        /// <summary>
        /// Atualiza um tipo de evento
        /// </summary>
        /// <param name="id">Id do tipo evento que será buscado</param>
        /// <param name="tipoEventoAtualizado">Objeto tipoEventoAtualizado que será alterado</param>
        public void Atualizar(int id, Instituicao InstituicaoAtualizada)
        {
            Instituicao InstituicaoBuscado = ctx.Instituicao.Find(id);

            InstituicaoBuscado.Cnpj = InstituicaoAtualizada.Cnpj;

            ctx.Instituicao.Update(InstituicaoBuscado);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Buscar um tipo de evento por Id
        /// </summary>
        /// <param name="id">Id do tipo de evento que será buscado</param>
        /// <returns>Retorna um tipo de evento específico pelo Id</returns>
        public Instituicao BuscarPorId(int id)
        {
            return ctx.Instituicao.FirstOrDefault(te => te.IdInstituicao == id);
        }

        /// <summary>
        /// Cadastrar um novo tipo de evento
        /// </summary>
        /// <param name="novoInstituicao">Objeto novoTipoEvento que será cadastrado</param>

        public void Cadastrar(Instituicao novaInstituicao)
        {
            ctx.Instituicao.Add(novaInstituicao);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Deletar um tipo de evento
        /// </summary>
        /// <param name="id">Id do tipo de evento que será buscado</param>
        public void Deletar(int id)
        {
            ctx.Instituicao.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        /// <summary>
        /// Listar tipos de eventos
        /// </summary>
        /// <returns>Retorna uma lista dos tipos de eventos</returns>
        public List<Instituicao> Listar()
        {
            return ctx.Instituicao.ToList();
        }
    }
}
