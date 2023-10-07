using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teapot.Business.Concrete.Chats.Dto
{
    public class AddChatDto
    {
        public int ProjectOwnerId { get; set; }
        public int ContributerId { get; set; }
    }
}
