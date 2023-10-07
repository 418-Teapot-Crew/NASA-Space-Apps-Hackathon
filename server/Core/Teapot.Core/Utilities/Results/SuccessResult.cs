using System;
using System.Collections.Generic;
using System.Text;

namespace Teapot.Core.Utilities.Results
{
    public class SuccessResult : Result
    {
        public SuccessResult(string successMessage) : base(true, successMessage)
        {

        }

        public SuccessResult() : base(true)
        {

        }
    }
}
