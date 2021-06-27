using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiCatalogoCartas.InputModel;
using ApiCatalogoCartas.ViewModel;

namespace ApiCatalogoCartas.Services
{
    public interface ICardService
    {
        Task<List<CardViewModel>> Obter(int pagina, int quantidade);
        Task<CardViewModel> Obter(Guid id);
        Task<CardViewModel> Inserir(CardInputModel card);
        Task Atualizar(Guid idCard, CardInputModel card);
        Task Atualizar(Guid idCard, string descricao);
        Task Apagar(Guid idCard);
    }
}