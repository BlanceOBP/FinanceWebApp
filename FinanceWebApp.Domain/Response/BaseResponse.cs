using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceWebApp.Domain.Response
{
    public class BaseResponse<T>
    {
        public string Status { get; set; }
        public string Message { get; set; }
    }
}
