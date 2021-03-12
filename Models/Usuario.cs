
using System.ComponentModel.DataAnnotations;

namespace Case_Grupo_Technos.Models
{

    public class Usuario
    {

        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string NomeUsuario { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Senha { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public Cargo Cargo { get; set; }

    }

    public enum Cargo
    {
        Diretor = 1,
        Gerente = 2,
        Empregado = 3
    }

}