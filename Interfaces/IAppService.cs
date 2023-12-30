﻿using MauiBlazorApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiBlazorApp.Interfaces
{
    public interface IAppService
    {
        public Task<string> AuthenticateUser(LoginModel loginModel);
    }
}