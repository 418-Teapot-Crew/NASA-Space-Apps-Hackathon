using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teapot.Core.Entity.Abstract;

namespace Teapot.Entities.Concrete
{
    public class Message : IEntity
    {

        public int Id { get; set; }
        public int ChatId { get; set; }
        public Chat Chat { get; set; }
        public User Sender { get; set; }    

    }
}
