using E_Commerce.Model.Models.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Model.Models.AddressModel
{
    public class AddressHandler
    {
        public int AddressId { get; set; }
        public string ResidentialAddress { get; set; } = string.Empty;
        public int CityId { get; set; }
        public int StateId { get; set; }
        public int CountryId { get; set; }
        public int UserId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
