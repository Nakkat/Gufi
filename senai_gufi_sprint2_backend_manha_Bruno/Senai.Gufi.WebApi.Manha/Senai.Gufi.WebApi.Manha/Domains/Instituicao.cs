using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senai.Gufi.WebApi.Manha.Domains
{
    public partial class Instituicao
    {
        public Instituicao()
        {
            Evento = new HashSet<Evento>();
        }
      
        public int IdInstituicao { get; set; }
        [Required(ErrorMessage = "Informe o CNPJ")]
        [StringLength(14,MinimumLength = 14, ErrorMessage = "Você deve colocar 14 dígitos obrigatoriamente")]
        public string Cnpj { get; set; }
        [Required(ErrorMessage = "Informe o NomeFantasia")]
        public string NomeFantasia { get; set; }
        [Required(ErrorMessage = "Informe o endereço")]
        public string Endereco { get; set; }

        public ICollection<Evento> Evento { get; set; }
    }
}
