using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace Server.Controller
{
    public abstract class Controller
    {
        public String processCommand(Command command)
        {
            switch (command.method)
            {
                case API.Methods.LIST:
                    return list(command);
                case API.Methods.GET:
                    return get(command);
                case API.Methods.PUT:
                    return put(command);
                case API.Methods.DELETE:
                    return delete(command);
            }
            return String.Empty;
        }

        public abstract String list(Command command);
        public abstract String get(Command command);
        public abstract String put(Command command);
        public abstract String delete(Command command);
    }
}
