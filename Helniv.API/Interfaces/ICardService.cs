using Helniv.API.Entities;
using Helniv.API.Models;

namespace Helniv.API.Interfaces
{
    public interface ICardService
    {
        IEnumerable<Card> GetAll();
        void CreateCard(CreateCardRequestModel cardModel, IFormFile? file);
        Card GetById(int id);
        void UpdateCard(int id, UpdateCardRequestModel cardModel, IFormFile? file);
        void DeleteCard(int id);
    }
}
