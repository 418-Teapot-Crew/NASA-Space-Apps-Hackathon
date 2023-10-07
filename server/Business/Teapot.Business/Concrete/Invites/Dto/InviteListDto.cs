using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teapot.Business.Concrete.Invites.Dto
{
    public class InviteListDto
    {
        public int Id { get; set; }
        public int ContributorId { get; set; }
        public int ProjectId { get; set; }
        public ContributorListDto Contributor { get; set; }
        public ProjectListDto Project { get; set; }
        public bool Status { get; set; }

    }
}
