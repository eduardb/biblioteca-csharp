using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Command
    {
        public string controller { get; set; }
        public string method { get; set; }
        public string arg1 { get; set; }
        public object arg2 { get; set; }
        public string userID { get; set; }
    }
}
