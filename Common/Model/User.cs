using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
    public class User
    {
        public enum Privilege { User, Admin }

        public string idUser { get; set; }
        public string nume { get; set; }
        public Privilege privilege { get; set; }
    }
}
