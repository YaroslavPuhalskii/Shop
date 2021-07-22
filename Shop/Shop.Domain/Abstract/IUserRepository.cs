using System.Linq;
using Shop.Domain.Entities;

namespace Shop.Domain.Abstract
{
    public interface IUserRepository
    {
        IQueryable<User> Users { get; }
        User CreateUser(User user);
    }
}
