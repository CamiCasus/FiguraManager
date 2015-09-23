using System;

namespace Domain.Core.Validations
{
    [Flags]
    public enum AccionValidar
    {
        Create = 1,
        Update = 2,
        Delete = 4
    }
}