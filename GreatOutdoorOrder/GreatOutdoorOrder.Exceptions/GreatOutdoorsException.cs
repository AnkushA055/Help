﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatOutdoorOrder.Exceptions
{
    /// <summary>
    /// Represents project-level user-defined exception.
    /// </summary>
   public class GreatOutdoorsException : ApplicationException
    {
        public GreatOutdoorsException() : base()
        {
        }

        public GreatOutdoorsException(string message) : base(message)
        {
        }

        public GreatOutdoorsException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
