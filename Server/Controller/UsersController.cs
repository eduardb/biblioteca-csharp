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
    class UsersController : Controller
    {
        public override string list(Command command)
        {
            Response<User> response = new Response<User>();
            response.success = false;
            response.message = "Not implemented";
            return JsonConvert.SerializeObject(response, Formatting.None);
        }

        public override string put(Command command)
        {
            Response<User> response = new Response<User>();
            response.success = false;
            response.message = "Not implemented";
            return JsonConvert.SerializeObject(response, Formatting.None);
        }

        public override string get(Command command)
        {
            Response<User> response = new Response<User>();

            if (command.userID.StartsWith("admin"))
            {
                response.success = true;
                response.response = new User { idUser = command.userID, nume = command.userID, privilege = User.Privilege.Admin };
            }
            else
            {
                response.response = Repository.Repository.getInstance().getUserById(command.userID);
                if (response.response != null)
                    response.success = true;
                else
                {
                    response.success = false;
                    response.message = "Invalid login credentials";
                }
            }

            return JsonConvert.SerializeObject(response, Formatting.None);
        }
    }
}
