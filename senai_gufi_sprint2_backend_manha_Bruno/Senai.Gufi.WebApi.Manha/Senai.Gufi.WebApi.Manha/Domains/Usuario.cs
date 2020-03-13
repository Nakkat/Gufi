using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senai.Gufi.WebApi.Manha.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Presenca = new HashSet<Presenca>();
        }

        public int IdUsuario { get; set; }
        [Required(ErrorMessage = "Informe seu nome")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Informe o seu email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Informe a sua senha")]
        public string Senha { get; set; }
        public DateTime? DataCadastro { get; set; }
        [Required(ErrorMessage = "Informe seu gênero")]
        public string Genero { get; set; }
        public int? IdTipoUsuario { get; set; }

        public TipoUsuario IdTipoUsuarioNavigation { get; set; }
        public ICollection<Presenca> Presenca { get; set; }
    }
}
