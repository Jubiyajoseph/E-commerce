using E_Commerce.Model.Models.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Model.Models.AddressModel
{
    public class DefaultAddress
    {
        public int DefaultAddressId { get; }
        public int AddressId { get; private set; }
        public Address? Address { get; set; }
        public int UserId { get; private set; }
        public User? User { get; set; }
    }
}
