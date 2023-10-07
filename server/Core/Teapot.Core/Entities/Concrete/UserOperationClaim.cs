using System;
using System.Collections.Generic;
using System.Text;
using Teapot.Core.Entities.Abstract;

namespace Teapot.Core.Entities.Concrete
{
    public class UserOperationClaim : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
        public OperationClaim OperationClaim { get; set; }
    }
}
