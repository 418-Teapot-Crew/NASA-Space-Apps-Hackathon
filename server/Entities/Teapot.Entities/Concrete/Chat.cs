using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teapot.Core.Entity.Abstract;

namespace Teapot.Entities.Concrete
{
    public class Chat : IEntity
    {
        public int Id { get; set; }
        public User ProjectOwner { get; set; }
        public User Contributer { get; set; }
        public ICollection<String> Messages { get; set; }   

    }
}
