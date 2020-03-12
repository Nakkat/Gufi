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
        /// Atualiza uma instituição
        /// </summary>
        /// <param name="id">Id da instituição que será buscado</param>
        /// <param name="instituicaoAtualizada">Objeto instituicaoAtualizada que será alterada</param>
        public void Atualizar(int id, Instituicao instituicaoAtualizada)
        {
            Instituicao instituicaoBuscada = ctx.Instituicao.Find(id);

            instituicaoBuscada.Cnpj = instituicaoAtualizada.Cnpj;
            instituicaoBuscada.NomeFantasia = instituicaoAtualizada.NomeFantasia;
            instituicaoBuscada.Endereco = instituicaoAtualizada.Endereco;

            ctx.Instituicao.Update(instituicaoBuscada);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Buscar uma instituição por Id
        /// </summary>
        /// <param name="id">Id da instituição que será buscado</param>
        /// <returns>Retorna uma instituição específica pelo Id</returns>
        public Instituicao BuscarPorId(int id)
        {
            return ctx.Instituicao.FirstOrDefault(te => te.IdInstituicao == id);
        }

        /// <summary>
        /// Cadastrar uma nova instituição
        /// </summary>
        /// <param name="novaInstituicao">Objeto novaInstituicao que será cadastrado</param>
        public void Cadastrar(Instituicao novaInstituicao)
        {
            ctx.Instituicao.Add(novaInstituicao);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Deletar uma instituição
        /// </summary>
        /// <param name="id">Id da insituição que será buscado</param>
        public void Deletar(int id)
        {
            ctx.Instituicao.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        /// <summary>
        /// Listar as instituições
        /// </summary>
        /// <returns>Retorna uma lista das instituições</returns>
        public List<Instituicao> Listar()
        {
            return ctx.Instituicao.ToList();
        }
    }
}
