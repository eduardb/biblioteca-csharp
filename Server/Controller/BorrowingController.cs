using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.Model;
using Server.Repository;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Server.Controller
{
    class BorrowingController : Controller
    {
        public override string list(Command command)
        {
            Response<List<Borrowing>> response = new Response<List<Borrowing>>();
            response.success = true;
            response.response = Repository.Repository.getInstance().getBorrowings();
            return JsonConvert.SerializeObject(response, Formatting.None);
        }

        public override string get(Command command)
        {
            throw new NotImplementedException();
        }

        public override string put(Command command)
        {
            JArray books = (JArray)command.arg2;

            List<Book> booksList = JsonConvert.DeserializeObject<List<Book>>(JsonConvert.SerializeObject(books));
            List<Book> booksNotBorrowable = Repository.Repository.getInstance().makeBorrowing(command.userID, booksList);

            Response<object> response = new Response<object>();

            if (booksNotBorrowable.Count > 0)
            {
                response.success = false;
                StringBuilder sb = new StringBuilder("Urmatoarele carti nu s-au putut imprumuta:");

                foreach (Book book in booksNotBorrowable)
                {
                    sb.AppendLine();
                    sb.Append(book.ToString());
                }

                response.message = sb.ToString();
            }
            else
            {
                response.success = true;
            }

            return JsonConvert.SerializeObject(response, Formatting.None);
        }

        public override string delete(Command command)
        {
            throw new NotImplementedException();
        }
    }
}
