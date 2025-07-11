﻿using Ecommerce_Backend_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_Backend_Core.Interfaces
{
    public interface IAuthRepository
    {
        Task<string> RegisterAsync(User user, string password);
        Task<string> LoginAsync (string userName, string password);
        Task<string> ChangePasswordAsync(string email, string oldPassword, string newPassword);
    }
}
