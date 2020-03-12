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
            if (status == "Confirmado")
            {
               return ctx.Presenca.Where(p => p.Situacao == "Confirmada").ToList();
            } else
            {
               return ctx.Presenca.Where(p => p.Situacao == "Não confirmada").ToList();
            }
        }

        public List<Presenca> Listar()
        {
            return ctx.Presenca.Include(p => p.IdEventoNavigation).ToList();
        }
    }
}
