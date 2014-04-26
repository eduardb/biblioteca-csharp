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

        public static bool operator==(Book b1, Book b2)
        {
            // If both are null, or both are same instance, return true.
            if (System.Object.ReferenceEquals(b1, b2))
            {
                return true;
            }

            // If one is null, but not both, return false.
            if (((object)b1 == null) || ((object)b2 == null))
            {
                return false;
            }
            return b1.Equals(b2);
        }

        public static bool operator!=(Book b1, Book b2)
        {
            return !(b1 == b2);
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return CodCarte.Equals(((Book)obj).CodCarte);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return CodCarte.GetHashCode();
        }
    }
}
