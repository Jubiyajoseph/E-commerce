﻿using Microsoft.EntityFrameworkCore;
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
            public int UserId { get; set; }

            public string Name { get; set; } = string.Empty;
           
            public string Email { get; set; } = string.Empty;
         
            public string Phone { get; set; } = string.Empty;
          
            public string Password { get; set; } = string.Empty;
    }


}
