using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.CrossCuttingConcerns.Logging
{
    public class LogDetailWithException : LogDetails
    {
        public string ExceptionMessage { get; set; }
    }
}
