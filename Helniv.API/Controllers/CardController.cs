using AutoMapper;
using Helniv.API.Entities;
using Helniv.API.Interfaces;
using Helniv.API.Models;
using Helniv.API.Services;
using Helniv.API.Utils;
using Microsoft.AspNetCore.Cors;
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateCard([FromForm] CreateCardRequestModel cardModel)
        {
            var file = Request.Form.Files[0];
            _cardService.CreateCard(cardModel, file);
            
            return Ok(new { message = "Carta criada com sucesso!" });
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateCard(int id, [FromForm]UpdateCardRequestModel cardModel)
        {
            var file = Request.Form.Files[0];
            _cardService.UpdateCard(id, cardModel, file);
            
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
