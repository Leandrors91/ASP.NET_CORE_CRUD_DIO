using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiCatalogoCartas.Entities;

namespace ApiCatalogoCartas.Repository
{
    public interface ICardRepository : IDisposable
    {
        Task<List<Card>> Obter(int pagina, int quantidade);
        Task<Card> Obter(Guid id);
        Task<List<Card>> Obter(string nome);
        Task Inserir(Card Card);
        Task Atualizar(Card Card);
        Task Apagar(Guid id);
    }
}