using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Exceptions
{
    public class ExceptionDetails
    {
        public string Type { get; set; }

        public string Title { get; set; }
        public int? Status { get; set; }
        public string Detail { get; set; }
        public IEnumerable<ValidationExceptionModel> ValidationErrors { get; set; }
    }
}
