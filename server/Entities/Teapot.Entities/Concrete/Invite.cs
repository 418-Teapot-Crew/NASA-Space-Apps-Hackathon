using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teapot.Entities.Concrete
{
    public class Invite
    {
        public int Id { get; set; }
        public int ContributorId { get; set; }
        public int ProjectId { get; set; }
        public bool Status { get; set; }
        public AppUser Contributor { get; set; }
        public Project Project { get; set; }

    }
}
