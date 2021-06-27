using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCatalogoCartas.Entities;
using ApiCatalogoCartas.Repository;

namespace ApiCatalogoCartas.Repositories
{
    public class CardRepository : ICardRepository
    {
        private static Dictionary<Guid, Card> cards = new Dictionary<Guid, Card>()
        {
            {Guid.Parse("0ca314a5-9282-45d8-92c3-2985f2a9fd04"), new Card{ Id = Guid.Parse("0ca314a5-9282-45d8-92c3-2985f2a9fd04"), Nome = "Dragão Branco de Olhos Azuis", TipoCard = "Dragão", TipoMonstro = "Normal", Atributo = "Luz", Ataque = 3000, Defesa = 2500, Nivel = 7, Descricao = "Este dragão lendário é uma poderosa máquina de destruição. Praticamente invencível, muito poucos enfrentaram esta magnífica criatura e viveram para contar a história."} },
            {Guid.Parse("eb909ced-1862-4789-8641-1bba36c23db3"), new Card{ Id = Guid.Parse("eb909ced-1862-4789-8641-1bba36c23db3"), Nome = "Dragão Negro de Olhos Vermelhos", TipoCard = "Dragão", TipoMonstro = "Normal", Atributo = "Trevas", Ataque = 2400, Defesa = 2000, Nivel = 7, Descricao = "Um dragão feroz com um ataque letal."} },
            {Guid.Parse("5e99c84a-108b-4dfa-ab7e-d8c55957a7ec"), new Card{ Id = Guid.Parse("5e99c84a-108b-4dfa-ab7e-d8c55957a7ec"), Nome = "Mago Negro", TipoCard = "Mago", TipoMonstro = "Normal", Atributo = "Trevas", Ataque = 2500, Defesa = 2100, Nivel = 7, Descricao = "O mago definitivo em termos de ataque e defesa."} },
            {Guid.Parse("da033439-f352-4539-879f-515759312d53"), new Card{ Id = Guid.Parse("da033439-f352-4539-879f-515759312d53"), Nome = "Dragão Revolver", TipoCard = "Maquina", TipoMonstro = "Efeito", Atributo = "Trevas", Ataque = 2600, Defesa = 220, Nivel = 7, Descricao = "Uma vez por turno: você pode escolher 1 monstro que seu oponente controla; lance uma moeda 3 vezes e destrua-o se pelo menos 2 resultados forem cara."} },
            {Guid.Parse("92576bd2-388e-4f5d-96c1-8bfda6c5a268"), new Card{ Id = Guid.Parse("92576bd2-388e-4f5d-96c1-8bfda6c5a268"), Nome = "Pequea Maga Negra", TipoCard = "Mago", TipoMonstro = "Efeito", Atributo = "Luz", Ataque = 2000, Defesa = 1700, Nivel = 7, Descricao = "Ganha 300 de ATK para cada Mago Negro ou Mago do Caos das Trevas no Cemitério."} },
            {Guid.Parse("c3c9b5da-6a45-4de1-b28b-491cbf83b589"), new Card{ Id = Guid.Parse("c3c9b5da-6a45-4de1-b28b-491cbf83b589"), Nome = "Inseto Devorador de Homens", TipoCard = "Inseto", TipoMonstro = "Efeito / virar", Atributo = "Terra", Ataque = 450, Defesa = 600, Nivel = 2, Descricao = "VIRE: Escolha 1 monstro no campo; destrua-o."} },
        };

        public Task<List<Card>> Obter(int pagina, int quantidade)
        {
            return Task.FromResult(cards.Values.Skip((pagina - 1) * quantidade).Take(quantidade).ToList());
        }

        public Task<Card> Obter(Guid id)
        {
            if (!cards.ContainsKey(id))
                return Task.FromResult<Card>(null);

            return Task.FromResult(cards[id]);
        }

        public Task<List<Card>> Obter(string nome)
        {
            return Task.FromResult(cards.Values.Where(card => card.Nome.Equals(nome)).ToList());
        }

        public Task<List<Card>> ObterSemLambda(string nome)
        {
            var retorno = new List<Card>();

            foreach(var card in cards.Values)
            {
                if (card.Nome.Equals(nome))
                    retorno.Add(card);
            }

            return Task.FromResult(retorno);
        }

        public Task Inserir(Card card)
        {
            cards.Add(card.Id, card);
            return Task.CompletedTask;
        }

        public Task Atualizar(Card card)
        {
            cards[card.Id] = card;
            return Task.CompletedTask;
        }

        public Task Apagar(Guid id)
        {
            cards.Remove(id);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            //Fechar conexão com o banco
        }
    }
}