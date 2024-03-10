using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistance.Repositories;

namespace CarGo.Domain.Entities
{
    public class Brand : Entity<Guid>
    {
        public string Name { get; set; }

        public virtual ICollection<Model> Models { get; set; } // virtual for supporting different ORMs like nHybernet etc.

        public Brand()
        {
            Models = new HashSet<Model>();
        }

        public Brand(Guid id, string name):this()
        {
            Id = id;
            Name = name;
        }
    }
}
