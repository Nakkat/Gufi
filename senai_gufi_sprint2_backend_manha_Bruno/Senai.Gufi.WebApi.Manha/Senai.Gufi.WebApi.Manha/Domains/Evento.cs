using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senai.Gufi.WebApi.Manha.Domains
{
    public partial class Evento
    {
        public Evento()
        {
            Presenca = new HashSet<Presenca>();
        }

        public int IdEvento { get; set; }
        [Required(ErrorMessage = "Informe o Nome do evento")]
        public string NomeEvento { get; set; }
        [Required(ErrorMessage = "Informe a data do evento")]
        public DateTime DataEvento { get; set; }
        [Required(ErrorMessage = "Informe a descrição do evento")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Informe se o acesso")]
        public bool? AcessoLivre { get; set; }
        [Required(ErrorMessage = "Informe o Id da instituição no qual o evento pertence")]
        public int? IdInstituicao { get; set; }
        [Required(ErrorMessage = "Informe o Id do tipo do evento no qual ele pertence")]
        public int? IdTipoEvento { get; set; }

        public Instituicao IdInstituicaoNavigation { get; set; }
        public TipoEvento IdTipoEventoNavigation { get; set; }
        public ICollection<Presenca> Presenca { get; set; }
    }
}
