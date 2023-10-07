using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teapot.Business.Concrete.Messages.Dto
{
    public class AddMessageDto
    {
        public int SenderId { get; set; }
        public int ChatId { get; set; }
    }
}
