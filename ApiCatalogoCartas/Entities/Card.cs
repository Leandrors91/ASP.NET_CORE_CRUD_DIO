using System;

namespace ApiCatalogoCartas.Entities
{
    public class Card
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string TipoMonstro { get; set; }
        public string TipoCard { get; set; }
        public string Atributo { get; set; }
        public string Descricao { get; set; }
        public int Nivel { get; set; }
        public int Ataque { get; set; }
        public int Defesa { get; set; }
    }
}