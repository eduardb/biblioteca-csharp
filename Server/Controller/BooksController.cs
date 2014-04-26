using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.Model;
using Server.Repository;
using Newtonsoft.Json;

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
            throw new NotImplementedException();
        }

        public override string put(Command command)
        {
            throw new NotImplementedException();
        }
    }
}
