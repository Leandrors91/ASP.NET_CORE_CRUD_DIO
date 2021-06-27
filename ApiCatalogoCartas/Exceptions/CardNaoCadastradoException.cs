using System;

namespace ApiCatalogoCartas.Exceptions
{
    public class CardNaoCadastradoException : Exception
    {
        public CardNaoCadastradoException()
            : base("Este card não foi cadastrado")
        { }
    }
}