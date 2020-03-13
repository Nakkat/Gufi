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
    public class PresencaRepository : IPresencaRepository
    {
        // Instancio meu contexto
        GufiContext ctx = new GufiContext();
        public List<Presenca> Aprovacao(string status)
        {
            if (status == "Sim")
            {
               return ctx.Presenca.Where(p => p.Situacao == "Confirmada").ToList();
            } else if (status == "Nao")
            {
               return ctx.Presenca.Where(p => p.Situacao == "Não Confirmada").ToList();
            }
            return null;
        }

        /// <summary>
        /// Inscrever-se num evento ou convidar outro usuário
        /// </summary>
        /// <param name="novaPresenca">Objeto novaPresenca que será cadastrado</param>
        public void InscricaoConvite(Presenca novaPresenca)
        {
            List<Presenca> listaPresenca = ListarMeusEventos(novaPresenca.IdUsuario);
            foreach (var presencaUnica in listaPresenca)
            {
                if (presencaUnica.IdEvento != novaPresenca.IdUsuario)
                {
                    novaPresenca.Situacao = "Aguardando";
                    ctx.Presenca.Add(novaPresenca);
                    ctx.SaveChanges();
                }
                
            } 
        
        }
            
        /// <summary>
        /// Listar presenças
        /// </summary>
        /// <returns>Retorna uma lista de presenças</returns>
        public List<Presenca> Listar()
        {
            return ctx.Presenca.Include(p => p.IdEventoNavigation).ToList();
        }

        /// <summary>
        /// Listar os eventos que contenham o id do meu usuário
        /// </summary>
        /// <param name="id">Id do usuário que será buscado</param>
        /// <returns></returns>
        public List<Presenca> ListarMeusEventos(int? id)
        {
            return ctx.Presenca.Include("IdEventoNavigation").Include("IdUsuarioNavigation").Where(p => p.IdUsuarioNavigation.IdUsuario == id).ToList();
        }

        /// <summary>
        /// Alterar a situação da presença
        /// </summary>
        /// <param name="id">Id da presença que será buscada</param>
        /// <param name="statusAlterado">Objeto statusAlterado que será atualizado</param>
        public void Situacao(int id, Presenca statusAlterado)
        {
            Presenca situacaoBuscada = ctx.Presenca.Find(id);

            situacaoBuscada.Situacao = statusAlterado.Situacao;

            ctx.Presenca.Update(statusAlterado);

            ctx.SaveChanges();
        }
    }
}
