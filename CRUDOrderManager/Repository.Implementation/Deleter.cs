﻿using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementation
{
    public class Deleter<TEntity> : IDelete<TEntity>
    {
        public void Delete(TEntity entity)
        {

        }
    }
}
