﻿using App.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.InMemoryDb
{
    public static class InMemoryDb
    {
        public static Admin OnlineUser { get; set; }
    }
}
