using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCatalogoCartas.Entities;
using ApiCatalogoCartas.Exceptions;
using ApiCatalogoCartas.InputModel;
using ApiCatalogoCartas.Repository;
using ApiCatalogoCartas.ViewModel;

namespace ApiCatalogoCartas.Services
{
    public class CardService : ICardService
    {
        public readonly ICardRepository _cardRepository;

        public CardService(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        public async Task<List<CardViewModel>> Obter(int pagina, int quantidade)
        {
            var cards = await _cardRepository.Obter(pagina, quantidade);

            return cards.Select(card => new CardViewModel
                                {
                                    Id = card.Id,
                                    Nome = card.Nome,
                                    TipoMonstro = card.TipoMonstro,
                                    TipoCard = card.TipoCard,
                                    Atributo = card.Atributo,
                                    Nivel = card.Nivel,
                                    Ataque = card.Ataque,
                                    Defesa = card.Defesa,
                                    Descricao = card.Descricao
                                })
                               .ToList();
        }

        public async Task<CardViewModel> Obter(Guid id)
        {
            var card = await _cardRepository.Obter(id);

            if (card == null)
                return null;

            return new CardViewModel
            {
                Id = card.Id,
                Nome = card.Nome,
                TipoMonstro = card.TipoMonstro,
                TipoCard = card.TipoCard,
                Atributo = card.Atributo,
                Nivel = card.Nivel,
                Ataque = card.Ataque,
                Defesa = card.Defesa,
                Descricao = card.Descricao
            };
        }

        public async Task<CardViewModel> Inserir(CardInputModel card)
        {
            var entidadeCard = await _cardRepository.Obter(card.Nome);

            if (entidadeCard.Count > 0)
                throw new CardJaCadastradoException();

            var cardInsert = new Card
            {
                Id = Guid.NewGuid(),
                Nome = card.Nome,
                TipoMonstro = card.TipoMonstro,
                TipoCard = card.TipoCard,
                Atributo = card.Atributo,
                Nivel = card.Nivel,
                Ataque = card.Ataque,
                Defesa = card.Defesa,
                Descricao = card.Descricao
            };

            await _cardRepository.Inserir(cardInsert);

            return new CardViewModel
            {
                Id = cardInsert.Id,
                Nome = card.Nome,
                TipoMonstro = card.TipoMonstro,
                TipoCard = card.TipoCard,
                Atributo = card.Atributo,
                Nivel = card.Nivel,
                Ataque = card.Ataque,
                Defesa = card.Defesa,
                Descricao = card.Descricao
            };
        }

        public async Task Atualizar(Guid id, CardInputModel card)
        {
            var entidadeCard = await _cardRepository.Obter(id);

            if (entidadeCard == null)
                throw new CardNaoCadastradoException();

            entidadeCard.Nome = card.Nome;
            entidadeCard.TipoMonstro = card.TipoMonstro;
            entidadeCard.TipoCard = card.TipoCard;
            entidadeCard.Atributo = card.Atributo;
            entidadeCard.Nivel = card.Nivel;
            entidadeCard.Ataque = card.Ataque;
            entidadeCard.Defesa = card.Defesa;
            entidadeCard.Descricao = card.Descricao;

            await _cardRepository.Atualizar(entidadeCard);
        }

        public async Task Atualizar(Guid id, string descricao)
        {
            var entidadeCard = await _cardRepository.Obter(id);

            if (entidadeCard == null)
                throw new CardNaoCadastradoException();

            entidadeCard.Descricao = descricao;

            await _cardRepository.Atualizar(entidadeCard);
        }

        public async Task Apagar(Guid id)
        {
            var card = await _cardRepository.Obter(id);

            if (card == null)
                throw new CardNaoCadastradoException();

            await _cardRepository.Apagar(id);
        }

        public void Dispose()
        {
            _cardRepository?.Dispose();
        }
    }
}
