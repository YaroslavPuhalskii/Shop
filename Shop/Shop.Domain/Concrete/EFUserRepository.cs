using Shop.Domain.Abstract;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Domain.Concrete
{
    public class EFUserRepository : IUserRepository
    {
        private readonly EFDbContext context = new EFDbContext();
        public IQueryable<User> Users
        {
            get 
            {
                return context.Users;
            }
        }

        public User CreateUser(User user)
        {
            if (user.Id == 0)
            {
                context.Users.Add(user);
            }

            context.SaveChanges();

            return user;
        }
    }
}
