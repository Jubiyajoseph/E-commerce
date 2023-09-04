using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Model.Models.UserModel
{
    
    public class User
    {
        public int UserId { get;  }
        public string Name { get; private set; } = string.Empty;         
        public string Email { get; private set; } = string.Empty;         
        public string Phone { get; private set; } = string.Empty;         
        public string Password { get; private set; } = string.Empty;

        public User(string name,string email,string phone,string password)
        {
            Name= name;
            Email= email;
            Phone= phone;
            Password= password;
        }

        public User(string name,string password)
        {
            Name = name;
            Password= password;
        }

    }


}
