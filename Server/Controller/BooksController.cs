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
    class BooksController : Controller
    {
        public override string list(Command command)
        {
            Response<List<Book>> response = new Response<List<Book>>();
            response.success = true;
            response.response = Repository.Repository.getInstance().getAllBooks((bool)command.arg2);
            return JsonConvert.SerializeObject(response, Formatting.None);
        }

        public override string get(Command command)
        {
            Response<Book> response = new Response<Book>();

            response.response = Repository.Repository.getInstance().getBookByCode(command.arg1);
            response.success = response.response != null;

            return JsonConvert.SerializeObject(response, Formatting.None);
        }

        public override string put(Command command)
        {
            Response<object> response = new Response<object>();

            JObject jBook = (JObject)command.arg2;
            Book book = JsonConvert.DeserializeObject<Book>(JsonConvert.SerializeObject(jBook));
            response.success = Repository.Repository.getInstance().addOrUpdateBook(book);

            return JsonConvert.SerializeObject(response, Formatting.None);
        }
    }
}
