using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teapot.Business.Concrete.ProjectContributors.Dto
{
    public class AddProjectContributorDto
    {
        public int ProjectId { get; set; }
        public int ContributorId { get; set; }
    }
}
