using OnlineConstructionEquipmentRental.Core.Model;

namespace OnlineConstructionEquipmentRental.Persistence.Repositories.Abstract
{
    public interface ICartRepository
    {
        Cart Get();
        void AddToCart(int id);
        void DeleteFromCart(int id);
        void UpdateCart(Cart cart);
        void Clear();
    }
}