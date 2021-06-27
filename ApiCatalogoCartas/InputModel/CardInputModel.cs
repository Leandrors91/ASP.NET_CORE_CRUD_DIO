using System;
using System.ComponentModel.DataAnnotations;

namespace ApiCatalogoCartas.InputModel
{
    public class CardInputModel
    {
        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "O nome do monstro tem que ter entre 1 e 100 caracteres")]
        public string Nome { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "O tipo do monstro tem que ter entre 1 e 100 caracteres")]
        public string Tipo { get; set; }
        [Required]
        [StringLength(300, MinimumLength = 10, ErrorMessage = "A descrição do monstro tem que ter entre 10 e 300 caracteres")]
        public string Descricao { get; set; }
        [Required]
        [Range(1, 12, ErrorMessage = "O nivel do mostro tem que estar entre 1 e 12")]
        public int Nivel { get; set; }
        [Required]
        [Range(0, 10000, ErrorMessage = "A defesa base do mostro tem que estar entre 0 e 10000")]
        public int Defesa { get; set; }
        [Required]
        [Range(0, 10000, ErrorMessage = "O ataque base do mostro tem que estar entre 0 e 10000")]
        public int Ataque { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "O atributo do monstro tem que ter entre 1 e 100 caracteres")]
        public string Atributo { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "O tipo do monstro tem que ter entre 1 e 100 caracteres")]
        public string TipoMonstro { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "O tipo do card tem que ter entre 1 e 100 caracteres")]
        public string TipoCard { get; set; }
    }
}