using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senai.Gufi.WebApi.Manha.Domains
{
    public partial class Presenca
    {
        public int IdPresenca { get; set; }
        [Required(ErrorMessage = "Informe o Id do usuário que a presença pertence")]
        public int? IdUsuario { get; set; }
        [Required(ErrorMessage = "Informe o Id do evento que a presença a pertence")]
        public int? IdEvento { get; set; }
        [Required(ErrorMessage = "Informe a situação")]
        public string Situacao { get; set; }

        public Evento IdEventoNavigation { get; set; }
        public Usuario IdUsuarioNavigation { get; set; }
    }
}
