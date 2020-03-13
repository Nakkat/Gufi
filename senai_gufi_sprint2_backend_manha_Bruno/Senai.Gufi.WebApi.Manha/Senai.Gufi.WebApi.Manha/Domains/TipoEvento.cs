using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senai.Gufi.WebApi.Manha.Domains
{
    public partial class TipoEvento
    {
        public TipoEvento()
        {
            Evento = new HashSet<Evento>();
        }

        public int IdTipoEvento { get; set; }
        [Required(ErrorMessage = "Informe o tipop do evento")]
        public string TituloTipoEvento { get; set; }

        public ICollection<Evento> Evento { get; set; }
    }
}
