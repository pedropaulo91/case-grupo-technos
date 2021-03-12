using System;
using System.ComponentModel.DataAnnotations;

namespace Case_Grupo_Technos.Models
{

    public class Produto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Codigo { get; set; }

        [MaxLength(1024, ErrorMessage = "Este campo deve conter no máximo 1024 caracteres")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public DateTime DataCadastro { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public DateTime DataLancamento { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public TipoProduto TipoDeProduto { get; set; }

    }

    public enum TipoProduto
    {
        Automotivo = 1,
        Beleza = 2,
        Casa = 3,
        Cozinha = 4,
        Eletronicos = 5
    }

}