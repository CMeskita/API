using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Exceptions
{
    public class NotFoundException:Exception
    {
        public NotFoundException(string messege) : base(messege)
        {

        }
        public int Code => 404;
    }
}
