﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Menpos.Domain.Common
{
    public abstract class BaseModel
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public bool IsActive { get; set; }
        public int EstablecimientoId { get; set; }
    }
}
