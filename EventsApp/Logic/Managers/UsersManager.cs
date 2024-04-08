using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsApp.Logic.Managers
{
    public class UsersManager
    {
        private static UsersManager _instance;

        public static UsersManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UsersManager();
                }

                return _instance;
            }
        }

        public UsersManager()
        {
        }
    }
}
