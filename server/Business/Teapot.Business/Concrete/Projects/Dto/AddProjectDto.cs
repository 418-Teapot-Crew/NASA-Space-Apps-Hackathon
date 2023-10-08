using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teapot.Business.Concrete.Projects.Dto
{
    public class AddProjectDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int OwnerId { get; set; }
        public DateTime DateTime { get; set; }
        public string ProjectUrl { get; set; }
        public bool Status { get; set; }
    }
}
