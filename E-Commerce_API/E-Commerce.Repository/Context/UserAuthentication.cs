using E_Commerce.Model.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Repository.Context
{
    public class UserAuthentication
    {
        private readonly E_Commerce_DbContext _context;

        public UserAuthentication(E_Commerce_DbContext context)
        {
            _context = context;
        }

        public bool ValidateCredentials(string username, string password)
        {
            var checkUser = _context.User.FirstOrDefault(x => x.Name == username &&  x.Password == password);
            return checkUser != null;
        }
    }
}
