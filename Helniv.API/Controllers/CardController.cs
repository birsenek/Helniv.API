using AutoMapper;
using Helniv.API.Entities;
using Helniv.API.Services;
using Helniv.API.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Helniv.API.Controllers
{
    [ApiController]
    [Route("/card")]
    public class CardController : Controller
    {
        private ICardService _cardService;
        private IMapper _mapper;

        public CardController(ICardService cardService, IMapper mapper)
        {
            _cardService = cardService;
            _mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]

        public IActionResult GetAll()
        {
            var cards = _cardService.GetAll();
            return Ok(cards);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult GetById(int id)
        {
            var user = _cardService.GetById(id);
            return Ok(user);
        }

        [HttpPost]

        public IActionResult CreateCard(Card card)
        {
            _cardService.CreateCard(card);
            return Ok(new { message = "Carta criada com sucesso!" });
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateCard(int id, Card card)
        {
            _cardService.UpdateCard(id, card);
            return Ok(new { message = "Carta atualizada com sucesso!" });
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult DeleteCard(int id)
        {
            _cardService.DeleteCard(id);
            return Ok(new { message = "Carta excluída com sucesso!" });
        }
    }
}
