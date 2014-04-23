using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Response<T>
    {
        public bool success { get; set; }
        public T response { get; set; }
        public string message { get; set; }
    }
}
