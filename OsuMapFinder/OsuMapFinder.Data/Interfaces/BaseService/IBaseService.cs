﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuMapFinder.Data.Interfaces.BaseService
{
    public interface IBaseService<T>
    {
        void Add(T entity);
    }
}
