using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
    public class Book
    {
        public string CodCarte { get; set; }
        public string Titlu { get; set; }
        public string Autor { get; set; }
        public int NrExemplare { get; set; }

        public override string ToString()
        {
            return Titlu + " - " + Autor + " (" + CodCarte + ")";
        }
    }
}
