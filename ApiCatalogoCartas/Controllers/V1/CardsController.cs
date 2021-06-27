using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiCatalogoCartas.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ApiCatalogoCartas.Exceptions;
using ApiCatalogoCartas.ViewModel;
using ApiCatalogoCartas.InputModel;
using System.ComponentModel.DataAnnotations;

namespace ApiCatalogoCartas.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        public readonly ICardService _cardService;
        
        public CardsController(ICardService cardService)
        {
            _cardService = cardService;
        }

        /// <summary>
        /// Buscar todos os cards de forma paginada
        /// </summary>
        /// <remarks>
        /// Não é possível retornar os cards sem paginação
        /// </remarks>
        /// <param name="pagina">Indica qual página está sendo consultada. Mínimo 1</param>
        /// <param name="quantidade">Indica a quantidade de registros por página. Mínimo 1 e máximo 50</param>
        /// <response code="200">Retorna a lista de cards</response>
        /// <response code="204">Caso não haja cards</response>   
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CardViewModel>>> Obter([FromQuery, Range(1, int.MaxValue)] int pagina = 1, [FromQuery, Range(1, 50)] int quantidade = 5)
        {
            var cards = await _cardService.Obter(pagina, quantidade);

            if (cards.Count() == 0)
                return NoContent();

            return Ok(cards);
        }

        /// <summary>
        /// Buscar um card pelo seu Id
        /// </summary>
        /// <param name="idCard">Id do card buscado</param>
        /// <response code="200">Retorna o card filtrado</response>
        /// <response code="204">Caso não haja card com este id</response>   
        [HttpGet("{idCard:guid}")]
        public async Task<ActionResult<CardViewModel>> Obter([FromRoute] Guid idCard)
        {
            var card = await _cardService.Obter(idCard);

            if (card == null)
                return NoContent();

            return Ok(card);
        }

        /// <summary>
        /// Inserir um card no catálogo
        /// </summary>
        /// <param name="cardInputModel">Dados do card a ser inserido</param>
        /// <response code="200">Caso o card seja inserido com sucesso</response>
        /// <response code="422">Caso já exista um card com o mesmo nome</response>   
        [HttpPost]
        public async Task<ActionResult<CardViewModel>> Criar([FromBody] CardInputModel cardInputModel)
        {
            try
            {
                var card = await _cardService.Inserir(cardInputModel);

                return Ok(card);
            }
            catch (CardJaCadastradoException ex)
            {
                return UnprocessableEntity("Já existe um card com este nome para esta produtora");
            }
        }

        /// <summary>
        /// Atualizar um card no catálogo
        /// </summary>
        /// /// <param name="idCard">Id do card a ser atualizado</param>
        /// <param name="cardInputModel">Novos dados para atualizar o card indicado</param>
        /// <response code="200">Caso o card seja atualizado com sucesso</response>
        /// <response code="404">Caso não exista um card com este Id</response>   
        [HttpPut("{idCard:guid}")]
        public async Task<ActionResult<CardViewModel>> Atualizar([FromRoute] Guid idCard, [FromBody] CardInputModel cardInputModel)
        {
            try
            {
                await _cardService.Atualizar(idCard, cardInputModel);

                return Ok();
            }
            catch (CardNaoCadastradoException ex)
            {
                return NotFound("Não existe este card");
            }
        }

        /// <summary>
        /// Atualizar o preço de um card
        /// </summary>
        /// /// <param name="idCard">Id do card a ser atualizado</param>
        /// <param name="descricao">Nova descricao do card</param>
        /// <response code="200">Caso a descricao seja atualizado com sucesso</response>
        /// <response code="404">Caso não exista um card com este Id</response>   
        [HttpPatch("{idCard:guid}/descricao/{descricao}")]
        public async Task<ActionResult<CardViewModel>> Atualizar([FromRoute] Guid idCard, [FromRoute] string descricao)
        {
            try
            {
                await _cardService.Atualizar(idCard, descricao);

                return Ok();
            }
            catch (CardNaoCadastradoException ex)
            {
                return NotFound("Não existe este card");
            }
        }

        /// <summary>
        /// Excluir um card
        /// </summary>
        /// /// <param name="idCard">Id do card a ser excluído</param>
        /// <response code="200">Caso o card seja apagado com sucesso</response>
        /// <response code="404">Caso não exista um card com este Id</response>   
        [HttpDelete("{idCard:guid}")]
        public async Task<ActionResult<CardViewModel>> Apagar([FromRoute] Guid idCard)
        {
            try
            {
                await _cardService.Apagar(idCard);

                return Ok();
            }
            catch (CardNaoCadastradoException ex)
            {
                return NotFound("Não existe este card");
            }
        }
    }
}