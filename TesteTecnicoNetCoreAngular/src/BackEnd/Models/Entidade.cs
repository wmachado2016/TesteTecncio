using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models
{
    public abstract class Entidade
    {
        public Guid Id { get; set; }

        public Entidade()
        {
            Id = Guid.NewGuid();
        }
    }
}
