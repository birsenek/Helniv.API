using AutoMapper;
using Helniv.API.Entities;
using Helniv.API.Interfaces;
using Helniv.API.Models;
using Helniv.API.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Helniv.API.Services
{

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

        public void CreateCard(CreateCardRequestModel cardModel, IFormFile? file)
        {
            if (_context.Cards.Any(x => x.Nome == cardModel.Nome))
                throw new Exception("Carta com nome '" + cardModel.Nome + "'já cadastrada.");

            if (file != null)
                SaveCardFile(file, cardModel.Elemento.ToString());

            var card = _mapper.Map<Card>(cardModel);

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

        public void UpdateCard(int id, UpdateCardRequestModel cardModel, IFormFile? file)
        {
            Card cardToUpdate = getCard(id);

            if (cardModel.Id == 0)
            {
                cardModel.Id = id;
            }

            if (cardModel.Nome != cardToUpdate.Nome && _context.Cards.Any(x => x.Nome == cardModel.Nome))
                throw new BadHttpRequestException("Já existe uma carta cadastrada com este nome!");

            if (file != null)
                SaveCardFile(file, cardModel.Elemento.ToString());
            
            cardToUpdate = _mapper.Map(cardModel, cardToUpdate);
            _context.Cards.Update(cardToUpdate);
            _context.SaveChanges();

        }

        public void DeleteCard(int id)
        {
            Card cardToDelete = getCard(id);

            _context.Cards.Remove(cardToDelete);
            _context.SaveChanges();

        }

        private void SaveCardFile(IFormFile file, string? cardElemento)
        {
            var folderPath = Directory.CreateDirectory($"D:\\Projetos\\Helniv\\HelnivFront\\src\\assets\\img\\cartas\\{ cardElemento }\\");

            using (var savePath = File.Create(folderPath.ToString() + file.FileName))
            {
                file.CopyTo(savePath);
            }
        }
    }
}
