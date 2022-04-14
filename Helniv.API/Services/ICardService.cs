using AutoMapper;
using Helniv.API.Entities;
using Helniv.API.Utils;
using Microsoft.EntityFrameworkCore;

namespace Helniv.API.Services
{
    public interface ICardService
    {
        IEnumerable<Card> GetAll();
        void CreateCard(Card card);
        Card GetById(int id);
        void UpdateCard(int id, Card card);
    }

    public class CardService : ICardService
    {
        private CardsDbContext _context;
        private readonly IMapper _mapper;

        public CardService(CardsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<Card> GetAll()
        {
            return _context.Cards.OrderBy(i => i.Id);
        }

        public void CreateCard(Card newCard)
        {
            // validate
            if (_context.Cards.Any(x => x.Nome == newCard.Nome))
                throw new Exception("Carta com nome '" + newCard.Nome + "'já cadastrada.");

            // map model to new user object
            var card = _mapper.Map<Card>(newCard);

            _context.Cards.Add(card);
            _context.SaveChanges();
        }

        public Card GetById(int id)
        {
            return getCard(id);
        }

        private Card getCard(int id)
        {
            var card = _context.Cards.AsNoTracking().Where(i => i.Id == id).FirstOrDefault();
            if (card == null)
                throw new KeyNotFoundException("Carta não encontrada");

            return card;
        }

        public void UpdateCard(int id, Card card)
        {
            Card cardToUpdate = getCard(id);

            if (card.Id == 0)
            {
                card.Id = id;
            }

            if (card.Nome != cardToUpdate.Nome && _context.Cards.Any(x => x.Nome == card.Nome))
                throw new BadHttpRequestException("Já existe uma carta cadastrada com este nome!");

            cardToUpdate = _mapper.Map(card, cardToUpdate);
            _context.Cards.Update(cardToUpdate);
            _context.SaveChanges();

        }
    }
}
