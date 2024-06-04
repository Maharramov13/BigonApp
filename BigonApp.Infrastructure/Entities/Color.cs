﻿using BigonApp.Infrastructure.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigonApp.Infrastructure.Entities
{
    public class Color:BaseEntity
    {
        public string Name { get; set; }
        public string HaxCode { get; set; }
    }
}