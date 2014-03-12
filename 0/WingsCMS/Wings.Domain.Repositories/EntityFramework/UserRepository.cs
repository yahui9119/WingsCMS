using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wings.Domain.Model;
using Wings.Domain.Repositories.Specifications;
using Wings.Domain.Specifications;

namespace Wings.Domain.Repositories.EntityFramework
{
    public class UserRepository:EntityFrameworkRepository<User>,IUserRepository
    {
        public UserRepository(IRepositoryContext context) : base(context) { }
        public bool UserNameExists(string UserName)
        {
            return Exists(new UserNameEqualsSpecification(UserName));
        }

        public bool EmailExists(string Email)
        {
            return Exists(new UserEmailEqualsSpecification(Email));
        }

        public bool CheckPassword(string UserName, string Password)
        {

            return Exists(new UserNameEqualsSpecification(UserName).And(new UserPasswordEqualsSpecification(Password)));
        }

        public User GetUserByEmail(string Email)
        {
            return Get(new UserEmailEqualsSpecification(Email));
        }
    }
}
