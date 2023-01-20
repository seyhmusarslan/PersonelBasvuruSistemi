﻿using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Position:BaseEntity
    {
        public int PositionId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
