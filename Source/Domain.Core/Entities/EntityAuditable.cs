﻿using System;

namespace Domain.Core.Entities
{
    public class EntityAuditable<TId> : Entity<TId>
    {
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public string UsuarioModificacion { get; set; }
    }
}
