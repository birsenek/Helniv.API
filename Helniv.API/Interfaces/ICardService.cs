using Helniv.API.Entities;
using Helniv.API.Models;

namespace Helniv.API.Interfaces
{
    public interface ICardService
    {
        IEnumerable<Card> GetAll();
        void CreateCard(CreateCardRequestModel cardModel);
        Card GetById(int id);
        void UpdateCard(int id, Card card);
        void DeleteCard(int id);
    }
}
