using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teapot.Entities.Concrete
{
    public class UserProject
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public AppUser User { get; set; }
        public int ProjectId { get; set; }    
        public Project Project { get; set; }
    }
}
