﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuMapFinder.Application.Interfaces
{
    public interface ILoginAppService
    {
        string Login(string username, string password);
    }
}
