using System;

namespace ApiCatalogoCartas.Exceptions
{
    public class CardJaCadastradoException : Exception
    {
        public CardJaCadastradoException()
            : base("Este card já foi cadastrado")
        { }
    }
}