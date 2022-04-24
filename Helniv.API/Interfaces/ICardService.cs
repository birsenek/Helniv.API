using Helniv.API.Entities;

namespace Helniv.API.Interfaces
{
    public interface ICardService
    {
        IEnumerable<Card> GetAll();
        void CreateCard(Card card);
        Card GetById(int id);
        void UpdateCard(int id, Card card);
        void DeleteCard(int id);
    }
}
